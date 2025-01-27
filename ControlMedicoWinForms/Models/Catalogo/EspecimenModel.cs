using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoWinForms.Models
{
    public class EspecimenModel
    {
        public int IdEspecimen { get; set; }
        public string Descripcion { get; set; }
        public int Activo { get; set; }
        public MedicoModel Medico { get; set; }
    }
}
