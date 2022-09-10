using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalEnCasa.App.Dominio.entidades;

namespace HospitalEnCasa.App.Persistencia.AppRepositorios
{
    public class RepositorioMedico:IRepositorioMedico
    {
        private readonly ApplicationContext _appContex;

        /// <summary>
        //description metodo constructor recibe un apptontex
        /// </summary>>
        /// <param name="appcontext">description</param>>
        public RepositorioMedico(ApplicationContext appContex)
        {
            _appContex = appContex;
        }

        public RepositorioMedico(){
            _appContex=new ApplicationContext();
        }

        public Medico AddMedico(Medico medico)
        {
            var medicoAdicionado = _appContex.Medicos.Add(medico);
            _appContex.SaveChanges();
            return medicoAdicionado.Entity;
        }

        public Boolean DeleteMedico(int idMedico)
        {
            var medicoEncontrado = _appContex.Medicos.FirstOrDefault(p => p.Id == idMedico);
            if (medicoEncontrado == null)
            {
                return false;
            }
            else
            {
                _appContex.Medicos.Remove(medicoEncontrado);
                _appContex.SaveChanges();
                return true;
            }

        }

        public Medico GetMedico(int idMedico)
        {
            return _appContex.Medicos.FirstOrDefault(p => p.Id == idMedico);
        }

        public IEnumerable<Medico> GetAllMedicos()
        {
            return _appContex.Medicos;
        }

        public Medico UpdateMedico(Medico medico)
        {
            var medicoEncontrado = _appContex.Medicos.FirstOrDefault(p => p.Id == medico.Id);
            if (medicoEncontrado == null)
            {
                medicoEncontrado=medico;
/*                medicoEncontrado.Name = medico.Name;
                medicoEncontrado.Description = medico.Description;*/               
                _appContex.SaveChanges();
                return medicoEncontrado;
            }
            else
            {
                return medicoEncontrado;
            }
        }
    }
}