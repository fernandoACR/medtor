using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoConnector.Models
{
    public class PacienteModel
    {
        public int IdPaciente { get; set; }
        public string PrimerNombre { get; set; }
        public string Telefono { get; set; }
        public string EstadoCivil { get; set; }
        public string Identificacion { get; set; }
        public int Activo { get; set; }
        public int IdSuscripcion { get; set; }
        public string CorreoElectronico { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public EscolaridadModel Escolaridad { get; set; }
        public PatologiaModel Patologia { get; set; }
        public LugarNacimientoModel LugarNacimiento { get; set; }
        public string NombreFamiliar { get; set; }
        public string TelefonoFamiliar { get; set; }
        public string Observaciones { get; set; }

        public string EscolaridadDescrip { get; set; }
        public string PatologiaDescrip { get; set; }

        public MedicoModel Medico { get; set; }

        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Genero { get; set; }
        public MedicamentoModel MedicamentoActual { get; set; }
        public OcupacionModel Ocupacion { get; set; }
        public int SeguroVida { get; set; }
        public string Religion { get; set; }
        public string NombreCompleto { get; set; }

        public string OcupacionDescrip { get; set; }
        public string MedicamentoDescrip { get; set; }
        public bool chkSeguroVida { get; set; }

        public ArchivoPacienteModel Foto { get; set; }
        public string LugarNacimientoDescrip { get; set; }
        public string TelefonoMovil { get; set; }
    }
}
