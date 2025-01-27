using ControlMedicoApi.Models;
using ControlMedicoApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Business
{
    public interface IInventarioMedicamentoBusiness
    {
        int AddInventarioMedicamento(InventarioMedicamentoModel inventarioMedicamento);
        bool UpdateInventarioMedicamento(InventarioMedicamentoModel inventarioMedicamento);
        List<InventarioMedicamentoModel> GetAllInventarioMedicamentos();
        InventarioMedicamentoModel GetInventarioMedicamentoById(InventarioMedicamentoModel inventarioMedicamento);
        List<InventarioMedicamentoModel> GetInventarioMedicamentoByIdMedicamento(MedicamentoModel medicamento);
    }
}
