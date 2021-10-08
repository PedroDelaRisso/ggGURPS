using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class RemovesPlayerCharacterIdFromItemModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_PlayerCharacters_PlayerCharacterId",
                table: "Item");

            migrationBuilder.AlterColumn<long>(
                name: "PlayerCharacterId",
                table: "Item",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_PlayerCharacters_PlayerCharacterId",
                table: "Item",
                column: "PlayerCharacterId",
                principalTable: "PlayerCharacters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_PlayerCharacters_PlayerCharacterId",
                table: "Item");

            migrationBuilder.AlterColumn<long>(
                name: "PlayerCharacterId",
                table: "Item",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_PlayerCharacters_PlayerCharacterId",
                table: "Item",
                column: "PlayerCharacterId",
                principalTable: "PlayerCharacters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
