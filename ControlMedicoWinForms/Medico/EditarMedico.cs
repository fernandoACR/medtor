using ControlMedicoWinForms.Cliente;
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
using static ControlMedicoWinForms.Models.ComunModel;

namespace ControlMedicoWinForms.Medico
{
    public partial class EditarMedico : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        ControlMedicos padre;
        int id;
        MedicoServices services = new MedicoServices();
        Catalogo.CatalogoServices catalogoServices = new Catalogo.CatalogoServices();
        ClienteServices clienteServices = new ClienteServices();

        public EditarMedico(int idMedico, ControlMedicos p)
        {
            padre = p;
            id = idMedico;
            InitializeComponent();
        }

        private async void EditarMedico_Load(object sender, EventArgs e)
        {
            this.Font = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);

            try
            {
                MedicoModel medico = await services.GetMedicoById(new MedicoModel() { IdMedico = id });
                var especialidades = await catalogoServices.GetAllEspecialidades();
                especialidades.Add(new EspecialidadModel { IdEspecialidad = 0, Descripcion = "Seleccione" });
                cmbEspecialidad.DataSource = especialidades.OrderBy(x=> x.IdEspecialidad).ToList();
                cmbEspecialidad.DisplayMember = "Descripcion";
                cmbEspecialidad.ValueMember = "IdEspecialidad";

                var clientes = await clienteServices.GetAllClientes();
                clientes.ForEach(x => x.IdSuscripcion = x.Suscripcion.IdSuscriptor);
                clientes.Add(new ClienteModel { IdSuscripcion = 0, Nombre = "Seleccione" });
                cmbCliente.DataSource = clientes.OrderBy(x => x.IdCliente).ToList();
                cmbCliente.DisplayMember = "Nombre";
                cmbCliente.ValueMember = "IdSuscripcion";

                if (medico != null)
                {
                    txtCorreo.Text = medico.Correo;
                    txtConfirmaCorreo.Text = medico.Correo;
                    txtNombre.Text = medico.Nombre;
                    txtTelefono.Text = medico.Telefono;
                    cmbEspecialidad.SelectedValue = medico.Especialidad == null ? 0 : medico.Especialidad.IdEspecialidad;
                    chkActivo.Checked = Convert.ToBoolean(medico.Activo);
                    txtCedulaProf.Text = medico.CedulaProfesional;
                    cmbCliente.SelectedValue = medico.Suscripcion.IdSuscriptor;
                }
            }
            catch (Exception ex)
            {
                ControlLenguaje.utility.WriteToErrorLog(AppDomain.CurrentDomain.BaseDirectory, ex);
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.validationMessages.GetString("ErrorInesperado"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                try
                {
                    MedicoModel medico = new MedicoModel()
                    {
                        IdMedico = id,
                        Nombre = txtNombre.Text,
                        Telefono = txtTelefono.Text,
                        Correo = txtCorreo.Text,
                        Activo = Convert.ToInt32(chkActivo.Checked),
                        Especialidad = (int)cmbEspecialidad.SelectedValue == 0 ? null : new EspecialidadModel() { IdEspecialidad = (int)cmbEspecialidad.SelectedValue },
                        CedulaProfesional = txtCedulaProf.Text
                    };

                    if (await services.UpdateMedico(medico))
                    {
                        ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show("Médico Editado Correctamente", ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        padre.LoadDatos();
                        this.Close();
                    }
                }
                catch(Exception ex)
                {
                    ControlLenguaje.utility.WriteToErrorLog(AppDomain.CurrentDomain.BaseDirectory, ex);
                    ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.validationMessages.GetString("ErrorInesperado"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool ValidateForm()
        {
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

            if (txtNombre.Text == "")
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(string.Format(ControlLenguaje.validationMessages.GetString("CampoVacio"), "Nombre"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (txtCorreo.Text == "")
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(string.Format(ControlLenguaje.validationMessages.GetString("CampoVacio"), "Correo"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (!rEMail.IsMatch(txtCorreo.Text))
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show("El valor del campo correo no es válido", ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (txtCorreo.Text != txtConfirmaCorreo.Text)
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show("El valor del campo correo y confirmar correo debe coincidir", ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
