using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SubSonic.CPF.Utility
{
    public static class LogManager
    {
        static BindingList<LogEntry> _entries = new BindingList<LogEntry>();

        public static BindingList<LogEntry> Entries
        {
            get { return _entries; }
            set { _entries = value; }
        }
        public static void Clear()
        {
            _entries.Clear();
        }
    }
}
