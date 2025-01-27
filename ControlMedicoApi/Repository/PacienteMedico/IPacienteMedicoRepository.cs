using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Repository
{
    public interface IPacienteMedicoRepository
    {
        int AddPacienteMedico(PacienteMedico pacienteMedico);
        bool UpdatePacienteMedico(PacienteMedico pacienteMedico);
        List<PacienteMedicoModel> GetAllPacienteMedicos();
        PacienteMedicoModel GetPacienteMedicoById(PacienteMedicoModel pacienteMedico);
        List<PacienteModel> GetPacienteByIdMedico(MedicoModel medico);
    }
}
