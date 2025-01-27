namespace ControlMedicoWinForms.Orden
{
    partial class AgregarOrden
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarOrden));
            this.lblMedicoEntrega = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cmbMedicoEntrega = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.label1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cmbPaciente = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.cmbDiagnostico = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.label10 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cmbEspecimen = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.label9 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtObservaciones = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.cmbEstatus = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.label8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnAgregar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCancelar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtMovilRecepcion = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label11 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtCorreoRecepcion = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cmbCliente = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.txtPersonaRecibe = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cmbMedicoRecibe = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.kryptonGroupBox2 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.kryptonGroupBox3 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.btnQuitarAdjunto = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnAgregarAdjunto = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtNombreArchivo = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lstArchivosAdjuntos = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
            this.txtPrecio = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMedicoEntrega)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPaciente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDiagnostico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEspecimen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEstatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMedicoRecibe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).BeginInit();
            this.kryptonGroupBox2.Panel.SuspendLayout();
            this.kryptonGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox3.Panel)).BeginInit();
            this.kryptonGroupBox3.Panel.SuspendLayout();
            this.kryptonGroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMedicoEntrega
            // 
            this.lblMedicoEntrega.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedicoEntrega.Location = new System.Drawing.Point(546, 16);
            this.lblMedicoEntrega.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMedicoEntrega.Name = "lblMedicoEntrega";
            this.lblMedicoEntrega.Size = new System.Drawing.Size(235, 24);
            this.lblMedicoEntrega.TabIndex = 1;
            this.lblMedicoEntrega.Values.Text = "Nombre del Médico que Entrega";
            // 
            // cmbMedicoEntrega
            // 
            this.cmbMedicoEntrega.AlwaysActive = false;
            this.cmbMedicoEntrega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMedicoEntrega.DropDownWidth = 427;
            this.cmbMedicoEntrega.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMedicoEntrega.FormattingEnabled = true;
            this.cmbMedicoEntrega.Location = new System.Drawing.Point(551, 42);
            this.cmbMedicoEntrega.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMedicoEntrega.Name = "cmbMedicoEntrega";
            this.cmbMedicoEntrega.Size = new System.Drawing.Size(427, 31);
            this.cmbMedicoEntrega.StateActive.ComboBox.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cmbMedicoEntrega.StateActive.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cmbMedicoEntrega.StateCommon.ComboBox.Border.Color1 = System.Drawing.Color.White;
            this.cmbMedicoEntrega.StateCommon.ComboBox.Border.Color2 = System.Drawing.Color.White;
            this.cmbMedicoEntrega.StateCommon.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cmbMedicoEntrega.StateCommon.ComboBox.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.cmbMedicoEntrega.StateCommon.ComboBox.Border.Rounding = 4;
            this.cmbMedicoEntrega.StateCommon.ComboBox.Border.Width = 2;
            this.cmbMedicoEntrega.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 24);
            this.label1.TabIndex = 1;
            this.label1.Values.Text = "Nombre del Paciente";
            // 
            // cmbPaciente
            // 
            this.cmbPaciente.AlwaysActive = false;
            this.cmbPaciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaciente.DropDownWidth = 427;
            this.cmbPaciente.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPaciente.FormattingEnabled = true;
            this.cmbPaciente.Location = new System.Drawing.Point(14, 42);
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
            this.cmbPaciente.SelectedIndexChanged += new System.EventHandler(this.cmbPaciente_SelectedIndexChanged);
            // 
            // cmbDiagnostico
            // 
            this.cmbDiagnostico.AlwaysActive = false;
            this.cmbDiagnostico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDiagnostico.DropDownWidth = 429;
            this.cmbDiagnostico.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDiagnostico.FormattingEnabled = true;
            this.cmbDiagnostico.Location = new System.Drawing.Point(14, 152);
            this.cmbDiagnostico.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDiagnostico.Name = "cmbDiagnostico";
            this.cmbDiagnostico.Size = new System.Drawing.Size(427, 31);
            this.cmbDiagnostico.StateActive.ComboBox.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cmbDiagnostico.StateActive.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cmbDiagnostico.StateCommon.ComboBox.Border.Color1 = System.Drawing.Color.White;
            this.cmbDiagnostico.StateCommon.ComboBox.Border.Color2 = System.Drawing.Color.White;
            this.cmbDiagnostico.StateCommon.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cmbDiagnostico.StateCommon.ComboBox.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.cmbDiagnostico.StateCommon.ComboBox.Border.Rounding = 4;
            this.cmbDiagnostico.StateCommon.ComboBox.Border.Width = 2;
            this.cmbDiagnostico.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(14, 71);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 24);
            this.label10.TabIndex = 18;
            this.label10.Values.Text = "Precio";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 128);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 24);
            this.label3.TabIndex = 2;
            this.label3.Values.Text = "Diagnostico";
            // 
            // cmbEspecimen
            // 
            this.cmbEspecimen.AlwaysActive = false;
            this.cmbEspecimen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEspecimen.DropDownWidth = 427;
            this.cmbEspecimen.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEspecimen.FormattingEnabled = true;
            this.cmbEspecimen.Location = new System.Drawing.Point(14, 30);
            this.cmbEspecimen.Margin = new System.Windows.Forms.Padding(4);
            this.cmbEspecimen.Name = "cmbEspecimen";
            this.cmbEspecimen.Size = new System.Drawing.Size(427, 31);
            this.cmbEspecimen.StateActive.ComboBox.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cmbEspecimen.StateActive.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cmbEspecimen.StateCommon.ComboBox.Border.Color1 = System.Drawing.Color.White;
            this.cmbEspecimen.StateCommon.ComboBox.Border.Color2 = System.Drawing.Color.White;
            this.cmbEspecimen.StateCommon.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cmbEspecimen.StateCommon.ComboBox.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.cmbEspecimen.StateCommon.ComboBox.Border.Rounding = 4;
            this.cmbEspecimen.StateCommon.ComboBox.Border.Width = 2;
            this.cmbEspecimen.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 199);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 24);
            this.label9.TabIndex = 14;
            this.label9.Values.Text = "Observaciones:";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.AlwaysActive = false;
            this.txtObservaciones.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservaciones.Location = new System.Drawing.Point(14, 221);
            this.txtObservaciones.Margin = new System.Windows.Forms.Padding(4);
            this.txtObservaciones.MaxLength = 200;
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(964, 112);
            this.txtObservaciones.StateActive.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txtObservaciones.StateActive.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtObservaciones.StateCommon.Border.Color1 = System.Drawing.Color.White;
            this.txtObservaciones.StateCommon.Border.Color2 = System.Drawing.Color.White;
            this.txtObservaciones.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtObservaciones.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.txtObservaciones.StateCommon.Border.Rounding = 4;
            this.txtObservaciones.StateCommon.Border.Width = 2;
            this.txtObservaciones.TabIndex = 13;
            // 
            // cmbEstatus
            // 
            this.cmbEstatus.AlwaysActive = false;
            this.cmbEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstatus.DropDownWidth = 160;
            this.cmbEstatus.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEstatus.FormattingEnabled = true;
            this.cmbEstatus.Location = new System.Drawing.Point(254, 94);
            this.cmbEstatus.Margin = new System.Windows.Forms.Padding(4);
            this.cmbEstatus.Name = "cmbEstatus";
            this.cmbEstatus.Size = new System.Drawing.Size(187, 31);
            this.cmbEstatus.StateActive.ComboBox.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cmbEstatus.StateActive.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cmbEstatus.StateCommon.ComboBox.Border.Color1 = System.Drawing.Color.White;
            this.cmbEstatus.StateCommon.ComboBox.Border.Color2 = System.Drawing.Color.White;
            this.cmbEstatus.StateCommon.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cmbEstatus.StateCommon.ComboBox.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.cmbEstatus.StateCommon.ComboBox.Border.Rounding = 4;
            this.cmbEstatus.StateCommon.ComboBox.Border.Width = 2;
            this.cmbEstatus.TabIndex = 12;
            this.cmbEstatus.Visible = false;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(254, 70);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 24);
            this.label8.TabIndex = 11;
            this.label8.Values.Text = "Estatus";
            this.label8.Visible = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 6);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 24);
            this.label4.TabIndex = 3;
            this.label4.Values.Text = "Especimen";
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.LightGray;
            this.btnAgregar.Location = new System.Drawing.Point(770, 704);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(100, 32);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Values.Image = global::ControlMedicoWinForms.Properties.Resources.btnGuardar;
            this.btnAgregar.Values.Text = "Guardar";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.LightGray;
            this.btnCancelar.Location = new System.Drawing.Point(910, 704);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 32);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Values.Image = global::ControlMedicoWinForms.Properties.Resources.cancelar;
            this.btnCancelar.Values.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtMovilRecepcion
            // 
            this.txtMovilRecepcion.AlwaysActive = false;
            this.txtMovilRecepcion.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMovilRecepcion.Location = new System.Drawing.Point(776, 106);
            this.txtMovilRecepcion.Margin = new System.Windows.Forms.Padding(4);
            this.txtMovilRecepcion.MaxLength = 200;
            this.txtMovilRecepcion.Name = "txtMovilRecepcion";
            this.txtMovilRecepcion.Size = new System.Drawing.Size(202, 33);
            this.txtMovilRecepcion.StateActive.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txtMovilRecepcion.StateActive.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtMovilRecepcion.StateCommon.Border.Color1 = System.Drawing.Color.White;
            this.txtMovilRecepcion.StateCommon.Border.Color2 = System.Drawing.Color.White;
            this.txtMovilRecepcion.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtMovilRecepcion.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.txtMovilRecepcion.StateCommon.Border.Rounding = 4;
            this.txtMovilRecepcion.StateCommon.Border.Width = 2;
            this.txtMovilRecepcion.TabIndex = 26;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(773, 84);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 24);
            this.label11.TabIndex = 25;
            this.label11.Values.Text = "Teléfono Móvil";
            // 
            // txtCorreoRecepcion
            // 
            this.txtCorreoRecepcion.AlwaysActive = false;
            this.txtCorreoRecepcion.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreoRecepcion.Location = new System.Drawing.Point(549, 106);
            this.txtCorreoRecepcion.Margin = new System.Windows.Forms.Padding(4);
            this.txtCorreoRecepcion.MaxLength = 200;
            this.txtCorreoRecepcion.Name = "txtCorreoRecepcion";
            this.txtCorreoRecepcion.Size = new System.Drawing.Size(214, 33);
            this.txtCorreoRecepcion.StateActive.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txtCorreoRecepcion.StateActive.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtCorreoRecepcion.StateCommon.Border.Color1 = System.Drawing.Color.White;
            this.txtCorreoRecepcion.StateCommon.Border.Color2 = System.Drawing.Color.White;
            this.txtCorreoRecepcion.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtCorreoRecepcion.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.txtCorreoRecepcion.StateCommon.Border.Rounding = 4;
            this.txtCorreoRecepcion.StateCommon.Border.Width = 2;
            this.txtCorreoRecepcion.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(546, 84);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 24);
            this.label5.TabIndex = 23;
            this.label5.Values.Text = "Correo ";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 24);
            this.label2.TabIndex = 22;
            this.label2.Values.Text = "Nombre de Institución:";
            // 
            // cmbCliente
            // 
            this.cmbCliente.AlwaysActive = false;
            this.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCliente.DropDownWidth = 427;
            this.cmbCliente.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(14, 35);
            this.cmbCliente.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(427, 31);
            this.cmbCliente.StateActive.ComboBox.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cmbCliente.StateActive.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cmbCliente.StateCommon.ComboBox.Border.Color1 = System.Drawing.Color.White;
            this.cmbCliente.StateCommon.ComboBox.Border.Color2 = System.Drawing.Color.White;
            this.cmbCliente.StateCommon.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cmbCliente.StateCommon.ComboBox.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.cmbCliente.StateCommon.ComboBox.Border.Rounding = 4;
            this.cmbCliente.StateCommon.ComboBox.Border.Width = 2;
            this.cmbCliente.TabIndex = 21;
            this.cmbCliente.SelectedIndexChanged += new System.EventHandler(this.cmbCliente_SelectedIndexChanged);
            // 
            // txtPersonaRecibe
            // 
            this.txtPersonaRecibe.AlwaysActive = false;
            this.txtPersonaRecibe.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPersonaRecibe.Location = new System.Drawing.Point(549, 35);
            this.txtPersonaRecibe.Margin = new System.Windows.Forms.Padding(4);
            this.txtPersonaRecibe.MaxLength = 200;
            this.txtPersonaRecibe.Name = "txtPersonaRecibe";
            this.txtPersonaRecibe.Size = new System.Drawing.Size(429, 33);
            this.txtPersonaRecibe.StateActive.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txtPersonaRecibe.StateActive.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtPersonaRecibe.StateCommon.Border.Color1 = System.Drawing.Color.White;
            this.txtPersonaRecibe.StateCommon.Border.Color2 = System.Drawing.Color.White;
            this.txtPersonaRecibe.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtPersonaRecibe.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.txtPersonaRecibe.StateCommon.Border.Rounding = 4;
            this.txtPersonaRecibe.StateCommon.Border.Width = 2;
            this.txtPersonaRecibe.TabIndex = 20;
            this.txtPersonaRecibe.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPersonaRecibe_KeyUp);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(546, 9);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(464, 24);
            this.label7.TabIndex = 3;
            this.label7.Values.Text = "Nombre de la persona que recibe (Si el medico no esta registrado)";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 84);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(148, 24);
            this.label6.TabIndex = 1;
            this.label6.Values.Text = "Nombre del Médico";
            // 
            // cmbMedicoRecibe
            // 
            this.cmbMedicoRecibe.AlwaysActive = false;
            this.cmbMedicoRecibe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMedicoRecibe.DropDownWidth = 427;
            this.cmbMedicoRecibe.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMedicoRecibe.FormattingEnabled = true;
            this.cmbMedicoRecibe.Location = new System.Drawing.Point(14, 106);
            this.cmbMedicoRecibe.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMedicoRecibe.Name = "cmbMedicoRecibe";
            this.cmbMedicoRecibe.Size = new System.Drawing.Size(427, 31);
            this.cmbMedicoRecibe.StateActive.ComboBox.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cmbMedicoRecibe.StateActive.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cmbMedicoRecibe.StateCommon.ComboBox.Border.Color1 = System.Drawing.Color.White;
            this.cmbMedicoRecibe.StateCommon.ComboBox.Border.Color2 = System.Drawing.Color.White;
            this.cmbMedicoRecibe.StateCommon.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cmbMedicoRecibe.StateCommon.ComboBox.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.cmbMedicoRecibe.StateCommon.ComboBox.Border.Rounding = 4;
            this.cmbMedicoRecibe.StateCommon.ComboBox.Border.Width = 2;
            this.cmbMedicoRecibe.TabIndex = 0;
            this.cmbMedicoRecibe.SelectedIndexChanged += new System.EventHandler(this.cmbMedicoRecibe_SelectedIndexChanged);
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.CaptionStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonGroupBox1.Location = new System.Drawing.Point(14, 12);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.lblMedicoEntrega);
            this.kryptonGroupBox1.Panel.Controls.Add(this.cmbMedicoEntrega);
            this.kryptonGroupBox1.Panel.Controls.Add(this.cmbPaciente);
            this.kryptonGroupBox1.Panel.Controls.Add(this.label1);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(996, 116);
            this.kryptonGroupBox1.TabIndex = 5;
            this.kryptonGroupBox1.Values.Heading = "Datos Generales";
            // 
            // kryptonGroupBox2
            // 
            this.kryptonGroupBox2.CaptionStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonGroupBox2.Location = new System.Drawing.Point(14, 134);
            this.kryptonGroupBox2.Name = "kryptonGroupBox2";
            // 
            // kryptonGroupBox2.Panel
            // 
            this.kryptonGroupBox2.Panel.Controls.Add(this.txtMovilRecepcion);
            this.kryptonGroupBox2.Panel.Controls.Add(this.txtPersonaRecibe);
            this.kryptonGroupBox2.Panel.Controls.Add(this.label11);
            this.kryptonGroupBox2.Panel.Controls.Add(this.cmbMedicoRecibe);
            this.kryptonGroupBox2.Panel.Controls.Add(this.txtCorreoRecepcion);
            this.kryptonGroupBox2.Panel.Controls.Add(this.label6);
            this.kryptonGroupBox2.Panel.Controls.Add(this.label5);
            this.kryptonGroupBox2.Panel.Controls.Add(this.label7);
            this.kryptonGroupBox2.Panel.Controls.Add(this.label2);
            this.kryptonGroupBox2.Panel.Controls.Add(this.cmbCliente);
            this.kryptonGroupBox2.Size = new System.Drawing.Size(996, 184);
            this.kryptonGroupBox2.TabIndex = 6;
            this.kryptonGroupBox2.Values.Heading = "Datos Recepción";
            // 
            // kryptonGroupBox3
            // 
            this.kryptonGroupBox3.CaptionStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonGroupBox3.Location = new System.Drawing.Point(14, 324);
            this.kryptonGroupBox3.Name = "kryptonGroupBox3";
            // 
            // kryptonGroupBox3.Panel
            // 
            this.kryptonGroupBox3.Panel.Controls.Add(this.btnQuitarAdjunto);
            this.kryptonGroupBox3.Panel.Controls.Add(this.btnAgregarAdjunto);
            this.kryptonGroupBox3.Panel.Controls.Add(this.kryptonLabel1);
            this.kryptonGroupBox3.Panel.Controls.Add(this.txtNombreArchivo);
            this.kryptonGroupBox3.Panel.Controls.Add(this.lstArchivosAdjuntos);
            this.kryptonGroupBox3.Panel.Controls.Add(this.txtPrecio);
            this.kryptonGroupBox3.Panel.Controls.Add(this.cmbDiagnostico);
            this.kryptonGroupBox3.Panel.Controls.Add(this.txtObservaciones);
            this.kryptonGroupBox3.Panel.Controls.Add(this.label4);
            this.kryptonGroupBox3.Panel.Controls.Add(this.label10);
            this.kryptonGroupBox3.Panel.Controls.Add(this.label8);
            this.kryptonGroupBox3.Panel.Controls.Add(this.label3);
            this.kryptonGroupBox3.Panel.Controls.Add(this.cmbEstatus);
            this.kryptonGroupBox3.Panel.Controls.Add(this.cmbEspecimen);
            this.kryptonGroupBox3.Panel.Controls.Add(this.label9);
            this.kryptonGroupBox3.Size = new System.Drawing.Size(996, 373);
            this.kryptonGroupBox3.TabIndex = 7;
            this.kryptonGroupBox3.Values.Heading = "Orden";
            // 
            // btnQuitarAdjunto
            // 
            this.btnQuitarAdjunto.Location = new System.Drawing.Point(939, 112);
            this.btnQuitarAdjunto.Name = "btnQuitarAdjunto";
            this.btnQuitarAdjunto.Size = new System.Drawing.Size(39, 36);
            this.btnQuitarAdjunto.TabIndex = 34;
            this.btnQuitarAdjunto.Values.Text = "-";
            this.btnQuitarAdjunto.Click += new System.EventHandler(this.btnQuitarAdjunto_Click);
            // 
            // btnAgregarAdjunto
            // 
            this.btnAgregarAdjunto.Location = new System.Drawing.Point(939, 70);
            this.btnAgregarAdjunto.Name = "btnAgregarAdjunto";
            this.btnAgregarAdjunto.Size = new System.Drawing.Size(39, 36);
            this.btnAgregarAdjunto.TabIndex = 33;
            this.btnAgregarAdjunto.Values.Text = "+";
            this.btnAgregarAdjunto.Click += new System.EventHandler(this.btnAgregarAdjunto_Click);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.Location = new System.Drawing.Point(549, 6);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(138, 24);
            this.kryptonLabel1.TabIndex = 32;
            this.kryptonLabel1.Values.Text = "Archivos Adjuntos:";
            // 
            // txtNombreArchivo
            // 
            this.txtNombreArchivo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreArchivo.Location = new System.Drawing.Point(549, 27);
            this.txtNombreArchivo.Name = "txtNombreArchivo";
            this.txtNombreArchivo.ReadOnly = true;
            this.txtNombreArchivo.Size = new System.Drawing.Size(362, 27);
            this.txtNombreArchivo.TabIndex = 31;
            this.txtNombreArchivo.Visible = false;
            // 
            // lstArchivosAdjuntos
            // 
            this.lstArchivosAdjuntos.Location = new System.Drawing.Point(549, 27);
            this.lstArchivosAdjuntos.Name = "lstArchivosAdjuntos";
            this.lstArchivosAdjuntos.Size = new System.Drawing.Size(362, 152);
            this.lstArchivosAdjuntos.TabIndex = 30;
            this.lstArchivosAdjuntos.DoubleClick += new System.EventHandler(this.lstArchivosAdjuntos_DoubleClick);
            // 
            // txtPrecio
            // 
            this.txtPrecio.AlwaysActive = false;
            this.txtPrecio.DecimalPlaces = 2;
            this.txtPrecio.Location = new System.Drawing.Point(14, 94);
            this.txtPrecio.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(198, 32);
            this.txtPrecio.StateActive.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txtPrecio.StateActive.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtPrecio.StateCommon.Border.Color1 = System.Drawing.Color.White;
            this.txtPrecio.StateCommon.Border.Color2 = System.Drawing.Color.White;
            this.txtPrecio.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtPrecio.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.txtPrecio.StateCommon.Border.Rounding = 4;
            this.txtPrecio.StateCommon.Border.Width = 2;
            this.txtPrecio.TabIndex = 21;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // AgregarOrden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1082, 749);
            this.Controls.Add(this.kryptonGroupBox3);
            this.Controls.Add(this.kryptonGroupBox2);
            this.Controls.Add(this.kryptonGroupBox1);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnCancelar);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AgregarOrden";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Orden";
            this.Load += new System.EventHandler(this.AgregarOrden_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbMedicoEntrega)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPaciente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDiagnostico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEspecimen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEstatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMedicoRecibe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).EndInit();
            this.kryptonGroupBox2.Panel.ResumeLayout(false);
            this.kryptonGroupBox2.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).EndInit();
            this.kryptonGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox3.Panel)).EndInit();
            this.kryptonGroupBox3.Panel.ResumeLayout(false);
            this.kryptonGroupBox3.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox3)).EndInit();
            this.kryptonGroupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbPaciente;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblMedicoEntrega;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbMedicoEntrega;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label9;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtObservaciones;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbEstatus;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label8;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label3;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAgregar;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancelar;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label10;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbEspecimen;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label6;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbMedicoRecibe;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label7;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtPersonaRecibe;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbDiagnostico;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtMovilRecepcion;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label11;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtCorreoRecepcion;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label2;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbCliente;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox3;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown txtPrecio;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnQuitarAdjunto;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAgregarAdjunto;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtNombreArchivo;
        private ComponentFactory.Krypton.Toolkit.KryptonListBox lstArchivosAdjuntos;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}