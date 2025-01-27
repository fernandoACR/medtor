using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Business
{
    public interface IOcupacionBusiness
    {
        int AddOcupacion(OcupacionModel ocupacion);
        bool UpdateOcupacion(OcupacionModel ocupacion);
        List<OcupacionModel> GetAllOcupacions();
        OcupacionModel GetOcupacionById(OcupacionModel ocupacion);
    }
}
