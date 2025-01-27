using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Repository
{
    public interface ITipoArchivoRepository
    {
        int AddTipoArchivo(TipoArchivo tipoArchivo);
        bool UpdateTipoArchivo(TipoArchivo tipoArchivo);
        List<TipoArchivoModel> GetAllTipoArchivos();
        TipoArchivoModel GetTipoArchivoById(TipoArchivoModel tipoArchivo);
    }
}
