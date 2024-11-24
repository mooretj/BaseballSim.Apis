using BaseballSim.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BaseballSim.DAL;

public class BaseballSimDbContext(DbContextOptions<BaseballSimDbContext> options) : DbContext(options)
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

      modelBuilder.Entity<Pitcher>(pitcher =>
      {
          pitcher.Property(p => p.Team).HasMaxLength(100).IsRequired();
          pitcher.Property(p => p.Name).HasMaxLength(100).IsRequired();
          pitcher.Property(p => p.Balls).HasColumnType("int");
          pitcher.Property(p => p.Strikes).HasColumnType("int");
          pitcher.Property(p => p.Hits).HasColumnType("int");
          pitcher.Property(p => p.Walks).HasColumnType("int");
          pitcher.Property(p => p.Singles).HasColumnType("int");
          pitcher.Property(p => p.Doubles).HasColumnType("int");
          pitcher.Property(p => p.Triples).HasColumnType("int");
          pitcher.Property(p => p.HomeRuns).HasColumnType("int");
          pitcher.Property(p => p.StrikeOuts).HasColumnType("int");
          pitcher.Property(p => p.BattersFaced).HasColumnType("int");
          pitcher.Property(p => p.TotalPitches).HasColumnType("int");
          pitcher.Property(p => p.Runs).HasColumnType("int");
          pitcher.Property(p => p.AvgAgainst).HasColumnType("decimal(0,3)");
      });
      modelBuilder.Entity<Pitcher>().HasKey(p => p.PlayerId);
      modelBuilder.Entity<Pitcher>().HasIndex(p => p.PlayerId);

      modelBuilder.Entity<Batter>(batter =>
      {
          batter.Property(b => b.Team).HasMaxLength(100).IsRequired();
          batter.Property(b => b.Name).HasMaxLength(100).IsRequired();
          batter.Property(b => b.Hits).HasColumnType("int");
          batter.Property(b => b.Singles).HasColumnType("int");
          batter.Property(b => b.Doubles).HasColumnType("int");
          batter.Property(b => b.Triples).HasColumnType("int");
          batter.Property(b => b.PlateAppearances).HasColumnType("int");
          batter.Property(b => b.AtBats).HasColumnType("int");
          batter.Property(b => b.Runs).HasColumnType("int");
          batter.Property(b => b.HomeRuns).HasColumnType("int");
          batter.Property(b => b.StrikeOuts).HasColumnType("int");
          batter.Property(b => b.Walks).HasColumnType("int");
          batter.Property(b => b.Rbis).HasColumnType("int");
          batter.Property(b => b.TotalBalls).HasColumnType("int");
          batter.Property(b => b.TotalStrikes).HasColumnType("int");
          batter.Property(b => b.TotalPitchesSeen).HasColumnType("int");
          batter.Property(b => b.BattingAvg).HasColumnType("decimal(0,3");
          batter.Property(b => b.Position).HasMaxLength(50).IsRequired();
      });
      modelBuilder.Entity<Batter>().HasKey(b => b.PlayerId);
      modelBuilder.Entity<Batter>().HasIndex(b => b.PlayerId);

      modelBuilder.Entity<Game>(game =>
      {
          game.Property(g => g.AwayOuts).HasColumnType("int");
          game.Property(g => g.HomeOuts).HasColumnType("int");
          game.Property(g => g.AwayScore).HasColumnType("int");
          game.Property(g => g.HomeScore).HasColumnType("int");
          game.Property(g => g.CurrentInning).HasColumnType("int");
          game.Property(g => g.HomeTeamId).HasColumnType("int");
          game.Property(g => g.AwayTeamId).HasColumnType("int");
          game.Property(g => g.HomeTeamName).HasMaxLength(100);
          game.Property(g => g.AwayTeamName).HasMaxLength(100);
          game.Property(g => g.IsCompleted).HasColumnType("bool");
          game.Property(g => g.GamePlayedDate).HasColumnType("date");
      });
      modelBuilder.Entity<Game>().HasKey(g => g.Id);
      modelBuilder.Entity<Game>().HasIndex(g => g.Id);
      base.OnModelCreating(modelBuilder);
  }
}

