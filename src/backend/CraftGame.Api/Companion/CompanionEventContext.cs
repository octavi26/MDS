namespace CraftGame.Api.Companion;

public sealed record CompanionEventContext(
    CompanionEventType EventType,
    string? ElementName,
    string? LevelName,
    string? GoalName,
    IReadOnlyCollection<string> Inventory,
    int MoveCount,
    int StruggleCount = 0,
    // A productive combination to nudge the stuck player toward. Filled in by the
    // endpoint (from the ai-service /hint) once the player has struggled enough.
    string? HintElementA = null,
    string? HintElementB = null);
