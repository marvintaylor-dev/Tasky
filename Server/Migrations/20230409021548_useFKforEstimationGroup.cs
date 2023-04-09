using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tasky.Server.Migrations
{
    public partial class useFKforEstimationGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RelativeEstimates_EstimationGroups_EstimationGroupId",
                table: "RelativeEstimates");

            migrationBuilder.DropIndex(
                name: "IX_RelativeEstimates_EstimationGroupId",
                table: "RelativeEstimates");

            migrationBuilder.RenameColumn(
                name: "EstimationGroupId",
                table: "RelativeEstimates",
                newName: "EstimationGroup");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EstimationGroup",
                table: "RelativeEstimates",
                newName: "EstimationGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_RelativeEstimates_EstimationGroupId",
                table: "RelativeEstimates",
                column: "EstimationGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_RelativeEstimates_EstimationGroups_EstimationGroupId",
                table: "RelativeEstimates",
                column: "EstimationGroupId",
                principalTable: "EstimationGroups",
                principalColumn: "EstimationGroupId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
