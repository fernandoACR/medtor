using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Models
{
    public class SuscripcionModel
    {
        public SuscripcionModel()
        {
            this.Transaccion = new TransaccionModel();
        }

        public int IdSuscriptor { get; set; }
        public int MaxUsuarios { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public EstatusSuscripcionModel Estatus { get; set; }
        public int Activo { get; set; }

        public ClienteModel Cliente { get; set; }
        public TransaccionModel Transaccion { get; set; }
    }
}