using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalEnCasa.App.Persistencia.Migrations
{
    public partial class Genero2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Generos_Personas_idPersona",
                table: "Generos");

            migrationBuilder.DropIndex(
                name: "IX_Generos_idPersona",
                table: "Generos");

            migrationBuilder.DropColumn(
                name: "idPersona",
                table: "Generos");

            migrationBuilder.AddColumn<int>(
                name: "idGenero",
                table: "Personas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_idGenero",
                table: "Personas",
                column: "idGenero",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Generos_idGenero",
                table: "Personas",
                column: "idGenero",
                principalTable: "Generos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Generos_idGenero",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_idGenero",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "idGenero",
                table: "Personas");

            migrationBuilder.AddColumn<int>(
                name: "idPersona",
                table: "Generos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Generos_idPersona",
                table: "Generos",
                column: "idPersona",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Generos_Personas_idPersona",
                table: "Generos",
                column: "idPersona",
                principalTable: "Personas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
