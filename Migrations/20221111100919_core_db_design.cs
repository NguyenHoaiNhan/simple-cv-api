using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace simple_cv.Migrations
{
    public partial class core_db_design : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "activity",
                columns: table => new
                {
                    act_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    position = table.Column<string>(type: "text", nullable: true),
                    organization = table.Column<string>(type: "text", nullable: true),
                    city = table.Column<string>(type: "text", nullable: true),
                    start_date = table.Column<DateOnly>(type: "date", nullable: true),
                    end_date = table.Column<DateOnly>(type: "date", nullable: true),
                    activity_type = table.Column<string>(type: "text", nullable: true),
                    activity_title = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_activity", x => x.act_id);
                });

            migrationBuilder.CreateTable(
                name: "cv",
                columns: table => new
                {
                    cv_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    cv_url = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cv", x => x.cv_id);
                });

            migrationBuilder.CreateTable(
                name: "skill",
                columns: table => new
                {
                    skill_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    skill_name = table.Column<string>(type: "text", nullable: true),
                    level = table.Column<int>(type: "integer", nullable: true),
                    skill_type = table.Column<string>(type: "text", nullable: true),
                    skill_title = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skill", x => x.skill_id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "text", nullable: true),
                    family_name = table.Column<string>(type: "text", nullable: true),
                    mid_name = table.Column<string>(type: "text", nullable: true),
                    phone = table.Column<string>(type: "text", nullable: true),
                    address = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "description",
                columns: table => new
                {
                    act_id = table.Column<int>(type: "integer", nullable: false),
                    is_bold = table.Column<bool>(type: "boolean", nullable: true),
                    is_italic = table.Column<bool>(type: "boolean", nullable: true),
                    is_underline = table.Column<bool>(type: "boolean", nullable: true),
                    bullet_type = table.Column<int>(type: "integer", nullable: true),
                    alignment = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_description", x => x.act_id);
                    table.ForeignKey(
                        name: "FK_description_activity_act_id",
                        column: x => x.act_id,
                        principalTable: "activity",
                        principalColumn: "act_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cv_activity",
                columns: table => new
                {
                    cv_id = table.Column<int>(type: "integer", nullable: false),
                    act_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cv_activity", x => new { x.cv_id, x.act_id });
                    table.ForeignKey(
                        name: "FK_cv_activity_activity_act_id",
                        column: x => x.act_id,
                        principalTable: "activity",
                        principalColumn: "act_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cv_activity_cv_cv_id",
                        column: x => x.cv_id,
                        principalTable: "cv",
                        principalColumn: "cv_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "info",
                columns: table => new
                {
                    cv_id = table.Column<int>(type: "integer", nullable: false),
                    given_name = table.Column<string>(type: "text", nullable: true),
                    family_name = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    headline = table.Column<string>(type: "text", nullable: true),
                    phone_num = table.Column<string>(type: "text", nullable: true),
                    address = table.Column<string>(type: "text", nullable: true),
                    post_code = table.Column<string>(type: "text", nullable: true),
                    city = table.Column<string>(type: "text", nullable: true),
                    date_of_birth = table.Column<DateOnly>(type: "date", nullable: true),
                    place_of_birth = table.Column<string>(type: "text", nullable: true),
                    driver_license = table.Column<string>(type: "text", nullable: true),
                    gender = table.Column<int>(type: "integer", nullable: true),
                    country_id = table.Column<int>(type: "integer", nullable: true),
                    civil_status_id = table.Column<int>(type: "integer", nullable: true),
                    github_link = table.Column<string>(type: "text", nullable: true),
                    linkedin_link = table.Column<string>(type: "text", nullable: true),
                    avatar = table.Column<string>(type: "text", nullable: true),
                    civil_status = table.Column<string>(type: "text", nullable: true),
                    country = table.Column<string>(type: "text", nullable: true),
                    info_title = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_info", x => x.cv_id);
                    table.ForeignKey(
                        name: "FK_info_cv_cv_id",
                        column: x => x.cv_id,
                        principalTable: "cv",
                        principalColumn: "cv_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cv_skill",
                columns: table => new
                {
                    cv_id = table.Column<int>(type: "integer", nullable: false),
                    skill_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cv_skill", x => new { x.cv_id, x.skill_id });
                    table.ForeignKey(
                        name: "FK_cv_skill_cv_cv_id",
                        column: x => x.cv_id,
                        principalTable: "cv",
                        principalColumn: "cv_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cv_skill_skill_skill_id",
                        column: x => x.skill_id,
                        principalTable: "skill",
                        principalColumn: "skill_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cv_activity_act_id",
                table: "cv_activity",
                column: "act_id");

            migrationBuilder.CreateIndex(
                name: "IX_cv_skill_skill_id",
                table: "cv_skill",
                column: "skill_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cv_activity");

            migrationBuilder.DropTable(
                name: "cv_skill");

            migrationBuilder.DropTable(
                name: "description");

            migrationBuilder.DropTable(
                name: "info");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "skill");

            migrationBuilder.DropTable(
                name: "activity");

            migrationBuilder.DropTable(
                name: "cv");
        }
    }
}
