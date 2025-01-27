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

namespace ControlMedicoWinForms.Catalogo.Especialidad
{
    public partial class ControlEspecialidades : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        private int highlightedRowIndex = -1;
        private DataGridViewCellStyle highlightStyle;

        CatalogoServices services = new CatalogoServices();
        List<EspecialidadModel> listEspecialidad = new List<EspecialidadModel>();

        public ControlEspecialidades()
        {
            InitializeComponent();
        }

        private void accionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarEspecialidad f = new AgregarEspecialidad(this);
            f.Show(this);
        }

        private void ControlEspecialidades_Load(object sender, EventArgs e)
        {
            this.Font = Utility.GetMedtorFont(FontControlEnum.General);
            this.kryptonRibbon1.StateCommon.RibbonGeneral.TextFont = Utility.GetMedtorFont(FontControlEnum.General);
            this.dtgvEspecialidades.StateCommon.HeaderColumn.Content.Font = Utility.GetMedtorFont(FontControlEnum.GridTitle);
            this.dtgvEspecialidades.RowsDefaultCellStyle.Font = Utility.GetMedtorFont(FontControlEnum.GridRows);

            progressBar1.Left = (this.dtgvEspecialidades.ClientSize.Width - progressBar1.Width) / 2;
            progressBar1.Top = (this.dtgvEspecialidades.ClientSize.Height - progressBar1.Height) / 2;

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
            if (dtgvEspecialidades.DataSource != null)
            {
                dtgvEspecialidades.DataSource = null;
                dtgvEspecialidades.Rows.Clear();
                dtgvEspecialidades.Columns.Clear();
            }

            dtgvEspecialidades.DataSource = listEspecialidad;

            DataGridViewImageColumn img = new DataGridViewImageColumn();

            img.Name = "ImagenActivo";
            img.HeaderText = "Activo";

            dtgvEspecialidades.Columns.Add(img);
            dtgvEspecialidades.Columns[0].HeaderText = "Id";
            dtgvEspecialidades.Columns[1].HeaderText = "Descripción";
            dtgvEspecialidades.Columns[1].Width = 200;
            dtgvEspecialidades.Columns[2].Visible = false;

            highlightStyle = new DataGridViewCellStyle();
            highlightStyle.BackColor = ColorTranslator.FromHtml("#f8e187");

            for (int i = 0; i <= dtgvEspecialidades.Rows.Count - 1; i++)
            {
                if ((int)dtgvEspecialidades.Rows[i].Cells["Activo"].Value > 0)
                {
                    ((DataGridViewImageCell)dtgvEspecialidades.Rows[i].Cells["ImagenActivo"]).Value = Properties.Resources.if_status_46254;
                }
                else
                {
                    ((DataGridViewImageCell)dtgvEspecialidades.Rows[i].Cells["ImagenActivo"]).Value = Properties.Resources.iconfinder_status_offline_46253;
                    dtgvEspecialidades.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#EC7063");
                }
            }

            dtgvEspecialidades.Refresh();
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int valor;
                DataGridViewRow row = dtgvEspecialidades.SelectedRows[0];
                {
                    valor = Convert.ToInt32(row.Cells[0].Value);
                    EditarEspecialidad h = new EditarEspecialidad(valor, this);
                    h.Show(this);
                }
            }
            catch (Exception)
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.cadenas.GetString("SeleccionarEspecialidad"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarEspecialidad f = new AgregarEspecialidad(this);
            f.Show(this);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int valor;
                DataGridViewRow row = dtgvEspecialidades.SelectedRows[0];
                {
                    valor = Convert.ToInt32(row.Cells[0].Value);
                    EditarEspecialidad h = new EditarEspecialidad(valor, this);
                    h.Show(this);
                }
            }
            catch (Exception)
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.cadenas.GetString("SeleccionarEspecialidad"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void kryptonRibbonGroupButton3_Click(object sender, EventArgs e)
        {

        }

        private void DtgvEspecialidades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Utility.CheckForInternetConnection())
            {
                listEspecialidad = services.GetAllEspecialidades().Result;            
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

        private void ControlEspecialidades_SizeChanged(object sender, EventArgs e)
        {
            progressBar1.Left = (this.dtgvEspecialidades.ClientSize.Width - progressBar1.Width) / 2;
            progressBar1.Top = (this.dtgvEspecialidades.ClientSize.Height - progressBar1.Height) / 2;
        }

        private void BtnRecargar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void DtgvEspecialidades_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == highlightedRowIndex) return;

            // Unhighlight the previously highlighted row.
            if (highlightedRowIndex >= 0)
            {
                Utility.SetRowStyle(dtgvEspecialidades.Rows[highlightedRowIndex], null);
            }

            // Highlight the row holding the mouse.
            highlightedRowIndex = e.RowIndex;
            if (highlightedRowIndex >= 0)
            {
                Utility.SetRowStyle(dtgvEspecialidades.Rows[highlightedRowIndex], highlightStyle);
            }
        }

        private void DtgvEspecialidades_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (highlightedRowIndex >= 0)
            {
                Utility.SetRowStyle(dtgvEspecialidades.Rows[highlightedRowIndex], null);

                highlightedRowIndex = -1;
            }
        }

        private void TxtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            string searchValue = txtBuscar.Text;

            dtgvEspecialidades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (searchValue != "")
            {
                try
                {
                    foreach (DataGridViewRow row in dtgvEspecialidades.Rows)
                    {
                        if (!row.Cells[1].Value.ToString().ToLower().Contains(searchValue.ToLower()))
                        {
                            CurrencyManager currencyManager = (CurrencyManager)BindingContext[dtgvEspecialidades.DataSource];
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
                foreach (DataGridViewRow row in dtgvEspecialidades.Rows)
                {
                    row.Visible = true;
                }
            }
        }
    }
}
