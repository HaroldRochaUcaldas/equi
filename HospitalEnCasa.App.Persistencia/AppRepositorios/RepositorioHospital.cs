using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalEnCasa.App.Dominio.entidades;

namespace HospitalEnCasa.App.Persistencia.AppRepositorios
{
    public class RepositorioHospital:IRepositorioHospital
    {
        private readonly ApplicationContext _appContex;

        /// <summary>
        //description metodo constructor recibe un apptontex
        /// </summary>>
        /// <param name="appcontext">description</param>>
        public RepositorioHospital(ApplicationContext appContex)
        {
            _appContex = appContex;
        }

        public Hospital AddHospital(Hospital hospital)
        {
            var hospitalAdicionado = _appContex.Hospitals.Add(hospital);
            _appContex.SaveChanges();
            return hospitalAdicionado.Entity;
        }

        public Boolean DeleteHospital(int idHospital)
        {
            var hospitalEncontrado = _appContex.Hospitals.FirstOrDefault(p => p.Id == idHospital);
            if (hospitalEncontrado == null)
            {
                return false;
            }
            else
            {
                _appContex.Hospitals.Remove(hospitalEncontrado);
                _appContex.SaveChanges();
                return true;
            }

        }

        public Hospital GetHospital(int idHospital)
        {
            return _appContex.Hospitals.FirstOrDefault(p => p.Id == idHospital);
        }

        public IEnumerable<Hospital> GetAllHospitals()
        {
            return _appContex.Hospitals;
        }

        public Hospital UpdateHospital(Hospital hospital)
        {
            var hospitalEncontrado = _appContex.Hospitals.FirstOrDefault(p => p.Id == hospital.Id);
            if (hospitalEncontrado == null)
            {
                hospitalEncontrado=hospital;
/*                hospitalEncontrado.Name = hospital.Name;
                hospitalEncontrado.Description = hospital.Description;*/               
                _appContex.SaveChanges();
                return hospitalEncontrado;
            }
            else
            {
                return hospitalEncontrado;
            }
        }
    }
}