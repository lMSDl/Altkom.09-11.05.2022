using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddTPH : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "AverageGrade",
                schema: "efc",
                table: "People",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IndexNumber",
                schema: "efc",
                table: "People",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Specialization",
                schema: "efc",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                schema: "efc",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AverageGrade",
                schema: "efc",
                table: "People");

            migrationBuilder.DropColumn(
                name: "IndexNumber",
                schema: "efc",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Specialization",
                schema: "efc",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Type",
                schema: "efc",
                table: "People");
        }
    }
}
