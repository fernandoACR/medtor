using ControlMedicoWinForms.Archivo;
using ControlMedicoWinForms.Catalogo;
using ControlMedicoWinForms.Diagnostico;
using ControlMedicoWinForms.Medico;
using ControlMedicoWinForms.Models;
using ControlMedicoWinForms.Paciente;
using ControlMedicoWinForms.Properties;
using ControlMedicoWinForms.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ControlMedicoWinForms.Models.ComunModel;

namespace ControlMedicoWinForms.Orden
{
    public partial class EditarOrden : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        ControlOrdenes padre;
        int id;
        OrdenServices ordenServices = new OrdenServices();
        MedicoServices medicoServices = new MedicoServices();
        PacienteServices pacienteServices = new PacienteServices();
        CatalogoServices catalogoServices = new CatalogoServices();
        DiagnosticoServices diagnosticoServices = new DiagnosticoServices();

        bool esRecepcion = false;
        OrdenModel orden = new OrdenModel();

        Dictionary<string, List<string>> rutasAdjuntos = new Dictionary<string, List<string>>();
        List<ArchivoOrdenModel> archivosAdjuntos = new List<ArchivoOrdenModel>();

        public EditarOrden(int idOrden, ControlOrdenes p)
        {
            padre = p;
            id = idOrden;
            
           
            InitializeComponent();
        }

        private async void EditarOrden_Load(object sender, EventArgs e)
        {
            this.Font = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);
            this.kryptonNavigator1.StateCommon.RibbonGeneral.TextFont = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);
            this.kryptonGroupBox1.StateCommon.Content.ShortText.Font = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);
            this.kryptonGroupBox2.StateCommon.Content.ShortText.Font = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);
            this.kryptonGroupBox3.StateCommon.Content.ShortText.Font = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);
            this.kryptonPage1.StateCommon.RibbonGeneral.TextFont = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);
            this.kryptonPage2.StateCommon.RibbonGeneral.TextFont = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);

            lstArchivosAdjuntos.Controls[0].DoubleClick += lstArchivosAdjuntos_DoubleClick;

            cmbMedicoEntrega.Enabled = false;
            cmbPaciente.Enabled = false;
            this.Width = 925;
            this.Height = 735;
            this.kryptonNavigator1.Height = 640;
            this.kryptonNavigator1.Width = 888;

            List<object> listEstatusOrden = new List<object>();
            listEstatusOrden.Add(new { IdEstatus = (int)EstatusOrdenEnum.REC, Descripcion = "Recibida" });
            listEstatusOrden.Add(new { IdEstatus = (int)EstatusOrdenEnum.PRO, Descripcion = "En proceso" });
            listEstatusOrden.Add(new { IdEstatus = (int)EstatusOrdenEnum.ENTO, Descripcion = "Completada" });
            cmbEstatus.DataSource = listEstatusOrden;
            cmbEstatus.DisplayMember = "Descripcion";
            cmbEstatus.ValueMember = "IdEstatus";

            lblEntregada.Text = "Entregada";
            picbEntregada.Image = Resources.SinEjecutar;
            picbEntregada.SizeMode = PictureBoxSizeMode.StretchImage;

            lblRecibida.Text = "Recibida";
            picbRecibida.Image = Resources.SinEjecutar;
            picbRecibida.SizeMode = PictureBoxSizeMode.StretchImage;

            lblEnProceso.Text = "En Proceso";
            picbEnProceso.Image = Resources.SinEjecutar;
            picbEnProceso.SizeMode = PictureBoxSizeMode.StretchImage;

            lblCompletada.Text = "Completado";
            picbCompletada.Image = Resources.SinEjecutar;
            picbCompletada.SizeMode = PictureBoxSizeMode.StretchImage;

            if (Utility.CheckForInternetConnection())
            {
                try
                {
                orden.IdOrden = id;
                orden = await ordenServices.GetOrdenById(orden);

                if (orden != null)
                {
                    picbEntregada.Image = Resources.Ejecutado;
                    lblFechaEntrega.Text = orden.FechaCreacion.ToString("dd/MM/yyyy");

                    if(orden.HistoricoOrden.Exists(d=>d.EstatusOrden.IdEstatusOrden == (int)EstatusOrdenEnum.REC))
                    {
                        picbRecibida.Image = Resources.Ejecutado;
                        lblFechaRecibe.Text = orden.HistoricoOrden.Find(d => d.EstatusOrden.IdEstatusOrden == (int)EstatusOrdenEnum.REC).FechaEstatus.ToString("dd/MM/yyyy");
                    }

                    if (orden.HistoricoOrden.Exists(d => d.EstatusOrden.IdEstatusOrden == (int)EstatusOrdenEnum.PRO))
                    {
                        picbEnProceso.Image = Resources.Ejecutado;
                        lblFechaProceso.Text = orden.HistoricoOrden.Find(d => d.EstatusOrden.IdEstatusOrden == (int)EstatusOrdenEnum.PRO).FechaEstatus.ToString("dd/MM/yyyy");
                    }

                    if (orden.HistoricoOrden.Exists(d => d.EstatusOrden.IdEstatusOrden == (int)EstatusOrdenEnum.ENTO))
                    {
                        picbCompletada.Image = Resources.Ejecutado;
                        lblFechaCompleto.Text = orden.HistoricoOrden.Find(d => d.EstatusOrden.IdEstatusOrden == (int)EstatusOrdenEnum.ENTO).FechaEstatus.ToString("dd/MM/yyyy");
                    }

                    if (orden.MedicoRecepcion.IdMedico == LoginModel.Medico.IdMedico)
                    {
                        esRecepcion = true;
                        //dtpFechaRecepcion.Visible = false;
                        //lblFechaRecepcion.Visible = false;
                        cmbMedicoEntrega.Enabled = false;
                        cmbMedicoRecibe.Enabled = false;
                        cmbDiagnostico.Enabled = false;
                        chkActivo.Visible = false;
                        dtpFechaEntrega.Enabled = false;
                        cmbEspecimen.Enabled = false;

                        if (orden.Monto > 0)
                        {
                            txtPrecio.Enabled = false;
                        }

                        if (orden.Pagado > 0)
                        {
                            chkPagado.Enabled = false;
                        }

                        dtpFechaRecepcion.Enabled = false;

                        if (orden.FechaEntregaOrigen != null)
                        {
                            dtpFechaEntrega.Enabled = false;
                        }

                        if (orden.Estatus.IdEstatusOrden == (int)EstatusOrdenEnum.ENTO)
                        {
                            if(orden.Pagado > 0)
                            {
                                btnEditar.Visible = false;
                                btnCancelar.Text = "Salir";
                            }

                            cmbEstatus.Enabled = false;
                            txtObservaciones.Enabled = false;                            
                        }
                    }

                    //Obtener pacientes
                    var pacientes = new List<PacienteModel>();

                    var medicos = await medicoServices.GetAllMedicos();

                    var diagnosticos = new List<DiagnosticoModel>();

                    if (LoginModel.Medico == null)
                    {
                        pacientes = await pacienteServices.GetAllPacientes();

                        medicos.Add(new MedicoModel { IdMedico = 0, Nombre = "Seleccione" });
                        cmbMedicoEntrega.DataSource = medicos.OrderBy(x => x.IdMedico).ToList();
                        cmbMedicoEntrega.DisplayMember = "Nombre";
                        cmbMedicoEntrega.ValueMember = "IdMedico";

                        cmbMedicoRecibe.DataSource = medicos.OrderBy(x => x.IdMedico).ToList();
                        cmbMedicoRecibe.DisplayMember = "Nombre";
                        cmbMedicoRecibe.ValueMember = "IdMedico";
                    }
                    else if (LoginModel.Medico != null && !esRecepcion)
                    {
                        pacientes = await pacienteServices.GetPacienteByIdMedico(new PacienteModel() { Medico = new MedicoModel() { IdMedico = LoginModel.Medico.IdMedico } });
                        
                        lblMedicoEntrega.Visible = false;
                        cmbMedicoEntrega.Visible = false;

                        medicos.Add(new MedicoModel { IdMedico = 0, Nombre = "Seleccione" });
                        cmbMedicoRecibe.DataSource = medicos.Where(x => x.IdMedico != LoginModel.Medico.IdMedico).OrderBy(x => x.IdMedico).ToList();
                        cmbMedicoRecibe.DisplayMember = "Nombre";
                        cmbMedicoRecibe.ValueMember = "IdMedico";
                    }
                    else if (LoginModel.Medico != null && esRecepcion)
                    {
                        pacientes.Add(await pacienteServices.GetPacienteById(new PacienteModel() { IdPaciente = orden.Paciente.IdPaciente }));

                        medicos.Add(new MedicoModel { IdMedico = 0, Nombre = "Seleccione" });
                        cmbMedicoEntrega.DataSource = medicos.OrderBy(x => x.IdMedico).ToList();
                        cmbMedicoEntrega.DisplayMember = "Nombre";
                        cmbMedicoEntrega.ValueMember = "IdMedico";

                        cmbMedicoRecibe.DataSource = medicos.OrderBy(x => x.IdMedico).ToList();
                        cmbMedicoRecibe.DisplayMember = "Nombre";
                        cmbMedicoRecibe.ValueMember = "IdMedico";
                    }

                    pacientes.Add(new PacienteModel { IdPaciente = 0, NombreCompleto = "Seleccione" });
                    cmbPaciente.DataSource = pacientes.OrderBy(x => x.IdPaciente).ToList();
                    cmbPaciente.DisplayMember = "NombreCompleto";
                    cmbPaciente.ValueMember = "IdPaciente";

                    var especimenes = await catalogoServices.GetAllEspecimenes();
                    especimenes.Add(new EspecimenModel { IdEspecimen = 0, Descripcion = "Seleccione" });
                    cmbEspecimen.DataSource = especimenes.OrderBy(x => x.IdEspecimen).ToList();
                    cmbEspecimen.DisplayMember = "Descripcion";
                    cmbEspecimen.ValueMember = "IdEspecimen";

                    cmbMedicoEntrega.SelectedValue = orden.MedicoEntrega.IdMedico;
                    cmbMedicoRecibe.SelectedValue = orden.MedicoRecepcion.IdMedico;
                    cmbPaciente.SelectedValue = orden.Paciente.IdPaciente;
                    cmbEspecimen.SelectedValue = orden.Especimen.IdEspecimen;

                    diagnosticos = await diagnosticoServices.GetDiagnosticoByIdPaciente(new DiagnosticoModel() { Paciente = new PacienteModel() { IdPaciente = orden.Paciente.IdPaciente } });
                    diagnosticos.Add(new DiagnosticoModel { IdDiagnostico = 0, Descripcion = "Seleccione" });
                    cmbDiagnostico.DataSource = diagnosticos.OrderBy(x => x.IdDiagnostico).ToList();
                    cmbDiagnostico.DisplayMember = "Descripcion";
                    cmbDiagnostico.ValueMember = "IdDiagnostico";
                    cmbDiagnostico.SelectedValue = orden.Diagnostico.IdDiagnostico;

                    if (orden.FechaRecepcion != null)
                        dtpFechaRecepcion.Value = (DateTime)orden.FechaRecepcion;

                    if (orden.FechaEntregaOrigen != null)
                        dtpFechaEntrega.Value = (DateTime)orden.FechaEntregaOrigen;

                    txtPrecio.Value = (decimal)orden.Monto;
                    txtObservaciones.Text = orden.Observaciones;
                    chkPagado.Checked = Convert.ToBoolean(orden.Pagado);
                    chkActivo.Checked = Convert.ToBoolean(orden.Activo);
                    cmbEstatus.SelectedValue = orden.Estatus.IdEstatusOrden;

                    if (orden.Pagado > 0 && orden.FechaRecepcion != null && !esRecepcion)
                    {
                        cmbEspecimen.Enabled = false;
                        cmbDiagnostico.Enabled = false;
                        txtPrecio.Enabled = false;
                        txtObservaciones.Enabled = false;
                        //txtxEntregadoPor.Enabled = false;
                        dtpFechaEntrega.Enabled = false;
                        dtpFechaRecepcion.Enabled = false;
                        chkPagado.Enabled = false;
                        cmbEstatus.Enabled = false;
                        cmbPaciente.Enabled = false;
                        cmbMedicoRecibe.Enabled = false;

                        if (orden.Estatus.IdEstatusOrden == (int)EstatusOrdenEnum.ENTO)
                        {
                            if (orden.Pagado > 0)
                            {
                                btnEditar.Visible = false;
                                btnCancelar.Text = ControlLenguaje.cadenas.GetString("TextoBtnSalir");
                            }

                            cmbEstatus.Enabled = false;
                            txtObservaciones.Enabled = false;
                            btnAgregarAdjunto.Enabled = false;
                            btnQuitarAdjunto.Enabled = false;
                        }
                    }

                    if (orden.ArchivosAdjuntos != null)
                    {
                        if (orden.ArchivosAdjuntos.Count > 0)
                        {
                            archivosAdjuntos = orden.ArchivosAdjuntos;

                            foreach (ArchivoOrdenModel archivo in orden.ArchivosAdjuntos)
                            {
                                rutasAdjuntos.Add(archivo.Descripcion, new List<string>()
                                {
                                    "",
                                    archivo.TipoArchivo.Descripcion,
                                    archivo.Codigo.ToString(),
                                    archivo.Archivo,
                                    archivo.ExtensionArchivo
                                });

                                lstArchivosAdjuntos.Items.Add(archivo.Descripcion);
                            }
                        }
                    }
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (btnCancelar.Text == ControlLenguaje.cadenas.GetString("TextoBtnCancelar"))
            {
                DialogResult result = ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.cadenas.GetString("ConfirmarCancelar"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            btnEditar.Enabled = false;
            btnCancelar.Enabled = false;

            OrdenModel ordenModel = new OrdenModel()
            {
                IdOrden = id,
                MedicoRecepcion = new MedicoModel() { IdMedico = (int)cmbMedicoRecibe.SelectedValue },
                //PersonaEntrega = txtxEntregadoPor.Text,
                PersonaRecepcion = txtPersonaRecibe.Text,
                Diagnostico = new DiagnosticoModel() { IdDiagnostico = (int)cmbDiagnostico.SelectedValue },
                //Entrega = txtxEntregadoPor.Text,
                Especimen = new EspecimenModel() { IdEspecimen = (int)cmbEspecimen.SelectedValue },
                Paciente = new PacienteModel() { IdPaciente = (int)cmbPaciente.SelectedValue },
                Observaciones = txtObservaciones.Text,
                Pagado = Convert.ToInt32(chkPagado.Checked),
                Activo = Convert.ToInt32(chkActivo.Checked),
                Monto = txtPrecio.Value,
                FechaEntregaOrigen = dtpFechaEntrega.Value
            };            

            if (cmbMedicoEntrega.SelectedValue != null)
            {
                ordenModel.MedicoEntrega = new MedicoModel() { IdMedico = (int)cmbMedicoEntrega.SelectedValue };
            }
            else
            {
                ordenModel.MedicoEntrega = orden.MedicoEntrega;
            }

            if (cmbEstatus.SelectedValue != null)
            {
                ordenModel.Estatus = new Models.Catalogo.EstatusOrdenModel() { IdEstatusOrden = (int)cmbEstatus.SelectedValue };
            }
            else
            {
                ordenModel.Estatus = orden.Estatus;
            }

            if(esRecepcion && orden.FechaRecepcion == null)
            {
                ordenModel.FechaRecepcion = DateTime.Now;
            }
            else 
            {
                ordenModel.FechaRecepcion = orden.FechaRecepcion;
            }

            if (esRecepcion && (int)cmbEstatus.SelectedValue == (int)EstatusOrdenEnum.ENTO && orden.FechaEntregaOrigen != null && orden.FechaRecepcion != null)
            {
                ordenModel.FechaEntregaOrigen = DateTime.Now;
            }

            if (rutasAdjuntos.Count > 0)
            {
                List<ArchivoOrdenModel> listAdjuntos = new List<ArchivoOrdenModel>();
                foreach (var adjunto in rutasAdjuntos)
                {
                    byte[] file;
                    string codigo = "";
                    if (adjunto.Value[0] != "")
                    {
                        using (var stream = new FileStream(adjunto.Value[0], FileMode.Open, FileAccess.Read))
                        {
                            using (var reader = new BinaryReader(stream))
                            {
                                file = reader.ReadBytes((int)stream.Length);
                            }
                        }
                    }
                    else
                    {
                        file = Convert.FromBase64String(adjunto.Value[3]);
                        codigo = adjunto.Value[2];
                    }

                    listAdjuntos.Add(new ArchivoOrdenModel()
                    {
                        Orden = new OrdenModel() { IdOrden = ordenModel.IdOrden },
                        TipoArchivo = new TipoArchivoModel() { IdTipoArchivo = Convert.ToInt32(adjunto.Value[1]) },
                        Descripcion = adjunto.Key,
                        Archivo = Convert.ToBase64String(file),
                        ExtensionArchivo = Path.GetExtension(adjunto.Value[0]),
                        Activo = 1,
                        Codigo = codigo != "" ? Guid.Parse(codigo) : Guid.Empty
                    });
                }

                ordenModel.ArchivosAdjuntos = listAdjuntos;
            }

            if (await ordenServices.UpdateOrden(ordenModel))
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.cadenas.GetString("OrdenEditada"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnEditar.Enabled = true;
                btnCancelar.Enabled = true;
                padre.Cargar();
                this.Close();
            }
            else
            {
                ControlLenguaje.utility.WriteToErrorLog(AppDomain.CurrentDomain.BaseDirectory, new Exception());
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.validationMessages.GetString("ErrorInesperado"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnEditar.Enabled = true;
                btnCancelar.Enabled = true;
            }
        }

        private void dtpFechaEntrega_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaEntrega.CustomFormat = "dd/MM/yyyy";
        }

        private void dtpFechaRecepcion_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaRecepcion.CustomFormat = "dd/MM/yyyy";
        }

        private void cmbPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Obtener Diagnosticos
            //if (cmbPaciente.SelectedIndex > 0 && !esRecepcion)
            //{
            //    var diagnosticos = await diagnosticoServices.GetDiagnosticoByIdPaciente(new DiagnosticoModel() { Paciente = new PacienteModel() { IdPaciente = (int)cmbPaciente.SelectedValue } });
            //    diagnosticos.Add(new DiagnosticoModel { IdDiagnostico = 0, Descripcion = "Seleccione" });
            //    cmbDiagnostico.DataSource = diagnosticos.OrderBy(x => x.IdDiagnostico).ToList();
            //    cmbDiagnostico.DisplayMember = "Descripcion";
            //    cmbDiagnostico.ValueMember = "IdDiagnostico";
            //}
        }

        private void cmbMedicoRecibe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMedicoRecibe.SelectedIndex > 0)
            {
                txtPersonaRecibe.Text = "";
                txtPersonaRecibe.Enabled = false;
            }
            else
            {
                txtPersonaRecibe.Enabled = true;
            }
        }

        private void txtPersonaRecibe_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtPersonaRecibe.Text != "")
            {
                cmbMedicoRecibe.SelectedIndex = 0;
            }
        }

        private void cmbEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if ((int)cmbEstatus.SelectedValue == (int)EstatusOrdenEnum.PRO)
                {
                    if(orden.FechaEntregaOrigen != null)
                        dtpFechaEntrega.Enabled = false;
                    else
                        dtpFechaEntrega.Enabled = true;
                }
                else
                {
                    dtpFechaEntrega.Enabled = false;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void kryptonPage1_Click(object sender, EventArgs e)
        {

        }

        private void kryptonLabel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void picbEntregada_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void kryptonLabel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void chkPagado_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void kryptonGroupBox3_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lstArchivosAdjuntos_DoubleClick(object sender, EventArgs e)
        {
            string adjuntoSeleccionado = (string)lstArchivosAdjuntos.SelectedItem;
            if (adjuntoSeleccionado != "" && adjuntoSeleccionado != null)
            {
                var archivo = rutasAdjuntos[adjuntoSeleccionado];

                if (archivo[0] == "")
                {
                    string path = AppDomain.CurrentDomain.BaseDirectory + adjuntoSeleccionado + archivo[4];
                    File.WriteAllBytes(path, Convert.FromBase64String(archivo[3]));
                    Process.Start(path);
                }
                else
                {
                    Process.Start(archivo[0]);
                }
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            txtNombreArchivo.Text = openFileDialog1.FileName;
            AgregarArchivo f = new AgregarArchivo(this);
            f.Show(this);
        }

        private void btnAgregarAdjunto_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        public void AdjuntarArchivo(string descripcion, int tipoArchivo)
        {
            lstArchivosAdjuntos.Items.Add(descripcion);
            rutasAdjuntos.Add(descripcion, new List<string>() { txtNombreArchivo.Text, tipoArchivo.ToString() });
            txtNombreArchivo.Text = "";
        }

        private void btnQuitarAdjunto_Click(object sender, EventArgs e)
        {
            string adjuntoSeleccionado = (string)lstArchivosAdjuntos.SelectedItem;
            if (adjuntoSeleccionado != "" && adjuntoSeleccionado != null)
            {
                lstArchivosAdjuntos.Items.Remove(adjuntoSeleccionado);
                rutasAdjuntos.Remove(adjuntoSeleccionado);
                txtNombreArchivo.Text = "";
            }
        }
    }
}
