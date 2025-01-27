using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Repository
{
    public interface IPacienteRepository
    {
        int AddPaciente(Paciente paciente);
        bool UpdatePaciente(Paciente paciente);
        List<PacienteModel> GetAllPacientes();
        PacienteModel GetPacienteById(PacienteModel paciente);
        List<PacienteModel> GetPacienteByIdMedico(PacienteModel paciente);
        int DeletePaciente(Paciente paciente);
    }
}
