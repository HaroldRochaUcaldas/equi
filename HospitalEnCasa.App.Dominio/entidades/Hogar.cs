using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalEnCasa.App.Dominio.entidades
{
    public class Hogar
    {
        public int Id {get;set;}
        public string Direccion{get;set;}
        public double Latirud{get;set;}
        public double Longitud{get;set;}
        public string Cidudad{get;set;}
        public int IdPaciente{get;set;}
        public Paciente ElPaciente{get;set;}
    }
}