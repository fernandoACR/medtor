﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Models
{
    public class EstatusOrdenModel
    {
        public int IdEstatusOrden { get; set; }
        public string Clave { get; set; }
        public string Descripcion { get; set; }
        public int Activo { get; set; }
        public int IdSuscripcion { get; set; }
    }
}