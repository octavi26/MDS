using CraftGame.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace CraftGame.Api.Data;

public sealed class CraftGameDbContext(DbContextOptions<CraftGameDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Level> Levels => Set<Level>();
    public DbSet<Element> Elements => Set<Element>();
    public DbSet<CraftingRecipe> CraftingRecipes => Set<CraftingRecipe>();
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

        modelBuilder.Entity<CraftingRecipe>()
            .HasIndex(recipe => new { recipe.ElementAKey, recipe.ElementBKey })
            .IsUnique();

        modelBuilder.Entity<CraftingRecipe>()
            .HasOne(recipe => recipe.ResultElement)
            .WithMany(e => e.ResultRecipes)
            .HasForeignKey(recipe => recipe.ResultElementId);

        modelBuilder.Entity<Level>()
            .HasMany(l => l.StartingElements)
            .WithMany(e => e.Levels)
            .UsingEntity<Dictionary<string, object>>(
                "LevelStartingElement",
                j => j.HasOne<Element>().WithMany().HasForeignKey("ElementId"),
                j => j.HasOne<Level>().WithMany().HasForeignKey("LevelId")
            );

        var userId = new Guid("a1b2c3d4-e5f6-7a8b-9c0d-1e2f3a4b5c6d");
        
        // Element IDs
        var waterId = new Guid("b1c2d3e4-f5a6-7b8c-9d0e-1f2a3b4c5d6e");
        var fireId = new Guid("c1d2e3f4-a5b6-7c8d-9e0f-1a2b3c4d5e6f");
        var airId = new Guid("f1a2b3c4-d5e6-7f8a-9b0c-1d2e3f4a5b6c");
        var earthId = new Guid("a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d");
        
        var mudId = new Guid("15d21606-737a-4f8e-81fa-08a439cf407f");
        var steamId = new Guid("24af5e8c-186c-4886-93f4-53171f54045e");
        var energyId = new Guid("52be66d6-c58a-4379-a53d-d75dfcdaee19");
        var stoneId = new Guid("1751b084-2cc8-4abc-9c46-5f915e6e2b79");
        var metalId = new Guid("cfdfef17-ba96-4c95-8849-ff523e7f2fb1");
        var toolId = new Guid("5cdaaf70-a9bb-40d9-aff7-6548cd13867c");
        var woodId = new Guid("399f2f14-ba58-457d-adea-4d6b1cd31b0e");
        var wheelId = new Guid("9e2178d5-f5a1-40ef-9341-0b119bb341ec");
        var engineId = new Guid("7c599ff1-2874-46c8-964d-8a2215368c11");
        var carId = new Guid("4eda4bc0-da00-43e1-83ed-293a35180476");
        var lifeId = new Guid("40e582ff-0317-43a5-83b0-fdc83e2343db");
        var dnaId = new Guid("fb802ed3-aaf1-4f35-a98c-2b0b3ca998ff");
        var humanId = new Guid("2811f056-bcda-4dee-aa12-f49235277733");
        var robotId = new Guid("ed102632-5c7b-4246-a60f-65049935ac77");
        var cyborgId = new Guid("c8cb07b9-90c1-48fc-9252-b0334175091b");

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
            new Element { Id = earthId, Name = "Earth", Description = "A basic earth element", Icon = "🌱", IsStartingElement = true },
            new Element { Id = mudId, Name = "Mud", Description = "Wet earth", Icon = "💩", IsStartingElement = false },
            new Element { Id = steamId, Name = "Steam", Description = "Hot vapor", Icon = "💨", IsStartingElement = false },
            new Element { Id = energyId, Name = "Energy", Description = "Pure power", Icon = "⚡", IsStartingElement = false },
            new Element { Id = stoneId, Name = "Stone", Description = "Hard rock", Icon = "🪨", IsStartingElement = false },
            new Element { Id = metalId, Name = "Metal", Description = "Forged material", Icon = "⛓️", IsStartingElement = false },
            new Element { Id = toolId, Name = "Tool", Description = "Crafted instrument", Icon = "🛠️", IsStartingElement = false },
            new Element { Id = woodId, Name = "Wood", Description = "Organic material", Icon = "🪵", IsStartingElement = false },
            new Element { Id = wheelId, Name = "Wheel", Description = "Rolling tool", Icon = "🎡", IsStartingElement = false },
            new Element { Id = engineId, Name = "Engine", Description = "Machine core", Icon = "⚙️", IsStartingElement = false },
            new Element { Id = carId, Name = "Car", Description = "Vehicle", Icon = "🚗", IsStartingElement = false },
            new Element { Id = lifeId, Name = "Life", Description = "The spark of existence", Icon = "✨", IsStartingElement = false },
            new Element { Id = dnaId, Name = "DNA", Description = "Biological blueprint", Icon = "🧬", IsStartingElement = false },
            new Element { Id = humanId, Name = "Human", Description = "Sentient life", Icon = "🧍", IsStartingElement = false },
            new Element { Id = robotId, Name = "Robot", Description = "Mechanical life", Icon = "🤖", IsStartingElement = false },
            new Element { Id = cyborgId, Name = "Cyborg", Description = "Human-Machine hybrid", Icon = "🦾", IsStartingElement = false }
        );

        var l1Id = new Guid("11111111-1111-1111-1111-111111111111");
        var l2Id = new Guid("22222222-2222-2222-2222-222222222222");
        var l3Id = new Guid("33333333-3333-3333-3333-333333333333");
        var l4Id = new Guid("44444444-4444-4444-4444-444444444444");
        var l5Id = new Guid("55555555-5555-5555-5555-555555555555");
        var l6Id = new Guid("66666666-6666-6666-6666-666666666666");
        var l7Id = new Guid("77777777-7777-7777-7777-777777777777");
        var l8Id = new Guid("88888888-8888-8888-8888-888888888888");
        var l9Id = new Guid("99999999-9999-9999-9999-999999999999");
        var l10Id = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");

        modelBuilder.Entity<Level>().HasData(
            new Level { Id = l1Id, Order = 1, Name = "Mission: First Vapor", Description = "The journey begins. Combine Fire and Water to create Steam.", Difficulty = 1, GoalElementName = "Steam" },
            new Level { Id = l2Id, Order = 2, Name = "Mission: Muddy Path", Description = "Earth meets Water. Find Mud.", Difficulty = 1, GoalElementName = "Mud" },
            new Level { Id = l3Id, Order = 3, Name = "Mission: Solid Base", Description = "Combine Fire and Mud to bake a Stone.", Difficulty = 2, GoalElementName = "Stone" },
            new Level { Id = l4Id, Order = 4, Name = "Mission: Metal Age", Description = "Extreme heat on Stone reveals Metal.", Difficulty = 2, GoalElementName = "Metal" },
            new Level { Id = l5Id, Order = 5, Name = "Mission: Tools of Trade", Description = "Use Metal and Wood to craft a Tool.", Difficulty = 3, GoalElementName = "Tool" },
            new Level { Id = l6Id, Order = 6, Name = "Mission: The Wheel", Description = "A Tool and Wood create the Wheel.", Difficulty = 3, GoalElementName = "Wheel" },
            new Level { Id = l7Id, Order = 7, Name = "Mission: The Engine", Description = "Steam power and Metal give birth to the Engine.", Difficulty = 4, GoalElementName = "Engine" },
            new Level { Id = l8Id, Order = 8, Name = "Mission: Transportation", Description = "Assemble a Car from an Engine and Wheels.", Difficulty = 5, GoalElementName = "Car" },
            new Level { Id = l9Id, Order = 9, Name = "Mission: Biotechnology", Description = "Infuse Life into DNA to create a Human.", Difficulty = 6, GoalElementName = "Human" },
            new Level { Id = l10Id, Order = 10, Name = "Mission: The Singularity", Description = "The ultimate union. Merge Human and Robot into a Cyborg.", Difficulty = 8, GoalElementName = "Cyborg" }
        );

        modelBuilder.Entity("LevelStartingElement").HasData(
            // Level 1: Fire, Water -> Steam
            new { LevelId = l1Id, ElementId = fireId },
            new { LevelId = l1Id, ElementId = waterId },
            
            // Level 2: Earth, Water -> Mud
            new { LevelId = l2Id, ElementId = earthId },
            new { LevelId = l2Id, ElementId = waterId },
            
            // Level 3: Fire, Mud -> Stone
            new { LevelId = l3Id, ElementId = fireId },
            new { LevelId = l3Id, ElementId = mudId },
            
            // Level 4: Fire, Stone -> Metal
            new { LevelId = l4Id, ElementId = fireId },
            new { LevelId = l4Id, ElementId = stoneId },
            
            // Level 5: Metal, Wood -> Tool
            new { LevelId = l5Id, ElementId = metalId },
            new { LevelId = l5Id, ElementId = woodId },
            
            // Level 6: Tool, Wood -> Wheel
            new { LevelId = l6Id, ElementId = toolId },
            new { LevelId = l6Id, ElementId = woodId },
            
            // Level 7: Steam, Metal, Fire -> Engine
            new { LevelId = l7Id, ElementId = steamId },
            new { LevelId = l7Id, ElementId = metalId },
            new { LevelId = l7Id, ElementId = fireId },
            
            // Level 8: Engine, Wheel -> Car
            new { LevelId = l8Id, ElementId = engineId },
            new { LevelId = l8Id, ElementId = wheelId },
            
            // Level 9: Life, DNA -> Human
            new { LevelId = l9Id, ElementId = lifeId },
            new { LevelId = l9Id, ElementId = dnaId },
            
            // Level 10: Human, Robot, Energy -> Cyborg
            new { LevelId = l10Id, ElementId = humanId },
            new { LevelId = l10Id, ElementId = robotId },
            new { LevelId = l10Id, ElementId = energyId }
        );
    }
}
