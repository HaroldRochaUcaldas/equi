using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalEnCasa.App.Dominio.entidades;

namespace HospitalEnCasa.App.Persistencia.AppRepositorios
{
    public interface IRepositorioHogar
    {
         IEnumerable<Hogar> GetAllHogars();
        Hogar AddHogar(Hogar hogar);
        Hogar UpdateHogar(Hogar hogar);
        Boolean DeleteHogar(int idHogar);
        Hogar GetHogar(int idHogar); 
    }
}