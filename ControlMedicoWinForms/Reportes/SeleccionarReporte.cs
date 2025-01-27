using ControlMedicoWinForms.Catalogo;
using ControlMedicoWinForms.Models;
using ControlMedicoWinForms.Utilidades;
using System;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace ControlMedicoWinForms.Reportes
{
    public partial class SeleccionarReporte : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        dynamic padre;
        CatalogoServices catalogoServices = new CatalogoServices();

        public SeleccionarReporte(dynamic p)
        {
            padre = p;
            InitializeComponent();
        }

        private async void SeleccionarReporte_Load(object sender, EventArgs e)
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
                //padre.AdjuntarArchivo(txtDescripcion.Text, (int)cmbTipoArchivo.SelectedValue);
                //this.Close();
            }            
        }

        public bool ValidateForm()
        {
            if ((int)cmbTipoArchivo.SelectedValue == 0)
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(string.Format(ControlLenguaje.validationMessages.GetString("CampoVacio"), "Tipo Archivo"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
