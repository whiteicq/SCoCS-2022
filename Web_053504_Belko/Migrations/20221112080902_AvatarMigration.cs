using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_053504_Belko.Migrations
{
    public partial class AvatarMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "avatar",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "avatar",
                table: "AspNetUsers");
        }
    }
}
