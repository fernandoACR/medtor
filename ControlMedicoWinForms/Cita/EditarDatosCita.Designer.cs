namespace ControlMedicoWinForms.Cita
{
    partial class EditarDatosCita
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditarDatosCita));
            this.btnCancelar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnAceptar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.cmbPaciente = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtComentarios = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cmbMedico = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.lblMedico = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cmbTipoCita = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.label3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonNavigator1 = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.kryptonPage1 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.cmbEstatusCita = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.label10 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonPage2 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.kryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.chkNotiWHP = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.chkNotiCorreo = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.chkNotiSMS = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPaciente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMedico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTipoCita)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).BeginInit();
            this.kryptonNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).BeginInit();
            this.kryptonPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEstatusCita)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage2)).BeginInit();
            this.kryptonPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(486, 238);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 32);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Values.Image = global::ControlMedicoWinForms.Properties.Resources.cancelar;
            this.btnCancelar.Values.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(378, 238);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 32);
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Values.Image = global::ControlMedicoWinForms.Properties.Resources.btnGuardar;
            this.btnAceptar.Values.Text = "Editar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // cmbPaciente
            // 
            this.cmbPaciente.AlwaysActive = false;
            this.cmbPaciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaciente.DropDownWidth = 203;
            this.cmbPaciente.Location = new System.Drawing.Point(153, 94);
            this.cmbPaciente.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPaciente.Name = "cmbPaciente";
            this.cmbPaciente.Size = new System.Drawing.Size(433, 31);
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
            this.cmbPaciente.TabIndex = 1;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(27, 96);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(72, 24);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Paciente:";
            // 
            // txtComentarios
            // 
            this.txtComentarios.AlwaysActive = false;
            this.txtComentarios.Location = new System.Drawing.Point(153, 137);
            this.txtComentarios.Margin = new System.Windows.Forms.Padding(4);
            this.txtComentarios.Name = "txtComentarios";
            this.txtComentarios.Size = new System.Drawing.Size(433, 33);
            this.txtComentarios.StateActive.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txtComentarios.StateActive.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtComentarios.StateCommon.Border.Color1 = System.Drawing.Color.White;
            this.txtComentarios.StateCommon.Border.Color2 = System.Drawing.Color.White;
            this.txtComentarios.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtComentarios.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.txtComentarios.StateCommon.Border.Rounding = 4;
            this.txtComentarios.StateCommon.Border.Width = 2;
            this.txtComentarios.TabIndex = 5;
            this.txtComentarios.TextChanged += new System.EventHandler(this.TxtComentarios_TextChanged);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(27, 137);
            this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(101, 24);
            this.kryptonLabel2.TabIndex = 2;
            this.kryptonLabel2.Values.Text = "Comentarios:";
            this.kryptonLabel2.Paint += new System.Windows.Forms.PaintEventHandler(this.KryptonLabel2_Paint);
            // 
            // cmbMedico
            // 
            this.cmbMedico.AlwaysActive = false;
            this.cmbMedico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMedico.DropDownWidth = 270;
            this.cmbMedico.FormattingEnabled = true;
            this.cmbMedico.Location = new System.Drawing.Point(153, 54);
            this.cmbMedico.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbMedico.Name = "cmbMedico";
            this.cmbMedico.Size = new System.Drawing.Size(433, 31);
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
            this.cmbMedico.TabIndex = 2;
            // 
            // lblMedico
            // 
            this.lblMedico.Location = new System.Drawing.Point(27, 57);
            this.lblMedico.Margin = new System.Windows.Forms.Padding(4);
            this.lblMedico.Name = "lblMedico";
            this.lblMedico.Size = new System.Drawing.Size(66, 24);
            this.lblMedico.TabIndex = 6;
            this.lblMedico.Values.Text = "Médico:";
            // 
            // cmbTipoCita
            // 
            this.cmbTipoCita.AlwaysActive = false;
            this.cmbTipoCita.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoCita.DropDownWidth = 271;
            this.cmbTipoCita.FormattingEnabled = true;
            this.cmbTipoCita.Location = new System.Drawing.Point(153, 13);
            this.cmbTipoCita.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbTipoCita.Name = "cmbTipoCita";
            this.cmbTipoCita.Size = new System.Drawing.Size(433, 31);
            this.cmbTipoCita.StateActive.ComboBox.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cmbTipoCita.StateActive.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cmbTipoCita.StateCommon.ComboBox.Border.Color1 = System.Drawing.Color.White;
            this.cmbTipoCita.StateCommon.ComboBox.Border.Color2 = System.Drawing.Color.White;
            this.cmbTipoCita.StateCommon.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cmbTipoCita.StateCommon.ComboBox.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.cmbTipoCita.StateCommon.ComboBox.Border.Rounding = 4;
            this.cmbTipoCita.StateCommon.ComboBox.Border.Width = 2;
            this.cmbTipoCita.TabIndex = 3;
            this.cmbTipoCita.SelectedIndexChanged += new System.EventHandler(this.CmbTipoCita_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(27, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 24);
            this.label3.TabIndex = 24;
            this.label3.Values.Text = "Tipo de Cita:";
            // 
            // kryptonNavigator1
            // 
            this.kryptonNavigator1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonNavigator1.Location = new System.Drawing.Point(0, 0);
            this.kryptonNavigator1.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonNavigator1.Name = "kryptonNavigator1";
            this.kryptonNavigator1.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.kryptonPage1,
            this.kryptonPage2});
            this.kryptonNavigator1.SelectedIndex = 0;
            this.kryptonNavigator1.Size = new System.Drawing.Size(621, 312);
            this.kryptonNavigator1.TabIndex = 26;
            this.kryptonNavigator1.Text = "kryptonNavigator1";
            // 
            // kryptonPage1
            // 
            this.kryptonPage1.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage1.Controls.Add(this.kryptonPanel1);
            this.kryptonPage1.Flags = 65534;
            this.kryptonPage1.LastVisibleSet = true;
            this.kryptonPage1.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonPage1.MinimumSize = new System.Drawing.Size(67, 62);
            this.kryptonPage1.Name = "kryptonPage1";
            this.kryptonPage1.Size = new System.Drawing.Size(619, 281);
            this.kryptonPage1.Text = "Datos Generales";
            this.kryptonPage1.ToolTipTitle = "Page ToolTip";
            this.kryptonPage1.UniqueName = "3E4535E6422141DA2E8B39FC38C1A82E";
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.cmbEstatusCita);
            this.kryptonPanel1.Controls.Add(this.label10);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Controls.Add(this.btnCancelar);
            this.kryptonPanel1.Controls.Add(this.cmbTipoCita);
            this.kryptonPanel1.Controls.Add(this.btnAceptar);
            this.kryptonPanel1.Controls.Add(this.lblMedico);
            this.kryptonPanel1.Controls.Add(this.cmbMedico);
            this.kryptonPanel1.Controls.Add(this.label3);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel1.Controls.Add(this.txtComentarios);
            this.kryptonPanel1.Controls.Add(this.cmbPaciente);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(619, 281);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // cmbEstatusCita
            // 
            this.cmbEstatusCita.AlwaysActive = false;
            this.cmbEstatusCita.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstatusCita.DropDownWidth = 135;
            this.cmbEstatusCita.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEstatusCita.FormattingEnabled = true;
            this.cmbEstatusCita.Location = new System.Drawing.Point(153, 181);
            this.cmbEstatusCita.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.cmbEstatusCita.Name = "cmbEstatusCita";
            this.cmbEstatusCita.Size = new System.Drawing.Size(433, 31);
            this.cmbEstatusCita.StateActive.ComboBox.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cmbEstatusCita.StateActive.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cmbEstatusCita.StateCommon.ComboBox.Border.Color1 = System.Drawing.Color.White;
            this.cmbEstatusCita.StateCommon.ComboBox.Border.Color2 = System.Drawing.Color.White;
            this.cmbEstatusCita.StateCommon.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cmbEstatusCita.StateCommon.ComboBox.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.cmbEstatusCita.StateCommon.ComboBox.Border.Rounding = 4;
            this.cmbEstatusCita.StateCommon.ComboBox.Border.Width = 2;
            this.cmbEstatusCita.TabIndex = 6;
            this.cmbEstatusCita.SelectedIndexChanged += new System.EventHandler(this.CmbEstatusCita_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(27, 185);
            this.label10.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 24);
            this.label10.TabIndex = 26;
            this.label10.Values.Text = "Estatus:";
            this.label10.Paint += new System.Windows.Forms.PaintEventHandler(this.Label10_Paint);
            // 
            // kryptonPage2
            // 
            this.kryptonPage2.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage2.Controls.Add(this.kryptonPanel2);
            this.kryptonPage2.Flags = 65534;
            this.kryptonPage2.LastVisibleSet = true;
            this.kryptonPage2.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonPage2.MinimumSize = new System.Drawing.Size(67, 62);
            this.kryptonPage2.Name = "kryptonPage2";
            this.kryptonPage2.Size = new System.Drawing.Size(619, 338);
            this.kryptonPage2.Text = "Notificaciones";
            this.kryptonPage2.ToolTipTitle = "Page ToolTip";
            this.kryptonPage2.UniqueName = "62D0ECFCAA7C4C9F848C39E464B3D5B1";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.chkNotiWHP);
            this.kryptonPanel2.Controls.Add(this.chkNotiCorreo);
            this.kryptonPanel2.Controls.Add(this.chkNotiSMS);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(619, 338);
            this.kryptonPanel2.TabIndex = 0;
            this.kryptonPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.KryptonPanel2_Paint);
            // 
            // chkNotiWHP
            // 
            this.chkNotiWHP.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNotiWHP.Location = new System.Drawing.Point(59, 146);
            this.chkNotiWHP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkNotiWHP.Name = "chkNotiWHP";
            this.chkNotiWHP.Size = new System.Drawing.Size(184, 24);
            this.chkNotiWHP.TabIndex = 8;
            this.chkNotiWHP.Values.Text = "Notificar por Whatsapp";
            // 
            // chkNotiCorreo
            // 
            this.chkNotiCorreo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNotiCorreo.Location = new System.Drawing.Point(59, 102);
            this.chkNotiCorreo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkNotiCorreo.Name = "chkNotiCorreo";
            this.chkNotiCorreo.Size = new System.Drawing.Size(239, 24);
            this.chkNotiCorreo.TabIndex = 6;
            this.chkNotiCorreo.Values.Text = "Notificar por correo electronico";
            // 
            // chkNotiSMS
            // 
            this.chkNotiSMS.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNotiSMS.Location = new System.Drawing.Point(395, 102);
            this.chkNotiSMS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkNotiSMS.Name = "chkNotiSMS";
            this.chkNotiSMS.Size = new System.Drawing.Size(145, 24);
            this.chkNotiSMS.TabIndex = 7;
            this.chkNotiSMS.Values.Text = "Notificar por SMS";
            // 
            // EditarDatosCita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 312);
            this.Controls.Add(this.kryptonNavigator1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditarDatosCita";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Datos de Cita";
            this.Load += new System.EventHandler(this.EditarDatosCita_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbPaciente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMedico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTipoCita)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).EndInit();
            this.kryptonNavigator1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).EndInit();
            this.kryptonPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEstatusCita)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage2)).EndInit();
            this.kryptonPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancelar;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAceptar;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbPaciente;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtComentarios;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbMedico;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblMedico;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbTipoCita;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label3;
        private ComponentFactory.Krypton.Navigator.KryptonNavigator kryptonNavigator1;
        private ComponentFactory.Krypton.Navigator.KryptonPage kryptonPage1;
        private ComponentFactory.Krypton.Navigator.KryptonPage kryptonPage2;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbEstatusCita;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label10;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkNotiWHP;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkNotiCorreo;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkNotiSMS;
    }
}