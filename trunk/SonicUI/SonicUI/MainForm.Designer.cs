namespace SonicUI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.kryptonManager = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subSonicHomepageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.btnGenerate = new System.Windows.Forms.ToolStripButton();
            this.btnScriptSchema = new System.Windows.Forms.ToolStripButton();
            this.kryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.dataTree1 = new SonicUI.DataTree();
            this.kryptonHeaderGroup2 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.displayControl6 = new SonicUI.DisplayControl();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.displayControl1 = new SonicUI.DisplayControl();
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.displayControl2 = new SonicUI.DisplayControl();
            this.txtNamespace = new System.Windows.Forms.TextBox();
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonButton2 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.displayControl3 = new SonicUI.DisplayControl();
            this.txtTemplatePath = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkPlural = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.chkCasing = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.chkGenRelProps = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.chkGenSP = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.chkGenLazy = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.chkRemUnderscore = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkRegexIgnore = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.displayControl5 = new SonicUI.DisplayControl();
            this.txtRegexReplace = new System.Windows.Forms.TextBox();
            this.displayControl4 = new SonicUI.DisplayControl();
            this.txtRegexMatch = new System.Windows.Forms.TextBox();
            this.kryptonHeaderGroup3 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.kryptonDataGridView2 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.logEntryBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.compileWorker = new System.ComponentModel.BackgroundWorker();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.displayControl7 = new SonicUI.DisplayControl();
            this.txtDictReplace = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
            this.kryptonSplitContainer1.Panel2.SuspendLayout();
            this.kryptonSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2.Panel)).BeginInit();
            this.kryptonHeaderGroup2.Panel.SuspendLayout();
            this.kryptonHeaderGroup2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonButton2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkPlural)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCasing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGenRelProps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGenSP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGenLazy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRemUnderscore)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkRegexIgnore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup3.Panel)).BeginInit();
            this.kryptonHeaderGroup3.Panel.SuspendLayout();
            this.kryptonHeaderGroup3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logEntryBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonManager
            // 
            this.kryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2007Black;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(785, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Image = global::SonicUI.Properties.Resources.connect_creating;
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::SonicUI.Properties.Resources.exit;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.subSonicHomepageToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::SonicUI.Properties.Resources.help;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // subSonicHomepageToolStripMenuItem
            // 
            this.subSonicHomepageToolStripMenuItem.Image = global::SonicUI.Properties.Resources.agt_internet;
            this.subSonicHomepageToolStripMenuItem.Name = "subSonicHomepageToolStripMenuItem";
            this.subSonicHomepageToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.subSonicHomepageToolStripMenuItem.Text = "SubSonic Homepage";
            this.subSonicHomepageToolStripMenuItem.Click += new System.EventHandler(this.subSonicHomepageToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 529);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new System.Drawing.Size(785, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusInfo
            // 
            this.statusInfo.Name = "statusInfo";
            this.statusInfo.Size = new System.Drawing.Size(80, 17);
            this.statusInfo.Text = "System Ready";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.btnGenerate,
            this.btnScriptSchema});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(785, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::SonicUI.Properties.Resources.connect_creating;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(72, 22);
            this.toolStripButton2.Text = "Connect";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Enabled = false;
            this.btnGenerate.Image = global::SonicUI.Properties.Resources.agt_forward;
            this.btnGenerate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(74, 22);
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // btnScriptSchema
            // 
            this.btnScriptSchema.Enabled = false;
            this.btnScriptSchema.Image = global::SonicUI.Properties.Resources.wizard;
            this.btnScriptSchema.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnScriptSchema.Name = "btnScriptSchema";
            this.btnScriptSchema.Size = new System.Drawing.Size(102, 22);
            this.btnScriptSchema.Text = "Script Schema";
            this.btnScriptSchema.Click += new System.EventHandler(this.btnScriptSchema_Click);
            // 
            // kryptonSplitContainer1
            // 
            this.kryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.kryptonSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonSplitContainer1.Location = new System.Drawing.Point(5, 5);
            this.kryptonSplitContainer1.Name = "kryptonSplitContainer1";
            // 
            // kryptonSplitContainer1.Panel1
            // 
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.kryptonHeaderGroup1);
            // 
            // kryptonSplitContainer1.Panel2
            // 
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.kryptonHeaderGroup2);
            this.kryptonSplitContainer1.Size = new System.Drawing.Size(775, 345);
            this.kryptonSplitContainer1.SplitterDistance = 187;
            this.kryptonSplitContainer1.TabIndex = 3;
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonHeaderGroup1.HeaderVisibleSecondary = false;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.dataTree1);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(187, 345);
            this.kryptonHeaderGroup1.TabIndex = 0;
            this.kryptonHeaderGroup1.Text = "Data";
            this.kryptonHeaderGroup1.ValuesPrimary.Description = "";
            this.kryptonHeaderGroup1.ValuesPrimary.Heading = "Data";
            this.kryptonHeaderGroup1.ValuesPrimary.Image = global::SonicUI.Properties.Resources.db_status;
            this.kryptonHeaderGroup1.ValuesSecondary.Description = "";
            this.kryptonHeaderGroup1.ValuesSecondary.Heading = "Description";
            this.kryptonHeaderGroup1.ValuesSecondary.Image = null;
            // 
            // dataTree1
            // 
            this.dataTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataTree1.Location = new System.Drawing.Point(0, 0);
            this.dataTree1.Name = "dataTree1";
            this.dataTree1.Size = new System.Drawing.Size(185, 313);
            this.dataTree1.TabIndex = 0;
            // 
            // kryptonHeaderGroup2
            // 
            this.kryptonHeaderGroup2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonHeaderGroup2.HeaderVisibleSecondary = false;
            this.kryptonHeaderGroup2.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeaderGroup2.Name = "kryptonHeaderGroup2";
            // 
            // kryptonHeaderGroup2.Panel
            // 
            this.kryptonHeaderGroup2.Panel.Controls.Add(this.groupBox3);
            this.kryptonHeaderGroup2.Panel.Controls.Add(this.groupBox2);
            this.kryptonHeaderGroup2.Panel.Controls.Add(this.groupBox1);
            this.kryptonHeaderGroup2.Size = new System.Drawing.Size(583, 345);
            this.kryptonHeaderGroup2.TabIndex = 0;
            this.kryptonHeaderGroup2.Text = "Options";
            this.kryptonHeaderGroup2.ValuesPrimary.Description = "";
            this.kryptonHeaderGroup2.ValuesPrimary.Heading = "Options";
            this.kryptonHeaderGroup2.ValuesPrimary.Image = global::SonicUI.Properties.Resources.configure;
            this.kryptonHeaderGroup2.ValuesSecondary.Description = "";
            this.kryptonHeaderGroup2.ValuesSecondary.Heading = "Description";
            this.kryptonHeaderGroup2.ValuesSecondary.Image = null;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.displayControl6);
            this.groupBox3.Controls.Add(this.displayControl1);
            this.groupBox3.Controls.Add(this.displayControl2);
            this.groupBox3.Controls.Add(this.kryptonButton1);
            this.groupBox3.Controls.Add(this.kryptonButton2);
            this.groupBox3.Controls.Add(this.displayControl3);
            this.groupBox3.Location = new System.Drawing.Point(13, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(350, 138);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Output";
            // 
            // displayControl6
            // 
            this.displayControl6.BackColor = System.Drawing.Color.Transparent;
            this.displayControl6.Caption = "Language";
            this.displayControl6.Location = new System.Drawing.Point(6, 105);
            this.displayControl6.Name = "displayControl6";
            this.displayControl6.Padding = new System.Windows.Forms.Padding(2);
            this.displayControl6.Size = new System.Drawing.Size(257, 25);
            this.displayControl6.TabIndex = 7;
            this.displayControl6.ViewControl = this.cmbLanguage;
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Items.AddRange(new object[] {
            "C Sharp",
            "VB.net"});
            this.cmbLanguage.Location = new System.Drawing.Point(0, 0);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(173, 21);
            this.cmbLanguage.TabIndex = 6;
            // 
            // displayControl1
            // 
            this.displayControl1.BackColor = System.Drawing.Color.Transparent;
            this.displayControl1.Caption = "Output Folder";
            this.displayControl1.Location = new System.Drawing.Point(6, 19);
            this.displayControl1.Name = "displayControl1";
            this.displayControl1.Padding = new System.Windows.Forms.Padding(2);
            this.displayControl1.Size = new System.Drawing.Size(259, 24);
            this.displayControl1.TabIndex = 1;
            this.displayControl1.ViewControl = this.txtOutputPath;
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Location = new System.Drawing.Point(0, 0);
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.Size = new System.Drawing.Size(175, 20);
            this.txtOutputPath.TabIndex = 0;
            // 
            // displayControl2
            // 
            this.displayControl2.BackColor = System.Drawing.Color.Transparent;
            this.displayControl2.Caption = "Namespace";
            this.displayControl2.Location = new System.Drawing.Point(6, 47);
            this.displayControl2.Name = "displayControl2";
            this.displayControl2.Padding = new System.Windows.Forms.Padding(2);
            this.displayControl2.Size = new System.Drawing.Size(259, 24);
            this.displayControl2.TabIndex = 3;
            this.displayControl2.ViewControl = this.txtNamespace;
            // 
            // txtNamespace
            // 
            this.txtNamespace.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtNamespace.Location = new System.Drawing.Point(0, 0);
            this.txtNamespace.Name = "txtNamespace";
            this.txtNamespace.Size = new System.Drawing.Size(175, 20);
            this.txtNamespace.TabIndex = 4;
            this.txtNamespace.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Location = new System.Drawing.Point(269, 19);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(22, 25);
            this.kryptonButton1.TabIndex = 2;
            this.kryptonButton1.Text = "...";
            this.kryptonButton1.Values.ExtraText = "";
            this.kryptonButton1.Values.Image = null;
            this.kryptonButton1.Values.ImageStates.ImageCheckedNormal = null;
            this.kryptonButton1.Values.ImageStates.ImageCheckedPressed = null;
            this.kryptonButton1.Values.ImageStates.ImageCheckedTracking = null;
            this.kryptonButton1.Values.Text = "...";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.Location = new System.Drawing.Point(269, 76);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.Size = new System.Drawing.Size(22, 25);
            this.kryptonButton2.TabIndex = 5;
            this.kryptonButton2.Text = "...";
            this.kryptonButton2.Values.ExtraText = "";
            this.kryptonButton2.Values.Image = null;
            this.kryptonButton2.Values.ImageStates.ImageCheckedNormal = null;
            this.kryptonButton2.Values.ImageStates.ImageCheckedPressed = null;
            this.kryptonButton2.Values.ImageStates.ImageCheckedTracking = null;
            this.kryptonButton2.Values.Text = "...";
            this.kryptonButton2.Click += new System.EventHandler(this.kryptonButton2_Click);
            // 
            // displayControl3
            // 
            this.displayControl3.BackColor = System.Drawing.Color.Transparent;
            this.displayControl3.Caption = "Template Directory";
            this.displayControl3.Location = new System.Drawing.Point(6, 77);
            this.displayControl3.Name = "displayControl3";
            this.displayControl3.Padding = new System.Windows.Forms.Padding(2);
            this.displayControl3.Size = new System.Drawing.Size(259, 24);
            this.displayControl3.TabIndex = 4;
            this.displayControl3.ViewControl = this.txtTemplatePath;
            // 
            // txtTemplatePath
            // 
            this.txtTemplatePath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtTemplatePath.Location = new System.Drawing.Point(0, 0);
            this.txtTemplatePath.Name = "txtTemplatePath";
            this.txtTemplatePath.Size = new System.Drawing.Size(175, 20);
            this.txtTemplatePath.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.chkPlural);
            this.groupBox2.Controls.Add(this.chkCasing);
            this.groupBox2.Controls.Add(this.chkGenRelProps);
            this.groupBox2.Controls.Add(this.chkGenSP);
            this.groupBox2.Controls.Add(this.chkGenLazy);
            this.groupBox2.Controls.Add(this.chkRemUnderscore);
            this.groupBox2.Location = new System.Drawing.Point(375, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 282);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Properties";
            // 
            // chkPlural
            // 
            this.chkPlural.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPlural.Location = new System.Drawing.Point(6, 19);
            this.chkPlural.Name = "chkPlural";
            this.chkPlural.Size = new System.Drawing.Size(72, 20);
            this.chkPlural.TabIndex = 6;
            this.chkPlural.Text = "Fix Plural";
            this.chkPlural.Values.ExtraText = "";
            this.chkPlural.Values.Image = null;
            this.chkPlural.Values.Text = "Fix Plural";
            // 
            // chkCasing
            // 
            this.chkCasing.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCasing.Location = new System.Drawing.Point(6, 47);
            this.chkCasing.Name = "chkCasing";
            this.chkCasing.Size = new System.Drawing.Size(117, 20);
            this.chkCasing.TabIndex = 7;
            this.chkCasing.Text = "Fix Object Casing";
            this.chkCasing.Values.ExtraText = "";
            this.chkCasing.Values.Image = null;
            this.chkCasing.Values.Text = "Fix Object Casing";
            // 
            // chkGenRelProps
            // 
            this.chkGenRelProps.Checked = false;
            this.chkGenRelProps.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.chkGenRelProps.Location = new System.Drawing.Point(6, 155);
            this.chkGenRelProps.Name = "chkGenRelProps";
            this.chkGenRelProps.Size = new System.Drawing.Size(200, 20);
            this.chkGenRelProps.TabIndex = 11;
            this.chkGenRelProps.Text = "Generate Relations as Properties";
            this.chkGenRelProps.Values.ExtraText = "";
            this.chkGenRelProps.Values.Image = null;
            this.chkGenRelProps.Values.Text = "Generate Relations as Properties";
            // 
            // chkGenSP
            // 
            this.chkGenSP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGenSP.Location = new System.Drawing.Point(6, 77);
            this.chkGenSP.Name = "chkGenSP";
            this.chkGenSP.Size = new System.Drawing.Size(98, 20);
            this.chkGenSP.TabIndex = 8;
            this.chkGenSP.Text = "Generate SP\'s";
            this.chkGenSP.Values.ExtraText = "";
            this.chkGenSP.Values.Image = null;
            this.chkGenSP.Values.Text = "Generate SP\'s";
            // 
            // chkGenLazy
            // 
            this.chkGenLazy.Checked = false;
            this.chkGenLazy.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.chkGenLazy.Location = new System.Drawing.Point(6, 129);
            this.chkGenLazy.Name = "chkGenLazy";
            this.chkGenLazy.Size = new System.Drawing.Size(135, 20);
            this.chkGenLazy.TabIndex = 10;
            this.chkGenLazy.Text = "Generate Lazy Loads";
            this.chkGenLazy.Values.ExtraText = "";
            this.chkGenLazy.Values.Image = null;
            this.chkGenLazy.Values.Text = "Generate Lazy Loads";
            // 
            // chkRemUnderscore
            // 
            this.chkRemUnderscore.Checked = false;
            this.chkRemUnderscore.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.chkRemUnderscore.Location = new System.Drawing.Point(6, 103);
            this.chkRemUnderscore.Name = "chkRemUnderscore";
            this.chkRemUnderscore.Size = new System.Drawing.Size(133, 20);
            this.chkRemUnderscore.TabIndex = 9;
            this.chkRemUnderscore.Text = "Remove Underscore";
            this.chkRemUnderscore.Values.ExtraText = "";
            this.chkRemUnderscore.Values.Image = null;
            this.chkRemUnderscore.Values.Text = "Remove Underscore";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.displayControl7);
            this.groupBox1.Controls.Add(this.chkRegexIgnore);
            this.groupBox1.Controls.Add(this.displayControl5);
            this.groupBox1.Controls.Add(this.displayControl4);
            this.groupBox1.Location = new System.Drawing.Point(13, 149);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 138);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Regex";
            // 
            // chkRegexIgnore
            // 
            this.chkRegexIgnore.Checked = false;
            this.chkRegexIgnore.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.chkRegexIgnore.Location = new System.Drawing.Point(261, 78);
            this.chkRegexIgnore.Name = "chkRegexIgnore";
            this.chkRegexIgnore.Size = new System.Drawing.Size(88, 20);
            this.chkRegexIgnore.TabIndex = 2;
            this.chkRegexIgnore.Text = "Ignore Case";
            this.chkRegexIgnore.Values.ExtraText = "";
            this.chkRegexIgnore.Values.Image = null;
            this.chkRegexIgnore.Values.Text = "Ignore Case";
            // 
            // displayControl5
            // 
            this.displayControl5.BackColor = System.Drawing.Color.Transparent;
            this.displayControl5.Caption = "Replace";
            this.displayControl5.Location = new System.Drawing.Point(7, 50);
            this.displayControl5.Name = "displayControl5";
            this.displayControl5.Padding = new System.Windows.Forms.Padding(2);
            this.displayControl5.Size = new System.Drawing.Size(344, 24);
            this.displayControl5.TabIndex = 1;
            this.displayControl5.ViewControl = this.txtRegexReplace;
            // 
            // txtRegexReplace
            // 
            this.txtRegexReplace.Location = new System.Drawing.Point(0, 0);
            this.txtRegexReplace.Name = "txtRegexReplace";
            this.txtRegexReplace.Size = new System.Drawing.Size(260, 20);
            this.txtRegexReplace.TabIndex = 1;
            // 
            // displayControl4
            // 
            this.displayControl4.BackColor = System.Drawing.Color.Transparent;
            this.displayControl4.Caption = "Match";
            this.displayControl4.Location = new System.Drawing.Point(8, 20);
            this.displayControl4.Name = "displayControl4";
            this.displayControl4.Padding = new System.Windows.Forms.Padding(2);
            this.displayControl4.Size = new System.Drawing.Size(344, 24);
            this.displayControl4.TabIndex = 0;
            this.displayControl4.ViewControl = this.txtRegexMatch;
            // 
            // txtRegexMatch
            // 
            this.txtRegexMatch.Location = new System.Drawing.Point(0, 0);
            this.txtRegexMatch.Name = "txtRegexMatch";
            this.txtRegexMatch.Size = new System.Drawing.Size(260, 20);
            this.txtRegexMatch.TabIndex = 1;
            // 
            // kryptonHeaderGroup3
            // 
            this.kryptonHeaderGroup3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonHeaderGroup3.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.Secondary;
            this.kryptonHeaderGroup3.HeaderVisibleSecondary = false;
            this.kryptonHeaderGroup3.Location = new System.Drawing.Point(5, 350);
            this.kryptonHeaderGroup3.Name = "kryptonHeaderGroup3";
            // 
            // kryptonHeaderGroup3.Panel
            // 
            this.kryptonHeaderGroup3.Panel.Controls.Add(this.kryptonDataGridView2);
            this.kryptonHeaderGroup3.Size = new System.Drawing.Size(775, 125);
            this.kryptonHeaderGroup3.TabIndex = 4;
            this.kryptonHeaderGroup3.Text = "Log";
            this.kryptonHeaderGroup3.ValuesPrimary.Description = "";
            this.kryptonHeaderGroup3.ValuesPrimary.Heading = "Log";
            this.kryptonHeaderGroup3.ValuesPrimary.Image = global::SonicUI.Properties.Resources.playlist;
            this.kryptonHeaderGroup3.ValuesSecondary.Description = "";
            this.kryptonHeaderGroup3.ValuesSecondary.Heading = "Description";
            this.kryptonHeaderGroup3.ValuesSecondary.Image = null;
            // 
            // kryptonDataGridView2
            // 
            this.kryptonDataGridView2.AllowUserToAddRows = false;
            this.kryptonDataGridView2.AllowUserToDeleteRows = false;
            this.kryptonDataGridView2.DataSource = this.logEntryBindingSource1;
            this.kryptonDataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonDataGridView2.Location = new System.Drawing.Point(0, 0);
            this.kryptonDataGridView2.Name = "kryptonDataGridView2";
            this.kryptonDataGridView2.Size = new System.Drawing.Size(773, 102);
            this.kryptonDataGridView2.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.kryptonDataGridView2.TabIndex = 0;
            this.kryptonDataGridView2.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.kryptonDataGridView2_RowsAdded);
            // 
            // logEntryBindingSource1
            // 
            this.logEntryBindingSource1.DataSource = typeof(SubSonic.Commander.LogEntry);
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn6.HeaderText = "Description";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Status";
            this.dataGridViewTextBoxColumn5.HeaderText = "Status";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // compileWorker
            // 
            this.compileWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.compileWorker_DoWork);
            this.compileWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.compileWorker_RunWorkerCompleted);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonSplitContainer1);
            this.kryptonPanel1.Controls.Add(this.kryptonHeaderGroup3);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 49);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.kryptonPanel1.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(785, 480);
            this.kryptonPanel1.TabIndex = 5;
            // 
            // displayControl7
            // 
            this.displayControl7.BackColor = System.Drawing.Color.Transparent;
            this.displayControl7.Caption = "Dict Replace";
            this.displayControl7.Location = new System.Drawing.Point(8, 104);
            this.displayControl7.Name = "displayControl7";
            this.displayControl7.Padding = new System.Windows.Forms.Padding(2);
            this.displayControl7.Size = new System.Drawing.Size(343, 24);
            this.displayControl7.TabIndex = 3;
            this.displayControl7.ViewControl = this.txtDictReplace;
            // 
            // txtDictReplace
            // 
            this.txtDictReplace.Location = new System.Drawing.Point(0, 0);
            this.txtDictReplace.Name = "txtDictReplace";
            this.txtDictReplace.Size = new System.Drawing.Size(259, 20);
            this.txtDictReplace.TabIndex = 4;
            this.txtDictReplace.Text = "\\(,_;\\),_;";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 551);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "SonicUI";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
            this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2.Panel)).EndInit();
            this.kryptonHeaderGroup2.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2)).EndInit();
            this.kryptonHeaderGroup2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonButton2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkPlural)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCasing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGenRelProps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGenSP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGenLazy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRemUnderscore)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkRegexIgnore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup3.Panel)).EndInit();
            this.kryptonHeaderGroup3.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup3)).EndInit();
            this.kryptonHeaderGroup3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logEntryBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer1;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup2;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup3;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView kryptonDataGridView2;
        private System.Windows.Forms.BindingSource logEntryBindingSource1;
        private DataTree dataTree1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.ToolStripButton btnGenerate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
        private DisplayControl displayControl1;
        private System.Windows.Forms.TextBox txtOutputPath;
        private DisplayControl displayControl2;
        private System.Windows.Forms.TextBox txtNamespace;
        private System.Windows.Forms.ToolStripStatusLabel statusInfo;
        private System.ComponentModel.BackgroundWorker compileWorker;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton btnScriptSchema;
        private System.Windows.Forms.ToolStripMenuItem subSonicHomepageToolStripMenuItem;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton2;
        private DisplayControl displayControl3;
        private System.Windows.Forms.TextBox txtTemplatePath;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkPlural;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkCasing;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkGenSP;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkRemUnderscore;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkGenLazy;
        private System.Windows.Forms.GroupBox groupBox2;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkGenRelProps;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private DisplayControl displayControl4;
        private System.Windows.Forms.TextBox txtRegexMatch;
        private DisplayControl displayControl5;
        private System.Windows.Forms.TextBox txtRegexReplace;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkRegexIgnore;
        private DisplayControl displayControl6;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private DisplayControl displayControl7;
        private System.Windows.Forms.TextBox txtDictReplace;
    }
}

