using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaparApi.Migrations
{
    public partial class bt2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "approvedDate",
                table: "BusinessType2s",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deactivatedDate",
                table: "BusinessType2s",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deletedDate",
                table: "BusinessType2s",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "approvedDate",
                table: "BusinessType2s");

            migrationBuilder.DropColumn(
                name: "deactivatedDate",
                table: "BusinessType2s");

            migrationBuilder.DropColumn(
                name: "deletedDate",
                table: "BusinessType2s");
        }
    }
}
