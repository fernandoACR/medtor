using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MSHTML;
using System.Reflection;
using ControlMedicoConnector.Services;
using ControlMedicoConnector.Models;
using System.Linq;

namespace LiveSwitch.TextControl
{
    public partial class EditorForm : Form
    {
        private string _filename = null;
        ConfiguracionReporteServices configuracionReporteServices = new ConfiguracionReporteServices();
        List<ConfiguracionReporteModel> configuraciones = new List<ConfiguracionReporteModel>();
        ConfiguracionReporteModel configuracionSeleccionada = new ConfiguracionReporteModel();

        public EditorForm()
        {
            InitializeComponent();
            editor.Tick += new Editor.TickDelegate(editor_Tick);
        }

        private void editor_Tick()
        {
            undoToolStripMenuItem.Enabled = editor.CanUndo();
            redoToolStripMenuItem.Enabled = editor.CanRedo();
            cutToolStripMenuItem.Enabled = editor.CanCut();
            copyToolStripMenuItem.Enabled = editor.CanCopy();
            pasteToolStripMenuItem.Enabled = editor.CanPaste();
            imageToolStripMenuItem.Enabled = editor.CanInsertLink();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _filename = null;
            Text = null;
            editor.BodyHtml = string.Empty;
        }

        private async void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (_filename == null)
            //{
            //    if (!SaveFileDialog())
            //        return;
            //}
            //SaveFile(_filename);
            configuracionSeleccionada.Html = editor.DocumentText;
            if( await configuracionReporteServices.UpdateConfiguracionReporte(configuracionSeleccionada))
            {
                MessageBox.Show("Configuración actualizada");
            }
            else
            {
                MessageBox.Show("Ocurrió un error inesperado, por favor contacte con el administrador del sistema");
            }
        }

        private bool SaveFileDialog()
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.AddExtension = true;
                dlg.DefaultExt = "htm";
                dlg.Filter = "HTML files (*.html;*.htm)|*.html;*.htm";
                DialogResult res = dlg.ShowDialog(this);
                if (res == DialogResult.OK)
                {
                    _filename = dlg.FileName;
                    return true;
                }
                else
                    return false;
            }
        }

        private void SaveFile(string filename)
        {
            using (StreamWriter writer = File.CreateText(filename))
            {
                writer.Write(editor.DocumentText);
                writer.Flush();
                writer.Close();
            }
        }

        private void LoadFile(string filename)
        {
            using (StreamReader reader = File.OpenText(filename))
            {
                editor.Html = reader.ReadToEnd();
                Text = editor.DocumentTitle;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "HTML files (*.html;*.htm)|*.html;*.htm";
                DialogResult res = dlg.ShowDialog(this);
                if (res == DialogResult.OK)
                {
                    _filename = dlg.FileName;
                }
                else
                    return;
            }
            LoadFile(_filename);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveFileDialog())
                SaveFile(_filename);
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SearchDialog dlg = new SearchDialog(editor))
            {
                dlg.ShowDialog(this);
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.SelectAll();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.Paste();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.Redo();
        }

        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, editor.BodyText);
        }

        private void htmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, editor.BodyHtml);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.Print();
        }

        private void breakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.InsertBreak();
        }

        private void textToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (TextInsertForm form = new TextInsertForm(editor.BodyHtml))
            {
                form.ShowDialog(this);
                if (form.Accepted)
                {
                    editor.BodyHtml = form.HTML;
                }
            }
        }

        private void paragraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.InsertParagraph();
        }

        private void imageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.InsertImage();
        }

        private void emailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ConfigureSMTPForm(null, 25, SMTPAuthenticationType.UsernamePassword, null, null, true, editor.ToMailMessage());
            form.ShowDialog();
        }

        private async void EditorForm_Load(object sender, EventArgs e)
        {
            configuraciones = await configuracionReporteServices.GetConfiguracionReporteByIdMedico(new ConfiguracionReporteModel() { Medico = LoginModel.Medico });
             
            foreach(ConfiguracionReporteModel configuracion in configuraciones)
            {               
                var item2 = new ToolStripMenuItem()
                {
                    Name = configuracion.TipoReporte.IdTipoReporte.ToString(),
                    Text = configuracion.TipoReporte.Descripcion
                };

                item2.Click += new EventHandler(ExpedienteToolStripMenuItem_Click);
                defaultToolStripMenuItem.DropDownItems.Add(item2);
            }
            //List<object> listaOpciones = new List<object>();
            //listaOpciones.Add(new { Text = "NombrePaciente", Value = "receta.Paciente.PrimerNombre" });
            //listaOpciones.Add(new { Text = "Fecha", Value = "receta.FechaCreacion" });
            //listaOpciones.Add(new { Text = "NombreMedico", Value = "receta.Medico.Nombre" });

            //object[] subjects = new object[3];
            //subjects[0] = new { Text = "NombrePaciente", Value = "receta.Paciente.PrimerNombre" };
            //subjects[1] = new { Text = "Fecha", Value = "receta.FechaCreacion" };
            //subjects[2] = new { Text = "NombreMedico", Value = "receta.Medico.Nombre" };

            //cmbVariables.ComboBox.ValueMember = "Value";
            //cmbVariables.ComboBox.DisplayMember = "Text";
            ////cmbVariables.ComboBox.DataSource = listaOpciones;
            //cmbVariables.ComboBox.Items.AddRange(subjects);
            //cmbVariables.ComboBox.Refresh();
        }

        private void CmbVariables_SelectedIndexChanged(object sender, EventArgs e)
        {
            dynamic value = cmbVariables.SelectedItem;
            
            editor.InsertVariable(value);
        }

        private void PacienteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ExpedienteToolStripMenuItem_Click(dynamic sender, EventArgs e)
        {
            ConfiguracionReporteModel configuracionReporte = configuraciones.Where(x => x.TipoReporte.IdTipoReporte == Convert.ToInt32(sender.Name)).FirstOrDefault();
            configuracionSeleccionada = configuracionReporte;

            string html = configuracionReporte.Html;

            List<TipoReporteVariableModel> listaVariables = configuracionReporte.TipoReporte.Variables;

            editor.BodyHtml = html;

            object[] listaOpciones = new object[listaVariables.Count];

            for (int i = 0; i<= listaVariables.Count -1; i++)
            {
                listaOpciones[i] = new { Text = listaVariables[i].Descripcion, Value = listaVariables[i].Propiedad };
            }

            cmbVariables.ComboBox.ValueMember = "Value";
            cmbVariables.ComboBox.DisplayMember = "Text";
            cmbVariables.ComboBox.Items.AddRange(listaOpciones);
            cmbVariables.ComboBox.Refresh();
        }

        private void variablesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}