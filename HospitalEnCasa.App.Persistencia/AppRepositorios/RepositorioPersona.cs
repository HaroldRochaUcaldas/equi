using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalEnCasa.App.Dominio.entidades;

namespace HospitalEnCasa.App.Persistencia.AppRepositorios
{
    public class RepositorioPersona:IRepositorioPersona
    {
        private readonly ApplicationContext _appContex;

        /// <summary>
        //description metodo constructor recibe un apptontex
        /// </summary>>
        /// <param name="appcontext">description</param>>
        public RepositorioPersona(ApplicationContext appContex)
        {
            _appContex = appContex;
        }

        public RepositorioPersona(){
            _appContex=new ApplicationContext();
        }


        public Persona AddPersona(Persona persona)
        {
            var personaAdicionado = _appContex.Personas.Add(persona);
            _appContex.SaveChanges();
            return personaAdicionado.Entity;
        }

        public Boolean DeletePersona(int idPersona)
        {
            var personaEncontrado = _appContex.Personas.FirstOrDefault(p => p.Id == idPersona);
            if (personaEncontrado == null)
            {
                return false;
            }
            else
            {
                _appContex.Personas.Remove(personaEncontrado);
                _appContex.SaveChanges();
                return true;
            }

        }

        public Persona GetPersona(int idPersona)
        {
            return _appContex.Personas.FirstOrDefault(p => p.Id == idPersona);
        }

        public IEnumerable<Persona> GetAllPersonas()
        {
            return _appContex.Personas;
        }

        public Persona UpdatePersona(Persona persona)
        {
            var personaEncontrado = _appContex.Personas.FirstOrDefault(p => p.Id == persona.Id);
            if (personaEncontrado == null)
            {
                personaEncontrado=persona;
/*                personaEncontrado.Name = persona.Name;
                personaEncontrado.Description = persona.Description;*/               
                _appContex.SaveChanges();
                return personaEncontrado;
            }
            else
            {
                return personaEncontrado;
            }
        }
    }
}