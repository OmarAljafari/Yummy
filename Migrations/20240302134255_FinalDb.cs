using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yummy.Migrations
{
    public partial class FinalDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainMenuLink",
                table: "MainMenu");

            migrationBuilder.RenameColumn(
                name: "MainMenuName",
                table: "MainMenu",
                newName: "MainMenuIconUrl");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionBookTime",
                table: "TransactionBook",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MainMenuIconUrl",
                table: "MainMenu",
                newName: "MainMenuName");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "TransactionBookTime",
                table: "TransactionBook",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "MainMenuLink",
                table: "MainMenu",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
