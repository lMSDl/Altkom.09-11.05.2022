using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class OneToOneChangeToOptional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registration_Vehicle_VehicleId",
                table: "Registration");

            migrationBuilder.DropIndex(
                name: "IX_Registration_VehicleId",
                table: "Registration");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "Registration",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_VehicleId",
                table: "Registration",
                column: "VehicleId",
                unique: true,
                filter: "[VehicleId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Registration_Vehicle_VehicleId",
                table: "Registration",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registration_Vehicle_VehicleId",
                table: "Registration");

            migrationBuilder.DropIndex(
                name: "IX_Registration_VehicleId",
                table: "Registration");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "Registration",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Registration_VehicleId",
                table: "Registration",
                column: "VehicleId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Registration_Vehicle_VehicleId",
                table: "Registration",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
