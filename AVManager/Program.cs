using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AVManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SetConnection();
            Application.Run(new MainForm());
        }
        static void SetConnection()
        {
            SubSonic.SubCommander.Server = Properties.Settings.Default.dbServer;
            SubSonic.SubCommander.Database = Properties.Settings.Default.dbBase;
            SubSonic.SubCommander.UserID = Properties.Settings.Default.dbUser;
            SubSonic.SubCommander.Password = Properties.Settings.Default.dbPass;
            SubSonic.SubCommander.SetProviderManually();
        }
    }
}