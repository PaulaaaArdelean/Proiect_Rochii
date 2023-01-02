using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Rochii.Migrations
{
    public partial class CategorieRochie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Designer",
                table: "Rochie");

            migrationBuilder.AddColumn<int>(
                name: "DesignerID",
                table: "Rochie",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeCategorie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Designer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeDesigner = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CategorieRochie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RochieID = table.Column<int>(type: "int", nullable: false),
                    CategorieID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieRochie", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CategorieRochie_Categorie_CategorieID",
                        column: x => x.CategorieID,
                        principalTable: "Categorie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorieRochie_Rochie_RochieID",
                        column: x => x.RochieID,
                        principalTable: "Rochie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rochie_DesignerID",
                table: "Rochie",
                column: "DesignerID");

            migrationBuilder.CreateIndex(
                name: "IX_CategorieRochie_CategorieID",
                table: "CategorieRochie",
                column: "CategorieID");

            migrationBuilder.CreateIndex(
                name: "IX_CategorieRochie_RochieID",
                table: "CategorieRochie",
                column: "RochieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rochie_Designer_DesignerID",
                table: "Rochie",
                column: "DesignerID",
                principalTable: "Designer",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rochie_Designer_DesignerID",
                table: "Rochie");

            migrationBuilder.DropTable(
                name: "CategorieRochie");

            migrationBuilder.DropTable(
                name: "Designer");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropIndex(
                name: "IX_Rochie_DesignerID",
                table: "Rochie");

            migrationBuilder.DropColumn(
                name: "DesignerID",
                table: "Rochie");

            migrationBuilder.AddColumn<string>(
                name: "Designer",
                table: "Rochie",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
