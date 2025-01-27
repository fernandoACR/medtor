using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Web;
using TuesPechkin;

namespace ControlMedicoApi.Models
{
    public static class UtlilityModel
    {
        public enum EstatusSuscripEnum
        {
            [Description("Por Pagar")]
            POP = 1,
            [Description("Pagado Parcial")]
            PAP = 2,
            [Description("Deuda")]
            DEU = 3,
            [Description("Pagado")]
            PAG = 4
        }

        public enum EstatusCitaEnum
        {
            [Description("Por Confirmar")]
            POR = 1,
            [Description("Agendada")]
            AGE = 2,
            [Description("Cancelada")]
            CNC = 4,
            [Description("Completada")]
            CMP = 5
        }

        public enum EstatusOrdenEnum
        {
            [Description("Entregado")]
            ENTR = 3,
            [Description("Recibido")]
            REC = 4,
            [Description("En proceso")]
            PRO = 5,
            [Description("Entregado a origen")]
            ENTO = 7
        }

        public enum TipoTransaccionEnum
        {
            SUS = 1
        }

        public enum OperacionContableEnum
        {
            RESTA = 1,
            SUMA = 3
        }

        public class EmailModel
        {
            public string From { get; set; }
            public string To { get; set; }
            public string Password { get; set; }
            public string Body { get; set; }
            public string Subject { get; set; }
            public object Entity { get; set; }
            public int TipoNotificacion { get; set; }
        }

        public enum TipoNotificacionEnum
        {
            [Description("Registro de Cliente")]
            NuevoCliente = 5,
            [Description("Registro de Medico")]
            NuevoMedico = 2,
            [Description("Registro de Usuario")]
            NuevoUsuario = 3,
            [Description("Recuperar Contraseña")]
            RecuperarPassword = 4,
            [Description("Recordar Cita")]
            RecordarCita = 1,
            [Description("Recibo de Pago")]
            ReciboPago = 6
        }

        public enum MedioNotificacionEnum
        {
            [Description("Correo Electronico")]
            EMAIL = 1,
            [Description("Mensaje de Texto")]
            SMS = 2,
            [Description("WhatsApp")]
            WHP = 3
        }

        public enum RolesUsuario
        {
            Administrador = 1,
            Medico = 2,
            Paciente = 3,
            Usuario = 4
        };

        public class RegistroUsuarioModel
        {
            public string Correo { get; set; }
            public string Password { get; set; }
            public string ConfirmaPassword { get; set; }
            public string Rol { get; set; }
            public int IdSuscripcion { get; set; }
            public int? IdMedico { get; set; }
        }

        public static string GetRandomAlphaNumString()
        {
            char[] charactersAvailable = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
                                             'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                                             '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};

            StringBuilder randomString = new StringBuilder();

            Random randomCharacter = new Random();

            for (uint i = 0; i < 6; i++)
            {
                int randomCharSelected = randomCharacter.Next(0, (charactersAvailable.Length - 1));

                randomString.Append(charactersAvailable[randomCharSelected]);
            }

            randomString.Append(".1");
            return randomString.ToString();
        }

        public enum TipoReporteEnum
        {
            ExpedienteP1 = 1,
            ExpedienteP2 = 3
        };

        public static IConverter converter = new ThreadSafeConverter(new PdfToolset(new Win32EmbeddedDeployment(new TempFolderDeployment())));
    }    
}