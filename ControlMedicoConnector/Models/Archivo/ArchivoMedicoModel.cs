using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoConnector.Models
{
    public class ArchivoMedicoModel
    {
        public int IdArchivoMedico { get; set; }
        public MedicoModel Medico { get; set; }
        public TipoArchivoModel TipoArchivo { get; set; }
        public string Descripcion { get; set; }
        public Guid Codigo { get; set; }
        public string Archivo { get; set; }
        public int Activo { get; set; }
        public string ExtensionArchivo { get; set; }
    }
}