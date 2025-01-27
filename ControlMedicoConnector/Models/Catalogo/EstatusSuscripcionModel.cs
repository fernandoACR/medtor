using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoConnector.Models
{
    public class EstatusSuscripcionModel
    {
        public int IdEstatusSuscriptor { get; set; }
        public string Descripcion { get; set; }
        public int Activo { get; set; }
    }
}
