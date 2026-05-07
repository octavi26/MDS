using CraftGame.Api.Companion;

namespace CraftGame.Api.Tests.Companion;

public sealed class DeterministicCompanionAgentTests
{
    [Fact]
    public async Task GenerateCommentAsync_ReturnsKnownLine_ForSteamDiscovery()
    {
        var agent = new DeterministicCompanionAgent();
        var context = new CompanionEventContext(
            CompanionEventType.ImportantElementDiscovered,
            ElementName: "Steam",
            LevelName: "Basics",
            GoalName: "Steam",
            Inventory: Array.Empty<string>(),
            MoveCount: 3);

        var comment = await agent.GenerateCommentAsync(context);

        Assert.Equal("Steam. Impressive. Humanity speedrun any percent.", comment.Text);
        Assert.Equal("deterministic-fallback", comment.Source);
        Assert.Null(comment.VoiceLineUrl);
    }

    [Fact]
    public async Task GenerateCommentAsync_ReturnsFallback_ForUnknownImportantElement()
    {
        var agent = new DeterministicCompanionAgent();
        var context = new CompanionEventContext(
            CompanionEventType.ImportantElementDiscovered,
            ElementName: "Clay",
            LevelName: null,
            GoalName: null,
            Inventory: Array.Empty<string>(),
            MoveCount: 1);

        var comment = await agent.GenerateCommentAsync(context);

        Assert.Equal("Clay discovered. I will pretend this was always part of the plan.", comment.Text);
    }
}
