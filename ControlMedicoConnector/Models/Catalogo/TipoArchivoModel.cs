﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoConnector.Models
{
    public class TipoArchivoModel
    {
        public int IdTipoArchivo { get; set; }
        public string Descripcion { get; set; }
        public int Activo { get; set; }
    }
}