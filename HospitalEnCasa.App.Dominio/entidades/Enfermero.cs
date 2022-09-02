using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalEnCasa.App.Dominio.entidades
{
    public class Enfermero:PersonalDeSalud
    {
       public string TarjetaProfesional{get;set;}
       public int HorasLaborales{get;set;}
       public ICollection<Paciente> Pacientes {get;set;}
    }
}