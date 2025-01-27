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

namespace ControlMedicoWinForms.Medico
{
    public partial class ControlMedicos : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        MedicoServices services = new MedicoServices();

        private int highlightedRowIndex = -1;
        private DataGridViewCellStyle highlightStyle;
        public ControlMedicos()
        {
            InitializeComponent();
        }

        private void ControlMedicos_Load(object sender, EventArgs e)
        {
            this.Font = Utility.GetMedtorFont(FontControlEnum.General);
            this.kryptonRibbon1.StateCommon.RibbonGeneral.TextFont = Utility.GetMedtorFont(FontControlEnum.General);
            this.dtgvMedicos.StateCommon.HeaderColumn.Content.Font = Utility.GetMedtorFont(FontControlEnum.GridTitle);
            this.dtgvMedicos.RowsDefaultCellStyle.Font = Utility.GetMedtorFont(FontControlEnum.GridRows);

            LoadDatos();
        }

        public async void LoadDatos()
        {
            List<MedicoModel> listMedicos = await services.GetAllMedicos();

            if(dtgvMedicos.DataSource != null)
            {
                dtgvMedicos.DataSource = null;
                dtgvMedicos.Columns.Clear();
            }

            dtgvMedicos.DataSource = listMedicos;

            DataGridViewImageColumn img = new DataGridViewImageColumn();

            img.Name = "ImagenActivo";
            img.HeaderText = "Activo";

            dtgvMedicos.Columns.Add(img);
            dtgvMedicos.Columns[0].HeaderText = "Número";
            dtgvMedicos.Columns[1].HeaderText = "Nombre";
            dtgvMedicos.Columns[2].HeaderText = "Teléfono";
            dtgvMedicos.Columns[7].HeaderText = "Cédula Profesional";
            dtgvMedicos.Columns[7].DisplayIndex = 3;
            dtgvMedicos.Columns[3].Visible = false;
            dtgvMedicos.Columns[8].Visible = false;
            dtgvMedicos.Columns[5].Visible = false;
            dtgvMedicos.Columns[4].Visible = false;
            dtgvMedicos.Columns[6].Visible = false;
            dtgvMedicos.Columns[6].DisplayIndex = 5;
            dtgvMedicos.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvMedicos.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvMedicos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            highlightStyle = new DataGridViewCellStyle();
            highlightStyle.BackColor = ColorTranslator.FromHtml("#f8e187");

            for (int i = 0; i <= dtgvMedicos.Rows.Count - 1; i++)
            {
                if ((int)dtgvMedicos.Rows[i].Cells["Activo"].Value > 0)
                {
                    ((DataGridViewImageCell)dtgvMedicos.Rows[i].Cells["ImagenActivo"]).Value = Properties.Resources.if_status_46254;
                }
                else
                {
                    ((DataGridViewImageCell)dtgvMedicos.Rows[i].Cells["ImagenActivo"]).Value = Properties.Resources.iconfinder_status_offline_46253;
                }
            }

            dtgvMedicos.Refresh();
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int valor;
                DataGridViewRow row = dtgvMedicos.SelectedRows[0];
                {
                    valor = Convert.ToInt32(row.Cells[0].Value);
                    EditarMedico h = new EditarMedico(valor, this);
                    h.Show(this);
                }
            }
            catch (Exception)
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show("Debe seleccionar un médico", ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void accionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarMedico f = new AgregarMedico(this);
            f.Show(this);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarMedico f = new AgregarMedico(this);
            f.Show(this);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int valor;
                DataGridViewRow row = dtgvMedicos.SelectedRows[0];
                {
                    valor = Convert.ToInt32(row.Cells[0].Value);
                    EditarMedico h = new EditarMedico(valor, this);
                    h.Show(this);
                }
            }
            catch (Exception)
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show("Debe seleccionar un médico", ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void DtgvMedicos_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == highlightedRowIndex) return;

            // Unhighlight the previously highlighted row.
            if (highlightedRowIndex >= 0)
            {
                Utility.SetRowStyle(dtgvMedicos.Rows[highlightedRowIndex], null);
            }

            // Highlight the row holding the mouse.
            highlightedRowIndex = e.RowIndex;
            if (highlightedRowIndex >= 0)
            {
                Utility.SetRowStyle(dtgvMedicos.Rows[highlightedRowIndex], highlightStyle);
            }
        }

        private void DtgvMedicos_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (highlightedRowIndex >= 0)
            {
                Utility.SetRowStyle(dtgvMedicos.Rows[highlightedRowIndex], null);

                highlightedRowIndex = -1;
            }
        }
    }
}
