using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tasky.Server.Migrations
{
    public partial class addSprints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SprintModelSprintId",
                table: "Members",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Sprints",
                columns: table => new
                {
                    SprintId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SprintNumber = table.Column<int>(type: "int", nullable: true),
                    SprintBudget = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    PreviousVelocity = table.Column<int>(type: "int", nullable: true),
                    CurrentMinCapacity = table.Column<int>(type: "int", nullable: true),
                    CurrentMaxCapacity = table.Column<int>(type: "int", nullable: true),
                    TeamId = table.Column<int>(type: "int", nullable: true),
                    Holidays = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlannedTraining = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PercentOfTimeOnFeatures = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    PercentOfTimeOnDebt = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    PercentOfTimeOnOther = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    PercentOfTimeBuffer = table.Column<decimal>(type: "decimal(8,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprints", x => x.SprintId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Members_SprintModelSprintId",
                table: "Members",
                column: "SprintModelSprintId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Sprints_SprintModelSprintId",
                table: "Members",
                column: "SprintModelSprintId",
                principalTable: "Sprints",
                principalColumn: "SprintId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Sprints_SprintModelSprintId",
                table: "Members");

            migrationBuilder.DropTable(
                name: "Sprints");

            migrationBuilder.DropIndex(
                name: "IX_Members_SprintModelSprintId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "SprintModelSprintId",
                table: "Members");
        }
    }
}
