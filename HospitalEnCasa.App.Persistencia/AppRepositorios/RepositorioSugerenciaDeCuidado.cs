using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalEnCasa.App.Dominio.entidades;

namespace HospitalEnCasa.App.Persistencia.AppRepositorios
{
    public class RepositorioSugerenciaDeCuidado
    {
        private readonly ApplicationContext _appContex;

        /// <summary>
        //description metodo constructor recibe un apptontex
        /// </summary>>
        /// <param name="appcontext">description</param>>
        public RepositorioSugerenciaDeCuidado(ApplicationContext appContex)
        {
            _appContex = appContex;
        }

        public SugerenciaDeCuidado AddSugerenciaDeCuidado(SugerenciaDeCuidado sugerenciaDeCuidado)
        {
            var sugerenciaDeCuidadoAdicionado = _appContex.SugerenciaDeCuidados.Add(sugerenciaDeCuidado);
            _appContex.SaveChanges();
            return sugerenciaDeCuidadoAdicionado.Entity;
        }

        public Boolean DeleteSugerenciaDeCuidado(int idSugerenciaDeCuidado)
        {
            var sugerenciaDeCuidadoEncontrado = _appContex.SugerenciaDeCuidados.FirstOrDefault(p => p.Id == idSugerenciaDeCuidado);
            if (sugerenciaDeCuidadoEncontrado == null)
            {
                return false;
            }
            else
            {
                _appContex.SugerenciaDeCuidados.Remove(sugerenciaDeCuidadoEncontrado);
                _appContex.SaveChanges();
                return true;
            }

        }

        public SugerenciaDeCuidado GetSugerenciaDeCuidado(int idSugerenciaDeCuidado)
        {
            return _appContex.SugerenciaDeCuidados.FirstOrDefault(p => p.Id == idSugerenciaDeCuidado);
        }

        public IEnumerable<SugerenciaDeCuidado> GetAllSugerenciaDeCuidados()
        {
            return _appContex.SugerenciaDeCuidados;
        }

        public SugerenciaDeCuidado UpdateSugerenciaDeCuidado(SugerenciaDeCuidado sugerenciaDeCuidado)
        {
            var sugerenciaDeCuidadoEncontrado = _appContex.SugerenciaDeCuidados.FirstOrDefault(p => p.Id == sugerenciaDeCuidado.Id);
            if (sugerenciaDeCuidadoEncontrado == null)
            {
                sugerenciaDeCuidadoEncontrado=sugerenciaDeCuidado;
/*                sugerenciaDeCuidadoEncontrado.Name = sugerenciaDeCuidado.Name;
                sugerenciaDeCuidadoEncontrado.Description = sugerenciaDeCuidado.Description;*/               
                _appContex.SaveChanges();
                return sugerenciaDeCuidadoEncontrado;
            }
            else
            {
                return sugerenciaDeCuidadoEncontrado;
            }
        }
    }
}