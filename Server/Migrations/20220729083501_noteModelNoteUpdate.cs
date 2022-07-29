using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tasky.Server.Migrations
{
    public partial class noteModelNoteUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Tasks_NoteModelTaskId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_NoteModelTaskId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "AssignedToSubTask",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "NoteModelTaskId",
                table: "Notes");

            migrationBuilder.RenameColumn(
                name: "Author",
                table: "Notes",
                newName: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Notes",
                newName: "Author");

            migrationBuilder.AddColumn<int>(
                name: "AssignedToSubTask",
                table: "Notes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NoteModelTaskId",
                table: "Notes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notes_NoteModelTaskId",
                table: "Notes",
                column: "NoteModelTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Tasks_NoteModelTaskId",
                table: "Notes",
                column: "NoteModelTaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId");
        }
    }
}
