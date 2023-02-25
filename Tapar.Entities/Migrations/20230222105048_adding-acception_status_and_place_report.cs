using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tapar.Data.Migrations
{
    public partial class addingacception_status_and_place_report : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status",
                table: "Places",
                newName: "StatusId");

            migrationBuilder.AddColumn<string>(
                name: "RejectedDescription",
                table: "Places",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Acception_Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acception_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Report_Options",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report_Options", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Place_Reports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Other_Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PlaceId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ReportOptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Place_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Place_Reports_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Place_Reports_Report_Options_ReportOptionId",
                        column: x => x.ReportOptionId,
                        principalTable: "Report_Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Place_Reports_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Acception_Statuses",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Waiting" },
                    { 2, "Approved" },
                    { 3, "Rejected" },
                    { 4, "Inspecting" }
                });

            migrationBuilder.InsertData(
                table: "Report_Options",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "غلط املایی وجود دارد" },
                    { 2, "آدرس اشتباه است" },
                    { 3, "تلفن اشتباه است" },
                    { 4, "موبایل اشتباه است" },
                    { 5, "این کسب و کار وجود ندارد" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Places_StatusId",
                table: "Places",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Place_Reports_PlaceId",
                table: "Place_Reports",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Place_Reports_ReportOptionId",
                table: "Place_Reports",
                column: "ReportOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Place_Reports_UserId",
                table: "Place_Reports",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Acception_Statuses_StatusId",
                table: "Places",
                column: "StatusId",
                principalTable: "Acception_Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_Acception_Statuses_StatusId",
                table: "Places");

            migrationBuilder.DropTable(
                name: "Acception_Statuses");

            migrationBuilder.DropTable(
                name: "Place_Reports");

            migrationBuilder.DropTable(
                name: "Report_Options");

            migrationBuilder.DropIndex(
                name: "IX_Places_StatusId",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "RejectedDescription",
                table: "Places");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Places",
                newName: "status");
        }
    }
}
