using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ModelsLibrary.Models.DbModels;
using System.Reflection.Emit;

namespace NBAProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }

        public DbSet<Season> Seasons { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Stat> Stats { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Stat>().HasKey(s => new { s.GameId, s.PlayerId });
            builder.Entity<Stat>()
            .HasOne(p => p.Player)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Stat>()
            .HasOne(p => p.Game)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Game>()
            .HasOne(e => e.HomeTeam)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Game>()
                .HasOne(e => e.VisitorTeam)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}