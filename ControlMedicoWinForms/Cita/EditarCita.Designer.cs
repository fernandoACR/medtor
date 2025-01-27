namespace ControlMedicoWinForms.Cita
{
    partial class EditarCita
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
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange1 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange2 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange3 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange4 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange5 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            this.monthView1 = new System.Windows.Forms.Calendar.MonthView();
            this.calendar1 = new System.Windows.Forms.Calendar.Calendar();
            this.cmbTipoCita = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.label2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label10 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cmbEstatusCita = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.label9 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtComentarios = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lblMedico = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cmbMedico = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.cmbPaciente = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.label7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cmbNotiHoraSMS = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.label8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cmbNotiDiasSMS = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.label6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cmbNotiHorasCorreo = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.label4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cmbDiasNotiCorreo = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.chkNotiSMS = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.chkNotiCorreo = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.btnCancelar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnAgregar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonNavigator1 = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.kryptonPage1 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.kryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.kryptonPage2 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.kryptonGroupBox2 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTipoCita)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEstatusCita)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMedico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPaciente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNotiHoraSMS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNotiDiasSMS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNotiHorasCorreo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDiasNotiCorreo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).BeginInit();
            this.kryptonNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).BeginInit();
            this.kryptonPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage2)).BeginInit();
            this.kryptonPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).BeginInit();
            this.kryptonGroupBox2.Panel.SuspendLayout();
            this.kryptonGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // monthView1
            // 
            this.monthView1.ArrowsColor = System.Drawing.SystemColors.Window;
            this.monthView1.ArrowsSelectedColor = System.Drawing.Color.Gold;
            this.monthView1.DayBackgroundColor = System.Drawing.Color.Empty;
            this.monthView1.DayGrayedText = System.Drawing.SystemColors.GrayText;
            this.monthView1.DaySelectedBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.monthView1.DaySelectedColor = System.Drawing.SystemColors.WindowText;
            this.monthView1.DaySelectedTextColor = System.Drawing.SystemColors.HighlightText;
            this.monthView1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.monthView1.ItemPadding = new System.Windows.Forms.Padding(2);
            this.monthView1.Location = new System.Drawing.Point(330, 20);
            this.monthView1.MonthTitleColor = System.Drawing.SystemColors.ActiveCaption;
            this.monthView1.MonthTitleColorInactive = System.Drawing.SystemColors.InactiveCaption;
            this.monthView1.MonthTitleTextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.monthView1.MonthTitleTextColorInactive = System.Drawing.SystemColors.InactiveCaptionText;
            this.monthView1.Name = "monthView1";
            this.monthView1.Size = new System.Drawing.Size(254, 460);
            this.monthView1.TabIndex = 26;
            this.monthView1.Text = "monthView1";
            this.monthView1.TodayBorderColor = System.Drawing.Color.Maroon;
            this.monthView1.SelectionChanged += new System.EventHandler(this.monthView1_SelectionChanged);
            // 
            // calendar1
            // 
            this.calendar1.Font = new System.Drawing.Font("Segoe UI", 9F);
            calendarHighlightRange1.DayOfWeek = System.DayOfWeek.Monday;
            calendarHighlightRange1.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange1.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange2.DayOfWeek = System.DayOfWeek.Tuesday;
            calendarHighlightRange2.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange2.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange3.DayOfWeek = System.DayOfWeek.Wednesday;
            calendarHighlightRange3.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange3.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange4.DayOfWeek = System.DayOfWeek.Thursday;
            calendarHighlightRange4.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange4.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange5.DayOfWeek = System.DayOfWeek.Friday;
            calendarHighlightRange5.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange5.StartTime = System.TimeSpan.Parse("08:00:00");
            this.calendar1.HighlightRanges = new System.Windows.Forms.Calendar.CalendarHighlightRange[] {
        calendarHighlightRange1,
        calendarHighlightRange2,
        calendarHighlightRange3,
        calendarHighlightRange4,
        calendarHighlightRange5};
            this.calendar1.Location = new System.Drawing.Point(603, 18);
            this.calendar1.Name = "calendar1";
            this.calendar1.Size = new System.Drawing.Size(634, 460);
            this.calendar1.TabIndex = 28;
            this.calendar1.Text = "calendar1";
            this.calendar1.LoadItems += new System.Windows.Forms.Calendar.Calendar.CalendarLoadEventHandler(this.calendar1_LoadItems);
            this.calendar1.ItemCreated += new System.Windows.Forms.Calendar.Calendar.CalendarItemCancelEventHandler(this.calendar1_ItemCreated);
            this.calendar1.ItemDeleting += new System.Windows.Forms.Calendar.Calendar.CalendarItemCancelEventHandler(this.calendar1_ItemDeleting);
            this.calendar1.ItemDatesChanged += new System.Windows.Forms.Calendar.Calendar.CalendarItemEventHandler(this.calendar1_ItemDatesChanged);
            this.calendar1.ItemClick += new System.Windows.Forms.Calendar.Calendar.CalendarItemEventHandler(this.calendar1_ItemClick);
            this.calendar1.ItemDoubleClick += new System.Windows.Forms.Calendar.Calendar.CalendarItemEventHandler(this.calendar1_ItemDoubleClick);
            this.calendar1.Resize += new System.EventHandler(this.calendar1_Resize);
            // 
            // cmbTipoCita
            // 
            this.cmbTipoCita.AlwaysActive = false;
            this.cmbTipoCita.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoCita.DropDownWidth = 270;
            this.cmbTipoCita.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoCita.FormattingEnabled = true;
            this.cmbTipoCita.Location = new System.Drawing.Point(23, 166);
            this.cmbTipoCita.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cmbTipoCita.Name = "cmbTipoCita";
            this.cmbTipoCita.Size = new System.Drawing.Size(270, 27);
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
            this.cmbTipoCita.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 146);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 24;
            this.label2.Values.Text = "Tipo de Cita:";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(19, 364);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 20);
            this.label10.TabIndex = 16;
            this.label10.Values.Text = "Estatus";
            // 
            // cmbEstatusCita
            // 
            this.cmbEstatusCita.AlwaysActive = false;
            this.cmbEstatusCita.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstatusCita.DropDownWidth = 135;
            this.cmbEstatusCita.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEstatusCita.FormattingEnabled = true;
            this.cmbEstatusCita.Location = new System.Drawing.Point(24, 386);
            this.cmbEstatusCita.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cmbEstatusCita.Name = "cmbEstatusCita";
            this.cmbEstatusCita.Size = new System.Drawing.Size(135, 27);
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
            this.cmbEstatusCita.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(20, 210);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 20);
            this.label9.TabIndex = 14;
            this.label9.Values.Text = "Comentarios:";
            // 
            // txtComentarios
            // 
            this.txtComentarios.AlwaysActive = false;
            this.txtComentarios.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComentarios.Location = new System.Drawing.Point(21, 234);
            this.txtComentarios.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtComentarios.MaxLength = 200;
            this.txtComentarios.Multiline = true;
            this.txtComentarios.Name = "txtComentarios";
            this.txtComentarios.Size = new System.Drawing.Size(270, 112);
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
            this.txtComentarios.TabIndex = 13;
            this.txtComentarios.TextChanged += new System.EventHandler(this.txtComentarios_TextChanged);
            // 
            // lblMedico
            // 
            this.lblMedico.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedico.Location = new System.Drawing.Point(17, 79);
            this.lblMedico.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMedico.Name = "lblMedico";
            this.lblMedico.Size = new System.Drawing.Size(120, 20);
            this.lblMedico.TabIndex = 1;
            this.lblMedico.Values.Text = "Nombre del Médico";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 20);
            this.label1.TabIndex = 1;
            this.label1.Values.Text = "Nombre del Paciente";
            // 
            // cmbMedico
            // 
            this.cmbMedico.AlwaysActive = false;
            this.cmbMedico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMedico.DropDownWidth = 270;
            this.cmbMedico.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMedico.FormattingEnabled = true;
            this.cmbMedico.Location = new System.Drawing.Point(21, 101);
            this.cmbMedico.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cmbMedico.Name = "cmbMedico";
            this.cmbMedico.Size = new System.Drawing.Size(270, 27);
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
            // cmbPaciente
            // 
            this.cmbPaciente.AlwaysActive = false;
            this.cmbPaciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaciente.DropDownWidth = 270;
            this.cmbPaciente.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPaciente.FormattingEnabled = true;
            this.cmbPaciente.Location = new System.Drawing.Point(23, 34);
            this.cmbPaciente.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cmbPaciente.Name = "cmbPaciente";
            this.cmbPaciente.Size = new System.Drawing.Size(270, 27);
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
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(292, 120);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 20);
            this.label7.TabIndex = 9;
            this.label7.Values.Text = "Hora";
            // 
            // cmbNotiHoraSMS
            // 
            this.cmbNotiHoraSMS.AlwaysActive = false;
            this.cmbNotiHoraSMS.DropDownWidth = 227;
            this.cmbNotiHoraSMS.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNotiHoraSMS.FormattingEnabled = true;
            this.cmbNotiHoraSMS.Location = new System.Drawing.Point(296, 142);
            this.cmbNotiHoraSMS.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cmbNotiHoraSMS.Name = "cmbNotiHoraSMS";
            this.cmbNotiHoraSMS.Size = new System.Drawing.Size(227, 27);
            this.cmbNotiHoraSMS.StateActive.ComboBox.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cmbNotiHoraSMS.StateActive.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cmbNotiHoraSMS.StateCommon.ComboBox.Border.Color1 = System.Drawing.Color.White;
            this.cmbNotiHoraSMS.StateCommon.ComboBox.Border.Color2 = System.Drawing.Color.White;
            this.cmbNotiHoraSMS.StateCommon.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cmbNotiHoraSMS.StateCommon.ComboBox.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.cmbNotiHoraSMS.StateCommon.ComboBox.Border.Rounding = 4;
            this.cmbNotiHoraSMS.StateCommon.ComboBox.Border.Width = 2;
            this.cmbNotiHoraSMS.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(292, 50);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 20);
            this.label8.TabIndex = 7;
            this.label8.Values.Text = "Dias";
            // 
            // cmbNotiDiasSMS
            // 
            this.cmbNotiDiasSMS.AlwaysActive = false;
            this.cmbNotiDiasSMS.DropDownWidth = 227;
            this.cmbNotiDiasSMS.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNotiDiasSMS.FormattingEnabled = true;
            this.cmbNotiDiasSMS.Location = new System.Drawing.Point(296, 73);
            this.cmbNotiDiasSMS.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cmbNotiDiasSMS.Name = "cmbNotiDiasSMS";
            this.cmbNotiDiasSMS.Size = new System.Drawing.Size(227, 27);
            this.cmbNotiDiasSMS.StateActive.ComboBox.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cmbNotiDiasSMS.StateActive.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cmbNotiDiasSMS.StateCommon.ComboBox.Border.Color1 = System.Drawing.Color.White;
            this.cmbNotiDiasSMS.StateCommon.ComboBox.Border.Color2 = System.Drawing.Color.White;
            this.cmbNotiDiasSMS.StateCommon.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cmbNotiDiasSMS.StateCommon.ComboBox.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.cmbNotiDiasSMS.StateCommon.ComboBox.Border.Rounding = 4;
            this.cmbNotiDiasSMS.StateCommon.ComboBox.Border.Width = 2;
            this.cmbNotiDiasSMS.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 120);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 20);
            this.label6.TabIndex = 5;
            this.label6.Values.Text = "Hora";
            // 
            // cmbNotiHorasCorreo
            // 
            this.cmbNotiHorasCorreo.AlwaysActive = false;
            this.cmbNotiHorasCorreo.DropDownWidth = 227;
            this.cmbNotiHorasCorreo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNotiHorasCorreo.FormattingEnabled = true;
            this.cmbNotiHorasCorreo.Location = new System.Drawing.Point(12, 142);
            this.cmbNotiHorasCorreo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cmbNotiHorasCorreo.Name = "cmbNotiHorasCorreo";
            this.cmbNotiHorasCorreo.Size = new System.Drawing.Size(227, 27);
            this.cmbNotiHorasCorreo.StateActive.ComboBox.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cmbNotiHorasCorreo.StateActive.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cmbNotiHorasCorreo.StateCommon.ComboBox.Border.Color1 = System.Drawing.Color.White;
            this.cmbNotiHorasCorreo.StateCommon.ComboBox.Border.Color2 = System.Drawing.Color.White;
            this.cmbNotiHorasCorreo.StateCommon.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cmbNotiHorasCorreo.StateCommon.ComboBox.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.cmbNotiHorasCorreo.StateCommon.ComboBox.Border.Rounding = 4;
            this.cmbNotiHorasCorreo.StateCommon.ComboBox.Border.Width = 2;
            this.cmbNotiHorasCorreo.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 50);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 20);
            this.label4.TabIndex = 3;
            this.label4.Values.Text = "Dias";
            // 
            // cmbDiasNotiCorreo
            // 
            this.cmbDiasNotiCorreo.AlwaysActive = false;
            this.cmbDiasNotiCorreo.DropDownWidth = 227;
            this.cmbDiasNotiCorreo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDiasNotiCorreo.FormattingEnabled = true;
            this.cmbDiasNotiCorreo.Location = new System.Drawing.Point(12, 73);
            this.cmbDiasNotiCorreo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cmbDiasNotiCorreo.Name = "cmbDiasNotiCorreo";
            this.cmbDiasNotiCorreo.Size = new System.Drawing.Size(227, 27);
            this.cmbDiasNotiCorreo.StateActive.ComboBox.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cmbDiasNotiCorreo.StateActive.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cmbDiasNotiCorreo.StateCommon.ComboBox.Border.Color1 = System.Drawing.Color.White;
            this.cmbDiasNotiCorreo.StateCommon.ComboBox.Border.Color2 = System.Drawing.Color.White;
            this.cmbDiasNotiCorreo.StateCommon.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cmbDiasNotiCorreo.StateCommon.ComboBox.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.cmbDiasNotiCorreo.StateCommon.ComboBox.Border.Rounding = 4;
            this.cmbDiasNotiCorreo.StateCommon.ComboBox.Border.Width = 2;
            this.cmbDiasNotiCorreo.TabIndex = 2;
            // 
            // chkNotiSMS
            // 
            this.chkNotiSMS.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNotiSMS.Location = new System.Drawing.Point(296, 12);
            this.chkNotiSMS.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chkNotiSMS.Name = "chkNotiSMS";
            this.chkNotiSMS.Size = new System.Drawing.Size(120, 20);
            this.chkNotiSMS.TabIndex = 1;
            this.chkNotiSMS.Values.Text = "Notificar por SMS";
            this.chkNotiSMS.CheckedChanged += new System.EventHandler(this.chkNotiSMS_CheckedChanged);
            // 
            // chkNotiCorreo
            // 
            this.chkNotiCorreo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNotiCorreo.Location = new System.Drawing.Point(12, 12);
            this.chkNotiCorreo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chkNotiCorreo.Name = "chkNotiCorreo";
            this.chkNotiCorreo.Size = new System.Drawing.Size(195, 20);
            this.chkNotiCorreo.TabIndex = 0;
            this.chkNotiCorreo.Values.Text = "Notificar por correo electronico";
            this.chkNotiCorreo.CheckedChanged += new System.EventHandler(this.chkNotiCorreo_CheckedChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.LightGray;
            this.btnCancelar.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(1171, 588);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(101, 32);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Values.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.LightGray;
            this.btnAgregar.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(1053, 588);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(101, 32);
            this.btnAgregar.TabIndex = 8;
            this.btnAgregar.Values.Text = "Editar";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // kryptonNavigator1
            // 
            this.kryptonNavigator1.Location = new System.Drawing.Point(12, 12);
            this.kryptonNavigator1.Name = "kryptonNavigator1";
            this.kryptonNavigator1.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.kryptonPage1,
            this.kryptonPage2});
            this.kryptonNavigator1.SelectedIndex = 0;
            this.kryptonNavigator1.Size = new System.Drawing.Size(1260, 554);
            this.kryptonNavigator1.TabIndex = 12;
            this.kryptonNavigator1.Text = "kryptonNavigator1";
            // 
            // kryptonPage1
            // 
            this.kryptonPage1.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage1.Controls.Add(this.kryptonGroupBox1);
            this.kryptonPage1.Controls.Add(this.monthView1);
            this.kryptonPage1.Controls.Add(this.calendar1);
            this.kryptonPage1.Flags = 65534;
            this.kryptonPage1.LastVisibleSet = true;
            this.kryptonPage1.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage1.Name = "kryptonPage1";
            this.kryptonPage1.Size = new System.Drawing.Size(1258, 527);
            this.kryptonPage1.Text = "Cita";
            this.kryptonPage1.ToolTipTitle = "Page ToolTip";
            this.kryptonPage1.UniqueName = "D13242CB477F4E699881D44CC21AF7BD";
            this.kryptonPage1.Click += new System.EventHandler(this.kryptonPage1_Click);
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.CaptionStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
            this.kryptonGroupBox1.Location = new System.Drawing.Point(19, 18);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.cmbTipoCita);
            this.kryptonGroupBox1.Panel.Controls.Add(this.cmbPaciente);
            this.kryptonGroupBox1.Panel.Controls.Add(this.label1);
            this.kryptonGroupBox1.Panel.Controls.Add(this.cmbEstatusCita);
            this.kryptonGroupBox1.Panel.Controls.Add(this.lblMedico);
            this.kryptonGroupBox1.Panel.Controls.Add(this.label9);
            this.kryptonGroupBox1.Panel.Controls.Add(this.label2);
            this.kryptonGroupBox1.Panel.Controls.Add(this.label10);
            this.kryptonGroupBox1.Panel.Controls.Add(this.txtComentarios);
            this.kryptonGroupBox1.Panel.Controls.Add(this.cmbMedico);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(318, 480);
            this.kryptonGroupBox1.TabIndex = 29;
            this.kryptonGroupBox1.Values.Heading = "Datos Generales";
            // 
            // kryptonPage2
            // 
            this.kryptonPage2.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage2.Controls.Add(this.kryptonGroupBox2);
            this.kryptonPage2.Flags = 65534;
            this.kryptonPage2.LastVisibleSet = true;
            this.kryptonPage2.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage2.Name = "kryptonPage2";
            this.kryptonPage2.Size = new System.Drawing.Size(1258, 527);
            this.kryptonPage2.Text = "Notificaciones";
            this.kryptonPage2.ToolTipTitle = "Page ToolTip";
            this.kryptonPage2.UniqueName = "52A4D5A22F98433FADB9A6D174B80AF5";
            // 
            // kryptonGroupBox2
            // 
            this.kryptonGroupBox2.CaptionStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
            this.kryptonGroupBox2.Location = new System.Drawing.Point(26, 39);
            this.kryptonGroupBox2.Name = "kryptonGroupBox2";
            // 
            // kryptonGroupBox2.Panel
            // 
            this.kryptonGroupBox2.Panel.Controls.Add(this.chkNotiCorreo);
            this.kryptonGroupBox2.Panel.Controls.Add(this.label7);
            this.kryptonGroupBox2.Panel.Controls.Add(this.cmbNotiDiasSMS);
            this.kryptonGroupBox2.Panel.Controls.Add(this.chkNotiSMS);
            this.kryptonGroupBox2.Panel.Controls.Add(this.label6);
            this.kryptonGroupBox2.Panel.Controls.Add(this.cmbDiasNotiCorreo);
            this.kryptonGroupBox2.Panel.Controls.Add(this.cmbNotiHorasCorreo);
            this.kryptonGroupBox2.Panel.Controls.Add(this.cmbNotiHoraSMS);
            this.kryptonGroupBox2.Panel.Controls.Add(this.label8);
            this.kryptonGroupBox2.Panel.Controls.Add(this.label4);
            this.kryptonGroupBox2.Size = new System.Drawing.Size(540, 202);
            this.kryptonGroupBox2.TabIndex = 10;
            this.kryptonGroupBox2.Values.Heading = "Opciones";
            // 
            // EditarCita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1285, 623);
            this.Controls.Add(this.kryptonNavigator1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAgregar);
            this.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditarCita";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Cita";
            this.Load += new System.EventHandler(this.EditarCita_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbTipoCita)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEstatusCita)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMedico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPaciente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNotiHoraSMS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNotiDiasSMS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNotiHorasCorreo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDiasNotiCorreo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).EndInit();
            this.kryptonNavigator1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).EndInit();
            this.kryptonPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage2)).EndInit();
            this.kryptonPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).EndInit();
            this.kryptonGroupBox2.Panel.ResumeLayout(false);
            this.kryptonGroupBox2.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).EndInit();
            this.kryptonGroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label9;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancelar;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAgregar;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtComentarios;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblMedico;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbMedico;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbPaciente;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label7;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbNotiHoraSMS;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label8;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbNotiDiasSMS;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label6;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbNotiHorasCorreo;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label4;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbDiasNotiCorreo;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkNotiSMS;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkNotiCorreo;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label10;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbEstatusCita;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbTipoCita;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label2;
        private System.Windows.Forms.Calendar.Calendar calendar1;
        private System.Windows.Forms.Calendar.MonthView monthView1;
        private ComponentFactory.Krypton.Navigator.KryptonNavigator kryptonNavigator1;
        private ComponentFactory.Krypton.Navigator.KryptonPage kryptonPage1;
        private ComponentFactory.Krypton.Navigator.KryptonPage kryptonPage2;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox2;
    }
}