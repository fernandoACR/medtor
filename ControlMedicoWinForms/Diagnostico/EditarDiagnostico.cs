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
    public partial class EditarDiagnostico : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        ControlDiagnosticos padre;
        int id;
        DiagnosticoServices diagnosticoServices = new DiagnosticoServices();
        PacienteServices pacienteServices = new PacienteServices();
        MedicoServices medicoServices = new MedicoServices();
        Dictionary<string, List<string>> rutasAdjuntos = new Dictionary<string, List<string>>();
        List<ArchivoDiagnosticoModel> archivosAdjuntos = new List<ArchivoDiagnosticoModel>();
        CitaServices citaServices = new CitaServices();
        List<CitaModel> citas = new List<CitaModel>();

        public EditarDiagnostico(int idDiagnostico, ControlDiagnosticos p)
        {
            padre = p;
            id = idDiagnostico;
            InitializeComponent();
        }

        private async void EditarDiagnostico_Load(object sender, EventArgs e)
        {
            this.Font = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);
            this.kryptonGroupBox1.StateCommon.Content.ShortText.Font = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);

            if (Utility.CheckForInternetConnection())
            {
                try
                {
                    cmbPaciente.Enabled = false;
                    txtPeso.Enabled = false;
                    txtAltura.Enabled = false;
                    txtAlergias.Enabled = false;
                    cmbMedico.Enabled = false;
                    txtDescripcion.Enabled = false;
                    btnQuitarAdjunto.Enabled = false;

                    lstArchivosAdjuntos.Controls[0].DoubleClick += lstArchivosAdjuntos_DoubleClick;

                    DiagnosticoModel diagnostico = await diagnosticoServices.GetDiagnosticoById(new DiagnosticoModel() { IdDiagnostico = id });

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

                    //Obtener pacientes
                    var pacientes = new List<PacienteModel>();

                    List<object> listaCitaPaciente = new List<object>();

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
                                descripcion = cita.Paciente.NombreCompleto + " (Cita a las " + cita.FechaCitaDesde.ToString("HH:mm") + ")";
                            }

                            listaCitaPaciente.Add(new { IdPaciente = cita.Paciente.IdPaciente, NombreCompleto = descripcion });
                        }
                    }

                    cmbPaciente.DataSource = listaCitaPaciente;
                    cmbPaciente.DisplayMember = "NombreCompleto";
                    cmbPaciente.ValueMember = "IdPaciente";
                    cmbPaciente.DropDownStyle = ComboBoxStyle.DropDown;
                    cmbPaciente.AutoCompleteMode = AutoCompleteMode.Suggest;
                    cmbPaciente.AutoCompleteSource = AutoCompleteSource.ListItems;

                    if (diagnostico != null)
                    {
                        cmbMedico.SelectedValue = diagnostico.Medico.IdMedico;
                        cmbPaciente.SelectedValue = diagnostico.Paciente.IdPaciente;
                        txtDescripcion.Text = diagnostico.Descripcion;
                        txtPeso.Value = (decimal)diagnostico.Peso;
                        txtAltura.Value = (decimal)diagnostico.Altura;
                        txtAlergias.Text = diagnostico.Alergias;
                        chkActivo.Checked = Convert.ToBoolean(diagnostico.Activo);

                        if (diagnostico.ArchivosAdjuntos != null)
                        {
                            if (diagnostico.ArchivosAdjuntos.Count > 0)
                            {
                                archivosAdjuntos = diagnostico.ArchivosAdjuntos;

                                foreach (ArchivoDiagnosticoModel archivo in diagnostico.ArchivosAdjuntos)
                                {
                                    rutasAdjuntos.Add(archivo.Descripcion, new List<string>()
                                {
                                    "",
                                    archivo.TipoArchivo.Descripcion,
                                    archivo.Codigo.ToString(),
                                    archivo.Archivo,
                                    archivo.ExtensionArchivo
                                });

                                    lstArchivosAdjuntos.Items.Add(archivo.Descripcion);
                                }
                            }
                        }
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.cadenas.GetString("ConfirmarCancelar"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            if(ValidateForm())
            {
                try
                {
                    btnAgregar.Enabled = false;
                    btnCancelar.Enabled = false;

                    DiagnosticoModel diagnostico = new DiagnosticoModel()
                    {
                        IdDiagnostico = id,
                        Medico = new MedicoModel() { IdMedico = cmbMedico.Visible ? (int)cmbMedico.SelectedValue : LoginModel.Medico.IdMedico },
                        Paciente = new PacienteModel() { IdPaciente = (int)cmbPaciente.SelectedValue },
                        Descripcion = txtDescripcion.Text,
                        Alergias = txtAlergias.Text,
                        Altura = txtAltura.Value,
                        Peso = txtPeso.Value,
                        Activo = Convert.ToInt32(chkActivo.Checked)
                    };

                    if (rutasAdjuntos.Count > 0)
                    {
                        List<ArchivoDiagnosticoModel> listAdjuntos = new List<ArchivoDiagnosticoModel>();
                        foreach (var adjunto in rutasAdjuntos)
                        {
                            byte[] file;
                            string codigo = "";
                            if (adjunto.Value[0] != "")
                            {
                                using (var stream = new FileStream(adjunto.Value[0], FileMode.Open, FileAccess.Read))
                                {
                                    using (var reader = new BinaryReader(stream))
                                    {
                                        file = reader.ReadBytes((int)stream.Length);
                                    }
                                }
                            }
                            else
                            {
                                file = Convert.FromBase64String(adjunto.Value[3]);
                                codigo = adjunto.Value[2];
                            }

                            listAdjuntos.Add(new ArchivoDiagnosticoModel()
                            {
                                Diagnostico = new DiagnosticoModel() { IdDiagnostico = diagnostico.IdDiagnostico },
                                TipoArchivo = new TipoArchivoModel() { IdTipoArchivo = Convert.ToInt32(adjunto.Value[1]) },
                                Descripcion = adjunto.Key,
                                Archivo = Convert.ToBase64String(file),
                                ExtensionArchivo = Path.GetExtension(adjunto.Value[0]),
                                Activo = 1,
                                Codigo = codigo != "" ? Guid.Parse(codigo) : Guid.Empty
                            });
                        }

                        diagnostico.ArchivosAdjuntos = listAdjuntos;
                    }

                    if (await diagnosticoServices.UpdateDiagnostico(diagnostico))
                    {

                        DialogResult result = ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.cadenas.GetString("DiagnosticoEditado"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            ControlRecetas controlRecetas = new ControlRecetas();
                            AgregarReceta f = new AgregarReceta(controlRecetas, new DiagnosticoModel() { IdDiagnostico = diagnostico.IdDiagnostico, Paciente = new PacienteModel() { IdPaciente = (int)cmbPaciente.SelectedValue } });
                            f.Show(controlRecetas);
                            this.Close();
                        }

                        btnAgregar.Enabled = true;
                        btnCancelar.Enabled = true;
                        padre.Cargar();
                        this.Close();
                    }
                }
                catch(Exception ex)
                {
                    ControlLenguaje.utility.WriteToErrorLog(AppDomain.CurrentDomain.BaseDirectory, ex);
                    ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.validationMessages.GetString("ErrorInesperado"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnAgregar.Enabled = true;
                    btnCancelar.Enabled = true;
                }
            }
        }

        private void txtAltura_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lstArchivosAdjuntos_DoubleClick(object sender, EventArgs e)
        {
            string adjuntoSeleccionado = (string)lstArchivosAdjuntos.SelectedItem;
            if (adjuntoSeleccionado != "" && adjuntoSeleccionado != null)
            {
                var archivo = rutasAdjuntos[adjuntoSeleccionado];

                if (archivo[0] == "")
                {
                    string path = AppDomain.CurrentDomain.BaseDirectory + adjuntoSeleccionado + archivo[4];
                    File.WriteAllBytes(path, Convert.FromBase64String(archivo[3]));
                    Process.Start(path);
                }
                else
                {
                    Process.Start(archivo[0]);
                }
            }
        }

        private void btnAgregarAdjunto_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        public void AdjuntarArchivo(string descripcion, int tipoArchivo)
        {
            lstArchivosAdjuntos.Items.Add(descripcion);
            rutasAdjuntos.Add(descripcion, new List<string>() { txtNombreArchivo.Text, tipoArchivo.ToString() });
            txtNombreArchivo.Text = "";
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            txtNombreArchivo.Text = openFileDialog1.FileName;
            AgregarArchivo f = new AgregarArchivo(this);
            f.Show(this);
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

            if (LoginModel.Rol != ComunModel.RolesUsuario.Medico)
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

        private void KryptonGroupBox1_Panel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
