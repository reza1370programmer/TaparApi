using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tapar.Data.Migrations
{
    public partial class changes_comment_tbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "approv_date",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "approv_date_userId",
                table: "Comments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "approv_date",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "approv_date_userId",
                table: "Comments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
