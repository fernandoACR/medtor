using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Repository
{
    public interface IDiagnosticoRepository
    {
        int AddDiagnostico(Diagnostico diagnostico);
        bool UpdateDiagnostico(Diagnostico diagnostico);
        List<DiagnosticoModel> GetAllDiagnosticos();
        DiagnosticoModel GetDiagnosticoById(DiagnosticoModel diagnostico);
        List<DiagnosticoModel> GetDiagnosticoByIdMedico(DiagnosticoModel diagnostico);
        List<DiagnosticoModel> GetDiagnosticoByIdPaciente(DiagnosticoModel diagnostico);
    }
}
