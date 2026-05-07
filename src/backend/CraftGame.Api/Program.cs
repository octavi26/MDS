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
builder.Services.AddSingleton<ICompanionAgent, DeterministicCompanionAgent>();
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
    return await db.Levels.ToListAsync();
})
.WithTags("Game");

app.MapPost("/api/sessions/start", async (StartSessionRequest request, CraftGameDbContext db) =>
{
    var session = new GameSession
    {
        Id = Guid.NewGuid(),
        UserId = request.UserId,
        LevelId = request.LevelId,
        StartTime = DateTime.UtcNow
    };

    var startingElements = await db.Elements
        .Where(e => e.IsStartingElement)
        .ToListAsync();

    foreach (var element in startingElements)
    {
        session.InventoryItems.Add(new SessionInventory
        {
            Id = Guid.NewGuid(),
            GameSessionId = session.Id,
            ElementId = element.Id,
            Quantity = 1
        });
    }

    db.GameSessions.Add(session);
    await db.SaveChangesAsync();

    return Results.Ok(new { sessionId = session.Id });
})
.WithTags("Game");

app.MapHub<GameHub>("/hubs/game");

app.Run();

public record StartSessionRequest(Guid UserId, Guid LevelId);

public partial class Program;
