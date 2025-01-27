using ControlMedicoWinForms.Medico;
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

namespace ControlMedicoWinForms.Orden
{
    public partial class ControlOrdenes : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        OrdenServices services = new OrdenServices();
        ReporteServices reporteServices = new ReporteServices();
        private int highlightedRowIndex = -1;
        private DataGridViewCellStyle highlightStyle;
        OpcionMostrar opcion = OpcionMostrar.Todas;
        List<OrdenModel> listOrdenes = new List<OrdenModel>();

        public ControlOrdenes()
        {
            InitializeComponent();
        }

        public enum OpcionMostrar
        {
            Todas = 1,
            Recibidas = 2,
            Entregadas = 3
        }

        public void LoadDatos()
        {
            if (dtgvOrdenes.DataSource != null)
            {
                dtgvOrdenes.DataSource = null;
                dtgvOrdenes.Columns.Clear();
            }

            dtgvOrdenes.DataSource = listOrdenes;

            DataGridViewImageColumn img = new DataGridViewImageColumn();

            img.Name = "ImagenActivo";
            img.HeaderText = "Activo";

            dtgvOrdenes.Columns.Add(img);

            dtgvOrdenes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvOrdenes.Columns[1].Visible = false;
            dtgvOrdenes.Columns[2].Visible = false;
            dtgvOrdenes.Columns[3].Visible = false;
            dtgvOrdenes.Columns[4].Visible = false;
            dtgvOrdenes.Columns[5].Visible = false;
            dtgvOrdenes.Columns[6].Visible = false;
            dtgvOrdenes.Columns[8].Visible = false;
            dtgvOrdenes.Columns[9].Visible = false;
            dtgvOrdenes.Columns[10].Visible = false;
            dtgvOrdenes.Columns[11].Visible = false;
            dtgvOrdenes.Columns[12].Visible = false;
            dtgvOrdenes.Columns[13].Visible = false;
            dtgvOrdenes.Columns[14].Visible = false;
            dtgvOrdenes.Columns[15].Visible = false;
            dtgvOrdenes.Columns[17].Visible = false;
            dtgvOrdenes.Columns[18].Visible = false;
            dtgvOrdenes.Columns[28].Visible = false;
            dtgvOrdenes.Columns[31].Width = 70;

            DataGridViewColumn numeroColumn = dtgvOrdenes.Columns[0];
            numeroColumn.Visible = false;
            numeroColumn.HeaderText = "Número";
            numeroColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewColumn pagadoColumn = dtgvOrdenes.Columns[23];
            pagadoColumn.HeaderText = "Pagado";
            pagadoColumn.Width = 70;
            pagadoColumn.DisplayIndex = 1;

            DataGridViewColumn entregadoColumn = dtgvOrdenes.Columns[22];
            entregadoColumn.Width = 70;
            entregadoColumn.DisplayIndex = 2;

            DataGridViewColumn estatusColumn = dtgvOrdenes.Columns[17];
            //estatusColumn.Width = 100;
            estatusColumn.DisplayIndex = 3;

            DataGridViewColumn pacienteColumn = dtgvOrdenes.Columns[19];
            pacienteColumn.HeaderText = "Paciente";
            pacienteColumn.DisplayIndex = 4;
            //pacienteColumn.Width = 200;

            DataGridViewColumn especimenColumn = dtgvOrdenes.Columns[21];
            especimenColumn.HeaderText = "Especimen";
            especimenColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            especimenColumn.DisplayIndex = 5;
            especimenColumn.Visible = false;

            DataGridViewColumn fechaRecepcionDescripColumn = dtgvOrdenes.Columns[25];
            fechaRecepcionDescripColumn.HeaderText = "Fecha Recepción";
            fechaRecepcionDescripColumn.Width = 90;
            fechaRecepcionDescripColumn.DisplayIndex = 6;

            DataGridViewColumn personaRecepcionColumn = dtgvOrdenes.Columns[16];
            personaRecepcionColumn.HeaderText = "Persona Recepción";
            personaRecepcionColumn.DisplayIndex = 7;
            //personaRecepcionColumn.Width = 120;
            personaRecepcionColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            DataGridViewColumn correoRecepcionColumn = dtgvOrdenes.Columns[29];
            correoRecepcionColumn.HeaderText = "Correo Recepción";
            correoRecepcionColumn.DisplayIndex = 8;
            //correoRecepcionColumn.Width = 120;
            correoRecepcionColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            DataGridViewColumn movilRecepcionColumn = dtgvOrdenes.Columns[30];
            movilRecepcionColumn.HeaderText = "Movil Recepción";
            movilRecepcionColumn.DisplayIndex = 9;
            //movilRecepcionColumn.Width = 120;
            movilRecepcionColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            DataGridViewColumn fechaEntregaDescripColumn = dtgvOrdenes.Columns[24];
            fechaEntregaDescripColumn.HeaderText = "Fecha Entrega";
            fechaEntregaDescripColumn.Width = 90;
            fechaEntregaDescripColumn.DisplayIndex = 10;

            DataGridViewColumn diagnosticoColumn = dtgvOrdenes.Columns[27];
            diagnosticoColumn.HeaderText = "Diagnostico";
            diagnosticoColumn.DisplayIndex = 11;
            //diagnosticoColumn.Width = 200;

            DataGridViewColumn medicoColumn = dtgvOrdenes.Columns[26];
            medicoColumn.HeaderText = "Médico Tratante";
            medicoColumn.DisplayIndex = 12;
            //medicoColumn.Width = 200;

            DataGridViewColumn precioColumn = dtgvOrdenes.Columns[7];
            precioColumn.HeaderText = "Monto";
            precioColumn.DisplayIndex = 13;
            precioColumn.Visible = false;

            DataGridViewColumn entregadoPorColumn = dtgvOrdenes.Columns[20];
            entregadoPorColumn.HeaderText = "Médico Entrega";
            entregadoPorColumn.DisplayIndex = 14;
            //entregadoPorColumn.Width = 200;

            DataGridViewColumn observacionesColumn = dtgvOrdenes.Columns[11];
            observacionesColumn.HeaderText = "Observaciones";
            //observacionesColumn.Width = 200;
            observacionesColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            observacionesColumn.DisplayIndex = 15;

            DataGridViewColumn claveColumn = dtgvOrdenes.Columns[8];
            claveColumn.HeaderText = "Número QX";
            claveColumn.DisplayIndex = 16;
            //claveColumn.Width = 85;
            claveColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewColumn activoColumn = dtgvOrdenes.Columns[14];
            activoColumn.HeaderText = "Activo";
            //activoColumn.Width = 80;
            activoColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            activoColumn.DisplayIndex = 17;

            highlightStyle = new DataGridViewCellStyle();
            highlightStyle.BackColor = ColorTranslator.FromHtml("#f8e187");

            for (int i = 0; i <= dtgvOrdenes.Rows.Count - 1; i++)
            {
                PacienteModel paciente = (PacienteModel)dtgvOrdenes.Rows[i].Cells["Paciente"].Value;
                dtgvOrdenes.Rows[i].Cells["NombrePaciente"].Value = paciente.NombreCompleto;

                MedicoModel medicoEntrega = (MedicoModel)dtgvOrdenes.Rows[i].Cells["MedicoEntrega"].Value;
                dtgvOrdenes.Rows[i].Cells["NombreMedicoEntrega"].Value = medicoEntrega.Nombre;

                if (dtgvOrdenes.Rows[i].Cells["MedicoRecepcion"].Value != null)
                {
                    MedicoModel medicoRecibe = (MedicoModel)dtgvOrdenes.Rows[i].Cells["MedicoRecepcion"].Value;
                    dtgvOrdenes.Rows[i].Cells["NombreMedicoRecepcion"].Value = medicoRecibe.Nombre;
                }
                EspecimenModel especimen = (EspecimenModel)dtgvOrdenes.Rows[i].Cells["Especimen"].Value;
                dtgvOrdenes.Rows[i].Cells["DescripcionEspecimen"].Value = especimen.Descripcion;

                if (dtgvOrdenes.Rows[i].Cells["Diagnostico"].Value != null)
                {
                    DiagnosticoModel diagnostico = (DiagnosticoModel)dtgvOrdenes.Rows[i].Cells["Diagnostico"].Value;
                    dtgvOrdenes.Rows[i].Cells["DescripcionDiagnostico"].Value = diagnostico.Descripcion;
                }
                dtgvOrdenes.Rows[i].Cells["ChkPagado"].Value = Convert.ToBoolean(dtgvOrdenes.Rows[i].Cells["Pagado"].Value);

                if (dtgvOrdenes.Rows[i].Cells["FechaEntregaOrigen"].Value != null)
                {
                    dtgvOrdenes.Rows[i].Cells["Entregado"].Value = true;
                    dtgvOrdenes.Rows[i].Cells["FechaEntregaDescrip"].Value = Convert.ToDateTime(dtgvOrdenes.Rows[i].Cells["FechaEntregaOrigen"].Value).ToString("dd/MM/yyyy");
                }

                if (dtgvOrdenes.Rows[i].Cells["FechaRecepcion"].Value != null)
                {
                    dtgvOrdenes.Rows[i].Cells["FechaRecepcionDescrip"].Value = Convert.ToDateTime(dtgvOrdenes.Rows[i].Cells["FechaRecepcion"].Value).ToString("dd/MM/yyyy");
                }

                if ((int)dtgvOrdenes.Rows[i].Cells["Activo"].Value > 0)
                {
                    ((DataGridViewImageCell)dtgvOrdenes.Rows[i].Cells["ImagenActivo"]).Value = Properties.Resources.if_status_46254;
                }
                else
                {
                    ((DataGridViewImageCell)dtgvOrdenes.Rows[i].Cells["ImagenActivo"]).Value = Properties.Resources.iconfinder_status_offline_46253;
                    dtgvOrdenes.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#EC7063");
                }
            }

            dtgvOrdenes.Refresh();

            if (cmbOpcionesVer.DataSource == null)
            {
                List<object> listaOpciones = new List<object>();
                listaOpciones.Add(new { Text = "Todas", Value = "Todas" });
                listaOpciones.Add(new { Text = "Entregadas", Value = OpcionMostrar.Entregadas.ToString() });
                listaOpciones.Add(new { Text = "Recibidas", Value = OpcionMostrar.Recibidas.ToString() });

                cmbOpcionesVer.ValueMember = "Value";
                cmbOpcionesVer.DisplayMember = "Text";
                cmbOpcionesVer.DataSource = listaOpciones;
            }
        }

        private void accionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarOrden f = new AgregarOrden(this);
            f.Show(this);
        }

        private void ControlOrdenes_Load(object sender, EventArgs e)
        {
            this.Font = Utility.GetMedtorFont(FontControlEnum.General);
            this.kryptonRibbon1.StateCommon.RibbonGeneral.TextFont = Utility.GetMedtorFont(FontControlEnum.General);
            this.dtgvOrdenes.StateCommon.HeaderColumn.Content.Font = Utility.GetMedtorFont(FontControlEnum.GridTitle);
            this.dtgvOrdenes.RowsDefaultCellStyle.Font = Utility.GetMedtorFont(FontControlEnum.GridRows);

            progressBar1.Left = (this.dtgvOrdenes.ClientSize.Width - progressBar1.Width) / 2;
            progressBar1.Top = (this.dtgvOrdenes.ClientSize.Height - progressBar1.Height) / 2;

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

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int valor;
                DataGridViewRow row = dtgvOrdenes.SelectedRows[0];
                {
                    valor = Convert.ToInt32(row.Cells[0].Value);
                    EditarOrden h = new EditarOrden(valor, this);
                    h.Show(this);
                }
            }
            catch (Exception)
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show("Debe seleccionar una orden", ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void entregadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opcion = OpcionMostrar.Entregadas;
            Cargar();
        }

        private void recibidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opcion = OpcionMostrar.Recibidas;
            Cargar();
        }

        private void todasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opcion = OpcionMostrar.Todas;
            Cargar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarOrden f = new AgregarOrden(this);
            f.Show(this);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                int valor;
                DataGridViewRow row = dtgvOrdenes.SelectedRows[0];
                {
                    valor = Convert.ToInt32(row.Cells[0].Value);
                    EditarOrden h = new EditarOrden(valor, this);
                    h.Show(this);
                }
            }
            catch (Exception)
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show("Debe seleccionar una orden", ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cmbOpcionesVer_SelectedValueChanged(object sender, EventArgs e)
        {
            var option = cmbOpcionesVer.SelectedValue;

            if(option != null)
            {
                if(option.ToString() == "Todas")
                {
                    opcion = OpcionMostrar.Todas;
                }

                if (option.ToString() == "Entregadas")
                {
                    opcion = OpcionMostrar.Entregadas;
                }

                if (option.ToString() == "Recibidas")
                {
                    opcion = OpcionMostrar.Recibidas;
                }

                Cargar();
            }
        }

        private void kryptonRibbon1_SelectedTabChanged(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                int valor;
                DataGridViewRow row = dtgvOrdenes.SelectedRows[0];
                {
                    valor = Convert.ToInt32(row.Cells[0].Value);
                    WebViewer webViewer = new WebViewer(reporteServices.PrintOrdenByIdOrden(new OrdenModel() { IdOrden = valor }));
                    webViewer.Show();
                }
            }
            catch (Exception ex)
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show("Debe seleccionar una orden", ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void BtnRecargar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void DtgvOrdenes_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == highlightedRowIndex) return;

            // Unhighlight the previously highlighted row.
            if (highlightedRowIndex >= 0)
            {
                Utility.SetRowStyle(dtgvOrdenes.Rows[highlightedRowIndex], null);
            }

            // Highlight the row holding the mouse.
            highlightedRowIndex = e.RowIndex;
            if (highlightedRowIndex >= 0)
            {
                Utility.SetRowStyle(dtgvOrdenes.Rows[highlightedRowIndex], highlightStyle);
            }
        }

        private void DtgvOrdenes_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (highlightedRowIndex >= 0)
            {
                Utility.SetRowStyle(dtgvOrdenes.Rows[highlightedRowIndex], null);

                highlightedRowIndex = -1;
            }
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Utility.CheckForInternetConnection())
            {     
                if (LoginModel.Medico != null)
                {
                    if (opcion == OpcionMostrar.Todas)
                    {
                        listOrdenes = services.GetOrdenByIdMedicoEntrega(new OrdenModel() { MedicoEntrega = LoginModel.Medico }).Result;
                        listOrdenes.AddRange(services.GetOrdenByIdMedicoRecepcion(new OrdenModel() { MedicoRecepcion = LoginModel.Medico }).Result);
                    }
                    else if (opcion == OpcionMostrar.Recibidas)
                    {
                        listOrdenes = services.GetOrdenByIdMedicoRecepcion(new OrdenModel() { MedicoRecepcion = LoginModel.Medico }).Result;
                    }
                    else
                    {
                        listOrdenes = services.GetOrdenByIdMedicoEntrega(new OrdenModel() { MedicoEntrega = LoginModel.Medico }).Result;
                    }
                }
                else
                {
                    listOrdenes = services.GetAllOrdenes().Result;
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

        private void ControlOrdenes_SizeChanged(object sender, EventArgs e)
        {
            progressBar1.Left = (this.dtgvOrdenes.ClientSize.Width - progressBar1.Width) / 2;
            progressBar1.Top = (this.dtgvOrdenes.ClientSize.Height - progressBar1.Height) / 2;
        }
    }
}
