using ControlMedicoWinForms.Catalogo;
using ControlMedicoWinForms.Medico;
using ControlMedicoWinForms.Models;
using ControlMedicoWinForms.Notificacion;
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
using static ControlMedicoWinForms.Models.ComunModel;

namespace ControlMedicoWinForms.Cita
{
    public partial class AgregarCita : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        List<CalendarItem> _items = new List<CalendarItem>();
        ControlCitas padre;

        CitaServices citaServices = new CitaServices();
        PacienteServices pacienteServices = new PacienteServices();
        NotificacionServices notificacionServices = new NotificacionServices();

        CitaModel nuevaCita = new CitaModel();
        List<CitaModel> listCitas = new List<CitaModel>();

        public AgregarCita(ControlCitas p)
        {
            padre = p;
            InitializeComponent();
        }

        public FileInfo ItemsFile
        {
            get
            {
                return new FileInfo(Path.Combine(Application.StartupPath, "items.xml"));
            }
        }

        private void AgregarCita_Load(object sender, EventArgs e)
        {
            this.Font = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);
            this.calendar1.Font = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);
            this.monthView1.Font = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);

            Cargar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            padre.Cargar();
            this.Close();
        }

        public bool ValidateForm()
        {
            if (_items.Where(x => x.ItemId <= 0).Count() <= 0)
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.validationMessages.GetString("FechaHoraCita"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            //if (_items.Where(x => x.ItemId <= 0).FirstOrDefault().Text == "")
            //{
            //    ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(string.Format(ControlLenguaje.validationMessages.GetString("CampoVacio"), ControlLenguaje.cadenas.GetString("TextoCampoTitulo")), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return false;
            //}           

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

        private void PlaceItems()
        {
            foreach (CalendarItem item in _items)
            {
                if (calendar1.ViewIntersects(item))
                {
                    calendar1.Items.Add(item);
                }
            }            
        }

        public async void NuevaCita(CalendarItem item, CitaModel nuevaCita)
        {
            if (nuevaCita.Paciente != null)
            {
                calendar1.Items[calendar1.Items.Count - 1].Text = nuevaCita.Paciente.PrimerNombre + " " + nuevaCita.Paciente.PrimerApellido + " - " + nuevaCita.TipoCita.Descripcion;
            }
            else
            {
                calendar1.Items[calendar1.Items.Count - 1].Text = nuevaCita.TipoCita.Descripcion;
            }

            calendar1.Items[calendar1.Items.Count - 1].BackgroundColor = Color.Yellow;

            calendar1.Refresh();

            if (ValidateForm())
            {
                try
                {
                    this.nuevaCita.Titulo = item.Text;
                    this.nuevaCita.FechaCitaDesde = item.StartDate;
                    this.nuevaCita.FechaCitaHasta = item.EndDate;

                    nuevaCita.FechaCitaDesde = item.StartDate;
                    nuevaCita.FechaCitaHasta = item.EndDate;

                    int accion = await citaServices.AddCita(nuevaCita);

                    if (accion > 0)
                    {
                        ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.cadenas.GetString("CitaAgregada"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                        listCitas.Add(await citaServices.GetCitaById(new CitaModel() { IdCita = accion }));
                        calendar1.Items[calendar1.Items.Count - 1].ItemId = accion;

                        if(nuevaCita.NotificarEmail)
                        {
                            int idNotificacion = await notificacionServices.AddNotificacion(new NotificacionModel()
                            {
                                Medico = LoginModel.Medico,
                                Paciente = nuevaCita.Paciente,
                                TipoNotificacion = new TipoNotificacionModel() { IdTipoNotificacion = (int)TipoNotificacionEnum.RecordarCita },
                                Recursivo = 0,
                                MedioNotificacion = new MedioNotificacionModel() { IdMedioNotificacion = (int)MedioNotificacionEnum.EMAIL },
                                FechaNotificacion = DateTime.Now,
                                HoraNotificacion = DateTime.Now,
                                Activo = 1,
                                Cita = new CitaModel() { IdCita = accion }
                            });

                            await notificacionServices.EnviarNotificacionPorIdNotificacion(new NotificacionModel() { IdNotificacion = idNotificacion });
                        }
                    }
                }
                catch (Exception ex)
                {
                    ControlLenguaje.utility.WriteToErrorLog(AppDomain.CurrentDomain.BaseDirectory, ex);
                    ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.validationMessages.GetString("ErrorInesperado"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public async void EditarCita(CalendarItem item, CitaModel editarCita)
        {
            calendar1.Refresh();

            if (await citaServices.UpdateCita(editarCita))
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.cadenas.GetString("CitaEditada"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                listCitas.Where(x => x.IdCita == item.ItemId).FirstOrDefault().Medico = editarCita.Medico;
                listCitas.Where(x => x.IdCita == item.ItemId).FirstOrDefault().Paciente = editarCita.Paciente;
                listCitas.Where(x => x.IdCita == item.ItemId).FirstOrDefault().TipoCita = editarCita.TipoCita;
                listCitas.Where(x => x.IdCita == item.ItemId).FirstOrDefault().Titulo = editarCita.Titulo;
                listCitas.Where(x => x.IdCita == item.ItemId).FirstOrDefault().Comentarios = editarCita.Comentarios;
                listCitas.Where(x => x.IdCita == item.ItemId).FirstOrDefault().EstatusCita = editarCita.EstatusCita;

                if (editarCita.NotificarEmail)
                {
                    int idNotificacion = await notificacionServices.AddNotificacion(new NotificacionModel()
                    {
                        Medico = LoginModel.Medico,
                        Paciente = editarCita.Paciente,
                        TipoNotificacion = new TipoNotificacionModel() { IdTipoNotificacion = (int)TipoNotificacionEnum.RecordarCita },
                        Recursivo = 0,
                        MedioNotificacion = new MedioNotificacionModel() { IdMedioNotificacion = (int)MedioNotificacionEnum.EMAIL },
                        FechaNotificacion = DateTime.Now,
                        HoraNotificacion = DateTime.Now,
                        Activo = 1,
                        Cita = new CitaModel() { IdCita = editarCita.IdCita }
                    });

                    await notificacionServices.EnviarNotificacionPorIdNotificacion(new NotificacionModel() { IdNotificacion = idNotificacion });
                }

            }
            else
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.validationMessages.GetString("ErrorInesperado"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cargar();
        }
        public void Cargar()
        {
            if (!bgrworkerCitas.IsBusy)
            {
                progressBar1.Show();
                bgrworkerCitas.RunWorkerAsync();
            }
        }

        private void calendar1_ItemCreated(object sender, CalendarItemCancelEventArgs e)
        {
            if (_items.Count > 0)
            {
                //_items.Clear();
                List<CalendarItem> calendarItems = new List<CalendarItem>();
                calendarItems.AddRange(calendar1.Items);

                foreach (var item in calendarItems)
                {
                    if(item != e.Item && item.ItemId <= 0)
                    {
                        calendar1.Items.Remove(item);
                        _items.Remove(item);
                    }
                }
            }

            _items.Add(e.Item);
        }

        private void monthView1_SelectionChanged_1(object sender, EventArgs e)
        {
            calendar1.SetViewRange(monthView1.SelectionStart, monthView1.SelectionEnd);
        }

        private void calendar1_LoadItems(object sender, CalendarLoadEventArgs e)
        {
            PlaceItems();
        }

        private async void calendar1_ItemDatesChanged(object sender, CalendarItemEventArgs e)
        {
            if (_items.Count > 0)
            {
                //_items.Clear();
                List<CalendarItem> calendarItems = new List<CalendarItem>();
                calendarItems.AddRange(calendar1.Items);

                foreach (var item in calendarItems)
                {
                    if (item != e.Item && item.ItemId <= 0)
                    {
                        calendar1.Items.Remove(item);
                        _items.Remove(item);
                    }
                }
            }

            _items.Add(e.Item);

            listCitas.Where(x => x.IdCita == e.Item.ItemId).FirstOrDefault().FechaCitaDesde = e.Item.StartDate;
            listCitas.Where(x => x.IdCita == e.Item.ItemId).FirstOrDefault().FechaCitaHasta = e.Item.EndDate;
            
            if (await citaServices.UpdateCita(listCitas.Where(x => x.IdCita == e.Item.ItemId).FirstOrDefault()))
            {
            }
            else
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.validationMessages.GetString("ErrorInesperado"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void calendar1_ItemClick(object sender, CalendarItemEventArgs e)
        {
            if (e.Item.ItemId > 0)
            {
                //e.Item.Selected = false;
            }
        }

        private void calendar1_DayHeaderClick_1(object sender, CalendarDayEventArgs e)
        {
            calendar1.SetViewRange(e.CalendarDay.Date, e.CalendarDay.Date);
        }

        private void calendar1_ItemDoubleClick(object sender, CalendarItemEventArgs e)
        {
            //calendar1.ActivateEditMode();
            Form f;
            if(e.Item.ItemId <= 0)
            {
                f = new IngresarDatosCita(this, e.Item);
            }
            else
            {
                f = new EditarDatosCita(this, e.Item, listCitas.Where(x=>x.IdCita == e.Item.ItemId).FirstOrDefault());
            }

            f.ShowDialog(this);
        }

        private void calendar1_ItemDeleted(object sender, CalendarItemEventArgs e)
        {
            
        }

        private void calendar1_ItemMouseHover(object sender, CalendarItemEventArgs e)
        {
        }

        private async void Calendar1_ItemDeleting(object sender, CalendarItemCancelEventArgs e)
        {
            if (e.Item.ItemId > 0)
            {
                DialogResult result = ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.cadenas.GetString("ConfirmarEliminarCita"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    CitaModel cita = listCitas.Where(x => x.IdCita == e.Item.ItemId).FirstOrDefault();

                    if (cita.EstatusCita.IdEstatusCita == (int)EstatusCitaEnum.AGE)
                    {
                        e.Cancel = true;
                        ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.validationMessages.GetString("ErrorEliminarCitaAgendada"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (await citaServices.DeleteCita(cita) > 0)
                        {
                            _items.Remove(e.Item);
                        }
                        else
                        {
                            e.Cancel = true;
                            ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.validationMessages.GetString("ErrorInesperado"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void Calendar1_ItemCreating(object sender, CalendarItemCancelEventArgs e)
        {
            if (e.Item.StartDate < DateTime.Now)
            {
                e.Cancel = true;
            }
        }

        private void BgrworkerCitas_DoWork(object sender, DoWorkEventArgs e)
        {
            bool esMedico = LoginModel.Rol == RolesUsuario.Medico;

            if (Utility.CheckForInternetConnection())
            {
                try
                {
                    if (esMedico)
                    {
                        listCitas = citaServices.GetCitasByIdMedicoAndIdEstatusCita(new CitaModel()
                        {
                            Medico = new MedicoModel() { IdMedico = LoginModel.Medico.IdMedico },
                            EstatusCita = new EstatusCitaModel() { IdEstatusCita = (int)EstatusCitaEnum.AGE }
                        }).Result;
                    }
                    else
                    {
                        listCitas = citaServices.GetAllCitas().Result;
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

        private void BgrworkerCitas_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            monthView1.MonthTitleColor = monthView1.MonthTitleColorInactive = CalendarColorTable.FromHex("#C2DAFC");
            monthView1.ArrowsColor = CalendarColorTable.FromHex("#77A1D3");
            monthView1.DaySelectedBackgroundColor = CalendarColorTable.FromHex("#F4CC52");
            monthView1.DaySelectedTextColor = monthView1.ForeColor;

            calendar1.TimeScale = (CalendarTimeScale)Convert.ToInt32(LoginModel.listaConfiguracionMedico.Where(x => x.Nombre == "CitaTimeScale").FirstOrDefault().Valor);
            
            if (listCitas.Count > 0)
            {
                _items.Clear();
                calendar1.Items.Clear();
                foreach (CitaModel cit in listCitas)
                {
                    CalendarItem cal = new CalendarItem(calendar1, cit.FechaCitaDesde, cit.FechaCitaHasta, cit.Paciente.PrimerNombre + " " + cit.Paciente.PrimerApellido + " - " + cit.TipoCita.Descripcion);
                    cal.ItemId = cit.IdCita; 

                    _items.Add(cal);
                }

                PlaceItems();

                //DateTime fechaCitaInicio = Utility.GetFirstDayOfWeek(DateTime.Now, DayOfWeek.Monday).AddHours(8);
                //DateTime fechaCitaFinal = Utility.GetLastDayOfWeek(DateTime.Now, DayOfWeek.Monday).AddHours(18);

                DateTime fechaCitaInicio = DateTime.Now.Date;
                DateTime fechaCitaFinal = fechaCitaInicio.AddDays(2);

                calendar1.SetViewRange(fechaCitaInicio, fechaCitaFinal);
            }

            progressBar1.Hide();
        }

        private void BgrworkerCitas_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void BtnRecargar_Click(object sender, EventArgs e)
        {

        }

        private void KryptonPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
