using ControlMedicoConnector.Models;
using ControlMedicoConnector.Paciente;
using ControlMedicoWpf.Utilidades;
using DMSkin.WPF;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for ControlPacientes.xaml
    /// </summary>
    public partial class ControlPacientes : MetroWindow
    {
        PacienteServices services = new PacienteServices();
        // ReporteServices reporteServices = new ReporteServices();

        ResourceManager validationMessages = new ResourceManager("ControlMedicoWinforms.Utilidades.ValidationMessages", Assembly.GetExecutingAssembly());
        Utility utility = new Utility();

        public ControlPacientes()
        {
            InitializeComponent();
        }

        public async void LoadDatos()
        {
            List<PacienteModel> listPacientes = await services.GetPacienteByIdMedico(new PacienteModel() { Medico = LoginModel.Medico });
            dtgPacientes.ItemsSource = listPacientes;

            DataGridTemplateColumn imgColumn = new DataGridTemplateColumn();
            imgColumn.Header = "Activo";

            FrameworkElementFactory imageFactory = new FrameworkElementFactory(typeof(Image));
            imageFactory.SetBinding(Image.SourceProperty, new Binding("../Resources/Images/activo.png"));

            DataTemplate dataTemplate = new DataTemplate();
            dataTemplate.VisualTree = imageFactory;

            imgColumn.CellTemplate = dataTemplate;

            dtgPacientes.Columns.Add(imgColumn);

            dtgPacientes.Columns[0].Header = "Número";
            dtgPacientes.Columns[1].Header = "Nombre";

            dtgPacientes.Columns[2].Header = "Teléfono";

            dtgPacientes.Columns[3].Header = "Estado Civil";

            dtgPacientes.Columns[4].Header = "Identificación";
            dtgPacientes.Columns[16].Header = "Escolaridad";
            dtgPacientes.Columns[17].Header = "Patologia";

            dtgPacientes.Columns[5].Visibility = Visibility.Hidden;
            dtgPacientes.Columns[6].Visibility = Visibility.Hidden;
            dtgPacientes.Columns[9].Visibility = Visibility.Hidden;
            dtgPacientes.Columns[10].Visibility = Visibility.Hidden;
            dtgPacientes.Columns[11].Visibility = Visibility.Hidden;
            dtgPacientes.Columns[13].Visibility = Visibility.Hidden;
            dtgPacientes.Columns[14].Visibility = Visibility.Hidden;

            if (LoginModel.Rol != ComunModel.RolesUsuario.Administrador)
                dtgPacientes.Columns[18].Visibility = Visibility.Hidden;

            dtgPacientes.Columns[7].Header = "Correo";
            dtgPacientes.Columns[8].Header = "Fecha Nacimiento";
            //dtgPacientes.Columns[8].Width = "";

            dtgPacientes.Columns[12].Header = "Lugar Nacimiento";
            dtgPacientes.Columns[12].Width = 200;

            //dtgPacientes.Columns[0].Width = 115;
            //dtgPacientes.Columns[1].Width = 300;
            //dtgPacientes.Columns[2].Width = 115;
            //dtgPacientes.Columns[3].Width = 200;
            //dtgPacientes.Columns[4].Width = 150;
            //dtgPacientes.Columns[5].Width = 115;
            //dtgPacientes.Columns[7].Width = 200;

            dtgPacientes.Columns[16].DisplayIndex = 14;
            dtgPacientes.Columns[17].DisplayIndex = 15;
            dtgPacientes.Columns[15].DisplayIndex = 16;
            //dtgPacientes.Columns[15].Width = 300;
            dtgPacientes.Columns[5].DisplayIndex = 17;

            //dtgPacientes.Columns[0].CellStyle.BasedOn = DataGridViewContentAlignment.MiddleCenter;
            //dtgPacientes.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dtgPacientes.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dtgPacientes.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //dtgPacientes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            for (int i = 0; i <= dtgPacientes.Items.Count - 1; i++)
            {
                dynamic pacienteDtg = dtgPacientes.Items[i];

                if (pacienteDtg.GetType() == typeof(PacienteModel))
                {
                    PatologiaModel patologia = pacienteDtg.Patologia;
                    if (patologia != null)
                        pacienteDtg.PatologiaDescrip = patologia.Descripcion;

                    EscolaridadModel escolaridad = pacienteDtg.Escolaridad;
                    if (escolaridad != null)
                        pacienteDtg.EscolaridadDescrip = escolaridad.Descripcion;

                    //if ((int)dtgPacientes.Rows[i].Cells["Activo"].Value > 0)
                    //{
                    //    ((DataGridViewImageCell)dtgPacientes.Rows[i].Cells["ImagenActivo"]).Value = Properties.Resources.if_status_46254;
                    //}
                }
            }  
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDatos();
        }

        private void dtgPacientes_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            PacienteModel row = (PacienteModel)dtgPacientes.SelectedItems[0];
            lblNombre.Content = row.Nombre;
            lblIdentificacion.Content = row.Identificacion;
            lblTelefono.Content = row.Telefono;
            lblEdoCivil.Content = row.EstadoCivil;
        }

        private void Agregar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            AgregarPaciente cw = new AgregarPaciente(this);
            cw.ShowInTaskbar = false;
            cw.Owner = this;
            cw.Show();
        }
    }
}
