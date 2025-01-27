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
    public partial class EditarEspecialidad : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        ControlEspecialidades padre;
        int id;
        CatalogoServices services = new CatalogoServices();

        public EditarEspecialidad(int idEspecialidad, ControlEspecialidades p)
        {
            id = idEspecialidad;
            padre = p;
            InitializeComponent();
        }

        private async void EditarEspecialidad_Load(object sender, EventArgs e)
        {
            this.Font = Utility.GetMedtorFont(FontControlEnum.GroupBoxControls);

            try
            {
                EspecialidadModel especialidad = await services.GetEspecialidadById(new EspecialidadModel() { IdEspecialidad = id });

                if (especialidad != null)
                {
                    txtDescripcion.Text = especialidad.Descripcion;
                    chkActivo.Checked = Convert.ToBoolean(especialidad.Activo);
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
                    if (await services.UpdateEspecialidad(new EspecialidadModel() { Descripcion = txtDescripcion.Text, IdEspecialidad = id, Activo = Convert.ToInt32(chkActivo.Checked) }))
                    {
                        ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show(ControlLenguaje.cadenas.GetString("EspecialidadEditada"), ControlLenguaje.cadenas.GetString("NombreAplicacion"), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
