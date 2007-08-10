namespace AVManager.Controls
{
    partial class OptionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.OptionsFormSplit = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.CatGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.CatTree = new System.Windows.Forms.TreeView();
            this.OptionsPanelPath = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            this.OptionsSplitContainer = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.OptionPanelContainer = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.DescriptionPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.OptDescrSplit = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.OptionDescrLabel = new System.Windows.Forms.Label();
            this.AppRestartLabel = new System.Windows.Forms.Label();
            this.OKBtn = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.ApplyBtn = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.CancelBtn = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.OptionsFormSplit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OptionsFormSplit.Panel1)).BeginInit();
            this.OptionsFormSplit.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OptionsFormSplit.Panel2)).BeginInit();
            this.OptionsFormSplit.Panel2.SuspendLayout();
            this.OptionsFormSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CatGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CatGroup1.Panel)).BeginInit();
            this.CatGroup1.Panel.SuspendLayout();
            this.CatGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OptionsPanelPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OptionsSplitContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OptionsSplitContainer.Panel1)).BeginInit();
            this.OptionsSplitContainer.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OptionsSplitContainer.Panel2)).BeginInit();
            this.OptionsSplitContainer.Panel2.SuspendLayout();
            this.OptionsSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OptionPanelContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionPanel)).BeginInit();
            this.DescriptionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OptDescrSplit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OptDescrSplit.Panel1)).BeginInit();
            this.OptDescrSplit.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OptDescrSplit.Panel2)).BeginInit();
            this.OptDescrSplit.Panel2.SuspendLayout();
            this.OptDescrSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OKBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ApplyBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CancelBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // OptionsFormSplit
            // 
            this.OptionsFormSplit.Cursor = System.Windows.Forms.Cursors.Default;
            this.OptionsFormSplit.DirtyPaletteCounter = 29;
            this.OptionsFormSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OptionsFormSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.OptionsFormSplit.IsSplitterFixed = true;
            this.OptionsFormSplit.Location = new System.Drawing.Point(0, 0);
            this.OptionsFormSplit.Margin = new System.Windows.Forms.Padding(0);
            this.OptionsFormSplit.MinimumSize = new System.Drawing.Size(480, 375);
            this.OptionsFormSplit.Name = "OptionsFormSplit";
            // 
            // OptionsFormSplit.Panel1
            // 
            this.OptionsFormSplit.Panel1.Controls.Add(this.CatGroup1);
            this.OptionsFormSplit.Panel1MinSize = 125;
            // 
            // OptionsFormSplit.Panel2
            // 
            this.OptionsFormSplit.Panel2.Controls.Add(this.OptionsPanelPath);
            this.OptionsFormSplit.Panel2.Controls.Add(this.OptionsSplitContainer);
            this.OptionsFormSplit.Panel2.Controls.Add(this.OKBtn);
            this.OptionsFormSplit.Panel2.Controls.Add(this.ApplyBtn);
            this.OptionsFormSplit.Panel2.Controls.Add(this.CancelBtn);
            this.OptionsFormSplit.Panel2.Controls.Add(this.label2);
            this.OptionsFormSplit.Panel2MinSize = 350;
            this.OptionsFormSplit.Size = new System.Drawing.Size(675, 521);
            this.OptionsFormSplit.SplitterDistance = 150;
            this.OptionsFormSplit.TabIndex = 0;
            // 
            // CatGroup1
            // 
            this.CatGroup1.DirtyPaletteCounter = 25;
            this.CatGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CatGroup1.Location = new System.Drawing.Point(0, 0);
            this.CatGroup1.Name = "CatGroup1";
            // 
            // CatGroup1.Panel
            // 
            this.CatGroup1.Panel.Controls.Add(this.CatTree);
            this.CatGroup1.Size = new System.Drawing.Size(150, 521);
            this.CatGroup1.TabIndex = 0;
            this.CatGroup1.Text = "Settings";
            this.CatGroup1.ValuesPrimary.Description = "";
            this.CatGroup1.ValuesPrimary.Heading = "Settings";
            
            this.CatGroup1.ValuesSecondary.Description = "";
            this.CatGroup1.ValuesSecondary.Heading = "";
            this.CatGroup1.ValuesSecondary.Image = null;
            // 
            // CatTree
            // 
            this.CatTree.AccessibleDescription = "Options Categories.";
            this.CatTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CatTree.Location = new System.Drawing.Point(0, 0);
            this.CatTree.Name = "CatTree";
            this.CatTree.ShowLines = false;
            this.CatTree.Size = new System.Drawing.Size(148, 481);
            this.CatTree.TabIndex = 0;
            this.CatTree.Enter += new System.EventHandler(this.MouseEnterDescr);
            this.CatTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.CatTree_AfterSelect);
            this.CatTree.MouseEnter += new System.EventHandler(this.MouseEnterDescr);
            this.CatTree.Leave += new System.EventHandler(this.MouseLeaveDescr);
            this.CatTree.MouseLeave += new System.EventHandler(this.MouseLeaveDescr);
            // 
            // OptionsPanelPath
            // 
            this.OptionsPanelPath.AccessibleDescription = "This box shows the options path for the current options panel.";
            this.OptionsPanelPath.DirtyPaletteCounter = 24;
            this.OptionsPanelPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.OptionsPanelPath.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OptionsPanelPath.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.OptionsPanelPath.Location = new System.Drawing.Point(0, 0);
            this.OptionsPanelPath.Name = "OptionsPanelPath";
            this.OptionsPanelPath.Padding = new System.Windows.Forms.Padding(10, 6, 0, 6);
            this.OptionsPanelPath.Size = new System.Drawing.Size(520, 31);
            this.OptionsPanelPath.TabIndex = 8;
            this.OptionsPanelPath.Text = "Options » Path";
            this.OptionsPanelPath.Values.Description = "Description";
            this.OptionsPanelPath.Values.Heading = "Options » Path";
            this.OptionsPanelPath.Values.Image = null;
            this.OptionsPanelPath.Visible = false;
            this.OptionsPanelPath.MouseLeave += new System.EventHandler(this.MouseLeaveDescr);
            this.OptionsPanelPath.MouseEnter += new System.EventHandler(this.MouseEnterDescr);
            // 
            // OptionsSplitContainer
            // 
            this.OptionsSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.OptionsSplitContainer.Cursor = System.Windows.Forms.Cursors.Default;
            this.OptionsSplitContainer.DirtyPaletteCounter = 29;
            this.OptionsSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.OptionsSplitContainer.IsSplitterFixed = true;
            this.OptionsSplitContainer.Location = new System.Drawing.Point(3, 37);
            this.OptionsSplitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.OptionsSplitContainer.MinimumSize = new System.Drawing.Size(340, 288);
            this.OptionsSplitContainer.Name = "OptionsSplitContainer";
            this.OptionsSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // OptionsSplitContainer.Panel1
            // 
            this.OptionsSplitContainer.Panel1.Controls.Add(this.OptionPanelContainer);
            this.OptionsSplitContainer.Panel1MinSize = 215;
            // 
            // OptionsSplitContainer.Panel2
            // 
            this.OptionsSplitContainer.Panel2.Controls.Add(this.DescriptionPanel);
            this.OptionsSplitContainer.Panel2MinSize = 64;
            this.OptionsSplitContainer.Size = new System.Drawing.Size(510, 434);
            this.OptionsSplitContainer.SplitterDistance = 323;
            this.OptionsSplitContainer.SplitterWidth = 8;
            this.OptionsSplitContainer.TabIndex = 7;
            // 
            // OptionPanelContainer
            // 
            this.OptionPanelContainer.AutoScroll = true;
            this.OptionPanelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OptionPanelContainer.Location = new System.Drawing.Point(0, 0);
            this.OptionPanelContainer.Margin = new System.Windows.Forms.Padding(0);
            this.OptionPanelContainer.MinimumSize = new System.Drawing.Size(340, 215);
            this.OptionPanelContainer.Name = "OptionPanelContainer";
            this.OptionPanelContainer.Size = new System.Drawing.Size(510, 323);
            this.OptionPanelContainer.TabIndex = 5;
            // 
            // DescriptionPanel
            // 
            this.DescriptionPanel.Controls.Add(this.OptDescrSplit);
            this.DescriptionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DescriptionPanel.Location = new System.Drawing.Point(0, 0);
            this.DescriptionPanel.Name = "DescriptionPanel";
            this.DescriptionPanel.Size = new System.Drawing.Size(510, 103);
            this.DescriptionPanel.TabIndex = 4;
            // 
            // OptDescrSplit
            // 
            this.OptDescrSplit.BackColor = System.Drawing.SystemColors.ControlLight;
            this.OptDescrSplit.DirtyPaletteCounter = 28;
            this.OptDescrSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OptDescrSplit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.OptDescrSplit.IsSplitterFixed = true;
            this.OptDescrSplit.Location = new System.Drawing.Point(0, 0);
            this.OptDescrSplit.Margin = new System.Windows.Forms.Padding(0);
            this.OptDescrSplit.MaximumSize = new System.Drawing.Size(0, 64);
            this.OptDescrSplit.Name = "OptDescrSplit";
            this.OptDescrSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // OptDescrSplit.Panel1
            // 
            this.OptDescrSplit.Panel1.Controls.Add(this.OptionDescrLabel);
            this.OptDescrSplit.Panel1MinSize = 35;
            // 
            // OptDescrSplit.Panel2
            // 
            this.OptDescrSplit.Panel2.Controls.Add(this.AppRestartLabel);
            this.OptDescrSplit.Panel2Collapsed = true;
            this.OptDescrSplit.Panel2MinSize = 17;
            this.OptDescrSplit.Size = new System.Drawing.Size(510, 64);
            this.OptDescrSplit.SplitterDistance = 21;
            this.OptDescrSplit.SplitterWidth = 1;
            this.OptDescrSplit.TabIndex = 0;
            // 
            // OptionDescrLabel
            // 
            this.OptionDescrLabel.AccessibleDescription = "This box shows a short description for each control.";
            this.OptionDescrLabel.AutoEllipsis = true;
            this.OptionDescrLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OptionDescrLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.OptionDescrLabel.Location = new System.Drawing.Point(0, 0);
            this.OptionDescrLabel.Name = "OptionDescrLabel";
            this.OptionDescrLabel.Size = new System.Drawing.Size(510, 64);
            this.OptionDescrLabel.TabIndex = 0;
            this.OptionDescrLabel.Text = "Description.";
            this.OptionDescrLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.OptionDescrLabel.MouseLeave += new System.EventHandler(this.MouseLeaveDescr);
            this.OptionDescrLabel.MouseEnter += new System.EventHandler(this.MouseEnterDescr);
            // 
            // AppRestartLabel
            // 
            this.AppRestartLabel.AccessibleDescription = "This box indicates that the application must restart in order for changes to take" +
                " effect.";
            this.AppRestartLabel.AutoEllipsis = true;
            this.AppRestartLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AppRestartLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppRestartLabel.ForeColor = System.Drawing.Color.Crimson;
            this.AppRestartLabel.Location = new System.Drawing.Point(0, 0);
            this.AppRestartLabel.Name = "AppRestartLabel";
            this.AppRestartLabel.Size = new System.Drawing.Size(0, 64);
            this.AppRestartLabel.TabIndex = 1;
            this.AppRestartLabel.Text = "Application must restart for changes to take effect.";
            this.AppRestartLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AppRestartLabel.MouseLeave += new System.EventHandler(this.MouseLeaveDescr);
            this.AppRestartLabel.MouseEnter += new System.EventHandler(this.MouseEnterDescr);
            // 
            // OKBtn
            // 
            this.OKBtn.AccessibleDescription = "Apply changes and close the options form.";
            this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKBtn.DirtyPaletteCounter = 27;
            this.OKBtn.Location = new System.Drawing.Point(276, 488);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(75, 24);
            this.OKBtn.TabIndex = 2;
            this.OKBtn.Text = "&OK";
            this.OKBtn.Values.ExtraText = "";
            this.OKBtn.Values.Image = null;
            this.OKBtn.Values.ImageStates.ImageCheckedNormal = null;
            this.OKBtn.Values.ImageStates.ImageCheckedPressed = null;
            this.OKBtn.Values.ImageStates.ImageCheckedTracking = null;
            this.OKBtn.Values.Text = "&OK";
            this.OKBtn.MouseLeave += new System.EventHandler(this.MouseLeaveDescr);
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            this.OKBtn.MouseEnter += new System.EventHandler(this.MouseEnterDescr);
            // 
            // ApplyBtn
            // 
            this.ApplyBtn.AccessibleDescription = "Apply changes.";
            this.ApplyBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ApplyBtn.DirtyPaletteCounter = 27;
            this.ApplyBtn.Enabled = false;
            this.ApplyBtn.Location = new System.Drawing.Point(355, 488);
            this.ApplyBtn.Name = "ApplyBtn";
            this.ApplyBtn.Size = new System.Drawing.Size(75, 24);
            this.ApplyBtn.TabIndex = 6;
            this.ApplyBtn.Text = "A&pply";
            this.ApplyBtn.Values.ExtraText = "";
            this.ApplyBtn.Values.Image = null;
            this.ApplyBtn.Values.ImageStates.ImageCheckedNormal = null;
            this.ApplyBtn.Values.ImageStates.ImageCheckedPressed = null;
            this.ApplyBtn.Values.ImageStates.ImageCheckedTracking = null;
            this.ApplyBtn.Values.Text = "A&pply";
            this.ApplyBtn.MouseLeave += new System.EventHandler(this.MouseLeaveDescr);
            this.ApplyBtn.Click += new System.EventHandler(this.ApplyBtn_Click);
            this.ApplyBtn.MouseEnter += new System.EventHandler(this.MouseEnterDescr);
            // 
            // CancelBtn
            // 
            this.CancelBtn.AccessibleDescription = "Cancel changes and close options form.";
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.DirtyPaletteCounter = 27;
            this.CancelBtn.Location = new System.Drawing.Point(434, 488);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 24);
            this.CancelBtn.TabIndex = 1;
            this.CancelBtn.Text = "&Cancel";
            this.CancelBtn.Values.ExtraText = "";
            this.CancelBtn.Values.Image = null;
            this.CancelBtn.Values.ImageStates.ImageCheckedNormal = null;
            this.CancelBtn.Values.ImageStates.ImageCheckedPressed = null;
            this.CancelBtn.Values.ImageStates.ImageCheckedTracking = null;
            this.CancelBtn.Values.Text = "&Cancel";
            this.CancelBtn.MouseLeave += new System.EventHandler(this.MouseLeaveDescr);
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            this.CancelBtn.MouseEnter += new System.EventHandler(this.MouseEnterDescr);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(3, 481);
            this.label2.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(509, 2);
            this.label2.TabIndex = 0;
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 521);
            this.Controls.Add(this.OptionsFormSplit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(486, 407);
            this.Name = "OptionsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionsForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.OptionsFormSplit.Panel1)).EndInit();
            this.OptionsFormSplit.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OptionsFormSplit.Panel2)).EndInit();
            this.OptionsFormSplit.Panel2.ResumeLayout(false);
            this.OptionsFormSplit.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OptionsFormSplit)).EndInit();
            this.OptionsFormSplit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CatGroup1.Panel)).EndInit();
            this.CatGroup1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CatGroup1)).EndInit();
            this.CatGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OptionsPanelPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OptionsSplitContainer.Panel1)).EndInit();
            this.OptionsSplitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OptionsSplitContainer.Panel2)).EndInit();
            this.OptionsSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OptionsSplitContainer)).EndInit();
            this.OptionsSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OptionPanelContainer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DescriptionPanel)).EndInit();
            this.DescriptionPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OptDescrSplit.Panel1)).EndInit();
            this.OptDescrSplit.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OptDescrSplit.Panel2)).EndInit();
            this.OptDescrSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OptDescrSplit)).EndInit();
            this.OptDescrSplit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OKBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ApplyBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CancelBtn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer OptionsFormSplit;
        private System.Windows.Forms.Label label2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton OKBtn;
        private ComponentFactory.Krypton.Toolkit.KryptonButton CancelBtn;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel DescriptionPanel;
        private System.Windows.Forms.Label AppRestartLabel;
        private System.Windows.Forms.Label OptionDescrLabel;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel OptionPanelContainer;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer OptDescrSplit;
        private ComponentFactory.Krypton.Toolkit.KryptonButton ApplyBtn;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer OptionsSplitContainer;
        private ComponentFactory.Krypton.Toolkit.KryptonHeader OptionsPanelPath;
        private System.Windows.Forms.TreeView CatTree;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup CatGroup1;
    }
}