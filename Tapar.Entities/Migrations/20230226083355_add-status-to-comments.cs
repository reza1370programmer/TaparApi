using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tapar.Data.Migrations
{
    public partial class addstatustocomments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "Comments");
        }
    }
}
