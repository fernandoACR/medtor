using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Business
{
    public interface IConfiguracionMedicoBusiness
    {
        int AddConfiguracionMedico(ConfiguracionMedicoModel configuracionConfiguracionMedico);
        bool UpdateConfiguracionMedico(List<ConfiguracionMedicoModel> configuracionConfiguracionMedico);
        List<ConfiguracionMedicoModel> GetAllConfiguracionMedicos();
        ConfiguracionMedicoModel GetConfiguracionMedicoById(ConfiguracionMedicoModel configuracionConfiguracionMedico);
        List<ConfiguracionMedicoModel> GetConfiguracionMedicoByIdMedico(ConfiguracionMedicoModel configuracionConfiguracionMedico);
    }
}
