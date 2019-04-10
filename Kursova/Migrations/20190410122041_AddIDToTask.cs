using Microsoft.EntityFrameworkCore.Migrations;

namespace Kursova.Migrations
{
    public partial class AddIDToTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "TaskViewModelId",
                table: "Answers",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Answers_TaskViewModelId",
                table: "Answers",
                column: "TaskViewModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Tasks_TaskViewModelId",
                table: "Answers",
                column: "TaskViewModelId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Tasks_TaskViewModelId",
                table: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Answers_TaskViewModelId",
                table: "Answers");

            migrationBuilder.AlterColumn<string>(
                name: "TaskViewModelId",
                table: "Answers",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

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
    }
}
