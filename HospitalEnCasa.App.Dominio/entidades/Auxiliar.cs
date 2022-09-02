using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalEnCasa.App.Dominio.entidades
{
    public class Auxiliar:Persona
    {
      //  int id {get;set;}
       public string Sucursal{get;set;}
       public Hospital SuHospital{get;set;}
    }
}