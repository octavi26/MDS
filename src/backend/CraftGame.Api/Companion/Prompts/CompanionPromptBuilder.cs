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
            "You are a deep-voiced, sarcastic orc boss who reluctantly oversees the player in a crafting puzzle game.",
            "You are gruff, condescending, and darkly funny, like a fantasy villain who finds the player mildly amusing.",
            "Write one short mocking comment for this gameplay moment.",
            "Rules: one sentence, under 120 characters, plain spoken words only.",
            "Do not use emojis, markdown, quotes, or bracketed sound effects like [laugh]; the line is read aloud verbatim.",
            string.Join(Environment.NewLine, details)
        });
    }

    private static string ValueOrUnknown(string? value)
    {
        return string.IsNullOrWhiteSpace(value) ? "unknown" : value.Trim();
    }
}
