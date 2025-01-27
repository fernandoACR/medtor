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
    public partial class IngresarDatosCita : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        AgregarCita padre;
        CalendarItem item;
        PacienteServices pacienteServices = new PacienteServices();
        MedicoServices medicoServices = new MedicoServices();
        CatalogoServices catalogoServices = new CatalogoServices();
        List<PacienteModel> pacientes = new List<PacienteModel>();
        List<TipoCitaModel> tiposCita = new List<TipoCitaModel>();

        public IngresarDatosCita(AgregarCita p, CalendarItem calendarItem)
        {
            padre = p;
            item = calendarItem;
            InitializeComponent();
        }

        private async void IngresarDatosCita_Load(object sender, EventArgs e)
        {
            this.Font = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);
            this.kryptonNavigator1.StateCommon.RibbonGeneral.TextFont = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);
            this.kryptonPage1.StateCommon.RibbonGeneral.TextFont = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);
            this.kryptonPage2.StateCommon.RibbonGeneral.TextFont = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);

            if (LoginModel.Rol == RolesUsuario.Administrador)
            {
                pacientes = await pacienteServices.GetAllPacientes();
            }
            else
            {
                pacientes = await pacienteServices.GetPacienteByIdMedico(new PacienteModel() { Medico = new MedicoModel() { IdMedico = LoginModel.Medico.IdMedico } });
                cmbMedico.Visible = false;
                lblMedico.Visible = false;
            }

            pacientes.Add(new PacienteModel { IdPaciente = 0, NombreCompleto = "Seleccione" });
            cmbPaciente.DataSource = pacientes.OrderBy(x => x.IdPaciente).ToList();
            cmbPaciente.DisplayMember = "NombreCompleto";
            cmbPaciente.ValueMember = "IdPaciente";
            cmbPaciente.DropDownStyle = ComboBoxStyle.DropDown;
            cmbPaciente.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbPaciente.AutoCompleteSource = AutoCompleteSource.ListItems;

            //Obtener Medicos
            var medicos = await medicoServices.GetAllMedicos();
            medicos.Add(new MedicoModel { IdMedico = 0, Nombre = "Seleccione" });
            cmbMedico.DataSource = medicos.OrderBy(x => x.IdMedico).ToList();
            cmbMedico.DisplayMember = "Nombre";
            cmbMedico.ValueMember = "IdMedico";

            //Obtener Tipo Cita
            tiposCita = await catalogoServices.GetAllTipoCitas();
            tiposCita.Add(new TipoCitaModel { IdTipoCita = 0, Descripcion = "Seleccione" });
            cmbTipoCita.DataSource = tiposCita.OrderBy(x => x.IdTipoCita).ToList();
            cmbTipoCita.DisplayMember = "Descripcion";
            cmbTipoCita.ValueMember = "IdTipoCita";

            //txtTitulo.Text = item.ToString();
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
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(string.Format(ControlLenguaje.validationMessages.GetString("CampoVacio"), ControlLenguaje.cadenas.GetString("TextoCampoDescripcion")), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                CitaModel nuevaCita = new CitaModel()
                {
                    Medico = new MedicoModel() { IdMedico = LoginModel.Medico == null ? (int)cmbMedico.SelectedValue : LoginModel.Medico.IdMedico },
                    Comentarios = txtComentarios.Text,                    
                    TipoCita = tiposCita.Where(x => x.IdTipoCita == (int)cmbTipoCita.SelectedValue).FirstOrDefault(),
                    Titulo = "",
                    NotificarEmail = chkNotiCorreo.Checked,
                    NotificarSMS = chkNotiSMS.Checked,
                    NotificarWHP = chkNotiWHP.Checked
                };

                if (nuevaCita.TipoCita.IdTipoCita != (int)TipoCitaEnum.PNL)
                {
                    nuevaCita.Paciente = pacientes.Where(x => x.IdPaciente == (int)cmbPaciente.SelectedValue).FirstOrDefault();
                }

                padre.NuevaCita(item, nuevaCita);
                this.Close();
            }
        }

        private void cmbNotiHorasCorreo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chkNotiCorreo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNotiCorreo.Checked)
            {
                //cmbNotiHorasCorreo.Enabled = true;
                //cmbDiasNotiCorreo.Enabled = true;
            }

            if (!chkNotiCorreo.Checked)
            {
                //cmbNotiHorasCorreo.Enabled = false;
                //cmbDiasNotiCorreo.Enabled = false;
            }
        }

        private void chkNotiSMS_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNotiSMS.Checked)
            {
                //cmbNotiHoraSMS.Enabled = true;
                //cmbNotiDiasSMS.Enabled = true;
            }

            if (!chkNotiSMS.Checked)
            {
                //cmbNotiHoraSMS.Enabled = false;
                //cmbNotiDiasSMS.Enabled = false;
            }
        }

        private void kryptonLabel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtComentarios_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ChkNotiWHP_CheckedChanged(object sender, EventArgs e)
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
                    cmbPaciente.Enabled = true;
                    chkNotiCorreo.Enabled = true;
                    chkNotiSMS.Enabled = true;
                    chkNotiWHP.Enabled = true;
                }
            }
        }
    }
}
