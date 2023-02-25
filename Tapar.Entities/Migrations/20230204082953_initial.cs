using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tapar.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    parentId = table.Column<int>(type: "int", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuperAdmins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    fullName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    adminType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperAdmins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTimes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    expirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    refreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userId = table.Column<long>(type: "bigint", nullable: true),
                    superAdminId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_SuperAdmins_superAdminId",
                        column: x => x.superAdminId,
                        principalTable: "SuperAdmins",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tablo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    manager = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    taparcode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    service_description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    mob1 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    mob2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    phone1 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    phone2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    phone3 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    fax = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    website = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    telegram = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    instagram = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    whatsapp = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    bussiness_pic1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    bussiness_pic2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    bussiness_pic3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    personal_pic = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    visitCart_front = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    visitCart_back = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    special_message = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    like_count = table.Column<int>(type: "int", nullable: true),
                    view_count = table.Column<int>(type: "int", nullable: true),
                    on_off = table.Column<bool>(type: "bit", nullable: false),
                    locationId = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<long>(type: "bigint", nullable: false),
                    workTimeId = table.Column<int>(type: "int", nullable: false),
                    cDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifiedUserId = table.Column<long>(type: "bigint", nullable: true),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Places_Locations_locationId",
                        column: x => x.locationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Places_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Places_WorkTimes_workTimeId",
                        column: x => x.workTimeId,
                        principalTable: "WorkTimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    text = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userId = table.Column<long>(type: "bigint", nullable: false),
                    placeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Places_placeId",
                        column: x => x.placeId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LikeCounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    likeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    userId = table.Column<long>(type: "bigint", nullable: false),
                    placeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikeCounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LikeCounts_Places_placeId",
                        column: x => x.placeId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LikeCounts_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlaceTags",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaceId = table.Column<long>(type: "bigint", nullable: false),
                    TagId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaceTags_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlaceTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WeekDays",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    saturday = table.Column<int>(type: "int", nullable: false),
                    sunday = table.Column<int>(type: "int", nullable: false),
                    monday = table.Column<int>(type: "int", nullable: false),
                    tuesday = table.Column<int>(type: "int", nullable: false),
                    wednesday = table.Column<int>(type: "int", nullable: false),
                    thursday = table.Column<int>(type: "int", nullable: false),
                    friday = table.Column<int>(type: "int", nullable: false),
                    placeId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeekDays_Places_placeId",
                        column: x => x.placeId,
                        principalTable: "Places",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "isActive", "name", "parentId" },
                values: new object[,]
                {
                    { 1, true, "آذربایجان شرقی", null },
                    { 2, true, "بناب", 1 }
                });

            migrationBuilder.InsertData(
                table: "WorkTimes",
                columns: new[] { "Id", "title" },
                values: new object[,]
                {
                    { 1, "شبانه روزی" },
                    { 2, "اداری" },
                    { 3, "خاص" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_placeId",
                table: "Comments",
                column: "placeId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_userId",
                table: "Comments",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_LikeCounts_placeId",
                table: "LikeCounts",
                column: "placeId");

            migrationBuilder.CreateIndex(
                name: "IX_LikeCounts_userId",
                table: "LikeCounts",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Places_locationId",
                table: "Places",
                column: "locationId");

            migrationBuilder.CreateIndex(
                name: "IX_Places_tablo",
                table: "Places",
                column: "tablo");

            migrationBuilder.CreateIndex(
                name: "IX_Places_taparcode",
                table: "Places",
                column: "taparcode",
                unique: true,
                filter: "[taparcode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Places_userId",
                table: "Places",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Places_workTimeId",
                table: "Places",
                column: "workTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceTags_PlaceId",
                table: "PlaceTags",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceTags_TagId",
                table: "PlaceTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_superAdminId",
                table: "RefreshTokens",
                column: "superAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_userId",
                table: "RefreshTokens",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_title",
                table: "Tags",
                column: "title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeekDays_placeId",
                table: "WeekDays",
                column: "placeId",
                unique: true,
                filter: "[placeId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "LikeCounts");

            migrationBuilder.DropTable(
                name: "PlaceTags");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "WeekDays");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "SuperAdmins");

            migrationBuilder.DropTable(
                name: "Places");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "WorkTimes");
        }
    }
}
