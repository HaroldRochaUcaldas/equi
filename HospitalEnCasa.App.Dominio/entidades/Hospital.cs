using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalEnCasa.App.Dominio.entidades
{
    public class Hospital
    {
        public int Id {get;set;}
        public string Nit {get;set;}
        public string Nombre {get;set;}
        public ICollection<PersonalDeSalud> ListaPersonalDeSalud {get;set;}
        public ICollection<Auxiliar> Auxiliares{get;set;}
    }
}