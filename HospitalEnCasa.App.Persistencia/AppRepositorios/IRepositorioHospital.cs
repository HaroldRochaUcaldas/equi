using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalEnCasa.App.Dominio.entidades;

namespace HospitalEnCasa.App.Persistencia.AppRepositorios
{
    public interface IRepositorioHospital
    {
         IEnumerable<Hospital> GetAllHospitals();
        Hospital AddHospital(Hospital hospital);
        Hospital UpdateHospital(Hospital hospital);
        Boolean DeleteHospital(int idHospital);
        Hospital GetHospital(int idHospital); 
    }
}