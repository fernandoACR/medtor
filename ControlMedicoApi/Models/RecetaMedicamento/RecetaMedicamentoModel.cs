using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Models
{
    public class RecetaMedicamentoModel
    {
        public int IdRecetaMedicamento { get; set; }
        public int? Cantidad { get; set; }
        public string Frecuencia { get; set; }

        public MedicamentoModel Medicamento { get; set; }
        public RecetaModel Receta { get; set; }
    }
}