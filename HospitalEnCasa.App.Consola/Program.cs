using System;
using HospitalEnCasa.App.Dominio.entidades;
using HospitalEnCasa.App.Persistencia.AppRepositorios;
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace HospitalEnCasa.App.Consola
{
    public class Program
    {
        private static IRepositorioPaciente _repoPaciente = new RepositorioPaciente(new ApplicationContext());
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            AddPaciente();
        }
        private static void AddPaciente()
        {
            var paciente = new Paciente
            {
                Nombre = "Harold Rocha",
                FechaDeNacimiento= new DateTime(1995,02,13),
                Documento="1018474393",
                TipoDeDocumento="C.C",
                /*SusMedicos= new Collection<Medico>(),
                SuEnfermero= new Enfermero {
                    TarjetaProfesional="adquirida",
                    HorasLaborales=2
                },
                SuFamiliarDesinado= new FamiliarDesignado{
                  Parentesco="hermano",
                  Correo="haroldrocha.tic@ucaldas.edu.co"
                },
                SuHogar= new Hogar{
                  Direccion="cr 51 n57 - 87",
                  Ciudad="Bogotá"
                },
                SignosVitales=new Collection<SignoVital>(),
                HistorialMedico= new Historico{
                    Diagnostico="Bueno" 
                }*/
            };
            _repoPaciente.AddPaciente(paciente);
        }

    }
}
