using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yummy.Migrations
{
    public partial class LastDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryMenuId",
                table: "ItemMenu",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ItemMenu_CategoryMenuId",
                table: "ItemMenu",
                column: "CategoryMenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemMenu_CategoryMenu_CategoryMenuId",
                table: "ItemMenu",
                column: "CategoryMenuId",
                principalTable: "CategoryMenu",
                principalColumn: "CategoryMenuId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemMenu_CategoryMenu_CategoryMenuId",
                table: "ItemMenu");

            migrationBuilder.DropIndex(
                name: "IX_ItemMenu_CategoryMenuId",
                table: "ItemMenu");

            migrationBuilder.DropColumn(
                name: "CategoryMenuId",
                table: "ItemMenu");
        }
    }
}
