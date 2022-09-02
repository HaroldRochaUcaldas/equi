using System;
using System.Collections.Generic;
using HospitalEnCasa.App.Dominio.entidades;
namespace HospiEnCasa.App.Persistencia
{
    public interface IRepositorioPaciente
    {
        IEnumerable<Paciente> GetAllPacientes();
        Paciente AddPaciente(Paciente paciente);
        Paciente UpdatePaciente(Paciente paciente);
        Boolean DeletePaciente(int idPaciente);
        Paciente GetPaciente(int idPaciente); 

    }

}