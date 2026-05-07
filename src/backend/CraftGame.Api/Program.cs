using System.Text.Json.Serialization;
using CraftGame.Api.Companion;
using CraftGame.Api.Companion.Ollama;
using CraftGame.Api.Companion.Prompts;
using CraftGame.Api.Companion.Sanitization;
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
    var db = scope.ServiceProvider.GetRequiredService<CraftGameDbContext>();
    await db.Database.MigrateAsync();
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

app.MapPost("/api/craft", async (
    CraftRequest request,
    CraftGameDbContext db,
    IHttpClientFactory httpClientFactory,
    IConfiguration configuration) =>
{
    // 1. Sort element names to ensure deterministic combination lookup
    var elements = new[] { request.ElementA, request.ElementB }.OrderBy(e => e).ToList();
    
    // 2. Call AI Service to get the result of the combination
    var aiServiceUrl = configuration["AiServiceUrl"] ?? "http://ai-service:8001";
    var client = httpClientFactory.CreateClient();
    
    var response = await client.PostAsJsonAsync($"{aiServiceUrl}/craft", new {
        element_a = elements[0],
        element_b = elements[1]
    });

    if (!response.IsSuccessStatusCode) return Results.Problem("AI Service failed to craft.");

    var result = await response.Content.ReadFromJsonAsync<CraftResponse>();
    if (result == null) return Results.Problem("Invalid response from AI Service.");

    // 3. Ensure the result element exists in the DB
    var element = await db.Elements.FirstOrDefaultAsync(e => e.Name == result.Result);
    if (element == null)
    {
        element = new Element
        {
            Id = Guid.NewGuid(),
            Name = result.Result,
            Description = $"Discovered by combining {elements[0]} and {elements[1]}",
            Icon = "✨", // Default icon for discovered elements
            IsStartingElement = false
        };
        db.Elements.Add(element);
        await db.SaveChangesAsync();
    }

    // 4. Add to session inventory if not already there
    var inventoryItem = await db.SessionInventories
        .FirstOrDefaultAsync(si => si.GameSessionId == request.SessionId && si.ElementId == element.Id);

    if (inventoryItem == null)
    {
        db.SessionInventories.Add(new SessionInventory
        {
            Id = Guid.NewGuid(),
            GameSessionId = request.SessionId,
            ElementId = element.Id,
            Quantity = 1
        });
        await db.SaveChangesAsync();
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
public record CraftRequest(Guid SessionId, string ElementA, string ElementB);
public record CraftResponse(string Result);

public partial class Program;
