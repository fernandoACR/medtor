using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Business
{
    public interface IRecetaBusiness
    {
        int AddReceta(RecetaModel receta);
        bool UpdateReceta(RecetaModel receta);
        List<RecetaModel> GetAllRecetas();
        RecetaModel GetRecetaById(RecetaModel receta);
        MemoryStream PrintRecetaByIdReceta(RecetaModel receta);
        List<RecetaModel> GetRecetaByIdMedico(RecetaModel receta);
    }
}
