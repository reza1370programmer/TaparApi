using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tapar.Data.Migrations
{
    public partial class changesfortags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Place_Tags");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Tags");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_title",
                table: "Tags",
                column: "title",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tags_title",
                table: "Tags");

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "Tags",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Place_Tags",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    placeId = table.Column<long>(type: "bigint", nullable: false),
                    tagId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Place_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Place_Tags_Places_placeId",
                        column: x => x.placeId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Place_Tags_Tags_tagId",
                        column: x => x.tagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Place_Tags_placeId",
                table: "Place_Tags",
                column: "placeId");

            migrationBuilder.CreateIndex(
                name: "IX_Place_Tags_tagId",
                table: "Place_Tags",
                column: "tagId");
        }
    }
}
