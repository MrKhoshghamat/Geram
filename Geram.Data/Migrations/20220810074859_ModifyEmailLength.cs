using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Geram.Data.Migrations
{
    public partial class ModifyEmailLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.UpdateData(
                table: "EmailSettings",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "vcschkeikvnegtdc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.UpdateData(
                table: "EmailSettings",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "1234HuneR");
        }
    }
}
