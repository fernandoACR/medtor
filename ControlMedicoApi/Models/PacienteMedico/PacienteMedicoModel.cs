using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Models
{
    public class PacienteMedicoModel
    {
        public int IdPacienteMedico { get; set; }
        public MedicoModel Medico { get; set; }
        public PacienteModel Paciente { get; set; }
        public SuscripcionModel Suscripcion { get; set; }
    }
}