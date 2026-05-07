namespace CraftGame.Api.Companion;

public sealed record CompanionComment(
    string Text,
    CompanionEventType EventType,
    string Source,
    string? VoiceLineUrl);
