using Microsoft.EntityFrameworkCore.Migrations;
using Oracle.EntityFrameworkCore.Metadata;

namespace Biblioteka.DAL.Migrations
{
    public partial class initialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autori",
                columns: table => new
                {
                    aId = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Adresa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autori", x => x.aId);
                });

            migrationBuilder.CreateTable(
                name: "Izdavaci",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(nullable: true),
                    Sjediste = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Izdavaci", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Knjige",
                columns: table => new
                {
                    kId = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    Naslov = table.Column<string>(nullable: true),
                    Cijena = table.Column<decimal>(nullable: false),
                    IzdavacId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Knjige", x => x.kId);
                    table.ForeignKey(
                        name: "FK_Knjige_Izdavaci_IzdavacId",
                        column: x => x.IzdavacId,
                        principalTable: "Izdavaci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AutKnjige",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    AutoraId = table.Column<int>(nullable: true),
                    KnjigakId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutKnjige", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutKnjige_Autori_AutoraId",
                        column: x => x.AutoraId,
                        principalTable: "Autori",
                        principalColumn: "aId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AutKnjige_Knjige_KnjigakId",
                        column: x => x.KnjigakId,
                        principalTable: "Knjige",
                        principalColumn: "kId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutKnjige_AutoraId",
                table: "AutKnjige",
                column: "AutoraId");

            migrationBuilder.CreateIndex(
                name: "IX_AutKnjige_KnjigakId",
                table: "AutKnjige",
                column: "KnjigakId");

            migrationBuilder.CreateIndex(
                name: "IX_Knjige_IzdavacId",
                table: "Knjige",
                column: "IzdavacId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutKnjige");

            migrationBuilder.DropTable(
                name: "Autori");

            migrationBuilder.DropTable(
                name: "Knjige");

            migrationBuilder.DropTable(
                name: "Izdavaci");
        }
    }
}
