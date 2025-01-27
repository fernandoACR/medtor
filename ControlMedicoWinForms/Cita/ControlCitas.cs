using ControlMedicoWinForms.Medico;
using ControlMedicoWinForms.Models;
using ControlMedicoWinForms.Reportes;
using ControlMedicoWinForms.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ControlMedicoWinForms.Models.ComunModel;

namespace ControlMedicoWinForms.Cita
{
    public partial class ControlCitas : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        CitaServices services = new CitaServices();
        MedicoServices medicoServices = new MedicoServices();
        ReporteServices reporteServices = new ReporteServices();

        private int highlightedRowIndex = -1;
        private DataGridViewCellStyle highlightStyle;
        List<CitaModel> listCitas = new List<CitaModel>();

        public ControlCitas()
        {
            InitializeComponent();
        }

        public void LoadDatos()
        {
            bool esMedico = LoginModel.Rol == RolesUsuario.Medico;

            dtgvCitas.DataSource = listCitas;

            dtgvCitas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvCitas.Columns[1].Visible = false;
            dtgvCitas.Columns[2].Visible = false;
            dtgvCitas.Columns[3].Visible = false;
            dtgvCitas.Columns[4].Visible = false;
            dtgvCitas.Columns[5].Visible = false;
            dtgvCitas.Columns[8].Visible = false;
            dtgvCitas.Columns[12].Visible = false;
            dtgvCitas.Columns[15].Visible = false;

            DataGridViewColumn numeroColumn = dtgvCitas.Columns[0];
            numeroColumn.Visible = true;
            numeroColumn.HeaderText = "";
            numeroColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            numeroColumn.DisplayIndex = 0;
            numeroColumn.Width = 40;

            DataGridViewColumn medicoColumn = dtgvCitas.Columns[10];

            if (!esMedico)
            {
                medicoColumn.HeaderText = "Médico";
                medicoColumn.DisplayIndex = 2;
                //medicoColumn.Width = 200;
            }
            else
            {
                medicoColumn.Visible = false;
            }

            DataGridViewColumn pacienteColumn = dtgvCitas.Columns[9];
            pacienteColumn.HeaderText = "Paciente";
            pacienteColumn.DisplayIndex = 1;
            pacienteColumn.MinimumWidth = 150;

            DataGridViewColumn tipoCitaDescripColumn = dtgvCitas.Columns[13];
            tipoCitaDescripColumn.HeaderText = "Tipo Cita";
            tipoCitaDescripColumn.DisplayIndex = 2;
            tipoCitaDescripColumn.Width = 100;

            DataGridViewColumn fechaCitaDescripColumn = dtgvCitas.Columns[11];
            fechaCitaDescripColumn.HeaderText = "Fecha";
            fechaCitaDescripColumn.Width = 100;
            fechaCitaDescripColumn.DisplayIndex = 3;

            DataGridViewColumn horaCitaDesdeDescripColumn = dtgvCitas.Columns[17];
            horaCitaDesdeDescripColumn.HeaderText = "Desde";
            horaCitaDesdeDescripColumn.Width = 100;
            horaCitaDesdeDescripColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            horaCitaDesdeDescripColumn.DisplayIndex = 4;

            DataGridViewColumn horaCitaHastaDescripColumn = dtgvCitas.Columns[16];
            horaCitaHastaDescripColumn.HeaderText = "Hasta";
            horaCitaHastaDescripColumn.Width = 100;
            horaCitaHastaDescripColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            horaCitaHastaDescripColumn.DisplayIndex = 5;

            DataGridViewColumn tituloColumn = dtgvCitas.Columns[6];
            tituloColumn.HeaderText = "Comentarios";
            //tituloColumn.Width = 200;
            tituloColumn.DisplayIndex = 6;
            tituloColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            DataGridViewColumn comentariosColumn = dtgvCitas.Columns[7];
            comentariosColumn.HeaderText = "Titulo";
            //comentariosColumn.Width = 200;
            comentariosColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            comentariosColumn.DisplayIndex = 7;

            DataGridViewColumn estatusCitaDescripColumn = dtgvCitas.Columns[14];
            estatusCitaDescripColumn.HeaderText = "Estatus";
            estatusCitaDescripColumn.DisplayIndex = 8;
            estatusCitaDescripColumn.Width = 150;

            DataGridViewColumn notificaEmailColumn = dtgvCitas.Columns[18];
            notificaEmailColumn.HeaderText = "Notificado Email";
            notificaEmailColumn.Visible = false;

            DataGridViewColumn notificaSMSColumn = dtgvCitas.Columns[19];
            notificaSMSColumn.HeaderText = "Notificado SMS";
            notificaSMSColumn.Visible = false;

            DataGridViewColumn notificaWHPColumn = dtgvCitas.Columns[20];
            notificaWHPColumn.HeaderText = "Notificado Whatsapp";
            notificaWHPColumn.Visible = false;

            dtgvCitas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            highlightStyle = new DataGridViewCellStyle();
            highlightStyle.BackColor = ColorTranslator.FromHtml("#f8e187");

            for (int i = 0; i <= dtgvCitas.Rows.Count - 1; i++)
            {
                PacienteModel paciente = (PacienteModel)dtgvCitas.Rows[i].Cells["Paciente"].Value;
                dtgvCitas.Rows[i].Cells["NombrePaciente"].Value = paciente.NombreCompleto;

                MedicoModel medico = (MedicoModel)dtgvCitas.Rows[i].Cells["Medico"].Value;
                dtgvCitas.Rows[i].Cells["NombreMedico"].Value = medico.Nombre;

                TipoCitaModel tipoCita = (TipoCitaModel)dtgvCitas.Rows[i].Cells["TipoCita"].Value;
                dtgvCitas.Rows[i].Cells["TipoCitaDescrip"].Value = tipoCita.Descripcion;

                EstatusCitaModel estatusCita = (EstatusCitaModel)dtgvCitas.Rows[i].Cells["EstatusCita"].Value;
                dtgvCitas.Rows[i].Cells["EstatusCitaDescrip"].Value = estatusCita.Descripcion;

                if (estatusCita.IdEstatusCita == (int)EstatusCitaEnum.CNC)
                {
                    dtgvCitas.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#EC7063");
                };

                dtgvCitas.Rows[i].Cells["FechaCitaDesdeDescrip"].Value = Convert.ToDateTime(dtgvCitas.Rows[i].Cells["FechaCitaDesde"].Value).ToString("dd/MM/yyyy");

                dtgvCitas.Rows[i].Cells["HoraCitaDesdeDescrip"].Value = Convert.ToDateTime(dtgvCitas.Rows[i].Cells["FechaCitaDesde"].Value).ToString("hh:mm tt");

                dtgvCitas.Rows[i].Cells["HoraCitaHastaDescrip"].Value = Convert.ToDateTime(dtgvCitas.Rows[i].Cells["FechaCitaHasta"].Value).ToString("hh:mm tt");
            }

            dtgvCitas.Refresh();
        }

        private void ControlCitas_Load(object sender, EventArgs e)
        {
            this.Font = Utility.GetMedtorFont(FontControlEnum.General);
            this.kryptonRibbon1.StateCommon.RibbonGeneral.TextFont = Utility.GetMedtorFont(FontControlEnum.General);
            this.dtgvCitas.StateCommon.HeaderColumn.Content.Font = Utility.GetMedtorFont(FontControlEnum.GridTitle);
            this.dtgvCitas.RowsDefaultCellStyle.Font = Utility.GetMedtorFont(FontControlEnum.GridRows);

            progressBar1.Left = (this.dtgvCitas.ClientSize.Width - progressBar1.Width) / 2;
            progressBar1.Top = (this.dtgvCitas.ClientSize.Height - progressBar1.Height) / 2;

            Cargar();
        }

        public void Cargar()
        {
            if (!backgroundWorker1.IsBusy)
            {
                progressBar1.Show();
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void accionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarCita f = new AgregarCita(this);
            f.Show(this);
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int valor;
                DataGridViewRow row = dtgvCitas.SelectedRows[0];
                {
                    valor = Convert.ToInt32(row.Cells[0].Value);
                    EditarCita h = new EditarCita(valor, this);
                    h.Show(this);
                }
            }
            catch (Exception)
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.cadenas.GetString("SeleccionarCita"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarCita f = new AgregarCita(this);
            f.Show(this);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int valor;
                DataGridViewRow row = dtgvCitas.SelectedRows[0];
                {
                    valor = Convert.ToInt32(row.Cells[0].Value);
                    EditarCita h = new EditarCita(valor, this);
                    h.Show(this);
                }
            }
            catch (Exception)
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.cadenas.GetString("SeleccionarCita"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                WebViewer webViewer = new WebViewer(reporteServices.PrintCitasByFecha(DateTime.Now));
                webViewer.Show();
            }
            catch (Exception ex)
            {
                ControlLenguaje.utility.WriteToErrorLog(AppDomain.CurrentDomain.BaseDirectory, ex);
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.validationMessages.GetString("ErrorInesperado"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBusqueda_KeyUp(object sender, KeyEventArgs e)
        {
            string searchValue = txtBusqueda.Text;

            dtgvCitas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (searchValue != "")
            {
                try
                {
                    foreach (DataGridViewRow row in dtgvCitas.Rows)
                    {
                        if (!row.Cells[9].Value.ToString().ToLower().Contains(searchValue.ToLower()))
                        {
                            CurrencyManager currencyManager = (CurrencyManager)BindingContext[dtgvCitas.DataSource];
                            currencyManager.SuspendBinding();
                            row.Visible = false;
                            currencyManager.ResumeBinding();
                        }
                    }
                }
                catch (Exception exc)
                {
                    //ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(exc.Message);
                }
            }
            else
            {
                foreach (DataGridViewRow row in dtgvCitas.Rows)
                {
                    row.Visible = true;
                }
            }
        }

        private void BtnRecargar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void DtgvCitas_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == highlightedRowIndex) return;

            // Unhighlight the previously highlighted row.
            if (highlightedRowIndex >= 0)
            {
                Utility.SetRowStyle(dtgvCitas.Rows[highlightedRowIndex], null);
            }

            // Highlight the row holding the mouse.
            highlightedRowIndex = e.RowIndex;
            if (highlightedRowIndex >= 0)
            {
                Utility.SetRowStyle(dtgvCitas.Rows[highlightedRowIndex], highlightStyle);
            }
        }

        private void DtgvCitas_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (highlightedRowIndex >= 0)
            {
                Utility.SetRowStyle(dtgvCitas.Rows[highlightedRowIndex], null);

                highlightedRowIndex = -1;
            }
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Utility.CheckForInternetConnection())
            {
                bool esMedico = LoginModel.Rol == ComunModel.RolesUsuario.Medico;
                
                if (esMedico)
                {
                    listCitas = services.GetCitasByIdMedico(new CitaModel() { Medico = new MedicoModel() { IdMedico = LoginModel.Medico.IdMedico } }).Result;
                }
                else
                {
                    listCitas = services.GetAllCitas().Result;
                }                
            }
            else
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.validationMessages.GetString("SinConexion"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LoadDatos();
            progressBar1.Hide();
        }

        private void ControlCitas_SizeChanged(object sender, EventArgs e)
        {
            progressBar1.Left = (this.dtgvCitas.ClientSize.Width - progressBar1.Width) / 2;
            progressBar1.Top = (this.dtgvCitas.ClientSize.Height - progressBar1.Height) / 2;
        }
    }
}
