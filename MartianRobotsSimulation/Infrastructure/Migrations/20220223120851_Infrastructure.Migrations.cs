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
                    Surface = table.Column<string>(nullable: true),
                    RobotsQuantity = table.Column<int>(nullable: false),
                    ExecutionDateTime = table.Column<DateTime>(nullable: false),
                    RobotsInputs = table.Column<string>(nullable: true),
                    RobotsResult = table.Column<string>(nullable: true),
                    Scents = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mision", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mision");
        }
    }
}
