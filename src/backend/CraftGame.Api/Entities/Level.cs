using System.ComponentModel.DataAnnotations;

namespace CraftGame.Api.Entities;

public class Level
{
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Difficulty { get; set; }
    public Guid GoalElementId { get; set; }
    public Element GoalElement { get; set; } = null!;
    public ICollection<GameSession> GameSessions { get; set; } = new List<GameSession>();
}
