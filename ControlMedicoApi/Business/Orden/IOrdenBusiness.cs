using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Business
{
    public interface IOrdenBusiness
    {
        int AddOrden(OrdenModel orden);
        bool UpdateOrden(OrdenModel orden);
        List<OrdenModel> GetAllOrdenes();
        OrdenModel GetOrdenById(OrdenModel orden);
        List<OrdenModel> GetOrdenByIdMedicoEntrega(OrdenModel orden);
        List<OrdenModel> GetOrdenByIdMedicoRecepcion(OrdenModel orden);
        List<OrdenModel> GetOrdenByIdDiagnostico(OrdenModel orden);
        MemoryStream PrintOrdenByIdOrden(OrdenModel orden);
    }
}
