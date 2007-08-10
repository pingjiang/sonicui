using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace SubSonic.CPF
{
    [ToolboxItem(true),ToolboxBitmap(typeof(PresentationManager), "view_choose.png")]
    public class PresentationManager:UserControl
    {
        List<ViewControl> _views = new List<ViewControl>();

        public List<ViewControl> Views
        {
            get { return _views; }
        }
        /// <summary>
        /// Add a view to the Underlying list
        /// </summary>
        /// <param name="View"> ViewControl to be added</param>
        public void AddView(ViewControl View)
        {
            _views.Add(View);
        }
        ViewControl _activeView;
        /// <summary>
        /// Sets the active View
        /// </summary>
        public ViewControl ActiveView
        {
            get { return _activeView; }
            set
            {
                if (value == _activeView)
                    return;

                _activeView = value;
                this.Controls.Clear();
                _activeView.Dock = DockStyle.Fill;
                this.Controls.Add(_activeView);
            }
        }
        public PresentationManager()
        {

        }
    }
}
