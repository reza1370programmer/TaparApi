using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tapar.Data.Migrations
{
    public partial class fulltextcapabiliy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(sql: "CREATE FULLTEXT CATALOG ftCatalog AS DEFAULT;",
                                suppressTransaction: true);
            migrationBuilder.Sql(
                                    sql: "CREATE FULLTEXT INDEX ON Places(tablo,service_description) KEY INDEX PK_Places;",
                                    suppressTransaction: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
