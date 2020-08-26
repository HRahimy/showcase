using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Showcase.Domain.Enums;

namespace Showcase.Persistence.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:e_activity_type", "add_dev_prog_lang,remove_dev_prog_lang,add_proj_prog_lang,remove_proj_prog_lang,watch_developer,unwatch_developer,watch_project,unwatch_project,add_blog_post,edit_blog_post,publish_blog_post,archive_blog_post,add_twitter_testimonial,remove_twitter_testimonial,add_facebook_testimonial,remove_facebook_testimonial,display_twitter_testimonial,undisplay_twitter_testimonial,display_facebook_testimonial,undisplay_facebook_testimonial")
                .Annotation("Npgsql:Enum:e_tag_type", "meta,programming_language")
                .Annotation("Npgsql:Enum:ep_rogramming_language", "c_sharp,java,java_script,go");

            migrationBuilder.CreateTable(
                name: "bucket_files",
                columns: table => new
                {
                    bucket_file_id = table.Column<string>(nullable: false),
                    created_by = table.Column<string>(nullable: true),
                    created_on = table.Column<DateTime>(nullable: false),
                    last_modified_by = table.Column<string>(nullable: true),
                    last_modified_on = table.Column<DateTime>(nullable: true),
                    bucket_name = table.Column<string>(nullable: true),
                    original_file_name = table.Column<string>(nullable: true),
                    file_path = table.Column<string>(nullable: true),
                    uploaded = table.Column<bool>(nullable: false),
                    content_type_metadata = table.Column<string>(nullable: true),
                    content_encoding_metadata = table.Column<string>(nullable: true),
                    content_language_metadata = table.Column<string>(nullable: true),
                    cache_control_metadata = table.Column<string>(nullable: true),
                    size_in_bytes = table.Column<int>(nullable: false),
                    ui_title = table.Column<string>(nullable: true),
                    ui_description = table.Column<string>(nullable: true),
                    archived = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bucket_files", x => x.bucket_file_id);
                });

            migrationBuilder.CreateTable(
                name: "display_projects",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    created_by = table.Column<string>(nullable: true),
                    created_on = table.Column<DateTime>(nullable: false),
                    last_modified_by = table.Column<string>(nullable: true),
                    last_modified_on = table.Column<DateTime>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    source_code_url = table.Column<string>(nullable: true),
                    thumbnail_url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_display_projects", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "profiles",
                columns: table => new
                {
                    profile_id = table.Column<string>(nullable: false),
                    created_by = table.Column<string>(nullable: true),
                    created_on = table.Column<DateTime>(nullable: false),
                    last_modified_by = table.Column<string>(nullable: true),
                    last_modified_on = table.Column<DateTime>(nullable: true),
                    name = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profiles", x => x.profile_id);
                });

            migrationBuilder.CreateTable(
                name: "tags",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    type = table.Column<ETagType>(nullable: false),
                    programming_language_tag = table.Column<EPRogrammingLanguage>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tags", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "blog_posts",
                columns: table => new
                {
                    blog_post_id = table.Column<string>(nullable: false),
                    created_by = table.Column<string>(nullable: true),
                    created_on = table.Column<DateTime>(nullable: false),
                    last_modified_by = table.Column<string>(nullable: true),
                    last_modified_on = table.Column<DateTime>(nullable: true),
                    title = table.Column<string>(nullable: true),
                    summary = table.Column<string>(nullable: true),
                    post_content_string = table.Column<string>(nullable: true),
                    post_content_md_file_id = table.Column<string>(nullable: true),
                    post_thumbnail_file_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blog_posts", x => x.blog_post_id);
                    table.ForeignKey(
                        name: "FK_blog_posts_bucket_files_post_content_md_file_id",
                        column: x => x.post_content_md_file_id,
                        principalTable: "bucket_files",
                        principalColumn: "bucket_file_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_blog_posts_bucket_files_post_thumbnail_file_id",
                        column: x => x.post_thumbnail_file_id,
                        principalTable: "bucket_files",
                        principalColumn: "bucket_file_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "profile_watchers",
                columns: table => new
                {
                    watcher_id = table.Column<string>(nullable: false),
                    watchee_id = table.Column<string>(nullable: false),
                    cancelled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profile_watchers", x => new { x.watcher_id, x.watchee_id });
                    table.ForeignKey(
                        name: "FK_profile_watchers_profiles_watchee_id",
                        column: x => x.watchee_id,
                        principalTable: "profiles",
                        principalColumn: "profile_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_profile_watchers_profiles_watcher_id",
                        column: x => x.watcher_id,
                        principalTable: "profiles",
                        principalColumn: "profile_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "project_watchers",
                columns: table => new
                {
                    watcher_id = table.Column<string>(nullable: false),
                    display_project_id = table.Column<string>(nullable: false),
                    cancelled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project_watchers", x => new { x.display_project_id, x.watcher_id });
                    table.ForeignKey(
                        name: "FK_project_watchers_display_projects_display_project_id",
                        column: x => x.display_project_id,
                        principalTable: "display_projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_project_watchers_profiles_watcher_id",
                        column: x => x.watcher_id,
                        principalTable: "profiles",
                        principalColumn: "profile_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "profile_tags",
                columns: table => new
                {
                    showcase_profile_id = table.Column<string>(nullable: false),
                    tag_id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profile_tags", x => new { x.showcase_profile_id, x.tag_id });
                    table.ForeignKey(
                        name: "FK_profile_tags_profiles_showcase_profile_id",
                        column: x => x.showcase_profile_id,
                        principalTable: "profiles",
                        principalColumn: "profile_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_profile_tags_tags_tag_id",
                        column: x => x.tag_id,
                        principalTable: "tags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "project_tags",
                columns: table => new
                {
                    display_project_id = table.Column<string>(nullable: false),
                    tag_id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project_tags", x => new { x.display_project_id, x.tag_id });
                    table.ForeignKey(
                        name: "FK_project_tags_display_projects_display_project_id",
                        column: x => x.display_project_id,
                        principalTable: "display_projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_project_tags_tags_tag_id",
                        column: x => x.tag_id,
                        principalTable: "tags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "activity_notes",
                columns: table => new
                {
                    activity_note_id = table.Column<string>(nullable: false),
                    activity_type = table.Column<EActivityType>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    note_text = table.Column<string>(nullable: true),
                    showcase_profile_id = table.Column<string>(nullable: true),
                    blog_post_id = table.Column<string>(nullable: true),
                    project_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_activity_notes", x => x.activity_note_id);
                    table.ForeignKey(
                        name: "FK_activity_notes_blog_posts_blog_post_id",
                        column: x => x.blog_post_id,
                        principalTable: "blog_posts",
                        principalColumn: "blog_post_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_activity_notes_display_projects_project_id",
                        column: x => x.project_id,
                        principalTable: "display_projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_activity_notes_profiles_showcase_profile_id",
                        column: x => x.showcase_profile_id,
                        principalTable: "profiles",
                        principalColumn: "profile_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "blog_post_tags",
                columns: table => new
                {
                    blog_post_id = table.Column<string>(nullable: false),
                    tag_id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blog_post_tags", x => new { x.blog_post_id, x.tag_id });
                    table.ForeignKey(
                        name: "FK_blog_post_tags_blog_posts_blog_post_id",
                        column: x => x.blog_post_id,
                        principalTable: "blog_posts",
                        principalColumn: "blog_post_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_blog_post_tags_tags_tag_id",
                        column: x => x.tag_id,
                        principalTable: "tags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "blog_post_watchers",
                columns: table => new
                {
                    watcher_id = table.Column<string>(nullable: false),
                    blog_post_id = table.Column<string>(nullable: false),
                    cancelled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blog_post_watchers", x => new { x.blog_post_id, x.watcher_id });
                    table.ForeignKey(
                        name: "FK_blog_post_watchers_blog_posts_blog_post_id",
                        column: x => x.blog_post_id,
                        principalTable: "blog_posts",
                        principalColumn: "blog_post_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_blog_post_watchers_profiles_watcher_id",
                        column: x => x.watcher_id,
                        principalTable: "profiles",
                        principalColumn: "profile_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_activity_notes_blog_post_id",
                table: "activity_notes",
                column: "blog_post_id");

            migrationBuilder.CreateIndex(
                name: "IX_activity_notes_project_id",
                table: "activity_notes",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_activity_notes_showcase_profile_id",
                table: "activity_notes",
                column: "showcase_profile_id");

            migrationBuilder.CreateIndex(
                name: "IX_blog_post_tags_tag_id",
                table: "blog_post_tags",
                column: "tag_id");

            migrationBuilder.CreateIndex(
                name: "IX_blog_post_watchers_watcher_id",
                table: "blog_post_watchers",
                column: "watcher_id");

            migrationBuilder.CreateIndex(
                name: "IX_blog_posts_post_content_md_file_id",
                table: "blog_posts",
                column: "post_content_md_file_id");

            migrationBuilder.CreateIndex(
                name: "IX_blog_posts_post_thumbnail_file_id",
                table: "blog_posts",
                column: "post_thumbnail_file_id");

            migrationBuilder.CreateIndex(
                name: "IX_profile_tags_tag_id",
                table: "profile_tags",
                column: "tag_id");

            migrationBuilder.CreateIndex(
                name: "IX_profile_watchers_watchee_id",
                table: "profile_watchers",
                column: "watchee_id");

            migrationBuilder.CreateIndex(
                name: "IX_project_tags_tag_id",
                table: "project_tags",
                column: "tag_id");

            migrationBuilder.CreateIndex(
                name: "IX_project_watchers_watcher_id",
                table: "project_watchers",
                column: "watcher_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "activity_notes");

            migrationBuilder.DropTable(
                name: "blog_post_tags");

            migrationBuilder.DropTable(
                name: "blog_post_watchers");

            migrationBuilder.DropTable(
                name: "profile_tags");

            migrationBuilder.DropTable(
                name: "profile_watchers");

            migrationBuilder.DropTable(
                name: "project_tags");

            migrationBuilder.DropTable(
                name: "project_watchers");

            migrationBuilder.DropTable(
                name: "blog_posts");

            migrationBuilder.DropTable(
                name: "tags");

            migrationBuilder.DropTable(
                name: "display_projects");

            migrationBuilder.DropTable(
                name: "profiles");

            migrationBuilder.DropTable(
                name: "bucket_files");
        }
    }
}
