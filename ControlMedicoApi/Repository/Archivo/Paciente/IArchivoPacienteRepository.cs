using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Repository
{
    public interface IArchivoPacienteRepository
    {
        int AddArchivoPaciente(ArchivoPaciente archivoPaciente);
        bool UpdateArchivoPaciente(ArchivoPaciente archivoPaciente);
        List<ArchivoPacienteModel> GetAllArchivoPacientes();
        ArchivoPacienteModel GetArchivoPacienteById(ArchivoPacienteModel archivoPaciente);
        ArchivoPacienteModel GetArchivoPacienteByIdPaciente(ArchivoPacienteModel archivoPaciente);
    }
}
