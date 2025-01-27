using ControlMedicoWinForms.Models;
using ControlMedicoWinForms.Reportes;
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

namespace ControlMedicoWinForms.Receta
{
    public partial class ControlRecetas : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        RecetaServices services = new RecetaServices();
        ReporteServices reporteServices = new ReporteServices();
        private int highlightedRowIndex = -1;
        private DataGridViewCellStyle highlightStyle;
        List<RecetaModel> listRecetas = new List<RecetaModel>();

        public ControlRecetas()
        {
            InitializeComponent();
        }

        private void ControlRecetas_Load(object sender, EventArgs e)
        {
            this.Font = Utility.GetMedtorFont(FontControlEnum.General);
            this.kryptonRibbon1.StateCommon.RibbonGeneral.TextFont = Utility.GetMedtorFont(FontControlEnum.General);
            this.dtgvRecetas.StateCommon.HeaderColumn.Content.Font = Utility.GetMedtorFont(FontControlEnum.GridTitle);
            this.dtgvRecetas.RowsDefaultCellStyle.Font = Utility.GetMedtorFont(FontControlEnum.GridRows);

            progressBar1.Left = (this.dtgvRecetas.ClientSize.Width - progressBar1.Width) / 2;
            progressBar1.Top = (this.dtgvRecetas.ClientSize.Height - progressBar1.Height) / 2;

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
            if (dtgvRecetas.DataSource != null)
            {
                dtgvRecetas.DataSource = null;
                dtgvRecetas.Rows.Clear();
                dtgvRecetas.Columns.Clear();
            }

            dtgvRecetas.DataSource = listRecetas;

            DataGridViewImageColumn img = new DataGridViewImageColumn();

            img.Name = "ImagenActivo";
            img.HeaderText = "Activo";

            dtgvRecetas.Columns.Add(img);

            dtgvRecetas.Columns[0].HeaderText = "";

            if (dtgvRecetas.Columns[0].Width != 100)
            {
                dtgvRecetas.Columns[0].Width = 15;
                dtgvRecetas.Columns[10].Width = 100;
                dtgvRecetas.Columns[11].Width = 300;
                dtgvRecetas.Columns[12].Width = 30;
            };

            dtgvRecetas.Columns[1].Visible = false;
            dtgvRecetas.Columns[8].Visible = false;
            dtgvRecetas.Columns[2].Visible = false;
            dtgvRecetas.Columns[3].Visible = false;
            dtgvRecetas.Columns[4].Visible = false;
            dtgvRecetas.Columns[5].Visible = false;
            dtgvRecetas.Columns[6].Visible = false;
            dtgvRecetas.Columns[7].Visible = false;
            dtgvRecetas.Columns[9].HeaderText = "Médico";
            dtgvRecetas.Columns[10].HeaderText = "Paciente";
            dtgvRecetas.Columns[11].HeaderText = "Diagnostico";            

            if (LoginModel.Medico != null)
            {
                dtgvRecetas.Columns[9].Visible = false;
            }

            dtgvRecetas.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvRecetas.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgvRecetas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            highlightStyle = new DataGridViewCellStyle();
            highlightStyle.BackColor = ColorTranslator.FromHtml("#f8e187");

            for (int i = 0; i <= dtgvRecetas.Rows.Count - 1; i++)
            {

                if ((int)dtgvRecetas.Rows[i].Cells["Activo"].Value > 0)
                {
                    ((DataGridViewImageCell)dtgvRecetas.Rows[i].Cells["ImagenActivo"]).Value = Properties.Resources.if_status_46254;
                }
                else
                {
                    ((DataGridViewImageCell)dtgvRecetas.Rows[i].Cells["ImagenActivo"]).Value = Properties.Resources.iconfinder_status_offline_46253;
                }

                PacienteModel paciente = (PacienteModel)dtgvRecetas.Rows[i].Cells["Paciente"].Value;
                dtgvRecetas.Rows[i].Cells["NombrePaciente"].Value = paciente.NombreCompleto;

                MedicoModel medico = (MedicoModel)dtgvRecetas.Rows[i].Cells["Medico"].Value;
                dtgvRecetas.Rows[i].Cells["NombreMedico"].Value = medico.Nombre;

                if (dtgvRecetas.Rows[i].Cells["Diagnostico"].Value != null)
                {
                    DiagnosticoModel diagnostico = (DiagnosticoModel)dtgvRecetas.Rows[i].Cells["Diagnostico"].Value;

                    if (diagnostico.IdDiagnostico > 0)
                    {
                        dtgvRecetas.Rows[i].Cells["DiagnosticoDescrip"].Value = diagnostico.Descripcion;
                    }
                }
            }

            dtgvRecetas.Refresh();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarReceta f = new AgregarReceta(this);
            f.Show(this);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                int valor;
                DataGridViewRow row = dtgvRecetas.SelectedRows[0];
                {
                    valor = Convert.ToInt32(row.Cells[0].Value);
                    WebViewer webViewer = new WebViewer(reporteServices.PrintRecetaByIdReceta(new RecetaModel() { IdReceta = valor }));
                    webViewer.Show();
                }
            }
            catch (Exception ex)
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show("Debe seleccionar una receta", ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtBusqueda_KeyUp(object sender, KeyEventArgs e)
        {
            string searchValue = txtBusqueda.Text;

            dtgvRecetas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (searchValue != "")
            {
                try
                {
                    foreach (DataGridViewRow row in dtgvRecetas.Rows)
                    {
                        if (!row.Cells[10].Value.ToString().ToLower().Contains(searchValue.ToLower()))
                        {
                            CurrencyManager currencyManager = (CurrencyManager)BindingContext[dtgvRecetas.DataSource];
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
                foreach (DataGridViewRow row in dtgvRecetas.Rows)
                {
                    row.Visible = true;
                }
            }
        }

        private void BtnRecargar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void DtgvRecetas_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == highlightedRowIndex) return;

            // Unhighlight the previously highlighted row.
            if (highlightedRowIndex >= 0)
            {
                Utility.SetRowStyle(dtgvRecetas.Rows[highlightedRowIndex], null);
            }

            // Highlight the row holding the mouse.
            highlightedRowIndex = e.RowIndex;
            if (highlightedRowIndex >= 0)
            {
                Utility.SetRowStyle(dtgvRecetas.Rows[highlightedRowIndex], highlightStyle);
            }
        }

        private void DtgvRecetas_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (highlightedRowIndex >= 0)
            {
                Utility.SetRowStyle(dtgvRecetas.Rows[highlightedRowIndex], null);

                highlightedRowIndex = -1;
            }
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Utility.CheckForInternetConnection())
            {
                if (LoginModel.Rol == ComunModel.RolesUsuario.Administrador)
                {
                    listRecetas = services.GetAllRecetas().Result;
                }
                else
                {
                    listRecetas = services.GetRecetaByIdMedico(new RecetaModel() { Medico = new MedicoModel() { IdMedico = LoginModel.Medico.IdMedico } }).Result;
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

        private void ControlRecetas_SizeChanged(object sender, EventArgs e)
        {
            progressBar1.Left = (this.dtgvRecetas.ClientSize.Width - progressBar1.Width) / 2;
            progressBar1.Top = (this.dtgvRecetas.ClientSize.Height - progressBar1.Height) / 2;
        }
    }
}
