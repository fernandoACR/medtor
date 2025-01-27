using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Models
{
    public class ArchivoOrdenModel
    {
        public int IdArchivoOrden { get; set; }
        public OrdenModel Orden { get; set; }
        public TipoArchivoModel TipoArchivo { get; set; }
        public string Descripcion { get; set; }
        public Guid Codigo { get; set; }
        public string Archivo { get; set; }
        public byte[] ArchivoByte { get; set; }
        public int Activo { get; set; }
        public string ExtensionArchivo { get; set; }
    }
}