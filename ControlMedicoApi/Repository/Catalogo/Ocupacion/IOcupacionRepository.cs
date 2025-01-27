using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Repository
{
    public interface IOcupacionRepository
    {
        int AddOcupacion(Ocupacion ocupacion);
        bool UpdateOcupacion(Ocupacion ocupacion);
        List<OcupacionModel> GetAllOcupacions();
        OcupacionModel GetOcupacionById(OcupacionModel ocupacion);
    }
}
