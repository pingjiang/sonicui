using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AVManager
{
    public partial class MainForm : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        Views.GridView _grid = new AVManager.Views.GridView();
        public MainForm()
        {
            InitializeComponent();
            logSource.DataSource = SubSonic.CPF.Utility.LogManager.Entries;
            _grid.Heading = "Data";
            SetupSources();
            presentationManager1.AddView(_grid);
            presentationManager1.ActiveView = _grid;
            AddInfoItem(SubSonic.CPF.Utility.LogState.Information, "SubSonic Manager", "Welcome to SubSonic Manager");
        }
        private void SetupSources()
        {
            objectTree.BeginUpdate();
            TreeNode _tables = new TreeNode("Tables");
            TreeNode _views = new TreeNode("Views");
            objectTree.Nodes.Add(_tables);
            objectTree.Nodes.Add(_views);
            foreach (string table in SubSonic.DataService.GetTableNames("Default"))
            {
                TreeNode tableNode = new TreeNode(table, 0, 0);
                tableNode.Tag = "Table";
                _tables.Nodes.Add(tableNode);
                
            }
            foreach (string view in SubSonic.DataService.GetViewNames("Default"))
            {
                TreeNode viewNode = new TreeNode(view, 0, 0);
                viewNode.Tag = "View";
                _views.Nodes.Add(viewNode);                
            }
            objectTree.EndUpdate();
        }
        void AddInfoItem(SubSonic.CPF.Utility.LogState State,string Title,string Description)
        {
            SubSonic.CPF.Utility.LogManager.Entries.Add(new SubSonic.CPF.Utility.LogEntry(State, Title, Description));
            
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void objectTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag.ToString() == "Table" || e.Node.Tag.ToString() == "View")
            {
                
                _grid.ActiveTable = e.Node.Text;
                _grid.LoadData();
            }
        }
    }
}