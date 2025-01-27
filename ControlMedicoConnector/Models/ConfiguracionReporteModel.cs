using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoConnector.Models
{
    public class ConfiguracionReporteModel
    {
        public int IdConfiguracionReporte { get; set; }
        public string Html { get; set; }
        public int Activo { get; set; }

        public MedicoModel Medico { get; set; }
        public TipoReporteModel TipoReporte { get; set; }
    }
}