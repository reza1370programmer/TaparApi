using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaparApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessCategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    gdesc = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessCategories", x => x.Id);
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
                name: "LocationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuperAdmins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fullName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperAdmins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    mobile = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    nickName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    firstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    nationalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessType1s",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    gdesc = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    businessCategoryId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessType1s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessType1s_BusinessCategories_businessCategoryId",
                        column: x => x.businessCategoryId,
                        principalTable: "BusinessCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    longitude = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    latitude = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    parentId = table.Column<int>(type: "int", nullable: true),
                    locationTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_LocationTypes_locationTypeId",
                        column: x => x.locationTypeId,
                        principalTable: "LocationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusinessOffices",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    gKey = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    phone1 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    phone2 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    phone3 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    fax = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    mob1 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    mob2 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    longitude = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    latitude = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    postCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    viewPic = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    area = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    website = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    telegram = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    whatsapp = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    instagram = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    parentId = table.Column<long>(type: "bigint", nullable: true),
                    userId = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_BusinessOffices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessOffices_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusinessPeople",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    gender = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    gDesc = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    nationalCode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    pic = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    userId = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_BusinessPeople", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessPeople_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusinessType2s",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    gdesc = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    businessType1Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessType2s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessType2s_BusinessType1s_businessType1Id",
                        column: x => x.businessType1Id,
                        principalTable: "BusinessType1s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OfficeUpdates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    phone1 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    phone2 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    phone3 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    fax = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    mob1 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    mob2 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    longitude = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    latitude = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    postCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    viewPic = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    area = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    website = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    telegram = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    whatsapp = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    instagram = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    modifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifiedUserId = table.Column<long>(type: "bigint", nullable: true),
                    businessOfficeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeUpdates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfficeUpdates_BusinessOffices_businessOfficeId",
                        column: x => x.businessOfficeId,
                        principalTable: "BusinessOffices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Businesses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titel = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    serviceDesc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    likeCount = table.Column<int>(type: "int", nullable: true),
                    viewCount = table.Column<int>(type: "int", nullable: true),
                    workTimeDesc = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    specialMessage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    longitude = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    lattitude = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    visitPic = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    tabloPic = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    workTime = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    businessOfficeId = table.Column<long>(type: "bigint", nullable: false),
                    businessType2Id = table.Column<long>(type: "bigint", nullable: false),
                    businessPersonId = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_Businesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Businesses_BusinessOffices_businessOfficeId",
                        column: x => x.businessOfficeId,
                        principalTable: "BusinessOffices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Businesses_BusinessPeople_businessPersonId",
                        column: x => x.businessPersonId,
                        principalTable: "BusinessPeople",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Businesses_BusinessType2s_businessType2Id",
                        column: x => x.businessType2Id,
                        principalTable: "BusinessType2s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpecialTypeFields",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    enTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    businessType1Id = table.Column<long>(type: "bigint", nullable: false),
                    businessType2Id = table.Column<long>(type: "bigint", nullable: false),
                    fieldTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialTypeFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialTypeFields_BusinessType1s_businessType1Id",
                        column: x => x.businessType1Id,
                        principalTable: "BusinessType1s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpecialTypeFields_BusinessType2s_businessType2Id",
                        column: x => x.businessType2Id,
                        principalTable: "BusinessType2s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpecialTypeFields_FieldTypes_fieldTypeId",
                        column: x => x.fieldTypeId,
                        principalTable: "FieldTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusinessUpdates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titel = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    serviceDesc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    workTimeDesc = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    specialMessage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    longitude = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    lattitude = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    visitPic = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    tabloPic = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    workTime = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    modifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifiedUserId = table.Column<long>(type: "bigint", nullable: true),
                    businessId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessUpdates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessUpdates_Businesses_businessId",
                        column: x => x.businessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    approvedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    approveUserId = table.Column<long>(type: "bigint", nullable: false),
                    userId = table.Column<long>(type: "bigint", nullable: false),
                    businessId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Businesses_businessId",
                        column: x => x.businessId,
                        principalTable: "Businesses",
                        principalColumn: "Id");
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
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    likeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userId = table.Column<long>(type: "bigint", nullable: false),
                    businessId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikeCounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LikeCounts_Businesses_businessId",
                        column: x => x.businessId,
                        principalTable: "Businesses",
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
                name: "ViewCounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    viewDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    clientDetail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userId = table.Column<long>(type: "bigint", nullable: false),
                    businessId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViewCounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ViewCounts_Businesses_businessId",
                        column: x => x.businessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ViewCounts_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_businessOfficeId",
                table: "Businesses",
                column: "businessOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_businessPersonId",
                table: "Businesses",
                column: "businessPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_businessType2Id",
                table: "Businesses",
                column: "businessType2Id");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessOffices_userId",
                table: "BusinessOffices",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessPeople_userId",
                table: "BusinessPeople",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessType1s_businessCategoryId",
                table: "BusinessType1s",
                column: "businessCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessType2s_businessType1Id",
                table: "BusinessType2s",
                column: "businessType1Id");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessUpdates_businessId",
                table: "BusinessUpdates",
                column: "businessId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_businessId",
                table: "Comments",
                column: "businessId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_userId",
                table: "Comments",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_LikeCounts_businessId",
                table: "LikeCounts",
                column: "businessId");

            migrationBuilder.CreateIndex(
                name: "IX_LikeCounts_userId",
                table: "LikeCounts",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_locationTypeId",
                table: "Locations",
                column: "locationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeUpdates_businessOfficeId",
                table: "OfficeUpdates",
                column: "businessOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialTypeFields_businessType1Id",
                table: "SpecialTypeFields",
                column: "businessType1Id");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialTypeFields_businessType2Id",
                table: "SpecialTypeFields",
                column: "businessType2Id");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialTypeFields_fieldTypeId",
                table: "SpecialTypeFields",
                column: "fieldTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ViewCounts_businessId",
                table: "ViewCounts",
                column: "businessId");

            migrationBuilder.CreateIndex(
                name: "IX_ViewCounts_userId",
                table: "ViewCounts",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessUpdates");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "LikeCounts");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "OfficeUpdates");

            migrationBuilder.DropTable(
                name: "SpecialTypeFields");

            migrationBuilder.DropTable(
                name: "SuperAdmins");

            migrationBuilder.DropTable(
                name: "ViewCounts");

            migrationBuilder.DropTable(
                name: "LocationTypes");

            migrationBuilder.DropTable(
                name: "FieldTypes");

            migrationBuilder.DropTable(
                name: "Businesses");

            migrationBuilder.DropTable(
                name: "BusinessOffices");

            migrationBuilder.DropTable(
                name: "BusinessPeople");

            migrationBuilder.DropTable(
                name: "BusinessType2s");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "BusinessType1s");

            migrationBuilder.DropTable(
                name: "BusinessCategories");
        }
    }
}
