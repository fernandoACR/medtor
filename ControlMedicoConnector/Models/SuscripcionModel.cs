using ControlMedicoConnector.Models.Catalogo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoConnector.Models
{
    public class SuscripcionModel
    {
        public int IdSuscriptor { get; set; }
        public int MaxUsuarios { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public EstatusSuscripcionModel Estatus { get; set; }
        public int Activo { get; set; }

        public ClienteModel Cliente { get; set; }
        public TransaccionModel Transaccion { get; set; }
    }
}
