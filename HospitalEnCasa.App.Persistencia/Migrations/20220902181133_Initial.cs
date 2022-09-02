using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalEnCasa.App.Persistencia.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hospital",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NIT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospital", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numeroTelefonico = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Auxiliares",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    sucursal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    suHospitalid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auxiliares", x => x.id);
                    table.ForeignKey(
                        name: "FK_Auxiliares_Hospital_suHospitalid",
                        column: x => x.suHospitalid,
                        principalTable: "Hospital",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Auxiliares_Personas_id",
                        column: x => x.id,
                        principalTable: "Personas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonaldeSalud",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    usuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contraseña = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    suHospitalid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaldeSalud", x => x.id);
                    table.ForeignKey(
                        name: "FK_PersonaldeSalud_Hospital_suHospitalid",
                        column: x => x.suHospitalid,
                        principalTable: "Hospital",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonaldeSalud_Personas_id",
                        column: x => x.id,
                        principalTable: "Personas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enfermeras",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    tarjetaProfesional = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    horasLaborales = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enfermeras", x => x.id);
                    table.ForeignKey(
                        name: "FK_Enfermeras_PersonaldeSalud_id",
                        column: x => x.id,
                        principalTable: "PersonaldeSalud",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    especialidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codigo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Medicos_PersonaldeSalud_id",
                        column: x => x.id,
                        principalTable: "PersonaldeSalud",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    fechaDeNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    documento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tipoDeDocumento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    suEnfermeroid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Pacientes_Enfermeras_suEnfermeroid",
                        column: x => x.suEnfermeroid,
                        principalTable: "Enfermeras",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pacientes_Personas_id",
                        column: x => x.id,
                        principalTable: "Personas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FamiliaresDesignados",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    parentesco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idFamiliar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamiliaresDesignados", x => x.id);
                    table.ForeignKey(
                        name: "FK_FamiliaresDesignados_Pacientes_idFamiliar",
                        column: x => x.idFamiliar,
                        principalTable: "Pacientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FamiliaresDesignados_Personas_id",
                        column: x => x.id,
                        principalTable: "Personas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Historias",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idpaciente = table.Column<int>(type: "int", nullable: false),
                    diagnostico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    entorno = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historias", x => x.id);
                    table.ForeignKey(
                        name: "FK_Historias_Pacientes_idpaciente",
                        column: x => x.idpaciente,
                        principalTable: "Pacientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hogar",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    latirud = table.Column<double>(type: "float", nullable: false),
                    longitud = table.Column<double>(type: "float", nullable: false),
                    cidudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idPaciente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hogar", x => x.id);
                    table.ForeignKey(
                        name: "FK_Hogar_Pacientes_idPaciente",
                        column: x => x.idPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicoPaciente",
                columns: table => new
                {
                    pacientesid = table.Column<int>(type: "int", nullable: false),
                    susMedicosid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicoPaciente", x => new { x.pacientesid, x.susMedicosid });
                    table.ForeignKey(
                        name: "FK_MedicoPaciente_Medicos_susMedicosid",
                        column: x => x.susMedicosid,
                        principalTable: "Medicos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicoPaciente_Pacientes_pacientesid",
                        column: x => x.pacientesid,
                        principalTable: "Pacientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SignoVitales",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaYhora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    signo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    valor = table.Column<double>(type: "float", nullable: false),
                    elPacienteid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignoVitales", x => x.id);
                    table.ForeignKey(
                        name: "FK_SignoVitales_Pacientes_elPacienteid",
                        column: x => x.elPacienteid,
                        principalTable: "Pacientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sugerenciaCuidados",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechayHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Historicoid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sugerenciaCuidados", x => x.id);
                    table.ForeignKey(
                        name: "FK_sugerenciaCuidados_Historias_Historicoid",
                        column: x => x.Historicoid,
                        principalTable: "Historias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auxiliares_suHospitalid",
                table: "Auxiliares",
                column: "suHospitalid");

            migrationBuilder.CreateIndex(
                name: "IX_FamiliaresDesignados_idFamiliar",
                table: "FamiliaresDesignados",
                column: "idFamiliar",
                unique: true,
                filter: "[idFamiliar] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Historias_idpaciente",
                table: "Historias",
                column: "idpaciente",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hogar_idPaciente",
                table: "Hogar",
                column: "idPaciente",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicoPaciente_susMedicosid",
                table: "MedicoPaciente",
                column: "susMedicosid");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_suEnfermeroid",
                table: "Pacientes",
                column: "suEnfermeroid");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaldeSalud_suHospitalid",
                table: "PersonaldeSalud",
                column: "suHospitalid");

            migrationBuilder.CreateIndex(
                name: "IX_SignoVitales_elPacienteid",
                table: "SignoVitales",
                column: "elPacienteid");

            migrationBuilder.CreateIndex(
                name: "IX_sugerenciaCuidados_Historicoid",
                table: "sugerenciaCuidados",
                column: "Historicoid");
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
        }
    }
}
