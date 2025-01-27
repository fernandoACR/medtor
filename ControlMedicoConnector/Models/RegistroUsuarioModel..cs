using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoConnector.Models
{
    public class RegistroUsuarioModel
    {
        public string Correo { get; set; }
        public string Password { get; set; }
        public string ConfirmaPassword { get; set; }
        public string Rol { get; set; }
        public int IdSuscripcion { get; set; }
        public int IdMedico { get; set; }
    }
}
