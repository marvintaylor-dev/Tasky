using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tasky.Server.Migrations
{
    public partial class updateSprintModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SprintModelSprintId",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_SprintModelSprintId",
                table: "Tasks",
                column: "SprintModelSprintId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Sprints_SprintModelSprintId",
                table: "Tasks",
                column: "SprintModelSprintId",
                principalTable: "Sprints",
                principalColumn: "SprintId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Sprints_SprintModelSprintId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_SprintModelSprintId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "SprintModelSprintId",
                table: "Tasks");
        }
    }
}
