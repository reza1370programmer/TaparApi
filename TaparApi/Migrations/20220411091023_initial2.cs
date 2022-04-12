using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaparApi.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpecialTypeFields_BusinessType2s_businessType2Id",
                table: "SpecialTypeFields");

            migrationBuilder.AlterColumn<long>(
                name: "businessType2Id",
                table: "SpecialTypeFields",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialTypeFields_BusinessType2s_businessType2Id",
                table: "SpecialTypeFields",
                column: "businessType2Id",
                principalTable: "BusinessType2s",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpecialTypeFields_BusinessType2s_businessType2Id",
                table: "SpecialTypeFields");

            migrationBuilder.AlterColumn<long>(
                name: "businessType2Id",
                table: "SpecialTypeFields",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialTypeFields_BusinessType2s_businessType2Id",
                table: "SpecialTypeFields",
                column: "businessType2Id",
                principalTable: "BusinessType2s",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
