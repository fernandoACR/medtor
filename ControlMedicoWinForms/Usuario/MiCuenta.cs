using ComponentFactory.Krypton.Toolkit;
using ControlMedicoWinForms.ConfiguracionMedico;
using ControlMedicoWinForms.Medico;
using ControlMedicoWinForms.Models;
using ControlMedicoWinForms.Services;
using ControlMedicoWinForms.Utilidades;
using LiveSwitch.TextControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ControlMedicoWinForms.Models.ComunModel;

namespace ControlMedicoWinForms.Usuario
{
    public partial class MiCuenta : KryptonForm
    {
        UsuarioServices usuarioServices = new UsuarioServices();
        ConfiguracionMedicoServices configuracionMedicoServices = new ConfiguracionMedicoServices();
        MedicoServices medicoServices = new MedicoServices();

        List<UsuarioModel> misUsuarios = new List<UsuarioModel>();
        ArchivoMedicoModel logoMedico = null;

        public MiCuenta()
        {
            InitializeComponent();
        }

        private async void MiCuenta_Load(object sender, EventArgs e)
        {
            this.Font = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);

            this.kryptonNavigator1.StateCommon.RibbonGeneral.TextFont = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);
            this.kryptonPage1.StateCommon.RibbonGeneral.TextFont = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);
            this.pageGeneral.StateCommon.RibbonGeneral.TextFont = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);
            this.pageMisUsuarios.StateCommon.RibbonGeneral.TextFont = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);
            this.kryptonPage3.StateCommon.RibbonGeneral.TextFont = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);

            if (LoginModel.Medico != null && LoginModel.Rol == RolesUsuario.Medico)
            {
                txtNombre.Text = LoginModel.Medico.Nombre;
                txtTelefonoContacto.Text = LoginModel.Medico.Telefono;
                txtDireccion.Text = "";
                chkSuscripActivo.Checked = Convert.ToBoolean(LoginModel.Suscripcion.Activo);
                misUsuarios = await usuarioServices.GetUsersByIdMedico(LoginModel.Medico);

                if(misUsuarios.Count > 0)
                {
                    foreach(UsuarioModel usuario in  misUsuarios)
                    {
                        lstMisUsuarios.Items.Add(usuario.UserName);
                    }                    
                }

                int xPosition = 0;
                int yPostion = 0;

                foreach (ConfiguracionMedicoModel configuracionMedico in LoginModel.listaConfiguracionMedico)
                {
                    xPosition = 30;
                    yPostion = yPostion + 31;

                    KryptonLabel label = new KryptonLabel();
                    label.Text = configuracionMedico.Descripcion;
                    label.Location = new Point(xPosition, yPostion);

                    kryptonNavigator1.Pages[4].Controls.Add(label);

                    xPosition = xPosition + 230;

                    if (configuracionMedico.Nombre == "CitaTimeScale")
                    {
                        KryptonComboBox comboBox = new KryptonComboBox();

                        List<object> listOpciones = new List<object>();
                        listOpciones.Add(new { Text = "15 min", Value = 15 });
                        listOpciones.Add(new { Text = "30 min", Value = 30 });
                        listOpciones.Add(new { Text = "60 min", Value = 60 });

                        comboBox.ValueMember = "Value";
                        comboBox.DisplayMember = "Text";
                        comboBox.DataSource = listOpciones;
                        comboBox.Location = new Point(xPosition, yPostion);
                        comboBox.Name = configuracionMedico.IdConfiguracionMedico.ToString();

                        kryptonNavigator1.Pages[4].Controls.Add(comboBox);

                        comboBox.SelectedValue = Convert.ToInt32(configuracionMedico.Valor);
                    }

                    if (configuracionMedico.TipoConfiguracion == "bool")
                    {
                        KryptonCheckBox checkBox = new KryptonCheckBox();
                        checkBox.Text = "";
                        checkBox.Checked = Convert.ToBoolean(configuracionMedico.Valor);
                        checkBox.Location = new Point(xPosition, yPostion);
                        checkBox.Name = configuracionMedico.IdConfiguracionMedico.ToString();

                        kryptonNavigator1.Pages[4].Controls.Add(checkBox);
                    }                    
                }

                if (LoginModel.Medico.Logo != null)
                {
                    MemoryStream mStream = new MemoryStream();
                    byte[] pData = Convert.FromBase64String(LoginModel.Medico.Logo.Archivo);
                    mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
                    pictureBox1.Image = Image.FromStream(mStream);
                    mStream.Dispose();

                    logoMedico = LoginModel.Medico.Logo;
                }
            }

            txtUserName.Text = LoginModel.UserName;

            if (LoginModel.Suscripcion != null)
            {
                txtValidezDesde.Text = LoginModel.Suscripcion.FechaInicio.ToString("dd/MM/yyy");
                txtValidezHasta.Text = LoginModel.Suscripcion.FechaFin.ToString("dd/MM/yyy");
                txtEstatus.Text = LoginModel.Suscripcion.Estatus.Descripcion;

                if (LoginModel.Suscripcion.Transaccion != null)
                {
                    txtSaldo.Text = LoginModel.Suscripcion.Transaccion.Saldo.ToString();
                }
            }

            if(LoginModel.Rol != RolesUsuario.Medico)
            {
                pageMisUsuarios.Visible = false;
                pageSuscripcion.Visible = false;
                pageGeneral.Visible = false;
            }

            txtPasswordActual.Text = "xxxxxxxxxx";
        }

        private void btnPassword_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {

        }

        private void kryptonLabel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void btnEditarPassword_Click(object sender, EventArgs e)
        {
            if (btnEditarPassword.Text == "Editar")
            {
                txtPasswordActual.ReadOnly = false;
                txtPasswordActual.Text = "";
                txtNuevoPassword.ReadOnly = false;
                txtNuevoPassword.ReadOnly = false;
                txtConfirmarPassword.ReadOnly = false;
                btnEditarPassword.Text = "Guardar";

                txtPasswordActual.StateActive.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
                txtPasswordActual.StateActive.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
                | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
                | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
                txtPasswordActual.StateCommon.Border.Color1 = System.Drawing.Color.Silver;
                txtPasswordActual.StateCommon.Border.Color2 = System.Drawing.Color.White;
                txtPasswordActual.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
                | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
                | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
                txtPasswordActual.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
                txtPasswordActual.StateCommon.Border.Rounding = 4;
                txtPasswordActual.StateCommon.Border.Width = 2;

                txtNuevoPassword.StateActive.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
                txtNuevoPassword.StateActive.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
                | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
                | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
                txtNuevoPassword.StateCommon.Border.Color1 = System.Drawing.Color.Silver;
                txtNuevoPassword.StateCommon.Border.Color2 = System.Drawing.Color.White;
                txtNuevoPassword.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
                | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
                | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
                txtNuevoPassword.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
                txtNuevoPassword.StateCommon.Border.Rounding = 4;
                txtNuevoPassword.StateCommon.Border.Width = 2;

                txtConfirmarPassword.StateActive.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
                txtConfirmarPassword.StateActive.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
                | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
                | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
                txtConfirmarPassword.StateCommon.Border.Color1 = System.Drawing.Color.Silver;
                txtConfirmarPassword.StateCommon.Border.Color2 = System.Drawing.Color.White;
                txtConfirmarPassword.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
                | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
                | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
                txtConfirmarPassword.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
                txtConfirmarPassword.StateCommon.Border.Rounding = 4;
                txtConfirmarPassword.StateCommon.Border.Width = 2;

                txtPasswordActual.Focus();
            }
            else
            {
                if (ValidateForm())
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

                        if (await usuarioServices.ChangePassword(model))
                        {
                            KryptonMessageBox.Show("Contraseña editada correctamente", ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                            txtPasswordActual.ReadOnly = true;
                            txtPasswordActual.Text = "xxxxxxxxxx";
                            txtNuevoPassword.ReadOnly = true;
                            txtNuevoPassword.ReadOnly = true;
                            txtConfirmarPassword.ReadOnly = true;
                            btnEditarPassword.Text = "Editar";
                        }
                    }
                    catch (Exception ex)
                    {
                        ControlLenguaje.utility.WriteToErrorLog(AppDomain.CurrentDomain.BaseDirectory, ex);
                        KryptonMessageBox.Show(ControlLenguaje.validationMessages.GetString("ErrorInesperado"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }                
            }
        }

        public bool ValidateForm()
        {
            if (txtPasswordActual.Text == "")
            {
                KryptonMessageBox.Show(string.Format(ControlLenguaje.validationMessages.GetString("CampoVacio"), "Contraseña Actual"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (txtNuevoPassword.Text == "")
            {
                KryptonMessageBox.Show(string.Format(ControlLenguaje.validationMessages.GetString("CampoVacio"), "Nueva Contraseña"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (txtNuevoPassword.Text != txtConfirmarPassword.Text)
            {
                KryptonMessageBox.Show("El valor del campo nueva contraseña y confirmar nueva contraseña debe coincidir", ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private void kryptonLabel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtConfirmarPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtNuevoPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtPasswordActual_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarCamposNusuario();
            btnEliminar.Enabled = true;
        }

        private async void btnAgregarNusuario_Click(object sender, EventArgs e)
        {
            if (ValidateFormMisUsuarios())
            {
                if (await usuarioServices.Register(new RegistroUsuarioModel()
                {
                    Correo = txtCorreoNusuario.Text,
                    Password = txtPasswordNusuario.Text,
                    ConfirmaPassword = txtPasswordNusuario2.Text,
                    Rol = RolesUsuario.Usuario.ToString(),
                    IdSuscripcion = LoginModel.IdSuscripcion,
                    IdMedico = LoginModel.Medico.IdMedico
                }))
                {
                    KryptonMessageBox.Show(ControlLenguaje.cadenas.GetString("UsuarioAgregado"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                    misUsuarios.Add(new UsuarioModel()
                    {
                        Correo = txtCorreoNusuario.Text
                    });

                    lstMisUsuarios.Items.Add(txtCorreoNusuario.Text);
                    LimpiarCamposNusuario();
                }
                else
                {
                    KryptonMessageBox.Show(ControlLenguaje.validationMessages.GetString("ErrorInesperado"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public bool ValidateFormMisUsuarios()
        {
            if (txtCorreoNusuario.Text == "")
            {
                KryptonMessageBox.Show(string.Format(ControlLenguaje.validationMessages.GetString("CampoVacio"), "Correo Electronico"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (txtCorreoNusuario.Text != "" && !ControlLenguaje.utility.IsValidEmail(txtCorreoNusuario.Text))
            {
                KryptonMessageBox.Show(ControlLenguaje.validationMessages.GetString("CampoEmail"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (txtPasswordNusuario.Text == "")
            {
                KryptonMessageBox.Show(string.Format(ControlLenguaje.validationMessages.GetString("CampoVacio"), "Contraseña"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (txtPasswordNusuario.Text != txtPasswordNusuario2.Text)
            {
                KryptonMessageBox.Show("Las contraseñas no coinciden", ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        public void LimpiarCamposNusuario()
        {
            txtCorreoNusuario.Text = "";
            txtPasswordNusuario.Text = "";
            txtPasswordNusuario2.Text = "";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCamposNusuario();
        }

        private void kryptonComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void kryptonLabel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void btnAplicarConfSistema_Click(object sender, EventArgs e)
        {
            List<ConfiguracionMedicoModel> listaConfiguracion = new List<ConfiguracionMedicoModel>();

            foreach(dynamic control in kryptonNavigator1.Pages[4].Controls)
            {
                if (control.GetType().ToString() == "ComponentFactory.Krypton.Toolkit.KryptonComboBox")
                {
                    listaConfiguracion.Add(new ConfiguracionMedicoModel()
                    {
                        IdConfiguracionMedico = Convert.ToInt32(control.Name),
                        Medico = LoginModel.Medico,
                        Valor = control.SelectedValue.ToString()
                    });
                }

                if (control.GetType().ToString() == "ComponentFactory.Krypton.Toolkit.KryptonCheckBox")
                {
                    listaConfiguracion.Add(new ConfiguracionMedicoModel()
                    {
                        IdConfiguracionMedico = Convert.ToInt32(control.Name),
                        Medico = LoginModel.Medico,
                        Valor = control.Checked == true ? "true" : "false"
                    });
                }
            }

            if(await configuracionMedicoServices.UpdateConfiguracionMedico(listaConfiguracion))
            {
                KryptonMessageBox.Show(ControlLenguaje.cadenas.GetString("ConfiguracionGuardada"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pageMisUsuarios_Click(object sender, EventArgs e)
        {

        }

        private void kryptonPage1_Load(object sender, EventArgs e)
        {
            
        }

        private void TxtPasswordNusuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void KryptonButton1_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files (JPG,PNG)|*.JPG;*.PNG;";
            openFileDialog1.Multiselect = false;
            openFileDialog1.ShowDialog();            
        }

        private async void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if (openFileDialog1.FileName != "")
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);

                MedicoModel medico = new MedicoModel()
                {

                    IdMedico = LoginModel.Medico.IdMedico,
                    Nombre = LoginModel.Medico.Nombre,
                    Telefono = LoginModel.Medico.Telefono,
                    Especialidad = LoginModel.Medico.Especialidad,
                    Activo = LoginModel.Medico.Activo,
                    Correo = LoginModel.Medico.Correo,
                    Suscripcion = LoginModel.Medico.Suscripcion,
                    CedulaProfesional = LoginModel.Medico.CedulaProfesional
                };

                if (openFileDialog1.FileName != "" && pictureBox1.Image != null)
                {
                    Image img = pictureBox1.Image;
                    MemoryStream mStream = new MemoryStream();
                    img.Save(mStream, img.RawFormat);
                    byte[] bArr = mStream.ToArray();
                    if (logoMedico != null)
                    {
                        medico.Logo = logoMedico;
                    }
                    else
                    {
                        medico.Logo = new ArchivoMedicoModel()
                        {
                            Medico = new MedicoModel() { IdMedico = LoginModel.Medico.IdMedico },
                            TipoArchivo = new TipoArchivoModel() { IdTipoArchivo = 3 },
                            Descripcion = "Logo Medico",
                            Activo = 1
                        };
                    }
                    medico.Logo.Archivo = Convert.ToBase64String(bArr);
                    medico.Logo.ExtensionArchivo = Path.GetExtension(openFileDialog1.FileName);

                    LoginModel.Medico.Logo = medico.Logo;
                }

                await medicoServices.UpdateMedico(medico);
            }
        }

        private void TxtCorreoNusuario_TextChanged(object sender, EventArgs e)
        {
            lstMisUsuarios.SelectedItem = null;
            btnEliminar.Enabled = false;
        }

        private async void BtnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = KryptonMessageBox.Show(ControlLenguaje.cadenas.GetString("ConfirmarEliminarUsuario"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string correo = (string)lstMisUsuarios.SelectedItem;

                if (await usuarioServices.DeleteUser(new UsuarioModel() { Correo = correo }))
                {
                    KryptonMessageBox.Show(ControlLenguaje.cadenas.GetString("UsuarioEliminado"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnEliminar.Enabled = false;
                    lstMisUsuarios.SelectedItem = null;
                    lstMisUsuarios.Items.Remove(correo);
                }
                else
                {
                    KryptonMessageBox.Show(ControlLenguaje.validationMessages.GetString("ErrorInesperado"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void KryptonButton2_Click(object sender, EventArgs e)
        {
            EditorForm ed = new EditorForm();
            ed.Show();
        }
    }
}
