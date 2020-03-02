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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Game>()
                .HasOne(g => g.Developer)
                .WithMany(d => d.GamesDeveloped)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Game>()
                .HasOne(g => g.Publisher)
                .WithMany(p => p.GamesPublished)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }

        public DbSet<Game> Games { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Developer> Developers { get; set; }

        public DbSet<Genre> Genres { get; set; }

    }
}
