using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tapar.Data.Migrations
{
    public partial class tag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagCats_Cat3s_catId",
                table: "TagCats");

            migrationBuilder.RenameColumn(
                name: "catId",
                table: "TagCats",
                newName: "cat2Id");

            migrationBuilder.RenameIndex(
                name: "IX_TagCats_catId",
                table: "TagCats",
                newName: "IX_TagCats_cat2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TagCats_Cat2s_cat2Id",
                table: "TagCats",
                column: "cat2Id",
                principalTable: "Cat2s",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagCats_Cat2s_cat2Id",
                table: "TagCats");

            migrationBuilder.RenameColumn(
                name: "cat2Id",
                table: "TagCats",
                newName: "catId");

            migrationBuilder.RenameIndex(
                name: "IX_TagCats_cat2Id",
                table: "TagCats",
                newName: "IX_TagCats_catId");

            migrationBuilder.AddForeignKey(
                name: "FK_TagCats_Cat3s_catId",
                table: "TagCats",
                column: "catId",
                principalTable: "Cat3s",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
