using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Business
{
    public interface IPatologiaBusiness
    {
        int AddPatologia(PatologiaModel patologia);
        bool UpdatePatologia(PatologiaModel patologia);
        List<PatologiaModel> GetAllPatologias();
        PatologiaModel GetPatologiaById(PatologiaModel patologia);
        List<PatologiaModel> GetPatologiaByIdMedico(PatologiaModel patologia);
        List<PatologiaModel> GetPatologiaByIdMedicoAndActivo(PatologiaModel patologia);
    }
}
