using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ControlMedicoWinForms.Models.ComunModel;

namespace ControlMedicoWinForms.Models
{
    public static class LoginModel
    {
        public static string UserId;
        public static string UserName;
        public static string Token;
        public static RolesUsuario Rol;
        public static int IdSuscripcion;

        public static SuscripcionModel Suscripcion;
        public static MedicoModel Medico;
        public static List<ConfiguracionMedicoModel> listaConfiguracionMedico;
    }
}
