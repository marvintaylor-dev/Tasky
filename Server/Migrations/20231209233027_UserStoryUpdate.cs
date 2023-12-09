using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tasky.Server.Migrations
{
    public partial class UserStoryUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StoryId",
                table: "UserStories",
                newName: "UserStoryId");

            migrationBuilder.RenameColumn(
                name: "UserStory",
                table: "Tasks",
                newName: "UserStoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserStoryId",
                table: "Tasks",
                column: "UserStoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_UserStories_UserStoryId",
                table: "Tasks",
                column: "UserStoryId",
                principalTable: "UserStories",
                principalColumn: "UserStoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_UserStories_UserStoryId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_UserStoryId",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "UserStoryId",
                table: "UserStories",
                newName: "StoryId");

            migrationBuilder.RenameColumn(
                name: "UserStoryId",
                table: "Tasks",
                newName: "UserStory");
        }
    }
}
