using ControlMedicoApi.Models;
using ControlMedicoApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Business
{
    public interface IDiagnosticoBusiness
    {
        int AddDiagnostico(DiagnosticoModel diagnostico);
        bool UpdateDiagnostico(DiagnosticoModel diagnostico);
        List<DiagnosticoModel> GetAllDiagnosticos();
        DiagnosticoModel GetDiagnosticoById(DiagnosticoModel diagnostico);
        List<DiagnosticoModel> GetDiagnosticoByIdMedico(DiagnosticoModel diagnostico);
        List<DiagnosticoModel> GetDiagnosticoByIdPaciente(DiagnosticoModel diagnostico);
    }
}
