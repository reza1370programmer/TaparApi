using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaparApi.Migrations
{
    public partial class next : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Businesses_BusinessPeople_businessPersonId",
                table: "Businesses");

            migrationBuilder.DropTable(
                name: "BusinessPeople");

            migrationBuilder.DropIndex(
                name: "IX_Businesses_businessPersonId",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "businessPersonId",
                table: "Businesses");

            migrationBuilder.AlterColumn<string>(
                name: "nationalCode",
                table: "Users",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "lastName",
                table: "Users",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "firstName",
                table: "Users",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "firstName",
                table: "Businesses",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "gdesc",
                table: "Businesses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "gender",
                table: "Businesses",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "lastName",
                table: "Businesses",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "nationalCode",
                table: "Businesses",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "picture",
                table: "Businesses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "firstName",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "gdesc",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "gender",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "lastName",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "nationalCode",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "picture",
                table: "Businesses");

            migrationBuilder.AlterColumn<string>(
                name: "nationalCode",
                table: "Users",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "lastName",
                table: "Users",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "firstName",
                table: "Users",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "businessPersonId",
                table: "Businesses",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "BusinessPeople",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<long>(type: "bigint", nullable: false),
                    approvedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    approvedUserId = table.Column<long>(type: "bigint", nullable: true),
                    cDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    cUserId = table.Column<long>(type: "bigint", nullable: true),
                    deactivatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deactivatedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deactivatedUserId = table.Column<long>(type: "bigint", nullable: true),
                    deletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deletedUserId = table.Column<long>(type: "bigint", nullable: true),
                    firstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    gDesc = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    gender = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    modifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifiedUserId = table.Column<long>(type: "bigint", nullable: true),
                    nationalCode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    pic = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_businessPersonId",
                table: "Businesses",
                column: "businessPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessPeople_userId",
                table: "BusinessPeople",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Businesses_BusinessPeople_businessPersonId",
                table: "Businesses",
                column: "businessPersonId",
                principalTable: "BusinessPeople",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
