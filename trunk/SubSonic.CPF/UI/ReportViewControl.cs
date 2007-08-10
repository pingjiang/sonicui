using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace SubSonic.CPF.UI
{
    [ToolboxItem(true)]
    public class ReportViewControl:ViewControl,IView
    {
        /// <summary>
        /// Print the Report
        /// </summary>
        public virtual void PrintView()
        {

        }
        #region IViewControl Members

        public ViewType View
        {
            get { return ViewType.ReportView; }
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
