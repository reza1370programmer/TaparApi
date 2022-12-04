using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tapar.Data.Migrations
{
    public partial class changesforcat2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cat2s_Cat1s_cat1Id",
                table: "Cat2s");

            migrationBuilder.DropColumn(
                name: "popup_state",
                table: "Cat2s");

            migrationBuilder.AlterColumn<int>(
                name: "cat1Id",
                table: "Cat2s",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cat2s_Cat1s_cat1Id",
                table: "Cat2s",
                column: "cat1Id",
                principalTable: "Cat1s",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cat2s_Cat1s_cat1Id",
                table: "Cat2s");

            migrationBuilder.AlterColumn<int>(
                name: "cat1Id",
                table: "Cat2s",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "popup_state",
                table: "Cat2s",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Cat2s_Cat1s_cat1Id",
                table: "Cat2s",
                column: "cat1Id",
                principalTable: "Cat1s",
                principalColumn: "Id");
        }
    }
}
