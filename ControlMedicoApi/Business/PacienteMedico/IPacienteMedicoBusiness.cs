using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Business
{
    public interface IPacienteMedicoBusiness
    {
        int AddPacienteMedico(PacienteMedicoModel pacienteMedico);
        bool UpdatePacienteMedico(PacienteMedicoModel pacienteMedico);
        List<PacienteMedicoModel> GetAllPacienteMedicos();
        PacienteMedicoModel GetPacienteMedicoById(PacienteMedicoModel pacienteMedico);
        List<PacienteModel> GetPacienteByIdMedico(MedicoModel medico);
    }
}
