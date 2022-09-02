using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalEnCasa.App.Dominio.entidades
{
    public class Persona
    {
       public int Id {get;set;}
       public string Nombre{get;set;}
       public int NumeroTelefonico{get;set;}
      public int IdGenero{get;set;}
       public Genero SuGenero{get;set;}
    }
}