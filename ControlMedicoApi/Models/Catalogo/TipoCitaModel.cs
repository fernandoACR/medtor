﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Models
{
    public class TipoCitaModel
    {
        public int IdTipoCita { get; set; }
        public string Clave { get; set; }
        public string Descripcion { get; set; }
        public int Activo { get; set; }
        public SuscripcionModel Suscripcion { get; set; }
    }
}