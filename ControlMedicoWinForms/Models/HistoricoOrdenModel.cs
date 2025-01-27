using ControlMedicoWinForms.Models.Catalogo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoWinForms.Models
{
    public class HistoricoOrdenModel
    {
        public int IdHistoricoOrden { get; set; }
        public OrdenModel Orden { get; set; }
        public EstatusOrdenModel EstatusOrden { get; set; }
        public DateTime FechaEstatus { get; set; }
        public int? IdUsuarioModificacion { get; set; }
    }
}
