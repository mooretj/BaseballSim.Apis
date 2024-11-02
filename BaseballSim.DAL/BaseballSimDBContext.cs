using BaseballSim.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BaseballSim.DAL;

public class BaseballSimDBContext(DbContextOptions<BaseballSimDBContext> options) : DbContext(options)
{
    public DbSet<Team> Teams { get; set; }
    public DbSet<Pitcher> Pitchers { get; set; }
    public DbSet<Batter> Batters { get; set; }
    public DbSet<Game> Games { get; set; }
    
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
      modelBuilder.Entity<Team>(team =>
      {
          team.Property(t => t.Name).HasMaxLength(100).IsRequired();
          team.Property(t => t.Division).HasMaxLength(50).IsRequired();
          team.Property(t => t.League).HasMaxLength(50).IsRequired();
          team.Property(t => t.Wins).HasColumnType("int").IsRequired();
          team.Property(t => t.Losses).HasColumnType("int").IsRequired();
      });
      modelBuilder.Entity<Team>().HasKey(t => t.Id);
      modelBuilder.Entity<Team>().HasIndex(t => t.Id).IsUnique();
      modelBuilder.Entity<Team>()
          .HasMany(t => t.Pitchers)
          .WithOne(p => p.Team)
          .HasForeignKey(p => p.TeamId)
          .OnDelete(DeleteBehavior.Cascade);
      modelBuilder.Entity<Team>()
          .HasMany(t => t.Batters)
          .WithOne(b => b.Team)
          .HasForeignKey(b => b.TeamId)
          .OnDelete(DeleteBehavior.Cascade);
  }
}

