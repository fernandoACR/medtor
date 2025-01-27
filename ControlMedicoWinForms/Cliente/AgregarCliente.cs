using ControlMedicoWinForms.Models;
using ControlMedicoWinForms.Suscripcion;
using ControlMedicoWinForms.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlMedicoWinForms.Cliente
{
    public partial class AgregarCliente : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        ControlClientes padre;
        ClienteServices services = new ClienteServices();
        SuscripcionServices suscripcionServices = new SuscripcionServices();
        public AgregarCliente(ControlClientes p)
        {
            padre = p;
            InitializeComponent();
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                try
                {
                    var listSuscripcions = (List<SuscripcionModel>)dtgrvSuscripciones.DataSource;

                    ClienteModel cliente = new ClienteModel()
                    {
                        IdCliente = 0,
                        Nombre = txtNombre.Text,
                        Telefono = txtTelefono.Text,
                        Identificacion = txtIdentificacion.Text,
                        Direccion = txtDireccion.Text,
                        Suscripcion = listSuscripcions.FirstOrDefault()
                    };

                    new Utility().GoAsync();
                    int accion = await services.AddCliente(cliente);

                    if (accion > 0)
                    {
                        ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show("Cliente agregado correctamente", ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        padre.LoadDatos();
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.validationMessages.GetString("ErrorInesperado"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AgregarCliente_Load(object sender, EventArgs e)
        {

        }

        public bool ValidateForm()
        {
            if (txtNombre.Text == "")
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show("El campo nombre es obligatorio", ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (txtTelefono.Text == "")
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show("El campo Teléfono es obligatorio", ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (txtIdentificacion.Text == "")
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show("El campo Identificación es obligatorio", ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (txtDireccion.Text == "")
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show("El campo Dirección es obligatorio", ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if(dtgrvSuscripciones.Rows.Count <= 0)
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show("Debe indicar los datos de la suscripción", ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void AgregarCliente_Load_1(object sender, EventArgs e)
        {
            //dtgrvSuscripciones.Columns[0].HeaderText = "Max Usuarios";
            //dtgrvSuscripciones.Columns[1].HeaderText = "Fecha Inicio";
            //dtgrvSuscripciones.Columns[2].HeaderText = "Fecha Fin";
            //dtgrvSuscripciones.Columns[3].HeaderText = "Activo";

            //dtgrvSuscripciones.Columns[0].Width = 50;
            //dtgrvSuscripciones.Columns[1].Width = 100;
            //dtgrvSuscripciones.Columns[2].Width = 100;
            //dtgrvSuscripciones.Columns[5].Width = 50;

            //dtgrvSuscripciones.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dtgrvSuscripciones.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dtgrvSuscripciones.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dtgrvSuscripciones.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void btnAgregarSuscripcion_Click(object sender, EventArgs e)
        {
            AgregarSuscripcion f = new AgregarSuscripcion(this);
            f.Show(this);
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
