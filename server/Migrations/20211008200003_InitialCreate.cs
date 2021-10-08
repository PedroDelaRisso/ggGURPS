using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameMasters",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerCharacters",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CharacterName = table.Column<string>(type: "TEXT", nullable: true),
                    Age = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    PlayerName = table.Column<string>(type: "TEXT", nullable: true),
                    Points = table.Column<int>(type: "INTEGER", nullable: false),
                    Strength = table.Column<int>(type: "INTEGER", nullable: false),
                    Dexterity = table.Column<int>(type: "INTEGER", nullable: false),
                    Inteligence = table.Column<int>(type: "INTEGER", nullable: false),
                    Health = table.Column<int>(type: "INTEGER", nullable: false),
                    FatiguePoints = table.Column<int>(type: "INTEGER", nullable: false),
                    HitPoints = table.Column<int>(type: "INTEGER", nullable: false),
                    Will = table.Column<int>(type: "INTEGER", nullable: false),
                    Perception = table.Column<int>(type: "INTEGER", nullable: false),
                    GameMasterId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerCharacters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerCharacters_GameMasters_GameMasterId",
                        column: x => x.GameMasterId,
                        principalTable: "GameMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdvantageAndDisadvantage",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<int>(type: "INTEGER", nullable: false),
                    AffectedAttribute = table.Column<int>(type: "INTEGER", nullable: false),
                    PlayerCharacterId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvantageAndDisadvantage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdvantageAndDisadvantage_PlayerCharacters_PlayerCharacterId",
                        column: x => x.PlayerCharacterId,
                        principalTable: "PlayerCharacters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<double>(type: "REAL", nullable: true),
                    Equipped = table.Column<bool>(type: "INTEGER", nullable: true),
                    PlayerCharacterId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_PlayerCharacters_PlayerCharacterId",
                        column: x => x.PlayerCharacterId,
                        principalTable: "PlayerCharacters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Difficulty = table.Column<int>(type: "INTEGER", nullable: false),
                    Level = table.Column<int>(type: "INTEGER", nullable: false),
                    Attribute = table.Column<int>(type: "INTEGER", nullable: false),
                    PlayerCharacterId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skill_PlayerCharacters_PlayerCharacterId",
                        column: x => x.PlayerCharacterId,
                        principalTable: "PlayerCharacters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdvantageAndDisadvantage_PlayerCharacterId",
                table: "AdvantageAndDisadvantage",
                column: "PlayerCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_PlayerCharacterId",
                table: "Item",
                column: "PlayerCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerCharacters_GameMasterId",
                table: "PlayerCharacters",
                column: "GameMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_PlayerCharacterId",
                table: "Skill",
                column: "PlayerCharacterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvantageAndDisadvantage");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "PlayerCharacters");

            migrationBuilder.DropTable(
                name: "GameMasters");
        }
    }
}
