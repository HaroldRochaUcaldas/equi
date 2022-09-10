using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalEnCasa.App.Dominio.entidades;

namespace HospitalEnCasa.App.Persistencia.AppRepositorios
{
    public class RepositorioPersonalDeSalud:IRepositorioPersonalDeSalud
    {
        private readonly ApplicationContext _appContex;

        /// <summary>
        //description metodo constructor recibe un apptontex
        /// </summary>>
        /// <param name="appcontext">description</param>>
        public RepositorioPersonalDeSalud(ApplicationContext appContex)
        {
            _appContex = appContex;
        }
        public RepositorioPersonalDeSalud(){
            _appContex=new ApplicationContext();
        }



        public PersonalDeSalud AddPersonalDeSalud(PersonalDeSalud personalDeSalud)
        {
            var personalDeSaludAdicionado = _appContex.PersonalDeSaluds.Add(personalDeSalud);
            _appContex.SaveChanges();
            return personalDeSaludAdicionado.Entity;
        }

        public Boolean DeletePersonalDeSalud(int idPersonalDeSalud)
        {
            var personalDeSaludEncontrado = _appContex.PersonalDeSaluds.FirstOrDefault(p => p.Id == idPersonalDeSalud);
            if (personalDeSaludEncontrado == null)
            {
                return false;
            }
            else
            {
                _appContex.PersonalDeSaluds.Remove(personalDeSaludEncontrado);
                _appContex.SaveChanges();
                return true;
            }

        }

        public PersonalDeSalud GetPersonalDeSalud(int idPersonalDeSalud)
        {
            return _appContex.PersonalDeSaluds.FirstOrDefault(p => p.Id == idPersonalDeSalud);
        }

        public IEnumerable<PersonalDeSalud> GetAllPersonalDeSaluds()
        {
            return _appContex.PersonalDeSaluds;
        }

        public PersonalDeSalud UpdatePersonalDeSalud(PersonalDeSalud personalDeSalud)
        {
            var personalDeSaludEncontrado = _appContex.PersonalDeSaluds.FirstOrDefault(p => p.Id == personalDeSalud.Id);
            if (personalDeSaludEncontrado == null)
            {
                personalDeSaludEncontrado=personalDeSalud;
/*                personalDeSaludEncontrado.Name = personalDeSalud.Name;
                personalDeSaludEncontrado.Description = personalDeSalud.Description;*/               
                _appContex.SaveChanges();
                return personalDeSaludEncontrado;
            }
            else
            {
                return personalDeSaludEncontrado;
            }
        }
    }
}