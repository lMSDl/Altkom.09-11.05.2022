using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ChangeSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "efc");

            migrationBuilder.RenameTable(
                name: "People",
                newName: "People",
                newSchema: "efc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "People",
                schema: "efc",
                newName: "People");
        }
    }
}
