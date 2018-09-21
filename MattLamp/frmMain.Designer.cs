namespace MattLamp
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.lblDevice = new System.Windows.Forms.Label();
            this.cbDevice = new System.Windows.Forms.ComboBox();
            this.deviceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rbActionSendKeyCombo = new System.Windows.Forms.RadioButton();
            this.rbActionCycleLedMode = new System.Windows.Forms.RadioButton();
            this.rbActionNone = new System.Windows.Forms.RadioButton();
            this.rectColorVal = new MattLamp.Controls.OwnerDrawPanel();
            this.rectColorHue = new MattLamp.Controls.OwnerDrawPanel();
            this.tbColorVal = new System.Windows.Forms.TrackBar();
            this.lblColorHue = new System.Windows.Forms.Label();
            this.lblColorBrightness = new System.Windows.Forms.Label();
            this.tbColorHue = new System.Windows.Forms.TrackBar();
            this.btnLedRemoveColor = new System.Windows.Forms.Button();
            this.btnLedClearColors = new System.Windows.Forms.Button();
            this.btnLedAddColor = new System.Windows.Forms.Button();
            this.lbEffectColors = new System.Windows.Forms.ListBox();
            this.colorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cbLedMode = new System.Windows.Forms.ComboBox();
            this.ledEffectModeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblMode = new System.Windows.Forms.Label();
            this.dlgColorPicker = new System.Windows.Forms.ColorDialog();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabKeyConfig = new System.Windows.Forms.TabPage();
            this.lblLedModeNote = new System.Windows.Forms.Label();
            this.cbActionToggleLedModeParm2 = new System.Windows.Forms.ComboBox();
            this.cbActionToggleLedModeParm1 = new System.Windows.Forms.ComboBox();
            this.cbActionSetLedModeParm = new System.Windows.Forms.ComboBox();
            this.rbActionToggleLedMode = new System.Windows.Forms.RadioButton();
            this.rbActionSetLedMode = new System.Windows.Forms.RadioButton();
            this.lblKeyAction = new System.Windows.Forms.Label();
            this.btnSaveKeyConfig = new System.Windows.Forms.Button();
            this.lblKeyComboDisp = new System.Windows.Forms.Label();
            this.btnSetKeyCombo = new System.Windows.Forms.Button();
            this.tabLedConfig = new System.Windows.Forms.TabPage();
            this.gbEffectSettings = new System.Windows.Forms.GroupBox();
            this.lblStrobeSpeed = new System.Windows.Forms.Label();
            this.tbEffectSpeed = new System.Windows.Forms.TrackBar();
            this.lblEffectSpeed = new System.Windows.Forms.Label();
            this.lblEffectSpeedDisp = new System.Windows.Forms.Label();
            this.lblSlower = new System.Windows.Forms.Label();
            this.lblStrobeSpeedDisp = new System.Windows.Forms.Label();
            this.lblFaster = new System.Windows.Forms.Label();
            this.tbStrobeSpeed = new System.Windows.Forms.TrackBar();
            this.gbEffectColors = new System.Windows.Forms.GroupBox();
            this.gbLedStatus = new System.Windows.Forms.GroupBox();
            this.ssLedStatus = new System.Windows.Forms.StatusStrip();
            this.lblLedStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.ledLayoutControl = new MattLamp.Controls.LedLayoutControl();
            this.ledStatusBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gbLive = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbLiveModeHB = new System.Windows.Forms.RadioButton();
            this.tbColorTemp = new System.Windows.Forms.TrackBar();
            this.rbLiveModeTemp = new System.Windows.Forms.RadioButton();
            this.rectColorTemp = new MattLamp.Controls.OwnerDrawPanel();
            this.btnSaveLedConfig = new System.Windows.Forms.Button();
            this.lblNoDevices = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.deviceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbColorVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbColorHue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledEffectModeBindingSource)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabKeyConfig.SuspendLayout();
            this.tabLedConfig.SuspendLayout();
            this.gbEffectSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbEffectSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbStrobeSpeed)).BeginInit();
            this.gbEffectColors.SuspendLayout();
            this.gbLedStatus.SuspendLayout();
            this.ssLedStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledStatusBindingSource)).BeginInit();
            this.gbLive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbColorTemp)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDevice
            // 
            this.lblDevice.AutoSize = true;
            this.lblDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDevice.Location = new System.Drawing.Point(12, 13);
            this.lblDevice.Name = "lblDevice";
            this.lblDevice.Size = new System.Drawing.Size(47, 13);
            this.lblDevice.TabIndex = 0;
            this.lblDevice.Text = "Device";
            // 
            // cbDevice
            // 
            this.cbDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDevice.DataSource = this.deviceBindingSource;
            this.cbDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDevice.FormattingEnabled = true;
            this.cbDevice.Location = new System.Drawing.Point(66, 10);
            this.cbDevice.Name = "cbDevice";
            this.cbDevice.Size = new System.Drawing.Size(718, 21);
            this.cbDevice.TabIndex = 1;
            this.cbDevice.Visible = false;
            this.cbDevice.SelectedIndexChanged += new System.EventHandler(this.cbDevice_SelectedIndexChanged);
            // 
            // deviceBindingSource
            // 
            this.deviceBindingSource.DataSource = typeof(MattLamp.Models.DeviceInstance);
            // 
            // rbActionSendKeyCombo
            // 
            this.rbActionSendKeyCombo.AutoSize = true;
            this.rbActionSendKeyCombo.Enabled = false;
            this.rbActionSendKeyCombo.Location = new System.Drawing.Point(3, 192);
            this.rbActionSendKeyCombo.Name = "rbActionSendKeyCombo";
            this.rbActionSendKeyCombo.Size = new System.Drawing.Size(132, 17);
            this.rbActionSendKeyCombo.TabIndex = 2;
            this.rbActionSendKeyCombo.Text = "Send Key Combination";
            this.rbActionSendKeyCombo.UseVisualStyleBackColor = true;
            this.rbActionSendKeyCombo.CheckedChanged += new System.EventHandler(this.rbActionSendKeyCombo_CheckedChanged);
            // 
            // rbActionCycleLedMode
            // 
            this.rbActionCycleLedMode.AutoSize = true;
            this.rbActionCycleLedMode.Enabled = false;
            this.rbActionCycleLedMode.Location = new System.Drawing.Point(6, 42);
            this.rbActionCycleLedMode.Name = "rbActionCycleLedMode";
            this.rbActionCycleLedMode.Size = new System.Drawing.Size(105, 17);
            this.rbActionCycleLedMode.TabIndex = 1;
            this.rbActionCycleLedMode.Text = "Cycle LED Mode";
            this.rbActionCycleLedMode.UseVisualStyleBackColor = true;
            // 
            // rbActionNone
            // 
            this.rbActionNone.AutoSize = true;
            this.rbActionNone.Checked = true;
            this.rbActionNone.Enabled = false;
            this.rbActionNone.Location = new System.Drawing.Point(6, 19);
            this.rbActionNone.Name = "rbActionNone";
            this.rbActionNone.Size = new System.Drawing.Size(72, 17);
            this.rbActionNone.TabIndex = 0;
            this.rbActionNone.TabStop = true;
            this.rbActionNone.Text = "No Action";
            this.rbActionNone.UseVisualStyleBackColor = true;
            // 
            // rectColorVal
            // 
            this.rectColorVal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rectColorVal.Location = new System.Drawing.Point(194, 42);
            this.rectColorVal.Name = "rectColorVal";
            this.rectColorVal.Size = new System.Drawing.Size(30, 231);
            this.rectColorVal.TabIndex = 17;
            this.rectColorVal.Paint += new System.Windows.Forms.PaintEventHandler(this.rectColorVal_Paint);
            // 
            // rectColorHue
            // 
            this.rectColorHue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rectColorHue.Location = new System.Drawing.Point(126, 42);
            this.rectColorHue.Name = "rectColorHue";
            this.rectColorHue.Size = new System.Drawing.Size(30, 231);
            this.rectColorHue.TabIndex = 15;
            this.rectColorHue.Paint += new System.Windows.Forms.PaintEventHandler(this.rectColorHue_Paint);
            // 
            // tbColorVal
            // 
            this.tbColorVal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbColorVal.AutoSize = false;
            this.tbColorVal.BackColor = System.Drawing.Color.White;
            this.tbColorVal.Enabled = false;
            this.tbColorVal.LargeChange = 10;
            this.tbColorVal.Location = new System.Drawing.Point(162, 42);
            this.tbColorVal.Maximum = 100;
            this.tbColorVal.Name = "tbColorVal";
            this.tbColorVal.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbColorVal.Size = new System.Drawing.Size(26, 231);
            this.tbColorVal.TabIndex = 14;
            this.tbColorVal.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbColorVal.ValueChanged += new System.EventHandler(this.tbColorVal_ValueChanged);
            // 
            // lblColorHue
            // 
            this.lblColorHue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblColorHue.Location = new System.Drawing.Point(99, 278);
            this.lblColorHue.Name = "lblColorHue";
            this.lblColorHue.Size = new System.Drawing.Size(62, 16);
            this.lblColorHue.TabIndex = 12;
            this.lblColorHue.Text = "Hue";
            // 
            // lblColorBrightness
            // 
            this.lblColorBrightness.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblColorBrightness.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColorBrightness.Location = new System.Drawing.Point(162, 276);
            this.lblColorBrightness.Name = "lblColorBrightness";
            this.lblColorBrightness.Size = new System.Drawing.Size(62, 16);
            this.lblColorBrightness.TabIndex = 10;
            this.lblColorBrightness.Text = "Brightness";
            this.lblColorBrightness.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbColorHue
            // 
            this.tbColorHue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbColorHue.AutoSize = false;
            this.tbColorHue.BackColor = System.Drawing.Color.White;
            this.tbColorHue.Enabled = false;
            this.tbColorHue.LargeChange = 15;
            this.tbColorHue.Location = new System.Drawing.Point(97, 42);
            this.tbColorHue.Margin = new System.Windows.Forms.Padding(0);
            this.tbColorHue.Maximum = 360;
            this.tbColorHue.Name = "tbColorHue";
            this.tbColorHue.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbColorHue.Size = new System.Drawing.Size(26, 231);
            this.tbColorHue.TabIndex = 9;
            this.tbColorHue.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbColorHue.ValueChanged += new System.EventHandler(this.tbColorHue_ValueChanged);
            // 
            // btnLedRemoveColor
            // 
            this.btnLedRemoveColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLedRemoveColor.Enabled = false;
            this.btnLedRemoveColor.Image = global::MattLamp.Properties.Resources.remove;
            this.btnLedRemoveColor.Location = new System.Drawing.Point(51, 225);
            this.btnLedRemoveColor.Margin = new System.Windows.Forms.Padding(0);
            this.btnLedRemoveColor.Name = "btnLedRemoveColor";
            this.btnLedRemoveColor.Size = new System.Drawing.Size(42, 42);
            this.btnLedRemoveColor.TabIndex = 8;
            this.btnLedRemoveColor.UseVisualStyleBackColor = true;
            this.btnLedRemoveColor.Click += new System.EventHandler(this.btnLedRemoveColor_Click);
            // 
            // btnLedClearColors
            // 
            this.btnLedClearColors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLedClearColors.Enabled = false;
            this.btnLedClearColors.Image = global::MattLamp.Properties.Resources.clear;
            this.btnLedClearColors.Location = new System.Drawing.Point(112, 225);
            this.btnLedClearColors.Name = "btnLedClearColors";
            this.btnLedClearColors.Size = new System.Drawing.Size(42, 42);
            this.btnLedClearColors.TabIndex = 7;
            this.btnLedClearColors.UseVisualStyleBackColor = true;
            this.btnLedClearColors.Click += new System.EventHandler(this.btnLedClearColors_Click);
            // 
            // btnLedAddColor
            // 
            this.btnLedAddColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLedAddColor.Enabled = false;
            this.btnLedAddColor.Image = global::MattLamp.Properties.Resources.add;
            this.btnLedAddColor.Location = new System.Drawing.Point(6, 225);
            this.btnLedAddColor.Name = "btnLedAddColor";
            this.btnLedAddColor.Size = new System.Drawing.Size(42, 42);
            this.btnLedAddColor.TabIndex = 6;
            this.btnLedAddColor.UseVisualStyleBackColor = true;
            this.btnLedAddColor.Click += new System.EventHandler(this.btnLedAddColor_Click);
            // 
            // lbEffectColors
            // 
            this.lbEffectColors.AllowDrop = true;
            this.lbEffectColors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbEffectColors.DataSource = this.colorBindingSource;
            this.lbEffectColors.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbEffectColors.Enabled = false;
            this.lbEffectColors.FormattingEnabled = true;
            this.lbEffectColors.IntegralHeight = false;
            this.lbEffectColors.ItemHeight = 18;
            this.lbEffectColors.Location = new System.Drawing.Point(6, 16);
            this.lbEffectColors.Name = "lbEffectColors";
            this.lbEffectColors.Size = new System.Drawing.Size(148, 200);
            this.lbEffectColors.TabIndex = 2;
            this.lbEffectColors.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbEffectColors_DrawItem);
            this.lbEffectColors.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbEffectColors_MouseDoubleClick);
            // 
            // colorBindingSource
            // 
            this.colorBindingSource.DataSource = typeof(System.Drawing.Color);
            this.colorBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.colorBindingSource_ListChanged);
            // 
            // cbLedMode
            // 
            this.cbLedMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbLedMode.DataSource = this.ledEffectModeBindingSource;
            this.cbLedMode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbLedMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLedMode.Enabled = false;
            this.cbLedMode.FormattingEnabled = true;
            this.cbLedMode.Location = new System.Drawing.Point(48, 6);
            this.cbLedMode.Name = "cbLedMode";
            this.cbLedMode.Size = new System.Drawing.Size(752, 21);
            this.cbLedMode.TabIndex = 1;
            this.cbLedMode.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbLedMode_DrawItem);
            this.cbLedMode.SelectedIndexChanged += new System.EventHandler(this.cbLedMode_SelectedIndexChanged);
            // 
            // ledEffectModeBindingSource
            // 
            this.ledEffectModeBindingSource.DataSource = typeof(MattLamp.Models.LedEffectMode);
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.Location = new System.Drawing.Point(6, 9);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(38, 13);
            this.lblMode.TabIndex = 0;
            this.lblMode.Text = "Mode";
            // 
            // dlgColorPicker
            // 
            this.dlgColorPicker.AnyColor = true;
            this.dlgColorPicker.FullOpen = true;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabKeyConfig);
            this.tabControl.Controls.Add(this.tabLedConfig);
            this.tabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl.ItemSize = new System.Drawing.Size(96, 48);
            this.tabControl.Location = new System.Drawing.Point(12, 42);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(776, 396);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 5;
            this.tabControl.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl_DrawItem);
            // 
            // tabKeyConfig
            // 
            this.tabKeyConfig.Controls.Add(this.lblLedModeNote);
            this.tabKeyConfig.Controls.Add(this.cbActionToggleLedModeParm2);
            this.tabKeyConfig.Controls.Add(this.cbActionToggleLedModeParm1);
            this.tabKeyConfig.Controls.Add(this.cbActionSetLedModeParm);
            this.tabKeyConfig.Controls.Add(this.rbActionToggleLedMode);
            this.tabKeyConfig.Controls.Add(this.rbActionSetLedMode);
            this.tabKeyConfig.Controls.Add(this.lblKeyAction);
            this.tabKeyConfig.Controls.Add(this.btnSaveKeyConfig);
            this.tabKeyConfig.Controls.Add(this.lblKeyComboDisp);
            this.tabKeyConfig.Controls.Add(this.btnSetKeyCombo);
            this.tabKeyConfig.Controls.Add(this.rbActionNone);
            this.tabKeyConfig.Controls.Add(this.rbActionCycleLedMode);
            this.tabKeyConfig.Controls.Add(this.rbActionSendKeyCombo);
            this.tabKeyConfig.Location = new System.Drawing.Point(4, 52);
            this.tabKeyConfig.Name = "tabKeyConfig";
            this.tabKeyConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabKeyConfig.Size = new System.Drawing.Size(768, 340);
            this.tabKeyConfig.TabIndex = 0;
            this.tabKeyConfig.Text = "Keys";
            this.tabKeyConfig.UseVisualStyleBackColor = true;
            // 
            // lblLedModeNote
            // 
            this.lblLedModeNote.AutoSize = true;
            this.lblLedModeNote.BackColor = System.Drawing.SystemColors.Info;
            this.lblLedModeNote.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblLedModeNote.Location = new System.Drawing.Point(122, 42);
            this.lblLedModeNote.Name = "lblLedModeNote";
            this.lblLedModeNote.Padding = new System.Windows.Forms.Padding(6);
            this.lblLedModeNote.Size = new System.Drawing.Size(469, 25);
            this.lblLedModeNote.TabIndex = 13;
            this.lblLedModeNote.Text = "Note: The LED effect mode will revert to what is set on the LEDs tab if the devic" +
    "e is unplugged.";
            // 
            // cbActionToggleLedModeParm2
            // 
            this.cbActionToggleLedModeParm2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbActionToggleLedModeParm2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbActionToggleLedModeParm2.Enabled = false;
            this.cbActionToggleLedModeParm2.FormattingEnabled = true;
            this.cbActionToggleLedModeParm2.Location = new System.Drawing.Point(24, 165);
            this.cbActionToggleLedModeParm2.Name = "cbActionToggleLedModeParm2";
            this.cbActionToggleLedModeParm2.Size = new System.Drawing.Size(738, 21);
            this.cbActionToggleLedModeParm2.TabIndex = 12;
            this.cbActionToggleLedModeParm2.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbLedMode_DrawItem);
            // 
            // cbActionToggleLedModeParm1
            // 
            this.cbActionToggleLedModeParm1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbActionToggleLedModeParm1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbActionToggleLedModeParm1.Enabled = false;
            this.cbActionToggleLedModeParm1.FormattingEnabled = true;
            this.cbActionToggleLedModeParm1.Location = new System.Drawing.Point(24, 138);
            this.cbActionToggleLedModeParm1.Name = "cbActionToggleLedModeParm1";
            this.cbActionToggleLedModeParm1.Size = new System.Drawing.Size(738, 21);
            this.cbActionToggleLedModeParm1.TabIndex = 10;
            this.cbActionToggleLedModeParm1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbLedMode_DrawItem);
            // 
            // cbActionSetLedModeParm
            // 
            this.cbActionSetLedModeParm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbActionSetLedModeParm.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbActionSetLedModeParm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbActionSetLedModeParm.Enabled = false;
            this.cbActionSetLedModeParm.FormattingEnabled = true;
            this.cbActionSetLedModeParm.Location = new System.Drawing.Point(24, 88);
            this.cbActionSetLedModeParm.Name = "cbActionSetLedModeParm";
            this.cbActionSetLedModeParm.Size = new System.Drawing.Size(738, 21);
            this.cbActionSetLedModeParm.TabIndex = 9;
            this.cbActionSetLedModeParm.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbLedMode_DrawItem);
            // 
            // rbActionToggleLedMode
            // 
            this.rbActionToggleLedMode.AutoSize = true;
            this.rbActionToggleLedMode.Enabled = false;
            this.rbActionToggleLedMode.Location = new System.Drawing.Point(6, 115);
            this.rbActionToggleLedMode.Name = "rbActionToggleLedMode";
            this.rbActionToggleLedMode.Size = new System.Drawing.Size(159, 17);
            this.rbActionToggleLedMode.TabIndex = 8;
            this.rbActionToggleLedMode.TabStop = true;
            this.rbActionToggleLedMode.Text = "Toggle LED Mode between:";
            this.rbActionToggleLedMode.UseVisualStyleBackColor = true;
            this.rbActionToggleLedMode.CheckedChanged += new System.EventHandler(this.rbActionToggleLedMode_CheckedChanged);
            // 
            // rbActionSetLedMode
            // 
            this.rbActionSetLedMode.AutoSize = true;
            this.rbActionSetLedMode.Enabled = false;
            this.rbActionSetLedMode.Location = new System.Drawing.Point(6, 65);
            this.rbActionSetLedMode.Name = "rbActionSetLedMode";
            this.rbActionSetLedMode.Size = new System.Drawing.Size(110, 17);
            this.rbActionSetLedMode.TabIndex = 7;
            this.rbActionSetLedMode.TabStop = true;
            this.rbActionSetLedMode.Text = "Set LED Mode to:";
            this.rbActionSetLedMode.UseVisualStyleBackColor = true;
            this.rbActionSetLedMode.CheckedChanged += new System.EventHandler(this.rbActionSetLedMode_CheckedChanged);
            // 
            // lblKeyAction
            // 
            this.lblKeyAction.AutoSize = true;
            this.lblKeyAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKeyAction.Location = new System.Drawing.Point(3, 3);
            this.lblKeyAction.Name = "lblKeyAction";
            this.lblKeyAction.Size = new System.Drawing.Size(103, 13);
            this.lblKeyAction.TabIndex = 6;
            this.lblKeyAction.Text = "Key Press Action";
            // 
            // btnSaveKeyConfig
            // 
            this.btnSaveKeyConfig.Enabled = false;
            this.btnSaveKeyConfig.Image = global::MattLamp.Properties.Resources.diskette;
            this.btnSaveKeyConfig.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveKeyConfig.Location = new System.Drawing.Point(3, 250);
            this.btnSaveKeyConfig.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.btnSaveKeyConfig.Name = "btnSaveKeyConfig";
            this.btnSaveKeyConfig.Size = new System.Drawing.Size(160, 24);
            this.btnSaveKeyConfig.TabIndex = 5;
            this.btnSaveKeyConfig.Text = "Save to Device Storage";
            this.btnSaveKeyConfig.UseVisualStyleBackColor = true;
            this.btnSaveKeyConfig.Click += new System.EventHandler(this.btnSaveKeyConfig_Click);
            // 
            // lblKeyComboDisp
            // 
            this.lblKeyComboDisp.AutoSize = true;
            this.lblKeyComboDisp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKeyComboDisp.Location = new System.Drawing.Point(102, 220);
            this.lblKeyComboDisp.Name = "lblKeyComboDisp";
            this.lblKeyComboDisp.Size = new System.Drawing.Size(43, 13);
            this.lblKeyComboDisp.TabIndex = 3;
            this.lblKeyComboDisp.Text = "Not Set";
            // 
            // btnSetKeyCombo
            // 
            this.btnSetKeyCombo.Enabled = false;
            this.btnSetKeyCombo.Location = new System.Drawing.Point(21, 215);
            this.btnSetKeyCombo.Margin = new System.Windows.Forms.Padding(24, 3, 3, 3);
            this.btnSetKeyCombo.Name = "btnSetKeyCombo";
            this.btnSetKeyCombo.Size = new System.Drawing.Size(75, 23);
            this.btnSetKeyCombo.TabIndex = 4;
            this.btnSetKeyCombo.Text = "Set...";
            this.btnSetKeyCombo.UseVisualStyleBackColor = true;
            this.btnSetKeyCombo.Click += new System.EventHandler(this.btnSetKeyCombo_Click);
            // 
            // tabLedConfig
            // 
            this.tabLedConfig.Controls.Add(this.gbEffectSettings);
            this.tabLedConfig.Controls.Add(this.gbEffectColors);
            this.tabLedConfig.Controls.Add(this.gbLedStatus);
            this.tabLedConfig.Controls.Add(this.gbLive);
            this.tabLedConfig.Controls.Add(this.btnSaveLedConfig);
            this.tabLedConfig.Controls.Add(this.lblMode);
            this.tabLedConfig.Controls.Add(this.cbLedMode);
            this.tabLedConfig.Location = new System.Drawing.Point(4, 52);
            this.tabLedConfig.Name = "tabLedConfig";
            this.tabLedConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabLedConfig.Size = new System.Drawing.Size(768, 340);
            this.tabLedConfig.TabIndex = 1;
            this.tabLedConfig.Text = "LEDs";
            this.tabLedConfig.UseVisualStyleBackColor = true;
            // 
            // gbEffectSettings
            // 
            this.gbEffectSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbEffectSettings.Controls.Add(this.lblStrobeSpeed);
            this.gbEffectSettings.Controls.Add(this.tbEffectSpeed);
            this.gbEffectSettings.Controls.Add(this.lblEffectSpeed);
            this.gbEffectSettings.Controls.Add(this.lblEffectSpeedDisp);
            this.gbEffectSettings.Controls.Add(this.lblSlower);
            this.gbEffectSettings.Controls.Add(this.lblStrobeSpeedDisp);
            this.gbEffectSettings.Controls.Add(this.lblFaster);
            this.gbEffectSettings.Controls.Add(this.tbStrobeSpeed);
            this.gbEffectSettings.Location = new System.Drawing.Point(172, 232);
            this.gbEffectSettings.Name = "gbEffectSettings";
            this.gbEffectSettings.Size = new System.Drawing.Size(354, 101);
            this.gbEffectSettings.TabIndex = 34;
            this.gbEffectSettings.TabStop = false;
            this.gbEffectSettings.Text = "Effect Settings";
            // 
            // lblStrobeSpeed
            // 
            this.lblStrobeSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStrobeSpeed.AutoSize = true;
            this.lblStrobeSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStrobeSpeed.Location = new System.Drawing.Point(6, 51);
            this.lblStrobeSpeed.Name = "lblStrobeSpeed";
            this.lblStrobeSpeed.Size = new System.Drawing.Size(84, 13);
            this.lblStrobeSpeed.TabIndex = 22;
            this.lblStrobeSpeed.Text = "Strobe Speed";
            // 
            // tbEffectSpeed
            // 
            this.tbEffectSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbEffectSpeed.AutoSize = false;
            this.tbEffectSpeed.BackColor = System.Drawing.Color.White;
            this.tbEffectSpeed.Enabled = false;
            this.tbEffectSpeed.LargeChange = 50;
            this.tbEffectSpeed.Location = new System.Drawing.Point(93, 20);
            this.tbEffectSpeed.Maximum = 10000;
            this.tbEffectSpeed.Minimum = 100;
            this.tbEffectSpeed.Name = "tbEffectSpeed";
            this.tbEffectSpeed.Size = new System.Drawing.Size(255, 28);
            this.tbEffectSpeed.TabIndex = 19;
            this.tbEffectSpeed.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbEffectSpeed.Value = 100;
            this.tbEffectSpeed.ValueChanged += new System.EventHandler(this.tbEffectSpeed_ValueChanged);
            // 
            // lblEffectSpeed
            // 
            this.lblEffectSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEffectSpeed.AutoSize = true;
            this.lblEffectSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEffectSpeed.Location = new System.Drawing.Point(6, 20);
            this.lblEffectSpeed.Name = "lblEffectSpeed";
            this.lblEffectSpeed.Size = new System.Drawing.Size(81, 13);
            this.lblEffectSpeed.TabIndex = 20;
            this.lblEffectSpeed.Text = "Effect Speed";
            // 
            // lblEffectSpeedDisp
            // 
            this.lblEffectSpeedDisp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEffectSpeedDisp.AutoSize = true;
            this.lblEffectSpeedDisp.Location = new System.Drawing.Point(6, 35);
            this.lblEffectSpeedDisp.Name = "lblEffectSpeedDisp";
            this.lblEffectSpeedDisp.Size = new System.Drawing.Size(41, 13);
            this.lblEffectSpeedDisp.TabIndex = 21;
            this.lblEffectSpeedDisp.Text = "100 ms";
            // 
            // lblSlower
            // 
            this.lblSlower.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSlower.AutoSize = true;
            this.lblSlower.Location = new System.Drawing.Point(309, 80);
            this.lblSlower.Name = "lblSlower";
            this.lblSlower.Size = new System.Drawing.Size(39, 13);
            this.lblSlower.TabIndex = 26;
            this.lblSlower.Text = "Slower";
            // 
            // lblStrobeSpeedDisp
            // 
            this.lblStrobeSpeedDisp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStrobeSpeedDisp.AutoSize = true;
            this.lblStrobeSpeedDisp.Location = new System.Drawing.Point(6, 64);
            this.lblStrobeSpeedDisp.Name = "lblStrobeSpeedDisp";
            this.lblStrobeSpeedDisp.Size = new System.Drawing.Size(29, 13);
            this.lblStrobeSpeedDisp.TabIndex = 23;
            this.lblStrobeSpeedDisp.Text = "1 ms";
            // 
            // lblFaster
            // 
            this.lblFaster.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFaster.AutoSize = true;
            this.lblFaster.Location = new System.Drawing.Point(90, 80);
            this.lblFaster.Name = "lblFaster";
            this.lblFaster.Size = new System.Drawing.Size(36, 13);
            this.lblFaster.TabIndex = 25;
            this.lblFaster.Text = "Faster";
            // 
            // tbStrobeSpeed
            // 
            this.tbStrobeSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbStrobeSpeed.AutoSize = false;
            this.tbStrobeSpeed.BackColor = System.Drawing.Color.White;
            this.tbStrobeSpeed.Enabled = false;
            this.tbStrobeSpeed.LargeChange = 100;
            this.tbStrobeSpeed.Location = new System.Drawing.Point(93, 51);
            this.tbStrobeSpeed.Maximum = 5000;
            this.tbStrobeSpeed.Minimum = 1;
            this.tbStrobeSpeed.Name = "tbStrobeSpeed";
            this.tbStrobeSpeed.Size = new System.Drawing.Size(255, 26);
            this.tbStrobeSpeed.TabIndex = 24;
            this.tbStrobeSpeed.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbStrobeSpeed.Value = 1;
            this.tbStrobeSpeed.ValueChanged += new System.EventHandler(this.tbStrobeSpeed_ValueChanged);
            // 
            // gbEffectColors
            // 
            this.gbEffectColors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbEffectColors.Controls.Add(this.lbEffectColors);
            this.gbEffectColors.Controls.Add(this.btnLedAddColor);
            this.gbEffectColors.Controls.Add(this.btnLedRemoveColor);
            this.gbEffectColors.Controls.Add(this.btnLedClearColors);
            this.gbEffectColors.Location = new System.Drawing.Point(6, 34);
            this.gbEffectColors.Name = "gbEffectColors";
            this.gbEffectColors.Size = new System.Drawing.Size(160, 273);
            this.gbEffectColors.TabIndex = 33;
            this.gbEffectColors.TabStop = false;
            this.gbEffectColors.Text = "Effect Colors";
            // 
            // gbLedStatus
            // 
            this.gbLedStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbLedStatus.Controls.Add(this.ssLedStatus);
            this.gbLedStatus.Controls.Add(this.ledLayoutControl);
            this.gbLedStatus.Location = new System.Drawing.Point(172, 34);
            this.gbLedStatus.Name = "gbLedStatus";
            this.gbLedStatus.Size = new System.Drawing.Size(354, 192);
            this.gbLedStatus.TabIndex = 32;
            this.gbLedStatus.TabStop = false;
            this.gbLedStatus.Text = "LED Status";
            // 
            // ssLedStatus
            // 
            this.ssLedStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblLedStatus});
            this.ssLedStatus.Location = new System.Drawing.Point(3, 167);
            this.ssLedStatus.Name = "ssLedStatus";
            this.ssLedStatus.Size = new System.Drawing.Size(348, 22);
            this.ssLedStatus.SizingGrip = false;
            this.ssLedStatus.TabIndex = 28;
            // 
            // lblLedStatus
            // 
            this.lblLedStatus.Name = "lblLedStatus";
            this.lblLedStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // ledLayoutControl
            // 
            this.ledLayoutControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ledLayoutControl.DataMember = null;
            this.ledLayoutControl.DataSource = this.ledStatusBindingSource;
            this.ledLayoutControl.Location = new System.Drawing.Point(3, 16);
            this.ledLayoutControl.Name = "ledLayoutControl";
            this.ledLayoutControl.Size = new System.Drawing.Size(348, 148);
            this.ledLayoutControl.TabIndex = 27;
            this.ledLayoutControl.Text = "ledLayoutControl1";
            this.ledLayoutControl.StatusTextChanged += new System.EventHandler<MattLamp.Controls.StatusTextChangedEventArgs>(this.ledLayoutControl_StatusTextChanged);
            this.ledLayoutControl.OnItemRightClick += new System.EventHandler<MattLamp.Controls.LedStatusEventArgs>(this.ledLayoutControl_OnItemRightClick);
            // 
            // ledStatusBindingSource
            // 
            this.ledStatusBindingSource.AllowNew = false;
            this.ledStatusBindingSource.DataSource = typeof(MattLamp.Models.LedStatus);
            // 
            // gbLive
            // 
            this.gbLive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbLive.Controls.Add(this.label1);
            this.gbLive.Controls.Add(this.rbLiveModeHB);
            this.gbLive.Controls.Add(this.tbColorTemp);
            this.gbLive.Controls.Add(this.rbLiveModeTemp);
            this.gbLive.Controls.Add(this.rectColorTemp);
            this.gbLive.Controls.Add(this.lblColorHue);
            this.gbLive.Controls.Add(this.lblColorBrightness);
            this.gbLive.Controls.Add(this.tbColorVal);
            this.gbLive.Controls.Add(this.rectColorVal);
            this.gbLive.Controls.Add(this.rectColorHue);
            this.gbLive.Controls.Add(this.tbColorHue);
            this.gbLive.Location = new System.Drawing.Point(532, 35);
            this.gbLive.Name = "gbLive";
            this.gbLive.Size = new System.Drawing.Size(230, 299);
            this.gbLive.TabIndex = 31;
            this.gbLive.TabStop = false;
            this.gbLive.Text = "Live Mode";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(23, 278);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 32;
            this.label1.Text = "Temp (ºK)";
            // 
            // rbLiveModeHB
            // 
            this.rbLiveModeHB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbLiveModeHB.AutoSize = true;
            this.rbLiveModeHB.Checked = true;
            this.rbLiveModeHB.Enabled = false;
            this.rbLiveModeHB.Location = new System.Drawing.Point(102, 19);
            this.rbLiveModeHB.Name = "rbLiveModeHB";
            this.rbLiveModeHB.Size = new System.Drawing.Size(106, 17);
            this.rbLiveModeHB.TabIndex = 31;
            this.rbLiveModeHB.TabStop = true;
            this.rbLiveModeHB.Text = "Hue + Brightness";
            this.rbLiveModeHB.UseVisualStyleBackColor = true;
            this.rbLiveModeHB.CheckedChanged += new System.EventHandler(this.rbLiveMode_CheckedChanged);
            // 
            // tbColorTemp
            // 
            this.tbColorTemp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbColorTemp.AutoSize = false;
            this.tbColorTemp.BackColor = System.Drawing.Color.White;
            this.tbColorTemp.Enabled = false;
            this.tbColorTemp.LargeChange = 200;
            this.tbColorTemp.Location = new System.Drawing.Point(20, 42);
            this.tbColorTemp.Margin = new System.Windows.Forms.Padding(0);
            this.tbColorTemp.Maximum = 10000;
            this.tbColorTemp.Minimum = 1500;
            this.tbColorTemp.Name = "tbColorTemp";
            this.tbColorTemp.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbColorTemp.Size = new System.Drawing.Size(26, 231);
            this.tbColorTemp.SmallChange = 10;
            this.tbColorTemp.TabIndex = 28;
            this.tbColorTemp.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbColorTemp.Value = 1500;
            this.tbColorTemp.ValueChanged += new System.EventHandler(this.tbColorTemp_ValueChanged);
            // 
            // rbLiveModeTemp
            // 
            this.rbLiveModeTemp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbLiveModeTemp.AutoSize = true;
            this.rbLiveModeTemp.Enabled = false;
            this.rbLiveModeTemp.Location = new System.Drawing.Point(20, 19);
            this.rbLiveModeTemp.Name = "rbLiveModeTemp";
            this.rbLiveModeTemp.Size = new System.Drawing.Size(72, 17);
            this.rbLiveModeTemp.TabIndex = 30;
            this.rbLiveModeTemp.Text = "Temp (ºK)";
            this.rbLiveModeTemp.UseVisualStyleBackColor = true;
            this.rbLiveModeTemp.CheckedChanged += new System.EventHandler(this.rbLiveMode_CheckedChanged);
            // 
            // rectColorTemp
            // 
            this.rectColorTemp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rectColorTemp.Location = new System.Drawing.Point(49, 42);
            this.rectColorTemp.Name = "rectColorTemp";
            this.rectColorTemp.Size = new System.Drawing.Size(30, 231);
            this.rectColorTemp.TabIndex = 16;
            this.rectColorTemp.Paint += new System.Windows.Forms.PaintEventHandler(this.rectColorTemp_Paint);
            // 
            // btnSaveLedConfig
            // 
            this.btnSaveLedConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveLedConfig.Enabled = false;
            this.btnSaveLedConfig.Image = global::MattLamp.Properties.Resources.diskette;
            this.btnSaveLedConfig.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveLedConfig.Location = new System.Drawing.Point(6, 310);
            this.btnSaveLedConfig.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.btnSaveLedConfig.Name = "btnSaveLedConfig";
            this.btnSaveLedConfig.Size = new System.Drawing.Size(160, 24);
            this.btnSaveLedConfig.TabIndex = 18;
            this.btnSaveLedConfig.Text = "Save to Device Storage";
            this.btnSaveLedConfig.UseVisualStyleBackColor = true;
            this.btnSaveLedConfig.Click += new System.EventHandler(this.btnSaveLedConfig_Click);
            // 
            // lblNoDevices
            // 
            this.lblNoDevices.AutoSize = true;
            this.lblNoDevices.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoDevices.ForeColor = System.Drawing.Color.Red;
            this.lblNoDevices.Location = new System.Drawing.Point(66, 13);
            this.lblNoDevices.Name = "lblNoDevices";
            this.lblNoDevices.Size = new System.Drawing.Size(124, 13);
            this.lblNoDevices.TabIndex = 6;
            this.lblNoDevices.Text = "No devices connected...";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblNoDevices);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.cbDevice);
            this.Controls.Add(this.lblDevice);
            this.Name = "frmMain";
            this.Text = "Matt Lamp";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.deviceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbColorVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbColorHue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledEffectModeBindingSource)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabKeyConfig.ResumeLayout(false);
            this.tabKeyConfig.PerformLayout();
            this.tabLedConfig.ResumeLayout(false);
            this.tabLedConfig.PerformLayout();
            this.gbEffectSettings.ResumeLayout(false);
            this.gbEffectSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbEffectSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbStrobeSpeed)).EndInit();
            this.gbEffectColors.ResumeLayout(false);
            this.gbLedStatus.ResumeLayout(false);
            this.gbLedStatus.PerformLayout();
            this.ssLedStatus.ResumeLayout(false);
            this.ssLedStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledStatusBindingSource)).EndInit();
            this.gbLive.ResumeLayout(false);
            this.gbLive.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbColorTemp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDevice;
        private System.Windows.Forms.ComboBox cbDevice;
        private System.Windows.Forms.RadioButton rbActionSendKeyCombo;
        private System.Windows.Forms.RadioButton rbActionCycleLedMode;
        private System.Windows.Forms.RadioButton rbActionNone;
        private System.Windows.Forms.ComboBox cbLedMode;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.ListBox lbEffectColors;
        private System.Windows.Forms.Button btnLedRemoveColor;
        private System.Windows.Forms.Button btnLedClearColors;
        private System.Windows.Forms.Button btnLedAddColor;
        private System.Windows.Forms.ColorDialog dlgColorPicker;
        private System.Windows.Forms.TrackBar tbColorVal;
        private System.Windows.Forms.Label lblColorHue;
        private System.Windows.Forms.Label lblColorBrightness;
        private System.Windows.Forms.TrackBar tbColorHue;
        private MattLamp.Controls.OwnerDrawPanel rectColorVal;
        private MattLamp.Controls.OwnerDrawPanel rectColorHue;
        private System.Windows.Forms.BindingSource colorBindingSource;
        private System.Windows.Forms.BindingSource ledEffectModeBindingSource;
        private System.Windows.Forms.BindingSource deviceBindingSource;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabKeyConfig;
        private System.Windows.Forms.TabPage tabLedConfig;
        private System.Windows.Forms.Button btnSaveKeyConfig;
        private System.Windows.Forms.Button btnSaveLedConfig;
        private System.Windows.Forms.Label lblKeyAction;
        private System.Windows.Forms.Label lblKeyComboDisp;
        private System.Windows.Forms.Button btnSetKeyCombo;
        private System.Windows.Forms.Label lblSlower;
        private System.Windows.Forms.Label lblFaster;
        private System.Windows.Forms.TrackBar tbStrobeSpeed;
        private System.Windows.Forms.Label lblStrobeSpeedDisp;
        private System.Windows.Forms.Label lblStrobeSpeed;
        private System.Windows.Forms.Label lblEffectSpeedDisp;
        private System.Windows.Forms.Label lblEffectSpeed;
        private System.Windows.Forms.TrackBar tbEffectSpeed;
        private System.Windows.Forms.ComboBox cbActionSetLedModeParm;
        private System.Windows.Forms.RadioButton rbActionToggleLedMode;
        private System.Windows.Forms.RadioButton rbActionSetLedMode;
        private System.Windows.Forms.ComboBox cbActionToggleLedModeParm1;
        private System.Windows.Forms.ComboBox cbActionToggleLedModeParm2;
        private System.Windows.Forms.BindingSource ledStatusBindingSource;
        private Controls.LedLayoutControl ledLayoutControl;
        private System.Windows.Forms.Label lblNoDevices;
        private System.Windows.Forms.TrackBar tbColorTemp;
        private Controls.OwnerDrawPanel rectColorTemp;
        private System.Windows.Forms.GroupBox gbLive;
        private System.Windows.Forms.RadioButton rbLiveModeTemp;
        private System.Windows.Forms.GroupBox gbEffectSettings;
        private System.Windows.Forms.GroupBox gbEffectColors;
        private System.Windows.Forms.GroupBox gbLedStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbLiveModeHB;
        private System.Windows.Forms.StatusStrip ssLedStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblLedStatus;
        private System.Windows.Forms.Label lblLedModeNote;
    }
}

