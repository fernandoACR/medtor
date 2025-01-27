using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Models
{
    public class TipoReporteVariableModel
    {
        public int IdTipoReporteVariable { get; set; }
        public TipoReporteModel TipoReporte { get; set; }
        public string Descripcion { get; set; }
        public string Entidad { get; set; }
        public string Tipo { get; set; }
        public string Propiedad { get; set; }
        public string Html { get; set; }
        public int Activo { get; set; }
    }
}