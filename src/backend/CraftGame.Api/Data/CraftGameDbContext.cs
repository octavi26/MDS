using Microsoft.EntityFrameworkCore;

namespace CraftGame.Api.Data;

public sealed class CraftGameDbContext(DbContextOptions<CraftGameDbContext> options) : DbContext(options)
{
}
