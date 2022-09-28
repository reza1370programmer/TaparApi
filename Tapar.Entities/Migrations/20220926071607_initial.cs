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
                name: "Cat1s",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    gdesc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat1s", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FieldTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    enTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    parentId = table.Column<int>(type: "int", nullable: true)
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
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    longitude = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    latitude = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    parentId = table.Column<int>(type: "int", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalStaffs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tablo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    lng = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    lat = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    phone1 = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    phone2 = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalStaffs", x => x.Id);
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
                    title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
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
                    password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    mobile = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
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
                name: "Cat2s",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    gdesc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    popup_state = table.Column<int>(type: "int", nullable: false),
                    cat1Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat2s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cat2s_Cat1s_cat1Id",
                        column: x => x.cat1Id,
                        principalTable: "Cat1s",
                        principalColumn: "Id");
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
                name: "Cat3s",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    gdesc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    cat2Id = table.Column<int>(type: "int", nullable: false)
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
                    filterId = table.Column<int>(type: "int", nullable: false),
                    cat2Id = table.Column<int>(type: "int", nullable: false)
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
                name: "Places",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tablo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    manager = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    service_description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    mob1 = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    mob2 = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    phone1 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    phone2 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    phone3 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    fax = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    longitude = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    latitude = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    bussiness_pic1 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    bussiness_pic2 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    bussiness_pic3 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    personal_pic = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    visitCart_front = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    visitCart_back = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    special_message = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    tags = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    gvalue = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    like_count = table.Column<int>(type: "int", nullable: true),
                    view_count = table.Column<int>(type: "int", nullable: true),
                    on_off = table.Column<bool>(type: "bit", nullable: false),
                    userId = table.Column<long>(type: "bigint", nullable: false),
                    cat3Id = table.Column<int>(type: "int", nullable: false),
                    work_time_id = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    cDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    cUserId = table.Column<long>(type: "bigint", nullable: true),
                    modifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifiedUserId = table.Column<long>(type: "bigint", nullable: true),
                    approvedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    approvedUserId = table.Column<long>(type: "bigint", nullable: true),
                    deactivatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deactivatedUserId = table.Column<long>(type: "bigint", nullable: true),
                    deactivatedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deletedUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Places_Cat3s_cat3Id",
                        column: x => x.cat3Id,
                        principalTable: "Cat3s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Places_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Places_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Places_WorkTimes_work_time_id",
                        column: x => x.work_time_id,
                        principalTable: "WorkTimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpecialTypeFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    enTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    minLength = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    maxLength = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isRequired = table.Column<bool>(type: "bit", nullable: false),
                    cat2Id = table.Column<int>(type: "int", nullable: true),
                    fieldTypeId = table.Column<int>(type: "int", nullable: false),
                    Cat3Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialTypeFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialTypeFields_Cat2s_cat2Id",
                        column: x => x.cat2Id,
                        principalTable: "Cat2s",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SpecialTypeFields_Cat3s_Cat3Id",
                        column: x => x.Cat3Id,
                        principalTable: "Cat3s",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SpecialTypeFields_FieldTypes_fieldTypeId",
                        column: x => x.fieldTypeId,
                        principalTable: "FieldTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TagCats",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tagId = table.Column<long>(type: "bigint", nullable: false),
                    catId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagCats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TagCats_Cat3s_catId",
                        column: x => x.catId,
                        principalTable: "Cat3s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TagCats_Tags_tagId",
                        column: x => x.tagId,
                        principalTable: "Tags",
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
                    create_date = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    approv_date = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    approv_date_userId = table.Column<long>(type: "bigint", nullable: false),
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
                name: "Place_Filters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    placeId = table.Column<long>(type: "bigint", nullable: false),
                    filterId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "SubPlaces",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    semat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    internalPhone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    personalPic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    placeId = table.Column<long>(type: "bigint", nullable: true)
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
                    viewDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    clientDetail = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    userId = table.Column<long>(type: "bigint", nullable: true),
                    placeId = table.Column<long>(type: "bigint", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Cat2s_cat1Id",
                table: "Cat2s",
                column: "cat1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Cat3s_cat2Id",
                table: "Cat3s",
                column: "cat2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_placeId",
                table: "Comments",
                column: "placeId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_userId",
                table: "Comments",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Filters_parentId",
                table: "Filters",
                column: "parentId");

            migrationBuilder.CreateIndex(
                name: "IX_Filters_Cat2s_cat2Id",
                table: "Filters_Cat2s",
                column: "cat2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Filters_Cat2s_filterId",
                table: "Filters_Cat2s",
                column: "filterId");

            migrationBuilder.CreateIndex(
                name: "IX_LikeCounts_placeId",
                table: "LikeCounts",
                column: "placeId");

            migrationBuilder.CreateIndex(
                name: "IX_LikeCounts_userId",
                table: "LikeCounts",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Place_Filters_filterId",
                table: "Place_Filters",
                column: "filterId");

            migrationBuilder.CreateIndex(
                name: "IX_Place_Filters_placeId",
                table: "Place_Filters",
                column: "placeId");

            migrationBuilder.CreateIndex(
                name: "IX_Place_Tags_placeId",
                table: "Place_Tags",
                column: "placeId");

            migrationBuilder.CreateIndex(
                name: "IX_Place_Tags_tagId",
                table: "Place_Tags",
                column: "tagId");

            migrationBuilder.CreateIndex(
                name: "IX_Places_cat3Id",
                table: "Places",
                column: "cat3Id");

            migrationBuilder.CreateIndex(
                name: "IX_Places_LocationId",
                table: "Places",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Places_userId",
                table: "Places",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Places_work_time_id",
                table: "Places",
                column: "work_time_id");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_superAdminId",
                table: "RefreshTokens",
                column: "superAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_userId",
                table: "RefreshTokens",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialTypeFields_cat2Id",
                table: "SpecialTypeFields",
                column: "cat2Id");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialTypeFields_Cat3Id",
                table: "SpecialTypeFields",
                column: "Cat3Id");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialTypeFields_fieldTypeId",
                table: "SpecialTypeFields",
                column: "fieldTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubPlaces_placeId",
                table: "SubPlaces",
                column: "placeId");

            migrationBuilder.CreateIndex(
                name: "IX_TagCats_catId",
                table: "TagCats",
                column: "catId");

            migrationBuilder.CreateIndex(
                name: "IX_TagCats_tagId",
                table: "TagCats",
                column: "tagId");

            migrationBuilder.CreateIndex(
                name: "IX_ViewCounts_placeId",
                table: "ViewCounts",
                column: "placeId");

            migrationBuilder.CreateIndex(
                name: "IX_ViewCounts_userId",
                table: "ViewCounts",
                column: "userId");

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
                name: "Filters_Cat2s");

            migrationBuilder.DropTable(
                name: "LikeCounts");

            migrationBuilder.DropTable(
                name: "MedicalStaffs");

            migrationBuilder.DropTable(
                name: "Place_Filters");

            migrationBuilder.DropTable(
                name: "Place_Tags");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "SpecialTypeFields");

            migrationBuilder.DropTable(
                name: "SubPlaces");

            migrationBuilder.DropTable(
                name: "TagCats");

            migrationBuilder.DropTable(
                name: "ViewCounts");

            migrationBuilder.DropTable(
                name: "WeekDays");

            migrationBuilder.DropTable(
                name: "Filters");

            migrationBuilder.DropTable(
                name: "SuperAdmins");

            migrationBuilder.DropTable(
                name: "FieldTypes");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Places");

            migrationBuilder.DropTable(
                name: "Cat3s");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "WorkTimes");

            migrationBuilder.DropTable(
                name: "Cat2s");

            migrationBuilder.DropTable(
                name: "Cat1s");
        }
    }
}
