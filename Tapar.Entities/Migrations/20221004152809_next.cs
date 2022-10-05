using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tapar.Data.Migrations
{
    public partial class next : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_Locations_LocationId",
                table: "Places");

            migrationBuilder.DropForeignKey(
                name: "FK_Places_WorkTimes_work_time_id",
                table: "Places");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Places",
                newName: "locationId");

            migrationBuilder.RenameColumn(
                name: "work_time_id",
                table: "Places",
                newName: "workTimeId");

            migrationBuilder.RenameIndex(
                name: "IX_Places_LocationId",
                table: "Places",
                newName: "IX_Places_locationId");

            migrationBuilder.RenameIndex(
                name: "IX_Places_work_time_id",
                table: "Places",
                newName: "IX_Places_workTimeId");

            migrationBuilder.AlterColumn<int>(
                name: "locationId",
                table: "Places",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Locations_locationId",
                table: "Places",
                column: "locationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Places_WorkTimes_workTimeId",
                table: "Places",
                column: "workTimeId",
                principalTable: "WorkTimes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_Locations_locationId",
                table: "Places");

            migrationBuilder.DropForeignKey(
                name: "FK_Places_WorkTimes_workTimeId",
                table: "Places");

            migrationBuilder.RenameColumn(
                name: "locationId",
                table: "Places",
                newName: "LocationId");

            migrationBuilder.RenameColumn(
                name: "workTimeId",
                table: "Places",
                newName: "work_time_id");

            migrationBuilder.RenameIndex(
                name: "IX_Places_locationId",
                table: "Places",
                newName: "IX_Places_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Places_workTimeId",
                table: "Places",
                newName: "IX_Places_work_time_id");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Places",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Locations_LocationId",
                table: "Places",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_WorkTimes_work_time_id",
                table: "Places",
                column: "work_time_id",
                principalTable: "WorkTimes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
