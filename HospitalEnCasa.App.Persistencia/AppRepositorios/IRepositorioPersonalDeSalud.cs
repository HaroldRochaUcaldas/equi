using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalEnCasa.App.Dominio.entidades;

namespace HospitalEnCasa.App.Persistencia.AppRepositorios
{
    public interface IRepositorioPersonalDeSalud
    {
         IEnumerable<PersonalDeSalud> GetAllPersonalDeSaluds();
        PersonalDeSalud AddPersonalDeSalud(PersonalDeSalud personalDeSalud);
        PersonalDeSalud UpdatePersonalDeSalud(PersonalDeSalud personalDeSalud);
        Boolean DeletePersonalDeSalud(int idPersonalDeSalud);
        PersonalDeSalud GetPersonalDeSalud(int idPersonalDeSalud); 
    }
}