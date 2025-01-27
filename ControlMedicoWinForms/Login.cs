using System;
using System.Windows.Forms;
using ControlMedicoWinForms.Services;
using ControlMedicoWinForms.Models;
using ControlMedicoWinForms.Models.Login;
using static ControlMedicoWinForms.Models.ComunModel;
using ControlMedicoWinForms.Utilidades;
using ControlMedicoWinForms.Medico;
using ControlMedicoWinForms.Suscripcion;
using ControlMedicoWinForms.ConfiguracionMedico;

namespace ControlMedicoWinForms
{
    public partial class Login : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        UsuarioServices services = new UsuarioServices();
        SuscripcionServices suscripcionServices = new SuscripcionServices();
        LoginResponse loginResponse = null;
        MainForm mainForm = new MainForm();

        public Login()
        {
            InitializeComponent();
        }        

        private void button1_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                btnLogin.Enabled = false;
                progressBar1.Show();
                backgroundWorker1.RunWorkerAsync();
            }
            //if (ValidateForm())
            //{
            //    try
            //    {
            //        LoginResponse loginResponse = await services.Login(txtUsuario.Text, txtPassword.Text);
            //        if (loginResponse != null)
            //        {
            //            LoginModel.UserId = loginResponse.UserId;
            //            LoginModel.Token = loginResponse.access_token;
            //            LoginModel.UserName = txtUsuario.Text;
            //            LoginModel.Rol = (RolesUsuario)loginResponse.RolId;                        
            //            LoginModel.IdSuscripcion = loginResponse.SuscriptionId;

            //            if (loginResponse.IdMedico > 0)
            //            {
            //                MedicoServices medicoServices = new MedicoServices();
            //                ConfiguracionMedicoServices configuracionMedicoServices = new ConfiguracionMedicoServices();

            //                MedicoModel medico = new MedicoModel()
            //                {
            //                    IdMedico = loginResponse.IdMedico
            //                };

            //                LoginModel.Medico = await medicoServices.GetMedicoById(medico);
            //                LoginModel.listaConfiguracionMedico = await configuracionMedicoServices.GetConfiguracionMedicoByIdMedico(new ConfiguracionMedicoModel() { Medico = medico });
            //            }

            //            LoginModel.Suscripcion = await suscripcionServices.GetSuscripcionById(new SuscripcionModel() { IdSuscriptor = LoginModel.IdSuscripcion });

            //            btnLogin.Values.Image = Properties.Resources.btnIniciarSesion1;
            //            btnLogin.Refresh();
            //            System.Threading.Thread.Sleep(5000);
            //            this.Hide();
            //            mainForm.Show();
            //            btnLogin.Values.Image = Properties.Resources.btnIniciarSesion2;
            //        }
            //        else
            //        {
            //            ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.validationMessages.GetString("LoginIncorrecto"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        ControlLenguaje.utility.WriteToErrorLog(AppDomain.CurrentDomain.BaseDirectory, ex);

            //        if (!Utility.CheckForInternetConnection())
            //        {
            //            ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.validationMessages.GetString("SinConexion"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        }
            //        else
            //        {
            //            ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.validationMessages.GetString("ErrorInesperado"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //}
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.Font = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);
#if DEBUG
            //Admin
            //txtUsuario.Text = "fcespedes@mail.com";
            //txtPassword.Text = "123Dr65.";

            //Medico
            //txtUsuario.Text = "luis_alonso@outlook.com";
            //txtPassword.Text = "000AAbb.";

            //Medico
            //txtUsuario.Text = "fcespedes2625@gmail.com";
            //txtPassword.Text = "000AAbb.";

            //Medico
            txtUsuario.Text = "cindye@mail.com";
            txtPassword.Text = "000AAbb.";

            //Medico
            //txtUsuario.Text = "israell@mail.com";
            //txtPassword.Text = "000AAbb.";
#endif
        }

        public bool ValidateForm()
        {
            if(txtUsuario.Text == "")
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show("Por favor ingrese el nombre de usuario", ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (txtPassword.Text == "")
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show("Por favor ingrese la contraseña", ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void ProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void BackgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (ValidateForm())
            {
                try
                {
                    loginResponse = services.Login(txtUsuario.Text, txtPassword.Text).Result;
                    if (loginResponse != null)
                    {
                        LoginModel.UserId = loginResponse.UserId;
                        LoginModel.Token = loginResponse.access_token;
                        LoginModel.UserName = txtUsuario.Text;
                        LoginModel.Rol = (RolesUsuario)loginResponse.RolId;
                        LoginModel.IdSuscripcion = loginResponse.SuscriptionId;

                        if (loginResponse.IdMedico > 0)
                        {
                            MedicoServices medicoServices = new MedicoServices();
                            ConfiguracionMedicoServices configuracionMedicoServices = new ConfiguracionMedicoServices();

                            MedicoModel medico = new MedicoModel()
                            {
                                IdMedico = loginResponse.IdMedico
                            };

                            LoginModel.Medico = medicoServices.GetMedicoById(medico).Result;

                            LoginModel.listaConfiguracionMedico = configuracionMedicoServices.GetConfiguracionMedicoByIdMedico(new ConfiguracionMedicoModel() { Medico = medico }).Result;
                            ControlMedicoConnector.Models.LoginModel.Medico = new ControlMedicoConnector.Models.MedicoModel() { IdMedico = LoginModel.Medico.IdMedico };
                            ControlMedicoConnector.Models.LoginModel.Token = LoginModel.Token;
                        }

                        LoginModel.Suscripcion = suscripcionServices.GetSuscripcionById(new SuscripcionModel() { IdSuscriptor = LoginModel.IdSuscripcion }).Result;
                        
                    }
                    else
                    {
                        ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.validationMessages.GetString("LoginIncorrecto"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (Exception ex)
                {
                    ControlLenguaje.utility.WriteToErrorLog(AppDomain.CurrentDomain.BaseDirectory, ex);

                    if (!Utility.CheckForInternetConnection())
                    {
                        ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.validationMessages.GetString("SinConexion"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.validationMessages.GetString("ErrorInesperado"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (loginResponse != null)
            {
                progressBar1.Hide();
                btnLogin.Values.Image = Properties.Resources.btnIniciarSesion1;
                btnLogin.Refresh();
                this.Hide();
                mainForm.Show();
                btnLogin.Values.Image = Properties.Resources.btnIniciarSesion2;
                btnLogin.Enabled = true;
            }
            else
            {
                btnLogin.Enabled = true;
                progressBar1.Hide();
            }
        }

        private void BackgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
        }
    }
}
