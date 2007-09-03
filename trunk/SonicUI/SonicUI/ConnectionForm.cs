using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace SonicUI
{
    public partial class ConnectionForm : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public ConnectionForm()
        {
            InitializeComponent();
        }
        SubSonic.DataProvider provider = new SubSonic.SqlDataProvider();
        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            SubSonic.Commander.SubSommander.CreateConnection(txtServer.Text,
                txtUser.Text,
                txtPassword.Text,
                txtBase.Text);

            try
            {
                string[] tables = SubSonic.DataService.GetTableNames(SubSonic.DataService.Provider.Name);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                SubSonic.Commander.ApplicationLog.AddEntry(SubSonic.Commander.LogState.Error, ex.Message);
                kryptonLabel1.Text = "Error Connecting to datasource";
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void kryptonCheckSet1_CheckedButtonChanged(object sender, EventArgs e)
        {
            KryptonCheckButton cb = (KryptonCheckButton)kryptonCheckSet1.CheckedButton;
            switch (cb.Tag.ToString())
            {
                case "mssql":
                    provider = new SubSonic.SqlDataProvider();
                    break;
                case "mysql":
                    provider = new SubSonic.MySqlDataProvider();
                    break;
                default:
                    provider = new SubSonic.SqlDataProvider();
                    break;
            }
                
        }
    }
}