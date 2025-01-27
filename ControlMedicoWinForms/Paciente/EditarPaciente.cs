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
using ControlMedicoWinForms.Catalogo;
using ControlMedicoWinForms.Models;
using ControlMedicoWinForms.Utilidades;
using static ControlMedicoWinForms.Models.ComunModel;

namespace ControlMedicoWinForms.Paciente
{
    public partial class EditarPaciente : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        ControlPacientes padre;
        int id;
        PacienteServices services = new PacienteServices();
        CatalogoServices catalogoServices = new CatalogoServices();
        ArchivoPacienteModel fotoPaciente = null;

        public EditarPaciente(int idPaciente, ControlPacientes p)
        {
            padre = p;
            id = idPaciente;
            InitializeComponent();
        }

        private async void EditarPaciente_Load(object sender, EventArgs e)
        {
            this.Font = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);
            this.kryptonGroupBox1.StateCommon.Content.ShortText.Font = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);
            this.kryptonGroupBox2.StateCommon.Content.ShortText.Font = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            //dtpFechaNac.CustomFormat = " ";
            dtpFechaNac.MaxDate = DateTime.Today;
            //dtpFechaNac.Format = DateTimePickerFormat.Custom;
            this.Width = 855;
            this.Height = 675;
            txtTelefono.MaxLength = 10;
            txtMovil.MaxLength = 10;
            txtTelefonoFamiliar.MaxLength = 10;

            //utility.GoAsync();

            if (Utility.CheckForInternetConnection())
            {
                try
                {
                    //Obtener escolaridades
                    var escolaridades = await catalogoServices.GetAllEscolaridades();
                    escolaridades.Add(new EscolaridadModel { IdEscolaridad = 0, Descripcion = "Seleccione" });
                    cmbEscolaridad.DataSource = escolaridades.OrderBy(x => x.IdEscolaridad).ToList();
                    cmbEscolaridad.DisplayMember = "Descripcion";
                    cmbEscolaridad.ValueMember = "IdEscolaridad";

                    //Obtener patologias
                    var patologias = await catalogoServices.GetAllPatologias();
                    patologias.Add(new PatologiaModel { IdPatologia = 0, Descripcion = "Seleccione" });
                    cmbPatologia.DataSource = patologias.OrderBy(x => x.IdPatologia).ToList();
                    cmbPatologia.DisplayMember = "Descripcion";
                    cmbPatologia.ValueMember = "IdPatologia";

                    //Obtener medicamentos
                    var medicamentos = await catalogoServices.GetAllMedicamentos();
                    medicamentos.Add(new MedicamentoModel { IdMedicamento = 0, Descripcion = "Seleccione" });
                    cmbMedicamento.DataSource = medicamentos.OrderBy(x => x.IdMedicamento).ToList();
                    cmbMedicamento.DisplayMember = "Descripcion";
                    cmbMedicamento.ValueMember = "IdMedicamento";

                    //Obtener ocupaciones
                    var ocupaciones = await catalogoServices.GetAllOcupacions();
                    ocupaciones.Add(new OcupacionModel { IdOcupacion = 0, Descripcion = "Seleccione" });
                    cmbOcupacion.DataSource = ocupaciones.OrderBy(x => x.IdOcupacion).ToList();
                    cmbOcupacion.DisplayMember = "Descripcion";
                    cmbOcupacion.ValueMember = "IdOcupacion";

                    //Obtener lugares de nacimiento
                    var lugaresNacimiento = await catalogoServices.GetAllLugarNacimientoes();
                    lugaresNacimiento.Add(new LugarNacimientoModel { IdLugarNacimiento = 0, Descripcion = "Seleccione" });
                    cmbLugarNac.DataSource = lugaresNacimiento.OrderBy(x => x.IdLugarNacimiento).ToList();
                    cmbLugarNac.DisplayMember = "Descripcion";
                    cmbLugarNac.ValueMember = "IdLugarNacimiento";

                    List<object> listaOpciones = new List<object>();

                    if (cmbGenero.DataSource == null)
                    {
                        listaOpciones.Add(new { Text = "Seleccione", Value = "" });
                        listaOpciones.Add(new { Text = "Masculino", Value = "M" });
                        listaOpciones.Add(new { Text = "Femenimo", Value = "F" });

                        cmbGenero.ValueMember = "Value";
                        cmbGenero.DisplayMember = "Text";
                        cmbGenero.DataSource = listaOpciones;

                        listaOpciones = new List<object>();
                    }

                    if (cmbSeguro.DataSource == null)
                    {
                        listaOpciones.Add(new { Text = "No Tiene", Value = 0 });
                        listaOpciones.Add(new { Text = "Si Tiene", Value = 1 });

                        cmbSeguro.ValueMember = "Value";
                        cmbSeguro.DisplayMember = "Text";
                        cmbSeguro.DataSource = listaOpciones;

                        listaOpciones = new List<object>();
                    }

                    PacienteModel paciente = await services.GetPacienteById(new PacienteModel() { IdPaciente = id });

                    if (paciente != null)
                    {
                        txtIdentificacion.Text = paciente.Identificacion;
                        txtPrimerNombre.Text = paciente.PrimerNombre;
                        txtTelefono.Text = paciente.Telefono;
                        txtMovil.Text = paciente.TelefonoMovil;
                        cmbEstadoCivil.Text = paciente.EstadoCivil;
                        chkActivo.Checked = Convert.ToBoolean(paciente.Activo);
                        txtCorreo.Text = paciente.CorreoElectronico;
                        dtpFechaNac.Value = paciente.FechaNacimiento != null ? (DateTime)paciente.FechaNacimiento : new DateTime(1900, 01, 01);
                        txtDireccion.Text = paciente.Direccion;
                        cmbEscolaridad.SelectedValue = paciente.Escolaridad.IdEscolaridad;
                        cmbPatologia.SelectedValue = paciente.Patologia.IdPatologia;
                        txtNombreFamiliar.Text = paciente.NombreFamiliar;
                        txtTelefonoFamiliar.Text = paciente.TelefonoFamiliar;
                        txtObservaciones.Text = paciente.Observaciones;
                        txtSegundoNombre.Text = paciente.SegundoNombre;
                        txtPrimerApellido.Text = paciente.PrimerApellido;
                        txtSegundoApellido.Text = paciente.SegundoApellido;
                        cmbOcupacion.SelectedValue = paciente.Ocupacion.IdOcupacion;
                        txtReligion.Text = paciente.Religion;
                        cmbMedicamento.SelectedValue = paciente.MedicamentoActual.IdMedicamento;
                        cmbGenero.SelectedValue = paciente.Genero;
                        cmbSeguro.SelectedValue = paciente.SeguroVida;
                        cmbLugarNac.SelectedValue = paciente.LugarNacimiento.IdLugarNacimiento;

                        if (paciente.Foto != null)
                        {
                            MemoryStream mStream = new MemoryStream();
                            byte[] pData = Convert.FromBase64String(paciente.Foto.Archivo);
                            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
                            pictureBox1.Image = Image.FromStream(mStream);
                            mStream.Dispose();

                            fotoPaciente = paciente.Foto;
                        }
                    }

                    txtPrimerNombre.Focus();
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

        public bool ValidateForm()
        {
            if (txtPrimerNombre.Text == "")
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(string.Format(ControlLenguaje.validationMessages.GetString("CampoVacio"), ControlLenguaje.cadenas.GetString("TextoCampoPrimerNombre")), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (txtPrimerApellido.Text == "")
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(string.Format(ControlLenguaje.validationMessages.GetString("CampoVacio"), ControlLenguaje.cadenas.GetString("TextoCampoPrimerApellido")), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (txtTelefono.Text == "" && txtMovil.Text == "")
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(string.Format(ControlLenguaje.validationMessages.GetString("CampoVacio"), ControlLenguaje.cadenas.GetString("TextoCampoTelefono")), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if ((string)cmbGenero.SelectedValue == "")
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(string.Format(ControlLenguaje.validationMessages.GetString("CampoVacio"), ControlLenguaje.cadenas.GetString("TextoCampoGenero")), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (txtCorreo.Text == "")
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(string.Format(ControlLenguaje.validationMessages.GetString("CampoVacio"), ControlLenguaje.cadenas.GetString("TextoCampoCorreo")), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (txtCorreo.Text != "" && !ControlLenguaje.utility.IsValidEmail(txtCorreo.Text))
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.validationMessages.GetString("CampoEmail"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (txtTelefonoFamiliar.Text != "" && txtNombreFamiliar.Text == "")
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(string.Format(ControlLenguaje.validationMessages.GetString("CampoVacio"), ControlLenguaje.cadenas.GetString("TextoCampoNombreFamiliar")), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                try
                {
                    btnEditar.Enabled = false;
                    btnCancelar.Enabled = false;

                    PacienteModel paciente = new PacienteModel()
                    {
                        IdPaciente = id,
                        PrimerNombre = txtPrimerNombre.Text,
                        Telefono = txtTelefono.Text,
                        TelefonoMovil = txtMovil.Text,
                        Identificacion = txtIdentificacion.Text,
                        Activo = Convert.ToInt32(chkActivo.Checked),
                        EstadoCivil = cmbEstadoCivil.Text,
                        CorreoElectronico = txtCorreo.Text,
                        FechaNacimiento = dtpFechaNac.Value,
                        Direccion = txtDireccion.Text,
                        Escolaridad = new EscolaridadModel() { IdEscolaridad = (int)cmbEscolaridad.SelectedValue },
                        Patologia = new PatologiaModel() { IdPatologia = (int)cmbPatologia.SelectedValue },
                        NombreFamiliar = txtNombreFamiliar.Text,
                        TelefonoFamiliar = txtTelefonoFamiliar.Text,
                        Observaciones = txtObservaciones.Text,
                        Medico = LoginModel.Medico,
                        PrimerApellido= txtPrimerApellido.Text,
                        SegundoNombre = txtSegundoNombre.Text,
                        SegundoApellido = txtSegundoApellido.Text,
                        Ocupacion = new OcupacionModel() { IdOcupacion = (int)cmbOcupacion.SelectedValue },
                        Religion = txtReligion.Text,
                        MedicamentoActual = new MedicamentoModel() { IdMedicamento = (int)cmbMedicamento.SelectedValue },
                        Genero = (string)cmbGenero.SelectedValue,
                        SeguroVida = (int)cmbSeguro.SelectedValue,
                        LugarNacimiento = new LugarNacimientoModel() { IdLugarNacimiento = (int)cmbLugarNac.SelectedValue },
                    };

                    if(openFileDialog1.FileName != "" && pictureBox1.Image != null)
                    {
                        Image img = pictureBox1.Image;
                        MemoryStream mStream = new MemoryStream();
                        img.Save(mStream, img.RawFormat);
                        byte[] bArr = mStream.ToArray();
                        if (fotoPaciente != null)
                        {
                            paciente.Foto = fotoPaciente;
                        }
                        else
                        {
                            paciente.Foto = new ArchivoPacienteModel()
                            {
                                Paciente = new PacienteModel() { IdPaciente = id },
                                TipoArchivo = new TipoArchivoModel() { IdTipoArchivo = 3 },
                                Descripcion = "Foto Paciente",
                                Activo = 1
                            };
                        }
                        paciente.Foto.Archivo = Convert.ToBase64String(bArr);
                        paciente.Foto.ExtensionArchivo = Path.GetExtension(openFileDialog1.FileName);
                    }
                    //utility.GoAsync();

                    if (await services.UpdatePaciente(paciente))
                    {
                        ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.cadenas.GetString("PacienteEditado"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        padre.Cargar();
                        btnEditar.Enabled = true;
                        btnCancelar.Enabled = true;
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    ControlLenguaje.utility.WriteToErrorLog(AppDomain.CurrentDomain.BaseDirectory, ex);
                    ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.validationMessages.GetString("ErrorInesperado"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnEditar.Enabled = true;
                    btnCancelar.Enabled = true;
                }
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlLenguaje.utility.OnlyNumbers(sender, e);
        }

        private void txtMovil_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlLenguaje.utility.OnlyNumbers(sender, e);
        }

        private void txtTelefonoFamiliar_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlLenguaje.utility.OnlyNumbers(sender, e);
        }

        private void dtpFechaNac_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaNac.CustomFormat = "dd/MM/yyyy";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.cadenas.GetString("ConfirmarCancelar"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnCargarFoto_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files (JPG,PNG)|*.JPG;*.PNG;";
            openFileDialog1.Multiselect = false;
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if(openFileDialog1.FileName != "")
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void cmbEscolaridad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TxtPrimerNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlLenguaje.utility.OnlyLetters(sender, e);
        }

        private void TxtTelefonoFamiliar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
