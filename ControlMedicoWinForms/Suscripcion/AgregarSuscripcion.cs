using ControlMedicoWinForms.Cliente;
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

namespace ControlMedicoWinForms.Suscripcion
{
    public partial class AgregarSuscripcion : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        AgregarCliente padre;
        public AgregarSuscripcion(AgregarCliente p)
        {
            padre = p;
            InitializeComponent();
        }

        private void AgregarSuscripcion_Load(object sender, EventArgs e)
        {

        }

        public bool ValidateForm()
        {
            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                try
                {
                    SuscripcionModel suscripcion = new SuscripcionModel()
                    {
                        Cliente = new ClienteModel(),
                        MaxUsuarios = (int)nudUsuarios.Value,
                        FechaInicio = dtpFechaInicio.Value,
                        FechaFin = dtpFechaFin.Value,
                        Activo = 1,
                        Transaccion = new TransaccionModel()
                        {
                            IdTipoTransaccion = 0,
                            IdOperacionContable = 0,
                            Fecha = DateTime.Now,
                            IdGenerado = 0,
                            Monto = nudMonto.Value,
                            MontoPagado = nudMontoPagado.Value,
                            NumReferencia = txtNumRef.Text
                        }
                    };

                    new Utility().GoAsync();
                    List<SuscripcionModel> listaSuscripciones = new List<SuscripcionModel>();
                    listaSuscripciones.Add(suscripcion);

                    padre.dtgrvSuscripciones.DataSource = listaSuscripciones;

                    padre.dtgrvSuscripciones.Columns[0].Visible = false;
                    padre.dtgrvSuscripciones.Columns[1].Visible = false;
                    padre.dtgrvSuscripciones.Columns[5].Visible = false;
                    padre.dtgrvSuscripciones.Columns[7].Visible = false;

                    padre.dtgrvSuscripciones.Columns[2].HeaderText = "Max Usuarios";
                    padre.dtgrvSuscripciones.Columns[3].HeaderText = "Fecha Inicio";
                    padre.dtgrvSuscripciones.Columns[4].HeaderText = "Fecha Fin";
                  
                    padre.dtgrvSuscripciones.Columns[0].Width = 50;
                    padre.dtgrvSuscripciones.Columns[1].Width = 100;
                    padre.dtgrvSuscripciones.Columns[2].Width = 100;
                    padre.dtgrvSuscripciones.Columns[5].Width = 50;
                    
                    padre.dtgrvSuscripciones.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    padre.dtgrvSuscripciones.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    padre.dtgrvSuscripciones.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    padre.dtgrvSuscripciones.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    padre.dtgrvSuscripciones.Refresh();
                    this.Close();
                }
                catch (Exception ex)
                {
                    ControlLenguaje.utility.WriteToErrorLog(AppDomain.CurrentDomain.BaseDirectory, ex);
                    ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.validationMessages.GetString("ErrorInesperado"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void nudUsuarios_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show("¿Seguro que desea cancelar?", ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
