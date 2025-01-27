using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoWinForms.Models
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

        public string NombrePaciente { get; set; }
        public string NombreMedico { get; set; }

        public string FechaCitaDesdeDescrip { get; set; }
        public TipoCitaModel TipoCita { get; set; }
        public string TipoCitaDescrip { get; set; }
        public string EstatusCitaDescrip { get; set; }
        public DateTime FechaCitaHasta { get; set; }
        public string HoraCitaHastaDescrip { get; set; }
        public string HoraCitaDesdeDescrip { get; set; }

        public bool NotificarEmail { get; set; }
        public bool NotificarSMS { get; set; }
        public bool NotificarWHP { get; set; }
    }
}
