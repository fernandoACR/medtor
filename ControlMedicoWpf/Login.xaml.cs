using ControlMedicoConnector.Models;
using ControlMedicoConnector.Medico;
using ControlMedicoConnector.Services;
using ControlMedicoWpf.Utilidades;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static ControlMedicoConnector.Models.ComunModel;
using ControlMedicoConnector.Models.Login;

namespace ControlMedicoWpf
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : MetroWindow
    {
        UsuarioServices services = new UsuarioServices();
        MainWindow mainWindow = new MainWindow();
        Utility utility = new Utility();

        public Login()
        {
            InitializeComponent();
        }

        private async void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                // new Utility().GoAsync();

                try
                {
                    LoginResponse loginResponse = await services.Login(txtUsuario.Text, txtContraseña.Text);
                    if (loginResponse != null)
                    {
                        LoginModel.UserId = loginResponse.UserId;
                        LoginModel.Token = loginResponse.access_token;
                        LoginModel.UserName = txtUsuario.Text;
                        LoginModel.Rol = (RolesUsuario)loginResponse.RolId;
                        LoginModel.IdSuscripcion = loginResponse.SuscriptionId;

                        if (LoginModel.Rol == ComunModel.RolesUsuario.Medico)
                        {
                            MedicoServices medicoServices = new MedicoServices();
                            LoginModel.Medico = await medicoServices.GetMedicoById(new MedicoModel() { IdMedico = loginResponse.IdMedico });
                        }

                        this.Hide();
                        mainWindow.Show();
                    }
                }
                catch (Exception ex)
                {
                    utility.WriteToErrorLog(AppDomain.CurrentDomain.BaseDirectory, ex);
                    MessageBox.Show("Ocurrió un error inesperado, por favor contacte con el area de soporte", "Control Médico", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public bool ValidateForm()
        {
            if (txtUsuario.Text == "")
            {
                MessageBox.Show("Por favor ingrese el nombre de usuario", "Control Médico", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            if (txtContraseña.Text == "")
            {
                MessageBox.Show("Por favor ingrese la contraseña", "Control Médico", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            return true;
        }
    }
}
