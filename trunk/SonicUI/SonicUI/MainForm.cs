using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using SubSonic.Commander;
using System.Diagnostics;
using Office2007MessageBox;

namespace SonicUI
{
    public partial class MainForm : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        const int splitDistance = 200;
        public MainForm()
        {
            InitializeComponent();
            this.SuspendLayout();
            ApplicationLog.EntryAdded += new EventHandler(ApplicationLog_EntryAdded);
            kryptonDataGridView2.DataSource = ApplicationLog.Entries;
            kryptonDataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ApplicationLog.AddEntry(LogState.Information, "Welcome to SonicUI");
            cmbLanguage.SelectedIndex = 0;
            
            this.ResumeLayout();
        }

        void ApplicationLog_EntryAdded(object sender, EventArgs e)
        {
            kryptonDataGridView2.Refresh();
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Connect();
        }
        void Connect()
        {
            ConnectionForm conn = new ConnectionForm();
            DialogResult dr = conn.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                dataTree1.LoadData();
                SensitizeControls();
                SubSommander.OutputPath = Application.StartupPath + @"\Output";
            }
        }
        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (kryptonSplitContainer1.SplitterDistance != splitDistance)
                kryptonSplitContainer1.SplitterDistance = splitDistance;

        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            statusInfo.Text = "Generating DAL ...";
            SubSommander.IncludeTables = dataTree1.SelectedTables;
            if(!string.IsNullOrEmpty(txtTemplatePath.Text))
                SubSommander.TemplatePath = txtTemplatePath.Text;
            if(!string.IsNullOrEmpty(txtOutputPath.Text))
                SubSommander.OutputPath = txtOutputPath.Text;
            switch (cmbLanguage.SelectedIndex)
            {
                case 0:
                    SubSommander.Language = "cs";
                    break;
                case 1:
                    SubSommander.Language = "vb";
                    break;
            }
            SubSommander.FixCasing = chkCasing.Checked;
            SubSommander.FixPlural = chkPlural.Checked;
            SubSommander.GenerateSP = chkGenSP.Checked;
            SubSommander.GenRelationProperties = chkGenRelProps.Checked;
            SubSommander.LazyLoad = chkGenLazy.Checked;
            SubSommander.RegexIgnoreCase = chkRegexIgnore.Checked;
            SubSommander.RegexMatch = txtRegexMatch.Text;
            SubSommander.RegexReplace = txtRegexReplace.Text;
            SubSommander.RemoveUnderScore = chkRemUnderscore.Checked;
            SubSommander.RegexDictReplace = txtDictReplace.Text;
            compileWorker.RunWorkerAsync();
            
        }
        void Generate()
        {
            //Invokes the grid onto the same thread as the operation so that we still see the log info as it happens
            this.kryptonDataGridView2.BeginInvoke((MethodInvoker)delegate()
            {
                SubSommander.RefreshProviders();
                SubSommander.GenerateAll();
                SubSommander.Compile();
                
            });
        }
        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult dr = fbd.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                txtOutputPath.Text = fbd.SelectedPath;
                SubSommander.OutputPath = txtOutputPath.Text;
            }
        }
        void setStatus(string text)
        {
            if (statusStrip1.InvokeRequired)
            {
                statusStrip1.BeginInvoke((MethodInvoker)delegate()
                {
                    statusInfo.Text = text;
                });
            }
            else
                statusInfo.Text = text;
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            SubSommander.Namespace = txtNamespace.Text;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void kryptonDataGridView2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            
            //int lastrow = kryptonDataGridView2.Rows.Count - 1;
            //kryptonDataGridView2.FirstDisplayedScrollingRowIndex = lastrow;
        }

        private void compileWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Generate();
        }

        private void compileWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            setStatus("Finished");
            MessageBox.Show("Generation Complete","Compile",MessageBoxButtons.OK,MessageBoxIcon.Information);
            //MessageBox.Show("Generation Complete");
        }
        void SensitizeControls()
        {
            
            kryptonHeaderGroup3.Panel.Enabled = true;
            btnGenerate.Enabled = true;
            if (SubSonic.DataService.Provider.GetType() == typeof(SubSonic.SqlDataProvider))
                btnScriptSchema.Enabled = true;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void btnScriptSchema_Click(object sender, EventArgs e)
        {
            SubSommander.ScriptSchema();
            MessageBox.Show("Schema Written", "SQL Schema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog(this);
        }

        private void subSonicHomepageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.subsonicproject.com");
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult dr = fbd.ShowDialog(this);
            if (dr == DialogResult.OK)
                txtTemplatePath.Text = fbd.SelectedPath;
        }
    }
}