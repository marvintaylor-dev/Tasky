using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tasky.Server.Migrations
{
    public partial class updateModelBuilder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Sprints_SprintModelSprintId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Sprints_SprintModelSprintId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Members_SprintModelSprintId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "SprintModelSprintId",
                table: "Members");

            migrationBuilder.RenameColumn(
                name: "SprintModelSprintId",
                table: "Tasks",
                newName: "AssignedToSprintSprintId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_SprintModelSprintId",
                table: "Tasks",
                newName: "IX_Tasks_AssignedToSprintSprintId");

            migrationBuilder.CreateTable(
                name: "MemberSprintModel",
                columns: table => new
                {
                    MembersWithPlannedLeaveMemberId = table.Column<int>(type: "int", nullable: false),
                    SprintsAssignedToSprintId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberSprintModel", x => new { x.MembersWithPlannedLeaveMemberId, x.SprintsAssignedToSprintId });
                    table.ForeignKey(
                        name: "FK_MemberSprintModel_Members_MembersWithPlannedLeaveMemberId",
                        column: x => x.MembersWithPlannedLeaveMemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberSprintModel_Sprints_SprintsAssignedToSprintId",
                        column: x => x.SprintsAssignedToSprintId,
                        principalTable: "Sprints",
                        principalColumn: "SprintId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MemberSprintModel_SprintsAssignedToSprintId",
                table: "MemberSprintModel",
                column: "SprintsAssignedToSprintId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Sprints_AssignedToSprintSprintId",
                table: "Tasks",
                column: "AssignedToSprintSprintId",
                principalTable: "Sprints",
                principalColumn: "SprintId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Sprints_AssignedToSprintSprintId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "MemberSprintModel");

            migrationBuilder.RenameColumn(
                name: "AssignedToSprintSprintId",
                table: "Tasks",
                newName: "SprintModelSprintId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_AssignedToSprintSprintId",
                table: "Tasks",
                newName: "IX_Tasks_SprintModelSprintId");

            migrationBuilder.AddColumn<int>(
                name: "SprintModelSprintId",
                table: "Members",
                type: "int",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Sprints_SprintModelSprintId",
                table: "Tasks",
                column: "SprintModelSprintId",
                principalTable: "Sprints",
                principalColumn: "SprintId");
        }
    }
}
