using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace SubSonic.Commander
{
    public static class ApplicationLog
    {
        static BindingList<LogEntry> _entries = new BindingList<LogEntry>();
        public static event EventHandler EntryAdded;
        public static BindingList<LogEntry> Entries
        {
            get
            {
                return _entries;
            }
        }
        public static void AddEntry(LogState State, string Info)
        {
            LogEntry entry = new LogEntry();
            entry.Description = Info;
            entry.Status = State;
            _entries.Add(entry);
            System.Windows.Forms.Application.DoEvents();
        }
        public static void Clearlist()
        {
            _entries.Clear();
        }

    }
}
