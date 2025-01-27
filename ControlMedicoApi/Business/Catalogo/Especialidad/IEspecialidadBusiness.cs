using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Business
{
    public interface IEspecialidadBusiness
    {
        int AddEspecialidad(EspecialidadModel especialidad);
        bool UpdateEspecialidad(EspecialidadModel especialidad);
        List<EspecialidadModel> GetAllEspecialidades();
        EspecialidadModel GetEspecialidadById(EspecialidadModel especialidad);
        List<EspecialidadModel> GetEspecialidadesByActivo(EspecialidadModel especialidad);
    }
}
