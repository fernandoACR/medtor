using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlMedicoWinForms.Catalogo;
using ControlMedicoWinForms.Medico;
using ControlMedicoWinForms.Paciente;
using ControlMedicoWinForms.Models;
using ControlMedicoWinForms.Utilidades;
using System.Resources;
using System.Reflection;
using ControlMedicoWinForms.Diagnostico;
using ControlMedicoWinForms.Cliente;
using System.IO;
using System.Diagnostics;
using ControlMedicoWinForms.Archivo;
using ControlMedicoWinForms.Reportes;
using static ControlMedicoWinForms.Models.ComunModel;

namespace ControlMedicoWinForms.Orden
{
    public partial class AgregarOrden : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        ControlOrdenes padre;
        OrdenServices ordenServices = new OrdenServices();
        PacienteServices pacienteServices = new PacienteServices();
        MedicoServices medicoServices = new MedicoServices();
        CatalogoServices catalogoServices = new CatalogoServices();
        DiagnosticoServices diagnosticoServices = new DiagnosticoServices();
        ClienteServices clienteServices = new ClienteServices();
        ReporteServices reporteServices = new ReporteServices();
        Dictionary<string, List<string>> rutasAdjuntos = new Dictionary<string, List<string>>();

        public AgregarOrden(ControlOrdenes p)
        {
            padre = p;
            InitializeComponent();
        }

        private async void AgregarOrden_Load(object sender, EventArgs e)
        {
            this.Font = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);

            this.kryptonGroupBox1.StateCommon.Content.ShortText.Font = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);
            this.kryptonGroupBox2.StateCommon.Content.ShortText.Font = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);
            this.kryptonGroupBox3.StateCommon.Content.ShortText.Font = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);

            lstArchivosAdjuntos.Controls[0].DoubleClick += lstArchivosAdjuntos_DoubleClick;

            this.Width = 912;
            this.Height = 623;

            //Obtener clientes
            var clientes = new List<ClienteModel>();

            //Obtener pacientes
            var pacientes = new List<PacienteModel>();

            if (Utility.CheckForInternetConnection())
            {
                try
                {
                    //Obtener Medicos
                    var medicos = await medicoServices.GetMedicoByIdSuscripcion(new MedicoModel() { Suscripcion = new SuscripcionModel() { IdSuscriptor = LoginModel.IdSuscripcion } });

                    if (LoginModel.Medico == null)
                    {
                        pacientes = await pacienteServices.GetAllPacientes();

                        medicos.Add(new MedicoModel { IdMedico = 0, Nombre = "Seleccione" });

                        cmbMedicoEntrega.DataSource = medicos.OrderBy(x => x.IdMedico).ToList();
                        cmbMedicoEntrega.DisplayMember = "Nombre";
                        cmbMedicoEntrega.ValueMember = "IdMedico";
                        cmbMedicoEntrega.DropDownStyle = ComboBoxStyle.DropDown;
                        cmbMedicoEntrega.AutoCompleteMode = AutoCompleteMode.Suggest;
                        cmbMedicoEntrega.AutoCompleteSource = AutoCompleteSource.ListItems;

                        cmbMedicoRecibe.DataSource = medicos.OrderBy(x => x.IdMedico).ToList();
                        cmbMedicoRecibe.DisplayMember = "Nombre";
                        cmbMedicoRecibe.ValueMember = "IdMedico";
                        cmbMedicoRecibe.DropDownStyle = ComboBoxStyle.DropDown;
                        cmbMedicoRecibe.AutoCompleteMode = AutoCompleteMode.Suggest;
                        cmbMedicoRecibe.AutoCompleteSource = AutoCompleteSource.ListItems;
                    }
                    else
                    {
                        clientes = await clienteServices.GetAllClientes();
                        pacientes = await pacienteServices.GetPacienteByIdMedico(new PacienteModel() { Medico = new MedicoModel() { IdMedico = LoginModel.Medico.IdMedico } });

                        lblMedicoEntrega.Visible = false;
                        cmbMedicoEntrega.Visible = false;
                        medicos.Add(new MedicoModel { IdMedico = 0, Nombre = "Seleccione" });
                        cmbMedicoRecibe.DataSource = medicos.Where(x => x.IdMedico != LoginModel.Medico.IdMedico).OrderBy(x => x.IdMedico).ToList();
                        cmbMedicoRecibe.DisplayMember = "Nombre";
                        cmbMedicoRecibe.ValueMember = "IdMedico";
                    }

                    pacientes.Add(new PacienteModel { IdPaciente = 0, NombreCompleto = "Seleccione" });
                    cmbPaciente.DataSource = pacientes.OrderBy(x => x.IdPaciente).ToList();
                    cmbPaciente.DisplayMember = "NombreCompleto";
                    cmbPaciente.ValueMember = "IdPaciente";
                    cmbPaciente.DropDownStyle = ComboBoxStyle.DropDown;
                    cmbPaciente.AutoCompleteMode = AutoCompleteMode.Suggest;
                    cmbPaciente.AutoCompleteSource = AutoCompleteSource.ListItems;

                    //Obtener Especimen
                    var especimenes = await catalogoServices.GetEspecimenesByIdMedicoAndActivo(new EspecimenModel() { Medico = LoginModel.Medico, Activo = 1 });
                    especimenes.Add(new EspecimenModel { IdEspecimen = 0, Descripcion = "Seleccione" });
                    cmbEspecimen.DataSource = especimenes.OrderBy(x => x.IdEspecimen).ToList();
                    cmbEspecimen.DisplayMember = "Descripcion";
                    cmbEspecimen.ValueMember = "IdEspecimen";

                    clientes.ForEach(x => x.IdSuscripcion = x.Suscripcion.IdSuscriptor);
                    clientes.Add(new ClienteModel { IdSuscripcion = 0, Nombre = "Seleccione" });
                    cmbCliente.DataSource = clientes.OrderBy(x => x.IdCliente).ToList();
                    cmbCliente.DisplayMember = "Nombre";
                    cmbCliente.ValueMember = "IdSuscripcion";
                }
                catch (Exception ex)
                {
                    ControlLenguaje.utility.WriteToErrorLog(AppDomain.CurrentDomain.BaseDirectory, ex);

                    if (!Utility.CheckForInternetConnection())
                    {
                        ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.validationMessages.GetString("SinConexion"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                    }
                    else
                    {
                        ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.validationMessages.GetString("ErrorInesperado"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.validationMessages.GetString("SinConexion"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.cadenas.GetString("ConfirmarCancelar"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                try
                {
                    btnAgregar.Enabled = false;
                    btnCancelar.Enabled = false;

                    OrdenModel orden = new OrdenModel()
                    {
                        MedicoEntrega = new MedicoModel() { IdMedico = cmbMedicoEntrega.Visible ? (int)cmbMedicoEntrega.SelectedValue : LoginModel.Medico.IdMedico },
                        MedicoRecepcion = new MedicoModel () { IdMedico = (int)cmbMedicoRecibe.SelectedValue },
                        Diagnostico = new DiagnosticoModel() {IdDiagnostico = (int)cmbDiagnostico.SelectedValue },
                        Especimen = new EspecimenModel() { IdEspecimen = (int)cmbEspecimen.SelectedValue },
                        Paciente = new PacienteModel() { IdPaciente = (int)cmbPaciente.SelectedValue },
                        Observaciones = txtObservaciones.Text,
                        Pagado = 0,
                        Activo = 1,
                        Monto = txtPrecio.Value,
                        FechaRecepcion = null, 
                        IdSuscripcion = (int)cmbCliente.SelectedValue,
                        CorreoPersonaRecepcion = txtCorreoRecepcion.Text,
                        MovilPersonaRecepcion = txtMovilRecepcion.Text
                    };

                    if (rutasAdjuntos.Count > 0)
                    {
                        List<ArchivoOrdenModel> listAdjuntos = new List<ArchivoOrdenModel>();

                        foreach (var adjunto in rutasAdjuntos)
                        {
                            byte[] file;
                            using (var stream = new FileStream(adjunto.Value[0], FileMode.Open, FileAccess.Read))
                            {
                                using (var reader = new BinaryReader(stream))
                                {
                                    file = reader.ReadBytes((int)stream.Length);
                                }
                            }

                            listAdjuntos.Add(new ArchivoOrdenModel()
                            {
                                Orden = new OrdenModel() { IdOrden = orden.IdOrden },
                                TipoArchivo = new TipoArchivoModel() { IdTipoArchivo = Convert.ToInt32(adjunto.Value[1]) },
                                Descripcion = adjunto.Key,
                                Archivo = Convert.ToBase64String(file),
                                ExtensionArchivo = Path.GetExtension(adjunto.Value[0]),
                                Activo = 1
                            });
                        }

                        orden.ArchivosAdjuntos = listAdjuntos;
                    }

                    int accion = await ordenServices.AddOrden(orden);

                    if (accion > 0)
                    {
                        DialogResult result = ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.cadenas.GetString("ConfirmarImprimirOrden"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            WebViewer webViewer = new WebViewer(reporteServices.PrintOrdenByIdOrden(new OrdenModel() { IdOrden = accion }));
                            webViewer.Show();
                        }
                        else
                        {
                            ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.cadenas.GetString("OrdenAgregada"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        btnAgregar.Enabled = true;
                        btnCancelar.Enabled = true;
                        padre.Cargar();
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    ControlLenguaje.utility.WriteToErrorLog(AppDomain.CurrentDomain.BaseDirectory, ex);
                    ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.validationMessages.GetString("ErrorInesperado"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnAgregar.Enabled = true;
                    btnCancelar.Enabled = true;
                }
            }
        }

        public bool ValidateForm()
        {
            if (cmbPaciente.SelectedValue == null)
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(string.Format(ControlLenguaje.validationMessages.GetString("CampoVacio"), ControlLenguaje.cadenas.GetString("TextoCampoPaciente")), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if ((int)cmbPaciente.SelectedValue == 0)
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(string.Format(ControlLenguaje.validationMessages.GetString("CampoVacio"), ControlLenguaje.cadenas.GetString("TextoCampoPaciente")), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (cmbMedicoEntrega.Visible)
            {
                if ((int)cmbMedicoEntrega.SelectedValue == 0)
                {
                    ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(string.Format(ControlLenguaje.validationMessages.GetString("CampoVacio"), ControlLenguaje.cadenas.GetString("TextoCampoMedico")), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            if ((int)cmbEspecimen.SelectedValue == 0)
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(string.Format(ControlLenguaje.validationMessages.GetString("CampoVacio"), ControlLenguaje.cadenas.GetString("TextoCampoEspecimen")), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private void dtpFechaRecepcion_ValueChanged(object sender, EventArgs e)
        {
            //dtpFechaRecepcion.CustomFormat = "dd/MM/yyyy";
        }

        private async void cmbPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Obtener Diagnosticos
            if (cmbPaciente.SelectedIndex > 0)
            {
                var diagnosticos = await diagnosticoServices.GetDiagnosticoByIdPaciente(new DiagnosticoModel() {Paciente = new PacienteModel() {IdPaciente = (int)cmbPaciente.SelectedValue } });
                diagnosticos.Add(new DiagnosticoModel { IdDiagnostico = 0, Descripcion = "Seleccione" });
                cmbDiagnostico.DataSource = diagnosticos.OrderBy(x => x.IdDiagnostico).ToList();
                cmbDiagnostico.DisplayMember = "Descripcion";
                cmbDiagnostico.ValueMember = "IdDiagnostico";
            }
        }

        private void cmbMedicoRecibe_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtPersonaRecibe_KeyUp(object sender, KeyEventArgs e)
        {
            if(txtPersonaRecibe.Text != "")
            {
                cmbMedicoRecibe.SelectedIndex = 0;
            }
        }

        private async void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Obtener Medicos
            if (cmbCliente.SelectedIndex > 0)
            {
                var medicos = await medicoServices.GetMedicoByIdSuscripcion(new MedicoModel() { Suscripcion = new SuscripcionModel() { IdSuscriptor = (int)cmbCliente.SelectedValue } });
                medicos.Add(new MedicoModel { IdMedico = 0, Nombre = "Seleccione" });
                cmbMedicoRecibe.DataSource = medicos.OrderBy(x => x.IdMedico).ToList();
                cmbMedicoRecibe.DisplayMember = "Nombre";
                cmbMedicoRecibe.ValueMember = "IdMedico";
                cmbMedicoRecibe.Enabled = true;

                txtPersonaRecibe.Text = "";
                txtPersonaRecibe.Enabled = false;
                txtCorreoRecepcion.Enabled = false;
                txtMovilRecepcion.Enabled = false;
            }
            else
            {
                cmbMedicoRecibe.Enabled = false;
                cmbMedicoRecibe.SelectedIndex = 0;
                txtPersonaRecibe.Text = "";
                txtPersonaRecibe.Enabled = true;
                txtCorreoRecepcion.Enabled = true;
                txtMovilRecepcion.Enabled = true;
            }
        }

        private void btnAgregarAdjunto_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void btnQuitarAdjunto_Click(object sender, EventArgs e)
        {
            string adjuntoSeleccionado = (string)lstArchivosAdjuntos.SelectedItem;
            if (adjuntoSeleccionado != "" && adjuntoSeleccionado != null)
            {
                lstArchivosAdjuntos.Items.Remove(adjuntoSeleccionado);
                rutasAdjuntos.Remove(adjuntoSeleccionado);
                txtNombreArchivo.Text = "";
            }
        }

        private void lstArchivosAdjuntos_DoubleClick(object sender, EventArgs e)
        {
            string adjuntoSeleccionado = (string)lstArchivosAdjuntos.SelectedItem;
            if (adjuntoSeleccionado != "" && adjuntoSeleccionado != null)
            {
                Process.Start(rutasAdjuntos[adjuntoSeleccionado].FirstOrDefault());
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            txtNombreArchivo.Text = openFileDialog1.FileName;
            AgregarArchivo f = new AgregarArchivo(this);
            f.Show(this);
        }

        public void AdjuntarArchivo(string descripcion, int tipoArchivo)
        {
            lstArchivosAdjuntos.Items.Add(descripcion);
            rutasAdjuntos.Add(descripcion, new List<string>() { txtNombreArchivo.Text, tipoArchivo.ToString() });
            txtNombreArchivo.Text = "";
        }
    }
}
