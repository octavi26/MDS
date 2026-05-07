using System.ComponentModel.DataAnnotations;

namespace CraftGame.Api.Entities;

public class Level
{
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Difficulty { get; set; }
    
    [Required]
    public string GoalElementName { get; set; } = string.Empty;
    
    public ICollection<GameSession> GameSessions { get; set; } = new List<GameSession>();
}
