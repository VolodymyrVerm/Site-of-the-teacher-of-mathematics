using Microsoft.EntityFrameworkCore.Migrations;

namespace Kursova.Migrations
{
    public partial class HZ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestsProgress_Tests_TestId",
                table: "TestsProgress");

            migrationBuilder.AlterColumn<int>(
                name: "TestId",
                table: "TestsProgress",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_TestsProgress_Tests_TestId",
                table: "TestsProgress",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestsProgress_Tests_TestId",
                table: "TestsProgress");

            migrationBuilder.AlterColumn<int>(
                name: "TestId",
                table: "TestsProgress",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TestsProgress_Tests_TestId",
                table: "TestsProgress",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
