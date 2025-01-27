using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Repository
{
    public interface ISuscripcionRepository
    {
        int AddSuscripcion(Suscripcion suscripcion);
        bool UpdateSuscripcion(Suscripcion suscripcion);
        List<SuscripcionModel> GetAllSuscripcions();
        SuscripcionModel GetSuscripcionById(SuscripcionModel suscripcion);
        SuscripcionModel GetSuscripcionByIdCliente(SuscripcionModel suscripcion);
    }
}
