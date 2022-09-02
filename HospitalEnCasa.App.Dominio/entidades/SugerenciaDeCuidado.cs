using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalEnCasa.App.Dominio.entidades
{
    public class SugerenciaDeCuidado
    {
        public int Id {get;set;}
        public DateTime FechayHora{get;set;}
        public string Descripcion{get;set;}
    }
}