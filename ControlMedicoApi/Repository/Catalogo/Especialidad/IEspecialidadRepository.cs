using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Repository
{
    public interface IEspecialidadRepository
    {
        int AddEspecialidad(Especialidad especialidad);
        bool UpdateEspecialidad(Especialidad especialidad);
        List<EspecialidadModel> GetAllEspecialidades();
        EspecialidadModel GetEspecialidadById(EspecialidadModel especialidad);
        List<EspecialidadModel> GetEspecialidadesByActivo(EspecialidadModel especialidad);
    }
}
