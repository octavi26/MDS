using System.ComponentModel.DataAnnotations;

namespace CraftGame.Api.Entities;

public class CraftingRecipe
{
    public Guid Id { get; set; }

    [Required]
    public string ElementAKey { get; set; } = string.Empty;

    [Required]
    public string ElementBKey { get; set; } = string.Empty;

    [Required]
    public string ElementADisplay { get; set; } = string.Empty;

    [Required]
    public string ElementBDisplay { get; set; } = string.Empty;

    public Guid ResultElementId { get; set; }
    public Element ResultElement { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
}
