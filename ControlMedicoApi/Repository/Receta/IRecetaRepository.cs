using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Repository
{
    public interface IRecetaRepository
    {
        int AddReceta(Receta receta);
        bool UpdateReceta(Receta receta);
        List<RecetaModel> GetAllRecetas();
        RecetaModel GetRecetaById(RecetaModel receta);
        List<RecetaModel> GetRecetaByIdDiagnostico(RecetaModel receta);
        List<RecetaModel> GetRecetaByIdMedico(RecetaModel receta);
    }
}
