using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlMedicoWinForms.Catalogo.Especialidad;
using ControlMedicoWinForms.Catalogo.Especimen;
using ControlMedicoWinForms.Catalogo.Patologia;
using ControlMedicoWinForms.Cita;
using ControlMedicoWinForms.Cliente;
using ControlMedicoWinForms.Medico;
using ControlMedicoWinForms.Models;
using ControlMedicoWinForms.Orden;
using ControlMedicoWinForms.Paciente;
using ControlMedicoWinForms.Usuario;
using static ControlMedicoWinForms.Models.ComunModel;
using ControlMedicoWinForms.Diagnostico;
using ControlMedicoWinForms.Catalogo.Medicamento;
using ControlMedicoWinForms.Receta;
using ControlMedicoWinForms.Utilidades;

namespace ControlMedicoWinForms
{
    public partial class MainForm : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public MainForm()
        {            
            InitializeComponent();
            //menuStrip1.Renderer = new MyRenderer();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Font = Utility.GetMedtorFont(FontControlEnum.General);
            this.kryptonRibbon1.StateCommon.RibbonGeneral.TextFont = Utility.GetMedtorFont(FontControlEnum.General);
            this.contextMenuStrip1.Font = Utility.GetMedtorFont(FontControlEnum.General);
            this.kryptonHeaderGroup1.StateCommon.HeaderPrimary.Content.ShortText.Font = Utility.GetMedtorFont(FontControlEnum.HeaderGroupBoxTitle);
            this.kryptonHeaderGroup1.StateCommon.HeaderSecondary.Content.ShortText.Font = Utility.GetMedtorFont(FontControlEnum.General);

            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
            this.ContextMenuStrip = contextMenuStrip1; 
            LoadMenu(LoginModel.Rol);
            //lblTotalPacientes.BackColor = Color.FromArgb(0, 104, 133);

            lblNombreUsuario.Text = LoginModel.UserName;
            lblFecha.RightToLeft = RightToLeft.No;            
            this.Text = ControlLenguaje.cadenas.GetString("NombreAplicacion");            

            //pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            //pictureBox1.Anchor = AnchorStyles.None;
            //pictureBox1.Location = new Point((pictureBox1.Parent.ClientSize.Width / 2) - (pictureBox1.Image.Width / 2),
            //                            (pictureBox1.Parent.ClientSize.Height / 2) - (pictureBox1.Image.Height / 2));
            //pictureBox1.Refresh();

            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                item.ForeColor = Color.Black;
                item.BackColor = Color.FromArgb(100, 175, 158);
                foreach (ToolStripMenuItem children in item.DropDownItems)
                {
                    children.ForeColor = Color.White;
                    children.BackColor = Color.FromArgb(0, 104, 133); 
                }
            }

            timer1.Interval = 60000;
            timer1.Start();
        }

        private void controlDePacientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControlPacientes f = new ControlPacientes();
            f.Show(this);

            //ControlPacientes addbill = new ControlPacientes();
            //addbill.Show();
            //addbill.MdiParent = this;
        }

        private void controlDeMedicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControlMedicos f = new ControlMedicos();
            f.Show(this);
        }

        public void LoadMenu(RolesUsuario rol)
        {
            menuStrip1.BackColor = Color.FromArgb(100, 175, 158);
            menuPaciente.TextLine1 = ControlLenguaje.cadenas.GetString("menuPaciente");
            menuCita.TextLine1 = ControlLenguaje.cadenas.GetString("menuCita");
            menuMedico.TextLine1 = ControlLenguaje.cadenas.GetString("menuMedico");
            menuOrden.TextLine1 = ControlLenguaje.cadenas.GetString("menuOrden");
            menuDiagnostico.TextLine1 = ControlLenguaje.cadenas.GetString("menuDiagnostico");
            menuReceta.TextLine1 = ControlLenguaje.cadenas.GetString("menuReceta");
            //menuEspecimen.TextLine1 = ControlLenguaje.cadenas.GetString("menuEspecimen");
            //menuPatologia.TextLine1 = ControlLenguaje.cadenas.GetString("menuPatologia");

            if (rol == RolesUsuario.Administrador)
            {
                menuPaciente.Visible = false;
                menuMedico.Visible = true;
                menuOrden.Visible = false;
                menuCita.Visible = false;
                menuDiagnostico.Visible = false;
                menuReceta.Visible = false;
                menuEspecimen.Visible = false;
                menuPatologia.Visible = false;
                menuMedicamento.Visible = false;
            }

            if (rol == RolesUsuario.Medico)
            {
                menuPaciente.Visible = true;
                menuMedico.Visible = false;
                menuOrden.Visible = true;
                menuCliente.Visible = false;
            }

            if (rol == RolesUsuario.Paciente)
            {
                menuPaciente.Visible = false;
                menuMedico.Visible = false;
                menuOrden.Visible = false;
            }

            if (rol == RolesUsuario.Usuario)
            {
                menuPaciente.Visible = true;
                menuMedico.Visible = false;
                menuOrden.Visible = true;
                menuCliente.Visible = false;
            }

            LoadCharts();
        }

        private void controlDeOrdenesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControlOrdenes f = new ControlOrdenes();
            f.Show(this);
        }

        private void especialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControlEspecialidades f = new ControlEspecialidades();
            f.Show(this);
        }

        private void especimenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControlEspecimen f = new ControlEspecimen();
            f.Show(this);
        }

        private void misDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditarPassword f = new EditarPassword(this);
            f.Show(this);
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginModel.IdSuscripcion = 0;
            LoginModel.UserName = "";
            LoginModel.Token = "";
            LoginModel.Rol = 0;
            LoginModel.Medico = null;

            Login f = new Login();
            f.Show();
            this.Close();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void controlDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControlClientes f = new ControlClientes();
            f.Show(this);
        }

        private void controlDeCitasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControlCitas f = new ControlCitas();
            f.Show(this);
        }

        private void patologiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControlPatologias f = new ControlPatologias();
            f.Show(this);
        }

        private void controlDeDiagnosticosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControlDiagnosticos f = new ControlDiagnosticos();
            f.Show(this);
        }

        private void pacientesToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void pacientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void pacientesToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void pacientesToolStripMenuItem_EnabledChanged(object sender, EventArgs e)
        {
        }

        private void pacientesToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
        }

        private void pacientesToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
        }

        private void pacientesToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {

        }

        private void pacientesToolStripMenuItem_BackColorChanged(object sender, EventArgs e)
        {
        }

        private void controlDePacientesToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
        }

        private void medicamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControlMedicamentos f = new ControlMedicamentos();
            f.Show(this);
        }

        private void citasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void kryptonRibbonGroupButton1_Click(object sender, EventArgs e)
        {
            ControlPacientes f = new ControlPacientes();
            f.Show(this);
        }

        private void catalogosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void kryptonRibbonGroupButton2_Click(object sender, EventArgs e)
        {
            ControlMedicos f = new ControlMedicos();
            f.Show(this);
        }

        private void kryptonRibbonGroupButton5_Click(object sender, EventArgs e)
        {
            ControlOrdenes f = new ControlOrdenes();
            f.Show(this);
        }

        private void kryptonRibbonGroupButton7_Click(object sender, EventArgs e)
        {
            ControlEspecialidades f = new ControlEspecialidades();
            f.Show(this);
        }

        private void kryptonRibbonGroupButton8_Click(object sender, EventArgs e)
        {
            ControlEspecimen f = new ControlEspecimen();
            f.Show(this);
        }

        private void kryptonRibbonGroupButton9_Click(object sender, EventArgs e)
        {
            ControlPatologias f = new ControlPatologias();
            f.Show(this);
        }

        private void kryptonRibbonGroupButton10_Click(object sender, EventArgs e)
        {
            ControlMedicamentos f = new ControlMedicamentos();
            f.Show(this);
        }

        private void kryptonRibbonGroupButton11_Click(object sender, EventArgs e)
        {
            ControlClientes f = new ControlClientes();
            f.Show(this);
        }

        private void kryptonRibbonGroupButton13_Click(object sender, EventArgs e)
        {
            ControlCitas f = new ControlCitas();
            f.Show(this);
        }

        private void kryptonRibbonGroupButton15_Click(object sender, EventArgs e)
        {
            ControlDiagnosticos f = new ControlDiagnosticos();
            f.Show(this);
        }

        private void kryptonRibbon1_SelectedTabChanged(object sender, EventArgs e)
        {

        }

        private void kryptonRibbonGroup1_DialogBoxLauncherClick(object sender, EventArgs e)
        {

        }

        private void kryptonRibbonGroup8_DialogBoxLauncherClick(object sender, EventArgs e)
        {

        }

        private void kryptonRibbonGroupButton20_Click(object sender, EventArgs e)
        {
            ControlEspecialidades f = new ControlEspecialidades();
            f.Show(this);
        }

        private void kryptonRibbonGroupButton3_Click(object sender, EventArgs e)
        {
            ControlMedicos f = new ControlMedicos();
            f.Show(this);
        }

        private void kryptonRibbonGroupButton2_Click_1(object sender, EventArgs e)
        {
            ControlOrdenes f = new ControlOrdenes();
            f.Show(this);
        }

        private void kryptonRibbonGroupButton17_Click(object sender, EventArgs e)
        {
            ControlClientes f = new ControlClientes();
            f.Show(this);
        }

        private void kryptonRibbonGroupButton18_Click(object sender, EventArgs e)
        {
            ControlCitas f = new ControlCitas();
            f.Show(this);
        }

        private void kryptonRibbonGroupButton19_Click(object sender, EventArgs e)
        {
            ControlDiagnosticos f = new ControlDiagnosticos();
            f.Show(this);
        }

        private void kryptonRibbonGroupButton21_Click(object sender, EventArgs e)
        {
            ControlEspecimen f = new ControlEspecimen();
            f.Show(this);
        }

        private void kryptonRibbonGroupButton22_Click(object sender, EventArgs e)
        {
            ControlPatologias f = new ControlPatologias();
            f.Show(this);
        }

        private void kryptonRibbonGroupButton23_Click(object sender, EventArgs e)
        {
            ControlMedicamentos f = new ControlMedicamentos();
            f.Show(this);
        }

        private void kryptonRibbonGroupButton4_Click(object sender, EventArgs e)
        {
            ControlRecetas f = new ControlRecetas();
            f.Show(this);
        }

        private void kryptonRibbonGroup2_DialogBoxLauncherClick(object sender, EventArgs e)
        {

        }

        private void menuMiCuenta_Click(object sender, EventArgs e)
        {
            MiCuenta f = new MiCuenta();
            f.Show(this);
        }

        private void menuSalir_Click(object sender, EventArgs e)
        {
            DialogResult result = ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.cadenas.GetString("ConfirmarSalir"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LoginModel.IdSuscripcion = 0;
                LoginModel.UserName = "";
                LoginModel.Token = "";
                LoginModel.Rol = 0;
                LoginModel.Medico = null;

                Login f = new Login();
                f.Show();
                this.Close();
            }            
        }

        public async void LoadCharts()
        {
            List<PacienteModel> pacientes = new List<PacienteModel>();
            List<DiagnosticoModel> diagnosticos = new List<DiagnosticoModel>();
            List<CitaModel> citas = new List<CitaModel>();

            if (LoginModel.Medico != null)
            {
                citas = await new CitaServices().GetCitasByIdMedicoAndIdEstatusCita(new CitaModel() { Medico = LoginModel.Medico, EstatusCita = new EstatusCitaModel() { IdEstatusCita = (int)EstatusCitaEnum.AGE } });
                citas = citas.Where(c => c.FechaCitaDesde.Date == DateTime.Now.Date).OrderBy(d=>d.FechaCitaDesde.Date).ToList();

                List<object> citasDia = new List<object>();

                foreach (CitaModel cita in citas)
                {
                    citasDia.Add(new { Value = cita.FechaCitaDesde.ToString("hh:mm tt") + " " + (cita.Paciente.NombreCompleto.Trim() != "" ? cita.Paciente.NombreCompleto : cita.TipoCita.Descripcion)});
                };

                kryptonListBox1.DataSource = citasDia;
                kryptonListBox1.DisplayMember = "Value";
                kryptonListBox1.Refresh();
                kryptonHeaderGroup1.Draggable(true);
            }
            else
            {

            }
        }

        private void kryptonPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonLabel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonLabel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTotalDiagnosticos_Paint(object sender, PaintEventArgs e)
        {

        }

        private void KryptonPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void CitasAgendadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (kryptonHeaderGroup1.Visible)
            {
                kryptonHeaderGroup1.Visible = false;
            }
            else
            {
                kryptonHeaderGroup1.Visible = true;
            }
        }

        private void KryptonButton1_Click(object sender, EventArgs e)
        {
            LoadCharts();
        }

        private void KryptonListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (Utility.CheckForInternetConnection())
            {
                lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
                LoadCharts();
            }
        }
    }
}
