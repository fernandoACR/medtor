using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Repository
{
    public interface IRecetaMedicamentoRepository
    {
        int AddRecetaMedicamento(RecetaMedicamento recetaMedicamento);
        bool UpdateRecetaMedicamento(RecetaMedicamento recetaMedicamento);
        List<RecetaMedicamentoModel> GetAllRecetaMedicamentos();
        RecetaMedicamentoModel GetRecetaMedicamentoById(RecetaMedicamentoModel recetaMedicamento);
        List<RecetaMedicamentoModel> GetRecetaMedicamentoByIdReceta(RecetaModel receta);
    }
}
