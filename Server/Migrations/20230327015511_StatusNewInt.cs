using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tasky.Server.Migrations
{
    public partial class StatusNewInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Statuses_StatusNewStatusId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_StatusNewStatusId",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "StatusNewStatusId",
                table: "Tasks",
                newName: "Status");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Tasks",
                newName: "StatusNewStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_StatusNewStatusId",
                table: "Tasks",
                column: "StatusNewStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Statuses_StatusNewStatusId",
                table: "Tasks",
                column: "StatusNewStatusId",
                principalTable: "Statuses",
                principalColumn: "StatusId");
        }
    }
}
