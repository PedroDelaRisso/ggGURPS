using Microsoft.EntityFrameworkCore.Migrations;

namespace ggGURPS.Migrations
{
    public partial class GameMasterToCharactersRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "GameMasterId",
                table: "Characters",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_GameMasterId",
                table: "Characters",
                column: "GameMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_GameMasters_GameMasterId",
                table: "Characters",
                column: "GameMasterId",
                principalTable: "GameMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_GameMasters_GameMasterId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_GameMasterId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "GameMasterId",
                table: "Characters");
        }
    }
}
