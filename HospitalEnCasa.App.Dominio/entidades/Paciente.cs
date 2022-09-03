using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalEnCasa.App.Dominio.entidades
{
    public class Paciente:Persona
    {
        public Paciente(DateTime F,string Docu,string TD,Enfermero Enfe){
          FechaDeNacimiento=F;
          Documento=Docu;
          TipoDeDocumento=TD;
          SuEnfermero=Enfe;
        }
        public Paciente(){
            
        }
        public DateTime FechaDeNacimiento{get;set;}
        public string Documento{get;set;}
        public string TipoDeDocumento{get;set;}
        public ICollection<Medico> SusMedicos{get;set;}
        public Enfermero SuEnfermero{get;set;}
        public FamiliarDesignado SuFamiliarDesinado {get;set;}
        public Hogar SuHogar {get;set;}
        public ICollection<SignoVital> SignosVitales{get;set;}
        public Historico HistorialMedico{get;set;}
        
    }
}