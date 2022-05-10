using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class RemoveFilterFromStreetCityIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Address_Street_City",
                table: "Address");

            migrationBuilder.CreateIndex(
                name: "IX_Address_Street_City",
                table: "Address",
                columns: new[] { "Street", "City" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Address_Street_City",
                table: "Address");

            migrationBuilder.CreateIndex(
                name: "IX_Address_Street_City",
                table: "Address",
                columns: new[] { "Street", "City" },
                unique: true,
                filter: "[Street] IS NOT NULL AND [City] IS NOT NULL");
        }
    }
}
