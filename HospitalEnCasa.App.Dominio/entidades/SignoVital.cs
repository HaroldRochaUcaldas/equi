using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalEnCasa.App.Dominio.entidades
{
    public class SignoVital
    {
        public int Id {get;set;}
        public DateTime FechaYhora{get;set;}
        public string Signo{get;set;}
        public double Valor{get;set;}
        public Paciente ElPaciente {get;set;}
    }
}