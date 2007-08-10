using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using SubSonic;

namespace AVManager.Views
{
    class GridView:SubSonic.CPF.UI.ListViewControl
    {
        private ComponentFactory.Krypton.Toolkit.KryptonHeader kryptonHeader1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView kryptonDataGridView1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel panel;
    
        public GridView()
        {
            SetStyle(System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer, true);
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GridView));
            this.panel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonDataGridView1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.kryptonHeader1 = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeader1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.kryptonDataGridView1);
            this.panel.Controls.Add(this.kryptonHeader1);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(499, 410);
            this.panel.TabIndex = 0;
            // 
            // kryptonDataGridView1
            // 
            this.kryptonDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.kryptonDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonDataGridView1.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Sheet;
            this.kryptonDataGridView1.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundSheet;
            this.kryptonDataGridView1.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.kryptonDataGridView1.GridStyles.StyleDataCells = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.kryptonDataGridView1.GridStyles.StyleRow = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.kryptonDataGridView1.Location = new System.Drawing.Point(0, 31);
            this.kryptonDataGridView1.Name = "kryptonDataGridView1";
            this.kryptonDataGridView1.Size = new System.Drawing.Size(499, 379);
            this.kryptonDataGridView1.StateCommon.Background.Color1 = System.Drawing.Color.White;
            this.kryptonDataGridView1.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundSheet;
            this.kryptonDataGridView1.TabIndex = 2;
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
            // GridView
            // 
            this.Controls.Add(this.panel);
            this.Name = "GridView";
            this.Size = new System.Drawing.Size(499, 410);
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeader1)).EndInit();
            this.ResumeLayout(false);

        }
        string _activeTable;
        public string ActiveTable
        {
            get { return _activeTable; }
            set
            {
                _activeTable = value;
                Heading = SubSonic.Sugar.Strings.EntityToText(_activeTable);
            }
        }
        public override void LoadData()
        {
            if (!string.IsNullOrEmpty(_activeTable))
            FetchData();
        }
        void FetchData()
        {
            DataTable table = new DataTable();
            SubSonic.Query qry = new Query(_activeTable);
            SubSonic.QueryEngine.SqlQuery sq = new SubSonic.QueryEngine.SqlQuery();
            
            table.Load(qry.ExecuteReader());
            kryptonDataGridView1.Columns.Clear();
            kryptonDataGridView1.DataSource = table;
            kryptonHeader1.Values.Description = "Loaded Records";
        }
        public override void RefreshData()
        {
            if(!string.IsNullOrEmpty(_activeTable))
                FetchData();
        }
        public string Heading
        {
            get { return kryptonHeader1.Values.Heading; }
            set { kryptonHeader1.Values.Heading = value; }
        }
        public override void New()
        {
            //Used when creating a new object 
        }
    }
}
