using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Models
{
    public class InventarioMedicamentoModel
    {
        public int IdInventarioMedicamento { get; set; }
        public MedicamentoModel Medicamento { get; set; }
        public string Codigo { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}