using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tasky.Server.Migrations
{
    public partial class NotesAndSubtasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "Tasks");

            migrationBuilder.CreateTable(
                name: "SubTasks",
                columns: table => new
                {
                    SubTaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Assignee = table.Column<int>(type: "int", nullable: false),
                    PriorityLevel = table.Column<int>(type: "int", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    AssignedToTask = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubTasks", x => x.SubTaskId);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    NoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssignedToTask = table.Column<int>(type: "int", nullable: false),
                    AssignedToSubTask = table.Column<int>(type: "int", nullable: false),
                    NoteModelTaskId = table.Column<int>(type: "int", nullable: true),
                    SubTaskId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.NoteId);
                    table.ForeignKey(
                        name: "FK_Notes_SubTasks_SubTaskId",
                        column: x => x.SubTaskId,
                        principalTable: "SubTasks",
                        principalColumn: "SubTaskId");
                    table.ForeignKey(
                        name: "FK_Notes_Tasks_NoteModelTaskId",
                        column: x => x.NoteModelTaskId,
                        principalTable: "Tasks",
                        principalColumn: "TaskId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_NoteModelTaskId",
                table: "Notes",
                column: "NoteModelTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_SubTaskId",
                table: "Notes",
                column: "SubTaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "SubTasks");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
