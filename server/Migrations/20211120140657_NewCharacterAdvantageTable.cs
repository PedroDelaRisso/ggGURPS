using Microsoft.EntityFrameworkCore.Migrations;

namespace ggGURPS.Migrations
{
    public partial class NewCharacterAdvantageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TableRelations_CharactersToAdvantages_Advantages_AdvantagesId",
                table: "TableRelations_CharactersToAdvantages");

            migrationBuilder.DropForeignKey(
                name: "FK_TableRelations_CharactersToAdvantages_Characters_CharactersId",
                table: "TableRelations_CharactersToAdvantages");

            migrationBuilder.DropTable(
                name: "CharacterAdvantage");

            migrationBuilder.RenameColumn(
                name: "CharactersId",
                table: "TableRelations_CharactersToAdvantages",
                newName: "AdvantageId");

            migrationBuilder.RenameColumn(
                name: "AdvantagesId",
                table: "TableRelations_CharactersToAdvantages",
                newName: "CharacterId");

            migrationBuilder.RenameIndex(
                name: "IX_TableRelations_CharactersToAdvantages_CharactersId",
                table: "TableRelations_CharactersToAdvantages",
                newName: "IX_TableRelations_CharactersToAdvantages_AdvantageId");

            migrationBuilder.AddForeignKey(
                name: "FK_TableRelations_CharactersToAdvantages_Advantages_AdvantageId",
                table: "TableRelations_CharactersToAdvantages",
                column: "AdvantageId",
                principalTable: "Advantages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TableRelations_CharactersToAdvantages_Characters_CharacterId",
                table: "TableRelations_CharactersToAdvantages",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TableRelations_CharactersToAdvantages_Advantages_AdvantageId",
                table: "TableRelations_CharactersToAdvantages");

            migrationBuilder.DropForeignKey(
                name: "FK_TableRelations_CharactersToAdvantages_Characters_CharacterId",
                table: "TableRelations_CharactersToAdvantages");

            migrationBuilder.RenameColumn(
                name: "AdvantageId",
                table: "TableRelations_CharactersToAdvantages",
                newName: "CharactersId");

            migrationBuilder.RenameColumn(
                name: "CharacterId",
                table: "TableRelations_CharactersToAdvantages",
                newName: "AdvantagesId");

            migrationBuilder.RenameIndex(
                name: "IX_TableRelations_CharactersToAdvantages_AdvantageId",
                table: "TableRelations_CharactersToAdvantages",
                newName: "IX_TableRelations_CharactersToAdvantages_CharactersId");

            migrationBuilder.CreateTable(
                name: "CharacterAdvantage",
                columns: table => new
                {
                    CharacterId = table.Column<long>(type: "bigint", nullable: false),
                    AdvantageId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterAdvantage", x => new { x.CharacterId, x.AdvantageId });
                    table.ForeignKey(
                        name: "FK_CharacterAdvantage_Advantages_AdvantageId",
                        column: x => x.AdvantageId,
                        principalTable: "Advantages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterAdvantage_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterAdvantage_AdvantageId",
                table: "CharacterAdvantage",
                column: "AdvantageId");

            migrationBuilder.AddForeignKey(
                name: "FK_TableRelations_CharactersToAdvantages_Advantages_AdvantagesId",
                table: "TableRelations_CharactersToAdvantages",
                column: "AdvantagesId",
                principalTable: "Advantages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TableRelations_CharactersToAdvantages_Characters_CharactersId",
                table: "TableRelations_CharactersToAdvantages",
                column: "CharactersId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
