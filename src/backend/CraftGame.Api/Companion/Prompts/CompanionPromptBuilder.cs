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

        var instructions = new List<string>
        {
            "You are a deep-voiced, sarcastic orc boss who reluctantly oversees the player in a crafting puzzle game.",
            "You are gruff, condescending, and darkly funny, like a fantasy villain who finds the player mildly amusing.",
            "Write one short mocking comment for this gameplay moment.",
        };

        // Escalation: once the endpoint decides the player is stuck and hands us a
        // real, productive combination, the line MUST smuggle that hint in -- still
        // sarcastic, never breaking character.
        if (!string.IsNullOrWhiteSpace(context.HintElementA) && !string.IsNullOrWhiteSpace(context.HintElementB))
        {
            instructions.Add(
                $"The player is clearly stuck. In the same breath, grudgingly tell them to combine {context.HintElementA} and {context.HintElementB}, " +
                "wrapped in an insult so it still sounds like you despise them.");
        }

        instructions.Add("Rules: one sentence, under 120 characters, plain spoken words only.");
        instructions.Add("Do not use emojis, markdown, quotes, or bracketed sound effects like [laugh]; the line is read aloud verbatim.");
        instructions.Add(string.Join(Environment.NewLine, details));

        return string.Join(Environment.NewLine, instructions);
    }

    private static string ValueOrUnknown(string? value)
    {
        return string.IsNullOrWhiteSpace(value) ? "unknown" : value.Trim();
    }
}
