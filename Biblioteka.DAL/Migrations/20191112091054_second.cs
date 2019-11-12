using Microsoft.EntityFrameworkCore.Migrations;

namespace Biblioteka.DAL.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Adresa",
                table: "Autori",
                newName: "Biografija");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Biografija",
                table: "Autori",
                newName: "Adresa");
        }
    }
}
