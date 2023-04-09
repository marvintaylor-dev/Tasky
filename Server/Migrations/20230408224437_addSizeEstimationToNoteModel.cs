using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tasky.Server.Migrations
{
    public partial class addSizeEstimationToNoteModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SizeEstimateEstimationId",
                table: "Tasks",
                type: "int",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_RelativeEstimates_SizeEstimateEstimationId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_SizeEstimateEstimationId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "SizeEstimateEstimationId",
                table: "Tasks");
        }
    }
}
