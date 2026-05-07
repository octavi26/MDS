using System.ComponentModel.DataAnnotations;

namespace CraftGame.Api.Entities;

public class User
{
    public Guid Id { get; set; }
    [Required]
    public string Username { get; set; } = string.Empty;
    [Required]
    public string Email { get; set; } = string.Empty;
    public ICollection<GameSession> GameSessions { get; set; } = new List<GameSession>();
}
