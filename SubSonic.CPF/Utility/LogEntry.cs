using System;
using System.Collections.Generic;
using System.Text;

namespace SubSonic.CPF.Utility
{
    public class LogEntry
    {
        LogState _status;
        public LogEntry(LogState Status, string Title, string Description)
        {
            _status = Status;
            _title = Title;
            _description = Description;
        }
        public LogState Status
        {
            get { return _status; }
        }
        string _title;

        public string Title
        {
            get { return _title; }
        }
        string _description;

        public string Description
        {
            get { return _description; }
        }

    }
    public enum LogState
    {
        Warning,
        Error,
        Information
    }
}
