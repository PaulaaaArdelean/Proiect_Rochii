using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Rochii.Migrations
{
    public partial class AZisMariaSaFacMigrare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clienta",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeClienta = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PrenumeClienta = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clienta", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Imprumut",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientaID = table.Column<int>(type: "int", nullable: true),
                    RochieID = table.Column<int>(type: "int", nullable: true),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imprumut", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Imprumut_Clienta_ClientaID",
                        column: x => x.ClientaID,
                        principalTable: "Clienta",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Imprumut_Rochie_RochieID",
                        column: x => x.RochieID,
                        principalTable: "Rochie",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Imprumut_ClientaID",
                table: "Imprumut",
                column: "ClientaID");

            migrationBuilder.CreateIndex(
                name: "IX_Imprumut_RochieID",
                table: "Imprumut",
                column: "RochieID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Imprumut");

            migrationBuilder.DropTable(
                name: "Clienta");
        }
    }
}
