using System;
using System.Collections.Generic;
using System.Text;
using SubSonic.Utilities;
using SubSonic;
using System.Configuration.Provider;
using System.Collections.Specialized;
using System.IO;
using System.Configuration;
using SubSonic.CodeGenerator;

namespace SubSonic.Commander
{
    public static class SubSommander
    {
        private static Arguments arguments;
        private static readonly TurboCompiler turboCompiler = new TurboCompiler();
        private static ICodeLanguage language = new CSharpCodeLanguage();
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
                    AddLogEntry(LogState.Information,string.Format("Setting ConfigPath: '{0}'", configPath));
                    SetProvider(configPath);
                }
            }

            if (!configSet)
            {
                SetProviderManually();
            }
        }

        private static void SetProviderManually()
        {
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
            if (string.IsNullOrEmpty(_namespace))
                config.Add("generatedNamespace", _namespace);

            //setup the config
            SetConfig(config, ConfigurationPropertyName.APPEND_WITH);
            SetConfig(config, ConfigurationPropertyName.ADDITIONAL_NAMESPACES);
            SetConfig(config, ConfigurationPropertyName.EXCLUDE_PROCEDURE_LIST);
            SetConfig(config, ConfigurationPropertyName.EXCLUDE_TABLE_LIST);
            SetConfig(config, ConfigurationPropertyName.EXTRACT_CLASS_NAME_FROM_SP_NAME);
            SetConfig(config, ConfigurationPropertyName.FIX_DATABASE_OBJECT_CASING,_fixCasing.ToString());
            SetConfig(config, ConfigurationPropertyName.FIX_PLURAL_CLASS_NAMES,_fixPlural.ToString());
            SetConfig(config, ConfigurationPropertyName.GENERATED_NAMESPACE);
            SetConfig(config, ConfigurationPropertyName.GENERATE_LAZY_LOADS,_lazyLoad.ToString());
            SetConfig(config, ConfigurationPropertyName.GENERATE_NULLABLE_PROPERTIES);
            SetConfig(config, ConfigurationPropertyName.GENERATE_ODS_CONTROLLERS);
            SetConfig(config, ConfigurationPropertyName.GENERATE_RELATED_TABLES_AS_PROPERTIES,_genRelationProperties.ToString());
            SetConfig(config, ConfigurationPropertyName.INCLUDE_PROCEDURE_LIST);
            SetConfig(config, ConfigurationPropertyName.INCLUDE_TABLE_LIST);
            SetConfig(config, ConfigurationPropertyName.REGEX_DICTIONARY_REPLACE,regexDictReplace);
            SetConfig(config, ConfigurationPropertyName.RELATED_TABLE_LOAD_PREFIX);
            SetConfig(config, ConfigurationPropertyName.REMOVE_UNDERSCORES,_removeUnderScore.ToString());
            SetConfig(config, ConfigurationPropertyName.SET_PROPERTY_DEFAULTS_FROM_DATABASE);
            SetConfig(config, ConfigurationPropertyName.SP_STARTS_WITH);
            SetConfig(config, ConfigurationPropertyName.STORED_PROCEDURE_CLASS_NAME);
            SetConfig(config, ConfigurationPropertyName.STRIP_COLUMN_TEXT);
            SetConfig(config, ConfigurationPropertyName.STRIP_PARAM_TEXT);
            SetConfig(config, ConfigurationPropertyName.STRIP_STORED_PROCEDURE_TEXT);
            SetConfig(config, ConfigurationPropertyName.STRIP_TABLE_TEXT);
            SetConfig(config, ConfigurationPropertyName.STRIP_VIEW_TEXT);
            SetConfig(config, ConfigurationPropertyName.USE_EXTENDED_PROPERTIES);
            SetConfig(config, ConfigurationPropertyName.USE_STORED_PROCEDURES,_generateSP.ToString());
            SetConfig(config, ConfigurationPropertyName.VIEW_STARTS_WITH);
            SetConfig(config, ConfigurationPropertyName.REGEX_MATCH_EXPRESSION, regexMatch);
            SetConfig(config, ConfigurationPropertyName.REGEX_REPLACE_EXPRESSION, regexReplace);
            SetConfig(config, ConfigurationPropertyName.REGEX_IGNORE_CASE, regexIgnoreCase.ToString());
            //initialize the provider
            Utility.WriteTrace("Initializing the provider with the passed in configuration >>> hold on to your hats...");
            provider.Initialize(providerName, config);

            //first, make sure there's a connection
            Utility.WriteTrace("Overriding the connection string...");
            provider.DefaultConnectionString = GetConnnectionString();
            provider.GeneratedNamespace = string.IsNullOrEmpty(_namespace) ? "SubSonic.Generated" : _namespace;
            AddLogEntry(LogState.Information, "Set connection string to " + provider.DefaultConnectionString);

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
        /// <summary>
        /// Override to add values directly since we do not have arguments
        /// </summary>
        /// <param name="config"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        private static void SetConfig(System.Collections.Specialized.NameValueCollection config, string key,string value)
        {
            string setting = value;
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
                AddLogEntry( LogState.Information ,"Building configuration from " + Path.Combine(Directory.GetCurrentDirectory(), appConfigPath));
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
                            AddLogEntry(LogState.Information, "Overriding default templates with those from " + section.TemplateDirectory);
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
                            AddLogEntry(LogState.Information, "Adding connection to " + provider.Name);

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
                                AddLogEntry(LogState.Error, string.Format("ERROR: There is no provider with the name '{0}'. Exception: {1}", providerName, e));
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

        private static string GetOutputDirectory()
        {
            string result;

            //this can be an absolute reference, or a partial name of a directory
            //like "App_Code/Generated"

            //see if this path is absolute
            string thisOutput = _outputPath;

            //if there's a drive specified, then it's absolute
            if (thisOutput.Contains(":"))
            {
                result = thisOutput;
            }
            else
            {
                result = Path.Combine(Directory.GetCurrentDirectory(), thisOutput);
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

        private static string GetConnnectionString()
        {
            bool haveError = false;

            string server = _server;
            string db = _database;

            if (server == string.Empty)
            {
                Console.WriteLine("No server name was passed in - please specify using /s MyServerName");
                haveError = true;
            }
            if (db == string.Empty)
            {
                Console.WriteLine("No Database name was passed in - please specify using /db MyDatabaseName");
                haveError = true;
            }

            //optional
            //string tableList = GetArg("tablelist"); //Not being used.
            string userID = _userid;
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
                //ThrowHelp(false);
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
            //SetProvider();
            SetProviderManually();
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

                AddLogEntry(LogState.Information,"Scripting Data");
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
                string outFileName = string.Format("{0}_Data_{1}_{2}_{3}.sql", provider.Name, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                string outPath = Path.Combine(outDir, outFileName);

                OutputFile(outPath, sb.ToString());
                AddLogEntry(LogState.Information,"Finished!");
            }
        }

        public static void ScriptSchema()
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
                    string outFileName = string.Format("{0}_Schema_{1}_{2}_{3}.sql", provider.Name, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                    string outPath = Path.Combine(outDir, outFileName);

                    OutputFile(outPath, schema);
                    AddLogEntry(LogState.Information, "Finished!");
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

        private static void GenerateEditor(string table, string outDir)
        {
            bool haveError = false;
           // WriteVersionInformation("");

            if (table == string.Empty)
            {
                Console.WriteLine("No table name was entered; please specify the name of the table using /table");
                haveError = true;
            }


            if (!haveError)
            {
                Console.WriteLine("Generating editor for " + table);

                if (DataService.Provider == null)
                {
                    SetProvider();
                }


                string fileExt = FileExtension.DOT_CS;
                string lang = _language;
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
                    Console.WriteLine("ERROR: Can't generate editor for " + table + ".");
                    Console.WriteLine("Please check the table name and that the you specified the right provider (you can set the provider by using /provider)");
                }
            }
            else
            {
               // ThrowHelp(false);
            }
        }

        public static void GenerateAll()
        {
            GenerateTables();
            GenerateODSControllers();
            GenerateViews();
            GenerateSPs();
            GenerateStructs();
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
            string tableList = _includeTables;//GetArg("tablelist");
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

        private static void GenerateTables()
        {
            //if (DataService.Provider == null)
            SetProvider();

            string fileExt = FileExtension.DOT_CS;
            string lang = _language;


            if (FileExtension.IsVB(lang))
            {
                language = new VBCodeLanguage();
                fileExt = FileExtension.DOT_VB;
            }
            //string usings = ParseUtility.GetUsings(language);

            if (DataService.Providers.Count == 0)
            {
                Console.WriteLine("There's a problem with the providers - none were loaded and no exceptions where thrown.");
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


                    AddLogEntry(LogState.Information, message);
                    string outDir = GetOutSubDir(provider);

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
                AddLogEntry(LogState.Information, "Finished");
            }
        }

        private static void GenerateODSControllers()
        {
            //if (DataService.Provider == null)
            SetProvider();

            string fileExt = FileExtension.DOT_CS;
            string lang = _language;

            if (FileExtension.IsVB(lang))
            {
                language = new VBCodeLanguage();
                fileExt = FileExtension.DOT_VB;
            }

            if (DataService.Providers.Count == 0)
            {
                Console.WriteLine("There's a problem with the providers - none were loaded and no exceptions where thrown.");
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


                    Console.WriteLine(message);
                    string outDir = GetOutSubDir(provider);

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
                Console.WriteLine("Finished");
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

        private static void GenerateViews()
        {
            //if (DataService.Provider == null)
            SetProvider();

            string lang = _language;
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

        private static void GenerateSPs()
        {
            //if (DataService.Provider == null)
            SetProvider();


            string lang = _language;
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
                string outPath = Path.Combine(outDir, "StoredProcedures" + fileExt);
                AddLogEntry(LogState.Information, "Generating SPs to " + outPath);

                TurboTemplate tt = CodeService.BuildSPTemplate(language, provider);
                tt.OutputPath = outPath;
                turboCompiler.AddTemplate(tt);
            }

            AddLogEntry(LogState.Information, "Finished");
        }

        private static void GenerateStructs()
        {
            //if (DataService.Provider == null)
            SetProvider();

            string lang = _language;
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
            string outPath = Path.Combine(outDir, "AllStructs" + fileExt);
            AddLogEntry(LogState.Information, "Generating Structs to " + outPath);
            TurboTemplate tt = CodeService.BuildStructsTemplate(language, DataService.Provider);
            tt.OutputPath = outPath;
            turboCompiler.AddTemplate(tt);


            AddLogEntry(LogState.Information, "Finished");
        }
        private static void AddLogEntry(LogState state, string Info)
        {
            ApplicationLog.AddEntry(state, Info);
        }
        #endregion
        #region Public Methods
        private static string _database;
        private static string _server;
        private static string _userid;
        private static string _password;

        /// <summary>
        /// Connect to the DataSource
        /// </summary>
        /// <param name="Server">Location of Server</param>
        /// <param name="DataBase">Database</param>
        public static void CreateConnection(string Server, string DataBase)
        {
            _server = Server;
            _database = DataBase;
            arguments = new Arguments(string.Empty);
            try
            {
                SetProviderManually();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ProviderError);
            }
        }
        /// <summary>
        /// Connect to the DataSource
        /// </summary>
        /// <param name="Server">Location of Server</param>
        /// <param name="UserID">User ID</param>
        /// <param name="Password">Password</param>
        /// <param name="Database">Database</param>
        public static void CreateConnection(string Server, string UserID, string Password, string Database)
        {
            _userid = UserID;
            _password = Password;
            CreateConnection(Server, Database);
        }
        /// <summary>
        /// Connect to the DataSource using flat file database eg. SQL Compact 2005
        /// </summary>
        /// <param name="Database"></param>
        public static void CreateConnection(string Database)
        {
            _database = Database;
            try
            {
                SetProviderManually();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ProviderError);
            }
        }
        static string ProviderError = "An error occured setting the provider";
        public static void RefreshProviders()
        {
            SetProviderManually();
        }
        #endregion
        #region Public Properties
        static string _outputPath;
        public static string OutputPath
        {
            get
            {
                return _outputPath;
            }
            set
            {
                _outputPath = value;
            }
        }
        static string _templatePath;
        public static string TemplatePath
        {
            get
            {
                return _templatePath;
            }
            set
            {
                _templatePath = value;
            }
        }
        static string _namespace;
        public static string Namespace
        {
            get
            {
                return _namespace;
            }
            set
            {
                _namespace = value;
            }
        }
        private static string _includeTables = string.Empty;
        public static string IncludeTables
        {
            get
            {
                return _includeTables;
            }
            set
            {
                _includeTables = value;
            }
        }
        public static void Compile()
        {
            if (turboCompiler.Templates.Count > 0)
            {
                AddLogEntry(LogState.Information,"Running Compiler...");
                turboCompiler.Run();
                AddLogEntry(LogState.Information, "Writing Files...");
                foreach (TurboTemplate template in turboCompiler.Templates)
                {
                    Utility.WriteTrace("Writing " + template.TemplateName + " as " + template.OutputPath.Substring(template.OutputPath.LastIndexOf("\\") + 1));
                    SubSonic.Sugar.Files.CreateToFile(template.OutputPath, template.FinalCode);
                }
                AddLogEntry(LogState.Information, "Done!");
            }
        }
        static string regexMatch;
        public static string RegexMatch
        {
            get
            {
                return regexMatch;
            }
            set
            {
                regexMatch = value;
            }
        }
        static string regexReplace;
        public static string RegexReplace
        {
            get
            {
                return regexReplace;
            }
            set
            {
                regexReplace = value;
            }
        }
        static bool regexIgnoreCase;
        public static bool RegexIgnoreCase
        {
            get
            {
                return regexIgnoreCase;
            }
            set
            {
                regexIgnoreCase = value;
            }
        }
        static string _language = "cs";
        public static string Language
        {
            get
            {
                return _language;
            }
            set
            {
                _language = value;
            }
        }
        static bool _fixCasing;
        public static bool FixCasing
        {
            get
            {
                return _fixCasing;
            }
            set
            {
                _fixCasing = value;
            }
        }
        static bool _fixPlural;
        public static bool FixPlural
        {
            get
            {
                return _fixPlural;
            }
            set
            {
                _fixPlural = value;
            }
        }
        static bool _generateSP;
        public static bool GenerateSP
        {
            get
            {
                return _generateSP;
            }
            set
            {
                _generateSP = value;
            }
        }
        static bool _removeUnderScore;
        public static bool RemoveUnderScore
        {
            get
            {
                return _removeUnderScore;
            }
            set
            {
                _removeUnderScore = value;
            }
        }
        static bool _lazyLoad;
        public static bool LazyLoad
        {
            get
            {
                return _lazyLoad;
            }
            set
            {
                _lazyLoad = value;
            }
        }
        static bool _genRelationProperties;
        public static bool GenRelationProperties
        {
            get
            {
                return _genRelationProperties;
            }
            set
            {
                _genRelationProperties = value;
            }
        }
        static string regexDictReplace;

        public static string RegexDictReplace
        {
            get { return regexDictReplace; }
            set { regexDictReplace = value; }
        }
        #endregion
    }
}