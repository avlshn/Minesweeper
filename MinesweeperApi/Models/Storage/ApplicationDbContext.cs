using Microsoft.EntityFrameworkCore;

namespace MinesweeperApi.Models.Storage
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<GameDbEntity> Games { get; set; }
    }
}
