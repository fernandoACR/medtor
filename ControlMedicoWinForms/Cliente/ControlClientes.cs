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

namespace ControlMedicoWinForms.Cliente
{
    public partial class ControlClientes : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        ClienteServices services = new ClienteServices();
        private int highlightedRowIndex = -1;
        private DataGridViewCellStyle highlightStyle;

        public ControlClientes()
        {
            InitializeComponent();
        }

        private void accionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarCliente f = new AgregarCliente(this);
            f.Show(this);
        }

        private void ControlClientes_Load(object sender, EventArgs e)
        {
            try
            {
                new Utility().GoAsync();
                LoadDatos();
            }
            catch (Exception ex)
            {
                ControlLenguaje.utility.WriteToErrorLog(AppDomain.CurrentDomain.BaseDirectory, ex);
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.validationMessages.GetString("ErrorInesperado"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async void LoadDatos()
        {
            List<ClienteModel> listClientes = await services.GetAllClientes();
            dtgvClientes.DataSource = listClientes;

            DataGridViewImageColumn img = new DataGridViewImageColumn();

            img.Name = "ImagenActivo";
            img.HeaderText = "Activo";

            dtgvClientes.Columns.Add(img);

            dtgvClientes.Columns[0].HeaderText = "Número";
            dtgvClientes.Columns[1].HeaderText = "Nombre";
            dtgvClientes.Columns[2].HeaderText = "Teléfono";
            dtgvClientes.Columns[3].HeaderText = "Dirección";
            dtgvClientes.Columns[4].HeaderText = "Identificación";

            //dtgvClientes.Columns[0].Width = 100;
            //dtgvClientes.Columns[1].Width = 200;
            //dtgvClientes.Columns[2].Width = 100;
            //dtgvClientes.Columns[3].Width = 300;
            //dtgvClientes.Columns[4].Width = 120;
            //dtgvClientes.Columns[5].Width = 100;
            dtgvClientes.Columns[5].Visible = false;
            dtgvClientes.Columns[6].Visible = false;
            dtgvClientes.Columns[7].Visible = false;

            dtgvClientes.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvClientes.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgvClientes.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvClientes.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgvClientes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            highlightStyle = new DataGridViewCellStyle();
            highlightStyle.BackColor = ColorTranslator.FromHtml("#f8e187");

            for (int i = 0; i <= dtgvClientes.Rows.Count - 1; i++)
            {
                if ((int)dtgvClientes.Rows[i].Cells["Activo"].Value > 0)
                {
                    ((DataGridViewImageCell)dtgvClientes.Rows[i].Cells["ImagenActivo"]).Value = Properties.Resources.if_status_46254;
                }
                else
                {
                    ((DataGridViewImageCell)dtgvClientes.Rows[i].Cells["ImagenActivo"]).Value = Properties.Resources.iconfinder_status_offline_46253;
                }
            }

            dtgvClientes.Refresh();
        }

        private void dtgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarCliente f = new AgregarCliente(this);
            f.Show(this);
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void DtgvClientes_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == highlightedRowIndex) return;

            // Unhighlight the previously highlighted row.
            if (highlightedRowIndex >= 0)
            {
                Utility.SetRowStyle(dtgvClientes.Rows[highlightedRowIndex], null);
            }

            // Highlight the row holding the mouse.
            highlightedRowIndex = e.RowIndex;
            if (highlightedRowIndex >= 0)
            {
                Utility.SetRowStyle(dtgvClientes.Rows[highlightedRowIndex], highlightStyle);
            }
        }

        private void DtgvClientes_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (highlightedRowIndex >= 0)
            {
                Utility.SetRowStyle(dtgvClientes.Rows[highlightedRowIndex], null);

                highlightedRowIndex = -1;
            }
        }
    }
}
