using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Business
{
    public interface IPacienteBusiness
    {
        int AddPaciente(PacienteModel paciente);
        bool UpdatePaciente(PacienteModel paciente);
        List<PacienteModel> GetAllPacientes();
        PacienteModel GetPacienteById(PacienteModel paciente);
        List<PacienteModel> GetPacienteByIdMedico(PacienteModel paciente);
        int DeletePaciente(PacienteModel paciente);
    }
}
