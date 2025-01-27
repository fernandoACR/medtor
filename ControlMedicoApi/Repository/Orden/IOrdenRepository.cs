using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlMedicoApi.Models;

namespace ControlMedicoApi.Repository
{
    public interface IOrdenRepository
    {
        int AddOrden(Orden orden);
        bool UpdateOrden(Orden orden);
        List<OrdenModel> GetAllOrdenes();
        OrdenModel GetOrdenById(OrdenModel orden);
        List<OrdenModel> GetOrdenByIdMedicoEntrega(OrdenModel orden);
        List<OrdenModel> GetOrdenByIdMedicoRecepcion(OrdenModel orden);
        List<OrdenModel> GetOrdenByIdDiagnostico(OrdenModel orden);
    }
}
