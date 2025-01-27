using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Repository
{
    public interface ITipoReporteVariableRepository
    {
        int AddTipoReporteVariable(TipoReporteVariable tipoReporteVariable);
        bool UpdateTipoReporteVariable(TipoReporteVariable tipoReporteVariable);
        List<TipoReporteVariableModel> GetAllTipoReporteVariables();
        TipoReporteVariableModel GetTipoReporteVariableById(TipoReporteVariableModel tipoReporteVariable);
        List<TipoReporteVariableModel> GetTipoReporteVariableByIdTipoReporte(TipoReporteVariableModel tipoReporteVariable);
    }
}
