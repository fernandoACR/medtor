using ControlMedicoWinForms.Catalogo;
using ControlMedicoWinForms.Cliente;
using ControlMedicoWinForms.Models;
using ControlMedicoWinForms.Notificacion;
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
using static ControlMedicoWinForms.Models.ComunModel;

namespace ControlMedicoWinForms.Medico
{
    public partial class AgregarMedico : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        ControlMedicos padre;
        MedicoServices services = new MedicoServices();
        CatalogoServices catalogoServices = new CatalogoServices();
        UsuarioServices usuarioServices = new UsuarioServices();
        ClienteServices clienteServices = new ClienteServices();
        NotificacionServices notificacionServices = new NotificacionServices();

        public AgregarMedico(ControlMedicos p)
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
                    MedicoModel medico = new MedicoModel()
                    {
                        IdMedico = 0,
                        Nombre = txtNombre.Text,
                        Telefono = txtTelefono.Text,
                        Especialidad = (int)cmbEspecialidad.SelectedValue == 0 ? null : new EspecialidadModel() { IdEspecialidad = (int)cmbEspecialidad.SelectedValue },
                        Correo = txtCorreo.Text,
                        CedulaProfesional = txtCedulaProf.Text,
                        Suscripcion = new SuscripcionModel() { IdSuscriptor = (int)cmbCliente.SelectedValue },
                    };

                    int accion = await services.AddMedico(medico);

                    if (accion > 0)
                    {
                        string randomPassword = Utility.GetRandomAlphaNumString();

                        if (await usuarioServices.Register(new RegistroUsuarioModel()
                        {
                            Correo = medico.Correo,
                            Password = "000AAbb.",
                            ConfirmaPassword = "000AAbb.",
                            Rol = RolesUsuario.Medico.ToString(),
                            IdSuscripcion = (int)cmbCliente.SelectedValue,
                            IdMedico = accion
                        }))
                        {
                            ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.cadenas.GetString("MedicoAgregado"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                            medico.IdMedico = accion;
                            int idNotificacion = await notificacionServices.AddNotificacion(new NotificacionModel()
                            {
                                Medico = medico,
                                Paciente = new PacienteModel() { IdPaciente = 0 },
                                TipoNotificacion = new TipoNotificacionModel() { IdTipoNotificacion = (int)TipoNotificacionEnum.NuevoMedico },
                                Recursivo = 0,
                                MedioNotificacion = new MedioNotificacionModel() { IdMedioNotificacion = (int)MedioNotificacionEnum.EMAIL },
                                FechaNotificacion = DateTime.Now,
                                HoraNotificacion = DateTime.Now,
                                Activo = 1,
                                Cita = new CitaModel() { IdCita = 0 }
                            });

                            await notificacionServices.EnviarNotificacionPorIdNotificacion(new NotificacionModel() { IdNotificacion = idNotificacion });

                            padre.LoadDatos();
                            this.Close();
                        }
                        else
                        {
                            ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show("Se ha agregado correctamente el médico, pero ocurrió un error al generar el usuario asociado", ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            padre.LoadDatos();
                            this.Close();
                        }
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

        private async void AgregarMedico_Load(object sender, EventArgs e)
        {
            this.Font = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);

            //Obtener especialidades
            var especialidades = await catalogoServices.GetAllEspecialidades();
            especialidades.Add(new EspecialidadModel { IdEspecialidad = 0, Descripcion = "Seleccione" });
            cmbEspecialidad.DataSource = especialidades.OrderBy(x => x.IdEspecialidad).ToList();
            cmbEspecialidad.DisplayMember = "Descripcion";
            cmbEspecialidad.ValueMember = "IdEspecialidad";

            //Obtener clientes
            var clientes = await clienteServices.GetAllClientes();
            clientes.ForEach(x => x.IdSuscripcion = x.Suscripcion.IdSuscriptor);
            clientes.Add(new ClienteModel {  IdSuscripcion = 0, Nombre = "Seleccione" });
            cmbCliente.DataSource = clientes.OrderBy(x => x.IdCliente).ToList();
            cmbCliente.DisplayMember = "Nombre";
            cmbCliente.ValueMember = "IdSuscripcion";
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
            ControlLenguaje.utility.OnlyNumbers(sender, e);
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
