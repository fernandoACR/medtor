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
using ControlMedicoWinForms.Models;
using ControlMedicoWinForms.Utilidades;
using static ControlMedicoWinForms.Models.ComunModel;

namespace ControlMedicoWinForms.Catalogo.Especialidad
{
    public partial class AgregarEspecialidad : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        ControlEspecialidades padre;
        CatalogoServices services = new CatalogoServices();

        public AgregarEspecialidad(ControlEspecialidades p)
        {
            padre = p;
            InitializeComponent();
        }

        private void AgregarEspecialidad_Load(object sender, EventArgs e)
        {
            this.Font = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtDescripcion.Text != "")
            {
                try
                {
                    if (await services.AddEspecialidad(new EspecialidadModel() { Descripcion = txtDescripcion.Text }) > 0)
                    {
                        ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.cadenas.GetString("EspecialidadAgregada"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        padre.Cargar();
                        this.Close();
                    }
                }
                catch(Exception ex)
                {
                    ControlLenguaje.utility.WriteToErrorLog(AppDomain.CurrentDomain.BaseDirectory, ex);
                    ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.validationMessages.GetString("ErrorInesperado"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(string.Format(ControlLenguaje.validationMessages.GetString("CampoVacio"), "Descripción"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
