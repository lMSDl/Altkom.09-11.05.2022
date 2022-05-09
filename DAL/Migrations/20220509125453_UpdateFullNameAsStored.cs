using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class UpdateFullNameAsStored : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                schema: "efc",
                table: "People",
                type: "nvarchar(max)",
                nullable: true,
                computedColumnSql: "[Name] + ' ' + [LastName]",
                stored: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComputedColumnSql: "[Name] + ' ' + [LastName]",
                oldStored: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                schema: "efc",
                table: "People",
                type: "nvarchar(max)",
                nullable: true,
                computedColumnSql: "[Name] + ' ' + [LastName]",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComputedColumnSql: "[Name] + ' ' + [LastName]");
        }
    }
}
