namespace CraftGame.Api.Companion;

public sealed class DeterministicCompanionAgent : ICompanionAgent
{
    private const string Source = "deterministic-fallback";

    private static readonly IReadOnlyDictionary<string, string> ImportantElementLines =
        new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            ["Steam"] = "Steam. Impressive. Humanity speedrun any percent.",
            ["House"] = "A house. Finally, the elements have discovered rent.",
            ["Village"] = "Village unlocked. Society has entered its group chat era.",
            ["Fire"] = "Fire. Bold choice. History usually starts getting expensive here.",
            ["Tool"] = "A tool. The universe now has project management."
        };

    public Task<CompanionComment> GenerateCommentAsync(
        CompanionEventContext context,
        CancellationToken cancellationToken = default)
    {
        var line = context.EventType switch
        {
            CompanionEventType.ImportantElementDiscovered => ImportantElementDiscovered(context),
            CompanionEventType.LevelCompleted => LevelCompleted(context),
            CompanionEventType.FirstDiscovery => FirstDiscovery(context),
            CompanionEventType.FailedCombination => FailedCombination(context),
            _ => "Noted. The cosmos refuses to elaborate."
        };

        return Task.FromResult(new CompanionComment(
            line,
            context.EventType,
            Source,
            VoiceLineUrl: null));
    }

    private static string ImportantElementDiscovered(CompanionEventContext context)
    {
        if (context.ElementName is not null && ImportantElementLines.TryGetValue(context.ElementName, out var line))
        {
            return line;
        }

        var element = context.ElementName ?? "Something";
        return $"{element} discovered. I will pretend this was always part of the plan.";
    }

    private static string LevelCompleted(CompanionEventContext context)
    {
        var level = context.LevelName ?? "Level";
        var goal = context.GoalName ?? "the objective";

        return $"{level} complete: {goal}. Clean work, suspiciously competent.";
    }

    private static string FirstDiscovery(CompanionEventContext context)
    {
        var element = context.ElementName ?? "a new thing";
        return $"First discovery: {element}. Tiny miracle, medium paperwork.";
    }

    private static string FailedCombination(CompanionEventContext context)
    {
        return context.MoveCount > 0
            ? "Nothing happened. A brave contribution to negative science."
            : "Nothing happened. Even the void checked its notes.";
    }
}
