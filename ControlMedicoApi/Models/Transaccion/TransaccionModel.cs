using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Models
{
    public class TransaccionModel
    {
        public int IdTransaccion { get; set; }
        public int IdTipoTransaccion { get; set; }
        public int IdOperacionContable { get; set; }
        public DateTime Fecha { get; set; }
        public int IdGenerado { get; set; }
        public decimal Monto { get; set; }
        public string NumReferencia { get; set; }
        public string Observaciones { get; set; }
        public int Estatus { get; set; }
        public decimal Saldo { get; set; }
        public decimal MontoPagado { get; set; }
    }
}