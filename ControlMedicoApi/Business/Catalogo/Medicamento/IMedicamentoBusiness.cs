using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Business
{
    public interface IMedicamentoBusiness
    {
        int AddMedicamento(MedicamentoModel medicamento);
        bool UpdateMedicamento(MedicamentoModel medicamento);
        List<MedicamentoModel> GetAllMedicamentos();
        MedicamentoModel GetMedicamentoById(MedicamentoModel medicamento);
        List<MedicamentoModel> GetMedicamentoByIdMedico(MedicamentoModel medicamento);
        List<MedicamentoModel> GetMedicamentosByIdMedicoAndActivo(MedicamentoModel medicamento);
    }
}
