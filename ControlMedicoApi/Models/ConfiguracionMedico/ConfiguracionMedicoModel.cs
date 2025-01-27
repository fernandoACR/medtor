using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Models
{
    public class ConfiguracionMedicoModel
    {
        public int IdConfiguracionMedico { get; set; }
        public MedicoModel Medico { get; set; }
        public string Descripcion { get; set; }
        public string TipoConfiguracion { get; set; }
        public string Valor { get; set; }
        public int Activo { get; set; }
        public string Nombre { get; set; }
    }
}