using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoConnector.Models
{
    public class TipoReporteVariableModel
    {
        public int IdTipoReporteVariable { get; set; }
        public TipoReporteModel TipoReporte { get; set; }
        public string Descripcion { get; set; }
        public string Propiedad { get; set; }
        public int Activo { get; set; }
    }
}
