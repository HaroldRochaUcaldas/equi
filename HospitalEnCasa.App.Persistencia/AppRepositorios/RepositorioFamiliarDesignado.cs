using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalEnCasa.App.Dominio.entidades;

namespace HospitalEnCasa.App.Persistencia.AppRepositorios
{
    public class RepositorioFamiliarDesignado
    {
        private readonly ApplicationContext _appContex;

        /// <summary>
        //description metodo constructor recibe un apptontex
        /// </summary>>
        /// <param name="appcontext">description</param>>
        public RepositorioFamiliarDesignado(ApplicationContext appContex)
        {
            _appContex = appContex;
        }

        public FamiliarDesignado AddFamiliarDesignado(FamiliarDesignado familiarDesignado)
        {
            var familiarDesignadoAdicionado = _appContex.FamiliarDesignados.Add(familiarDesignado);
            _appContex.SaveChanges();
            return familiarDesignadoAdicionado.Entity;
        }

        public Boolean DeleteFamiliarDesignado(int idFamiliarDesignado)
        {
            var familiarDesignadoEncontrado = _appContex.FamiliarDesignados.FirstOrDefault(p => p.Id == idFamiliarDesignado);
            if (familiarDesignadoEncontrado == null)
            {
                return false;
            }
            else
            {
                _appContex.FamiliarDesignados.Remove(familiarDesignadoEncontrado);
                _appContex.SaveChanges();
                return true;
            }

        }

        public FamiliarDesignado GetFamiliarDesignado(int idFamiliarDesignado)
        {
            return _appContex.FamiliarDesignados.FirstOrDefault(p => p.Id == idFamiliarDesignado);
        }

        public IEnumerable<FamiliarDesignado> GetAllFamiliarDesignados()
        {
            return _appContex.FamiliarDesignados;
        }

        public FamiliarDesignado UpdateFamiliarDesignado(FamiliarDesignado familiarDesignado)
        {
            var familiarDesignadoEncontrado = _appContex.FamiliarDesignados.FirstOrDefault(p => p.Id == familiarDesignado.Id);
            if (familiarDesignadoEncontrado == null)
            {
                familiarDesignadoEncontrado=familiarDesignado;
/*                familiarDesignadoEncontrado.Name = familiarDesignado.Name;
                familiarDesignadoEncontrado.Description = familiarDesignado.Description;*/               
                _appContex.SaveChanges();
                return familiarDesignadoEncontrado;
            }
            else
            {
                return familiarDesignadoEncontrado;
            }
        }
    }
}