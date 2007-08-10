using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SubSonic;

namespace SubCommanderUI
{
    public partial class MainForm : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public MainForm()
        {
            InitializeComponent();
            logSource.DataSource = SubSonic.CPF.Utility.LogManager.Entries;
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            Connect();

        }
        private bool _connected = false;
        void Connect()
        {
            _connected = false;
            SubSonic.SubCommander.Server = txtServer.Text;
            SubSonic.SubCommander.Database = txtDatabase.Text;
            SubSonic.SubCommander.Password = txtPass.Text;
            SubSonic.SubCommander.UserID = txtUser.Text;
            SubSonic.SubCommander.SetProviderManually();
            SubCommander.NameSpace = txtNSpace.Text;
            string[] tables = null;
            checkedListBox1.Items.Clear();
            try
            {
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
                _connected = true;
                SubSonic.CPF.Utility.LogManager.Entries.Add(new SubSonic.CPF.Utility.LogEntry(SubSonic.CPF.Utility.LogState.Information,
                    "Connection", string.Format("Loaded {0} tables", checkedListBox1.Items.Count)));
            }
            catch (Exception ex)
            {
                SubSonic.CPF.Utility.LogManager.Entries.Add(new SubSonic.CPF.Utility.LogEntry(SubSonic.CPF.Utility.LogState.Error, "Connection", ex.Message));
            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SubSonic.CPF.Utility.LogManager.Clear();
        }

        private void kryptonDataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (kryptonDataGridView1.Columns[e.ColumnIndex].HeaderText.Equals("Status"))
            {
                SubSonic.CPF.Utility.LogState _state = (SubSonic.CPF.Utility.LogState)e.Value;
                DataGridViewCell cell = kryptonDataGridView1[e.ColumnIndex, e.RowIndex];
                switch (_state)
                {
                    case SubSonic.CPF.Utility.LogState.Warning:
                        e.CellStyle.BackColor = Color.Orange;
                        break;
                    case SubSonic.CPF.Utility.LogState.Error:
                        e.CellStyle.BackColor = Color.Red;
                        break;
                    case SubSonic.CPF.Utility.LogState.Information:
                        e.CellStyle.BackColor = Color.LightSteelBlue;
                        break;
                }
            }
        }

        private void displayControl4_MouseMove(object sender, MouseEventArgs e)
        {
    
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            codeWorker.RunWorkerAsync();
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult dr = fbd.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                txtOutput.Text = fbd.SelectedPath;
            }
        }

        private void logSource_ListChanged(object sender, ListChangedEventArgs e)
        {

        }
        private void codeWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (_connected)
            {
                //Invoke the grid to the same thread as the worker to make the Interface more responsive
                kryptonDataGridView1.BeginInvoke((MethodInvoker)delegate()
                {
                    SubCommander.OutPutDirectory = txtOutput.Text;
                    SubCommander.GenerateAll();
                });
            }
        }
    }
}