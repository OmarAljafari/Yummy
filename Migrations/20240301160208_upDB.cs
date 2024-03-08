using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Yummy.Migrations
{
    public partial class upDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WhatPeopleSayTitle",
                table: "WhatPeopleSay");

            migrationBuilder.AddColumn<string>(
                name: "WhatPeopleSayTitle",
                table: "SystemSetting",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WhatPeopleSayTitle",
                table: "SystemSetting");

            migrationBuilder.AddColumn<string>(
                name: "WhatPeopleSayTitle",
                table: "WhatPeopleSay",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
