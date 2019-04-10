using Microsoft.EntityFrameworkCore.Migrations;

namespace Kursova.Migrations
{
    public partial class AddFKToAnsw : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "Answers",
                newName: "TaskViewModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TaskViewModelId",
                table: "Answers",
                newName: "QuestionId");
        }
    }
}
