namespace CraftGame.Api.Crafting;

public interface IAiCraftClient
{
    Task<AiCraftResult?> CraftAsync(AiCraftRequest request, CancellationToken cancellationToken = default);
}
