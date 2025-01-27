using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Repository
{
    public interface IInventarioMedicamentoRepository
    {
        int AddInventarioMedicamento(InventarioMedicamento inventarioMedicamento);
        bool UpdateInventarioMedicamento(InventarioMedicamento inventarioMedicamento);
        List<InventarioMedicamentoModel> GetAllInventarioMedicamentos();
        InventarioMedicamentoModel GetInventarioMedicamentoById(InventarioMedicamentoModel inventarioMedicamento);
        List<InventarioMedicamentoModel> GetInventarioMedicamentoByIdMedicamento(MedicamentoModel medicamento);
    }
}
