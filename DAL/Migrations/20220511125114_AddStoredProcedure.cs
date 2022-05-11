using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddStoredProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
@"CREATE PROCEDURE efc.GetPersonByPESEL @PESEL decimal(11, 0)
AS BEGIN
SELECT * FROM efc.People
WHERE PESEL = @PESEL
END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE efc.GetPersonByPESEL");
        }
    }
}
