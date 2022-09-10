using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalEnCasa.App.Dominio.entidades;

namespace HospitalEnCasa.App.Persistencia.AppRepositorios
{
    public class RepositorioSignoVital:IRepositorioSingoVital
    {
        private readonly ApplicationContext _appContex;

        /// <summary>
        //description metodo constructor recibe un apptontex
        /// </summary>>
        /// <param name="appcontext">description</param>>
        public RepositorioSignoVital(ApplicationContext appContex)
        {
            _appContex = appContex;
        }

        public SignoVital AddSignoVital(SignoVital signoVital)
        {
            var signoVitalAdicionado = _appContex.SignoVitals.Add(signoVital);
            _appContex.SaveChanges();
            return signoVitalAdicionado.Entity;
        }

        public Boolean DeleteSignoVital(int idSignoVital)
        {
            var signoVitalEncontrado = _appContex.SignoVitals.FirstOrDefault(p => p.Id == idSignoVital);
            if (signoVitalEncontrado == null)
            {
                return false;
            }
            else
            {
                _appContex.SignoVitals.Remove(signoVitalEncontrado);
                _appContex.SaveChanges();
                return true;
            }

        }

        public SignoVital GetSignoVital(int idSignoVital)
        {
            return _appContex.SignoVitals.FirstOrDefault(p => p.Id == idSignoVital);
        }

        public IEnumerable<SignoVital> GetAllSignoVitals()
        {
            return _appContex.SignoVitals;
        }

        public SignoVital UpdateSignoVital(SignoVital signoVital)
        {
            var signoVitalEncontrado = _appContex.SignoVitals.FirstOrDefault(p => p.Id == signoVital.Id);
            if (signoVitalEncontrado == null)
            {
                signoVitalEncontrado=signoVital;
/*                signoVitalEncontrado.Name = signoVital.Name;
                signoVitalEncontrado.Description = signoVital.Description;*/               
                _appContex.SaveChanges();
                return signoVitalEncontrado;
            }
            else
            {
                return signoVitalEncontrado;
            }
        }
    }
}