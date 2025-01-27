using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoConnector.Models.Catalogo
{
    public class EstatusOrdenModel
    {
        public int IdEstatusOrden { get; set; }
        public string Clave { get; set; }
        public string Descripcion { get; set; }
        public int Activo { get; set; }
        public int IdSuscripcion { get; set; }
    }
}
