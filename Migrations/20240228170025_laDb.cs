using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yummy.Migrations
{
    public partial class laDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemMenu_CategoryMenu_CategoryMenuId",
                table: "ItemMenu");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryMenuId",
                table: "ItemMenu",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemMenu_CategoryMenu_CategoryMenuId",
                table: "ItemMenu",
                column: "CategoryMenuId",
                principalTable: "CategoryMenu",
                principalColumn: "CategoryMenuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemMenu_CategoryMenu_CategoryMenuId",
                table: "ItemMenu");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryMenuId",
                table: "ItemMenu",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemMenu_CategoryMenu_CategoryMenuId",
                table: "ItemMenu",
                column: "CategoryMenuId",
                principalTable: "CategoryMenu",
                principalColumn: "CategoryMenuId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
