using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalEnCasa.App.Dominio.entidades;

namespace HospitalEnCasa.App.Persistencia.AppRepositorios
{
    public interface IRepositorioHistorico
    {
         IEnumerable<Historico> GetAllHistoricos();
        Historico AddHistorico(Historico historico);
        Historico UpdateHistorico(Historico historico);
        Boolean DeleteHistorico(int idHistorico);
        Historico GetHistorico(int idHistorico); 
    }
}