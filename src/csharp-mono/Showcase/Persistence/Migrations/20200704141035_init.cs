using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Showcase.Persistence.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "display_projects",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    source_code_url = table.Column<string>(nullable: true),
                    languages = table.Column<int[]>(nullable: true),
                    thumbnail_url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_display_projects", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "display_projects");
        }
    }
}
