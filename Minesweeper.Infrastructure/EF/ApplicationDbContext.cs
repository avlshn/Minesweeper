using Microsoft.EntityFrameworkCore;
using Minesweeper.Core.Models;

namespace MinesweeperApi.Models.Storage;

/// <summary>
/// Application DB context class
/// </summary>
public class ApplicationDbContext : DbContext
{
    /// <summary>
    /// Default constructor
    /// </summary>
    /// <param name="options"></param>
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    /// <summary>
    /// Game Db entity
    /// </summary>
    public DbSet<GameDbEntity> Games { get; set; }
}
