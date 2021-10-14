using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class CreatesItemsAndInventories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharacterId = table.Column<long>(type: "bigint", nullable: false),
                    ItemId = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
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
                    Price = table.Column<double>(type: "float", nullable: true),
                    Weight = table.Column<double>(type: "float", nullable: true),
                    DamageReduction = table.Column<long>(type: "bigint", nullable: true),
                    SwingDamageDice = table.Column<long>(type: "bigint", nullable: true),
                    SwingDamageModifier = table.Column<int>(type: "int", nullable: true),
                    ThrustDamageDice = table.Column<long>(type: "bigint", nullable: true),
                    ThrustDamageModifier = table.Column<int>(type: "int", nullable: true),
                    Recoil = table.Column<long>(type: "bigint", nullable: true),
                    Range = table.Column<long>(type: "bigint", nullable: true),
                    RateOfFire = table.Column<long>(type: "bigint", nullable: true),
                    DamageDice = table.Column<long>(type: "bigint", nullable: true),
                    DamageModifier = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
