using System;
using System.Collections;
using System.Configuration.Provider;
using System.Diagnostics;
using System.Text;
using System.IO;
using System.Reflection;
using System.Configuration;
//using ICSharpCode.SharpZipLib.Zip;
using SubSonic;
using SubSonic.Utilities;
using SubSonic.CodeGenerator;
using System.Windows.Forms;

namespace SubSonic
{
    public static class SubCommander
    {
        static string possibleargs
        {
            get
            {
                return @"override
,server
,db
,userid
,password
,out
,lang
,provider
,includeTableList
,config
,excludeTableList   
,generatedNamespace
,templateDirectory
,fixPluralClassNames
,useSPs
,spClassName
,stripTableText
,stripColumnText
,stripParamText
,appendWith
,spStartsWith
,viewStartsWith
,relatedTableLoadPrefix
,removeUnderscores
,regexMatchExpression
,regexReplaceExpression
,regexIgnoreCase
,regexDictionaryReplace
,generateLazyLoads
,generateRelatedTablesAsProperties
,extractClassNameFromSPName
,includeProcedureList
,excludeProcedureList
,useExtendedProperties";
            }
        }
        private static Arguments arguments;
        private static readonly TurboCompiler turboCompiler = new TurboCompiler();
        private static ICodeLanguage language = new CSharpCodeLanguage();
        #region ProgramCode
        /*
        private static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            arguments = new Arguments(Environment.CommandLine);

            //the first args gonna tell us what to do
            string command = "";
            if (args.Length > 0)
            {
                command = args[0];
            }

            try
            {
                if (Utility.IsMatch(command, "scriptdata"))
                {
                    ScriptData();
                }
                else if (Utility.IsMatch(command, "scriptschema"))
                {
                    ScriptSchema();
                }
                else if (Utility.IsMatch(command, "version"))
                {
                    VersionDB();
                }
                else if (Utility.IsMatch(command, "generatetables"))
                {
                    GenerateTables();
                }
                else if (Utility.IsMatch(command, "generateods"))
                {
                    GenerateODSControllers();
                }
                else if (Utility.IsMatch(command, "generateviews"))
                {
                    GenerateViews();
                }
                else if (Utility.IsMatch(command, "generatesps"))
                {
                    GenerateSPs();
                }
                else if (Utility.IsMatch(command, "generate") || Utility.IsMatch(command, "generateall"))
                {
                    GenerateAll();
                }
                else if (Utility.IsMatch(command, "generateeditor") || Utility.IsMatch(command, "editor"))
                {
                    GenerateEditor();
                }
                else if (Utility.IsMatch(command, "help"))
                {
                    ThrowHelp(true);
                }
                else if (Utility.IsMatch(command, "dir"))
                {
                    Console.WriteLine(Directory.GetCurrentDirectory());
                    Console.WriteLine("");
                    Console.WriteLine("Press any key to exit...");
                    Console.Read();
                }
                else
                {
                    Console.WriteLine("ERROR: No Command Specified");
                    ThrowHelp(true);
                }

                if (turboCompiler.Templates.Count > 0)
                {
                    Console.WriteLine("Running Compiler...");
                    turboCompiler.Run();
                    Console.WriteLine("Writing Files...");
                    foreach (TurboTemplate template in turboCompiler.Templates)
                    {
                        Utility.WriteTrace("Writing " + template.TemplateName + " as " + template.OutputPath.Substring(template.OutputPath.LastIndexOf("\\") + 1));
                        SubSonic.Sugar.Files.CreateToFile(template.OutputPath, template.FinalCode);
                    }
                    Console.WriteLine("Done!");
                }
            }
            catch (Exception x)
            {
                Console.WriteLine("ERROR: Trying to execute {0}{1}Error Message: {2}", command, Environment.NewLine, x);
            }
            timer.Stop();
            Console.WriteLine("Execution Time: " + timer.ElapsedMilliseconds + "ms");
        }
        */
        /*
        private static void ThrowHelp(bool verbose)
        {
            WriteVersionInformation("sonic.exe v{0} - Command Line Interface to SubSonic v{1}");
            Console.WriteLine("Usage:   sonic command [options]");
            Console.WriteLine("Sample:  sonic generate /server localhost /db northwind /out GeneratedFiles");
            Console.WriteLine("Help:    sonic help");
            Console.WriteLine("TIP:    SubSonic will read your App.Config or Web.Config - just select the project ");
            Console.WriteLine("and run your command.");
            Console.WriteLine("");
            if (!verbose)
            {
                return;
            }

            Console.WriteLine("******************** Commands *********************************");
            Console.WriteLine("version:        Scripts out the schema/data of your db to file");
            Console.WriteLine("scriptdata:     Scripts the data to file for your database");
            Console.WriteLine("scriptschema:   Scripts your Database schema to file");
            Console.WriteLine("generate:       Generates output code for tables, views, and SPs");
            Console.WriteLine("generatetables: Generates output code for your tables");
            Console.WriteLine("generateODS:    Generates and ObjectDataSource controller for each table");
            Console.WriteLine("generateviews:  Generates output code for your views");
            Console.WriteLine("generatesps:    Generates output code for your SPs");
            Console.WriteLine("editor:         Creates an Editor for a particular table");
            Console.WriteLine("");
            Console.WriteLine("******************** Argument List ****************************");
            Console.WriteLine("####### Required For all commands (these can be read from config files)");
            Console.WriteLine("if you don't have a Web or App.config, these need to be set");
            Console.WriteLine("/override       SubCommander won't try to find a config - instead it will use what you pass in");
            Console.WriteLine("/server -       the database server - ALWAYS REQUIRED");
            Console.WriteLine("/db -           the database to use");
            Console.WriteLine("");
            Console.WriteLine("####### Other Commands (some may be required for specific commands)");
            Console.WriteLine("/userid -       the User ID for your database (blank = use SSPI)");
            Console.WriteLine("/password -     the password for your DB (blank = use SSPI)");
            Console.WriteLine("/out -          the output directory for generated items. (default = current)");
            Console.WriteLine("/lang -         generated code language: cs or vb (default = cs)");
            Console.WriteLine("/provider -     the name of the provider to use");
            Console.WriteLine("/includeTableList -    used for generating classes. A comma-delimited list that ");
            Console.WriteLine("                defines which tables should be used to generate classes");
            Console.WriteLine("/config -       the path your App/Web.Config - used to instance SubSonic ");
            Console.WriteLine("/excludeTableList    the opposite of tablelist. These tables will NOT be ");
            Console.WriteLine("                used to generate classes");
            Console.WriteLine("");
            Console.WriteLine("******** Arguments Matching SubSonic web.config Settings ********");
            Console.WriteLine("Just add a '/' in front");
            Console.WriteLine("/generatedNamespace -  the namespace to use for generated code");
            Console.WriteLine("/templateDirectory -   the directory containing template overrides");
            Console.WriteLine("/fixDatabaseObjectCasing - fix the capitilization of object generated from database? true/false (default is true)");
            Console.WriteLine("/fixPluralClassNames - reset all plural table names to singular? true/false");
            Console.WriteLine("/useSPs -              whether to generate SP wrapper (true/false)");
            Console.WriteLine("/spClassName -         default is 'StoredProcedures' - this will override that");
            Console.WriteLine("/stripTableText -      replace table text with this command");
            Console.WriteLine("/stripColumnText -     replace column text with this command");
            Console.WriteLine("/stripParamText -      replace SP param text with this command");
            Console.WriteLine("/appendWith -          when you have reserved words in your table columns");
            Console.WriteLine("                       we need to append it with something. Our default is 'X'.");
            Console.WriteLine("                       You can change that here.");
            Console.WriteLine("/spStartsWith -        use SPs that start with this");
            Console.WriteLine("/viewStartsWith -      use Views that start with this");
            Console.WriteLine("/relatedTableLoadPrefix - prefix related table loaders");
            Console.WriteLine("/removeUnderscores -   whether to remove underscores from generated object");
            Console.WriteLine("                       names (true/false) default is false");
            Console.WriteLine("/templateDirectory     The path to your custom templates. This is a directory reference");
            Console.WriteLine("/regexMatchExpression");
            Console.WriteLine("/regexReplaceExpression");
            Console.WriteLine("/regexIgnoreCase");
            Console.WriteLine("/regexDictionaryReplace");
            Console.WriteLine("/generateLazyLoads");
            Console.WriteLine("/generateRelatedTablesAsProperties");
            Console.WriteLine("/extractClassNameFromSPName");
            Console.WriteLine("/includeProcedureList");
            Console.WriteLine("/excludeProcedureList");
            Console.WriteLine("/useExtendedProperties");
            Console.WriteLine("/additionalNamespaces");
        }
        */
        #endregion
        private static void WriteVersionInformation(string formatString)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string sonicVersion = asm.GetName().Version.ToString();
            string subSonicVersion = "---";

            AssemblyName[] asmNames = asm.GetReferencedAssemblies();
            foreach (AssemblyName nm in asmNames)
            {
                if (nm.Name == "SubSonic")
                {
                    subSonicVersion = nm.Version.ToString();
                    break;
                }
            }

            Console.WriteLine(formatString, sonicVersion, subSonicVersion);
        }

        #region Provider Startup

        private static string GetConfigPath()
        {
            // Try cmd line arg first.
            string configArg = GetArg("config");

            string configPath = GetConfigInDir(configArg);
            if (configPath != null)
            {
                return configPath;
            }

            string thisDir = Directory.GetCurrentDirectory();

            configPath = GetConfigInDir(Path.Combine(thisDir, configArg));
            if (configPath != null)
            {
                return configPath;
            }

            return GetConfigInDir(thisDir);
        }

        // Tries to find the config file in the specified directory.
        private static string GetConfigInDir(string directory)
        {
            if (File.Exists(directory))
            {
                return directory;
            }

            string webConfigPath = Path.Combine(directory, "Web.config");
            if (File.Exists(webConfigPath))
            {
                return webConfigPath;
            }

            string appConfigPath = Path.Combine(directory, "App.config");
            if (File.Exists(appConfigPath))
            {
                return appConfigPath;
            }

            return null;
        }

        private static void SetProvider()
        {
            string overrideFlag = GetArg("override");
            bool configSet = false;
            if (String.IsNullOrEmpty(overrideFlag))
            {
                string configPath = GetConfigPath();
                if (File.Exists(configPath))
                {
                    configSet = true;
                    AddLogEntry(SubSonic.CPF.Utility.LogState.Information,string.Format("Setting ConfigPath: '{0}'", configPath));
                    SetProvider(configPath);
                }
            }

            if (!configSet)
            {
                SetProviderManually();
            }
        }
        public static void Initialize(string Provider,string server,string db,string userID,string password)
        {
            arguments = new Arguments(string.Empty);
        }
        /// <summary>
        /// Sets DataProvider without using .config file
        /// </summary>
        public static void SetProviderManually()
        {
            if (arguments == null)
            {
                arguments = new Arguments("generate");
            }
            string traceFlag = GetArg(ConfigurationPropertyName.ENABLE_TRACE);

            if (!String.IsNullOrEmpty(traceFlag))
            {
                DataService.EnableTrace = Convert.ToBoolean(traceFlag);
            }

            Utility.WriteTrace("Setting config manually - need AT LEAST a /server and /db");

            //clear the providers and reset
            DataService.Provider = new SqlDataProvider();
            DataService.Providers = new DataProviderCollection();

            //instance a section - we'll set this manually for the DataService
            SubSonicSection section = new SubSonicSection();
            section.TemplateDirectory = GetArg(ConfigurationPropertyName.TEMPLATE_DIRECTORY);
            CodeService.TemplateDirectory = section.TemplateDirectory;

            string providerName = GetArg(ConfigurationPropertyName.PROVIDER_TO_USE);
            if (string.IsNullOrEmpty(providerName))
            {
                providerName = "Default";
            }
            section.DefaultProvider = providerName;

            section.DefaultProvider = "Default";

            CodeService.TemplateDirectory = section.TemplateDirectory;

            //set the properties
            DataProvider provider = DataService.Provider;
            System.Collections.Specialized.NameValueCollection config = new System.Collections.Specialized.NameValueCollection();

            //need to add this for now
            config.Add("connectionStringName", "Default");

            if (!string.IsNullOrEmpty(GetArg(ConfigurationPropertyName.TEMPLATE_DIRECTORY)))
            {
                config.Add(ConfigurationPropertyName.TEMPLATE_DIRECTORY, GetArg(ConfigurationPropertyName.TEMPLATE_DIRECTORY));
            }


            //setup the config
            SetConfig(config, ConfigurationPropertyName.APPEND_WITH);
            SetConfig(config, ConfigurationPropertyName.ADDITIONAL_NAMESPACES);
            SetConfig(config, ConfigurationPropertyName.EXCLUDE_PROCEDURE_LIST);
            SetConfig(config, ConfigurationPropertyName.EXCLUDE_TABLE_LIST);
            SetConfig(config, ConfigurationPropertyName.EXTRACT_CLASS_NAME_FROM_SP_NAME);
            SetConfig(config, ConfigurationPropertyName.FIX_DATABASE_OBJECT_CASING);
            SetConfig(config, ConfigurationPropertyName.FIX_PLURAL_CLASS_NAMES);
            SetConfig(config, ConfigurationPropertyName.GENERATED_NAMESPACE);
            SetConfig(config, ConfigurationPropertyName.GENERATE_LAZY_LOADS);
            SetConfig(config, ConfigurationPropertyName.GENERATE_NULLABLE_PROPERTIES);
            SetConfig(config, ConfigurationPropertyName.GENERATE_ODS_CONTROLLERS);
            SetConfig(config, ConfigurationPropertyName.GENERATE_RELATED_TABLES_AS_PROPERTIES);
            SetConfig(config, ConfigurationPropertyName.INCLUDE_PROCEDURE_LIST);
            SetConfig(config, ConfigurationPropertyName.INCLUDE_TABLE_LIST);
            SetConfig(config, ConfigurationPropertyName.REGEX_DICTIONARY_REPLACE);
            SetConfig(config, ConfigurationPropertyName.REGEX_IGNORE_CASE);
            SetConfig(config, ConfigurationPropertyName.REGEX_MATCH_EXPRESSION);
            SetConfig(config, ConfigurationPropertyName.REGEX_REPLACE_EXPRESSION);
            SetConfig(config, ConfigurationPropertyName.RELATED_TABLE_LOAD_PREFIX);
            SetConfig(config, ConfigurationPropertyName.REMOVE_UNDERSCORES);
            SetConfig(config, ConfigurationPropertyName.SET_PROPERTY_DEFAULTS_FROM_DATABASE);
            SetConfig(config, ConfigurationPropertyName.SP_STARTS_WITH);
            SetConfig(config, ConfigurationPropertyName.STORED_PROCEDURE_CLASS_NAME);
            SetConfig(config, ConfigurationPropertyName.STRIP_COLUMN_TEXT);
            SetConfig(config, ConfigurationPropertyName.STRIP_PARAM_TEXT);
            SetConfig(config, ConfigurationPropertyName.STRIP_STORED_PROCEDURE_TEXT);
            SetConfig(config, ConfigurationPropertyName.STRIP_TABLE_TEXT);
            SetConfig(config, ConfigurationPropertyName.STRIP_VIEW_TEXT);
            SetConfig(config, ConfigurationPropertyName.USE_EXTENDED_PROPERTIES);
            SetConfig(config, ConfigurationPropertyName.USE_STORED_PROCEDURES);
            SetConfig(config, ConfigurationPropertyName.VIEW_STARTS_WITH);


            //initialize the provider
            Utility.WriteTrace("Initializing the provider with the passed in configuration >>> hold on to your hats...");
            provider.Initialize(providerName, config);

            //first, make sure there's a connection
            Utility.WriteTrace("Overriding the connection string...");
            provider.DefaultConnectionString = GetConnnectionString();

            Utility.WriteTrace("Set connection string to " + provider.DefaultConnectionString);
            provider.GeneratedNamespace = string.IsNullOrEmpty(_nameSpace)?"SubSonic.Generated":_nameSpace;
            AddLogEntry(SubSonic.CPF.Utility.LogState.Information, "Set connection string to " + provider.DefaultConnectionString);
            DataService.Providers.Add(provider);
        }

        private static void SetConfig(System.Collections.Specialized.NameValueCollection config, string key)
        {
            string setting = GetArg(key);
            if (!String.IsNullOrEmpty(setting))
            {
                Utility.WriteTrace("Setting " + key + " to " + setting);
                config.Add(key, setting);
            }
        }


        private static void SetProvider(string appConfigPath)
        {
            //clear the providers and reset
            DataService.Provider = new SqlDataProvider();
            DataService.Providers = new DataProviderCollection();


            //if present, get the connection strings and the SubSonic config
            if (File.Exists(appConfigPath))
            {
                ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
                Console.WriteLine("Building configuration from " + Path.Combine(Directory.GetCurrentDirectory(), appConfigPath));
                fileMap.ExeConfigFilename = appConfigPath;

                // Open another config file 
                Configuration subConfig = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

                try
                {
                    SubSonicSection section = (SubSonicSection)subConfig.GetSection(ConfigurationSectionName.SUB_SONIC_SERVICE);

                    if (section != null)
                    {
                        DataService.ConfigSection = section;
                        string argTemplateDirectory = GetArg(ConfigurationPropertyName.TEMPLATE_DIRECTORY);
                        string activeTemplateDirectory = String.IsNullOrEmpty(argTemplateDirectory) ? section.TemplateDirectory : argTemplateDirectory;


                        string argTraceFlag = GetArg(ConfigurationPropertyName.ENABLE_TRACE);
                        string activeTraceFlag = String.IsNullOrEmpty(argTraceFlag) ? section.EnableTrace : argTraceFlag;

                        if (!String.IsNullOrEmpty(activeTraceFlag))
                        {
                            DataService.EnableTrace = Convert.ToBoolean(activeTraceFlag);
                        }

                        if (!String.IsNullOrEmpty(activeTemplateDirectory))
                        {
                            Console.WriteLine("Overriding default templates with those from " + section.TemplateDirectory);
                            CodeService.TemplateDirectory = activeTemplateDirectory;
                        }

                        //initialize
                        //need to pull out the default connection string
                        //since this application doesn't have a config file, the target one does
                        //so reconciling connection string won't work
                        string connectionStringName = section.Providers[0].Parameters["connectionStringName"];
                        if (connectionStringName == null)
                        {
                            throw new ConfigurationErrorsException("The Parameter 'connectionStringName' was not specified");
                        }

                        ConnectionStringSettings connSettings = subConfig.ConnectionStrings.ConnectionStrings[connectionStringName];
                        if (connSettings == null)
                        {
                            throw new ConfigurationErrorsException(string.Format("ConnectionStrings section missing connection string with the name '{0}'", connectionStringName));
                        }

                        string connString = subConfig.ConnectionStrings.ConnectionStrings[connectionStringName].ConnectionString;
                        //DataService.ConnectionString = connString;


                        System.Web.Configuration.ProvidersHelper.InstantiateProviders(section.Providers, DataService.Providers, typeof(DataProvider));

                        //this is a tad backwards, but it's what needs to happen since our application
                        //is configuring another application's providers
                        //go back and reset the provider's connection strings

                        //int counter = 0;
                        foreach (DataProvider provider in DataService.Providers)
                        {
                            Console.WriteLine("Adding connection to " + provider.Name);

                            provider.SetDefaultConnectionString(subConfig.ConnectionStrings.ConnectionStrings[provider.ConnectionStringName].ConnectionString);
                            //provider.ConnectionString = subConfig.ConnectionStrings.ConnectionStrings[provider.ConnectionStringName].ConnectionString;
                        }

                        //reset the default provider
                        string providerName = GetArg("provider");
                        if (providerName != string.Empty)
                        {
                            try
                            {
                                DataService.Provider = DataService.Providers[providerName];
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("ERROR: There is no provider with the name '{0}'. Exception: {1}", providerName, e);
                            }
                        }
                        else
                        {
                            DataService.Provider = DataService.Providers[section.DefaultProvider];
                        }
                    }
                }
                catch (ConfigurationErrorsException x)
                {
                    //let the user know the config was problematic...
                    Console.WriteLine("Can't set the configuration for the providers. There is an error with your config setup (did you remember to configure SubSonic in your config file?). '{0}'", x.Message);
                }
            }
            else
            {
                throw new Exception("There's no config file present at " + appConfigPath);
            }
        }
        private static string _outPutDirectory=string.Empty;

        public static string OutPutDirectory
        {
            get { return _outPutDirectory; }
            set { _outPutDirectory = value; }
        }
        private static string GetOutputDirectory()
        {
            string result;
            //if there's a drive specified, then it's absolute
            if (_outPutDirectory.Contains(":"))
            {
                result = _outPutDirectory;
            }
            else
            {
                result = Path.Combine(Directory.GetCurrentDirectory(), _outPutDirectory);
            }

            //now, if the output directory doesn't exist, create it
            if (!Directory.Exists(result))
            {
                Directory.CreateDirectory(result);
            }

            return result;
        }

        #endregion

        #region Utility

        private static void OutputFile(string filePath, string fileText)
        {
            using (StreamWriter sw = File.CreateText(filePath))
            {
                sw.Write(fileText);
            }
        }

        private static string GetArg(string argSwitch)
        {
            return arguments[argSwitch] ?? string.Empty;
        }
        static string _server;

        public static string Server
        {
            get { return SubCommander._server; }
            set { SubCommander._server = value; }
        }
        static string _database;

        public static string Database
        {
            get { return SubCommander._database; }
            set { SubCommander._database = value; }
        }
        static string _userID;

        public static string UserID
        {
            get { return SubCommander._userID; }
            set { SubCommander._userID = value; }
        }
        static string _password;

        public static string Password
        {
            get { return SubCommander._password; }
            set { SubCommander._password = value; }
        }
        private static string GetConnnectionString()
        {
            bool haveError = false;

            string server = _server;
            string db = _database;

            if (server == string.Empty)
            {
                AddLogEntry(SubSonic.CPF.Utility.LogState.Error,"No server name was passed in - please specify MyServer Name");
                haveError = true;
            }
            if (db == string.Empty)
            {
                AddLogEntry(SubSonic.CPF.Utility.LogState.Information,"No Database name was passed in - please specify Database Name");
                haveError = true;
            }

            //optional
            //string tableList = GetArg("tablelist"); //Not being used.
            string userID = _userID;
            string pasword = _password;
            string sConn = string.Empty;
            if (!haveError)
            {
                sConn = "Server=" + server + ";Database=" + db + ";";
                if (userID == string.Empty)
                {
                    sConn += "Integrated Security=SSPI;";
                }
                else
                {
                    sConn += "User ID=" + userID + ";Password=" + pasword;
                }
            }
            else
            {
               // ThrowHelp(false);
            }

            return sConn;
        }

        #endregion

        #region Scripters

        private static void VersionDB()
        {
            ScriptSchema();
            ScriptData();
        }

        private static void ScriptData()
        {
            SetProvider();
            //for this to work, we need a Servername, DB, and output. Optional elements are table list and user id/password
            //string[] tables = DataService.GetTableNames(SubSonicConfig.ProviderName);
            foreach (DataProvider provider in DataService.Providers)
            {
                //string[] tables = DataService.GetTableNames(provider.Name);
                string[] tables = DataService.GetOrderedTableNames(provider.Name);

                string outDir = GetOutputDirectory();
                if (outDir == string.Empty)
                {
                    outDir = Directory.GetCurrentDirectory();
                }

                Utility.WriteTrace("Scripting Data");
                Utility.WriteTrace("#####################################");
                StringBuilder sb = new StringBuilder();
                foreach (string tbl in tables)
                {
                    if (IsInList(tbl) || CodeService.ShouldGenerate(tbl, provider.Name))
                    {
                        Utility.WriteTrace("Scripting Table: " + tbl);
                        string dataScript = DBScripter.ScriptData(tbl, provider.Name);
                        sb.Append(dataScript + Environment.NewLine + Environment.NewLine);
                    }
                }
                string outFileName = string.Format("{0}_{1}_{2}_{3}_{4}_Data.sql", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Environment.UserName, provider.Name);
                string outPath = Path.Combine(outDir, outFileName);

                OutputFile(outPath, sb.ToString());
                Utility.WriteTrace("Finished!");
            }
        }

        private static void ScriptSchema()
        {
            SetProvider();

            foreach (DataProvider provider in DataService.Providers)
            {
                string sConn = provider.DefaultConnectionString; //GetConnnectionString();


                if (sConn != string.Empty)
                {
                    Utility.WriteTrace("Scripting Schema:" + provider.Name);
                    Utility.WriteTrace("#####################################");
                    //string db = GetArg("db");
                    string outDir = GetOutputDirectory();

                    string schema = DBScripter.ScriptSchema(sConn);
                    string outFileName = string.Format("{0}_{1}_{2}_{3}_{4}_Schema.sql", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Environment.UserName, provider.Name);
                    string outPath = Path.Combine(outDir, outFileName);

                    OutputFile(outPath, schema);
                    AddLogEntry(SubSonic.CPF.Utility.LogState.Information,"Finished!");
                }
            }
        }

        #endregion

        #region Generators

        private static void GenerateEditor()
        {
            string table = GetArg("table");
            string outDir = GetOutputDirectory();
            GenerateEditor(table, outDir);
        }
        /// <summary>
        /// Windows Forms Version of an Editor
        /// </summary>
        /// <param name="table"></param>
        /// <param name="outDir"></param>
        private static void GenerateEditor(string table, string outDir)
        {
            bool haveError = false;
            WriteVersionInformation("");

            if (table == string.Empty)
            {
                AddLogEntry(SubSonic.CPF.Utility.LogState.Error,"No table name was entered; please specify the name of the table");
                haveError = true;
            }


            if (!haveError)
            {
                AddLogEntry(SubSonic.CPF.Utility.LogState.Information,"Generating editor for " + table);

                if (DataService.Provider == null)
                {
                    SetProvider();
                }


                string fileExt = FileExtension.DOT_CS;
                string lang = GetArg("lang");
                //LanguageType langType = LanguageType.CSharp;

                if (FileExtension.IsVB(lang))
                {
                    //langType = LanguageType.VB;
                    fileExt = FileExtension.DOT_VB;
                }
                TableSchema.Table tableSchema = DataService.GetSchema(table, DataService.Provider.Name, TableType.Table);
                string pageName = tableSchema.ClassName + "Editor.aspx";
                string codePageName = pageName + fileExt;
                string pageFile = Path.Combine(outDir, pageName);
                string codeFile = Path.Combine(outDir, codePageName);

                //generate up the editor
                try
                {
                    //string page = ScaffoldCodeGenerator.GeneratePage(DataService.Provider.Name, table, pageName, "", langType);
                    //string code = ScaffoldCodeGenerator.GenerateCode(pageName, DataService.Provider.Name, table, langType);
                    //string page = "";
                    //string code = "";
                    //Clipboard.SetData(System.Windows.Forms.DataFormats.StringFormat, page);
                    //OutputFile(pageFile, page);
                    //OutputFile(codeFile, code);
                    //Console.WriteLine("Copied to clipboard" + pageName);
                }
                catch
                {
                    AddLogEntry(SubSonic.CPF.Utility.LogState.Error,"ERROR: Can't generate editor for " + table + ".");
                    AddLogEntry(SubSonic.CPF.Utility.LogState.Error,"Please check the table name and that the you specified the right provider (you can set the provider by using /provider)");
                }
            }
            else
            {
                //ThrowHelp(false);
            }
        }

        public static void GenerateAll()
        {
            DateTime start = DateTime.Now;
            GenerateTables();
            GenerateODSControllers();
            GenerateViews();
            GenerateSPs();
            GenerateStructs();
            if (turboCompiler.Templates.Count > 0)
            {
                AddLogEntry(SubSonic.CPF.Utility.LogState.Information, "Running Compiler...");
                turboCompiler.Run();
                AddLogEntry(SubSonic.CPF.Utility.LogState.Information, "Writing Files...");
                foreach (TurboTemplate template in turboCompiler.Templates)
                {
                    Utility.WriteTrace("Writing " + template.TemplateName + " as " + template.OutputPath.Substring(template.OutputPath.LastIndexOf("\\") + 1));
                    SubSonic.Sugar.Files.CreateToFile(template.OutputPath, template.FinalCode);
                }
                AddLogEntry(SubSonic.CPF.Utility.LogState.Information, "Done!");
            }
            DateTime end = DateTime.Now;
            TimeSpan ts = end.Subtract(start);
            AddLogEntry(SubSonic.CPF.Utility.LogState.Information,string.Format("Completed in {0}ms",ts.Milliseconds));
        }

        private static bool IsExcluded(string tableName)
        {
            bool bOut = false;
            string excludeList = GetArg("excludelist");

            if (excludeList != string.Empty)
            {
                string[] tables = excludeList.Split(',');
                foreach (string tbl in tables)
                {
                    if (tbl.ToLower() == tableName.ToLower())
                    {
                        bOut = true;
                        break;
                    }
                }
            }
            else
            {
                bOut = false;
            }
            return bOut;
        }

        private static bool IsInList(string tableName)
        {
            string tableList = GetArg("tablelist");
            bool bOut = false;

            if (tableList.Trim() == "*")
            {
                bOut = true;
            }
            else
            {
                if (tableList != string.Empty)
                {
                    string[] tables = tableList.Split(',');
                    foreach (string tbl in tables)
                    {
                        if (tbl.ToLower() == tableName.ToLower())
                        {
                            bOut = true;
                            break;
                        }
                    }
                }
                else
                {
                    //it's not set, default it to true
                    bOut = true;
                }
            }

            return bOut;
        }

        private static string GetOutSubDir(ProviderBase provider)
        {
            string outDir = GetOutputDirectory();
            if (outDir == string.Empty)
            {
                outDir = Directory.GetCurrentDirectory();
            }

            if (DataService.Providers.Count > 1)
            {
                //this is set by the routines
                outDir = Path.Combine(outDir, provider.Name);
            }
            if (!Directory.Exists(outDir))
            {
                Directory.CreateDirectory(outDir);
            }

            return outDir;
        }

        public static void GenerateTables()
        {
            //if (DataService.Provider == null)
            SetProvider();

            string fileExt = FileExtension.DOT_CS;
            string lang = GetArg("lang");


            if (FileExtension.IsVB(lang))
            {
                language = new VBCodeLanguage();
                fileExt = FileExtension.DOT_VB;
            }
            //string usings = ParseUtility.GetUsings(language);

            if (DataService.Providers.Count == 0)
            {
                AddLogEntry(SubSonic.CPF.Utility.LogState.Error,"There's a problem with the providers - none were loaded and no exceptions where thrown.");
            }
            else
            {
                //loop the providers, and if there's more than one, output to their own folder
                //for tidiness
                foreach (DataProvider provider in DataService.Providers)
                {
                    //get the table list
                    string[] tables = DataService.GetTableNames(provider.Name);
                    string message = "Generating classes for " + provider.Name + " (" + tables.Length + " total)";
                    if (tables.Length > 200)
                    {
                        message += " that's a serious amount of tables to generate. But we can handle it. You just will need to be patient and go get some coffee while we do this thang...";
                    }
                    else if (tables.Length > 100)
                    {
                        message += " that's a lot of tables. This could take a few minutes...";
                    }
                    else if (tables.Length > 50)
                    {
                        message += " - moderate amount of tables... this could take 30 seconds or so...";
                    }


                    AddLogEntry(SubSonic.CPF.Utility.LogState.Information,message);
                    string outDir = GetOutSubDir(provider);
                    outDir = Path.Combine(outDir, "Models");
                    if (!Directory.Exists(outDir))
                    {
                        Directory.CreateDirectory(outDir);
                    }
                    /*
                    ArrayList evalTables = new ArrayList();
                    foreach (string tbl in tables)
                    {
                        TableSchema.Table t = DataService.GetTableSchema(tbl, provider.Name);
                        Console.Write(".");
                        if(t.ForeignKeys.Count > 0)
                        {
                            provider.GetManyToManyTables(t, evalTables);    
                        }
                    }
                    */
                    foreach (string tbl in tables)
                    {
                        if (IsInList(tbl) && !IsExcluded(tbl) && CodeService.ShouldGenerate(tbl, provider.Name))
                        {
                            string className = DataService.GetSchema(tbl, provider.Name, TableType.Table).ClassName;
                            TurboTemplate tt = CodeService.BuildClassTemplate(tbl, language, provider);
                            tt.OutputPath = Path.Combine(outDir, className + fileExt);
                            turboCompiler.AddTemplate(tt);
                        }
                    }
                }
                AddLogEntry(SubSonic.CPF.Utility.LogState.Information,"Finished");
            }
        }
        static string _nameSpace;
        public static string NameSpace
        {
            get { return _nameSpace; }
            set { _nameSpace = value; }
        }
        public static void GenerateODSControllers()
        {
            //if (DataService.Provider == null)
            SetProvider();

            string fileExt = FileExtension.DOT_CS;
            string lang = GetArg("lang");

            if (FileExtension.IsVB(lang))
            {
                language = new VBCodeLanguage();
                fileExt = FileExtension.DOT_VB;
            }

            if (DataService.Providers.Count == 0)
            {
                AddLogEntry(SubSonic.CPF.Utility.LogState.Error,"There's a problem with the providers - none were loaded and no exceptions where thrown.");
            }
            else
            {
                //loop the providers, and if there's more than one, output to their own folder
                //for tidiness
                foreach (DataProvider provider in DataService.Providers)
                {
                    //get the table list
                    string[] tables = DataService.GetTableNames(provider.Name);
                    string message = "Generating ODS Controllers for " + provider.Name + " (" + tables.Length + " total)";
                    if (tables.Length > 200)
                    {
                        message += " that's a serious amount of tables to generate. But we can handle it. You just will need to be patient and go get some coffee while we do this thang...";
                    }
                    else if (tables.Length > 100)
                    {
                        message += " that's a lot of tables. This could take a few minutes...";
                    }
                    else if (tables.Length > 50)
                    {
                        message += " - moderate amount of tables... this could take 30 seconds or so...";
                    }


                    AddLogEntry(SubSonic.CPF.Utility.LogState.Information,message);
                    string outDir = GetOutSubDir(provider);
                    outDir = Path.Combine(outDir, "Controllers");
                    if (!Directory.Exists(outDir))
                    {
                        Directory.CreateDirectory(outDir);
                    }
                    //foreach (string tbl in tables)
                    //{
                    //    if (IsInList(tbl) && !IsExcluded(tbl))
                    //    {
                    //        string className = DataService.GetSchema(tbl, provider.Name, TableType.Table).ClassName;
                    //        string code = CodeService.RunODS(tbl, provider.Name, language);

                    //        if (!String.IsNullOrEmpty(code))
                    //        {
                    //            string outPath = Path.Combine(outDir, className + "Controller" + fileExt);
                    //            Console.WriteLine("Generating ODS Controller for  " + className + " to " + outPath);
                    //            SubSonic.Sugar.Files.CreateToFile(outPath, usings + code);
                    //        }

                    //    }
                    //}

                    foreach (string tbl in tables)
                    {
                        if (IsInList(tbl) && !IsExcluded(tbl) && CodeService.ShouldGenerate(tbl, provider.Name))
                        {
                            string className = DataService.GetSchema(tbl, provider.Name, TableType.Table).ClassName;
                            TurboTemplate tt = CodeService.BuildODSTemplate(tbl, language, provider);
                            tt.OutputPath = Path.Combine(outDir, className + "Controller" + fileExt);
                            turboCompiler.AddTemplate(tt);
                        }
                    }
                }
                AddLogEntry(SubSonic.CPF.Utility.LogState.Information,"Finished");
            }
        }


        //private static string GetNamespace(DataProvider provider)
        //{
        //    string nameSpace = GetArg(ConfigurationPropertyName.GENERATED_NAMESPACE) ?? string.Empty;
        //    if (nameSpace.Length == 0)
        //        nameSpace = provider.GeneratedNamespace ?? string.Empty;
        //    if (nameSpace.Length == 0)
        //        nameSpace = provider.Name ?? string.Empty;
        //    if (nameSpace.Length == 0)
        //        throw new InvalidOperationException("Something is seriously FUBAR! We can't get a namespace. The provider name should be set.");
        //    return nameSpace;
        //}

        public static void GenerateViews()
        {
            //if (DataService.Provider == null)
            SetProvider();

            string lang = GetArg("lang");
            string fileExt = FileExtension.DOT_CS;

            if (FileExtension.IsVB(lang))
            {
                language = new VBCodeLanguage();
                fileExt = FileExtension.DOT_VB;
            }

            //loop the providers, and if there's more than one, output to their own folder
            //for tidiness
            foreach (DataProvider provider in DataService.Providers)
            {
                //get the view list
                string[] views = DataService.GetViewNames(provider.Name);
                string outDir = GetOutSubDir(provider);
                outDir = Path.Combine(outDir, "Models");
                if (!Directory.Exists(outDir))
                {
                    Directory.CreateDirectory(outDir);
                }
                foreach (string tbl in views)
                {
                    if (IsInList(tbl) && !IsExcluded(tbl) && CodeService.ShouldGenerate(tbl, provider.Name))
                    {
                        string className = DataService.GetSchema(tbl, provider.Name, TableType.View).ClassName;
                        TurboTemplate tt = CodeService.BuildViewTemplate(tbl, language, provider);
                        tt.OutputPath = Path.Combine(outDir, className + fileExt);
                        turboCompiler.AddTemplate(tt);
                    }
                }
            }
        }

        public static void GenerateSPs()
        {
            //if (DataService.Provider == null)
            SetProvider();


            string lang = GetArg("lang");
            string fileExt = FileExtension.DOT_CS;

            if (FileExtension.IsVB(lang))
            {
                language = new VBCodeLanguage();
                fileExt = FileExtension.DOT_VB;
            }

            //loop the providers, and if there's more than one, output to their own folder
            //for tidiness
            foreach (DataProvider provider in DataService.Providers)
            {
                //string code = usings + CodeService.RunSPs(provider.Name, language);
                string outDir = GetOutSubDir(provider);
                if (outDir == string.Empty)
                {
                    outDir = Directory.GetCurrentDirectory();
                }
                outDir = Path.Combine(outDir, "Controllers");
                if (!Directory.Exists(outDir))
                {
                    Directory.CreateDirectory(outDir);
                }
                string outPath = Path.Combine(outDir, "StoredProcedures" + fileExt);
                AddLogEntry(SubSonic.CPF.Utility.LogState.Information,"Generating SPs to " + outPath);

                TurboTemplate tt = CodeService.BuildSPTemplate(language, provider);
                tt.OutputPath = outPath;
                turboCompiler.AddTemplate(tt);
            }

            AddLogEntry(SubSonic.CPF.Utility.LogState.Information,"Finished");
        }

        public static void GenerateStructs()
        {
            //if (DataService.Provider == null)
            SetProvider();

            string lang = GetArg("lang");
            string fileExt = FileExtension.DOT_CS;

            if (FileExtension.IsVB(lang))
            {
                language = new VBCodeLanguage();
                fileExt = FileExtension.DOT_VB;
            }

            string outDir = GetOutputDirectory();
            if (outDir == string.Empty)
            {
                outDir = Directory.GetCurrentDirectory();
            }
            outDir = Path.Combine(outDir, "Utility");
            if (!Directory.Exists(outDir))
            {
                Directory.CreateDirectory(outDir);
            }
            string outPath = Path.Combine(outDir, "AllStructs" + fileExt);
            Console.WriteLine("Generating Structs to " + outPath);
            TurboTemplate tt = CodeService.BuildStructsTemplate(language, DataService.Provider);
            tt.OutputPath = outPath;
            turboCompiler.AddTemplate(tt);


            Console.WriteLine("Finished");
        }
        private static void AddLogEntry(SubSonic.CPF.Utility.LogState state, string Description)
        {
            
            SubSonic.CPF.Utility.LogManager.Entries.Add(new SubSonic.CPF.Utility.LogEntry(state,"Generator",Description));
            Application.DoEvents();
        }
        #endregion
    }
}

