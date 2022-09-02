using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalEnCasa.App.Dominio.entidades
{
    public class PersonalDeSalud:Persona
    {
        //int id {get;set;}
        public string Usuario{get;set;}
        public string Contraseña{get;set;}
        public Hospital SuHospital{get;set;}        
    }
}