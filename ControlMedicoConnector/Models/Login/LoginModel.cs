using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ControlMedicoConnector.Models.ComunModel;

namespace ControlMedicoConnector.Models
{
    public static class LoginModel
    {
        public static string UserId;
        public static string UserName;
        public static string Token;
        public static RolesUsuario Rol;
        public static int IdSuscripcion;

        public static MedicoModel Medico;
    }
}
