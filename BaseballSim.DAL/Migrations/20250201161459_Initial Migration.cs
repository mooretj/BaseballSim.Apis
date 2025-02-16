using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BaseballSim.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GamePlayedDate = table.Column<DateTime>(type: "date", nullable: false),
                    HomeTeamId = table.Column<int>(type: "int", nullable: false),
                    AwayTeamId = table.Column<int>(type: "int", nullable: false),
                    HomeTeamName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    AwayTeamName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    HomeScore = table.Column<int>(type: "int", nullable: false),
                    AwayScore = table.Column<int>(type: "int", nullable: false),
                    CurrentInning = table.Column<int>(type: "int", nullable: false),
                    HomeOuts = table.Column<int>(type: "int", nullable: false),
                    AwayOuts = table.Column<int>(type: "int", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bool", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    League = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Division = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Wins = table.Column<int>(type: "int", nullable: false),
                    Losses = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Batters",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TeamId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PlateAppearances = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<int>(type: "integer", maxLength: 50, nullable: false),
                    AtBats = table.Column<int>(type: "int", nullable: false),
                    Runs = table.Column<int>(type: "int", nullable: false),
                    Hits = table.Column<int>(type: "int", nullable: false),
                    Singles = table.Column<int>(type: "int", nullable: false),
                    Doubles = table.Column<int>(type: "int", nullable: false),
                    Triples = table.Column<int>(type: "int", nullable: false),
                    HomeRuns = table.Column<int>(type: "int", nullable: false),
                    Rbis = table.Column<int>(type: "int", nullable: false),
                    Walks = table.Column<int>(type: "int", nullable: false),
                    StrikeOuts = table.Column<int>(type: "int", nullable: false),
                    BattingAvg = table.Column<float>(type: "numeric(3,3)", nullable: false),
                    TotalPitchesSeen = table.Column<int>(type: "int", nullable: false),
                    TotalStrikes = table.Column<int>(type: "int", nullable: false),
                    TotalBalls = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batters", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_Batters_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pitchers",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TeamId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    BattersFaced = table.Column<int>(type: "int", nullable: false),
                    TotalPitches = table.Column<int>(type: "int", nullable: false),
                    Runs = table.Column<int>(type: "int", nullable: false),
                    Hits = table.Column<int>(type: "int", nullable: false),
                    Singles = table.Column<int>(type: "int", nullable: false),
                    Doubles = table.Column<int>(type: "int", nullable: false),
                    Triples = table.Column<int>(type: "int", nullable: false),
                    HomeRuns = table.Column<int>(type: "int", nullable: false),
                    Walks = table.Column<int>(type: "int", nullable: false),
                    StrikeOuts = table.Column<int>(type: "int", nullable: false),
                    Strikes = table.Column<int>(type: "int", nullable: false),
                    Balls = table.Column<int>(type: "int", nullable: false),
                    AvgAgainst = table.Column<float>(type: "numeric(3,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pitchers", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_Pitchers_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Batters_PlayerId",
                table: "Batters",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Batters_TeamId",
                table: "Batters",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Id",
                table: "Games",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Pitchers_PlayerId",
                table: "Pitchers",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Pitchers_TeamId",
                table: "Pitchers",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Id",
                table: "Teams",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Batters");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Pitchers");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
