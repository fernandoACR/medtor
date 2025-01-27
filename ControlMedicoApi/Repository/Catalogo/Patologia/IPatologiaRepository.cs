using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Repository
{
    public interface IPatologiaRepository
    {
        int AddPatologia(Patologia patologia);
        bool UpdatePatologia(Patologia patologia);
        List<PatologiaModel> GetAllPatologias();
        PatologiaModel GetPatologiaById(PatologiaModel patologia);
        List<PatologiaModel> GetPatologiaByIdMedico(PatologiaModel patologia);
        List<PatologiaModel> GetPatologiaByIdMedicoAndActivo(PatologiaModel patologia);
    }
}
