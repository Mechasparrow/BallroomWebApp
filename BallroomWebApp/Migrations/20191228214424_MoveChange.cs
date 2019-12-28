using Microsoft.EntityFrameworkCore.Migrations;

namespace BallroomWebApp.Migrations
{
    public partial class MoveChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "DanceMove",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "DanceMove");
        }
    }
}
