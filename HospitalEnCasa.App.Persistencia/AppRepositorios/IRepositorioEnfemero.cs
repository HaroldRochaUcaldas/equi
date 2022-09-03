using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalEnCasa.App.Dominio.entidades;

namespace HospitalEnCasa.App.Persistencia.AppRepositorios
{
    public interface IRepositorioEnfemero
    {
         IEnumerable<Enfermero> GetAllEnfermeros();
        Enfermero AddEnfermero(Enfermero enfermero);
        Enfermero UpdateEnfermero(Enfermero enfermero);
        Boolean DeleteEnfermero(int idEnfermero);
        Enfermero GetEnfermero(int idEnfermero); 
    }
}