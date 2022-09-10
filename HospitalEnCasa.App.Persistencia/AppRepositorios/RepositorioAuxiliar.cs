using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalEnCasa.App.Dominio.entidades;

namespace HospitalEnCasa.App.Persistencia.AppRepositorios
{
    public class RepositorioAuxiliar:IRepositorioAuxiliar
    {
                private readonly ApplicationContext  _appContex=new ApplicationContext();

        /// <summary>
        //description metodo constructor recibe un apptontex
        /// </summary>>
        /// <param name="appcontext">description</param>>
        public RepositorioAuxiliar(ApplicationContext appContex)
        {
            _appContex = appContex;
        }

        public RepositorioAuxiliar(){
            _appContex=new ApplicationContext();
        }
        public Auxiliar AddAuxiliar(Auxiliar auxiliar)
        {
            var auxiliarAdicionado = _appContex.Auxiliares.Add(auxiliar);
            _appContex.SaveChanges();
            return auxiliarAdicionado.Entity;
        }

        public Boolean DeleteAuxiliar(int idAuxiliar)
        {
            var auxiliarEncontrado = _appContex.Auxiliares.FirstOrDefault(p => p.Id == idAuxiliar);
            if (auxiliarEncontrado == null)
            {
                return false;
            }
            else
            {
                _appContex.Auxiliares.Remove(auxiliarEncontrado);
                _appContex.SaveChanges();
                return true;
            }

        }

        public Auxiliar GetAuxiliar(int idAuxiliar)
        {
            return _appContex.Auxiliares.FirstOrDefault(p => p.Id == idAuxiliar);
        }

        public IEnumerable<Auxiliar> GetAllAuxiliares()
        {
            return _appContex.Auxiliares;
        }

        public Auxiliar UpdateAuxiliar(Auxiliar auxiliar)
        {
            var auxiliarEncontrado = _appContex.Auxiliares.FirstOrDefault(p => p.Id == auxiliar.Id);
            if (auxiliarEncontrado == null)
            {
                auxiliarEncontrado=auxiliar;
/*                auxiliarEncontrado.Name = auxiliar.Name;
                auxiliarEncontrado.Description = auxiliar.Description;*/               
                _appContex.SaveChanges();
                return auxiliarEncontrado;
            }
            else
            {
                return auxiliarEncontrado;
            }
        }
    }
}