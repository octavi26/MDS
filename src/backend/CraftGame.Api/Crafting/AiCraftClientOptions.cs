namespace CraftGame.Api.Crafting;

public sealed class AiCraftClientOptions
{
    public const string SectionName = "AiCraftClient";

    public string BaseUrl { get; init; } = "http://ai-service:8001";

    public int TimeoutSeconds { get; init; } = 10;
}
