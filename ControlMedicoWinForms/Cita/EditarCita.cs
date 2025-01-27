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
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Calendar;
using System.Xml.Serialization;

namespace ControlMedicoWinForms.Cita
{
    public partial class EditarCita : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        List<CalendarItem> _items = new List<CalendarItem>();
        CalendarItem contextItem = null;

        ControlCitas padre;
        int id;
        CitaServices citaServices = new CitaServices();
        PacienteServices pacienteServices = new PacienteServices();
        MedicoServices medicoServices = new MedicoServices();
        CatalogoServices catalogoServices = new CatalogoServices();

        ResourceManager validationMessages = new ResourceManager("ControlMedicoWinforms.Utilidades.ValidationMessages", Assembly.GetExecutingAssembly());

        public EditarCita(int idCita, ControlCitas p)
        {
            padre = p;
            id = idCita;
            InitializeComponent();
        }

        public FileInfo ItemsFile
        {
            get
            {
                return new FileInfo(Path.Combine(Application.StartupPath, "items.xml"));
            }
        }

        private void PlaceItems()
        {
            foreach (CalendarItem item in _items)
            {
                if (calendar1.ViewIntersects(item))
                {
                    if (item.ItemId != id)
                    {
                        item.Locked = true;                        
                    }
                    else
                    {
                        item.Selected = true;
                    }

                    calendar1.Items.Add(item);
                }
            }
        }

        private void EditarCita_Load(object sender, EventArgs e)
        {
            LoadDatos();            
        }

        public async void LoadDatos()
        {
            monthView1.MonthTitleColor = monthView1.MonthTitleColorInactive = CalendarColorTable.FromHex("#C2DAFC");
            monthView1.ArrowsColor = CalendarColorTable.FromHex("#77A1D3");
            monthView1.DaySelectedBackgroundColor = CalendarColorTable.FromHex("#F4CC52");
            monthView1.DaySelectedTextColor = monthView1.ForeColor;

            if (LoginModel.Rol == ComunModel.RolesUsuario.Medico)
            {
                cmbMedico.Visible = false;
                lblMedico.Visible = false;
            }

            //dtpFechaRecepcion.CustomFormat = " ";
            //dtpFechaRecepcion.Format = DateTimePickerFormat.Custom;

            //dtpHoraCita.CustomFormat = " ";
            //dtpHoraCita.Format = DateTimePickerFormat.Custom;

            //cmbEstatusCita.Enabled = false;
            //dtpFechaRecepcion.MinDate = DateTime.Today;

            try
            {
                CitaModel cita = await citaServices.GetCitaById(new CitaModel() { IdCita = id });
                bool esMedico = LoginModel.Rol == ComunModel.RolesUsuario.Medico;

                List<CitaModel> listCitas = new List<CitaModel>();
                if (esMedico)
                {
                    listCitas = await citaServices.GetCitasByIdMedico(new CitaModel() { Medico = new MedicoModel() { IdMedico = LoginModel.Medico.IdMedico } });
                }
                else
                {
                    listCitas = await citaServices.GetAllCitas();
                }

                var medicos = await medicoServices.GetAllMedicos();
                medicos.Add(new MedicoModel { IdMedico = 0, Nombre = "Seleccione" });
                cmbMedico.DataSource = medicos.OrderBy(x => x.IdMedico).ToList();
                cmbMedico.DisplayMember = "Nombre";
                cmbMedico.ValueMember = "IdMedico";

                var pacientes = await pacienteServices.GetAllPacientes();
                pacientes.Add(new PacienteModel { IdPaciente = 0, NombreCompleto = "Seleccione" });
                cmbPaciente.DataSource = pacientes.OrderBy(x => x.IdPaciente).ToList();
                cmbPaciente.DisplayMember = "NombreCompleto";
                cmbPaciente.ValueMember = "IdPaciente";

                var estatusCita = await catalogoServices.GetAllEstatusCitas();
                estatusCita.Add(new EstatusCitaModel { IdEstatusCita = 0, Descripcion = "Seleccione" });
                cmbEstatusCita.DataSource = estatusCita.OrderBy(x => x.IdEstatusCita).ToList();
                cmbEstatusCita.DisplayMember = "Descripcion";
                cmbEstatusCita.ValueMember = "IdEstatusCita";

                //Obtener Tipo Cita
                var tiposCita = await catalogoServices.GetAllTipoCitas();
                tiposCita.Add(new TipoCitaModel { IdTipoCita = 0, Descripcion = "Seleccione" });
                cmbTipoCita.DataSource = tiposCita.OrderBy(x => x.IdTipoCita).ToList();
                cmbTipoCita.DisplayMember = "Descripcion";
                cmbTipoCita.ValueMember = "IdTipoCita";

                if (cita != null)
                {
                    _items.Clear();
                    calendar1.Items.Clear();
                    foreach (CitaModel cit in listCitas)
                    {
                        CalendarItem cal = new CalendarItem(calendar1, cit.FechaCitaDesde, cit.FechaCitaHasta, cit.Titulo);
                        cal.ItemId = cit.IdCita;

                        if (cit.IdCita != id)
                        {

                            _items.Add(cal);
                        }
                        else
                        {
                            _items.Add(cal);
                            contextItem = cal;
                        }
                    }

                    PlaceItems();

                    //dtpFechaRecepcion.MinDate = cita.FechaCitaDesde;
                    cmbMedico.SelectedValue = cita.Medico.IdMedico;
                    cmbPaciente.SelectedValue = cita.Paciente.IdPaciente;
                    //txtTitulo.Text = cita.Titulo;
                    //dtpFechaRecepcion.Value = cita.FechaCitaHasta;
                    //dtpHoraCita.Value = cita.FechaCitaDesde;
                    txtComentarios.Text = cita.Comentarios;
                    cmbEstatusCita.SelectedValue = cita.EstatusCita.IdEstatusCita;
                    cmbTipoCita.SelectedValue = cita.TipoCita.IdTipoCita;

                    if (DateTime.Today.Date >= cita.FechaCitaDesde.Date && (int)cita.EstatusCita.IdEstatusCita != (int)ComunModel.EstatusCitaEnum.POR)
                    {
                        cmbMedico.Enabled = false;
                        cmbPaciente.Enabled = false;
                        txtComentarios.Enabled = false;
                        //txtTitulo.Enabled = false;
                        //dtpFechaRecepcion.Enabled = false;
                        btnAgregar.Enabled = false;
                        cmbTipoCita.Enabled = false;
                        btnCancelar.Text = "Salir";
                        cmbEstatusCita.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ControlLenguaje.utility.WriteToErrorLog(AppDomain.CurrentDomain.BaseDirectory, ex);
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.validationMessages.GetString("ErrorInesperado"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                CitaModel cita = new CitaModel()
                {
                    IdCita = id,
                    Medico = new MedicoModel() { IdMedico = (int)cmbMedico.SelectedValue },
                    Comentarios = txtComentarios.Text,
                    Titulo = contextItem.Text,
                    Paciente = new PacienteModel() { IdPaciente = (int)cmbPaciente.SelectedValue },
                    FechaCitaDesde = contextItem.StartDate,
                    EstatusCita = new EstatusCitaModel() { IdEstatusCita = (int)cmbEstatusCita.SelectedValue },
                    TipoCita = new TipoCitaModel() { IdTipoCita = (int)cmbTipoCita.SelectedValue },
                    FechaCitaHasta = contextItem.EndDate
                };

                if (await citaServices.UpdateCita(cita))
                {
                    ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.cadenas.GetString("CitaEditada"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    padre.LoadDatos();
                    this.Close();
                }
                else
                {
                    ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.validationMessages.GetString("ErrorInesperado"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    padre.LoadDatos();
                    this.Close();
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

        private void dtpFechaRecepcion_ValueChanged(object sender, EventArgs e)
        {
            //dtpFechaRecepcion.CustomFormat = "dd/MM/yyyy";
        }

        private void chkNotiCorreo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNotiCorreo.Checked)
            {
                cmbNotiHorasCorreo.Enabled = true;
                cmbDiasNotiCorreo.Enabled = true;
            }

            if (!chkNotiCorreo.Checked)
            {
                cmbNotiHorasCorreo.Enabled = false;
                cmbDiasNotiCorreo.Enabled = false;
            }
        }

        private void chkNotiSMS_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNotiSMS.Checked)
            {
                cmbNotiHoraSMS.Enabled = true;
                cmbNotiDiasSMS.Enabled = true;
            }

            if (!chkNotiSMS.Checked)
            {
                cmbNotiHoraSMS.Enabled = false;
                cmbNotiDiasSMS.Enabled = false;
            }
        }

        private void dtpHoraCi_ValueChanged(object sender, EventArgs e)
        {
            //dtpHoraCita.CustomFormat = "hh:mm";
        }

        public bool ValidateForm()
        {
            if (contextItem.StartDate.ToString() == "")
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show("Debe indicar la fecha de la cita", ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if ((int)cmbPaciente.SelectedValue == 0)
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(string.Format(validationMessages.GetString("CampoVacio"), ControlLenguaje.cadenas.GetString("TextoCampoPaciente")), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if ((int)cmbMedico.SelectedValue == 0 && LoginModel.Medico == null)
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(string.Format(validationMessages.GetString("CampoVacio"), "Nombre del Medico"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (contextItem.Text == "")
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(string.Format(validationMessages.GetString("CampoVacio"), "Titulo"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (txtComentarios.Text == "")
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(string.Format(validationMessages.GetString("CampoVacio"), "Comentarios"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private void calendar1_LoadItems(object sender, CalendarLoadEventArgs e)
        {
            PlaceItems();
        }

        private void calendar1_ItemClick(object sender, CalendarItemEventArgs e)
        {
            if(e.Item.ItemId != id)
            {
                e.Item.Selected = false;
            }
            //if (e.Item.ItemId != id)
            //{
            //    id = e.Item.ItemId;
            //    LoadDatos();
            //}
            //contextItem = e.Item;
        }

        private void calendar1_Resize(object sender, EventArgs e)
        {

        }

        private void monthView1_SelectionChanged(object sender, EventArgs e)
        {
            calendar1.SetViewRange(monthView1.SelectionStart, monthView1.SelectionEnd);
        }

        private void calendar1_ItemCreated(object sender, CalendarItemCancelEventArgs e)
        {
            contextItem.StartDate = e.Item.StartDate;
            contextItem.EndDate = e.Item.EndDate;
            contextItem.Text = e.Item.Text;
        }

        private void calendar1_ItemDatesChanged(object sender, CalendarItemEventArgs e)
        {
            contextItem.StartDate = e.Item.StartDate;
            contextItem.EndDate = e.Item.EndDate;
            contextItem.Text = e.Item.Text;
        }

        private void calendar1_ItemDoubleClick(object sender, CalendarItemEventArgs e)
        {
            //if (e.Item.ItemId != id)
            //{
            //    id = e.Item.ItemId;
            //    LoadDatos();
            //}
            //contextItem = e.Item;
            calendar1.ActivateEditMode();
        }

        private void calendar1_ItemDeleting(object sender, CalendarItemCancelEventArgs e)
        {
            //contextItem = null;
            //await citaServices.DeleteCita(new CitaModel() { IdCita = e.Item.ItemId });
        }

        private void txtComentarios_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
