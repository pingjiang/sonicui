using System;
using System.Collections.Generic;
using System.Text;

namespace SubSonicManager
{
    public class LogEntry
    {
        LogState _status;
        public LogEntry(LogState Status,string Title,string Description)
        {
            _status = Status;
            _title = Title;
            _description = Description;
        }
        public LogEntry()
        {

        }
        public LogState Status
        {
            get { return _status; }
            set { _status = value; }
        }
        string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
    }
    public enum LogState
    {
        Warning,
        Error,
        Information
    }
}
