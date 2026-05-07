namespace CraftGame.Api.Companion;

public sealed record CompanionCommentRequest(
    CompanionEventType EventType,
    string? ElementName,
    string? LevelName,
    string? GoalName,
    IReadOnlyCollection<string>? Inventory,
    int MoveCount)
{
    public CompanionEventContext ToContext()
    {
        return new CompanionEventContext(
            EventType,
            Normalize(ElementName),
            Normalize(LevelName),
            Normalize(GoalName),
            Inventory?.Where(item => !string.IsNullOrWhiteSpace(item)).Select(item => item.Trim()).ToArray()
                ?? Array.Empty<string>(),
            Math.Max(0, MoveCount));
    }

    private static string? Normalize(string? value)
    {
        return string.IsNullOrWhiteSpace(value) ? null : value.Trim();
    }
}
