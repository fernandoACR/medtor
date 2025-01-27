using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Business
{
    public interface IMedicoBusiness
    {
        int AddMedico(MedicoModel medico);
        bool UpdateMedico(MedicoModel medico);
        List<MedicoModel> GetAllMedicos();
        MedicoModel GetMedicoById(MedicoModel medico);
        List<MedicoModel> GetMedicoByIdSuscripcion(MedicoModel medico);
    }
}
