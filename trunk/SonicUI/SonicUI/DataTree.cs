using SubSonic;
using System;
using System.Windows.Forms;

namespace SonicUI
{
    public partial class DataTree : UserControl
    {
        public DataTree()
        {
            InitializeComponent();
        }
        TreeNode tableHolder;
        TreeNode viewHolder;
        public void LoadData()
        {
            treeView1.BeginUpdate();
            treeView1.Nodes.Clear();
            TreeNode rootNode = new TreeNode("DataSources");
            rootNode.ImageIndex = 0;
            rootNode.SelectedImageIndex = 0;
            treeView1.Nodes.Add(rootNode);
            foreach (DataProvider provider in DataService.Providers)
            {
                TreeNode sourceNode = new TreeNode(provider.Name);
                rootNode.Nodes.Add(sourceNode);
                sourceNode.SelectedImageIndex = 1;
                sourceNode.ImageIndex = 1;
                SubSonic.TableSchema.Table[] tables = DataService.GetTables(provider.Name);
                TreeNode tableNode = new TreeNode("Tables");
                tableNode.Tag = "TABLE";
                tableNode.ImageIndex = 1;
                tableNode.SelectedImageIndex=1;
                tableHolder = tableNode;
                TreeNode viewNode = new TreeNode("Views");
                viewNode.Tag = "VIEW";
                viewNode.SelectedImageIndex = 2;
                viewNode.SelectedImageIndex = 2;
                viewHolder = viewNode;
                sourceNode.Nodes.AddRange(new TreeNode[]{tableNode,viewNode});
                for (int i = 0; i < tables.Length; i++)
                {
                    SubSonic.TableSchema.Table table = tables[i];
                    TreeNode objectNode = new TreeNode();
                    objectNode.Text = table.TableName;
                    objectNode.Tag = table;
                    objectNode.Checked = true;
                    tableNode.Nodes.Add(objectNode);
                }
                string[] views = DataService.GetViewNames(provider.Name);
                for (int vi = 0; vi < views.Length; vi++)
                {
                    TreeNode objectNode = new TreeNode(views[vi]);
                    objectNode.Checked = true;
                    viewNode.Nodes.Add(objectNode);
                }
                SubSonic.Commander.ApplicationLog.AddEntry(SubSonic.Commander.LogState.Information,string.Format("Loaded {0} tables",tables.Length));
            }
            
            treeView1.EndUpdate();
        }
        public string SelectedTables
        {
            get
            {
                string tables = string.Empty;
                if (treeView1.Nodes.Count > 0)
                {
                    for (int i = 0; i < tableHolder.Nodes.Count; i++)
                    {
                        TreeNode child = tableHolder.Nodes[i];
                        if (child.Checked)
                            tables += child.Text + ",";
                    }

                }
                return tables.TrimEnd(new char[1]{','});
            }
        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.BeginUpdate();
            for (int i = 0; i < tableHolder.Nodes.Count; i++)
            {
                tableHolder.Nodes[i].Checked = true;
            }
            for (int vi = 0; vi < viewHolder.Nodes.Count; vi++)
            {
                viewHolder.Nodes[vi].Checked = true;
            }
            treeView1.EndUpdate();
        }

        private void deselectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.BeginUpdate();
            for (int i = 0; i < tableHolder.Nodes.Count; i++)
            {
                tableHolder.Nodes[i].Checked = false;
            }
            for (int vi = 0; vi < viewHolder.Nodes.Count; vi++)
            {
                viewHolder.Nodes[vi].Checked = false;
            }
            treeView1.EndUpdate();
        }
    }
}
