using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoWinForms.Models
{
    public class ArchivoOrdenModel
    {
        public int IdArchivoOrden { get; set; }
        public OrdenModel Orden { get; set; }
        public TipoArchivoModel TipoArchivo { get; set; }
        public string Descripcion { get; set; }
        public Guid Codigo { get; set; }
        public string Archivo { get; set; }
        public int Activo { get; set; }
        public string ExtensionArchivo { get; set; }
    }
}
