using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Models
{
    public class OrdenModel
    {
        public OrdenModel()
        {
            this.Paciente = new PacienteModel();
            this.MedicoEntrega = new MedicoModel();
            this.Especimen = new EspecimenModel();
            this.MedicoRecepcion = new MedicoModel();
            this.Diagnostico = new DiagnosticoModel();
        }

        public int IdOrden { get; set; }
        public PacienteModel Paciente { get; set; }
        public MedicoModel MedicoEntrega { get; set; }
        public EspecimenModel Especimen { get; set; }
        public DateTime? FechaRecepcion { get; set; }
        public DateTime? FechaEntregaOrigen { get; set; }
        public DiagnosticoModel Diagnostico { get; set; }
        public decimal? Monto { get; set; }
        public string PersonaEntrega { get; set; }
        public string Clave { get; set; }
        public string Entrega { get; set; }
        public string Observaciones { get; set; }
        public EstatusOrdenModel Estatus { get; set; }
        public int? Pagado { get; set; }
        public int Activo { get; set; }
        public MedicoModel MedicoRecepcion { get; set; }
        public string PersonaRecepcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string CorreoPersonaRecepcion { get; set; }
        public string MovilPersonaRecepcion { get; set; }
        public List<HistoricoOrdenModel> HistoricoOrden { get; set; }
        public int IdSuscripcion { get; set; }

        public List<ArchivoOrdenModel> ArchivosAdjuntos { get; set; }

    }
}