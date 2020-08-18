using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Showcase.Persistence.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "developers",
                columns: table => new
                {
                    developer_id = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_developers", x => x.developer_id);
                });

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

            migrationBuilder.CreateTable(
                name: "programming_languages",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: true),
                    developer_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_programming_languages", x => x.id);
                    table.ForeignKey(
                        name: "FK_programming_languages_developers_developer_id",
                        column: x => x.developer_id,
                        principalTable: "developers",
                        principalColumn: "developer_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "watchers",
                columns: table => new
                {
                    watcher_id = table.Column<string>(nullable: false),
                    developer_id = table.Column<string>(nullable: true),
                    cancelled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_watchers", x => x.watcher_id);
                    table.ForeignKey(
                        name: "FK_watchers_developers_developer_id",
                        column: x => x.developer_id,
                        principalTable: "developers",
                        principalColumn: "developer_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_programming_languages_developer_id",
                table: "programming_languages",
                column: "developer_id");

            migrationBuilder.CreateIndex(
                name: "IX_watchers_developer_id",
                table: "watchers",
                column: "developer_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "display_projects");

            migrationBuilder.DropTable(
                name: "programming_languages");

            migrationBuilder.DropTable(
                name: "watchers");

            migrationBuilder.DropTable(
                name: "developers");
        }
    }
}
