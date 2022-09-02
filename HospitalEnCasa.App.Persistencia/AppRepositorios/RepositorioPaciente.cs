using System;
using System.Collections.Generic;
using HospitalEnCasa.App.Dominio.entidades;
using System.Linq;

namespace HospiEnCasa.App.Persistencia
{

    public class RepositorioPaciente : IRepositorioPaciente
    {
        /*
                private readonly AppContext _appContex;

                /// <summary>
                //description metodo constructor recibe un apptontex
                /// </summary>>
                /// <param name="appcontext">description</param>>
                public RepositorioPaciente(AppContext appContex)
                {
                    _appContex = appContex;
                }

                public Paciente AddPaciente(Paciente paciente)
                {
                    var pacienteAdicionado = _appContex.Pacientes.Add(paciente);
                    _appContex.SaveChanges();
                    return pacienteAdicionado.Entity;
                }

                public Boolean DeletePaciente(int idPaciente)
                {
                    var pacienteEncontrado = _appContex.Pacientes.FirstOrDefault(p => p.Id == idPaciente);
                    if (pacienteEncontrado == null)
                    {
                        return false;
                    }
                    else
                    {
                        _appContex.Pacientes.Remove(pacienteEncontrado);
                        _appContex.SaveChanges();
                        return true;
                    }

                }

                public Paciente GetPaciente(int idPaciente)
                {
                    Paciente pacienteretornado = _appContex.Pacientes.FirstOrDefault(p => p.Id == idPaciente);
                    if (pacienteretornado.genero == null)
                    {
                     pacienteretornado.genero=_appContex.Generos.FirstOrDefault(p => p.Id == pacienteretornado.genero_id);
                    }
                    return _appContex.Pacientes.FirstOrDefault(p => p.Id == idPaciente);
                }

                public IEnumerable<Paciente> GetAllPacientes()
                {
                    return _appContex.Pacientes;
                }

                public Paciente UpdatePaciente(Paciente paciente)
                {
                    var pacienteEncontrado = _appContex.Pacientes.FirstOrDefault(p => p.id == paciente.id);
                    if (pacienteEncontrado == null)
                    {
                        pacienteEncontrado.nombres = paciente.nombres;
                        pacienteEncontrado.apellidos = paciente.apellidos;
                        pacienteEncontrado.numeroTelefeno = paciente.numeroTelefeno;
                        pacienteEncontrado.genero_id = paciente.genero_id;
                        // pacienteEncontrado.genero=paciente.genero;
                        pacienteEncontrado.direccion = paciente.direccion;
                        pacienteEncontrado.latitud = paciente.latitud;
                        pacienteEncontrado.longitud = paciente.longitud;
                        pacienteEncontrado.ciudad = paciente.ciudad;
                        pacienteEncontrado.fechaNacimiento = paciente.fechaNacimiento;
                        _appContex.SaveChanges();
                        return pacienteEncontrado;
                    }
                    else
                    {
                        return pacienteEncontrado;
                    }
                }*/
        public Paciente AddPaciente(Paciente paciente)
        {
            throw new NotImplementedException();
        }

        public bool DeletePaciente(int idPaciente)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Paciente> GetAllPacientes()
        {
            throw new NotImplementedException();
        }

        public Paciente GetPaciente(int idPaciente)
        {
            throw new NotImplementedException();
        }

        public Paciente UpdatePaciente(Paciente paciente)
        {
            throw new NotImplementedException();
        }
    }
}