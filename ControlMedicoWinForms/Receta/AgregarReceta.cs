using ControlMedicoWinForms.Catalogo;
using ControlMedicoWinForms.Diagnostico;
using ControlMedicoWinForms.Models;
using ControlMedicoWinForms.Paciente;
using ControlMedicoWinForms.Reportes;
using ControlMedicoWinForms.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ControlMedicoWinForms.Models.ComunModel;

namespace ControlMedicoWinForms.Receta
{
    public partial class AgregarReceta : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        ControlRecetas padre;
        DiagnosticoModel diagnostico;
        RecetaServices recetaServices = new RecetaServices();
        CatalogoServices catalogoServices = new CatalogoServices();
        PacienteServices pacienteServices = new PacienteServices();
        List<RecetaMedicamentoModel> recetaMedicamentos = new List<RecetaMedicamentoModel>();
        List<MedicamentoModel> medicamentos = new List<MedicamentoModel>();
        ReporteServices reporteServices = new ReporteServices();
        DiagnosticoServices diagnosticoServices = new DiagnosticoServices();

        ResourceManager validationMessages = new ResourceManager("ControlMedicoWinforms.Utilidades.ValidationMessages", Assembly.GetExecutingAssembly());

        public AgregarReceta(ControlRecetas p, DiagnosticoModel d = null)
        {
            padre = p;
            diagnostico = d;
            InitializeComponent();
        }

        private void AgregarReceta_Load(object sender, EventArgs e)
        {
            this.Font = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);

            this.dtgvMedicamentos.StateCommon.HeaderColumn.Content.Font = Utility.GetMedtorFont(FontControlEnum.GridTitle);
            this.dtgvMedicamentos.RowsDefaultCellStyle.Font = Utility.GetMedtorFont(FontControlEnum.GridRows);
            this.dtgvReceta.StateCommon.HeaderColumn.Content.Font = Utility.GetMedtorFont(FontControlEnum.GridTitle);
            this.dtgvReceta.RowsDefaultCellStyle.Font = Utility.GetMedtorFont(FontControlEnum.GridRows);

            LoadDatos();
        }

        public async void LoadDatos()
        {
            this.MaximizeBox = false;

            if (Utility.CheckForInternetConnection())
            {
                try
                {
                    medicamentos = await catalogoServices.GetMedicamentosByIdMedicoAndActivo(new MedicamentoModel() { Medico = LoginModel.Medico, Activo = 1 });
                    dtgvMedicamentos.DataSource = medicamentos;

                    FormatearGridMedicamento();

                    FormatearGridReceta();

                    List<PacienteModel> listaPacientes = await pacienteServices.GetPacienteByIdMedico(new PacienteModel() { Medico = new MedicoModel() { IdMedico = LoginModel.Medico.IdMedico } });
                    listaPacientes.Add(new PacienteModel { IdPaciente = 0, NombreCompleto = "Seleccione" });

                    cmbPaciente.DataSource = listaPacientes.OrderBy(x => x.IdPaciente).ToList();
                    cmbPaciente.DisplayMember = "NombreCompleto";
                    cmbPaciente.ValueMember = "IdPaciente";

                    cmbPaciente.DropDownStyle = ComboBoxStyle.DropDown;
                    cmbPaciente.AutoCompleteMode = AutoCompleteMode.Suggest;
                    cmbPaciente.AutoCompleteSource = AutoCompleteSource.ListItems;

                    if (diagnostico != null)
                    {
                        cmbPaciente.SelectedValue = diagnostico.Paciente.IdPaciente;
                        cmbDiagnostico.SelectedValue = diagnostico.IdDiagnostico;
                    }
                }
                catch (Exception ex)
                {
                    ControlLenguaje.utility.WriteToErrorLog(AppDomain.CurrentDomain.BaseDirectory, ex);

                    if (!Utility.CheckForInternetConnection())
                    {
                        ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.validationMessages.GetString("SinConexion"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                    }
                    else
                    {
                        ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.validationMessages.GetString("ErrorInesperado"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.validationMessages.GetString("SinConexion"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        private void kryptonDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgvMedicamentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (dtgvMedicamentos.SelectedRows.Count > 0)
            {
                try
                {
                    for (int i = 0; i <= dtgvMedicamentos.SelectedRows.Count - 1; i++)
                    {
                        MedicamentoModel medicamento = (MedicamentoModel)dtgvMedicamentos.SelectedRows[i].DataBoundItem;

                        recetaMedicamentos.Add(new RecetaMedicamentoModel()
                        {
                            IdRecetaMedicamento = 0,
                            Cantidad = 1,
                            Frecuencia = "Cada 12 horas",
                            Medicamento = medicamento,
                            MedicamentoDescrip = medicamento.Descripcion,
                            Receta = null
                        });

                        medicamentos.Remove(medicamento);                        
                    }

                    if (dtgvReceta.DataSource != null)
                    {
                        dtgvReceta.DataSource = null;
                    };   

                    FormatearGridReceta();

                    dtgvMedicamentos.DataSource = null;
                    dtgvMedicamentos.DataSource = medicamentos;
                    FormatearGridMedicamento();
                }
                catch (Exception)
                {
                    ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show("Debe seleccionar un medicamento", ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void kryptonLabel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dtgvReceta.SelectedRows.Count > 0)
            {
                try
                {
                    for (int i = 0; i <= dtgvReceta.SelectedRows.Count - 1; i++)
                    {
                        RecetaMedicamentoModel recetaMedicamento = (RecetaMedicamentoModel)dtgvReceta.SelectedRows[i].DataBoundItem;

                        if (recetaMedicamento.Medicamento != null)
                        {
                            medicamentos.Add(recetaMedicamento.Medicamento);                            
                        }

                        recetaMedicamentos.Remove(recetaMedicamento);
                    }

                    if (dtgvMedicamentos.DataSource != null)
                    {
                        dtgvMedicamentos.DataSource = null;
                    };

                    dtgvMedicamentos.DataSource = medicamentos;
                    FormatearGridMedicamento();

                    if (dtgvReceta.DataSource != null)
                    {
                        dtgvReceta.DataSource = null;
                    };

                    dtgvReceta.DataSource = recetaMedicamentos;
                    FormatearGridReceta();
                }
                catch (Exception ex)
                {
                    ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show("Debe seleccionar una linea", ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void FormatearGridMedicamento()
        {
            dtgvMedicamentos.Columns[1].Visible = false;
            dtgvMedicamentos.Columns[0].Visible = false;
            dtgvMedicamentos.Columns[3].Visible = false;
            dtgvMedicamentos.Columns[2].HeaderText = "Descripción";
            dtgvMedicamentos.Refresh();
        }

        private void FormatearGridReceta()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = recetaMedicamentos;
            dtgvReceta.DataSource = bs;

            dtgvReceta.Columns[0].Visible = false;
            dtgvReceta.Columns[3].Visible = false;
            dtgvReceta.Columns[4].HeaderText = "Medicamento";
            dtgvReceta.Columns[5].Visible = false;

            dtgvReceta.AllowUserToAddRows = true;

            for (int i = 0; i <= dtgvReceta.Rows.Count - 2; i++)
            {
                dtgvReceta.Rows[i].Cells[4].ReadOnly = true;
            }

            dtgvReceta.Refresh();
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                try
                {
                    btnAgregar.Enabled = false;
                    btnCancelar.Enabled = false;

                    recetaMedicamentos.Where(x => x.Medicamento == null).ToList().ForEach(d => d.Medicamento = new MedicamentoModel() { IdMedicamento = 0, Medico = LoginModel.Medico, Activo = 1, Descripcion = d.MedicamentoDescrip });

                    RecetaModel receta = new RecetaModel()
                    {
                        Medico = LoginModel.Medico,
                        Paciente = new PacienteModel() { IdPaciente = (int)cmbPaciente.SelectedValue },
                        recetaMedicamentos = recetaMedicamentos,
                        Diagnostico = (int?)cmbDiagnostico.SelectedValue > 0 ? new DiagnosticoModel() { IdDiagnostico = (int)cmbDiagnostico.SelectedValue } : null
                    };

                    int accion = await recetaServices.AddReceta(receta);

                    if (accion > 0)
                    {
                        DialogResult result = ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show("¿Desea imprimir la receta?", ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            WebViewer webViewer = new WebViewer(reporteServices.PrintRecetaByIdReceta(new RecetaModel() { IdReceta = accion }));
                            webViewer.Show();
                        }
                        else
                        {
                            ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show("Receta guardada correctamente", ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        btnAgregar.Enabled = true;
                        btnCancelar.Enabled = true;
                        padre.Cargar();
                        this.Close();
                    }

                }
                catch (Exception ex)
                {
                    ControlLenguaje.utility.WriteToErrorLog(AppDomain.CurrentDomain.BaseDirectory, ex);
                    btnAgregar.Enabled = true;
                    btnCancelar.Enabled = true;
                    ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.validationMessages.GetString("ErrorInesperado"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.cadenas.GetString("ConfirmarCancelar"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        private async void cmbPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Obtener Diagnosticos
            if (cmbPaciente.SelectedIndex > 0)
            {
                var diagnosticos = await diagnosticoServices.GetDiagnosticoByIdPaciente(new DiagnosticoModel() { Paciente = new PacienteModel() { IdPaciente = (int)cmbPaciente.SelectedValue } });
                diagnosticos.Add(new DiagnosticoModel { IdDiagnostico = 0, Descripcion = "Seleccione" });
                cmbDiagnostico.DataSource = diagnosticos.OrderBy(x => x.IdDiagnostico).ToList();
                cmbDiagnostico.DisplayMember = "Descripcion";
                cmbDiagnostico.ValueMember = "IdDiagnostico";
                cmbDiagnostico.DropDownStyle = ComboBoxStyle.DropDown;
                cmbDiagnostico.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmbDiagnostico.AutoCompleteSource = AutoCompleteSource.ListItems;

                if (diagnostico != null)
                {
                    cmbDiagnostico.SelectedValue = diagnostico.IdDiagnostico;
                    diagnostico = null;
                }
            }
        }

        public bool ValidateForm()
        {
            if (cmbPaciente.SelectedValue == null)
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(string.Format(validationMessages.GetString("CampoVacio"), "Nombre del Paciente"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if ((int)cmbPaciente.SelectedValue == 0)
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(string.Format(validationMessages.GetString("CampoVacio"), "Nombre del Paciente"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            //if (dtgvReceta.Rows.Count <= 0)
            //{
            //    ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(string.Format(validationMessages.GetString("CampoVacio"), "Receta"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return false;
            //}

            return true;
        }

        private void dtgvReceta_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgvReceta_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if(e.ColumnIndex == 1)
            {
                int number;

                bool success = Int32.TryParse(e.FormattedValue.ToString(), out number);

                if (success)
                {
                    return;
                }
                else
                {
                    ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show("El campo cantidad debe ser un número", ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                }
            }
        }

        private void kryptonSplitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TxtBuscarMedicamento_KeyUp(object sender, KeyEventArgs e)
        {
            string searchValue = txtBuscarMedicamento.Text;

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

        private void KryptonLabel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
