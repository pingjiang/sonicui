using System;
using System.Data.SqlClient;
using System.Data;
using SubSonic;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Collections.Specialized;

namespace SubSonic
{
    public class DBScripter
    {

        public static string ScriptData(string tableName, string providerName)
        {

            return DataService.ScriptData(tableName, providerName);
        }


        public static string ScriptSchema(string connectionString)
        {
            string result = "";

            SqlConnection conn = new SqlConnection(connectionString);
            SqlConnectionStringBuilder cString = new SqlConnectionStringBuilder(connectionString);
            ServerConnection sconn = new ServerConnection(conn);
            Server server = new Server(sconn);
            Database db = server.Databases[cString.InitialCatalog];
            Transfer trans = new Transfer(db);

            //set the objects to copy
            trans.CopyAllTables = true;
            trans.CopyAllDefaults = true;
            trans.CopyAllUserDefinedFunctions = true;
            trans.CopyAllStoredProcedures = true;
            trans.CopyAllViews = true;
            trans.CopyData = true;
            trans.CopySchema = true;
            trans.CopyAllDefaults = true;
            trans.DropDestinationObjectsFirst = true;
            trans.UseDestinationTransaction = true;

            trans.Options.AnsiFile = true;
            trans.Options.ClusteredIndexes = true;
            trans.Options.DriAll = true;
            trans.Options.IncludeHeaders = true;
            trans.Options.IncludeIfNotExists = true;
            trans.Options.SchemaQualify = true;


            StringCollection script = trans.ScriptTransfer();


            foreach (string s in script)
            {
                result += s + Environment.NewLine;
            }
            return result + Environment.NewLine + Environment.NewLine;
        }


    }
}
