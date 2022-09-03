using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalEnCasa.App.Dominio.entidades;

namespace HospitalEnCasa.App.Persistencia.AppRepositorios
{
    public interface IRepositorioAuxiliar
    {
         IEnumerable<Auxiliar> GetAllAuxiliares();
        Auxiliar AddAuxiliar(Auxiliar auxiliar);
        Auxiliar UpdateAuxiliar(Auxiliar auxiliar);
        Boolean DeleteAuxiliar(int idAuxiliar);
        Auxiliar GetAuxiliar(int idAuxiliar); 
    }
}