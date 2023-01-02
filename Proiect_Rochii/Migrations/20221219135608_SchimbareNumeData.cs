using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Rochii.Migrations
{
    public partial class SchimbareNumeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReturnDate",
                table: "Imprumut",
                newName: "DataReturnare");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataImpumutare",
                table: "Imprumut",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataImpumutare",
                table: "Imprumut");

            migrationBuilder.RenameColumn(
                name: "DataReturnare",
                table: "Imprumut",
                newName: "ReturnDate");
        }
    }
}
