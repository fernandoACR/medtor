using ControlMedicoApi.Models;
using ControlMedicoApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Business
{
    public interface IRecetaMedicamentoBusiness
    {
        int AddRecetaMedicamento(RecetaMedicamentoModel recetaMedicamento);
        bool UpdateRecetaMedicamento(RecetaMedicamentoModel recetaMedicamento);
        List<RecetaMedicamentoModel> GetAllRecetaMedicamentos();
        RecetaMedicamentoModel GetRecetaMedicamentoById(RecetaMedicamentoModel recetaMedicamento);
    }
}
