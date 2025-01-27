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
    public partial class AgregarPaciente : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        ControlPacientes padre;
        PacienteServices services = new PacienteServices();
        CatalogoServices catalogoServices = new CatalogoServices();

        public AgregarPaciente(ControlPacientes p)
        {
            padre = p;
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {            
            if (ValidateForm())
            {
                try
                {
                    btnAgregar.Enabled = false;
                    btnCancelar.Enabled = false;

                    PacienteModel paciente = new PacienteModel()
                    {
                        IdPaciente = 0,
                        PrimerNombre = txtPrimerNombre.Text,
                        Telefono = txtTelefono.Text,
                        TelefonoMovil = txtMovil.Text,
                        Identificacion = txtIdentificacion.Text,
                        EstadoCivil = cmbEstadoCivil.Text,
                        CorreoElectronico = txtCorreo.Text,
                        FechaNacimiento=dtpFechaNac.Value,
                        Direccion = txtDireccion.Text,
                        Escolaridad = new EscolaridadModel() { IdEscolaridad = (int)cmbEscolaridad.SelectedValue },
                        Patologia = new PatologiaModel() { IdPatologia = (int)cmbPatologia.SelectedValue },
                        NombreFamiliar = txtNombreFamiliar.Text,
                        TelefonoFamiliar = txtTelefonoFamiliar.Text,
                        Observaciones = txtObservaciones.Text,
                        Medico = LoginModel.Medico,
                        SegundoNombre = txtSegundoNombre.Text,
                        PrimerApellido = txtPrimerApellido.Text,
                        SegundoApellido = txtSegundoApellido.Text,
                        Ocupacion = new OcupacionModel() { IdOcupacion = (int)cmbOcupacion.SelectedValue },
                        Religion = txtReligion.Text,
                        MedicamentoActual = new MedicamentoModel() { IdMedicamento = (int)cmbMedicamento.SelectedValue },
                        Genero = (string)cmbGenero.SelectedValue,
                        SeguroVida = (int)cmbSeguro.SelectedValue,
                        LugarNacimiento = new LugarNacimientoModel() { IdLugarNacimiento = (int)cmbLugarNac.SelectedValue },
                    };

                    if (openFileDialog1.FileName != "" && pictureBox1.Image != null)
                    {
                        Image img = pictureBox1.Image;
                        MemoryStream mStream = new MemoryStream();
                        img.Save(mStream, img.RawFormat);
                        byte[] bArr = mStream.ToArray();

                        paciente.Foto = new ArchivoPacienteModel()
                        {
                            Archivo = Convert.ToBase64String(bArr),
                            ExtensionArchivo = Path.GetExtension(openFileDialog1.FileName),
                            Paciente = new PacienteModel() { IdPaciente = paciente.IdPaciente },
                            Descripcion = "Foto Paciente",
                            TipoArchivo = new TipoArchivoModel() { IdTipoArchivo = 1 }
                        };
                    }

                    //utility.GoAsync();
                    int accion = await services.AddPaciente(paciente);

                    if (accion > 0)
                    {
                        ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.cadenas.GetString("PacienteAgregado"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        padre.Cargar();
                        btnAgregar.Enabled = true;
                        btnCancelar.Enabled = true;
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.cadenas.GetString("ConfirmarCancelar"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private async void AgregarPaciente_Load(object sender, EventArgs e)
        {
            this.Font = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);
            this.kryptonGroupBox1.StateCommon.Content.ShortText.Font = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);
            this.kryptonGroupBox2.StateCommon.Content.ShortText.Font = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            dtpFechaNac.CustomFormat = " ";
            dtpFechaNac.MaxDate = DateTime.Today;
            dtpFechaNac.Format = DateTimePickerFormat.Custom;
            this.Width = 848;
            this.Height = 683;
            txtTelefono.MaxLength = 10;
            txtMovil.MaxLength = 10;
            txtTelefonoFamiliar.MaxLength = 10;


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
                    var patologias = await catalogoServices.GetPatologiaByIdMedicoAndActivo(new PatologiaModel() { Medico = LoginModel.Medico, Activo = 1 });
                    patologias.Add(new PatologiaModel { IdPatologia = 0, Descripcion = "Seleccione" });
                    cmbPatologia.DataSource = patologias.OrderBy(x => x.IdPatologia).ToList();
                    cmbPatologia.DisplayMember = "Descripcion";
                    cmbPatologia.ValueMember = "IdPatologia";

                    //Obtener medicamentos
                    var medicamentos = await catalogoServices.GetMedicamentosByIdMedicoAndActivo(new MedicamentoModel() { Medico = LoginModel.Medico, Activo = 1 });
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

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlLenguaje.utility.OnlyNumbers(sender, e);
        }

        private void dtpFechaNac_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaNac.CustomFormat = "dd/MM/yyyy";
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtMovil_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlLenguaje.utility.OnlyNumbers(sender, e);
        }

        private void txtTelefonoFamiliar_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlLenguaje.utility.OnlyNumbers(sender, e);
        }

        private void kryptonGroupBox1_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void cmbEstadoCivil_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if (openFileDialog1.FileName != "")
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void btnCargarFoto_Click(object sender, EventArgs e)
        {       
            openFileDialog1.Filter = "Image Files (JPG,PNG)|*.JPG;*.PNG;";
            openFileDialog1.Multiselect = false;
            openFileDialog1.ShowDialog();
        }

        private void txtMovil_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtPrimerNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlLenguaje.utility.OnlyLetters(sender, e);
        }

        private void TxtSegundoNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            ControlLenguaje.utility.OnlyLetters(sender, e);
        }

        private void BtnExtraer_Click(object sender, EventArgs e)
        {

        }
    }
}
