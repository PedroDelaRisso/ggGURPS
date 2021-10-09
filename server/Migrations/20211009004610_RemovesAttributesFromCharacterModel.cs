using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class RemovesAttributesFromCharacterModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "PlayerCharacters");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "PlayerCharacters");

            migrationBuilder.DropColumn(
                name: "Perception",
                table: "PlayerCharacters");

            migrationBuilder.DropColumn(
                name: "PlayerName",
                table: "PlayerCharacters");

            migrationBuilder.DropColumn(
                name: "Points",
                table: "PlayerCharacters");

            migrationBuilder.DropColumn(
                name: "Will",
                table: "PlayerCharacters");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Age",
                table: "PlayerCharacters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "PlayerCharacters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Perception",
                table: "PlayerCharacters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PlayerName",
                table: "PlayerCharacters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "PlayerCharacters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Will",
                table: "PlayerCharacters",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
