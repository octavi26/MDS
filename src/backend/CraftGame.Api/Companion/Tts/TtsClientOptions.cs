namespace CraftGame.Api.Companion.Tts;

public sealed class TtsClientOptions
{
    public const string SectionName = "TtsClient";

    /// <summary>When false, the companion stays text-only (no voice synthesis).</summary>
    public bool Enabled { get; init; } = true;

    /// <summary>Internal URL the backend uses to reach the ai-service /tts endpoint.</summary>
    public string BaseUrl { get; init; } = "http://ai-service:8001";

    /// <summary>Public URL the browser uses to fetch the rendered clip (host-reachable).</summary>
    public string PublicBaseUrl { get; init; } = "http://localhost:8001";

    public int TimeoutSeconds { get; init; } = 30;
}
