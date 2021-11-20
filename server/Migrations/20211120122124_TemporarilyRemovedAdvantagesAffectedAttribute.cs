using Microsoft.EntityFrameworkCore.Migrations;

namespace ggGURPS.Migrations
{
    public partial class TemporarilyRemovedAdvantagesAffectedAttribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AffectedAttribute",
                table: "Advantages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AffectedAttribute",
                table: "Advantages",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
