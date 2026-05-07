using CraftGame.Api.Companion;
using CraftGame.Api.Companion.Prompts;

namespace CraftGame.Api.Tests.Companion;

public sealed class CompanionPromptBuilderTests
{
    [Fact]
    public void BuildPrompt_IncludesGameplayContext()
    {
        var builder = new CompanionPromptBuilder();
        var context = new CompanionEventContext(
            CompanionEventType.ImportantElementDiscovered,
            ElementName: "Steam",
            LevelName: "Basics",
            GoalName: "Steam",
            Inventory: ["Water", "Fire", "Steam"],
            MoveCount: 3);

        var prompt = builder.BuildPrompt(context);

        Assert.Contains("event: ImportantElementDiscovered", prompt);
        Assert.Contains("level: Basics", prompt);
        Assert.Contains("goal: Steam", prompt);
        Assert.Contains("element: Steam", prompt);
        Assert.Contains("inventory: Water, Fire, Steam", prompt);
    }

    [Fact]
    public void BuildPrompt_AsksForShortSingleLineOutput()
    {
        var builder = new CompanionPromptBuilder();
        var context = new CompanionEventContext(
            CompanionEventType.LevelCompleted,
            ElementName: null,
            LevelName: "Village Start",
            GoalName: "Village",
            Inventory: Array.Empty<string>(),
            MoveCount: 9);

        var prompt = builder.BuildPrompt(context);

        Assert.Contains("one sentence", prompt);
        Assert.Contains("under 120 characters", prompt);
        Assert.Contains("no markdown", prompt);
    }
}
