using System.ComponentModel.DataAnnotations;

namespace CraftGame.Api.Entities;

public class SessionInventory
{
    public Guid Id { get; set; }
    public Guid GameSessionId { get; set; }
    public GameSession GameSession { get; set; } = null!;
    public Guid ElementId { get; set; }
    public Element Element { get; set; } = null!;
    public int Quantity { get; set; }
}
