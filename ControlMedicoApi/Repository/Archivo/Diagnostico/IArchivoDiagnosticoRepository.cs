using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Repository
{
    public interface IArchivoDiagnosticoRepository
    {
        int AddArchivoDiagnostico(ArchivoDiagnostico archivoDiagnostico);
        bool UpdateArchivoDiagnostico(ArchivoDiagnostico archivoDiagnostico);
        List<ArchivoDiagnosticoModel> GetAllArchivoDiagnosticos();
        ArchivoDiagnosticoModel GetArchivoDiagnosticoById(ArchivoDiagnosticoModel archivoDiagnostico);
        List<ArchivoDiagnosticoModel> GetArchivoDiagnosticoByIdDiagnostico(ArchivoDiagnosticoModel archivoDiagnostico);
        int DeleteArchivoDiagnostico(ArchivoDiagnostico archivoDiagnostico);
    }
}
