using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaparApi.Migrations
{
    public partial class adminType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "adminType",
                table: "SuperAdmins",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "adminType",
                table: "SuperAdmins");
        }
    }
}
