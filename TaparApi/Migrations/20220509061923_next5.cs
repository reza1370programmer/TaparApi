using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaparApi.Migrations
{
    public partial class next5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "visitPic",
                table: "BusinessUpdates",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "tabloPic",
                table: "BusinessUpdates",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<string>(
                name: "firstName",
                table: "BusinessUpdates",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "gdesc",
                table: "BusinessUpdates",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "gender",
                table: "BusinessUpdates",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "lastName",
                table: "BusinessUpdates",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nationalCode",
                table: "BusinessUpdates",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "picture",
                table: "BusinessUpdates",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "firstName",
                table: "BusinessUpdates");

            migrationBuilder.DropColumn(
                name: "gdesc",
                table: "BusinessUpdates");

            migrationBuilder.DropColumn(
                name: "gender",
                table: "BusinessUpdates");

            migrationBuilder.DropColumn(
                name: "lastName",
                table: "BusinessUpdates");

            migrationBuilder.DropColumn(
                name: "nationalCode",
                table: "BusinessUpdates");

            migrationBuilder.DropColumn(
                name: "picture",
                table: "BusinessUpdates");

            migrationBuilder.AlterColumn<string>(
                name: "visitPic",
                table: "BusinessUpdates",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "tabloPic",
                table: "BusinessUpdates",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
