using Microsoft.EntityFrameworkCore.Migrations;

namespace Kursova.Migrations
{
    public partial class UpdateProgress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "TestsProgress",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TestsProgress");
        }
    }
}
