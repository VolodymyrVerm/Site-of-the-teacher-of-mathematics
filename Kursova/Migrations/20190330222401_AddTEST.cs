using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kursova.Migrations
{
    public partial class AddTEST : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "Tasks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TestViewModelId",
                table: "Tasks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TestId",
                table: "Answers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CountQuestion = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TestViewModelId",
                table: "Tasks",
                column: "TestViewModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Tests_TestViewModelId",
                table: "Tasks",
                column: "TestViewModelId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Tests_TestViewModelId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_TestViewModelId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "TestViewModelId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "TestId",
                table: "Answers");
        }
    }
}
