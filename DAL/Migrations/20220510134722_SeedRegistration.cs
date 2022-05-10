using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class SeedRegistration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Registration",
                columns: new[] { "Id", "Number", "Updated", "VehicleId" },
                values: new object[] { 100, "ASJDA2313418", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1500 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Registration",
                keyColumn: "Id",
                keyValue: 100);
        }
    }
}
