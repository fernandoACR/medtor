using ControlMedicoWinForms.Catalogo;
using ControlMedicoWinForms.Medico;
using ControlMedicoWinForms.Models;
using ControlMedicoWinForms.Paciente;
using ControlMedicoWinForms.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Calendar;
using static ControlMedicoWinForms.Models.ComunModel;

namespace ControlMedicoWinForms.Cita
{
    public partial class EditarDatosCita : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        AgregarCita padre;
        CalendarItem item;
        CitaModel citaEditar;
        PacienteServices pacienteServices = new PacienteServices();
        MedicoServices medicoServices = new MedicoServices();
        CatalogoServices catalogoServices = new CatalogoServices();

        public EditarDatosCita(AgregarCita p, CalendarItem calendarItem, CitaModel cita)
        {
            padre = p;
            item = calendarItem;
            citaEditar = cita;
            InitializeComponent();
        }

        private async void EditarDatosCita_Load(object sender, EventArgs e)
        {
            this.Font = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);
            this.kryptonNavigator1.StateCommon.RibbonGeneral.TextFont = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);
            this.kryptonPage1.StateCommon.RibbonGeneral.TextFont = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);
            this.kryptonPage2.StateCommon.RibbonGeneral.TextFont = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);
            cmbPaciente.Enabled = false;

            var pacientes = new List<PacienteModel>();
            pacientes.Add(new PacienteModel { IdPaciente = 0, NombreCompleto = "Seleccione" });

            if (citaEditar.TipoCita.IdTipoCita != (int)TipoCitaEnum.PNL)
            {
                pacientes.Add(await pacienteServices.GetPacienteById(citaEditar.Paciente));
                cmbMedico.Visible = false;
                lblMedico.Visible = false;
            }
            else
            {
                cmbTipoCita.Enabled = false;
            }

            if (LoginModel.Rol != RolesUsuario.Administrador)
            {
                cmbMedico.Visible = false;
                lblMedico.Visible = false;
            }

            cmbPaciente.DataSource = pacientes.OrderBy(x => x.IdPaciente).ToList();
            cmbPaciente.DisplayMember = "NombreCompleto";
            cmbPaciente.ValueMember = "IdPaciente";
            cmbPaciente.DropDownStyle = ComboBoxStyle.DropDown;
            cmbPaciente.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbPaciente.AutoCompleteSource = AutoCompleteSource.ListItems;

            if (citaEditar.TipoCita.IdTipoCita != (int)TipoCitaEnum.PNL)
            {
                cmbPaciente.SelectedValue = citaEditar.Paciente.IdPaciente;
                chkNotiCorreo.Enabled = false;
                chkNotiSMS.Enabled = false;
                chkNotiWHP.Enabled = false;
                chkNotiCorreo.Checked = false;
                chkNotiSMS.Checked = false;
                chkNotiWHP.Checked = false;
            }
            //Obtener Medicos
            var medicos = await medicoServices.GetAllMedicos();
            medicos.Add(new MedicoModel { IdMedico = 0, Nombre = "Seleccione" });
            cmbMedico.DataSource = medicos.OrderBy(x => x.IdMedico).ToList();
            cmbMedico.DisplayMember = "Nombre";
            cmbMedico.ValueMember = "IdMedico";

            //Obtener Tipo Cita
            var tiposCita = await catalogoServices.GetAllTipoCitas();

            if (citaEditar.TipoCita.IdTipoCita != (int)TipoCitaEnum.PNL)
            {
                tiposCita = tiposCita.Where(ti=> ti.IdTipoCita != (int)TipoCitaEnum.PNL ).ToList();
            }

            tiposCita.Add(new TipoCitaModel { IdTipoCita = 0, Descripcion = "Seleccione" });
            cmbTipoCita.DataSource = tiposCita.OrderBy(x => x.IdTipoCita).ToList();
            cmbTipoCita.DisplayMember = "Descripcion";
            cmbTipoCita.ValueMember = "IdTipoCita";

            
            var estatusCita = await catalogoServices.GetAllEstatusCitas();
            estatusCita.Add(new EstatusCitaModel { IdEstatusCita = 0, Descripcion = "Seleccione" });
            cmbEstatusCita.DataSource = estatusCita.OrderBy(x => x.IdEstatusCita).ToList();
            cmbEstatusCita.DisplayMember = "Descripcion";
            cmbEstatusCita.ValueMember = "IdEstatusCita";

            cmbMedico.SelectedValue = citaEditar.Medico.IdMedico;            
            txtComentarios.Text = citaEditar.Comentarios;
            cmbEstatusCita.SelectedValue = citaEditar.EstatusCita.IdEstatusCita;
            cmbTipoCita.SelectedValue = citaEditar.TipoCita.IdTipoCita;

            if(citaEditar.EstatusCita.IdEstatusCita == (int)EstatusCitaEnum.CMP)
            {
                cmbMedico.Enabled = false;
                cmbPaciente.Enabled = false;
                txtComentarios.Enabled = false;
                cmbEstatusCita.Enabled = false;
                cmbTipoCita.Enabled = false;
                btnAceptar.Visible = false;
                btnCancelar.Text = ControlLenguaje.cadenas.GetString("TextoBtnSalir");
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                CitaModel nuevaCita = new CitaModel()
                {
                    IdCita = citaEditar.IdCita,
                    Medico = new MedicoModel() { IdMedico = LoginModel.Medico == null ? (int)cmbMedico.SelectedValue : LoginModel.Medico.IdMedico },
                    Comentarios = txtComentarios.Text,
                    Paciente = new PacienteModel() { IdPaciente = (int)cmbPaciente.SelectedValue },
                    TipoCita = new TipoCitaModel() { IdTipoCita = (int)cmbTipoCita.SelectedValue },
                    EstatusCita = new EstatusCitaModel() { IdEstatusCita = (int)cmbEstatusCita.SelectedValue },
                    FechaCitaDesde = item.StartDate,
                    FechaCitaHasta = item.EndDate,
                    Titulo = ""
                };

                padre.EditarCita(item, nuevaCita);
                this.Close();
            }
        }

        public bool ValidateForm()
        {
            if (cmbPaciente.SelectedValue == null && (int)cmbTipoCita.SelectedValue != (int)TipoCitaEnum.PNL)
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(string.Format(ControlLenguaje.validationMessages.GetString("CampoVacio"), ControlLenguaje.cadenas.GetString("TextoCampoPaciente")), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if ((int)cmbPaciente.SelectedValue == 0 && (int)cmbTipoCita.SelectedValue != (int)TipoCitaEnum.PNL)
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(string.Format(ControlLenguaje.validationMessages.GetString("CampoVacio"), ControlLenguaje.cadenas.GetString("TextoCampoPaciente")), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (txtComentarios.Text == "")
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(string.Format(ControlLenguaje.validationMessages.GetString("CampoVacio"), ControlLenguaje.cadenas.GetString("TextoCampoComentarios")), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void KryptonPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TxtComentarios_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void KryptonLabel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CmbEstatusCita_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CmbTipoCita_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoCita.SelectedIndex > 0)
            {
                if ((int)cmbTipoCita.SelectedValue == (int)TipoCitaEnum.PNL)
                {
                    cmbPaciente.SelectedValue = 0;
                    cmbPaciente.Enabled = false;
                    chkNotiCorreo.Enabled = false;
                    chkNotiSMS.Enabled = false;
                    chkNotiWHP.Enabled = false;
                    chkNotiCorreo.Checked = false;
                    chkNotiSMS.Checked = false;
                    chkNotiWHP.Checked = false;
                }
                else
                {
                    chkNotiCorreo.Enabled = true;
                    chkNotiSMS.Enabled = true;
                    chkNotiWHP.Enabled = true;
                }
            }
        }
    }
}
