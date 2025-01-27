using ControlMedicoConnector.Catalogo;
using ControlMedicoConnector.Models;
using ControlMedicoConnector.Paciente;
using ControlMedicoWpf.Utilidades;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
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

namespace ControlMedicoWpf.Paciente
{
    /// <summary>
    /// Interaction logic for AgregarPaciente.xaml
    /// </summary>
    public partial class AgregarPaciente : MetroWindow
    {
        ControlPacientes padre;
        PacienteServices services = new PacienteServices();
        CatalogoServices catalogoServices = new CatalogoServices();

        ResourceManager validationMessages = new ResourceManager("ControlMedicoWinforms.Utilidades.ValidationMessages", Assembly.GetExecutingAssembly());
        Utility utility = new Utility();

        public AgregarPaciente(ControlPacientes p)
        {
            padre = p;
            InitializeComponent();
        }


        private async void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                try
                {
                    PacienteModel paciente = new PacienteModel()
                    {
                        IdPaciente = 0,
                        Nombre = txtNombre.Text,
                        Telefono = txtTelefono.Text,
                        Identificacion = txtIdentificacion.Text,
                        EstadoCivil = cmbEstadoCivil.Text,
                        CorreoElectronico = txtCorreo.Text,
                        //FechaNacimiento = dtpFechaNac.Value,
                        Direccion = txtDireccion.Text,
                        Escolaridad = new EscolaridadModel() { IdEscolaridad = (int)cmbEscolaridad.SelectedValue },
                        //Patologia = new PatologiaModel() { IdPatologia = (int)cmbPatologia.SelectedValue },
                        //NombreFamiliar = txtFamiliar.Text,
                        //TelefonoFamiliar = txtTelefonoFamiliar.Text,
                        //Observaciones = txtObservaciones.Text,
                        Medico = LoginModel.Medico
                    };

                    //utility.GoAsync();
                    int accion = await services.AddPaciente(paciente);

                    if (accion > 0)
                    {
                        MessageBox.Show("Paciente agregado correctamente", "Control Médico", MessageBoxButton.OK, MessageBoxImage.Information);
                        padre.LoadDatos();
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    utility.WriteToErrorLog(AppDomain.CurrentDomain.BaseDirectory, ex);
                    MessageBox.Show(validationMessages.GetString("ErrorInesperado"), "Control Médico", MessageBoxButton.OK, MessageBoxImage.Information);                    
                }
            }
        }

        public bool ValidateForm()
        {
            if (txtNombre.Text == "")
            {
                MessageBox.Show(string.Format(validationMessages.GetString("CampoVacio"), "Nombre"), "Control Médico", MessageBoxButton.OK, MessageBoxImage.Information);                
                return false;
            }

            if (txtCorreo.Text != "" && !utility.IsValidEmail(txtCorreo.Text))
            {
                MessageBox.Show(validationMessages.GetString("CampoEmail"), "Control Médico", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            //if (txtTelefonoFamiliar.Text != "" && txtFamiliar.Text == "")
            //{
            //    MessageBox.Show(string.Format(validationMessages.GetString("CampoVacio"), "Familiar de Contacto"), "Control Médico", MessageBoxButton.OK, MessageBoxImage.Information);
            //    return false;
            //}

            return true;
        }

        private async void AgregarPaciente_Loaded(object sender, RoutedEventArgs e)
        {
            //dtpFechaNac.CustomFormat = " ";
            //dtpFechaNac.MaxDate = DateTime.Today;
            //dtpFechaNac.Format = DateTimePickerFormat.Custom;

            txtTelefono.MaxLength = 10;
            //txtMovil.MaxLength = 10;
            //txtTelefonoFamiliar.MaxLength = 10;

            //Obtener escolaridades
            var escolaridades = await catalogoServices.GetAllEscolaridades();
            escolaridades.Add(new EscolaridadModel { IdEscolaridad = 0, Descripcion = "Seleccione" });
            cmbEscolaridad.ItemsSource = escolaridades.OrderBy(x => x.IdEscolaridad).ToList();
            cmbEscolaridad.DisplayMemberPath = "Descripcion";
            //cmbEscolaridad.ValueMember = "IdEscolaridad";

            var estadoCivil = new List<object>();
            estadoCivil.Add(new { Id = 0, Descripcion = "Seleccione" });
            estadoCivil.Add(new { Id = 1, Descripcion = "Casado (a)" });
            estadoCivil.Add(new { Id = 2, Descripcion = "Soltero (a)" });
            cmbEstadoCivil.ItemsSource = estadoCivil.ToList();
            cmbEstadoCivil.DisplayMemberPath = "Descripcion";

            var genero = new List<object>();
            genero.Add(new { Id = 0, Descripcion = "Seleccione" });
            genero.Add(new { Id = 1, Descripcion = "Maculino" });
            genero.Add(new { Id = 2, Descripcion = "Femenino" });
            cmbGenero.ItemsSource = genero.ToList();
            cmbGenero.DisplayMemberPath = "Descripcion";

            //Obtener patologias
            //var patologias = await catalogoServices.GetAllPatologias();
            //patologias.Add(new PatologiaModel { IdPatologia = 0, Descripcion = "Seleccione" });
            //cmbPatologia.DataSource = patologias.OrderBy(x => x.IdPatologia).ToList();
            //cmbPatologia.DisplayMember = "Descripcion";
            //cmbPatologia.ValueMember = "IdPatologia";
        }
    }
}
