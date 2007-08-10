using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SubSonic.CPF.UI
{
    public class ListViewControl:ViewControl,IView
    {
        /// <summary>
        /// Load data for List
        /// </summary>
        public virtual void LoadData()
        {

        }
        public virtual void RefreshData()
        {

        }

        public virtual void New()
        {

        }
        #region IViewControl Members

        public ViewType View
        {
            get
            {
                return ViewType.ListView;
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
