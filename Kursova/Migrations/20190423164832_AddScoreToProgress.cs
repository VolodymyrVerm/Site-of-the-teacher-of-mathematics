using Microsoft.EntityFrameworkCore.Migrations;

namespace Kursova.Migrations
{
    public partial class AddScoreToProgress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TestsProgress",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "TestsProgress",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TestsProgress_UserId",
                table: "TestsProgress",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestsProgress_AspNetUsers_UserId",
                table: "TestsProgress",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestsProgress_AspNetUsers_UserId",
                table: "TestsProgress");

            migrationBuilder.DropIndex(
                name: "IX_TestsProgress_UserId",
                table: "TestsProgress");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "TestsProgress");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TestsProgress",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
