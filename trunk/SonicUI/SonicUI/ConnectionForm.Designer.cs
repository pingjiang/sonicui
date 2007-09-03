namespace SonicUI
{
    partial class ConnectionForm
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
            this.kryptonManager = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.kryptonPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.displayControl5 = new SonicUI.DisplayControl();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonCheckButton4 = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.kryptonCheckButton3 = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.kryptonCheckButton1 = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.displayControl4 = new SonicUI.DisplayControl();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.displayControl3 = new SonicUI.DisplayControl();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.displayControl2 = new SonicUI.DisplayControl();
            this.txtBase = new System.Windows.Forms.TextBox();
            this.displayControl1 = new SonicUI.DisplayControl();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.kryptonCheckSet1 = new ComponentFactory.Krypton.Toolkit.KryptonCheckSet(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).BeginInit();
            this.kryptonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonCheckButton4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonCheckButton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonCheckButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonManager
            // 
            this.kryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2007Black;
            // 
            // kryptonPanel
            // 
            this.kryptonPanel.Controls.Add(this.displayControl5);
            this.kryptonPanel.Controls.Add(this.kryptonButton1);
            this.kryptonPanel.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel.Controls.Add(this.kryptonCheckButton4);
            this.kryptonPanel.Controls.Add(this.kryptonCheckButton3);
            this.kryptonPanel.Controls.Add(this.kryptonCheckButton1);
            this.kryptonPanel.Controls.Add(this.displayControl4);
            this.kryptonPanel.Controls.Add(this.displayControl3);
            this.kryptonPanel.Controls.Add(this.displayControl2);
            this.kryptonPanel.Controls.Add(this.displayControl1);
            this.kryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel.Name = "kryptonPanel";
            this.kryptonPanel.Size = new System.Drawing.Size(389, 250);
            this.kryptonPanel.TabIndex = 0;
            // 
            // displayControl5
            // 
            this.displayControl5.BackColor = System.Drawing.Color.Transparent;
            this.displayControl5.Caption = "Provider Name";
            this.displayControl5.ForeColor = System.Drawing.Color.White;
            this.displayControl5.Location = new System.Drawing.Point(20, 134);
            this.displayControl5.Name = "displayControl5";
            this.displayControl5.Padding = new System.Windows.Forms.Padding(2);
            this.displayControl5.Size = new System.Drawing.Size(200, 24);
            this.displayControl5.TabIndex = 10;
            this.displayControl5.ViewControl = this.textBox1;
            this.displayControl5.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(116, 20);
            this.textBox1.TabIndex = 11;
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Location = new System.Drawing.Point(280, 199);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(106, 39);
            this.kryptonButton1.TabIndex = 9;
            this.kryptonButton1.Text = "Connect";
            this.kryptonButton1.Values.ExtraText = "";
            this.kryptonButton1.Values.Image = global::SonicUI.Properties.Resources.connect_creating;
            this.kryptonButton1.Values.ImageStates.ImageCheckedNormal = null;
            this.kryptonButton1.Values.ImageStates.ImageCheckedPressed = null;
            this.kryptonButton1.Values.ImageStates.ImageCheckedTracking = null;
            this.kryptonButton1.Values.Text = "Connect";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalPanel;
            this.kryptonLabel1.Location = new System.Drawing.Point(13, 219);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(145, 20);
            this.kryptonLabel1.TabIndex = 8;
            this.kryptonLabel1.Text = "Enter Connection Details";
            this.kryptonLabel1.Values.ExtraText = "";
            this.kryptonLabel1.Values.Image = null;
            this.kryptonLabel1.Values.Text = "Enter Connection Details";
            // 
            // kryptonCheckButton4
            // 
            this.kryptonCheckButton4.Location = new System.Drawing.Point(296, 46);
            this.kryptonCheckButton4.Name = "kryptonCheckButton4";
            this.kryptonCheckButton4.Size = new System.Drawing.Size(90, 25);
            this.kryptonCheckButton4.TabIndex = 7;
            this.kryptonCheckButton4.Tag = "mysql";
            this.kryptonCheckButton4.Text = "MySQL";
            this.kryptonCheckButton4.Values.ExtraText = "";
            this.kryptonCheckButton4.Values.Image = null;
            this.kryptonCheckButton4.Values.Text = "MySQL";
            // 
            // kryptonCheckButton3
            // 
            this.kryptonCheckButton3.Location = new System.Drawing.Point(296, 77);
            this.kryptonCheckButton3.Name = "kryptonCheckButton3";
            this.kryptonCheckButton3.Size = new System.Drawing.Size(90, 25);
            this.kryptonCheckButton3.TabIndex = 6;
            this.kryptonCheckButton3.Tag = "sqlce";
            this.kryptonCheckButton3.Text = "SQL CE";
            this.kryptonCheckButton3.Values.ExtraText = "";
            this.kryptonCheckButton3.Values.Image = null;
            this.kryptonCheckButton3.Values.Text = "SQL CE";
            this.kryptonCheckButton3.Visible = false;
            // 
            // kryptonCheckButton1
            // 
            this.kryptonCheckButton1.Checked = true;
            this.kryptonCheckButton1.Location = new System.Drawing.Point(296, 15);
            this.kryptonCheckButton1.Name = "kryptonCheckButton1";
            this.kryptonCheckButton1.Size = new System.Drawing.Size(90, 25);
            this.kryptonCheckButton1.TabIndex = 4;
            this.kryptonCheckButton1.Tag = "mssql";
            this.kryptonCheckButton1.Text = "MSSQL";
            this.kryptonCheckButton1.Values.ExtraText = "";
            this.kryptonCheckButton1.Values.Image = null;
            this.kryptonCheckButton1.Values.Text = "MSSQL";
            // 
            // displayControl4
            // 
            this.displayControl4.BackColor = System.Drawing.Color.Transparent;
            this.displayControl4.Caption = "Password";
            this.displayControl4.ForeColor = System.Drawing.Color.White;
            this.displayControl4.Location = new System.Drawing.Point(19, 103);
            this.displayControl4.Name = "displayControl4";
            this.displayControl4.Padding = new System.Windows.Forms.Padding(2);
            this.displayControl4.Size = new System.Drawing.Size(201, 24);
            this.displayControl4.TabIndex = 3;
            this.displayControl4.ViewControl = this.txtPassword;
            // 
            // txtPassword
            // 
            this.txtPassword.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtPassword.Location = new System.Drawing.Point(0, 0);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(117, 20);
            this.txtPassword.TabIndex = 7;
            // 
            // displayControl3
            // 
            this.displayControl3.BackColor = System.Drawing.Color.Transparent;
            this.displayControl3.Caption = "User ID";
            this.displayControl3.ForeColor = System.Drawing.Color.White;
            this.displayControl3.Location = new System.Drawing.Point(19, 73);
            this.displayControl3.Name = "displayControl3";
            this.displayControl3.Padding = new System.Windows.Forms.Padding(2);
            this.displayControl3.Size = new System.Drawing.Size(201, 24);
            this.displayControl3.TabIndex = 2;
            this.displayControl3.ViewControl = this.txtUser;
            // 
            // txtUser
            // 
            this.txtUser.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtUser.Location = new System.Drawing.Point(0, 0);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(117, 20);
            this.txtUser.TabIndex = 6;
            // 
            // displayControl2
            // 
            this.displayControl2.BackColor = System.Drawing.Color.Transparent;
            this.displayControl2.Caption = "Database";
            this.displayControl2.ForeColor = System.Drawing.Color.White;
            this.displayControl2.Location = new System.Drawing.Point(19, 43);
            this.displayControl2.Name = "displayControl2";
            this.displayControl2.Padding = new System.Windows.Forms.Padding(2);
            this.displayControl2.Size = new System.Drawing.Size(199, 24);
            this.displayControl2.TabIndex = 1;
            this.displayControl2.ViewControl = this.txtBase;
            // 
            // txtBase
            // 
            this.txtBase.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtBase.Location = new System.Drawing.Point(0, 0);
            this.txtBase.Name = "txtBase";
            this.txtBase.Size = new System.Drawing.Size(115, 20);
            this.txtBase.TabIndex = 5;
            // 
            // displayControl1
            // 
            this.displayControl1.BackColor = System.Drawing.Color.Transparent;
            this.displayControl1.Caption = "Server";
            this.displayControl1.ForeColor = System.Drawing.Color.White;
            this.displayControl1.Location = new System.Drawing.Point(19, 13);
            this.displayControl1.Name = "displayControl1";
            this.displayControl1.Padding = new System.Windows.Forms.Padding(2);
            this.displayControl1.Size = new System.Drawing.Size(199, 24);
            this.displayControl1.TabIndex = 0;
            this.displayControl1.ViewControl = this.txtServer;
            // 
            // txtServer
            // 
            this.txtServer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtServer.Location = new System.Drawing.Point(0, 0);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(115, 20);
            this.txtServer.TabIndex = 4;
            // 
            // kryptonCheckSet1
            // 
            this.kryptonCheckSet1.CheckButtons.Add(this.kryptonCheckButton1);
            this.kryptonCheckSet1.CheckButtons.Add(this.kryptonCheckButton3);
            this.kryptonCheckSet1.CheckButtons.Add(this.kryptonCheckButton4);
            this.kryptonCheckSet1.CheckedButton = this.kryptonCheckButton1;
            this.kryptonCheckSet1.CheckedButtonChanged += new System.EventHandler(this.kryptonCheckSet1_CheckedButtonChanged);
            // 
            // ConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 250);
            this.Controls.Add(this.kryptonPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ConnectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect to DataSource";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).EndInit();
            this.kryptonPanel.ResumeLayout(false);
            this.kryptonPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonCheckButton4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonCheckButton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonCheckButton1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel;
        private DisplayControl displayControl4;
        private System.Windows.Forms.TextBox txtPassword;
        private DisplayControl displayControl3;
        private System.Windows.Forms.TextBox txtUser;
        private DisplayControl displayControl2;
        private System.Windows.Forms.TextBox txtBase;
        private DisplayControl displayControl1;
        private System.Windows.Forms.TextBox txtServer;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton kryptonCheckButton4;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton kryptonCheckButton3;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton kryptonCheckButton1;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckSet kryptonCheckSet1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private DisplayControl displayControl5;
        private System.Windows.Forms.TextBox textBox1;
    }
}

