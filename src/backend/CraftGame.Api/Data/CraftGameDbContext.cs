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
    }
}
