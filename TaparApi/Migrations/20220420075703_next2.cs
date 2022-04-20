using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaparApi.Migrations
{
    public partial class next2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "businessOfficeTypeId",
                table: "BusinessOffices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BusinessOfficeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    gdesc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessOfficeTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessOffices_businessOfficeTypeId",
                table: "BusinessOffices",
                column: "businessOfficeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessOffices_BusinessOfficeTypes_businessOfficeTypeId",
                table: "BusinessOffices",
                column: "businessOfficeTypeId",
                principalTable: "BusinessOfficeTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessOffices_BusinessOfficeTypes_businessOfficeTypeId",
                table: "BusinessOffices");

            migrationBuilder.DropTable(
                name: "BusinessOfficeTypes");

            migrationBuilder.DropIndex(
                name: "IX_BusinessOffices_businessOfficeTypeId",
                table: "BusinessOffices");

            migrationBuilder.DropColumn(
                name: "businessOfficeTypeId",
                table: "BusinessOffices");
        }
    }
}
