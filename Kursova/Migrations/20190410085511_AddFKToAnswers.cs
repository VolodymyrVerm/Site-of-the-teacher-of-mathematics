using Microsoft.EntityFrameworkCore.Migrations;

namespace Kursova.Migrations
{
    public partial class AddFKToAnswers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AspNetUsersId",
                table: "TestsProgress",
                newName: "IdentityUserId");

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "Answers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Answers_TaskId",
                table: "Answers",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Tasks_TaskId",
                table: "Answers",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Tasks_TaskId",
                table: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Answers_TaskId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Answers");

            migrationBuilder.RenameColumn(
                name: "IdentityUserId",
                table: "TestsProgress",
                newName: "AspNetUsersId");
        }
    }
}
