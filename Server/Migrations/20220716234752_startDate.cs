using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tasky.Server.Migrations
{
    public partial class startDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Sections_SectionId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_SectionId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "Tasks");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Tasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Tasks");

            migrationBuilder.AddColumn<int>(
                name: "SectionId",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_SectionId",
                table: "Tasks",
                column: "SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Sections_SectionId",
                table: "Tasks",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "SectionId");
        }
    }
}
