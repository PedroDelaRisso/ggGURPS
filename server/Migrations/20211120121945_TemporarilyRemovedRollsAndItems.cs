using Microsoft.EntityFrameworkCore.Migrations;

namespace ggGURPS.Migrations
{
    public partial class TemporarilyRemovedRollsAndItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rolls");

            migrationBuilder.DropTable(
                name: "TableRelations_CharactersToItems");

            migrationBuilder.DropTable(
                name: "Items");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DamageDice = table.Column<int>(type: "int", nullable: false),
                    DamageModifier = table.Column<int>(type: "int", nullable: false),
                    DamageReduction = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Range = table.Column<int>(type: "int", nullable: false),
                    RateOfFire = table.Column<int>(type: "int", nullable: false),
                    Recoil = table.Column<int>(type: "int", nullable: false),
                    SwingDamageDice = table.Column<int>(type: "int", nullable: false),
                    SwingDamageModifier = table.Column<int>(type: "int", nullable: false),
                    ThrustDamageDice = table.Column<int>(type: "int", nullable: false),
                    ThrustDamageModifier = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rolls",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvantageId = table.Column<long>(type: "bigint", nullable: true),
                    CharacterId = table.Column<long>(type: "bigint", nullable: true),
                    FinalResult = table.Column<int>(type: "int", nullable: false),
                    GameMasterId = table.Column<long>(type: "bigint", nullable: true),
                    Index = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<long>(type: "bigint", nullable: true),
                    Modifier = table.Column<int>(type: "int", nullable: false),
                    NumberOfDice = table.Column<long>(type: "bigint", nullable: false),
                    RollResult = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<long>(type: "bigint", nullable: true),
                    Success = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rolls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rolls_Advantages_AdvantageId",
                        column: x => x.AdvantageId,
                        principalTable: "Advantages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rolls_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rolls_GameMasters_GameMasterId",
                        column: x => x.GameMasterId,
                        principalTable: "GameMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rolls_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rolls_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TableRelations_CharactersToItems",
                columns: table => new
                {
                    CharactersId = table.Column<long>(type: "bigint", nullable: false),
                    ItemsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableRelations_CharactersToItems", x => new { x.CharactersId, x.ItemsId });
                    table.ForeignKey(
                        name: "FK_TableRelations_CharactersToItems_Characters_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableRelations_CharactersToItems_Items_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rolls_AdvantageId",
                table: "Rolls",
                column: "AdvantageId");

            migrationBuilder.CreateIndex(
                name: "IX_Rolls_CharacterId",
                table: "Rolls",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Rolls_GameMasterId",
                table: "Rolls",
                column: "GameMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Rolls_ItemId",
                table: "Rolls",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Rolls_SkillId",
                table: "Rolls",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_TableRelations_CharactersToItems_ItemsId",
                table: "TableRelations_CharactersToItems",
                column: "ItemsId");
        }
    }
}
