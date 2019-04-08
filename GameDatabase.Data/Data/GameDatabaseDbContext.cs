using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameDatabase.Data
{
    public class GameDatabaseDbContext : IdentityDbContext
    {
        public GameDatabaseDbContext(DbContextOptions<GameDatabaseDbContext> options)
            : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
    }
}
