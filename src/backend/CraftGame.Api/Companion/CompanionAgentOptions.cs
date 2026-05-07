namespace CraftGame.Api.Companion;

public sealed class CompanionAgentOptions
{
    public const string SectionName = "CompanionAgent";

    public bool Enabled { get; init; } = true;

    public string Provider { get; init; } = CompanionAgentProviders.Deterministic;

    public string OllamaBaseUrl { get; init; } = "http://localhost:11434";

    public string OllamaModel { get; init; } = "qwen2.5:0.5b-instruct";

    public int TimeoutSeconds { get; init; } = 10;
}

public static class CompanionAgentProviders
{
    public const string Deterministic = "deterministic";
    public const string Ollama = "ollama";
}
