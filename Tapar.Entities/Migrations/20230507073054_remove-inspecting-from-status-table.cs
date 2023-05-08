using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tapar.Data.Migrations
{
    public partial class removeinspectingfromstatustable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Acception_Statuses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Acception_Statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "Approved");

            migrationBuilder.UpdateData(
                table: "Acception_Statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "Waiting");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Acception_Statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "Waiting");

            migrationBuilder.UpdateData(
                table: "Acception_Statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "Approved");

            migrationBuilder.InsertData(
                table: "Acception_Statuses",
                columns: new[] { "Id", "Title" },
                values: new object[] { 4, "Inspecting" });
        }
    }
}
