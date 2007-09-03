using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SonicUI
{
    [Designer(typeof(System.Windows.Forms.Design.ParentControlDesigner))]
    public partial class DisplayControl : UserControl
    {
        public DisplayControl()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            InitializeComponent();
            BackColor = Color.Transparent;
         
        }

        public string Caption
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }
        private Control _control;

        public Control ViewControl
        {
            get { return _control; }
            set {
                if (value != _control)
                {
                    _control = value;
                    _control.Parent = panel1;
                    _control.Location = new System.Drawing.Point(0, 0);
                    _control.SizeChanged += new EventHandler(_control_SizeChanged);
                    panel1.Controls.Clear();
                    panel1.Controls.Add(_control);
                    int height = _control.Height+4;
                    this.Height = height;
                    this.Width = label1.Width + 2 + _control.Width+2;
                }
            }
        }

        void _control_SizeChanged(object sender, EventArgs e)
        {
            int height = _control.Height + 4;
            this.Height = height;
            this.Width = label1.Width + 2 + _control.Width+2;
        }
    }
}
