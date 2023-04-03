using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tasky.Server.Migrations
{
    public partial class addedStatusOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StatusName",
                table: "Statuses",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "StatusOrder",
                table: "Statuses",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusOrder",
                table: "Statuses");

            migrationBuilder.AlterColumn<string>(
                name: "StatusName",
                table: "Statuses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);
        }
    }
}
