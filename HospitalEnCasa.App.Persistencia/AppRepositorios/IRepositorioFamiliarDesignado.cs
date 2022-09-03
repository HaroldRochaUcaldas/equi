using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalEnCasa.App.Dominio.entidades;

namespace HospitalEnCasa.App.Persistencia.AppRepositorios
{
    public interface IRepositorioFamiliarDesignado
    {
         IEnumerable<FamiliarDesignado> GetAllFamiliarDesignados();
        FamiliarDesignado AddFamiliarDesignado(FamiliarDesignado familiarDesignado);
        FamiliarDesignado UpdateFamiliarDesignado(FamiliarDesignado familiarDesignado);
        Boolean DeleteFamiliarDesignado(int idFamiliarDesignado);
        FamiliarDesignado GetFamiliarDesignado(int idFamiliarDesignado); 
    }
}