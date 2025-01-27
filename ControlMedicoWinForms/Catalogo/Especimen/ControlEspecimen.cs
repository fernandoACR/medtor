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

namespace ControlMedicoWinForms.Catalogo.Especimen
{
    public partial class ControlEspecimen : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        private int highlightedRowIndex = -1;
        private DataGridViewCellStyle highlightStyle;

        CatalogoServices services = new CatalogoServices();
        List<EspecimenModel> listEspecimen = new List<EspecimenModel>();

        public ControlEspecimen()
        {
            InitializeComponent();
        }

        public void LoadDatos()
        {
            if (dtgvEspecimen.DataSource != null)
            {
                dtgvEspecimen.DataSource = null;
                dtgvEspecimen.Rows.Clear();
                dtgvEspecimen.Columns.Clear();
            }

            dtgvEspecimen.DataSource = listEspecimen;

            DataGridViewImageColumn img = new DataGridViewImageColumn();

            img.Name = "ImagenActivo";
            img.HeaderText = "Activo";

            dtgvEspecimen.Columns.Add(img);

            dtgvEspecimen.Columns[0].HeaderText = "Id";
            dtgvEspecimen.Columns[1].HeaderText = ControlLenguaje.cadenas.GetString("TextoCampoDescripcion");
            dtgvEspecimen.Columns[2].Visible = false;
            dtgvEspecimen.Columns[3].Visible = false;

            highlightStyle = new DataGridViewCellStyle();
            highlightStyle.BackColor = ColorTranslator.FromHtml("#f8e187");

            for (int i = 0; i <= dtgvEspecimen.Rows.Count - 1; i++)
            {
                if ((int)dtgvEspecimen.Rows[i].Cells["Activo"].Value > 0)
                {
                    ((DataGridViewImageCell)dtgvEspecimen.Rows[i].Cells["ImagenActivo"]).Value = Properties.Resources.if_status_46254;
                }
                else
                {
                    ((DataGridViewImageCell)dtgvEspecimen.Rows[i].Cells["ImagenActivo"]).Value = Properties.Resources.iconfinder_status_offline_46253;
                    dtgvEspecimen.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#EC7063");
                }
            }

            dtgvEspecimen.Refresh();
        }

        private void accionesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AgregarEspecimen f = new AgregarEspecimen(this);
            f.Show(this);
        }

        private void ControlEspecimen_Load(object sender, EventArgs e)
        {
            this.Font = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);
            this.kryptonRibbon1.StateCommon.RibbonGeneral.TextFont = Utility.GetMedtorFont(FontControlEnum.General);
            this.dtgvEspecimen.StateCommon.HeaderColumn.Content.Font = Utility.GetMedtorFont(FontControlEnum.GridTitle);
            this.dtgvEspecimen.RowsDefaultCellStyle.Font = Utility.GetMedtorFont(FontControlEnum.GridRows);

            progressBar1.Left = (this.dtgvEspecimen.ClientSize.Width - progressBar1.Width) / 2;
            progressBar1.Top = (this.dtgvEspecimen.ClientSize.Height - progressBar1.Height) / 2;

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

        private void editarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                int valor;
                DataGridViewRow row = dtgvEspecimen.SelectedRows[0];
                {
                    valor = Convert.ToInt32(row.Cells[0].Value);
                    EditarEspecimen h = new EditarEspecimen(valor, this);
                    h.Show(this);
                }
            }
            catch (Exception)
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.cadenas.GetString("SeleccionarEspecimen"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarEspecimen f = new AgregarEspecimen(this);
            f.Show(this);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int valor;
                DataGridViewRow row = dtgvEspecimen.SelectedRows[0];
                {
                    valor = Convert.ToInt32(row.Cells[0].Value);
                    EditarEspecimen h = new EditarEspecimen(valor, this);
                    h.Show(this);
                }
            }
            catch (Exception)
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.cadenas.GetString("SeleccionarEspecimen"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dtgvEspecimen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Utility.CheckForInternetConnection())
            {
                listEspecimen = services.GetEspecimenByIdMedico(new EspecimenModel() { Medico = LoginModel.Medico }).Result;
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

        private void ControlEspecimen_SizeChanged(object sender, EventArgs e)
        {
            progressBar1.Left = (this.dtgvEspecimen.ClientSize.Width - progressBar1.Width) / 2;
            progressBar1.Top = (this.dtgvEspecimen.ClientSize.Height - progressBar1.Height) / 2;
        }

        private void BtnRecargar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void DtgvEspecimen_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == highlightedRowIndex) return;

            // Unhighlight the previously highlighted row.
            if (highlightedRowIndex >= 0)
            {
                Utility.SetRowStyle(dtgvEspecimen.Rows[highlightedRowIndex], null);
            }

            // Highlight the row holding the mouse.
            highlightedRowIndex = e.RowIndex;
            if (highlightedRowIndex >= 0)
            {
                Utility.SetRowStyle(dtgvEspecimen.Rows[highlightedRowIndex], highlightStyle);
            }
        }

        private void DtgvEspecimen_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (highlightedRowIndex >= 0)
            {
                Utility.SetRowStyle(dtgvEspecimen.Rows[highlightedRowIndex], null);

                highlightedRowIndex = -1;
            }
        }

        private void TxtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            string searchValue = txtBuscar.Text;

            dtgvEspecimen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (searchValue != "")
            {
                try
                {
                    foreach (DataGridViewRow row in dtgvEspecimen.Rows)
                    {
                        if (!row.Cells[1].Value.ToString().ToLower().Contains(searchValue.ToLower()))
                        {
                            CurrencyManager currencyManager = (CurrencyManager)BindingContext[dtgvEspecimen.DataSource];
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
                foreach (DataGridViewRow row in dtgvEspecimen.Rows)
                {
                    row.Visible = true;
                }
            }
        }
    }
}
