using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Repository
{
    public interface IMedicamentoRepository
    {
        int AddMedicamento(Medicamento medicamento);
        bool UpdateMedicamento(Medicamento medicamento);
        List<MedicamentoModel> GetAllMedicamentos();
        MedicamentoModel GetMedicamentoById(MedicamentoModel medicamento);
        List<MedicamentoModel> GetMedicamentoByIdMedico(MedicamentoModel medicamento);
        List<MedicamentoModel> GetMedicamentosByIdMedicoAndActivo(MedicamentoModel medicamento);
    }
}
