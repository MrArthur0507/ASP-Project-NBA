using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.DbModels;
using System.Reflection.Emit;

namespace NBAProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Stat> Stats { get; set; }

        public DbSet<ApiLogger> ApiLogger { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Player>().Property(p => p.Id).ValueGeneratedNever();
            modelBuilder.Entity<Team>().Property(t => t.Id).ValueGeneratedNever();
            modelBuilder.Entity<Game>().Property(g => g.Id).ValueGeneratedNever();
            modelBuilder.Entity<Stat>().Property(m => m.Id).ValueGeneratedNever();
            modelBuilder.Entity<Meta>().Property(m => m.Id).ValueGeneratedNever();



            modelBuilder.Entity<Game>()
            .HasOne(e => e.HomeTeam)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Game>()
            .HasOne(e => e.VisitorTeam)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Stat>()
            .HasOne(s => s.Team)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);
        }
            
    }
}