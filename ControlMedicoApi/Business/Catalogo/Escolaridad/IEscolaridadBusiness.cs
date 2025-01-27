using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Business
{
    public interface IEscolaridadBusiness
    {
        int AddEscolaridad(EscolaridadModel escolaridad);
        bool UpdateEscolaridad(EscolaridadModel escolaridad);
        List<EscolaridadModel> GetAllEscolaridades();
        EscolaridadModel GetEscolaridadById(EscolaridadModel escolaridad);
    }
}
