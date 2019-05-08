using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kursova.Migrations
{
    public partial class DeleteCompleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Completed",
                table: "TestsProgress");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "TestsProgress",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "TestsProgress");

            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "TestsProgress",
                nullable: false,
                defaultValue: false);
        }
    }
}
