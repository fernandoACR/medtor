using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Repository
{
    public interface IConfiguracionReporteRepository
    {
        int AddConfiguracionReporte(ConfiguracionReporte configuracionConfiguracionReporte);
        bool UpdateConfiguracionReporte(ConfiguracionReporte configuracionReporte);
        List<ConfiguracionReporteModel> GetAllConfiguracionReportes();
        ConfiguracionReporteModel GetConfiguracionReporteById(ConfiguracionReporteModel configuracionConfiguracionReporte);
        List<ConfiguracionReporteModel> GetConfiguracionReporteByIdMedico(ConfiguracionReporteModel configuracionReporte);
    }
}
