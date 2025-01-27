using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Models
{
    public class CitaModel
    {
        public int IdCita { get; set; }
        public MedicoModel Medico { get; set; }
        public PacienteModel Paciente { get; set; }
        public DateTime FechaCitaDesde { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string Comentarios { get; set; }
        public string Titulo { get; set; }
        public EstatusCitaModel EstatusCita { get; set; }
        public TipoCitaModel TipoCita { get; set; }
        public DateTime FechaCitaHasta { get; set; }
    }
}