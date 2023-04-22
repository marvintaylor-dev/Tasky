using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tasky.Server.Migrations
{
    public partial class manyToManySprintsTasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Sprints_AssignedToSprintId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_AssignedToSprintId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "AssignedToSprintId",
                table: "Tasks");

            migrationBuilder.CreateTable(
                name: "NoteModelSprintModel",
                columns: table => new
                {
                    AssignedTasksTaskId = table.Column<int>(type: "int", nullable: false),
                    AssignedToSprintSprintId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteModelSprintModel", x => new { x.AssignedTasksTaskId, x.AssignedToSprintSprintId });
                    table.ForeignKey(
                        name: "FK_NoteModelSprintModel_Sprints_AssignedToSprintSprintId",
                        column: x => x.AssignedToSprintSprintId,
                        principalTable: "Sprints",
                        principalColumn: "SprintId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoteModelSprintModel_Tasks_AssignedTasksTaskId",
                        column: x => x.AssignedTasksTaskId,
                        principalTable: "Tasks",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NoteModelSprintModel_AssignedToSprintSprintId",
                table: "NoteModelSprintModel",
                column: "AssignedToSprintSprintId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoteModelSprintModel");

            migrationBuilder.AddColumn<int>(
                name: "AssignedToSprintId",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AssignedToSprintId",
                table: "Tasks",
                column: "AssignedToSprintId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Sprints_AssignedToSprintId",
                table: "Tasks",
                column: "AssignedToSprintId",
                principalTable: "Sprints",
                principalColumn: "SprintId");
        }
    }
}
