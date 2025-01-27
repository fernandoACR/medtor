using ControlMedicoWinForms.Archivo;
using ControlMedicoWinForms.Cita;
using ControlMedicoWinForms.Medico;
using ControlMedicoWinForms.Models;
using ControlMedicoWinForms.Paciente;
using ControlMedicoWinForms.Receta;
using ControlMedicoWinForms.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ControlMedicoWinForms.Models.ComunModel;

namespace ControlMedicoWinForms.Diagnostico
{
    public partial class AgregarDiagnostico : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        ControlDiagnosticos padre;
        DiagnosticoServices diagnosticoServices = new DiagnosticoServices();
        PacienteServices pacienteServices = new PacienteServices();
        MedicoServices medicoServices = new MedicoServices();
        Dictionary<string, List<string>> rutasAdjuntos = new Dictionary<string, List<string>>();
        CitaServices citaServices = new CitaServices();
        List<CitaModel> citas = new List<CitaModel>();

        public AgregarDiagnostico(ControlDiagnosticos p)
        {
            padre = p;
            InitializeComponent();
        }

        private async void AgregarDiagnostico_Load(object sender, EventArgs e)
        {
            this.Font = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);
            this.kryptonGroupBox1.StateCommon.Content.ShortText.Font = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);

            lstArchivosAdjuntos.Controls[0].DoubleClick += lstArchivosAdjuntos_DoubleClick;

            //Obtener pacientes
            var pacientes = new List<PacienteModel>();

            List<object> listaCitaPaciente = new List<object>();

            if (Utility.CheckForInternetConnection())
            {
                try
                {
                    if (LoginModel.Rol == RolesUsuario.Administrador)
                    {
                        pacientes = await pacienteServices.GetAllPacientes();
                    }
                    else
                    {
                        citas = await citaServices.GetCitasByFechaAndIdMedico(new CitaModel() { Medico = new MedicoModel() { IdMedico = LoginModel.Medico.IdMedico }, FechaCitaDesde = DateTime.Now.Date });

                        listaCitaPaciente.Add(new { IdPaciente = 0, NombreCompleto = "Seleccione" });

                        foreach (CitaModel cita in citas)
                        {
                            string descripcion = "";

                            if (cita.IdCita <= 0)
                            {
                                descripcion = cita.Paciente.NombreCompleto + " " + "(Sin cita)";
                            }
                            else
                            {
                                descripcion = cita.Paciente.NombreCompleto + " (Cita a las " + cita.FechaCitaDesde.ToString("hh:mm tt") + ")";
                            }

                            listaCitaPaciente.Add(new { IdPaciente = cita.Paciente.IdPaciente, NombreCompleto = descripcion });
                        }
                    }

                    cmbPaciente.DataSource = listaCitaPaciente;
                    cmbPaciente.DisplayMember = "NombreCompleto";
                    cmbPaciente.ValueMember = "IdPaciente";
                    cmbPaciente.AutoCompleteMode = AutoCompleteMode.Suggest;
                    cmbPaciente.AutoCompleteSource = AutoCompleteSource.ListItems;

                    //Obtener Medicos
                    if (LoginModel.Medico != null)
                    {
                        lblNombreMedico.Visible = false;
                        cmbMedico.Visible = false;
                        label6.Location = new Point(txtAlergias.Location.X, 180);
                        txtDescripcion.Location = new Point(txtAlergias.Location.X, 204);
                    }
                    else
                    {
                        var medicos = await medicoServices.GetAllMedicos();
                        medicos.Add(new MedicoModel { IdMedico = 0, Nombre = "Seleccione" });
                        cmbMedico.DataSource = medicos.OrderBy(x => x.IdMedico).ToList();
                        cmbMedico.DisplayMember = "Nombre";
                        cmbMedico.ValueMember = "IdMedico";
                    }
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

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                try
                {
                    btnAgregar.Enabled = false;
                    btnCancelar.Enabled = false;

                    CitaModel cita = citas.Find(x => x.Paciente.IdPaciente == (int)cmbPaciente.SelectedValue);

                    if(cita.IdCita <= 0)
                    {
                        CitaModel nuevaCita = new CitaModel()
                        {
                            IdCita = 0,
                            Medico = new MedicoModel() { IdMedico = cmbMedico.Visible ? (int)cmbMedico.SelectedValue : LoginModel.Medico.IdMedico },
                            Paciente = new PacienteModel() { IdPaciente = (int)cmbPaciente.SelectedValue },
                            FechaCitaDesde = DateTime.Now,
                            FechaCitaHasta = DateTime.Now.AddMinutes(15),
                            Comentarios = txtDescripcion.Text,
                            Titulo = "Cita dia " + DateTime.Now.Date.ToString("dd/MM/yyyy"),
                            EstatusCita = new EstatusCitaModel() { IdEstatusCita = (int)EstatusCitaEnum.AGE },
                            TipoCita = new TipoCitaModel() { IdTipoCita = 1 }
                        };

                        int idCita = await citaServices.AddCita(nuevaCita);

                        nuevaCita.IdCita = idCita;

                        cita = nuevaCita;
                    }
                    
                    DiagnosticoModel diagnostico = new DiagnosticoModel()
                    {
                        Medico = new MedicoModel() { IdMedico = cmbMedico.Visible ? (int)cmbMedico.SelectedValue : LoginModel.Medico.IdMedico },
                        Paciente = new PacienteModel() { IdPaciente = (int)cmbPaciente.SelectedValue },
                        Descripcion = txtDescripcion.Text,
                        Alergias = txtAlergias.Text,
                        Altura = txtAltura.Value,
                        Peso = txtPeso.Value,
                        Cita = cita
                    };

                    if (rutasAdjuntos.Count > 0)
                    {
                        List<ArchivoDiagnosticoModel> listAdjuntos = new List<ArchivoDiagnosticoModel>();

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

                            listAdjuntos.Add(new ArchivoDiagnosticoModel()
                            {
                                Diagnostico = new DiagnosticoModel() { IdDiagnostico = diagnostico.IdDiagnostico },
                                TipoArchivo = new TipoArchivoModel() { IdTipoArchivo = Convert.ToInt32(adjunto.Value[1]) },
                                Descripcion = adjunto.Key,
                                Archivo = Convert.ToBase64String(file),
                                ExtensionArchivo = Path.GetExtension(adjunto.Value[0]),
                                Activo = 1
                            });
                        }

                        diagnostico.ArchivosAdjuntos = listAdjuntos;
                    }

                    int accion = await diagnosticoServices.AddDiagnostico(diagnostico);                               

                    if (accion > 0)
                    {
                        DialogResult result = ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.cadenas.GetString("DiagnosticoAgregado"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            ControlRecetas controlRecetas = new ControlRecetas();
                            AgregarReceta f = new AgregarReceta(controlRecetas, new DiagnosticoModel() { IdDiagnostico = accion, Paciente = new PacienteModel() { IdPaciente = (int)cmbPaciente.SelectedValue } });
                            f.Show(controlRecetas);
                            this.Close();
                        }

                        padre.Cargar();

                        btnAgregar.Enabled = true;
                        btnCancelar.Enabled = true;

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

            if (LoginModel.Medico == null)
            {
                if ((int)cmbMedico.SelectedValue == 0)
                {
                    ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(string.Format(ControlLenguaje.validationMessages.GetString("CampoVacio"), ControlLenguaje.cadenas.GetString("TextoCampoMedico")), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            if (txtDescripcion.Text == "")
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(string.Format(ControlLenguaje.validationMessages.GetString("CampoVacio"), ControlLenguaje.cadenas.GetString("TextoCampoDescripcion")), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.cadenas.GetString("ConfirmarCancelar"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnAdjuntar_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            txtNombreArchivo.Text = openFileDialog1.FileName;
            AgregarArchivo f = new AgregarArchivo(this);
            f.Show(this);
        }

        private void txtNombreArchivo_Click(object sender, EventArgs e)
        {
            
        }

        private void txtNombreArchivo_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtNombreArchivo_MouseClick(object sender, MouseEventArgs e)
        {
        }

        public void AdjuntarArchivo(string descripcion, int tipoArchivo)
        {
            lstArchivosAdjuntos.Items.Add(descripcion);
            rutasAdjuntos.Add(descripcion, new List<string>() { txtNombreArchivo.Text, tipoArchivo.ToString() });
            txtNombreArchivo.Text = "";
        }

        private void btnAgregarAdjunto_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void lstArchivosAdjuntos_DoubleClick(object sender, EventArgs e)
        {
            string adjuntoSeleccionado = (string)lstArchivosAdjuntos.SelectedItem;
            if (adjuntoSeleccionado != "" && adjuntoSeleccionado != null)
            {
                Process.Start(rutasAdjuntos[adjuntoSeleccionado].FirstOrDefault());
            }
        }

        private void lstArchivosAdjuntos_Click(object sender, EventArgs e)
        {

        }

        private void lstArchivosAdjuntos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }

        private void lstArchivosAdjuntos_SelectedIndexChanged(object sender, EventArgs e)
        {

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
    }
}
