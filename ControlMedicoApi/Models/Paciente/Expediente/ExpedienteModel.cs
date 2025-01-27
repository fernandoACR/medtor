using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Models
{
    public class ExpedienteModel
    {
        public PacienteModel Paciente { get; set; }
        public List<DiagnosticoModel> Diagnosticos { get; set; }
        public List<OrdenModel> Ordenes { get; set; }
    }
}