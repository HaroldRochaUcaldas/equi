using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalEnCasa.App.Persistencia.Migrations
{
    public partial class Genero : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Historias_Pacientes_idpaciente",
                table: "Historias");

            migrationBuilder.RenameColumn(
                name: "idpaciente",
                table: "Historias",
                newName: "idPaciente");

            migrationBuilder.RenameIndex(
                name: "IX_Historias_idpaciente",
                table: "Historias",
                newName: "IX_Historias_idPaciente");

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idPersona = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Generos_Personas_idPersona",
                        column: x => x.idPersona,
                        principalTable: "Personas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Generos_idPersona",
                table: "Generos",
                column: "idPersona",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Historias_Pacientes_idPaciente",
                table: "Historias",
                column: "idPaciente",
                principalTable: "Pacientes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Historias_Pacientes_idPaciente",
                table: "Historias");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.RenameColumn(
                name: "idPaciente",
                table: "Historias",
                newName: "idpaciente");

            migrationBuilder.RenameIndex(
                name: "IX_Historias_idPaciente",
                table: "Historias",
                newName: "IX_Historias_idpaciente");

            migrationBuilder.AddForeignKey(
                name: "FK_Historias_Pacientes_idpaciente",
                table: "Historias",
                column: "idpaciente",
                principalTable: "Pacientes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
