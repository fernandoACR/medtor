using ControlMedicoWinForms.Models;
using ControlMedicoWinForms.Services;
using ControlMedicoWinForms.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlMedicoWinForms.Usuario
{
    public partial class EditarPassword : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        MainForm padre;
        UsuarioServices services = new UsuarioServices();
        ResourceManager validationMessages = new ResourceManager("ControlMedicoWinforms.Utilidades.ValidationMessages", Assembly.GetExecutingAssembly());
        Utility utility = new Utility();

        public EditarPassword(MainForm p)
        {
            padre = p;
            InitializeComponent();
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if(ValidateForm())
            {
                try
                {
                    EditarPasswordModel model = new EditarPasswordModel()
                    {
                        UserId = LoginModel.UserId,
                        PasswordActual = txtPasswordActual.Text,
                        NuevoPassword = txtNuevoPassword.Text,
                        ConfirmarPassword = txtConfirmarPassword.Text
                    };

                    if (await services.ChangePassword(model))
                    {
                        ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show("Contraseña editada correctamente", "Control Médico", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                catch(Exception ex)
                {
                    utility.WriteToErrorLog(AppDomain.CurrentDomain.BaseDirectory, ex);
                    ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(validationMessages.GetString("ErrorInesperado"), "Control Médico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void EditarPassword_Load(object sender, EventArgs e)
        {
            lblNombreUsuario.Text = LoginModel.UserName;
        }

        public bool ValidateForm()
        {
            if (txtPasswordActual.Text == "")
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(string.Format(validationMessages.GetString("CampoVacio"), "Contraseña Actual"), "Control Médico", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (txtNuevoPassword.Text == "")
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(string.Format(validationMessages.GetString("CampoVacio"), "Nueva Contraseña"), "Control Médico", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (txtNuevoPassword.Text != txtConfirmarPassword.Text)
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show("El valor del campo nueva contraseña y confirmar nueva contraseña debe coincidir", "Control Médico", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
