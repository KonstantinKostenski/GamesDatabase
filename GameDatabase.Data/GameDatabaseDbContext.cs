using GamesDatabaseBusinessLogic.Models;
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

            builder.Entity<Game>()
                .HasMany(g => g.Reviews)
                .WithOne(r => r.Game)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<GamesFavourites>()
        .HasKey(bc => new { bc.GameId, bc.UserId });
            builder.Entity<GamesFavourites>()
                .HasOne(bc => bc.Game)
                .WithMany(b => b.GamesFavourites)
                .HasForeignKey(bc => bc.GameId);
            builder.Entity<GamesFavourites>()
                .HasOne(bc => bc.User)
                .WithMany(c => c.GamesFavourites)
                .HasForeignKey(bc => bc.UserId);

            base.OnModelCreating(builder);
        }

        public DbSet<Game> Games { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Developer> Developers { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<UserApi> UserApi { get; set; }

        public DbSet<GamesFavourites> GamesFavourites { get; set; }
    }
}
