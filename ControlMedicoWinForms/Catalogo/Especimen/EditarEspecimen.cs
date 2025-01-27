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
    public partial class EditarEspecimen : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        ControlEspecimen padre;
        int id;
        CatalogoServices services = new CatalogoServices();

        public EditarEspecimen(int idEspecimen, ControlEspecimen p)
        {
            id = idEspecimen;
            padre = p;
            InitializeComponent();
        }

        private async void EditarEspecimen_Load(object sender, EventArgs e)
        {
            this.Font = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);

            try
            {
                EspecimenModel especimen = await services.GetEspecimenById(new EspecimenModel() { IdEspecimen = id });

                if (especimen != null)
                {
                    txtDescripcion.Text = especimen.Descripcion;
                    chkActivo.Checked = Convert.ToBoolean(especimen.Activo);
                }
            }
            catch (Exception ex)
            {
                ControlLenguaje.utility.WriteToErrorLog(AppDomain.CurrentDomain.BaseDirectory, ex);
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.validationMessages.GetString("ErrorInesperado"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtDescripcion.Text != "")
            {
                try
                {
                    if (await services.UpdateEspecimen(new EspecimenModel() { Descripcion = txtDescripcion.Text, Medico = LoginModel.Medico, IdEspecimen = id, Activo = Convert.ToInt32(chkActivo.Checked) }))
                    {
                        ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.cadenas.GetString("EspecimenEditado"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
