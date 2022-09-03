using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalEnCasa.App.Dominio.entidades;

namespace HospitalEnCasa.App.Persistencia.AppRepositorios
{
    public interface IRepositorioSingoVital
    {
         IEnumerable<SignoVital> GetAllSignoVitals();
        SignoVital AddSignoVital(SignoVital signoVital);
        SignoVital UpdateSignoVital(SignoVital signoVital);
        Boolean DeleteSignoVital(int idSignoVital);
        SignoVital GetSignoVital(int idSignoVital); 
    }
}