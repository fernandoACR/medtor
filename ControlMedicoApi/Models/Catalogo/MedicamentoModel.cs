using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Models
{
    public class MedicamentoModel
    {
        public int IdMedicamento { get; set; }
        public MedicoModel Medico { get; set; }
        public string Descripcion { get; set; }
        public int Activo { get; set; }
    }
}