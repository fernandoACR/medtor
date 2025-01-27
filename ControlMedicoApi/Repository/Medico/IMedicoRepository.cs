using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Repository
{
    public interface IMedicoRepository
    {
        int AddMedico(Medico medico);
        bool UpdateMedico(Medico medico);
        List<MedicoModel> GetAllMedicos();
        MedicoModel GetMedicoById(MedicoModel medico);
        List<MedicoModel> GetMedicoByIdSuscripcion(MedicoModel medico);
    }
}
