using Microsoft.EntityFrameworkCore;

namespace MinesweeperApi.Models.Storage;

/// <summary>
/// Application DB context class
/// </summary>
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    }

    public DbSet<GameDbEntity> Games { get; set; }
}
