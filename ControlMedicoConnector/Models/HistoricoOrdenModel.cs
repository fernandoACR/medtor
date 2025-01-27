using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoConnector.Models
{
    public class HistoricoOrdenModel
    {
        public int IdHistoricoOrden { get; set; }
        public int IdOrden { get; set; }
        public int IdEstatusOrden { get; set; }
        public string ClaveOrden { get; set; }
        public DateTime FechaEstatus { get; set; }
        public int? IdUsuarioModificacion { get; set; }
    }
}
