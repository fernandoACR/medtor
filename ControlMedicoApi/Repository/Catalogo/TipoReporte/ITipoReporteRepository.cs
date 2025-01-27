using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Repository
{
    public interface ITipoReporteRepository
    {
        int AddTipoReporte(TipoReporte tipoReporte);
        bool UpdateTipoReporte(TipoReporte tipoReporte);
        List<TipoReporteModel> GetAllTipoReportes();
        TipoReporteModel GetTipoReporteById(TipoReporteModel tipoReporte);
    }
}
