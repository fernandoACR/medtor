using ControlMedicoWinForms.Models;
using ControlMedicoWinForms.Utilidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static ControlMedicoWinForms.Models.ComunModel;

namespace ControlMedicoWinForms.Catalogo.Medicamento
{
    public partial class ControlMedicamentos : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        CatalogoServices services = new CatalogoServices();
        List<MedicamentoModel> listMedicamento = new List<MedicamentoModel>();
        private int highlightedRowIndex = -1;
        private DataGridViewCellStyle highlightStyle;

        public ControlMedicamentos()
        {
            InitializeComponent();
        }

        private void ControlMedicamentos_Load(object sender, EventArgs e)
        {
            this.Font = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);
            this.kryptonRibbon1.StateCommon.RibbonGeneral.TextFont = Utility.GetMedtorFont(FontControlEnum.General);
            this.dtgvMedicamentos.StateCommon.HeaderColumn.Content.Font = Utility.GetMedtorFont(FontControlEnum.GridTitle);
            this.dtgvMedicamentos.RowsDefaultCellStyle.Font = Utility.GetMedtorFont(FontControlEnum.GridRows);

            progressBar1.Left = (this.dtgvMedicamentos.ClientSize.Width - progressBar1.Width) / 2;
            progressBar1.Top = (this.dtgvMedicamentos.ClientSize.Height - progressBar1.Height) / 2;

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
            if (dtgvMedicamentos.DataSource != null)
            {
                dtgvMedicamentos.DataSource = null;
                dtgvMedicamentos.Rows.Clear();
                dtgvMedicamentos.Columns.Clear();
            }

            dtgvMedicamentos.DataSource = listMedicamento;

            DataGridViewImageColumn img = new DataGridViewImageColumn();

            img.Name = "ImagenActivo";
            img.HeaderText = "Activo";

            dtgvMedicamentos.Columns.Add(img);
            dtgvMedicamentos.Columns[1].Visible = false;
            dtgvMedicamentos.Columns[0].HeaderText = "Id";
            dtgvMedicamentos.Columns[2].HeaderText = "Descripción";
            dtgvMedicamentos.Columns[3].Visible = false;

            highlightStyle = new DataGridViewCellStyle();
            highlightStyle.BackColor = ColorTranslator.FromHtml("#f8e187");

            for (int i = 0; i <= dtgvMedicamentos.Rows.Count - 1; i++)
            {
                if ((int)dtgvMedicamentos.Rows[i].Cells["Activo"].Value > 0)
                {
                    ((DataGridViewImageCell)dtgvMedicamentos.Rows[i].Cells["ImagenActivo"]).Value = Properties.Resources.if_status_46254;
                }
                else
                {
                    ((DataGridViewImageCell)dtgvMedicamentos.Rows[i].Cells["ImagenActivo"]).Value = Properties.Resources.iconfinder_status_offline_46253;
                    dtgvMedicamentos.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#EC7063");
                }
            }

            dtgvMedicamentos.Refresh();
        }

        private void accionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarMedicamento f = new AgregarMedicamento(this);
            f.Show(this);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarMedicamento f = new AgregarMedicamento(this);
            f.Show(this);
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void BackgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (Utility.CheckForInternetConnection())
            {
                listMedicamento = services.GetMedicamentoByIdMedico(new MedicamentoModel() { Medico = LoginModel.Medico }).Result;                          
            }
            else
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.validationMessages.GetString("SinConexion"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            LoadDatos();
            progressBar1.Hide();
        }

        private void ControlMedicamentos_SizeChanged(object sender, EventArgs e)
        {
            progressBar1.Left = (this.dtgvMedicamentos.ClientSize.Width - progressBar1.Width) / 2;
            progressBar1.Top = (this.dtgvMedicamentos.ClientSize.Height - progressBar1.Height) / 2;
        }

        private void BtnRecargar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int valor;
                DataGridViewRow row = dtgvMedicamentos.SelectedRows[0];
                {
                    valor = Convert.ToInt32(row.Cells[0].Value);
                    EditarMedicamento h = new EditarMedicamento(valor, this);
                    h.Show(this);
                }
            }
            catch (Exception)
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.cadenas.GetString("SeleccionarPatologia"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void DtgvMedicamentos_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == highlightedRowIndex) return;

            // Unhighlight the previously highlighted row.
            if (highlightedRowIndex >= 0)
            {
                Utility.SetRowStyle(dtgvMedicamentos.Rows[highlightedRowIndex], null);
            }

            // Highlight the row holding the mouse.
            highlightedRowIndex = e.RowIndex;
            if (highlightedRowIndex >= 0)
            {
                Utility.SetRowStyle(dtgvMedicamentos.Rows[highlightedRowIndex], highlightStyle);
            }
        }

        private void DtgvMedicamentos_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (highlightedRowIndex >= 0)
            {
                Utility.SetRowStyle(dtgvMedicamentos.Rows[highlightedRowIndex], null);

                highlightedRowIndex = -1;
            }
        }

        private void KryptonRibbonGroupTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            string searchValue = kryptonRibbonGroupTextBox1.Text;

            dtgvMedicamentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (searchValue != "")
            {
                try
                {
                    foreach (DataGridViewRow row in dtgvMedicamentos.Rows)
                    {
                        if (!row.Cells[2].Value.ToString().ToLower().Contains(searchValue.ToLower()))
                        {
                            CurrencyManager currencyManager = (CurrencyManager)BindingContext[dtgvMedicamentos.DataSource];
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
                foreach (DataGridViewRow row in dtgvMedicamentos.Rows)
                {
                    row.Visible = true;
                }
            }
        }
    }
}
