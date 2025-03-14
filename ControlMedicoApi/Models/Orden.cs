//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ControlMedicoApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Orden
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Orden()
        {
            this.HistoricoOrdens = new HashSet<HistoricoOrden>();
        }
    
        public int IdOrden { get; set; }
        public int IdPaciente { get; set; }
        public int IdMedicoEntrega { get; set; }
        public Nullable<int> IdEspecimen { get; set; }
        public Nullable<System.DateTime> FechaRecepcion { get; set; }
        public Nullable<System.DateTime> FechaEntregaReceptor { get; set; }
        public Nullable<int> IdDiagnostico { get; set; }
        public Nullable<decimal> Monto { get; set; }
        public string PersonaEntrega { get; set; }
        public string Observaciones { get; set; }
        public Nullable<int> Estatus { get; set; }
        public Nullable<int> Pagado { get; set; }
        public int Activo { get; set; }
        public int IdSuscripcion { get; set; }
        public Nullable<int> IdMedicoRecepcion { get; set; }
        public string PersonaRecepcion { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public Nullable<System.DateTime> FechaEntregaOrigen { get; set; }
        public string CorreoPersonaRecepcion { get; set; }
        public string MovilPersonaRecepcion { get; set; }
    
        public virtual EstatusOrden EstatusOrden { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HistoricoOrden> HistoricoOrdens { get; set; }
        public virtual Medico Medico { get; set; }
        public virtual Paciente Paciente { get; set; }
        public virtual Especiman Especiman { get; set; }
    }
}
