namespace CraftGame.Api.Companion.Prompts;

public sealed class CompanionPromptBuilder : ICompanionPromptBuilder
{
    public string BuildPrompt(CompanionEventContext context)
    {
        var details = new List<string>
        {
            $"event: {context.EventType}",
            $"level: {ValueOrUnknown(context.LevelName)}",
            $"goal: {ValueOrUnknown(context.GoalName)}",
            $"element: {ValueOrUnknown(context.ElementName)}",
            $"moves: {context.MoveCount}"
        };

        if (context.Inventory.Count > 0)
        {
            details.Add($"inventory: {string.Join(", ", context.Inventory.Take(8))}");
        }

        return string.Join(Environment.NewLine, new[]
        {
            "You are the companion in a level-based AI crafting puzzle game.",
            "Write one short ironic or funny comment for this gameplay moment.",
            "Rules: one sentence, under 120 characters, no emojis, no markdown, no quotes.",
            string.Join(Environment.NewLine, details)
        });
    }

    private static string ValueOrUnknown(string? value)
    {
        return string.IsNullOrWhiteSpace(value) ? "unknown" : value.Trim();
    }
}
