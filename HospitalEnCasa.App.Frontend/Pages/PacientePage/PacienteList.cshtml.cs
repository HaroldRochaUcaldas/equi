using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using HospitalEnCasa.App.Persistencia.AppRepositorios;
using HospitalEnCasa.App.Dominio.entidades;
namespace HospitalEnCasa.App.Frontend.Pages
{
    public class PacienteListModel : PageModel
    {
        private readonly IRepositorioPaciente repo_paciente;

        public IEnumerable<Paciente> listaPaciente{get;set;}

        public PacienteListModel(IRepositorioPaciente repo_paciente)
        {
            this.repo_paciente=repo_paciente;
        }

        public void OnGet()
        {
           listaPaciente=repo_paciente.GetAllPacientes(); 
        }
    }
}
