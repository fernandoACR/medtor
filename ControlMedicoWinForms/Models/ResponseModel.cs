using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoWinForms.Models
{
    public class ResponseModel
    {
        public bool Response { get; set; }
        public object Entity { get; set; }
        public dynamic List { get; set; }
        public List<string> ErrorList { get; set; }
    }
}
