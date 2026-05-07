using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CraftGame.Api.Data;

public sealed class CraftGameDbContextFactory : IDesignTimeDbContextFactory<CraftGameDbContext>
{
    public CraftGameDbContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<CraftGameDbContext>()
            .UseNpgsql("Host=localhost;Port=5432;Database=craftgame;Username=craftgame;Password=craftgame")
            .Options;

        return new CraftGameDbContext(options);
    }
}
