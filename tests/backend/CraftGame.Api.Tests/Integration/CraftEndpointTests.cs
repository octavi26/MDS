using System.Net;
using System.Net.Http.Json;
using CraftGame.Api.Crafting;
using CraftGame.Api.Data;
using CraftGame.Api.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CraftGame.Api.Tests.Integration;

public sealed class CraftEndpointTests
{
    [Fact]
    public async Task StartSession_CreatesSessionWithStartingInventory()
    {
        await using var factory = CreateFactory(new CapturingAiCraftClient(null));
        await SeedUserLevelAndElementsAsync(factory);

        var client = factory.CreateClient();

        var response = await client.PostAsJsonAsync("/api/sessions/start", new
        {
            userId = TestIds.UserId,
            levelId = TestIds.LevelId
        });

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var payload = await response.Content.ReadFromJsonAsync<StartSessionResponse>();
        Assert.NotNull(payload);
        Assert.NotEqual(Guid.Empty, payload.SessionId);

        var sessionResponse = await client.GetFromJsonAsync<SessionResponse>(
            $"/api/sessions/{payload.SessionId}");

        Assert.NotNull(sessionResponse);
        Assert.Equal(TestIds.LevelId, sessionResponse.LevelId);
        Assert.Equal(["Dust", "Fire"], sessionResponse.Inventory.Select(i => i.Name).ToArray());
    }

    [Fact]
    public async Task PostCraft_PassesSessionLevelContextToAiService()
    {
        var aiClient = new CapturingAiCraftClient(new AiCraftResult(
            "Spark Crystal",
            "test",
            Deterministic: true,
            UsefulSteps: null,
            Difficulty: 3));

        await using var factory = CreateFactory(aiClient);
        await SeedCraftSessionAsync(factory);

        var client = factory.CreateClient();

        var response = await client.PostAsJsonAsync("/api/craft", new
        {
            sessionId = TestIds.SessionId,
            elementA = "Fire",
            elementB = "Dust"
        });

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(aiClient.LastRequest);
        Assert.Equal("Dust", aiClient.LastRequest.ElementA);
        Assert.Equal("Fire", aiClient.LastRequest.ElementB);
        Assert.Equal("Life's Mystery", aiClient.LastRequest.LevelName);
        Assert.Equal(3, aiClient.LastRequest.LevelDifficulty);
        Assert.Equal("Life", aiClient.LastRequest.GoalElement);
        Assert.Equal(["Dust", "Fire"], aiClient.LastRequest.Inventory);
    }

    [Fact]
    public async Task PostCraft_ReturnsProblem_WhenAiServiceFails()
    {
        await using var factory = CreateFactory(new CapturingAiCraftClient(null));
        await SeedCraftSessionAsync(factory);

        var client = factory.CreateClient();

        var response = await client.PostAsJsonAsync("/api/craft", new
        {
            sessionId = TestIds.SessionId,
            elementA = "Fire",
            elementB = "Dust"
        });

        Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
    }

    private static WebApplicationFactory<Program> CreateFactory(IAiCraftClient aiClient)
    {
        var databaseName = $"craft-tests-{Guid.NewGuid()}";

        return new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.UseEnvironment("Testing");
                builder.ConfigureServices(services =>
                {
                    services.RemoveAll<DbContextOptions>();
                    services.RemoveAll<DbContextOptions<CraftGameDbContext>>();
                    services.RemoveAll<IDbContextOptionsConfiguration<CraftGameDbContext>>();
                    services.AddDbContext<CraftGameDbContext>(options =>
                    {
                        options.UseInMemoryDatabase(databaseName);
                    });

                    services.RemoveAll<IAiCraftClient>();
                    services.AddSingleton(aiClient);
                });
            });
    }

    private static async Task SeedCraftSessionAsync(WebApplicationFactory<Program> factory)
    {
        await SeedUserLevelAndElementsAsync(factory);

        using var scope = factory.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<CraftGameDbContext>();

        db.GameSessions.Add(new GameSession
        {
            Id = TestIds.SessionId,
            UserId = TestIds.UserId,
            LevelId = TestIds.LevelId,
            StartTime = DateTime.UtcNow
        });
        db.SessionInventories.AddRange(
            new SessionInventory
            {
                Id = Guid.NewGuid(),
                GameSessionId = TestIds.SessionId,
                ElementId = TestIds.FireId,
                Quantity = 1
            },
            new SessionInventory
            {
                Id = Guid.NewGuid(),
                GameSessionId = TestIds.SessionId,
                ElementId = TestIds.DustId,
                Quantity = 1
            });

        await db.SaveChangesAsync();
    }

    private static async Task SeedUserLevelAndElementsAsync(WebApplicationFactory<Program> factory)
    {
        using var scope = factory.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<CraftGameDbContext>();

        db.Users.Add(new User
        {
            Id = TestIds.UserId,
            Username = "TestPlayer",
            Email = "test@example.com"
        });
        db.Levels.Add(new Level
        {
            Id = TestIds.LevelId,
            Name = "Life's Mystery",
            Description = "Find Life.",
            Difficulty = 3,
            GoalElementName = "Life"
        });
        db.Elements.AddRange(
            new Element
            {
                Id = TestIds.FireId,
                Name = "Fire",
                Description = "A basic fire element",
                Icon = "fire",
                IsStartingElement = true
            },
            new Element
            {
                Id = TestIds.DustId,
                Name = "Dust",
                Description = "A dusty element",
                Icon = "dust",
                IsStartingElement = true
            });

        await db.SaveChangesAsync();
    }

    private sealed class CapturingAiCraftClient(AiCraftResult? result) : IAiCraftClient
    {
        public AiCraftRequest? LastRequest { get; private set; }

        public Task<AiCraftResult?> CraftAsync(
            AiCraftRequest request,
            CancellationToken cancellationToken = default)
        {
            LastRequest = request;
            return Task.FromResult(result);
        }
    }

    private static class TestIds
    {
        public static readonly Guid UserId = Guid.Parse("10000000-0000-0000-0000-000000000001");
        public static readonly Guid LevelId = Guid.Parse("10000000-0000-0000-0000-000000000002");
        public static readonly Guid SessionId = Guid.Parse("10000000-0000-0000-0000-000000000003");
        public static readonly Guid FireId = Guid.Parse("10000000-0000-0000-0000-000000000004");
        public static readonly Guid DustId = Guid.Parse("10000000-0000-0000-0000-000000000005");
    }

    private sealed record StartSessionResponse(Guid SessionId);

    private sealed record SessionResponse(
        Guid Id,
        Guid LevelId,
        IReadOnlyList<SessionInventoryResponse> Inventory);

    private sealed record SessionInventoryResponse(string Name, int Quantity);
}
