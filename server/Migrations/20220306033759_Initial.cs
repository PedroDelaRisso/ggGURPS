using Microsoft.EntityFrameworkCore.Migrations;

namespace ggGURPS.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    Dexterity = table.Column<int>(type: "int", nullable: false),
                    Inteligence = table.Column<int>(type: "int", nullable: false),
                    Health = table.Column<int>(type: "int", nullable: false),
                    Perception = table.Column<int>(type: "int", nullable: false),
                    Will = table.Column<int>(type: "int", nullable: false),
                    Magery = table.Column<int>(type: "int", nullable: false),
                    DamageReduction = table.Column<int>(type: "int", nullable: false),
                    HitPoints = table.Column<int>(type: "int", nullable: false),
                    FatiguePoints = table.Column<int>(type: "int", nullable: false),
                    EnergyReserves = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChallengeRating = table.Column<int>(type: "int", nullable: false),
                    CharacterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomRolls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomRolls_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaseAttribute = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    CharacterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Spells",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    DamageDice = table.Column<int>(type: "int", nullable: false),
                    Modifier = table.Column<float>(type: "real", nullable: false),
                    CostToCast = table.Column<int>(type: "int", nullable: false),
                    CostToMaintain = table.Column<int>(type: "int", nullable: false),
                    CharacterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spells", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spells_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkillId = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    DamageType = table.Column<int>(type: "int", nullable: false),
                    DamageDice = table.Column<int>(type: "int", nullable: false),
                    Modifier = table.Column<float>(type: "real", nullable: false),
                    Recoil = table.Column<int>(type: "int", nullable: false),
                    RateOfFire = table.Column<int>(type: "int", nullable: false),
                    Shots = table.Column<int>(type: "int", nullable: false),
                    Range = table.Column<int>(type: "int", nullable: false),
                    Accuracy = table.Column<int>(type: "int", nullable: false),
                    ArmorDivisor = table.Column<int>(type: "int", nullable: false),
                    CharacterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomRolls_CharacterId",
                table: "CustomRolls",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CharacterId",
                table: "Items",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_SkillId",
                table: "Items",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_CharacterId",
                table: "Skills",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Spells_CharacterId",
                table: "Spells",
                column: "CharacterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomRolls");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Spells");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Characters");
        }
    }
}
