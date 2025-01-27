using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoConnector.Models
{
    public class MedicoModel
    {
        public int IdMedico { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public EspecialidadModel Especialidad { get; set; }
        public int Activo { get; set; }
        public string Correo { get; set; }
        public SuscripcionModel Suscripcion { get; set; }
        public string CedulaProfesional { get; set; }
        public ArchivoMedicoModel Logo { get; set; }
    }
}
