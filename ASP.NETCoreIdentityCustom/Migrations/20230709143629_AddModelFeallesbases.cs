using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bornholm_Sleagts.Migrations
{
    public partial class AddModelFeallesbases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feallesbases",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AvisTypeID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Avisdato = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Efternavn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fornavne = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Foedt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Alder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Doebenavn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Erhverv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SognID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TidlBopael = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Doedsdato = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Begravelsesdato = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Begravelsessted = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Efterladte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlereDoedsannoncer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AndreDataFraAnnoncen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Oegenavne = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nekrolog = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Mindeord = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Statstidende = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Partnerlink = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feallesbases", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feallesbases");
        }
    }
}
