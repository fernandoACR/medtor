using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoConnector.Models.Login
{
    public class LoginResponse
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int RolId { get; set; }
        public string UserId { get; set; }
        public int SuscriptionId { get; set; }
        public int IdMedico { get; set; }
    }
}
