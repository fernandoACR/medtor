using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Business
{
    public interface IConfiguracionReporteBusiness
    {
        int AddConfiguracionReporte(ConfiguracionReporteModel configuracionConfiguracionReporte);
        bool UpdateConfiguracionReporte(ConfiguracionReporteModel configuracionConfiguracionReporte);
        List<ConfiguracionReporteModel> GetAllConfiguracionReportes();
        ConfiguracionReporteModel GetConfiguracionReporteById(ConfiguracionReporteModel configuracionConfiguracionReporte);
        List<ConfiguracionReporteModel> GetConfiguracionReporteByIdMedico(ConfiguracionReporteModel configuracionConfiguracionReporte);
    }
}
