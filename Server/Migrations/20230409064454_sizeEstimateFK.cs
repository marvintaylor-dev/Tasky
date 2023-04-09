using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tasky.Server.Migrations
{
    public partial class sizeEstimateFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_RelativeEstimates_SizeEstimateEstimationId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_SizeEstimateEstimationId",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "SizeEstimateEstimationId",
                table: "Tasks",
                newName: "SizeEstimate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SizeEstimate",
                table: "Tasks",
                newName: "SizeEstimateEstimationId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_SizeEstimateEstimationId",
                table: "Tasks",
                column: "SizeEstimateEstimationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_RelativeEstimates_SizeEstimateEstimationId",
                table: "Tasks",
                column: "SizeEstimateEstimationId",
                principalTable: "RelativeEstimates",
                principalColumn: "EstimationId");
        }
    }
}
