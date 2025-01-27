using ControlMedicoWinForms.Catalogo;
using ControlMedicoWinForms.Diagnostico;
using ControlMedicoWinForms.Models;
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

namespace ControlMedicoWinForms.Archivo
{
    public partial class AgregarArchivo : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        dynamic padre;
        ResourceManager validationMessages = new ResourceManager("ControlMedicoWinforms.Utilidades.ValidationMessages", Assembly.GetExecutingAssembly());
        CatalogoServices catalogoServices = new CatalogoServices();

        public AgregarArchivo(dynamic p)
        {
            padre = p;
            InitializeComponent();
        }

        private async void AgregarArchivo_Load(object sender, EventArgs e)
        {
            var tipoArchivos = await catalogoServices.GetAllTipoArchivos();
            tipoArchivos.Add(new TipoArchivoModel { IdTipoArchivo = 0, Descripcion = "Seleccione" });
            cmbTipoArchivo.DataSource = tipoArchivos.OrderBy(x => x.IdTipoArchivo).ToList();
            cmbTipoArchivo.DisplayMember = "Descripcion";
            cmbTipoArchivo.ValueMember = "IdTipoArchivo";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                padre.AdjuntarArchivo(txtDescripcion.Text, (int)cmbTipoArchivo.SelectedValue);
                this.Close();
            }            
        }

        public bool ValidateForm()
        {
            if ((int)cmbTipoArchivo.SelectedValue == 0)
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(string.Format(validationMessages.GetString("CampoVacio"), "Tipo Archivo"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (txtDescripcion.Text == "")
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(string.Format(validationMessages.GetString("CampoVacio"), "Descripción"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
