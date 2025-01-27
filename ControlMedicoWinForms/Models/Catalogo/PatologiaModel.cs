using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoWinForms.Models
{
    public class PatologiaModel
    {
        public int IdPatologia { get; set; }
        public string Clave { get; set; }
        public string Descripcion { get; set; }
        public int Activo { get; set; }
        public MedicoModel Medico { get; set; }
    }
}
