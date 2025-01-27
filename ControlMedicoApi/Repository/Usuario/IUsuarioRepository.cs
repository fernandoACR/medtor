using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Repository
{
    public interface IUsuarioRepository
    {
        UsuarioModel GetUsuarioByIdMedico(MedicoModel medico);
        UsuarioModel GetUsuarioByEmail(UsuarioModel usuario);
    }
}
