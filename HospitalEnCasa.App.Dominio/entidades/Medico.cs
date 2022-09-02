using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalEnCasa.App.Dominio.entidades
{
    public class Medico:PersonalDeSalud
    {
        public string Especialidad{get;set;}
        public string Codigo{get;set;}
        public ICollection<Paciente> Pacientes{get;set;}
    }
}