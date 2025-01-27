using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Repository
{
    public interface IEscolaridadRepository
    {
        int AddEscolaridad(Escolaridad escolaridad);
        bool UpdateEscolaridad(Escolaridad escolaridad);
        List<EscolaridadModel> GetAllEscolaridades();
        EscolaridadModel GetEscolaridadById(EscolaridadModel escolaridad);
    }
}
