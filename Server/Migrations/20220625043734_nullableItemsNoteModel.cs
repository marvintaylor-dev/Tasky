using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tasky.Server.Migrations
{
    public partial class nullableItemsNoteModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LinkTo",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isSubTask",
                table: "Tasks",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkTo",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "isSubTask",
                table: "Tasks");
        }
    }
}
