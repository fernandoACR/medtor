using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Repository
{
    public interface IArchivoOrdenRepository
    {
        int AddArchivoOrden(ArchivoOrden archivoOrden);
        bool UpdateArchivoOrden(ArchivoOrden archivoOrden);
        List<ArchivoOrdenModel> GetAllArchivoOrdens();
        ArchivoOrdenModel GetArchivoOrdenById(ArchivoOrdenModel archivoOrden);
        List<ArchivoOrdenModel> GetArchivoOrdenByIdOrden(ArchivoOrdenModel archivoOrden);
        int DeleteArchivoOrden(ArchivoOrden archivoOrden);
    }
}
