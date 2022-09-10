using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalEnCasa.App.Dominio.entidades;

namespace HospitalEnCasa.App.Persistencia.AppRepositorios
{
    public class RepositorioHogar:IRepositorioHogar
    {
        private readonly ApplicationContext _appContex;

        /// <summary>
        //description metodo constructor recibe un apptontex
        /// </summary>>
        /// <param name="appcontext">description</param>>
        public RepositorioHogar(ApplicationContext appContex)
        {
            _appContex = appContex;
        }

        public RepositorioHogar(){
            _appContex=new ApplicationContext();
        }


        public Hogar AddHogar(Hogar hogar)
        {
            var hogarAdicionado = _appContex.Hogars.Add(hogar);
            _appContex.SaveChanges();
            return hogarAdicionado.Entity;
        }

        public Boolean DeleteHogar(int idHogar)
        {
            var hogarEncontrado = _appContex.Hogars.FirstOrDefault(p => p.Id == idHogar);
            if (hogarEncontrado == null)
            {
                return false;
            }
            else
            {
                _appContex.Hogars.Remove(hogarEncontrado);
                _appContex.SaveChanges();
                return true;
            }

        }

        public Hogar GetHogar(int idHogar)
        {
            return _appContex.Hogars.FirstOrDefault(p => p.Id == idHogar);
        }

        public IEnumerable<Hogar> GetAllHogars()
        {
            return _appContex.Hogars;
        }

        public Hogar UpdateHogar(Hogar hogar)
        {
            var hogarEncontrado = _appContex.Hogars.FirstOrDefault(p => p.Id == hogar.Id);
            if (hogarEncontrado == null)
            {
                hogarEncontrado=hogar;
/*                hogarEncontrado.Name = hogar.Name;
                hogarEncontrado.Description = hogar.Description;*/               
                _appContex.SaveChanges();
                return hogarEncontrado;
            }
            else
            {
                return hogarEncontrado;
            }
        }
    }
}