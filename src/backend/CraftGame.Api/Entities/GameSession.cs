using System.ComponentModel.DataAnnotations;

namespace CraftGame.Api.Entities;

public class GameSession
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    public Guid LevelId { get; set; }
    public Level Level { get; set; } = null!;
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public DateTime? CompletedAt { get; set; }
    public ICollection<SessionInventory> InventoryItems { get; set; } = new List<SessionInventory>();
}
