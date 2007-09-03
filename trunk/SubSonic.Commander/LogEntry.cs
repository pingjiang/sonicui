using System;
using System.Collections.Generic;
using System.Text;

namespace SubSonic.Commander
{
    public class LogEntry
    {
        string description;
        LogState status;
        public LogState Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

    }
    public enum LogState
    {
        Warning,
        Error,
        Information
    }
}
