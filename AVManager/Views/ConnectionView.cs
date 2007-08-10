using System;
using System.Collections.Generic;
using System.Text;
using SubSonic;

namespace SubSonicManager.Views
{
    class ConnectionView:SubSonic.CPF.UI.EditViewControl
    {
        private SubSonic.CPF.UI.DisplayControl displayControl1;
        private System.Windows.Forms.TextBox txtServer;
        private ComponentFactory.Krypton.Toolkit.KryptonHeader kryptonHeader1;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtBase;
        private SubSonic.CPF.UI.DisplayControl displayControl4;
        private SubSonic.CPF.UI.DisplayControl displayControl3;
        private SubSonic.CPF.UI.DisplayControl displayControl2;
        private SubSonic.CPF.UI.DisplayControl displayControl5;
        private System.Windows.Forms.ComboBox cmbProvider;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnConnect;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel panel;
    
        public ConnectionView()
        {
            this.InitializeComponent();
            cmbProvider.DataSource = Enum.GetValues(typeof(ProviderTypes));
        }

        public override void Save()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionView));
            this.panel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnConnect = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.displayControl5 = new SubSonic.CPF.UI.DisplayControl();
            this.cmbProvider = new System.Windows.Forms.ComboBox();
            this.displayControl4 = new SubSonic.CPF.UI.DisplayControl();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.displayControl3 = new SubSonic.CPF.UI.DisplayControl();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.displayControl2 = new SubSonic.CPF.UI.DisplayControl();
            this.txtBase = new System.Windows.Forms.TextBox();
            this.kryptonHeader1 = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            this.displayControl1 = new SubSonic.CPF.UI.DisplayControl();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnConnect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeader1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.checkedListBox1);
            this.panel.Controls.Add(this.btnConnect);
            this.panel.Controls.Add(this.displayControl5);
            this.panel.Controls.Add(this.displayControl4);
            this.panel.Controls.Add(this.displayControl3);
            this.panel.Controls.Add(this.displayControl2);
            this.panel.Controls.Add(this.kryptonHeader1);
            this.panel.Controls.Add(this.displayControl1);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(499, 410);
            this.panel.TabIndex = 0;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(272, 267);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(90, 25);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Connect";
            this.btnConnect.Values.ExtraText = "";
            this.btnConnect.Values.Image = null;
            this.btnConnect.Values.ImageStates.ImageCheckedNormal = null;
            this.btnConnect.Values.ImageStates.ImageCheckedPressed = null;
            this.btnConnect.Values.ImageStates.ImageCheckedTracking = null;
            this.btnConnect.Values.Text = "Connect";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // displayControl5
            // 
            this.displayControl5.BackColor = System.Drawing.Color.Transparent;
            this.displayControl5.Caption = "Provider";
            this.displayControl5.Location = new System.Drawing.Point(16, 37);
            this.displayControl5.Name = "displayControl5";
            this.displayControl5.Padding = new System.Windows.Forms.Padding(2);
            this.displayControl5.Size = new System.Drawing.Size(173, 26);
            this.displayControl5.TabIndex = 5;
            this.displayControl5.ViewControl = this.cmbProvider;
            // 
            // cmbProvider
            // 
            this.cmbProvider.FormattingEnabled = true;
            this.cmbProvider.Location = new System.Drawing.Point(0, 0);
            this.cmbProvider.Name = "cmbProvider";
            this.cmbProvider.Size = new System.Drawing.Size(121, 21);
            this.cmbProvider.TabIndex = 6;
            // 
            // displayControl4
            // 
            this.displayControl4.BackColor = System.Drawing.Color.Transparent;
            this.displayControl4.Caption = "Password:";
            this.displayControl4.Location = new System.Drawing.Point(27, 159);
            this.displayControl4.Name = "displayControl4";
            this.displayControl4.Padding = new System.Windows.Forms.Padding(2);
            this.displayControl4.Size = new System.Drawing.Size(158, 27);
            this.displayControl4.TabIndex = 4;
            this.displayControl4.ViewControl = this.txtPass;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(0, 0);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(100, 20);
            this.txtPass.TabIndex = 7;
            // 
            // displayControl3
            // 
            this.displayControl3.BackColor = System.Drawing.Color.Transparent;
            this.displayControl3.Caption = "User: ";
            this.displayControl3.Location = new System.Drawing.Point(47, 129);
            this.displayControl3.Name = "displayControl3";
            this.displayControl3.Padding = new System.Windows.Forms.Padding(2);
            this.displayControl3.Size = new System.Drawing.Size(139, 24);
            this.displayControl3.TabIndex = 3;
            this.displayControl3.ViewControl = this.txtUser;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(0, 0);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(100, 20);
            this.txtUser.TabIndex = 6;
            // 
            // displayControl2
            // 
            this.displayControl2.BackColor = System.Drawing.Color.Transparent;
            this.displayControl2.Caption = "Database: ";
            this.displayControl2.Location = new System.Drawing.Point(24, 99);
            this.displayControl2.Name = "displayControl2";
            this.displayControl2.Padding = new System.Windows.Forms.Padding(2);
            this.displayControl2.Size = new System.Drawing.Size(164, 24);
            this.displayControl2.TabIndex = 2;
            this.displayControl2.ViewControl = this.txtBase;
            // 
            // txtBase
            // 
            this.txtBase.Location = new System.Drawing.Point(0, 0);
            this.txtBase.Name = "txtBase";
            this.txtBase.Size = new System.Drawing.Size(100, 20);
            this.txtBase.TabIndex = 5;
            // 
            // kryptonHeader1
            // 
            this.kryptonHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonHeader1.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeader1.Name = "kryptonHeader1";
            this.kryptonHeader1.Size = new System.Drawing.Size(499, 31);
            this.kryptonHeader1.TabIndex = 1;
            this.kryptonHeader1.Text = "Provider Setup";
            this.kryptonHeader1.Values.Description = "Description";
            this.kryptonHeader1.Values.Heading = "Provider Setup";
            this.kryptonHeader1.Values.Image = ((System.Drawing.Image)(resources.GetObject("kryptonHeader1.Values.Image")));
            // 
            // displayControl1
            // 
            this.displayControl1.BackColor = System.Drawing.Color.Transparent;
            this.displayControl1.Caption = "Server";
            this.displayControl1.Location = new System.Drawing.Point(45, 67);
            this.displayControl1.Name = "displayControl1";
            this.displayControl1.Padding = new System.Windows.Forms.Padding(2);
            this.displayControl1.Size = new System.Drawing.Size(146, 26);
            this.displayControl1.TabIndex = 0;
            this.displayControl1.ViewControl = this.txtServer;
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(0, 0);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(100, 20);
            this.txtServer.TabIndex = 1;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(295, 49);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(167, 169);
            this.checkedListBox1.TabIndex = 7;
            // 
            // ConnectionView
            // 
            this.Controls.Add(this.panel);
            this.Name = "ConnectionView";
            this.Size = new System.Drawing.Size(499, 410);
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnConnect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeader1)).EndInit();
            this.ResumeLayout(false);

        }


        private void btnConnect_Click(object sender, EventArgs e)
        {
            SubSonic.SubCommander.Database = txtBase.Text;
            SubSonic.SubCommander.Server = txtServer.Text;
            SubSonic.SubCommander.UserID = txtUser.Text;
            SubSonic.SubCommander.Password = txtPass.Text;
            SubSonic.SubCommander.SetProviderManually();
            string[] tables=null;
            checkedListBox1.Items.Clear();
            foreach (DataProvider provider in DataService.Providers)
            {
                tables = DataService.GetOrderedTableNames(provider.Name);
                if (tables != null)
                {
                    for (int i = 0; i < tables.Length; i++)
                    {
                        checkedListBox1.Items.Add(tables[i]);
                        //This is ugly but keeps the form responsive
                        System.Windows.Forms.Application.DoEvents();
                    }

                }
            }
            SubSonic.CPF.Utility.LogManager.Entries.Add(new SubSonic.CPF.Utility.LogEntry(SubSonic.CPF.Utility.LogState.Information,
                "Connection", string.Format("Loaded {0} tables", checkedListBox1.Items.Count)));
        }
    }
    public enum ProviderTypes
    {
        SqlServer,
        MySql,
        Oracle,
        SqlCE,
        SQLite,
        Enterprise2,
        Enterprise3
    }
}
