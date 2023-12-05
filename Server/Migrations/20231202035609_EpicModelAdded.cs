using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tasky.Server.Migrations
{
    public partial class EpicModelAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Epic",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EpicId",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Epics",
                columns: table => new
                {
                    EpicId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EpicName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EpicBudget = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    EpicColor = table.Column<int>(type: "int", nullable: true),
                    EpicCategory = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Epics", x => x.EpicId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_EpicId",
                table: "Tasks",
                column: "EpicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Epics_EpicId",
                table: "Tasks",
                column: "EpicId",
                principalTable: "Epics",
                principalColumn: "EpicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Epics_EpicId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "Epics");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_EpicId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Epic",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "EpicId",
                table: "Tasks");
        }
    }
}
