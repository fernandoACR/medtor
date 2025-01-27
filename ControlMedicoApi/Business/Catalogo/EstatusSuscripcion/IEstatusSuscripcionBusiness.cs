using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Business
{
    public interface IEstatusSuscripcionBusiness
    {
        int AddEstatusSuscripcion(EstatusSuscripcionModel estatusSuscripcion);
        bool UpdateEstatusSuscripcion(EstatusSuscripcionModel estatusSuscripcion);
        List<EstatusSuscripcionModel> GetAllEstatusSuscripciones();
        EstatusSuscripcionModel GetEstatusSuscripcionById(EstatusSuscripcionModel estatusSuscripcion);
    }
}
