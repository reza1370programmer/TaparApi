using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaparApi.Migrations
{
    public partial class relationbusinessOfficelocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "locationId",
                table: "BusinessOffices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BusinessOffices_locationId",
                table: "BusinessOffices",
                column: "locationId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessOffices_Locations_locationId",
                table: "BusinessOffices",
                column: "locationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessOffices_Locations_locationId",
                table: "BusinessOffices");

            migrationBuilder.DropIndex(
                name: "IX_BusinessOffices_locationId",
                table: "BusinessOffices");

            migrationBuilder.DropColumn(
                name: "locationId",
                table: "BusinessOffices");
        }
    }
}
