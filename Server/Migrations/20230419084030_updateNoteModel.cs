using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tasky.Server.Migrations
{
    public partial class updateNoteModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Sprints_AssignedToSprintSprintId",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "AssignedToSprintSprintId",
                table: "Tasks",
                newName: "AssignedToSprintId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_AssignedToSprintSprintId",
                table: "Tasks",
                newName: "IX_Tasks_AssignedToSprintId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Sprints_AssignedToSprintId",
                table: "Tasks",
                column: "AssignedToSprintId",
                principalTable: "Sprints",
                principalColumn: "SprintId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Sprints_AssignedToSprintId",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "AssignedToSprintId",
                table: "Tasks",
                newName: "AssignedToSprintSprintId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_AssignedToSprintId",
                table: "Tasks",
                newName: "IX_Tasks_AssignedToSprintSprintId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Sprints_AssignedToSprintSprintId",
                table: "Tasks",
                column: "AssignedToSprintSprintId",
                principalTable: "Sprints",
                principalColumn: "SprintId");
        }
    }
}
