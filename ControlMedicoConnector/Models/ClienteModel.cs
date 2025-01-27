using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoConnector.Models
{
    public class ClienteModel
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Identificacion { get; set; }
        public int Activo { get; set; }
        public SuscripcionModel Suscripcion { get; set; }

        [JsonIgnore]
        public int IdSuscripcion { get; set; }
    }
}
