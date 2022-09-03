﻿// <auto-generated />
using System;
using HospitalEnCasa.App.Persistencia.AppRepositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HospitalEnCasa.App.Persistencia.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220903161534_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("HospitalEnCasa.App.Dominio.entidades.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("HospitalEnCasa.App.Dominio.entidades.Historico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Diagnostico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Entorno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdPaciente")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdPaciente")
                        .IsUnique();

                    b.ToTable("Historicos");
                });

            modelBuilder.Entity("HospitalEnCasa.App.Dominio.entidades.Hogar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Ciudad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdPaciente")
                        .HasColumnType("int");

                    b.Property<double>("Latitud")
                        .HasColumnType("float");

                    b.Property<double>("Longitud")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("IdPaciente")
                        .IsUnique();

                    b.ToTable("Hogars");
                });

            modelBuilder.Entity("HospitalEnCasa.App.Dominio.entidades.Hospital", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Nit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Hospitals");
                });

            modelBuilder.Entity("HospitalEnCasa.App.Dominio.entidades.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("IdGenero")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroTelefonico")
                        .HasColumnType("int");

                    b.Property<int?>("SuGeneroId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SuGeneroId");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("HospitalEnCasa.App.Dominio.entidades.SignoVital", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("ElPacienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaYhora")
                        .HasColumnType("datetime2");

                    b.Property<string>("Signo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ElPacienteId");

                    b.ToTable("SignoVitals");
                });

            modelBuilder.Entity("HospitalEnCasa.App.Dominio.entidades.SugerenciaDeCuidado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechayHora")
                        .HasColumnType("datetime2");

                    b.Property<int?>("HistoricoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HistoricoId");

                    b.ToTable("SugerenciaDeCuidado");
                });

            modelBuilder.Entity("MedicoPaciente", b =>
                {
                    b.Property<int>("PacientesId")
                        .HasColumnType("int");

                    b.Property<int>("SusMedicosId")
                        .HasColumnType("int");

                    b.HasKey("PacientesId", "SusMedicosId");

                    b.HasIndex("SusMedicosId");

                    b.ToTable("MedicoPaciente");
                });

            modelBuilder.Entity("HospitalEnCasa.App.Dominio.entidades.Auxiliar", b =>
                {
                    b.HasBaseType("HospitalEnCasa.App.Dominio.entidades.Persona");

                    b.Property<int?>("SuHospitalId")
                        .HasColumnType("int");

                    b.Property<string>("Sucursal")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("SuHospitalId");

                    b.ToTable("Auxiliares");
                });

            modelBuilder.Entity("HospitalEnCasa.App.Dominio.entidades.FamiliarDesignado", b =>
                {
                    b.HasBaseType("HospitalEnCasa.App.Dominio.entidades.Persona");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdFamiliar")
                        .HasColumnType("int");

                    b.Property<string>("Parentesco")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("IdFamiliar")
                        .IsUnique()
                        .HasFilter("[IdFamiliar] IS NOT NULL");

                    b.ToTable("FamiliaresDesignados");
                });

            modelBuilder.Entity("HospitalEnCasa.App.Dominio.entidades.Paciente", b =>
                {
                    b.HasBaseType("HospitalEnCasa.App.Dominio.entidades.Persona");

                    b.Property<string>("Documento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaDeNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<int?>("SuEnfermeroId")
                        .HasColumnType("int");

                    b.Property<string>("TipoDeDocumento")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("SuEnfermeroId");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("HospitalEnCasa.App.Dominio.entidades.PersonalDeSalud", b =>
                {
                    b.HasBaseType("HospitalEnCasa.App.Dominio.entidades.Persona");

                    b.Property<string>("Contraseña")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SuHospitalId")
                        .HasColumnType("int");

                    b.Property<string>("Usuario")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("SuHospitalId");

                    b.ToTable("PersonaldeSalud");
                });

            modelBuilder.Entity("HospitalEnCasa.App.Dominio.entidades.Enfermero", b =>
                {
                    b.HasBaseType("HospitalEnCasa.App.Dominio.entidades.PersonalDeSalud");

                    b.Property<int>("HorasLaborales")
                        .HasColumnType("int");

                    b.Property<string>("TarjetaProfesional")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Enfermeras");
                });

            modelBuilder.Entity("HospitalEnCasa.App.Dominio.entidades.Medico", b =>
                {
                    b.HasBaseType("HospitalEnCasa.App.Dominio.entidades.PersonalDeSalud");

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Especialidad")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Medicos");
                });

            modelBuilder.Entity("HospitalEnCasa.App.Dominio.entidades.Historico", b =>
                {
                    b.HasOne("HospitalEnCasa.App.Dominio.entidades.Paciente", "ElPaciente")
                        .WithOne("HistorialMedico")
                        .HasForeignKey("HospitalEnCasa.App.Dominio.entidades.Historico", "IdPaciente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ElPaciente");
                });

            modelBuilder.Entity("HospitalEnCasa.App.Dominio.entidades.Hogar", b =>
                {
                    b.HasOne("HospitalEnCasa.App.Dominio.entidades.Paciente", "ElPaciente")
                        .WithOne("SuHogar")
                        .HasForeignKey("HospitalEnCasa.App.Dominio.entidades.Hogar", "IdPaciente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ElPaciente");
                });

            modelBuilder.Entity("HospitalEnCasa.App.Dominio.entidades.Persona", b =>
                {
                    b.HasOne("HospitalEnCasa.App.Dominio.entidades.Genero", "SuGenero")
                        .WithMany("LaPersona")
                        .HasForeignKey("SuGeneroId");

                    b.Navigation("SuGenero");
                });

            modelBuilder.Entity("HospitalEnCasa.App.Dominio.entidades.SignoVital", b =>
                {
                    b.HasOne("HospitalEnCasa.App.Dominio.entidades.Paciente", "ElPaciente")
                        .WithMany("SignosVitales")
                        .HasForeignKey("ElPacienteId");

                    b.Navigation("ElPaciente");
                });

            modelBuilder.Entity("HospitalEnCasa.App.Dominio.entidades.SugerenciaDeCuidado", b =>
                {
                    b.HasOne("HospitalEnCasa.App.Dominio.entidades.Historico", null)
                        .WithMany("SugerenciasDeCuidados")
                        .HasForeignKey("HistoricoId");
                });

            modelBuilder.Entity("MedicoPaciente", b =>
                {
                    b.HasOne("HospitalEnCasa.App.Dominio.entidades.Paciente", null)
                        .WithMany()
                        .HasForeignKey("PacientesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalEnCasa.App.Dominio.entidades.Medico", null)
                        .WithMany()
                        .HasForeignKey("SusMedicosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HospitalEnCasa.App.Dominio.entidades.Auxiliar", b =>
                {
                    b.HasOne("HospitalEnCasa.App.Dominio.entidades.Persona", null)
                        .WithOne()
                        .HasForeignKey("HospitalEnCasa.App.Dominio.entidades.Auxiliar", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("HospitalEnCasa.App.Dominio.entidades.Hospital", "SuHospital")
                        .WithMany("Auxiliares")
                        .HasForeignKey("SuHospitalId");

                    b.Navigation("SuHospital");
                });

            modelBuilder.Entity("HospitalEnCasa.App.Dominio.entidades.FamiliarDesignado", b =>
                {
                    b.HasOne("HospitalEnCasa.App.Dominio.entidades.Persona", null)
                        .WithOne()
                        .HasForeignKey("HospitalEnCasa.App.Dominio.entidades.FamiliarDesignado", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("HospitalEnCasa.App.Dominio.entidades.Paciente", "SuFamiliar")
                        .WithOne("SuFamiliarDesinado")
                        .HasForeignKey("HospitalEnCasa.App.Dominio.entidades.FamiliarDesignado", "IdFamiliar")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SuFamiliar");
                });

            modelBuilder.Entity("HospitalEnCasa.App.Dominio.entidades.Paciente", b =>
                {
                    b.HasOne("HospitalEnCasa.App.Dominio.entidades.Persona", null)
                        .WithOne()
                        .HasForeignKey("HospitalEnCasa.App.Dominio.entidades.Paciente", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("HospitalEnCasa.App.Dominio.entidades.Enfermero", "SuEnfermero")
                        .WithMany("Pacientes")
                        .HasForeignKey("SuEnfermeroId");

                    b.Navigation("SuEnfermero");
                });

            modelBuilder.Entity("HospitalEnCasa.App.Dominio.entidades.PersonalDeSalud", b =>
                {
                    b.HasOne("HospitalEnCasa.App.Dominio.entidades.Persona", null)
                        .WithOne()
                        .HasForeignKey("HospitalEnCasa.App.Dominio.entidades.PersonalDeSalud", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("HospitalEnCasa.App.Dominio.entidades.Hospital", "SuHospital")
                        .WithMany("ListaPersonalDeSalud")
                        .HasForeignKey("SuHospitalId");

                    b.Navigation("SuHospital");
                });

            modelBuilder.Entity("HospitalEnCasa.App.Dominio.entidades.Enfermero", b =>
                {
                    b.HasOne("HospitalEnCasa.App.Dominio.entidades.PersonalDeSalud", null)
                        .WithOne()
                        .HasForeignKey("HospitalEnCasa.App.Dominio.entidades.Enfermero", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HospitalEnCasa.App.Dominio.entidades.Medico", b =>
                {
                    b.HasOne("HospitalEnCasa.App.Dominio.entidades.PersonalDeSalud", null)
                        .WithOne()
                        .HasForeignKey("HospitalEnCasa.App.Dominio.entidades.Medico", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HospitalEnCasa.App.Dominio.entidades.Genero", b =>
                {
                    b.Navigation("LaPersona");
                });

            modelBuilder.Entity("HospitalEnCasa.App.Dominio.entidades.Historico", b =>
                {
                    b.Navigation("SugerenciasDeCuidados");
                });

            modelBuilder.Entity("HospitalEnCasa.App.Dominio.entidades.Hospital", b =>
                {
                    b.Navigation("Auxiliares");

                    b.Navigation("ListaPersonalDeSalud");
                });

            modelBuilder.Entity("HospitalEnCasa.App.Dominio.entidades.Paciente", b =>
                {
                    b.Navigation("HistorialMedico");

                    b.Navigation("SignosVitales");

                    b.Navigation("SuFamiliarDesinado");

                    b.Navigation("SuHogar");
                });

            modelBuilder.Entity("HospitalEnCasa.App.Dominio.entidades.Enfermero", b =>
                {
                    b.Navigation("Pacientes");
                });
#pragma warning restore 612, 618
        }
    }
}
