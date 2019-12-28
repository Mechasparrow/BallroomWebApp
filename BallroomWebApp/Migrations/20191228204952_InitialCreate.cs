using Microsoft.EntityFrameworkCore.Migrations;

namespace BallroomWebApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dance",
                columns: table => new
                {
                    DanceId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Speed = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dance", x => x.DanceId);
                });

            migrationBuilder.CreateTable(
                name: "DanceVideo",
                columns: table => new
                {
                    DanceVideoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    VideoUrl = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanceVideo", x => x.DanceVideoId);
                });

            migrationBuilder.CreateTable(
                name: "Syllabus",
                columns: table => new
                {
                    SyllabusId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Level = table.Column<int>(nullable: false),
                    DanceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Syllabus", x => x.SyllabusId);
                    table.ForeignKey(
                        name: "FK_Syllabus_Dance_DanceId",
                        column: x => x.DanceId,
                        principalTable: "Dance",
                        principalColumn: "DanceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DanceMove",
                columns: table => new
                {
                    DanceMoveId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DanceVideoId = table.Column<int>(nullable: false),
                    SyllabusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanceMove", x => x.DanceMoveId);
                    table.ForeignKey(
                        name: "FK_DanceMove_DanceVideo_DanceVideoId",
                        column: x => x.DanceVideoId,
                        principalTable: "DanceVideo",
                        principalColumn: "DanceVideoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DanceMove_Syllabus_SyllabusId",
                        column: x => x.SyllabusId,
                        principalTable: "Syllabus",
                        principalColumn: "SyllabusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DanceMove_DanceVideoId",
                table: "DanceMove",
                column: "DanceVideoId");

            migrationBuilder.CreateIndex(
                name: "IX_DanceMove_SyllabusId",
                table: "DanceMove",
                column: "SyllabusId");

            migrationBuilder.CreateIndex(
                name: "IX_Syllabus_DanceId",
                table: "Syllabus",
                column: "DanceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DanceMove");

            migrationBuilder.DropTable(
                name: "DanceVideo");

            migrationBuilder.DropTable(
                name: "Syllabus");

            migrationBuilder.DropTable(
                name: "Dance");
        }
    }
}
