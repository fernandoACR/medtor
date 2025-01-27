using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Models
{
    public class TipoNotificacionModel
    {
        public int IdTipoNotificacion { get; set; }
        public MedicoModel Medico { get; set; }
        public string Descripcion { get; set; }
        public string Clave { get; set; }
        public string Template { get; set; }
        public int Activo { get; set; }
    }
}