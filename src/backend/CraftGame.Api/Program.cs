using System.Text.Json.Serialization;
using CraftGame.Api.Companion;
using CraftGame.Api.Companion.Ollama;
using CraftGame.Api.Companion.Prompts;
using CraftGame.Api.Companion.Sanitization;
using CraftGame.Api.Crafting;
using CraftGame.Api.Data;
using CraftGame.Api.Entities;
using CraftGame.Api.Hubs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>
{
    configuration
        .ReadFrom.Configuration(context.Configuration)
        .Enrich.FromLogContext()
        .WriteTo.Console();
});

builder.Services.AddDbContext<CraftGameDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
        ?? "Host=localhost;Port=5432;Database=craftgame;Username=craftgame;Password=craftgame";

    options.UseNpgsql(connectionString);
    options.ConfigureWarnings(w => w.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning));
});

builder.Services.AddSignalR();
builder.Services.Configure<AiCraftClientOptions>(
    builder.Configuration.GetSection(AiCraftClientOptions.SectionName));
builder.Services.AddHttpClient<IAiCraftClient, HttpAiCraftClient>((serviceProvider, client) =>
{
    var options = serviceProvider.GetRequiredService<IOptions<AiCraftClientOptions>>().Value;
    client.BaseAddress = new Uri(options.BaseUrl);
    client.Timeout = TimeSpan.FromSeconds(Math.Max(1, options.TimeoutSeconds));
});
builder.Services.Configure<CompanionAgentOptions>(
    builder.Configuration.GetSection(CompanionAgentOptions.SectionName));
builder.Services.AddHttpClient<IOllamaClient, OllamaClient>((serviceProvider, client) =>
{
    var options = serviceProvider.GetRequiredService<IOptions<CompanionAgentOptions>>().Value;
    client.BaseAddress = new Uri(options.OllamaBaseUrl);
});
builder.Services.AddSingleton<ICompanionPromptBuilder, CompanionPromptBuilder>();
builder.Services.AddSingleton<ICompanionLineSanitizer, CompanionLineSanitizer>();
builder.Services.AddSingleton<DeterministicCompanionAgent>();
builder.Services.AddTransient<OllamaCompanionAgent>();
builder.Services.AddTransient<ICompanionAgent>(serviceProvider =>
{
    var options = serviceProvider.GetRequiredService<IOptions<CompanionAgentOptions>>().Value;

    if (!options.Enabled || !string.Equals(options.Provider, CompanionAgentProviders.Ollama, StringComparison.OrdinalIgnoreCase))
    {
        return serviceProvider.GetRequiredService<DeterministicCompanionAgent>();
    }

    return serviceProvider.GetRequiredService<OllamaCompanionAgent>();
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("Frontend", policy =>
    {
        policy
            .WithOrigins("http://localhost:5173", "http://127.0.0.1:5173")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    if (!app.Environment.IsEnvironment("Testing"))
    {
        var db = scope.ServiceProvider.GetRequiredService<CraftGameDbContext>();
        await db.Database.MigrateAsync();
    }
}

app.UseSerilogRequestLogging();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("Frontend");

app.MapGet("/health", () => Results.Ok(new
{
    status = "ok",
    service = "craft-game-api"
}))
.WithTags("System");

app.MapGet("/ready", async (CraftGameDbContext db, CancellationToken cancellationToken) =>
{
    var canConnect = await db.Database.CanConnectAsync(cancellationToken);
    return canConnect
        ? Results.Ok(new { status = "ready", database = "connected" })
        : Results.Problem("Database is not reachable.");
})
.WithTags("System");

app.MapPost("/api/companion/comments", async (
    CompanionCommentRequest request,
    ICompanionAgent companionAgent,
    CancellationToken cancellationToken) =>
{
    var comment = await companionAgent.GenerateCommentAsync(request.ToContext(), cancellationToken);
    return Results.Ok(comment);
})
.WithTags("Companion");

app.MapPost("/api/users/register", async (RegisterUserRequest request, CraftGameDbContext db, CancellationToken cancellationToken) =>
{
    var user = new User
    {
        Id = Guid.NewGuid(),
        Username = request.Username,
        Email = $"{request.Username.ToLower()}@example.com"
    };

    db.Users.Add(user);
    await db.SaveChangesAsync(cancellationToken);

    return Results.Ok(new { id = user.Id, username = user.Username });
})
.WithTags("Users");

app.MapGet("/api/levels", async (CraftGameDbContext db) =>
{
    var startingElements = await db.Elements
        .Where(e => e.IsStartingElement)
        .Select(e => e.Name)
        .ToListAsync();

    return await db.Levels
        .Select(l => new {
            l.Id,
            l.Name,
            l.Description,
            l.Difficulty,
            GoalItem = l.GoalElementName,
            StartingItems = startingElements
        })
        .ToListAsync();
})
.WithTags("Game");

app.MapPost("/api/sessions/start", async (
    StartSessionRequest request,
    CraftGameDbContext db,
    CancellationToken cancellationToken) =>
{
    var userExists = await db.Users.AnyAsync(u => u.Id == request.UserId, cancellationToken);
    var levelExists = await db.Levels.AnyAsync(l => l.Id == request.LevelId, cancellationToken);

    if (!userExists || !levelExists)
    {
        return Results.NotFound("User or level was not found.");
    }

    var existingSession = await db.GameSessions
        .Include(s => s.InventoryItems)
        .ThenInclude(si => si.Element)
        .Where(s => s.UserId == request.UserId && s.LevelId == request.LevelId && s.CompletedAt == null)
        .OrderByDescending(s => s.StartTime)
        .FirstOrDefaultAsync(cancellationToken);

    if (existingSession != null)
    {
        return Results.Ok(new
        {
            sessionId = existingSession.Id,
            inventory = existingSession.InventoryItems
                .OrderBy(si => si.Element.Name)
                .Select(si => new
                {
                    name = si.Element.Name,
                    quantity = si.Quantity
                }),
            isResumed = true
        });
    }

    var startingElements = await db.Elements
        .Where(e => e.IsStartingElement)
        .OrderBy(e => e.Name)
        .ToListAsync(cancellationToken);

    var session = new GameSession
    {
        Id = Guid.NewGuid(),
        UserId = request.UserId,
        LevelId = request.LevelId,
        StartTime = DateTime.UtcNow
    };

    db.GameSessions.Add(session);
    db.SessionInventories.AddRange(startingElements.Select(element => new SessionInventory
    {
        Id = Guid.NewGuid(),
        GameSessionId = session.Id,
        ElementId = element.Id,
        Quantity = 1
    }));

    await db.SaveChangesAsync(cancellationToken);

    return Results.Ok(new 
    { 
        sessionId = session.Id,
        inventory = startingElements.Select(e => new { name = e.Name, quantity = 1 }),
        isResumed = false 
    });
})
.WithTags("Game");

app.MapGet("/api/sessions/{sessionId:guid}", async (
    Guid sessionId,
    CraftGameDbContext db,
    CancellationToken cancellationToken) =>
{
    var session = await db.GameSessions
        .Include(s => s.InventoryItems)
        .ThenInclude(si => si.Element)
        .FirstOrDefaultAsync(s => s.Id == sessionId, cancellationToken);

    if (session == null)
    {
        return Results.NotFound("Game session was not found.");
    }

    return Results.Ok(new
    {
        id = session.Id,
        levelId = session.LevelId,
        inventory = session.InventoryItems
            .OrderBy(si => si.Element.Name)
            .Select(si => new
            {
                name = si.Element.Name,
                quantity = si.Quantity
            })
    });
})
.WithTags("Game");

app.MapPost("/api/craft", async (
    CraftRequest request,
    CraftGameDbContext db,
    IAiCraftClient aiCraftClient,
    CancellationToken cancellationToken) =>
{
    var elements = new[] { request.ElementA, request.ElementB }.OrderBy(e => e).ToList();

    var session = await db.GameSessions
        .Include(s => s.Level)
        .Include(s => s.InventoryItems)
        .ThenInclude(si => si.Element)
        .FirstOrDefaultAsync(s => s.Id == request.SessionId, cancellationToken);

    if (session == null)
    {
        return Results.NotFound("Game session was not found.");
    }

    var result = await aiCraftClient.CraftAsync(new AiCraftRequest(
        ElementA: elements[0],
        ElementB: elements[1],
        LevelName: session.Level.Name,
        LevelDifficulty: session.Level.Difficulty,
        GoalElement: session.Level.GoalElementName,
        Inventory: session.InventoryItems
            .Select(si => si.Element.Name)
            .OrderBy(name => name)
            .ToList()), cancellationToken);

    if (result == null || string.IsNullOrWhiteSpace(result.Result))
    {
        return Results.Problem("AI Service failed to craft.");
    }

    var element = await db.Elements.FirstOrDefaultAsync(e => e.Name == result.Result, cancellationToken);
    if (element == null)
    {
        element = new Element
        {
            Id = Guid.NewGuid(),
            Name = result.Result,
            Description = $"Discovered by combining {elements[0]} and {elements[1]}",
            Icon = "✨",
            IsStartingElement = false
        };
        db.Elements.Add(element);
        await db.SaveChangesAsync(cancellationToken);
    }

    var inventoryItem = await db.SessionInventories
        .FirstOrDefaultAsync(si => si.GameSessionId == request.SessionId && si.ElementId == element.Id, cancellationToken);

    if (inventoryItem == null)
    {
        db.SessionInventories.Add(new SessionInventory
        {
            Id = Guid.NewGuid(),
            GameSessionId = request.SessionId,
            ElementId = element.Id,
            Quantity = 1
        });
        await db.SaveChangesAsync(cancellationToken);
    }

    return Results.Ok(new { 
        name = element.Name, 
        description = element.Description,
        icon = element.Icon
    });
})
.WithTags("Game");

app.MapHub<GameHub>("/hubs/game");

app.Run();

public record StartSessionRequest(Guid UserId, Guid LevelId);
public record RegisterUserRequest(string Username);
public record CraftRequest(Guid SessionId, string ElementA, string ElementB);

public partial class Program;
