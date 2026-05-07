namespace CraftGame.Api.Companion;

public sealed record CompanionEventContext(
    CompanionEventType EventType,
    string? ElementName,
    string? LevelName,
    string? GoalName,
    IReadOnlyCollection<string> Inventory,
    int MoveCount);
