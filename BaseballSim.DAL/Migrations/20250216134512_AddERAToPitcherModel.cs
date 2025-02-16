using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseballSim.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddERAToPitcherModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "ERA",
                table: "Pitchers",
                type: "decimal(3,2",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ERA",
                table: "Pitchers");
        }
    }
}
