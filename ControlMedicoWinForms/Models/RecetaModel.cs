using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoWinForms.Models
{
    public class RecetaModel
    {
        public RecetaModel()
        {
            this.recetaMedicamentos = new List<RecetaMedicamentoModel>();
        }

        public int IdReceta { get; set; }
        public int IdInstitucion { get; set; }
        public DiagnosticoModel Diagnostico { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public MedicoModel Medico { get; set; }
        public PacienteModel Paciente { get; set; }
        public int Activo { get; set; }

        public List<RecetaMedicamentoModel> recetaMedicamentos { get; set; }

        public string InstitucionDescrip { get; set; }
        public string NombreMedico { get; set; }
        public string NombrePaciente { get; set; }
        public string DiagnosticoDescrip { get; set; }
    }
}
