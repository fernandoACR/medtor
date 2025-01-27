using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoWinForms.Models
{
    public class ArchivoDiagnosticoModel
    {
        public int IdArchivoDiagnostico { get; set; }
        public DiagnosticoModel Diagnostico { get; set; }
        public TipoArchivoModel TipoArchivo { get; set; }
        public string Descripcion { get; set; }
        public Guid Codigo { get; set; }
        public string Archivo { get; set; }
        public int Activo { get; set; }
        public string ExtensionArchivo { get; set; }
    }
}