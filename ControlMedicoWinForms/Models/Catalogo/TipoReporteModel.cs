using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoWinForms.Models
{
    public class TipoReporteModel
    {
        public int IdTipoReporte { get; set; }
        public string Descripcion { get; set; }
        public int Activo { get; set; }
    }
}