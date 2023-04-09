using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tasky.Server.Migrations
{
    public partial class addRelativeEstimation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RelativeSizes");

            migrationBuilder.CreateTable(
                name: "EstimationGroups",
                columns: table => new
                {
                    EstimationGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstimationGroups", x => x.EstimationGroupId);
                });

            migrationBuilder.CreateTable(
                name: "RelativeEstimates",
                columns: table => new
                {
                    EstimationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstimationGroupId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelativeEstimates", x => x.EstimationId);
                    table.ForeignKey(
                        name: "FK_RelativeEstimates_EstimationGroups_EstimationGroupId",
                        column: x => x.EstimationGroupId,
                        principalTable: "EstimationGroups",
                        principalColumn: "EstimationGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RelativeEstimates_EstimationGroupId",
                table: "RelativeEstimates",
                column: "EstimationGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RelativeEstimates");

            migrationBuilder.DropTable(
                name: "EstimationGroups");

            migrationBuilder.CreateTable(
                name: "RelativeSizes",
                columns: table => new
                {
                    SizeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeGroup = table.Column<int>(type: "int", nullable: false),
                    SizeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelativeSizes", x => x.SizeId);
                });
        }
    }
}
