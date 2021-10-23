using Microsoft.EntityFrameworkCore.Migrations;

namespace ggGURPS.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advantages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(type: "int", nullable: false),
                    AffectedAttribute = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advantages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameMasters",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemType = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    DamageReduction = table.Column<int>(type: "int", nullable: false),
                    SwingDamageDice = table.Column<int>(type: "int", nullable: false),
                    SwingDamageModifier = table.Column<int>(type: "int", nullable: false),
                    ThrustDamageDice = table.Column<int>(type: "int", nullable: false),
                    ThrustDamageModifier = table.Column<int>(type: "int", nullable: false),
                    Recoil = table.Column<int>(type: "int", nullable: false),
                    Range = table.Column<int>(type: "int", nullable: false),
                    RateOfFire = table.Column<int>(type: "int", nullable: false),
                    DamageDice = table.Column<int>(type: "int", nullable: false),
                    DamageModifier = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpentPoints = table.Column<int>(type: "int", nullable: false),
                    Difficulty = table.Column<int>(type: "int", nullable: false),
                    BaseAttribute = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameMasterId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campaigns_GameMasters_GameMasterId",
                        column: x => x.GameMasterId,
                        principalTable: "GameMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhysicalDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPoints = table.Column<int>(type: "int", nullable: false),
                    SpentPoints = table.Column<int>(type: "int", nullable: false),
                    RemainingPoints = table.Column<int>(type: "int", nullable: false),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    Dexterity = table.Column<int>(type: "int", nullable: false),
                    Inteligence = table.Column<int>(type: "int", nullable: false),
                    Health = table.Column<int>(type: "int", nullable: false),
                    HitPoints = table.Column<int>(type: "int", nullable: false),
                    FatiguePoints = table.Column<int>(type: "int", nullable: false),
                    Will = table.Column<int>(type: "int", nullable: false),
                    Perception = table.Column<int>(type: "int", nullable: false),
                    Npc = table.Column<bool>(type: "bit", nullable: false),
                    PlayerId = table.Column<long>(type: "bigint", nullable: true),
                    CampaignId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TableRelations_PlayersToCampaigns",
                columns: table => new
                {
                    CampaignsId = table.Column<long>(type: "bigint", nullable: false),
                    PlayersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableRelations_PlayersToCampaigns", x => new { x.CampaignsId, x.PlayersId });
                    table.ForeignKey(
                        name: "FK_TableRelations_PlayersToCampaigns_Campaigns_CampaignsId",
                        column: x => x.CampaignsId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableRelations_PlayersToCampaigns_Players_PlayersId",
                        column: x => x.PlayersId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rolls",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfDice = table.Column<long>(type: "bigint", nullable: false),
                    Modifier = table.Column<int>(type: "int", nullable: false),
                    RollResult = table.Column<int>(type: "int", nullable: false),
                    FinalResult = table.Column<int>(type: "int", nullable: false),
                    Index = table.Column<int>(type: "int", nullable: false),
                    Success = table.Column<bool>(type: "bit", nullable: false),
                    CharacterId = table.Column<long>(type: "bigint", nullable: true),
                    GameMasterId = table.Column<long>(type: "bigint", nullable: true),
                    AdvantageId = table.Column<long>(type: "bigint", nullable: true),
                    SkillId = table.Column<long>(type: "bigint", nullable: true),
                    ItemId = table.Column<long>(type: "bigint", nullable: true)
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
                name: "TableRelations_CharactersToAdvantages",
                columns: table => new
                {
                    AdvantagesId = table.Column<long>(type: "bigint", nullable: false),
                    CharactersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableRelations_CharactersToAdvantages", x => new { x.AdvantagesId, x.CharactersId });
                    table.ForeignKey(
                        name: "FK_TableRelations_CharactersToAdvantages_Advantages_AdvantagesId",
                        column: x => x.AdvantagesId,
                        principalTable: "Advantages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableRelations_CharactersToAdvantages_Characters_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "TableRelations_CharactersToSkills",
                columns: table => new
                {
                    CharactersId = table.Column<long>(type: "bigint", nullable: false),
                    SkillsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableRelations_CharactersToSkills", x => new { x.CharactersId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_TableRelations_CharactersToSkills_Characters_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableRelations_CharactersToSkills_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_GameMasterId",
                table: "Campaigns",
                column: "GameMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CampaignId",
                table: "Characters",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_PlayerId",
                table: "Characters",
                column: "PlayerId");

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
                name: "IX_TableRelations_CharactersToAdvantages_CharactersId",
                table: "TableRelations_CharactersToAdvantages",
                column: "CharactersId");

            migrationBuilder.CreateIndex(
                name: "IX_TableRelations_CharactersToItems_ItemsId",
                table: "TableRelations_CharactersToItems",
                column: "ItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_TableRelations_CharactersToSkills_SkillsId",
                table: "TableRelations_CharactersToSkills",
                column: "SkillsId");

            migrationBuilder.CreateIndex(
                name: "IX_TableRelations_PlayersToCampaigns_PlayersId",
                table: "TableRelations_PlayersToCampaigns",
                column: "PlayersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rolls");

            migrationBuilder.DropTable(
                name: "TableRelations_CharactersToAdvantages");

            migrationBuilder.DropTable(
                name: "TableRelations_CharactersToItems");

            migrationBuilder.DropTable(
                name: "TableRelations_CharactersToSkills");

            migrationBuilder.DropTable(
                name: "TableRelations_PlayersToCampaigns");

            migrationBuilder.DropTable(
                name: "Advantages");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "GameMasters");
        }
    }
}
