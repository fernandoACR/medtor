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

namespace ControlMedicoWinForms.Catalogo.Patologia
{
    public partial class ControlPatologias : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        CatalogoServices services = new CatalogoServices();
        List<PatologiaModel> listPatologia = new List<PatologiaModel>();
        private int highlightedRowIndex = -1;
        private DataGridViewCellStyle highlightStyle;

        public ControlPatologias()
        {
            InitializeComponent();
        }

        private void ControlPatologias_Load(object sender, EventArgs e)
        {
            this.Font = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);
            this.kryptonRibbon1.StateCommon.RibbonGeneral.TextFont = Utility.GetMedtorFont(FontControlEnum.General);
            this.dtgvPatologias.StateCommon.HeaderColumn.Content.Font = Utility.GetMedtorFont(FontControlEnum.GridTitle);
            this.dtgvPatologias.RowsDefaultCellStyle.Font = Utility.GetMedtorFont(FontControlEnum.GridRows);

            progressBar1.Left = (this.dtgvPatologias.ClientSize.Width - progressBar1.Width) / 2;
            progressBar1.Top = (this.dtgvPatologias.ClientSize.Height - progressBar1.Height) / 2;

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
            if (dtgvPatologias.DataSource != null)
            {
                dtgvPatologias.DataSource = null;
                dtgvPatologias.Rows.Clear();
                dtgvPatologias.Columns.Clear();
            }

            dtgvPatologias.DataSource = listPatologia;

            DataGridViewImageColumn img = new DataGridViewImageColumn();

            img.Name = "ImagenActivo";
            img.HeaderText = "Activo";

            dtgvPatologias.Columns.Add(img);
            dtgvPatologias.Columns[0].HeaderText = "Id";
            dtgvPatologias.Columns[1].HeaderText = ControlLenguaje.cadenas.GetString("TextoCampoClave");
            dtgvPatologias.Columns[2].HeaderText = ControlLenguaje.cadenas.GetString("TextoCampoDescripcion");
            dtgvPatologias.Columns[3].Visible = false;
            dtgvPatologias.Columns[4].Visible = false;

            highlightStyle = new DataGridViewCellStyle();
            highlightStyle.BackColor = ColorTranslator.FromHtml("#f8e187");

            for (int i = 0; i <= dtgvPatologias.Rows.Count - 1; i++)
            {
                if ((int)dtgvPatologias.Rows[i].Cells["Activo"].Value > 0)
                {
                    ((DataGridViewImageCell)dtgvPatologias.Rows[i].Cells["ImagenActivo"]).Value = Properties.Resources.if_status_46254;
                }
                else
                {
                    ((DataGridViewImageCell)dtgvPatologias.Rows[i].Cells["ImagenActivo"]).Value = Properties.Resources.iconfinder_status_offline_46253;
                    dtgvPatologias.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#EC7063");
                }
            }

            dtgvPatologias.Refresh();
        }

        private void accionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarPatologia f = new AgregarPatologia(this);
            f.Show(this);
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int valor;
                DataGridViewRow row = dtgvPatologias.SelectedRows[0];
                {
                    valor = Convert.ToInt32(row.Cells[0].Value);
                    EditarPatologia h = new EditarPatologia(valor, this);
                    h.Show(this);
                }
            }
            catch (Exception)
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.cadenas.GetString("SeleccionarPatologia"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarPatologia f = new AgregarPatologia(this);
            f.Show(this);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int valor;
                DataGridViewRow row = dtgvPatologias.SelectedRows[0];
                {
                    valor = Convert.ToInt32(row.Cells[0].Value);
                    EditarPatologia h = new EditarPatologia(valor, this);
                    h.Show(this);
                }
            }
            catch (Exception)
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.cadenas.GetString("SeleccionarPatologia"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void KryptonRibbonGroup2_DialogBoxLauncherClick(object sender, EventArgs e)
        {

        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Utility.CheckForInternetConnection())
            {
                listPatologia = services.GetPatologiaByIdMedico(new PatologiaModel() { Medico = LoginModel.Medico }).Result;
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

        private void BtnRecargar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void ControlPatologias_SizeChanged(object sender, EventArgs e)
        {
            progressBar1.Left = (this.dtgvPatologias.ClientSize.Width - progressBar1.Width) / 2;
            progressBar1.Top = (this.dtgvPatologias.ClientSize.Height - progressBar1.Height) / 2;
        }

        private void DtgvPatologias_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == highlightedRowIndex) return;

            // Unhighlight the previously highlighted row.
            if (highlightedRowIndex >= 0)
            {
                Utility.SetRowStyle(dtgvPatologias.Rows[highlightedRowIndex], null);
            }

            // Highlight the row holding the mouse.
            highlightedRowIndex = e.RowIndex;
            if (highlightedRowIndex >= 0)
            {
                Utility.SetRowStyle(dtgvPatologias.Rows[highlightedRowIndex], highlightStyle);
            }
        }

        private void DtgvPatologias_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (highlightedRowIndex >= 0)
            {
                Utility.SetRowStyle(dtgvPatologias.Rows[highlightedRowIndex], null);

                highlightedRowIndex = -1;
            }
        }

        private void KryptonRibbonGroupTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            string searchValue = kryptonRibbonGroupTextBox1.Text;

            dtgvPatologias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (searchValue != "")
            {
                try
                {
                    foreach (DataGridViewRow row in dtgvPatologias.Rows)
                    {
                        if (!row.Cells[2].Value.ToString().ToLower().Contains(searchValue.ToLower()))
                        {
                            CurrencyManager currencyManager = (CurrencyManager)BindingContext[dtgvPatologias.DataSource];
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
                foreach (DataGridViewRow row in dtgvPatologias.Rows)
                {
                    row.Visible = true;
                }
            }
        }
    }
}
