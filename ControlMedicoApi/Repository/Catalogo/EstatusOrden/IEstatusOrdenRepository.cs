using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Repository
{
    public interface IEstatusOrdenRepository
    {
        int AddEstatusOrden(EstatusOrden estatusOrden);
        bool UpdateEstatusOrden(EstatusOrden estatusOrden);
        List<EstatusOrdenModel> GetAllEstatusOrdens();
        EstatusOrdenModel GetEstatusOrdenById(EstatusOrdenModel estatusOrden);
    }
}
