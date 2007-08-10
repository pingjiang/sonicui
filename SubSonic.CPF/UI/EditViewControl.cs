using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SubSonic.CPF.UI
{
    public class EditViewControl:ViewControl,IView
    {
        public EditViewControl()
        {

        }
        bool isDirty = false;

        public bool IsDirty
        {
            get { return isDirty; }
            set { isDirty = value; }
        }
        /// <summary>
        /// Saves the data NOTE: You have to set the dirty value here;
        /// </summary>
        public virtual void Save()
        {
        }
        #region IViewControl Members

        public ViewType View
        {
            get
            {
                return ViewType.EditorView;
            }
        }
        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (value != _description)
                    _description = value;
            }
        }
        string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (value != _title)
                    _title = value;
            }
        }

        #endregion
    }
}
