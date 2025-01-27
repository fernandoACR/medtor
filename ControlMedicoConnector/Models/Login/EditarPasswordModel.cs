using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoConnector.Models
{
    public class EditarPasswordModel
    {
        public string UserId { get; set; }
        public string PasswordActual { get; set; }
        public string NuevoPassword { get; set; }
        public string ConfirmarPassword { get; set; }
    }
}
