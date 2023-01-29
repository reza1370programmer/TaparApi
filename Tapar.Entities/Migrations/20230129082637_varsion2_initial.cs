using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tapar.Data.Migrations
{
    public partial class varsion2_initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_Cat3s_cat3Id",
                table: "Places");

            migrationBuilder.DropTable(
                name: "Filters_Cat2s");

            migrationBuilder.DropTable(
                name: "MedicalStaffs");

            migrationBuilder.DropTable(
                name: "Place_Filters");

            migrationBuilder.DropTable(
                name: "SpecialTypeFields");

            migrationBuilder.DropTable(
                name: "SubPlaces");

            migrationBuilder.DropTable(
                name: "TagCat3s");

            migrationBuilder.DropTable(
                name: "ViewCounts");

            migrationBuilder.DropTable(
                name: "Filters");

            migrationBuilder.DropTable(
                name: "Cat3s");

            migrationBuilder.DropTable(
                name: "Cat2s");

            migrationBuilder.DropTable(
                name: "Cat1s");

            migrationBuilder.DropIndex(
                name: "IX_Places_cat3Id",
                table: "Places");

            migrationBuilder.DropIndex(
                name: "IX_Places_tags",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "cat3Id",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "gvalue",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "latitude",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "longitude",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "tags",
                table: "Places");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "cat3Id",
                table: "Places",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "gvalue",
                table: "Places",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "latitude",
                table: "Places",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "longitude",
                table: "Places",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tags",
                table: "Places",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Cat1s",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    abbreviation = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    gdesc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat1s", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    parentId = table.Column<int>(type: "int", nullable: true),
                    enTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filters_Filters_parentId",
                        column: x => x.parentId,
                        principalTable: "Filters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MedicalStaffs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    lat = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    lng = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    phone1 = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    phone2 = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    tablo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalStaffs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubPlaces",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    placeId = table.Column<long>(type: "bigint", nullable: true),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    internalPhone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    personalPic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    semat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubPlaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubPlaces_Places_placeId",
                        column: x => x.placeId,
                        principalTable: "Places",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ViewCounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    placeId = table.Column<long>(type: "bigint", nullable: false),
                    userId = table.Column<long>(type: "bigint", nullable: true),
                    clientDetail = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    viewDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViewCounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ViewCounts_Places_placeId",
                        column: x => x.placeId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ViewCounts_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cat2s",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cat1Id = table.Column<int>(type: "int", nullable: false),
                    gdesc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat2s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cat2s_Cat1s_cat1Id",
                        column: x => x.cat1Id,
                        principalTable: "Cat1s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Place_Filters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    filterId = table.Column<int>(type: "int", nullable: false),
                    placeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Place_Filters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Place_Filters_Filters_filterId",
                        column: x => x.filterId,
                        principalTable: "Filters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Place_Filters_Places_placeId",
                        column: x => x.placeId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cat3s",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cat2Id = table.Column<int>(type: "int", nullable: false),
                    gdesc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat3s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cat3s_Cat2s_cat2Id",
                        column: x => x.cat2Id,
                        principalTable: "Cat2s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Filters_Cat2s",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cat2Id = table.Column<int>(type: "int", nullable: false),
                    filterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filters_Cat2s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filters_Cat2s_Cat2s_cat2Id",
                        column: x => x.cat2Id,
                        principalTable: "Cat2s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Filters_Cat2s_Filters_filterId",
                        column: x => x.filterId,
                        principalTable: "Filters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpecialTypeFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cat2Id = table.Column<int>(type: "int", nullable: true),
                    enTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    isRequired = table.Column<bool>(type: "bit", nullable: false),
                    maxLength = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialTypeFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialTypeFields_Cat2s_cat2Id",
                        column: x => x.cat2Id,
                        principalTable: "Cat2s",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TagCat3s",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cat3Id = table.Column<int>(type: "int", nullable: false),
                    tagId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagCat3s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TagCat3s_Cat3s_cat3Id",
                        column: x => x.cat3Id,
                        principalTable: "Cat3s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TagCat3s_Tags_tagId",
                        column: x => x.tagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Places_cat3Id",
                table: "Places",
                column: "cat3Id");

            migrationBuilder.CreateIndex(
                name: "IX_Places_tags",
                table: "Places",
                column: "tags");

            migrationBuilder.CreateIndex(
                name: "IX_Cat2s_cat1Id",
                table: "Cat2s",
                column: "cat1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Cat3s_cat2Id",
                table: "Cat3s",
                column: "cat2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Filters_enTitle",
                table: "Filters",
                column: "enTitle",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Filters_parentId",
                table: "Filters",
                column: "parentId");

            migrationBuilder.CreateIndex(
                name: "IX_Filters_title",
                table: "Filters",
                column: "title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Filters_Cat2s_cat2Id",
                table: "Filters_Cat2s",
                column: "cat2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Filters_Cat2s_filterId",
                table: "Filters_Cat2s",
                column: "filterId");

            migrationBuilder.CreateIndex(
                name: "IX_Place_Filters_filterId",
                table: "Place_Filters",
                column: "filterId");

            migrationBuilder.CreateIndex(
                name: "IX_Place_Filters_placeId",
                table: "Place_Filters",
                column: "placeId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialTypeFields_cat2Id",
                table: "SpecialTypeFields",
                column: "cat2Id");

            migrationBuilder.CreateIndex(
                name: "IX_SubPlaces_placeId",
                table: "SubPlaces",
                column: "placeId");

            migrationBuilder.CreateIndex(
                name: "IX_TagCat3s_cat3Id",
                table: "TagCat3s",
                column: "cat3Id");

            migrationBuilder.CreateIndex(
                name: "IX_TagCat3s_tagId",
                table: "TagCat3s",
                column: "tagId");

            migrationBuilder.CreateIndex(
                name: "IX_ViewCounts_placeId",
                table: "ViewCounts",
                column: "placeId");

            migrationBuilder.CreateIndex(
                name: "IX_ViewCounts_userId",
                table: "ViewCounts",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Cat3s_cat3Id",
                table: "Places",
                column: "cat3Id",
                principalTable: "Cat3s",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
