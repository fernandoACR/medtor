﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoConnector.Models
{
    public class OcupacionModel
    {
        public int IdOcupacion { get; set; }
        public string Clave { get; set; }
        public string Descripcion { get; set; }
        public int Activo { get; set; }
    }
}
