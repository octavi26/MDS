using System.Text.Json.Serialization;
using CraftGame.Api.Companion;
using CraftGame.Api.Data;
using CraftGame.Api.Hubs;
using Microsoft.EntityFrameworkCore;
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

app.MapHub<GameHub>("/hubs/game");

app.Run();

public partial class Program;
