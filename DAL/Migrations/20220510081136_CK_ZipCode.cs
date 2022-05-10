using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class CK_ZipCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CK_ZipCode",
                table: "Address",
                sql: "LEN([ZipCode]) = 6 AND CHARINDEX('-', [ZipCode]) = 3");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_ZipCode",
                table: "Address");
        }
    }
}
