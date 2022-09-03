using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalEnCasa.App.Persistencia.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hospital",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospital", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroTelefonico = table.Column<int>(type: "int", nullable: false),
                    IdGenero = table.Column<int>(type: "int", nullable: false),
                    SuGeneroId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personas_Generos_SuGeneroId",
                        column: x => x.SuGeneroId,
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Auxiliares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Sucursal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuHospitalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auxiliares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Auxiliares_Hospital_SuHospitalId",
                        column: x => x.SuHospitalId,
                        principalTable: "Hospital",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Auxiliares_Personas_Id",
                        column: x => x.Id,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonaldeSalud",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuHospitalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaldeSalud", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonaldeSalud_Hospital_SuHospitalId",
                        column: x => x.SuHospitalId,
                        principalTable: "Hospital",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonaldeSalud_Personas_Id",
                        column: x => x.Id,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enfermeras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TarjetaProfesional = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HorasLaborales = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enfermeras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enfermeras_PersonaldeSalud_Id",
                        column: x => x.Id,
                        principalTable: "PersonaldeSalud",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Especialidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicos_PersonaldeSalud_Id",
                        column: x => x.Id,
                        principalTable: "PersonaldeSalud",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FechaDeNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoDeDocumento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuEnfermeroId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacientes_Enfermeras_SuEnfermeroId",
                        column: x => x.SuEnfermeroId,
                        principalTable: "Enfermeras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pacientes_Personas_Id",
                        column: x => x.Id,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FamiliaresDesignados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Parentesco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdFamiliar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamiliaresDesignados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamiliaresDesignados_Pacientes_IdFamiliar",
                        column: x => x.IdFamiliar,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FamiliaresDesignados_Personas_Id",
                        column: x => x.Id,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Historias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPaciente = table.Column<int>(type: "int", nullable: false),
                    Diagnostico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Entorno = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Historias_Pacientes_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hogar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latirud = table.Column<double>(type: "float", nullable: false),
                    Longitud = table.Column<double>(type: "float", nullable: false),
                    Cidudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdPaciente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hogar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hogar_Pacientes_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicoPaciente",
                columns: table => new
                {
                    PacientesId = table.Column<int>(type: "int", nullable: false),
                    SusMedicosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicoPaciente", x => new { x.PacientesId, x.SusMedicosId });
                    table.ForeignKey(
                        name: "FK_MedicoPaciente_Medicos_SusMedicosId",
                        column: x => x.SusMedicosId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicoPaciente_Pacientes_PacientesId",
                        column: x => x.PacientesId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SignoVitales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaYhora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Signo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    ElPacienteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignoVitales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SignoVitales_Pacientes_ElPacienteId",
                        column: x => x.ElPacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sugerenciaCuidados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechayHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HistoricoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sugerenciaCuidados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sugerenciaCuidados_Historias_HistoricoId",
                        column: x => x.HistoricoId,
                        principalTable: "Historias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auxiliares_SuHospitalId",
                table: "Auxiliares",
                column: "SuHospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_FamiliaresDesignados_IdFamiliar",
                table: "FamiliaresDesignados",
                column: "IdFamiliar",
                unique: true,
                filter: "[IdFamiliar] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Historias_IdPaciente",
                table: "Historias",
                column: "IdPaciente",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hogar_IdPaciente",
                table: "Hogar",
                column: "IdPaciente",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicoPaciente_SusMedicosId",
                table: "MedicoPaciente",
                column: "SusMedicosId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_SuEnfermeroId",
                table: "Pacientes",
                column: "SuEnfermeroId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaldeSalud_SuHospitalId",
                table: "PersonaldeSalud",
                column: "SuHospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_SuGeneroId",
                table: "Personas",
                column: "SuGeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_SignoVitales_ElPacienteId",
                table: "SignoVitales",
                column: "ElPacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_sugerenciaCuidados_HistoricoId",
                table: "sugerenciaCuidados",
                column: "HistoricoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auxiliares");

            migrationBuilder.DropTable(
                name: "FamiliaresDesignados");

            migrationBuilder.DropTable(
                name: "Hogar");

            migrationBuilder.DropTable(
                name: "MedicoPaciente");

            migrationBuilder.DropTable(
                name: "SignoVitales");

            migrationBuilder.DropTable(
                name: "sugerenciaCuidados");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Historias");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Enfermeras");

            migrationBuilder.DropTable(
                name: "PersonaldeSalud");

            migrationBuilder.DropTable(
                name: "Hospital");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Generos");
        }
    }
}
