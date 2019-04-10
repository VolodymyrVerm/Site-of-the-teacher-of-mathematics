using Microsoft.EntityFrameworkCore.Migrations;

namespace Kursova.Migrations
{
    public partial class addFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "TestsProgress",
                newName: "AspNetUsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AspNetUsersId",
                table: "TestsProgress",
                newName: "UserId");
        }
    }
}
