using Microsoft.EntityFrameworkCore.Migrations;

namespace ggGURPS.Migrations
{
    public partial class AddsPlayersCampaignsRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TableRelations_CampaignsToPlayers",
                columns: table => new
                {
                    CampaignsId = table.Column<long>(type: "bigint", nullable: false),
                    PlayersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableRelations_CampaignsToPlayers", x => new { x.CampaignsId, x.PlayersId });
                    table.ForeignKey(
                        name: "FK_TableRelations_CampaignsToPlayers_Campaigns_CampaignsId",
                        column: x => x.CampaignsId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableRelations_CampaignsToPlayers_Players_PlayersId",
                        column: x => x.PlayersId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TableRelations_CampaignsToPlayers_PlayersId",
                table: "TableRelations_CampaignsToPlayers",
                column: "PlayersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TableRelations_CampaignsToPlayers");
        }
    }
}
