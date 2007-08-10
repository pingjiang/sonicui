using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SubSonic.CPF
{
    public interface IView
    {
        ViewType View
        {
            get;
        }
        string Description
        {
            get;
            set;
        }
        string Title
        {
            get;
            set;
        }

    }
    /// <summary>
    /// ViewType of the ViewControl
    /// ListView - Grid/List for Displaying Collections
    /// EditorView - Editor for individual records
    /// ReportView - Reporting Display for use with printing
    /// </summary>
    public enum ViewType
    {
        ListView,
        EditorView,
        ReportView
    }
}
