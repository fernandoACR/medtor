using ControlMedicoWinForms.Models;
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

namespace ControlMedicoWinForms.Catalogo.Medicamento
{
    public partial class EditarMedicamento : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        ControlMedicamentos padre;
        int id;
        CatalogoServices services = new CatalogoServices();

        public EditarMedicamento(int idMedicamento, ControlMedicamentos p)
        {
            id = idMedicamento;
            padre = p;
            InitializeComponent();
        }

        private async void EditarMedicamento_Load(object sender, EventArgs e)
        {
            this.Font = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);

            try
            {
                MedicamentoModel medicamento = await services.GetMedicamentoById(new MedicamentoModel() { IdMedicamento = id });

                if (medicamento != null)
                {
                    txtDescripcion.Text = medicamento.Descripcion;
                    chkActivo.Checked = Convert.ToBoolean(medicamento.Activo);
                }
            }
            catch (Exception ex)
            {
                ControlLenguaje.utility.WriteToErrorLog(AppDomain.CurrentDomain.BaseDirectory, ex);
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.validationMessages.GetString("ErrorInesperado"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtDescripcion.Text != "")
            {
                try
                {
                    if (await services.UpdateMedicamento(new MedicamentoModel() {IdMedicamento = id, Descripcion = txtDescripcion.Text, Medico = LoginModel.Medico, Activo = Convert.ToInt32(chkActivo.Checked) }))
                    {
                        ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.cadenas.GetString("MedicamentoEditado"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        padre.Cargar();
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    ControlLenguaje.utility.WriteToErrorLog(AppDomain.CurrentDomain.BaseDirectory, ex);
                    ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.validationMessages.GetString("ErrorInesperado"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(string.Format(ControlLenguaje.validationMessages.GetString("CampoVacio"), ControlLenguaje.cadenas.GetString("TextoCampoDescripcion")), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
