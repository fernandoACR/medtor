using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlMedicoWinForms.Paciente;
using ControlMedicoWinForms.Models;
using ControlMedicoWinForms.Services;
using ControlMedicoWinForms.Utilidades;
using System.Resources;
using System.Reflection;
using ControlMedicoWinForms.Reportes;
using iTextSharp.text.pdf;
using System.IO;
using static ControlMedicoWinForms.Models.ComunModel;

namespace ControlMedicoWinForms.Paciente
{
    public partial class ControlPacientes : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        PacienteServices services = new PacienteServices();
        ReporteServices reporteServices = new ReporteServices();
        private int highlightedRowIndex = -1;
        private DataGridViewCellStyle highlightStyle;
        List<PacienteModel> listPacientes = new List<PacienteModel>();

        public ControlPacientes()
        {
            InitializeComponent();
        }

        private void ControlPacientes_Load(object sender, EventArgs e)
        {
            try
            {
                this.Font = Utility.GetMedtorFont(FontControlEnum.General);
                this.kryptonRibbon1.StateCommon.RibbonGeneral.TextFont = Utility.GetMedtorFont(FontControlEnum.General);
                this.dtgvPacientes.StateCommon.HeaderColumn.Content.Font = Utility.GetMedtorFont(FontControlEnum.GridTitle);
                this.dtgvPacientes.RowsDefaultCellStyle.Font = Utility.GetMedtorFont(FontControlEnum.GridRows);
                kryptonRibbonGroupButton1.TextLine1 = ControlLenguaje.cadenas.GetString("menuAgregar");

                progressBar1.Left = (this.dtgvPacientes.ClientSize.Width - progressBar1.Width) / 2;
                progressBar1.Top = (this.dtgvPacientes.ClientSize.Height - progressBar1.Height) / 2;

                Cargar();
            }
            catch(Exception ex)
            {
                ControlLenguaje.utility.WriteToErrorLog(AppDomain.CurrentDomain.BaseDirectory, ex);
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.validationMessages.GetString("ErrorInesperado"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void accionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarPaciente f = new AgregarPaciente(this);
            f.Show(this);
        }

        public void Cargar()
        {
            if (!backgroundWorker1.IsBusy)
            {
                progressBar1.Show();
                backgroundWorker1.RunWorkerAsync();
            }
        }

        public void LoadDatos()
        {
            if (dtgvPacientes.DataSource != null)
            {
                dtgvPacientes.DataSource = null;
                dtgvPacientes.Rows.Clear();
                dtgvPacientes.Columns.Clear();
            }

            dtgvPacientes.DataSource = listPacientes;

            //Add a DataGridViewImageColumn to display the images

            DataGridViewImageColumn img = new DataGridViewImageColumn();

            img.Name = "ImagenActivo";
            img.HeaderText = "Activo";

            dtgvPacientes.Columns.Add(img);

            dtgvPacientes.Columns[0].HeaderText = "Número";
            dtgvPacientes.Columns[0].Visible = false;
            dtgvPacientes.Columns[27].HeaderText = ControlLenguaje.cadenas.GetString("GridCampoNombre");
            dtgvPacientes.Columns[27].MinimumWidth = 70;
            dtgvPacientes.Columns[27].DisplayIndex = 1;
            dtgvPacientes.Columns[2].HeaderText = ControlLenguaje.cadenas.GetString("GridCampoTelefono");
            dtgvPacientes.Columns[33].HeaderText = ControlLenguaje.cadenas.GetString("GridCampoMovil");

            dtgvPacientes.Columns[3].HeaderText = ControlLenguaje.cadenas.GetString("GridCampoEstadoCivil"); ;

            dtgvPacientes.Columns[4].HeaderText = "Identificación";
            dtgvPacientes.Columns[16].HeaderText = "Escolaridad";
            dtgvPacientes.Columns[17].HeaderText = "Patologia";

            dtgvPacientes.Columns[15].Visible = false;
            dtgvPacientes.Columns[17].Visible = false;
            dtgvPacientes.Columns[19].Visible = false;
            dtgvPacientes.Columns[20].Visible = false;
            dtgvPacientes.Columns[21].Visible = false;
            dtgvPacientes.Columns[22].Visible = false;
            dtgvPacientes.Columns[23].Visible = false;
            dtgvPacientes.Columns[24].Visible = false;
            dtgvPacientes.Columns[25].Visible = false;
            dtgvPacientes.Columns[26].Visible = false;
            dtgvPacientes.Columns[28].Visible = false;
            dtgvPacientes.Columns[29].Visible = false;
            dtgvPacientes.Columns[30].DisplayIndex = 25;
            dtgvPacientes.Columns[30].HeaderText = "Seguro";
            dtgvPacientes.Columns[31].Visible = false;

            dtgvPacientes.Columns[1].Visible = false;
            dtgvPacientes.Columns[5].Visible = false;
            dtgvPacientes.Columns[6].Visible = false;
            dtgvPacientes.Columns[8].Visible = false;
            dtgvPacientes.Columns[9].Visible = false;
            dtgvPacientes.Columns[10].Visible = false;
            dtgvPacientes.Columns[11].Visible = false;
            dtgvPacientes.Columns[12].Visible = false;
            dtgvPacientes.Columns[13].Visible = false;
            dtgvPacientes.Columns[14].Visible = false;

            if (LoginModel.Rol != ComunModel.RolesUsuario.Administrador)
                dtgvPacientes.Columns[18].Visible = false;

            dtgvPacientes.Columns[7].HeaderText = "Correo";
            dtgvPacientes.Columns[8].HeaderText = "Fecha Nacimiento";
            //dtgvPacientes.Columns[8].Width = 200;

            dtgvPacientes.Columns[32].HeaderText = "Lugar Nacimiento";

            dtgvPacientes.Columns[16].DisplayIndex = 14;
            dtgvPacientes.Columns[17].DisplayIndex = 15;
            dtgvPacientes.Columns[15].DisplayIndex = 16;
            //dtgvPacientes.Columns[15].Width = 300;
            dtgvPacientes.Columns[5].DisplayIndex = 17;
            dtgvPacientes.Columns[32].DisplayIndex = 12;
            dtgvPacientes.Columns[33].DisplayIndex = 3;

            dtgvPacientes.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvPacientes.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgvPacientes.Columns[33].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgvPacientes.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvPacientes.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgvPacientes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            highlightStyle = new DataGridViewCellStyle();
            highlightStyle.BackColor = ColorTranslator.FromHtml("#f8e187");

            //highlightStyle.Font = new Font(dtgvPacientes.Font, FontStyle.Bold);

            for (int i = 0; i <= dtgvPacientes.Rows.Count - 1; i++)
            {
                PatologiaModel patologia = (PatologiaModel)dtgvPacientes.Rows[i].Cells["Patologia"].Value;
                if (patologia != null)
                    dtgvPacientes.Rows[i].Cells["PatologiaDescrip"].Value = patologia.Descripcion;

                EscolaridadModel escolaridad = (EscolaridadModel)dtgvPacientes.Rows[i].Cells["Escolaridad"].Value;
                if (escolaridad != null)
                    dtgvPacientes.Rows[i].Cells["EscolaridadDescrip"].Value = escolaridad.Descripcion;

                OcupacionModel ocupacion = (OcupacionModel)dtgvPacientes.Rows[i].Cells["Ocupacion"].Value;
                if (ocupacion != null)
                    dtgvPacientes.Rows[i].Cells["OcupacionDescrip"].Value = ocupacion.Descripcion;

                MedicamentoModel medicamento = (MedicamentoModel)dtgvPacientes.Rows[i].Cells["MedicamentoActual"].Value;
                if (medicamento != null)
                    dtgvPacientes.Rows[i].Cells["MedicamentoDescrip"].Value = medicamento.Descripcion;

                LugarNacimientoModel lugarNacimiento = (LugarNacimientoModel)dtgvPacientes.Rows[i].Cells["LugarNacimiento"].Value;
                if (lugarNacimiento != null)
                    dtgvPacientes.Rows[i].Cells["LugarNacimientoDescrip"].Value = lugarNacimiento.Descripcion;

                if ((int)dtgvPacientes.Rows[i].Cells["Activo"].Value > 0)
                {
                    ((DataGridViewImageCell)dtgvPacientes.Rows[i].Cells["ImagenActivo"]).Value = Properties.Resources.if_status_46254;
                }
                else
                {
                    ((DataGridViewImageCell)dtgvPacientes.Rows[i].Cells["ImagenActivo"]).Value = Properties.Resources.iconfinder_status_offline_46253;
                    dtgvPacientes.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#EC7063");
                }

                if (dtgvPacientes.Rows[i].Cells["SeguroVida"].Value != null)
                    dtgvPacientes.Rows[i].Cells["chkSeguroVida"].Value = Convert.ToBoolean(dtgvPacientes.Rows[i].Cells["SeguroVida"].Value);
            }

            dtgvPacientes.Refresh();
        }        

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int valor;
                DataGridViewRow row = dtgvPacientes.SelectedRows[0];
                {
                    valor = Convert.ToInt32(row.Cells[0].Value);
                    EditarPaciente h = new EditarPaciente(valor, this);
                    h.Show(this);
                }
            }
            catch (Exception)
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show("Debe seleccionar un paciente", ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void expedienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int valor;
                DataGridViewRow row = dtgvPacientes.SelectedRows[0];
                {
                    valor = Convert.ToInt32(row.Cells[0].Value);
                    //System.IO.Stream stream = await reporteServices.GetExpedienteByIdPaciente(new PacienteModel() { IdPaciente = valor });
                    WebViewer webViewer = new WebViewer(reporteServices.GetExpedienteByIdPaciente(new PacienteModel() { IdPaciente = valor }));
                    webViewer.Show();
                }
            }
            catch (Exception ex)
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show("Debe seleccionar un paciente", ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }           
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            string searchValue = txtBuscar.Text;

            dtgvPacientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (searchValue != "")
            {
                try
                {
                    foreach (DataGridViewRow row in dtgvPacientes.Rows)
                    {
                        if (!row.Cells[1].Value.ToString().ToLower().Contains(searchValue))
                        {
                            CurrencyManager currencyManager = (CurrencyManager)BindingContext[dtgvPacientes.DataSource];
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
                foreach (DataGridViewRow row in dtgvPacientes.Rows)
                {
                    row.Visible = true;
                }
            }
        }

        private void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void kryptonRibbonGroupButton1_Click(object sender, EventArgs e)
        {
            AgregarPaciente f = new AgregarPaciente(this);
            f.Show(this);
        }

        private void kryptonRibbonGroupButton2_Click(object sender, EventArgs e)
        {
            try
            {
                int valor;
                DataGridViewRow row = dtgvPacientes.SelectedRows[0];
                {
                    valor = Convert.ToInt32(row.Cells[0].Value);
                    EditarPaciente h = new EditarPaciente(valor, this);
                    h.Show(this);
                }
            }
            catch (Exception)
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show("Debe seleccionar un paciente", ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void kryptonRibbonGroupButton4_Click(object sender, EventArgs e)
        {
            try
            {
                int valor;
                DataGridViewRow row = dtgvPacientes.SelectedRows[0];
                {
                    valor = Convert.ToInt32(row.Cells[0].Value);
                    //System.IO.Stream stream = await reporteServices.GetExpedienteByIdPaciente(new PacienteModel() { IdPaciente = valor });
                    WebViewer webViewer = new WebViewer(reporteServices.GetExpedienteByIdPaciente(new PacienteModel() { IdPaciente = valor }));
                    webViewer.Show();
                }
            }
            catch (Exception ex)
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show("Debe seleccionar un paciente", ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void kryptonRibbonGroupTextBox2_KeyUp(object sender, KeyEventArgs e)
        {
            string searchValue = kryptonRibbonGroupTextBox2.Text;

            dtgvPacientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (searchValue != "")
            {
                try
                {
                    foreach (DataGridViewRow row in dtgvPacientes.Rows)
                    {
                        CurrencyManager currencyManager = (CurrencyManager)BindingContext[dtgvPacientes.DataSource];
                        currencyManager.SuspendBinding();

                        row.Visible = false;

                        if (row.Cells[1].Value.ToString().ToLower().Contains(searchValue.ToLower()) || row.Cells[19].Value.ToString().ToLower().Contains(searchValue.ToLower())
                            || row.Cells[20].Value.ToString().ToLower().Contains(searchValue.ToLower()) || row.Cells[21].Value.ToString().ToLower().Contains(searchValue.ToLower()))
                        {
                            row.Visible = true;                            
                        }

                        currencyManager.ResumeBinding();
                    }
                }
                catch (Exception exc)
                {
                    //ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(exc.Message);
                }
            }
            else
            {
                foreach (DataGridViewRow row in dtgvPacientes.Rows)
                {
                    row.Visible = true;
                }
            }
        }

        private void kryptonRibbon1_SelectedTabChanged(object sender, EventArgs e)
        {

        }

        private void kryptonRibbonGroupTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private async void kryptonRibbonGroupButton3_Click(object sender, EventArgs e)
        {
            try
            {
                int valor;
                DataGridViewRow row = dtgvPacientes.SelectedRows[0];
                valor = Convert.ToInt32(row.Cells[0].Value);

                DialogResult result = ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show("¿Seguro que desea eliminar el paciente seleccionado?", ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int accion = await services.DeletePaciente(new PacienteModel()
                                 {
                                    IdPaciente = Convert.ToInt32(row.Cells[0].Value)
                                 });

                    if(accion > 0)
                    {
                        ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show("Paciente eliminado correctamente", ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDatos();
                    }
                    else
                    {
                        ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show("No se pudo eliminar el paciente", ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show("Debe seleccionar un paciente", ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }            
        }

        private void BtnRecargar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void DtgvPacientes_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == highlightedRowIndex) return;

            // Unhighlight the previously highlighted row.
            if (highlightedRowIndex >= 0)
            {
                Utility.SetRowStyle(dtgvPacientes.Rows[highlightedRowIndex], null);
            }

            // Highlight the row holding the mouse.
            highlightedRowIndex = e.RowIndex;
            if (highlightedRowIndex >= 0)
            {
                Utility.SetRowStyle(dtgvPacientes.Rows[highlightedRowIndex], highlightStyle);
            }
        }

        private void DtgvPacientes_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (highlightedRowIndex >= 0)
            {
                Utility.SetRowStyle(dtgvPacientes.Rows[highlightedRowIndex], null);

                highlightedRowIndex = -1;
            }
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Utility.CheckForInternetConnection())
            {
                listPacientes = services.GetPacienteByIdMedico(new PacienteModel() { Medico = LoginModel.Medico }).Result;
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

        private void ControlPacientes_SizeChanged(object sender, EventArgs e)
        {
            progressBar1.Left = (this.dtgvPacientes.ClientSize.Width - progressBar1.Width) / 2;
            progressBar1.Top = (this.dtgvPacientes.ClientSize.Height - progressBar1.Height) / 2;
        }

        private void ProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void BtnReportes_Click(object sender, EventArgs e)
        {
            WebViewer webViewer = new WebViewer(reporteServices.PrintReporteByIdTipoReporteAndIdMedico(new ConfiguracionReporteModel()));
            webViewer.Show();
        }
    }
}
