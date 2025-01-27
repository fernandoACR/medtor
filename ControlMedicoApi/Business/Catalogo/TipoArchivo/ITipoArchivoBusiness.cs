using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Business
{
    public interface ITipoArchivoBusiness
    {
        int AddTipoArchivo(TipoArchivoModel tipoArchivo);
        bool UpdateTipoArchivo(TipoArchivoModel tipoArchivo);
        List<TipoArchivoModel> GetAllTipoArchivos();
        TipoArchivoModel GetTipoArchivoById(TipoArchivoModel tipoArchivo);
    }
}
