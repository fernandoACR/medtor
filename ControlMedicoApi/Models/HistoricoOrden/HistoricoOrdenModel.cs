using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Models
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