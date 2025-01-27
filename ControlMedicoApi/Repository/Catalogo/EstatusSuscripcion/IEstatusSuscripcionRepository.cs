using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Repository
{
    public interface IEstatusSuscripcionRepository
    {
        int AddEstatusSuscripcion(EstatusSuscripcion estatusSuscripcion);
        bool UpdateEstatusSuscripcion(EstatusSuscripcion estatusSuscripcion);
        List<EstatusSuscripcionModel> GetAllEstatusSuscripciones();
        EstatusSuscripcionModel GetEstatusSuscripcionById(EstatusSuscripcionModel estatusSuscripcion);
    }
}
