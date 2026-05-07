using CraftGame.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace CraftGame.Api.Data;

public sealed class CraftGameDbContext(DbContextOptions<CraftGameDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Level> Levels => Set<Level>();
    public DbSet<Element> Elements => Set<Element>();
    public DbSet<GameSession> GameSessions => Set<GameSession>();
    public DbSet<SessionInventory> SessionInventories => Set<SessionInventory>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<GameSession>()
            .HasOne(s => s.User)
            .WithMany(u => u.GameSessions)
            .HasForeignKey(s => s.UserId);

        modelBuilder.Entity<GameSession>()
            .HasOne(s => s.Level)
            .WithMany(l => l.GameSessions)
            .HasForeignKey(s => s.LevelId);

        modelBuilder.Entity<SessionInventory>()
            .HasOne(si => si.GameSession)
            .WithMany(s => s.InventoryItems)
            .HasForeignKey(si => si.GameSessionId);

        modelBuilder.Entity<SessionInventory>()
            .HasOne(si => si.Element)
            .WithMany(e => e.Inventories)
            .HasForeignKey(si => si.ElementId);

        var userId = new Guid("a1b2c3d4-e5f6-7a8b-9c0d-1e2f3a4b5c6d");
        var waterId = new Guid("b1c2d3e4-f5a6-7b8c-9d0e-1f2a3b4c5d6e");
        var fireId = new Guid("c1d2e3f4-a5b6-7c8d-9e0f-1a2b3c4d5e6f");
        var airId = new Guid("f1a2b3c4-d5e6-7f8a-9b0c-1d2e3f4a5b6c");
        var earthId = new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d");
        
        var level1Id = new Guid("e1f2a3b4-c5d6-7e8f-9a0b-1c2d3e4f5a6b");
        var level2Id = new Guid("f2a3b4c5-d6e7-8f9a-0b1c-2d3e4f5a6b7c");
        var level3Id = new Guid("01234567-89ab-cdef-0123-456789abcdef");
        var level4Id = new Guid("fedcba98-7654-3210-fedc-ba9876543210");

        modelBuilder.Entity<User>().HasData(new User
        {
            Id = userId,
            Username = "PlayerOne",
            Email = "playerone@example.com"
        });

        modelBuilder.Entity<Element>().HasData(
            new Element { Id = waterId, Name = "Water", Description = "A basic water element", Icon = "💧", IsStartingElement = true },
            new Element { Id = fireId, Name = "Fire", Description = "A basic fire element", Icon = "🔥", IsStartingElement = true },
            new Element { Id = airId, Name = "Air", Description = "A basic air element", Icon = "💨", IsStartingElement = true },
            new Element { Id = earthId, Name = "Earth", Description = "A basic earth element", Icon = "🌱", IsStartingElement = true }
        );

        modelBuilder.Entity<Level>().HasData(
            new Level
            {
                Id = level1Id,
                Name = "The First Step",
                Description = "Combine elements to create Steam!",
                Difficulty = 1,
                GoalElementName = "Steam"
            },
            new Level
            {
                Id = level2Id,
                Name = "Nature's Recipe",
                Description = "Create Mud and Rain to progress.",
                Difficulty = 2,
                GoalElementName = "Rain"
            },
            new Level
            {
                Id = level3Id,
                Name = "Life's Mystery",
                Description = "Can you find the spark of Life?",
                Difficulty = 3,
                GoalElementName = "Life"
            },
            new Level
            {
                Id = level4Id,
                Name = "Animal Kingdom",
                Description = "Bring a Horse to life!",
                Difficulty = 4,
                GoalElementName = "Horse"
            }
        );
    }
}
