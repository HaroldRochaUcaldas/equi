using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalEnCasa.App.Persistencia.AppRepositorios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using HospitalEnCasa.App.Dominio.entidades;
namespace HospitalEnCasa.App.Frontend.Pages.PacientesPages
{
    public class Detalles : PageModel
    {
        private readonly ILogger<Detalles> _logger;
        public Paciente elPaciente{get;set;}
        public IRepositorioPaciente Repo_paciente { get; set;}

        public Detalles(IRepositorioPaciente repo_paciente)
        {
            this.Repo_paciente=repo_paciente;
        }

        public IActionResult OnGet(int PacienteId)
        {
           elPaciente=this.Repo_paciente.GetPaciente(PacienteId);
           if(elPaciente==null){
              return RedirectToPage("/.NotFound");
           }else{
            return Page();
           }
        }
    }
}