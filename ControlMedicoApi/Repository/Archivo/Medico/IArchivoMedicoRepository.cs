using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Repository
{
    public interface IArchivoMedicoRepository
    {
        int AddArchivoMedico(ArchivoMedico archivoMedico);
        bool UpdateArchivoMedico(ArchivoMedico archivoMedico);
        List<ArchivoMedicoModel> GetAllArchivoMedicos();
        ArchivoMedicoModel GetArchivoMedicoById(ArchivoMedicoModel archivoMedico);
        ArchivoMedicoModel GetArchivoMedicoByIdMedico(ArchivoMedicoModel archivoMedico);
    }
}
