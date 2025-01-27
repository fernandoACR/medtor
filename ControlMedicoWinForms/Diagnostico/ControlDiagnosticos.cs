using ControlMedicoWinForms.Models;
using ControlMedicoWinForms.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ControlMedicoWinForms.Models.ComunModel;

namespace ControlMedicoWinForms.Diagnostico
{
    public partial class ControlDiagnosticos : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        DiagnosticoServices services = new DiagnosticoServices();
        private int highlightedRowIndex = -1;
        private DataGridViewCellStyle highlightStyle;
        List<DiagnosticoModel> listDiagnosticos = new List<DiagnosticoModel>();

        public ControlDiagnosticos()
        {
            InitializeComponent();
        }

        private void ControlDiagnosticos_Load(object sender, EventArgs e)
        {
            this.Font = Utility.GetMedtorFont(FontControlEnum.General);
            this.kryptonRibbon1.StateCommon.RibbonGeneral.TextFont = Utility.GetMedtorFont(FontControlEnum.General);
            this.dtgvDiagnosticos.StateCommon.HeaderColumn.Content.Font = Utility.GetMedtorFont(FontControlEnum.GridTitle);
            this.dtgvDiagnosticos.RowsDefaultCellStyle.Font = Utility.GetMedtorFont(FontControlEnum.GridRows);

            progressBar1.Left = (this.dtgvDiagnosticos.ClientSize.Width - progressBar1.Width) / 2;
            progressBar1.Top = (this.dtgvDiagnosticos.ClientSize.Height - progressBar1.Height) / 2;

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

        public void LoadDatos()
        {
            if (dtgvDiagnosticos.DataSource != null)
            {
                dtgvDiagnosticos.DataSource = null;
                dtgvDiagnosticos.Rows.Clear();
                dtgvDiagnosticos.Columns.Clear();
            }

            dtgvDiagnosticos.DataSource = listDiagnosticos;

            DataGridViewImageColumn img = new DataGridViewImageColumn();

            img.Name = "ImagenActivo";
            img.HeaderText = "Activo";

            dtgvDiagnosticos.Columns.Add(img);

            dtgvDiagnosticos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvDiagnosticos.Columns[1].Visible = false;
            dtgvDiagnosticos.Columns[2].Visible = false;
            dtgvDiagnosticos.Columns[8].Visible = false;
            dtgvDiagnosticos.Columns[9].Visible = false;
            dtgvDiagnosticos.Columns[7].Visible = false;
            dtgvDiagnosticos.Columns[12].Visible = false;

            DataGridViewColumn numeroColumn = dtgvDiagnosticos.Columns[0];
            numeroColumn.Visible = false;
            numeroColumn.HeaderText = "Número";
            numeroColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewColumn pacienteColumn = dtgvDiagnosticos.Columns[11];
            pacienteColumn.HeaderText = "Paciente";
            pacienteColumn.DisplayIndex = 2;
            pacienteColumn.Width = 200;

            DataGridViewColumn medicoColumn = dtgvDiagnosticos.Columns[10];
            medicoColumn.HeaderText = "Médico";
            medicoColumn.DisplayIndex = 3;
            medicoColumn.Width = 200;

            DataGridViewColumn descripcionColumn = dtgvDiagnosticos.Columns[3];
            descripcionColumn.Width = 250;

            if (LoginModel.Rol == ComunModel.RolesUsuario.Medico)
            {
                medicoColumn.Visible = false;
            }

            DataGridViewColumn activoColumn = dtgvDiagnosticos.Columns[7];
            activoColumn.HeaderText = "Activo";
            activoColumn.Width = 50;
            activoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgvDiagnosticos.Columns[4].Width = 70;
            dtgvDiagnosticos.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgvDiagnosticos.Columns[5].Width = 70;
            dtgvDiagnosticos.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgvDiagnosticos.Columns[6].Width = 200;
            dtgvDiagnosticos.Columns[13].Width = 70;

            highlightStyle = new DataGridViewCellStyle();
            highlightStyle.BackColor = ColorTranslator.FromHtml("#f8e187");

            for (int i = 0; i <= dtgvDiagnosticos.Rows.Count - 1; i++)
            {
                PacienteModel paciente = (PacienteModel)dtgvDiagnosticos.Rows[i].Cells["Paciente"].Value;
                dtgvDiagnosticos.Rows[i].Cells["NombrePaciente"].Value = paciente.NombreCompleto;

                MedicoModel medico = (MedicoModel)dtgvDiagnosticos.Rows[i].Cells["Medico"].Value;
                dtgvDiagnosticos.Rows[i].Cells["NombreMedico"].Value = medico.Nombre;

                if ((int)dtgvDiagnosticos.Rows[i].Cells["Activo"].Value > 0)
                {
                    ((DataGridViewImageCell)dtgvDiagnosticos.Rows[i].Cells["ImagenActivo"]).Value = Properties.Resources.if_status_46254;
                }
                else
                {
                    ((DataGridViewImageCell)dtgvDiagnosticos.Rows[i].Cells["ImagenActivo"]).Value = Properties.Resources.iconfinder_status_offline_46253;
                    dtgvDiagnosticos.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#EC7063");
                }
            }

            dtgvDiagnosticos.Refresh();
        }

        private void accionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarDiagnostico f = new AgregarDiagnostico(this);
            f.Show(this);
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int valor;
                DataGridViewRow row = dtgvDiagnosticos.SelectedRows[0];
                {
                    valor = Convert.ToInt32(row.Cells[0].Value);
                    EditarDiagnostico h = new EditarDiagnostico(valor, this);
                    h.Show(this);
                }
            }
            catch (Exception)
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show("Debe seleccionar un diagnostico", ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarDiagnostico f = new AgregarDiagnostico(this);
            f.Show(this);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int valor;
                DataGridViewRow row = dtgvDiagnosticos.SelectedRows[0];
                {
                    valor = Convert.ToInt32(row.Cells[0].Value);
                    EditarDiagnostico h = new EditarDiagnostico(valor, this);
                    h.Show(this);
                }
            }
            catch (Exception)
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show("Debe seleccionar un diagnostico", ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void txtBusqueda_KeyUp(object sender, KeyEventArgs e)
        {
            string searchValue = txtBusqueda.Text;

            dtgvDiagnosticos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (searchValue != "")
            {
                try
                {
                    foreach (DataGridViewRow row in dtgvDiagnosticos.Rows)
                    {
                        if (!row.Cells[11].Value.ToString().ToLower().Contains(searchValue.ToLower()))
                        {
                            CurrencyManager currencyManager = (CurrencyManager)BindingContext[dtgvDiagnosticos.DataSource];
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
                foreach (DataGridViewRow row in dtgvDiagnosticos.Rows)
                {
                    row.Visible = true;
                }
            }
        }

        private void BtnRecargar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void DtgvDiagnosticos_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == highlightedRowIndex) return;

            // Unhighlight the previously highlighted row.
            if (highlightedRowIndex >= 0)
            {
                Utility.SetRowStyle(dtgvDiagnosticos.Rows[highlightedRowIndex], null);
            }

            // Highlight the row holding the mouse.
            highlightedRowIndex = e.RowIndex;
            if (highlightedRowIndex >= 0)
            {
                Utility.SetRowStyle(dtgvDiagnosticos.Rows[highlightedRowIndex], highlightStyle);
            }
        }

        private void DtgvDiagnosticos_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (highlightedRowIndex >= 0)
            {
                Utility.SetRowStyle(dtgvDiagnosticos.Rows[highlightedRowIndex], null);

                highlightedRowIndex = -1;
            }
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Utility.CheckForInternetConnection())
            {
                if (LoginModel.Rol == ComunModel.RolesUsuario.Administrador)
                {
                    listDiagnosticos = services.GetAllDiagnosticos().Result;
                }
                else
                {
                    listDiagnosticos = services.GetDiagnosticoByIdMedico(new DiagnosticoModel() { Medico = new MedicoModel() { IdMedico = LoginModel.Medico.IdMedico } }).Result;
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

        private void ControlDiagnosticos_SizeChanged(object sender, EventArgs e)
        {
            progressBar1.Left = (this.dtgvDiagnosticos.ClientSize.Width - progressBar1.Width) / 2;
            progressBar1.Top = (this.dtgvDiagnosticos.ClientSize.Height - progressBar1.Height) / 2;
        }
    }
}
