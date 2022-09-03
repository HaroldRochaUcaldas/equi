//using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalEnCasa.App.Dominio.entidades
{
    public class Historico
    {
        public int Id{get;set;}
        public int IdPaciente{get;set;}
        public Paciente ElPaciente{get;set;}
        public string Diagnostico {get;set;}
        public string Entorno{get;set;}
        public ICollection<SugerenciaDeCuidado> SugerenciasDeCuidados{get;set;}
    }
}