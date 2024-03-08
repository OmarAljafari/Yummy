using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yummy.Migrations
{
    public partial class NEdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MomentTitle",
                table: "Moment");

            migrationBuilder.DropColumn(
                name: "GalleryTitle",
                table: "Gallery");

            migrationBuilder.DropColumn(
                name: "ChefTitle",
                table: "Chef");

            migrationBuilder.DropColumn(
                name: "CategoryMenuTitle",
                table: "CategoryMenu");

            migrationBuilder.RenameColumn(
                name: "AboutUsDescription",
                table: "AboutUs",
                newName: "AboutUsPoint3");

            migrationBuilder.AddColumn<string>(
                name: "CategoryMenuTitle",
                table: "SystemSetting",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ChefTitle",
                table: "SystemSetting",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GalleryTitle",
                table: "SystemSetting",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MomentTitle",
                table: "SystemSetting",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<double>(
                name: "ItemMenuPrice",
                table: "ItemMenu",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "AboutUsParagraph1",
                table: "AboutUs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AboutUsParagraph2",
                table: "AboutUs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AboutUsPoint1",
                table: "AboutUs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AboutUsPoint2",
                table: "AboutUs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryMenuTitle",
                table: "SystemSetting");

            migrationBuilder.DropColumn(
                name: "ChefTitle",
                table: "SystemSetting");

            migrationBuilder.DropColumn(
                name: "GalleryTitle",
                table: "SystemSetting");

            migrationBuilder.DropColumn(
                name: "MomentTitle",
                table: "SystemSetting");

            migrationBuilder.DropColumn(
                name: "AboutUsParagraph1",
                table: "AboutUs");

            migrationBuilder.DropColumn(
                name: "AboutUsParagraph2",
                table: "AboutUs");

            migrationBuilder.DropColumn(
                name: "AboutUsPoint1",
                table: "AboutUs");

            migrationBuilder.DropColumn(
                name: "AboutUsPoint2",
                table: "AboutUs");

            migrationBuilder.RenameColumn(
                name: "AboutUsPoint3",
                table: "AboutUs",
                newName: "AboutUsDescription");

            migrationBuilder.AddColumn<string>(
                name: "MomentTitle",
                table: "Moment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "ItemMenuPrice",
                table: "ItemMenu",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "GalleryTitle",
                table: "Gallery",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ChefTitle",
                table: "Chef",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CategoryMenuTitle",
                table: "CategoryMenu",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
