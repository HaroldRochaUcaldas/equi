using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalEnCasa.App.Dominio.entidades;

namespace HospitalEnCasa.App.Persistencia.AppRepositorios
{
    public interface IRepositorioSugerenciaDeCuidado
    {
         IEnumerable<SugerenciaDeCuidado> GetAllSugerenciaDeCuidados();
        SugerenciaDeCuidado AddSugerenciaDeCuidado(SugerenciaDeCuidado sugerenciaDeCuidado);
        SugerenciaDeCuidado UpdateSugerenciaDeCuidado(SugerenciaDeCuidado sugerenciaDeCuidado);
        Boolean DeleteSugerenciaDeCuidado(int idSugerenciaDeCuidado);
        SugerenciaDeCuidado GetSugerenciaDeCuidado(int idSugerenciaDeCuidado); 
    }
}