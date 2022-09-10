using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalEnCasa.App.Dominio.entidades;

namespace HospitalEnCasa.App.Persistencia.AppRepositorios
{
    public class RepositorioHistorico:IRepositorioHistorico
    {
        private readonly ApplicationContext _appContex;

        /// <summary>
        //description metodo constructor recibe un apptontex
        /// </summary>>
        /// <param name="appcontext">description</param>>
        public RepositorioHistorico(ApplicationContext appContex)
        {
            _appContex = appContex;
        }

        public RepositorioHistorico(){
            _appContex=new ApplicationContext();
        }

        public Historico AddHistorico(Historico historico)
        {
            var historicoAdicionado = _appContex.Historicos.Add(historico);
            _appContex.SaveChanges();
            return historicoAdicionado.Entity;
        }

        public Boolean DeleteHistorico(int idHistorico)
        {
            var historicoEncontrado = _appContex.Historicos.FirstOrDefault(p => p.Id == idHistorico);
            if (historicoEncontrado == null)
            {
                return false;
            }
            else
            {
                _appContex.Historicos.Remove(historicoEncontrado);
                _appContex.SaveChanges();
                return true;
            }

        }

        public Historico GetHistorico(int idHistorico)
        {
            return _appContex.Historicos.FirstOrDefault(p => p.Id == idHistorico);
        }

        public IEnumerable<Historico> GetAllHistoricos()
        {
            return _appContex.Historicos;
        }

        public Historico UpdateHistorico(Historico historico)
        {
            var historicoEncontrado = _appContex.Historicos.FirstOrDefault(p => p.Id == historico.Id);
            if (historicoEncontrado == null)
            {
                historicoEncontrado=historico;
/*                historicoEncontrado.Name = historico.Name;
                historicoEncontrado.Description = historico.Description;*/               
                _appContex.SaveChanges();
                return historicoEncontrado;
            }
            else
            {
                return historicoEncontrado;
            }
        }
    }
}