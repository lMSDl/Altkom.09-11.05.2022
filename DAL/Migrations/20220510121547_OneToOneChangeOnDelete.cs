using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class OneToOneChangeOnDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registration_Vehicle_VehicleId",
                table: "Registration");

            migrationBuilder.AddForeignKey(
                name: "FK_Registration_Vehicle_VehicleId",
                table: "Registration",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registration_Vehicle_VehicleId",
                table: "Registration");

            migrationBuilder.AddForeignKey(
                name: "FK_Registration_Vehicle_VehicleId",
                table: "Registration",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
