using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Models
{
    public class NotificacionModel
    {
        public int IdNotificacion { get; set; }
        public MedicoModel Medico { get; set; }
        public PacienteModel Paciente { get; set; }
        public TipoNotificacionModel TipoNotificacion { get; set; }
        public MedioNotificacionModel MedioNotificacion { get; set; }
        public int? Recursivo { get; set; }
        public DateTime? FechaNotificacion { get; set; }
        public DateTime? HoraNotificacion { get; set; }
        public int Activo { get; set; }
        public CitaModel Cita { get; set; }
    }
}