using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentRecords.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    StudentId = table.Column<string>(nullable: false),
                    UnitCode = table.Column<string>(nullable: false),
                    Semester = table.Column<short>(nullable: false),
                    Year = table.Column<short>(nullable: false),
                    Ass1Score = table.Column<short>(nullable: false),
                    Ass2Score = table.Column<short>(nullable: false),
                    ExamScore = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    IsAdmin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    UnitCode = table.Column<string>(nullable: false),
                    UnitTitle = table.Column<string>(nullable: false),
                    UnitCoordinator = table.Column<string>(nullable: false),
                    UnitOutline = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.UnitCode);
                    table.ForeignKey(
                        name: "FK_Units_Results_UnitCode",
                        column: x => x.UnitCode,
                        principalTable: "Results",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Results");
        }
    }
}
