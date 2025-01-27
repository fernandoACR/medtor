using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoWinForms.Models
{
    public class DiagnosticoModel
    {
        public int IdDiagnostico { get; set; }
        public PacienteModel Paciente { get; set; }
        public MedicoModel Medico { get; set; }
        public string Descripcion { get; set; }
        public decimal? Peso { get; set; }
        public decimal? Altura { get; set; }
        public string Alergias { get; set; }
        public int Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }

        public string NombreMedico { get; set; }
        public string NombrePaciente { get; set; }

        public List<ArchivoDiagnosticoModel> ArchivosAdjuntos { get; set; }
        public CitaModel Cita { get; set; }
    }
}
