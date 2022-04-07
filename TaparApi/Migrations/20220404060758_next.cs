using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaparApi.Migrations
{
    public partial class next : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "approvedDate",
                table: "BusinessCategories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deactivatedDate",
                table: "BusinessCategories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deletedDate",
                table: "BusinessCategories",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "approvedDate",
                table: "BusinessCategories");

            migrationBuilder.DropColumn(
                name: "deactivatedDate",
                table: "BusinessCategories");

            migrationBuilder.DropColumn(
                name: "deletedDate",
                table: "BusinessCategories");
        }
    }
}
