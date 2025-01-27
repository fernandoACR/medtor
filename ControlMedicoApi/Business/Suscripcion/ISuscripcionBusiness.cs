using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Business
{
    public interface ISuscripcionBusiness
    {
        int AddSuscripcion(SuscripcionModel suscripcion);
        bool UpdateSuscripcion(SuscripcionModel suscripcion);
        List<SuscripcionModel> GetAllSuscripcions();
        SuscripcionModel GetSuscripcionById(SuscripcionModel suscripcion);
    }
}
