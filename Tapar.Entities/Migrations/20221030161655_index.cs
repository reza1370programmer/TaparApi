using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tapar.Data.Migrations
{
    public partial class index : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Places_tablo",
                table: "Places",
                column: "tablo");

            migrationBuilder.CreateIndex(
                name: "IX_Places_tags",
                table: "Places",
                column: "tags");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Places_tablo",
                table: "Places");

            migrationBuilder.DropIndex(
                name: "IX_Places_tags",
                table: "Places");
        }
    }
}
