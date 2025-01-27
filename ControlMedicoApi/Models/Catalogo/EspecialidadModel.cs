using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Models
{
    public class EspecialidadModel
    {
        public int IdEspecialidad { get; set; }
        public string Descripcion { get; set; }
        public int Activo { get; set; }
    }
}