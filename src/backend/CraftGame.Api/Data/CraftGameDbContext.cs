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

        modelBuilder.Entity<Level>()
            .HasOne(l => l.GoalElement)
            .WithMany()
            .HasForeignKey(l => l.GoalElementId);

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
        var steamId = new Guid("d1e2f3a4-b5c6-7d8e-9f0a-1b2c3d4e5f6a");
        var levelId = new Guid("e1f2a3b4-c5d6-7e8f-9a0b-1c2d3e4f5a6b");

        modelBuilder.Entity<User>().HasData(new User
        {
            Id = userId,
            Username = "PlayerOne",
            Email = "playerone@example.com"
        });

        modelBuilder.Entity<Element>().HasData(
            new Element { Id = waterId, Name = "Water", Description = "A basic water element", Icon = "💧", IsStartingElement = true },
            new Element { Id = fireId, Name = "Fire", Description = "A basic fire element", Icon = "🔥", IsStartingElement = true },
            new Element { Id = steamId, Name = "Steam", Description = "A hot steam element", Icon = "💨", IsStartingElement = false }
        );

        modelBuilder.Entity<Level>().HasData(new Level
        {
            Id = levelId,
            Name = "The First Step",
            Description = "Combine elements to create Steam!",
            Difficulty = 1,
            GoalElementId = steamId
        });
    }
}
