using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalEnCasa.App.Dominio.entidades;

namespace HospitalEnCasa.App.Persistencia.AppRepositorios
{
    public class RepositorioEnfermero:IRepositorioEnfemero
    {
        private readonly ApplicationContext _appContex;

        /// <summary>
        //description metodo constructor recibe un apptontex
        /// </summary>>
        /// <param name="appcontext">description</param>>
        public RepositorioEnfermero(ApplicationContext appContex)
        {
            _appContex = appContex;
        }
        public RepositorioEnfermero(){
             _appContex=new ApplicationContext();
        }



        public Enfermero AddEnfermero(Enfermero enfermero)
        {
            var enfermeroAdicionado = _appContex.Enfermeros.Add(enfermero);
            _appContex.SaveChanges();
            return enfermeroAdicionado.Entity;
        }

        public Boolean DeleteEnfermero(int idEnfermero)
        {
            var enfermeroEncontrado = _appContex.Enfermeros.FirstOrDefault(p => p.Id == idEnfermero);
            if (enfermeroEncontrado == null)
            {
                return false;
            }
            else
            {
                _appContex.Enfermeros.Remove(enfermeroEncontrado);
                _appContex.SaveChanges();
                return true;
            }

        }

        public Enfermero GetEnfermero(int idEnfermero)
        {
            return _appContex.Enfermeros.FirstOrDefault(p => p.Id == idEnfermero);
        }

        public IEnumerable<Enfermero> GetAllEnfermeros()
        {
            return _appContex.Enfermeros;
        }

        public Enfermero UpdateEnfermero(Enfermero enfermero)
        {
            var enfermeroEncontrado = _appContex.Enfermeros.FirstOrDefault(p => p.Id == enfermero.Id);
            if (enfermeroEncontrado == null)
            {
                enfermeroEncontrado=enfermero;
/*                enfermeroEncontrado.Name = enfermero.Name;
                enfermeroEncontrado.Description = enfermero.Description;*/               
                _appContex.SaveChanges();
                return enfermeroEncontrado;
            }
            else
            {
                return enfermeroEncontrado;
            }
        }
    }
}