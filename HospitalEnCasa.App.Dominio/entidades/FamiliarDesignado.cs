using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalEnCasa.App.Dominio.entidades
{
    public class FamiliarDesignado:Persona
    {
       public string Parentesco {get;set;}
       public string Correo{get;set;}
       public int IdFamiliar{get;set;}
       public Paciente SuFamiliar {get;set;}
    }
}