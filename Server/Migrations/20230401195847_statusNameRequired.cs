using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tasky.Server.Migrations
{
    public partial class statusNameRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Why",
                table: "UserStories",
                newName: "Want");

            migrationBuilder.RenameColumn(
                name: "Who",
                table: "UserStories",
                newName: "So");

            migrationBuilder.RenameColumn(
                name: "What",
                table: "UserStories",
                newName: "As");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Want",
                table: "UserStories",
                newName: "Why");

            migrationBuilder.RenameColumn(
                name: "So",
                table: "UserStories",
                newName: "Who");

            migrationBuilder.RenameColumn(
                name: "As",
                table: "UserStories",
                newName: "What");
        }
    }
}
