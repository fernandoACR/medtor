using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using static ControlMedicoWinForms.Models.ComunModel;

namespace ControlMedicoWinForms.Utilidades
{
    public static class ControlLenguaje
    {
        public static ResourceManager validationMessages = new ResourceManager("ControlMedicoWinforms.Utilidades.ValidationMessages", Assembly.GetExecutingAssembly());
        public static Utility utility = new Utility();
        public static string idiomaSeleccionado = IdiomaEnum.Espanol.ToString();
        public static ResourceManager cadenas = new ResourceManager("ControlMedicoWinforms.Utilidades.Idioma." + idiomaSeleccionado + "Strings", Assembly.GetExecutingAssembly());
    }
}
