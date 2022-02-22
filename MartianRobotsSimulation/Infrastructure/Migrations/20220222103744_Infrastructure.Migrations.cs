using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class InfrastructureMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mision",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RobotsQuantity = table.Column<int>(nullable: false),
                    Surface = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mision", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RobotCommadModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    XCoordinate = table.Column<int>(nullable: false),
                    YCoordinate = table.Column<int>(nullable: false),
                    Instructions = table.Column<string>(nullable: true),
                    Position = table.Column<char>(nullable: false),
                    MisionModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RobotCommadModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RobotCommadModel_Mision_MisionModelId",
                        column: x => x.MisionModelId,
                        principalTable: "Mision",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RobotOutputModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    XCoordinate = table.Column<int>(nullable: false),
                    YCoordinate = table.Column<int>(nullable: false),
                    IsLost = table.Column<bool>(nullable: false),
                    MisionModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RobotOutputModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RobotOutputModel_Mision_MisionModelId",
                        column: x => x.MisionModelId,
                        principalTable: "Mision",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RobotCommadModel_MisionModelId",
                table: "RobotCommadModel",
                column: "MisionModelId");

            migrationBuilder.CreateIndex(
                name: "IX_RobotOutputModel_MisionModelId",
                table: "RobotOutputModel",
                column: "MisionModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RobotCommadModel");

            migrationBuilder.DropTable(
                name: "RobotOutputModel");

            migrationBuilder.DropTable(
                name: "Mision");
        }
    }
}
