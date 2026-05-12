using System.Text.Json.Serialization;

namespace CraftGame.Api.Crafting;

public sealed record AiCraftRequest(
    [property: JsonPropertyName("element_a")] string ElementA,
    [property: JsonPropertyName("element_b")] string ElementB,
    [property: JsonPropertyName("level_name")] string? LevelName,
    [property: JsonPropertyName("level_difficulty")] int? LevelDifficulty,
    [property: JsonPropertyName("goal_element")] string? GoalElement,
    [property: JsonPropertyName("inventory")] IReadOnlyList<string> Inventory);

public sealed record AiCraftResult(
    [property: JsonPropertyName("result")] string Result,
    [property: JsonPropertyName("source")] string? Source,
    [property: JsonPropertyName("deterministic")] bool Deterministic,
    [property: JsonPropertyName("useful_steps")] int? UsefulSteps,
    [property: JsonPropertyName("difficulty")] int? Difficulty);
