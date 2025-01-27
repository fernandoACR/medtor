using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Repository
{
    public interface IConfiguracionMedicoRepository
    {
        int AddConfiguracionMedico(ConfiguracionMedico configuracionConfiguracionMedico);
        bool UpdateConfiguracionMedico(ConfiguracionMedico configuracionConfiguracionMedico);
        List<ConfiguracionMedicoModel> GetAllConfiguracionMedicos();
        ConfiguracionMedicoModel GetConfiguracionMedicoById(ConfiguracionMedicoModel configuracionConfiguracionMedico);
        List<ConfiguracionMedicoModel> GetConfiguracionMedicoByIdMedico(ConfiguracionMedicoModel configuracionMedico);
    }
}
