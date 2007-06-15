using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Text;
using System.Reflection;
using System.Configuration;
using System.Windows.Forms;
using System.IO;
using SubSonic;
using SubSonic.Utilities;
using SubSonic.CodeGenerator;
using ComponentFactory.Krypton.Toolkit;
/*
 * I have taken some code form SubCommander to initialise the connections
 * 
 */
namespace SonicUI
{
    public partial class MainForm : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        string possibleargs = @"override
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
        public MainForm()
        {
            InitializeComponent();
            char[] charSeparators = new char[] {','};
            string[] result = possibleargs.Split(charSeparators);
            for (int i = 0; i < result.Length; i++)
			{
                arguments.Add(result[i].Replace(",",string.Empty),string.Empty);
			}
#if DEBUG
            txtServer.Text = @"YAVIN\SQLEXPRESS";
            txtBase.Text = "orbitserver";
            txtPass.Text = "arch22";
            txtUser.Text = "sa";
            txtNameSpace.Text = "SonicUI.Dal";
            
            if (!Directory.Exists(Application.StartupPath + @"\DAL"))
            {
                Directory.CreateDirectory(Application.StartupPath + @"\DAL");
            }
            outDIR = Application.StartupPath + @"\DAL";
            txtOutPath.Text = outDIR;
#endif
        }
        string cnfPath= string.Empty;
        string outDIR = string.Empty;
        private void btnPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog fbd = new OpenFileDialog();
            DialogResult dr = fbd.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                cnfPath = fbd.FileName;
                configPath.Text = cnfPath;
            }
        }
        SubSonic.DataProviderType providername = new SubSonic.DataProviderType();
        private void MainForm_Load(object sender, EventArgs e)
        {
            providerCombo.DataSource = Enum.GetValues(typeof(SubSonic.DataProviderType)); 
        }

        private void providerCombo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            providername = (SubSonic.DataProviderType)this.providerCombo.SelectedValue;
        }
        WorkItemCollection items = new WorkItemCollection();
        BindingList<DataProvider> providers = new BindingList<DataProvider>();
        private void btnEnumData_Click(object sender, EventArgs e)
        {
            PerformConnect();
        }
        void PerformConnect()
        {
            this.UseWaitCursor = true;

            SetDescription("Retrieving Database Info");
            if (checkBox1.Checked)
                SetProvider(configPath.Text);
            else
                SetProviderManually();
            workSource.Clear();
            if (providers != null)
                providers.Clear();
            items.Clear();

            cmbProvider.DisplayMember = "Name";
            cmbProvider.ValueMember = "Name";
            cmbProvider.DataSource = providers;
            Application.DoEvents();
            foreach (DataProvider provider in DataService.Providers)
            {
                try
                {
                    providers.Add(provider);
                    SetDescription("Retrieving Table info");
                    string[] tables = DataService.GetTableNames(provider.Name);
                    for (int i = 0; i < tables.Length; i++)
                    {
                        string t = tables[i];
                        SetDescription(string.Format("Adding Table {0}", t));
                        WorkItem item = new WorkItem();
                        item.TableName = t;
                        item.Type = "Table";
                        item.Create = true;
                        workSource.Add(item);
                        items.Add(item);
                    }

                    Application.DoEvents();
                    SetDescription("Retrieving View info");
                    string[] view = DataService.GetViewNames(provider.Name);
                    for (int iv = 0; iv < view.Length; iv++)
                    {
                        string t = view[iv];
                        SetDescription(string.Format("Adding View {0}", t));
                        WorkItem item = new WorkItem();
                        item.TableName = t;
                        item.Type = "View";
                        item.Create = true;
                        workSource.Add(item);
                        items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection failed for {0}", provider.Name);
                }
            }
            SetDescription("Done");
            this.UseWaitCursor = false;
        }
        void SetDescription(string desc)
        {
            Application.DoEvents();
            objectGroup.ValuesSecondary.Heading = desc;
        }
        string connectionstring = string.Empty;
        void CheckDB()
        {

        }
        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult dr = fbd.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                outDIR = fbd.SelectedPath;
                txtOutPath.Text = outDIR;
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            string appconfig = CreateAppConfig(txtNameSpace.Text,providername.ToString(),txtProvName.ToString(),connectionstring);
            GenerateAll();
            OutputWriteline("#### You can use the following for you app.config ####");
            OutputWriteline(appconfig);
        }
        void GenerateAll()
        {
            progress.Value = 0;
            GenerateTables();
            progress.Value = 20;
            GenerateODSControllers();
            progress.Value = 40;
            GenerateViews();
            progress.Value = 60;
            GenerateSPs();
            progress.Value = 80;
            GenerateStructs();
            progress.Value = 100;
        }
        string excludeTables
        {
            get
            {
                string excludes = string.Empty;
                for (int i = 0; i < workSource.Count; i++)
                {
                    WorkItem item = (WorkItem)workSource[i];
                    if (!item.Create)
                    {
                        excludes += string.Format(",{0}", item.TableName);
                    }
                }
                return excludes;
            }
        }
        string CreateAppConfig(string nspace,string ssprovider,string providername,string connstring)
        {
            string cnf = string.Format(@"<?xml version=\""1.0\"" encoding=\""utf-8\"" ?>
    <configuration>

       <configSections>
        <section name=\""SubSonicService\"" type=\""SubSonic.SubSonicSection, SubSonic\"" allowDefinition=\""MachineToApplication\"" restartOnExternalChanges=\""true\""/>
        </configSections>
       <connectionStrings>
        <add name=\""OrbitRMS.Properties.Settings.Arch\"" connectionString=\""{3}\"" />
       </connectionStrings>
       <SubSonicService defaultProvider=\""{2}\"">    
            <providers>
                <add name=\""{2}\"" type=\""{1}, SubSonic\"" connectionStringName=\""OrbitRMS.Properties.Settings.Server\"" generatedNamespace=\""{0}\""/>
           </providers>
        </SubSonicService>
       </configuration>
    ",nspace,ssprovider,providername,connstring).Replace("\\",string.Empty);
            return cnf;
        }
        string GetConnnectionString()
        {


            bool haveError = false;

            string server = txtServer.Text;
            string db = txtBase.Text;

            if (server == string.Empty)
            {
                OutputWriteline("No server name was passed in - please specify using /s MyServerName");
                haveError = true;
            }
            if (db == string.Empty)
            {
                OutputWriteline("No Database name was passed in - please specify using /s MyServerName");
                haveError = true;
            }

            //optional
            //string tableList = GetArg("tablelist"); //Not being used.
            string userID = txtUser.Text;
            string pasword = txtPass.Text;
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
        void SetProviderManually()
        {
            //Utility.WriteTrace("Setting config manually - need AT LEAST a /server and /db");

            //clear the providers and reset
            DataService.Provider = new SqlDataProvider();
            DataService.Providers = new DataProviderCollection();

            //instance a section - we'll set this manually for the DataService
            SubSonicSection section = new SubSonicSection();
            section.TemplateDirectory = txtTemplatePath.Text;
            CodeService.TemplateDirectory = section.TemplateDirectory;

            string providerName = providername.ToString();
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

            if (!string.IsNullOrEmpty(txtTemplatePath.Text))
                config.Add(ConfigurationPropertyName.TEMPLATE_DIRECTORY, txtTemplatePath.Text);


            //setup the config
            SetConfig(config, ConfigurationPropertyName.GENERATED_NAMESPACE);
            SetConfig(config, ConfigurationPropertyName.INCLUDE_TABLE_LIST);
            SetConfig(config, ConfigurationPropertyName.EXCLUDE_TABLE_LIST);
            SetConfig(config, ConfigurationPropertyName.STORED_PROCEDURE_CLASS_NAME);
            SetConfig(config, ConfigurationPropertyName.STRIP_TABLE_TEXT);
            SetConfig(config, ConfigurationPropertyName.STRIP_STORED_PROCEDURE_TEXT);
            SetConfig(config, ConfigurationPropertyName.STRIP_VIEW_TEXT);
            SetConfig(config, ConfigurationPropertyName.STRIP_COLUMN_TEXT);
            SetConfig(config, ConfigurationPropertyName.STRIP_PARAM_TEXT);
            SetConfig(config, ConfigurationPropertyName.APPEND_WITH);
            SetConfig(config, ConfigurationPropertyName.SP_STARTS_WITH);
            SetConfig(config, ConfigurationPropertyName.VIEW_STARTS_WITH);
            SetConfig(config, ConfigurationPropertyName.RELATED_TABLE_LOAD_PREFIX);
            SetConfig(config, ConfigurationPropertyName.REGEX_MATCH_EXPRESSION);
            SetConfig(config, ConfigurationPropertyName.REGEX_DICTIONARY_REPLACE);
            SetConfig(config, ConfigurationPropertyName.REGEX_REPLACE_EXPRESSION);
            SetConfig(config, ConfigurationPropertyName.FIX_PLURAL_CLASS_NAMES);
            SetConfig(config, ConfigurationPropertyName.REMOVE_UNDERSCORES);
            SetConfig(config, ConfigurationPropertyName.USE_STORED_PROCEDURES);
            SetConfig(config, ConfigurationPropertyName.REGEX_IGNORE_CASE);
            SetConfig(config, ConfigurationPropertyName.GENERATE_LAZY_LOADS);
            SetConfig(config, ConfigurationPropertyName.GENERATE_RELATED_TABLES_AS_PROPERTIES);
            SetConfig(config, ConfigurationPropertyName.EXTRACT_CLASS_NAME_FROM_SP_NAME);
            SetConfig(config, ConfigurationPropertyName.INCLUDE_PROCEDURE_LIST);
            SetConfig(config, ConfigurationPropertyName.EXCLUDE_PROCEDURE_LIST);
            SetConfig(config, ConfigurationPropertyName.USE_EXTENDED_PROPERTIES);


            //initialize the provider
            Utility.WriteTrace("Initializing the provider with the passed in configuration >>> hold on to your hats...");
            provider.Initialize(providerName, config);

            //first, make sure there's a connection
            Utility.WriteTrace("Overriding the connection string...");
            provider.DefaultConnectionString = GetConnnectionString();
            Utility.WriteTrace("Set connection string to " + provider.DefaultConnectionString);

            DataService.Providers.Add(provider);
        }

         void SetConfig(System.Collections.Specialized.NameValueCollection config, string key)
        {
            string setting = GetArg(key);
            if (!String.IsNullOrEmpty(setting))
            {
                Utility.WriteTrace("Setting " + key + " to " + setting);
                config.Add(key, setting);
            }
        }


        void SetProvider(string appConfigPath)
        {


            //clear the providers and reset
            DataService.Provider = new SqlDataProvider();
            DataService.Providers = new DataProviderCollection();


            //if present, get the connection strings and the SubSonic config
            if (File.Exists(appConfigPath))
            {

                ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
                OutputWriteline("Building configuration from " + Path.Combine(Directory.GetCurrentDirectory(), appConfigPath));
                fileMap.ExeConfigFilename = appConfigPath;

                // Open another config file 
                Configuration subConfig = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

                try
                {
                    SubSonicSection section = (SubSonicSection)subConfig.GetSection(ConfigurationSectionName.SUB_SONIC_SERVICE);

                    if (section != null)
                    {
                        DataService.ConfigSection = section;
                        CodeService.TemplateDirectory = section.TemplateDirectory;

                        if (!String.IsNullOrEmpty(section.TemplateDirectory))
                            OutputWriteline("Overriding default templates with those from " + section.TemplateDirectory);


                        //initialize
                        //need to pull out the default connection string
                        //since this application doesn't have a config file, the target one does
                        //so reconciling connection string won't work
                        string connectionStringName = section.Providers[0].Parameters["connectionStringName"];
                        if (connectionStringName == null)
                            throw new ConfigurationErrorsException("The Parameter 'connectionStringName' was not specified");

                        ConnectionStringSettings connSettings = subConfig.ConnectionStrings.ConnectionStrings[connectionStringName];
                        if (connSettings == null)
                            throw new ConfigurationErrorsException(string.Format("ConnectionStrings section missing connection string with the name '{0}'", connectionStringName));

                        string connString = subConfig.ConnectionStrings.ConnectionStrings[connectionStringName].ConnectionString;
                        //DataService.ConnectionString = connString;


                        System.Web.Configuration.ProvidersHelper.InstantiateProviders(section.Providers, DataService.Providers, typeof(DataProvider));

                        //this is a tad backwards, but it's what needs to happen since our application
                        //is configuring another application's providers
                        //go back and reset the provider's connection strings

                        //int counter = 0;
                        foreach (DataProvider provider in DataService.Providers)
                        {
                            OutputWriteline("Adding connection to " + provider.Name);

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
                               // OutputWriteline("ERROR: There is no provider with the name '{0}'. Exception: {1}", providerName, e);

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
                    MessageBox.Show("Can't set the configuration for the providers. There is an error with your config setup (did you remember to configure SubSonic in your config file?). '{0}'", x.Message);

                }
            }
            else
            {
                MessageBox.Show("There's no config file present at " + appConfigPath,"SonicUI",MessageBoxButtons.OK,MessageBoxIcon.Error);

            }

        }

        private StringDictionary arguments = new StringDictionary();
        string GetArg(string argSwitch)
        {
            return arguments[argSwitch] ?? string.Empty;
        }
        void SetArg(string key,string value)
        {
            arguments.Add(key, value);
        }
        private void btnTemplate_Click(object sender, EventArgs e)
        {

        }
        //Ripped From SubCommander
        string GetOutputDirectory()
        {
            string result;

            //this can be an absolute reference, or a partial name of a directory
            //like "App_Code/Generated"

            //see if this path is absolute
            string thisOutput = outDIR;

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
                Directory.CreateDirectory(result);

            return result;

        }
        string GetOutSubDir(DataProvider provider)
        {
            string outDir = GetOutputDirectory();
            if (outDir == string.Empty)
                outDir = Directory.GetCurrentDirectory();

            if (DataService.Providers.Count > 1)
            {
                //this is set by the routines
                outDir = Path.Combine(outDir, provider.Name);
            }
            if (!Directory.Exists(outDir))
                Directory.CreateDirectory(outDir);

            return outDir;
        }
        void GenerateTables()
        {

            //if (DataService.Provider == null)
            //SetProvider();

            string fileExt = FileExtension.DOT_CS;
            string lang = GetArg("lang");
            LanguageType langType = LanguageType.CSharp;

            if (FileExtension.IsVB(lang))
            {
                langType = LanguageType.VB;
                fileExt = FileExtension.DOT_VB;
            }
            string usings = ParseUtility.GetUsings(langType);

            if (DataService.Providers.Count == 0)
            {
                OutputWriteline("There's a problem with the providers - none were loaded and no exceptions where thrown.");

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


                    OutputWriteline(message);
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
                    for (int i = 0; i < workSource.Count; i++)
                    {
                        WorkItem item = (WorkItem)workSource[i];
                        if (item.Create)
                        {
                            string className = DataService.GetSchema(item.TableName, provider.Name, TableType.Table).ClassName;
                            string code = CodeService.RunClass(item.TableName, provider.Name, langType);

                            if (!String.IsNullOrEmpty(code))
                            {
                                string outPath = Path.Combine(outDir, className + fileExt);
                                //Console.Clear();
                                OutputWriteline("Generating class for  " + className + " to " + outPath);
                                Utility.CreateToFile(outPath, usings + code);
                            }
                        }
                    }
                }
                OutputWriteline("Finished");
            }

        }
        void OutputWriteline(string message)
        {
            Application.DoEvents();
            outputText.AppendText(message+"\r\n");
            outputText.ScrollToCaret();
        }
        void GenerateODSControllers()
        {

            //if (DataService.Provider == null)
            //SetProvider();

            string fileExt = FileExtension.DOT_CS;
            string lang = GetArg("lang");
            LanguageType langType = LanguageType.CSharp;

            if (FileExtension.IsVB(lang))
            {
                langType = LanguageType.VB;
                fileExt = FileExtension.DOT_VB;
            }
            string usings = ParseUtility.GetUsings(langType);

            if (DataService.Providers.Count == 0)
            {
                OutputWriteline("There's a problem with the providers - none were loaded and no exceptions where thrown.");

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


                    OutputWriteline(message);
                    string outDir = GetOutSubDir(provider);

                    for (int i = 0; i < workSource.Count; i++)
                    {
                        WorkItem item = (WorkItem)workSource[i];
                        if (item.Create)
                        {
                            string className = DataService.GetSchema(item.TableName, provider.Name, TableType.Table).ClassName;
                            string code = CodeService.RunODS(item.TableName, provider.Name, langType);

                            if (!String.IsNullOrEmpty(code))
                            {
                                string outPath = Path.Combine(outDir, className + "Controller" + fileExt);
                                OutputWriteline("Generating ODS Controller for  " + className + " to " + outPath);
                                Utility.CreateToFile(outPath, usings + code);
                            }

                        }
                    }

                }
                OutputWriteline("Finished");
            }

        }
        void GenerateViews() {
            //if (DataService.Provider == null)
            //SetProvider();

            string lang = GetArg("lang");
            string fileExt = FileExtension.DOT_CS;
            LanguageType langType = LanguageType.CSharp;

            if (FileExtension.IsVB(lang)) {
                langType = LanguageType.VB;
                fileExt = FileExtension.DOT_VB;
            }
            string usings = ParseUtility.GetUsings(langType);

            //loop the providers, and if there's more than one, output to their own folder
            //for tidiness
            foreach (DataProvider provider in DataService.Providers)
            {
                //get the view list
                string[] views = DataService.GetViewNames(provider.Name);
                string outDir = GetOutSubDir(provider);

                foreach(string tbl in views)
                {

                    string className = DataService.GetSchema(tbl, provider.Name, TableType.View).ClassName;
                    string code = usings + CodeService.RunReadOnly(tbl, provider.Name, langType);
                    string outPath = Path.Combine(outDir, className + fileExt);
                    OutputWriteline("Generating ReadOnly class for  " + className + " to " + outPath);

                    Utility.CreateToFile(outPath, code);
                }
            }

            OutputWriteline("Finished");
        }

        void GenerateSPs() {
            //if (DataService.Provider == null)
           // SetProvider();
            

            string lang = GetArg("lang");
            string fileExt = FileExtension.DOT_CS;
            LanguageType langType = LanguageType.CSharp;

            if (FileExtension.IsVB(lang))
            {
                langType = LanguageType.VB;
                fileExt = FileExtension.DOT_VB;
            }
            string usings = ParseUtility.GetUsings(langType);

            //loop the providers, and if there's more than one, output to their own folder
            //for tidiness
            foreach (DataProvider provider in DataService.Providers)
            {

                string code = usings + CodeService.RunSPs(provider.Name, langType);
                string outDir = GetOutSubDir(provider);
                if(outDir == string.Empty)
                    outDir = Directory.GetCurrentDirectory();
                string outPath = Path.Combine(outDir, "StoredProcedures" + fileExt);
                OutputWriteline("Generating SPs to " + outPath);

                Utility.CreateToFile(outPath, code);
            }

            OutputWriteline("Finished");
        }
        void GenerateStructs() {
            //if (DataService.Provider == null)
            //SetProvider();

            string lang = GetArg("lang");
            string fileExt = FileExtension.DOT_CS;
            LanguageType langType = LanguageType.CSharp;
            

            if (FileExtension.IsVB(lang))
            {
                langType = LanguageType.VB;
                fileExt = FileExtension.DOT_VB;
            }
            string usings = ParseUtility.GetUsings(langType);


            string code = usings + CodeService.RunStructs(langType);

            string outDir = GetOutputDirectory();
            if (outDir == string.Empty)
                outDir = Directory.GetCurrentDirectory();
            string outPath = Path.Combine(outDir, "AllStructs" + fileExt);
            OutputWriteline("Generating Structs to " + outPath);

            Utility.CreateToFile(outPath, code);

            OutputWriteline("Finished");
        }

        private void txtOutPath_TextChanged(object sender, EventArgs e)
        {
            outDIR = txtOutPath.Text;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                kryptonGroup1.Enabled = false;
            }
            else
            {
                kryptonGroup1.Enabled = true;
            }

        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void buttonSpecHeaderGroup1_Click(object sender, EventArgs e)
        {
            if (objectGroup.Collapsed)
            {
                objectGroup.HeaderPositionPrimary = VisualOrientation.Right;
                objectGroup.ButtonSpecs[0].Edge = PaletteRelativeEdgeAlign.Near;
            }
            else
            {
                objectGroup.HeaderPositionPrimary = VisualOrientation.Top;
                objectGroup.ButtonSpecs[0].Edge = PaletteRelativeEdgeAlign.Far;
            }
        }

        private void buttonSpecHeaderGroup2_Click(object sender, EventArgs e)
        {
            if (advGroup.Collapsed)
            {
                advGroup.HeaderPositionPrimary = VisualOrientation.Right;
                advGroup.ButtonSpecs[0].Edge = PaletteRelativeEdgeAlign.Near;
            }
            else
            {
                advGroup.HeaderPositionPrimary = VisualOrientation.Top;
                advGroup.ButtonSpecs[0].Edge = PaletteRelativeEdgeAlign.Near;
            }
        }

        private void btnAdvPlural_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            PerformConnect();
        }

        private void btnAdvPlural_CheckedChanged(object sender, EventArgs e)
        {
            if (btnAdvPlural.Checked)
            {
                SetArg("fixPluralClassNames", "true");
            }
            else
            {
                SetArg("fixPluralClassNames", "false");
            }
        }

        private void kryptonCheckButton1_CheckedChanged(object sender, EventArgs e)
        {
            KryptonCheckButton btn = sender as KryptonCheckButton;
            SetArg(btn.Tag.ToString(), btn.Checked.ToString().ToLower());
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < workSource.Count; i++)
            {
                WorkItem item = workSource[i] as WorkItem;
                if (!item.Create)
                    item.Create = true;
                workGrid.Refresh();
            }
        }

        private void selectNoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < workSource.Count; i++)
            {
                WorkItem item = workSource[i] as WorkItem;
                if (item.Create)
                    item.Create = false;
                workGrid.Refresh();
            }
        }
    }
}