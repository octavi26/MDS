using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using CraftGame.Api.Companion;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace CraftGame.Api.Tests.Integration;

public sealed class CompanionEndpointTests
{
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web)
    {
        Converters = { new JsonStringEnumConverter() }
    };

    [Fact]
    public async Task PostComment_ReturnsCompanionLine()
    {
        await using var factory = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder => builder.UseEnvironment("Testing"));

        var client = factory.CreateClient();
        var request = new CompanionCommentRequest(
            CompanionEventType.LevelCompleted,
            ElementName: null,
            LevelName: "Village Start",
            GoalName: "Village",
            Inventory: ["Wood", "House", "Village"],
            MoveCount: 9);

        var response = await client.PostAsJsonAsync("/api/companion/comments", request, JsonOptions);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var comment = await response.Content.ReadFromJsonAsync<CompanionComment>(JsonOptions);

        Assert.NotNull(comment);
        Assert.Equal(CompanionEventType.LevelCompleted, comment.EventType);
        Assert.Equal("Village Start complete: Village. Clean work, suspiciously competent.", comment.Text);
        Assert.Equal("deterministic-fallback", comment.Source);
    }
}
