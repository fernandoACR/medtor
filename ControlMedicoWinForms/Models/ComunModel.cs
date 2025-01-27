using ControlMedicoWinForms.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlMedicoWinForms.Models
{
    public class ComunModel
    {
        public enum EstatusSuscripEnum
        {            
            POP = 1,
            PAP = 2,
            DEU = 3,
            PAG = 4
        }

        public enum RolesUsuario
        {
            Administrador = 1,
            Medico = 2,
            Paciente = 3,
            Usuario = 4
        };

        public enum EstatusCitaEnum
        {
            POR = 1,
            AGE = 2,
            CNC = 4,
            [Description("Completada")]
            CMP = 5
        };

        public enum EstatusOrdenEnum
        {
            ENTR = 3,
            REC = 4,
            PRO = 5,
            ENTO = 7
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

        public class MyColorTable : ProfessionalColorTable
        {
            private Color menuItemSelectedColor;
            public MyColorTable(Color color) : base()
            {
                menuItemSelectedColor = color;
            }
            public override Color MenuItemSelected
            {
                get { return menuItemSelectedColor; }
            }
        }

        public class MyRenderer : ToolStripProfessionalRenderer
        {
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                //Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
                Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
            }
            protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
            {
                base.OnRenderItemText(e);
                e.Item.ForeColor = Color.White;
            }            
        }

        public class UsuarioModel
        {
            public string Id { get; set; }
            public string Correo { get; set; }
            public bool EmailConfirmed { get; set; }
            public string PasswordHash { get; set; }
            public string SecurityStamp { get; set; }
            public string PhoneNumber { get; set; }
            public bool PhoneNumberConfirmed { get; set; }
            public bool TwoFactorEnabled { get; set; }
            public Nullable<System.DateTime> LockoutEndDateUtc { get; set; }
            public bool LockoutEnabled { get; set; }
            public int AccessFailedCount { get; set; }
            public string UserName { get; set; }
            public Nullable<int> IdSuscripcion { get; set; }
            public Nullable<int> IdMedico { get; set; }
        }

        public class EmailModel
        {
            public string From { get; set; }
            public string To { get; set; }
            public string Password { get; set; }
            public string Body { get; set; }
            public string Subject { get; set; }
            public object Entity { get; set; }
            public int TemplateNotificacionEmail { get; set; }
        }

        public enum IdiomaEnum
        {
            Espanol = 0,
            English = 1
        }

        public enum FontControlEnum
        {
            General = 0,
            GridTitle = 1,
            GridRows = 2,
            GroupBoxTitle = 3,
            GroupBoxControls = 4,
            HeaderGroupBoxTitle = 5
        }

        public enum TipoCitaEnum
        {
            [Description("General")]
            GRL = 1,
            [Description("Especialidad")]
            ESP = 2,
            [Description("Personal")]
            PNL = 3
        }
    }
}
