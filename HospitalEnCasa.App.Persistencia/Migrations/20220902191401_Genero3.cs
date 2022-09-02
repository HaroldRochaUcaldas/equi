using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalEnCasa.App.Persistencia.Migrations
{
    public partial class Genero3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Generos_idGenero",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_idGenero",
                table: "Personas");

            migrationBuilder.AddColumn<int>(
                name: "suGeneroId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_suGeneroId",
                table: "Personas",
                column: "suGeneroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Generos_suGeneroId",
                table: "Personas",
                column: "suGeneroId",
                principalTable: "Generos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Generos_suGeneroId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_suGeneroId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "suGeneroId",
                table: "Personas");

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
    }
}
