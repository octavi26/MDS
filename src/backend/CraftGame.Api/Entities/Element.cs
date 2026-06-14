using System.ComponentModel.DataAnnotations;

namespace CraftGame.Api.Entities;

public class Element
{
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public bool IsStartingElement { get; set; }
    public ICollection<Level> Levels { get; set; } = new List<Level>();
    public ICollection<SessionInventory> Inventories { get; set; } = new List<SessionInventory>();
}
