﻿// <auto-generated />
using System;
using BaseballSim.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BaseballSim.DAL.Migrations
{
    [DbContext(typeof(BaseballSimDbContext))]
    partial class BaseballSimDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-rc.2.24474.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BaseballSim.Core.Models.Batter", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PlayerId"));

                    b.Property<int>("AtBats")
                        .HasColumnType("int");

                    b.Property<float>("BattingAvg")
                        .HasColumnType("decimal(3,3)");

                    b.Property<int>("Doubles")
                        .HasColumnType("int");

                    b.Property<int>("Hits")
                        .HasColumnType("int");

                    b.Property<int>("HomeRuns")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("PlateAppearances")
                        .HasColumnType("int");

                    b.Property<int>("Position")
                        .HasMaxLength(50)
                        .HasColumnType("integer");

                    b.Property<int>("Rbis")
                        .HasColumnType("int");

                    b.Property<int>("Runs")
                        .HasColumnType("int");

                    b.Property<int>("Singles")
                        .HasColumnType("int");

                    b.Property<int>("StrikeOuts")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("integer");

                    b.Property<int>("TotalBalls")
                        .HasColumnType("int");

                    b.Property<int>("TotalPitchesSeen")
                        .HasColumnType("int");

                    b.Property<int>("TotalStrikes")
                        .HasColumnType("int");

                    b.Property<int>("Triples")
                        .HasColumnType("int");

                    b.Property<int>("Walks")
                        .HasColumnType("int");

                    b.HasKey("PlayerId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("TeamId");

                    b.ToTable("Batters");
                });

            modelBuilder.Entity("BaseballSim.Core.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AwayOuts")
                        .HasColumnType("int");

                    b.Property<int>("AwayScore")
                        .HasColumnType("int");

                    b.Property<int>("AwayTeamId")
                        .HasColumnType("int");

                    b.Property<string>("AwayTeamName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("CurrentInning")
                        .HasColumnType("int");

                    b.Property<DateTime>("GamePlayedDate")
                        .HasColumnType("date");

                    b.Property<int>("HomeOuts")
                        .HasColumnType("int");

                    b.Property<int>("HomeScore")
                        .HasColumnType("int");

                    b.Property<int>("HomeTeamId")
                        .HasColumnType("int");

                    b.Property<string>("HomeTeamName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bool");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("BaseballSim.Core.Models.Pitcher", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PlayerId"));

                    b.Property<float>("AvgAgainst")
                        .HasColumnType("decimal(3,3)");

                    b.Property<int>("Balls")
                        .HasColumnType("int");

                    b.Property<int>("BattersFaced")
                        .HasColumnType("int");

                    b.Property<int>("Doubles")
                        .HasColumnType("int");

                    b.Property<float>("ERA")
                        .HasColumnType("decimal(3,2)");

                    b.Property<int>("Hits")
                        .HasColumnType("int");

                    b.Property<int>("HomeRuns")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("Runs")
                        .HasColumnType("int");

                    b.Property<int>("Singles")
                        .HasColumnType("int");

                    b.Property<int>("StrikeOuts")
                        .HasColumnType("int");

                    b.Property<int>("Strikes")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("integer");

                    b.Property<int>("TotalPitches")
                        .HasColumnType("int");

                    b.Property<int>("Triples")
                        .HasColumnType("int");

                    b.Property<int>("Walks")
                        .HasColumnType("int");

                    b.HasKey("PlayerId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("TeamId");

                    b.ToTable("Pitchers");
                });

            modelBuilder.Entity("BaseballSim.Core.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Division")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("League")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("Losses")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("Wins")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("BaseballSim.Core.Models.Batter", b =>
                {
                    b.HasOne("BaseballSim.Core.Models.Team", "Team")
                        .WithMany("Batters")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("BaseballSim.Core.Models.Pitcher", b =>
                {
                    b.HasOne("BaseballSim.Core.Models.Team", "Team")
                        .WithMany("Pitchers")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("BaseballSim.Core.Models.Team", b =>
                {
                    b.Navigation("Batters");

                    b.Navigation("Pitchers");
                });
#pragma warning restore 612, 618
        }
    }
}
