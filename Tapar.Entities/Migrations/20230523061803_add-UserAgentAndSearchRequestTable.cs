using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tapar.Data.Migrations
{
    public partial class addUserAgentAndSearchRequestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SearchRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SearchKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SearchCount = table.Column<int>(type: "int", nullable: false),
                    SearchDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAgents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Referer = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EnteranceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BrowserName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DeviceType = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAgents", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SearchRequests");

            migrationBuilder.DropTable(
                name: "UserAgents");
        }
    }
}
