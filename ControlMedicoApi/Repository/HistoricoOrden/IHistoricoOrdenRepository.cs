using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Repository
{
    public interface IHistoricoOrdenRepository
    {
        int AddHistoricoOrden(HistoricoOrden historicoOrden);
        bool UpdateHistoricoOrden(HistoricoOrden historicoOrden);
        List<HistoricoOrdenModel> GetAllHistoricoOrdens();
        HistoricoOrdenModel GetHistoricoOrdenById(HistoricoOrdenModel historicoOrden);
        List<HistoricoOrdenModel> GetHistoricoOrdensByIdOrden(HistoricoOrdenModel historicoOrden);
    }
}
