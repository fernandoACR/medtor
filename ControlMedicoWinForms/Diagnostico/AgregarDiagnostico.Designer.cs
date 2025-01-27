namespace ControlMedicoWinForms.Diagnostico
{
    partial class AgregarDiagnostico
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarDiagnostico));
            this.label6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtDescripcion = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtAlergias = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblNombreMedico = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cmbMedico = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.label1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cmbPaciente = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.btnCancelar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnAgregar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.btnQuitarAdjunto = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnAgregarAdjunto = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtNombreArchivo = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lstArchivosAdjuntos = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
            this.txtAltura = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.txtPeso = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMedico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPaciente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(19, 238);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 24);
            this.label6.TabIndex = 12;
            this.label6.Values.Text = "Descripcion:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.AlwaysActive = false;
            this.txtDescripcion.Location = new System.Drawing.Point(19, 262);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(879, 210);
            this.txtDescripcion.StateActive.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txtDescripcion.StateActive.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtDescripcion.StateCommon.Border.Color1 = System.Drawing.Color.White;
            this.txtDescripcion.StateCommon.Border.Color2 = System.Drawing.Color.White;
            this.txtDescripcion.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtDescripcion.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.txtDescripcion.StateCommon.Border.Rounding = 4;
            this.txtDescripcion.StateCommon.Border.Width = 2;
            this.txtDescripcion.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(19, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 24);
            this.label5.TabIndex = 8;
            this.label5.Values.Text = "Alergico a:";
            // 
            // txtAlergias
            // 
            this.txtAlergias.AlwaysActive = false;
            this.txtAlergias.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAlergias.Location = new System.Drawing.Point(22, 145);
            this.txtAlergias.Name = "txtAlergias";
            this.txtAlergias.Size = new System.Drawing.Size(427, 33);
            this.txtAlergias.StateActive.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txtAlergias.StateActive.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtAlergias.StateCommon.Border.Color1 = System.Drawing.Color.White;
            this.txtAlergias.StateCommon.Border.Color2 = System.Drawing.Color.White;
            this.txtAlergias.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtAlergias.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.txtAlergias.StateCommon.Border.Rounding = 4;
            this.txtAlergias.StateCommon.Border.Width = 2;
            this.txtAlergias.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(236, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 24);
            this.label4.TabIndex = 6;
            this.label4.Values.Text = "Altura (m)";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 24);
            this.label3.TabIndex = 5;
            this.label3.Values.Text = "Peso (kg)";
            // 
            // lblNombreMedico
            // 
            this.lblNombreMedico.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreMedico.Location = new System.Drawing.Point(19, 180);
            this.lblNombreMedico.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombreMedico.Name = "lblNombreMedico";
            this.lblNombreMedico.Size = new System.Drawing.Size(148, 24);
            this.lblNombreMedico.TabIndex = 1;
            this.lblNombreMedico.Values.Text = "Nombre del Médico";
            // 
            // cmbMedico
            // 
            this.cmbMedico.AlwaysActive = false;
            this.cmbMedico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMedico.DropDownWidth = 427;
            this.cmbMedico.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMedico.FormattingEnabled = true;
            this.cmbMedico.Location = new System.Drawing.Point(22, 204);
            this.cmbMedico.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMedico.Name = "cmbMedico";
            this.cmbMedico.Size = new System.Drawing.Size(427, 31);
            this.cmbMedico.StateActive.ComboBox.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cmbMedico.StateActive.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cmbMedico.StateCommon.ComboBox.Border.Color1 = System.Drawing.Color.White;
            this.cmbMedico.StateCommon.ComboBox.Border.Color2 = System.Drawing.Color.White;
            this.cmbMedico.StateCommon.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cmbMedico.StateCommon.ComboBox.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.cmbMedico.StateCommon.ComboBox.Border.Rounding = 4;
            this.cmbMedico.StateCommon.ComboBox.Border.Width = 2;
            this.cmbMedico.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 24);
            this.label1.TabIndex = 1;
            this.label1.Values.Text = "Nombre del Paciente";
            // 
            // cmbPaciente
            // 
            this.cmbPaciente.AlwaysActive = false;
            this.cmbPaciente.DropDownWidth = 427;
            this.cmbPaciente.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPaciente.FormattingEnabled = true;
            this.cmbPaciente.Location = new System.Drawing.Point(22, 40);
            this.cmbPaciente.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPaciente.Name = "cmbPaciente";
            this.cmbPaciente.Size = new System.Drawing.Size(427, 31);
            this.cmbPaciente.StateActive.ComboBox.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cmbPaciente.StateActive.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cmbPaciente.StateCommon.ComboBox.Border.Color1 = System.Drawing.Color.White;
            this.cmbPaciente.StateCommon.ComboBox.Border.Color2 = System.Drawing.Color.White;
            this.cmbPaciente.StateCommon.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cmbPaciente.StateCommon.ComboBox.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.cmbPaciente.StateCommon.ComboBox.Border.Rounding = 4;
            this.cmbPaciente.StateCommon.ComboBox.Border.Width = 2;
            this.cmbPaciente.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.LightGray;
            this.btnCancelar.Location = new System.Drawing.Point(834, 552);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 32);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Values.Image = global::ControlMedicoWinForms.Properties.Resources.cancelar;
            this.btnCancelar.Values.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.LightGray;
            this.btnAgregar.Location = new System.Drawing.Point(712, 552);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(100, 32);
            this.btnAgregar.TabIndex = 5;
            this.btnAgregar.Values.Image = global::ControlMedicoWinForms.Properties.Resources.btnGuardar;
            this.btnAgregar.Values.Text = "Guardar";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.CaptionStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
            this.kryptonGroupBox1.Location = new System.Drawing.Point(8, 0);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.btnQuitarAdjunto);
            this.kryptonGroupBox1.Panel.Controls.Add(this.btnAgregarAdjunto);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel1);
            this.kryptonGroupBox1.Panel.Controls.Add(this.txtNombreArchivo);
            this.kryptonGroupBox1.Panel.Controls.Add(this.lstArchivosAdjuntos);
            this.kryptonGroupBox1.Panel.Controls.Add(this.txtAltura);
            this.kryptonGroupBox1.Panel.Controls.Add(this.txtPeso);
            this.kryptonGroupBox1.Panel.Controls.Add(this.cmbMedico);
            this.kryptonGroupBox1.Panel.Controls.Add(this.cmbPaciente);
            this.kryptonGroupBox1.Panel.Controls.Add(this.label6);
            this.kryptonGroupBox1.Panel.Controls.Add(this.label1);
            this.kryptonGroupBox1.Panel.Controls.Add(this.txtDescripcion);
            this.kryptonGroupBox1.Panel.Controls.Add(this.lblNombreMedico);
            this.kryptonGroupBox1.Panel.Controls.Add(this.label5);
            this.kryptonGroupBox1.Panel.Controls.Add(this.label3);
            this.kryptonGroupBox1.Panel.Controls.Add(this.txtAlergias);
            this.kryptonGroupBox1.Panel.Controls.Add(this.label4);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(926, 536);
            this.kryptonGroupBox1.TabIndex = 7;
            this.kryptonGroupBox1.Values.Heading = "Diagnostico";
            // 
            // btnQuitarAdjunto
            // 
            this.btnQuitarAdjunto.Location = new System.Drawing.Point(859, 91);
            this.btnQuitarAdjunto.Name = "btnQuitarAdjunto";
            this.btnQuitarAdjunto.Size = new System.Drawing.Size(39, 36);
            this.btnQuitarAdjunto.TabIndex = 29;
            this.btnQuitarAdjunto.Values.Text = "-";
            this.btnQuitarAdjunto.Click += new System.EventHandler(this.btnQuitarAdjunto_Click);
            // 
            // btnAgregarAdjunto
            // 
            this.btnAgregarAdjunto.Location = new System.Drawing.Point(859, 49);
            this.btnAgregarAdjunto.Name = "btnAgregarAdjunto";
            this.btnAgregarAdjunto.Size = new System.Drawing.Size(39, 36);
            this.btnAgregarAdjunto.TabIndex = 28;
            this.btnAgregarAdjunto.Values.Text = "+";
            this.btnAgregarAdjunto.Click += new System.EventHandler(this.btnAgregarAdjunto_Click);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.Location = new System.Drawing.Point(491, 17);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(138, 24);
            this.kryptonLabel1.TabIndex = 26;
            this.kryptonLabel1.Values.Text = "Archivos Adjuntos:";
            // 
            // txtNombreArchivo
            // 
            this.txtNombreArchivo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreArchivo.Location = new System.Drawing.Point(491, 38);
            this.txtNombreArchivo.Name = "txtNombreArchivo";
            this.txtNombreArchivo.ReadOnly = true;
            this.txtNombreArchivo.Size = new System.Drawing.Size(362, 27);
            this.txtNombreArchivo.TabIndex = 25;
            this.txtNombreArchivo.Visible = false;
            this.txtNombreArchivo.TextChanged += new System.EventHandler(this.txtNombreArchivo_TextChanged);
            this.txtNombreArchivo.Click += new System.EventHandler(this.txtNombreArchivo_Click);
            this.txtNombreArchivo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtNombreArchivo_MouseClick);
            // 
            // lstArchivosAdjuntos
            // 
            this.lstArchivosAdjuntos.Location = new System.Drawing.Point(491, 38);
            this.lstArchivosAdjuntos.Name = "lstArchivosAdjuntos";
            this.lstArchivosAdjuntos.Size = new System.Drawing.Size(362, 101);
            this.lstArchivosAdjuntos.TabIndex = 24;
            this.lstArchivosAdjuntos.SelectedIndexChanged += new System.EventHandler(this.lstArchivosAdjuntos_SelectedIndexChanged);
            this.lstArchivosAdjuntos.Click += new System.EventHandler(this.lstArchivosAdjuntos_Click);
            this.lstArchivosAdjuntos.DoubleClick += new System.EventHandler(this.lstArchivosAdjuntos_DoubleClick);
            this.lstArchivosAdjuntos.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstArchivosAdjuntos_MouseDoubleClick);
            // 
            // txtAltura
            // 
            this.txtAltura.AlwaysActive = false;
            this.txtAltura.DecimalPlaces = 2;
            this.txtAltura.Location = new System.Drawing.Point(236, 91);
            this.txtAltura.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.txtAltura.Name = "txtAltura";
            this.txtAltura.Size = new System.Drawing.Size(213, 32);
            this.txtAltura.StateActive.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txtAltura.StateActive.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtAltura.StateCommon.Border.Color1 = System.Drawing.Color.White;
            this.txtAltura.StateCommon.Border.Color2 = System.Drawing.Color.White;
            this.txtAltura.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtAltura.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.txtAltura.StateCommon.Border.Rounding = 4;
            this.txtAltura.StateCommon.Border.Width = 2;
            this.txtAltura.TabIndex = 23;
            // 
            // txtPeso
            // 
            this.txtPeso.AlwaysActive = false;
            this.txtPeso.DecimalPlaces = 2;
            this.txtPeso.Location = new System.Drawing.Point(22, 91);
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Size = new System.Drawing.Size(213, 32);
            this.txtPeso.StateActive.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txtPeso.StateActive.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtPeso.StateCommon.Border.Color1 = System.Drawing.Color.White;
            this.txtPeso.StateCommon.Border.Color2 = System.Drawing.Color.White;
            this.txtPeso.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtPeso.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.txtPeso.StateCommon.Border.Rounding = 4;
            this.txtPeso.StateCommon.Border.Width = 2;
            this.txtPeso.TabIndex = 22;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // AgregarDiagnostico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 602);
            this.Controls.Add(this.kryptonGroupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAgregar);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AgregarDiagnostico";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Diagnostico";
            this.Load += new System.EventHandler(this.AgregarDiagnostico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbMedico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPaciente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label6;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtDescripcion;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label5;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtAlergias;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblNombreMedico;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbMedico;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbPaciente;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancelar;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAgregar;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown txtAltura;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown txtPeso;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtNombreArchivo;
        private ComponentFactory.Krypton.Toolkit.KryptonListBox lstArchivosAdjuntos;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnQuitarAdjunto;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAgregarAdjunto;
    }
}