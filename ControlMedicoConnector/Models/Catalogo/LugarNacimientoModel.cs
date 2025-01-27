using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoConnector.Models
{
    public class LugarNacimientoModel
    {
        public int IdLugarNacimiento { get; set; }
        public string Clave { get; set; }
        public string Descripcion { get; set; }
        public int Activo { get; set; }
    }
}