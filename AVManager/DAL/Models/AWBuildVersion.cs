using System; 
using System.Text; 
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; 
using System.Xml; 
using System.Xml.Serialization;
using SubSonic; 
using SubSonic.Utilities;

namespace AVManager.DAL
{
	/// <summary>
	/// Strongly-typed collection for the AWBuildVersion class.
	/// </summary>
	[Serializable]
	public partial class AWBuildVersionCollection : ActiveList<AWBuildVersion, AWBuildVersionCollection> 
	{	   
		public AWBuildVersionCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the AWBuildVersion table.
	/// </summary>
	[Serializable]
	public partial class AWBuildVersion : ActiveRecord<AWBuildVersion>
	{
		#region .ctors and Default Settings
		
		public AWBuildVersion()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public AWBuildVersion(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public AWBuildVersion(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public AWBuildVersion(string columnName, object columnValue)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByParam(columnName,columnValue);
		}

		
		protected static void SetSQLProps() { GetTableSchema(); }

		
		#endregion
		
		#region Schema and Query Accessor
		public static Query CreateQuery() { return new Query(Schema); }

		
		public static TableSchema.Table Schema
		{
			get
			{
				if (BaseSchema == null)
					SetSQLProps();
				return BaseSchema;
			}

		}

		
		private static void GetTableSchema() 
		{
			if(!IsSchemaInitialized)
			{
				//Schema declaration
				TableSchema.Table schema = new TableSchema.Table("AWBuildVersion", TableType.Table, DataService.GetInstance("Default"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarSystemInformationID = new TableSchema.TableColumn(schema);
				colvarSystemInformationID.ColumnName = "SystemInformationID";
				colvarSystemInformationID.DataType = DbType.Byte;
				colvarSystemInformationID.MaxLength = 0;
				colvarSystemInformationID.AutoIncrement = true;
				colvarSystemInformationID.IsNullable = false;
				colvarSystemInformationID.IsPrimaryKey = true;
				colvarSystemInformationID.IsForeignKey = false;
				colvarSystemInformationID.IsReadOnly = false;
				colvarSystemInformationID.DefaultSetting = @"";
				colvarSystemInformationID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSystemInformationID);
				
				TableSchema.TableColumn colvarDatabaseVersion = new TableSchema.TableColumn(schema);
				colvarDatabaseVersion.ColumnName = "Database Version";
				colvarDatabaseVersion.DataType = DbType.String;
				colvarDatabaseVersion.MaxLength = 25;
				colvarDatabaseVersion.AutoIncrement = false;
				colvarDatabaseVersion.IsNullable = false;
				colvarDatabaseVersion.IsPrimaryKey = false;
				colvarDatabaseVersion.IsForeignKey = false;
				colvarDatabaseVersion.IsReadOnly = false;
				colvarDatabaseVersion.DefaultSetting = @"";
				colvarDatabaseVersion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDatabaseVersion);
				
				TableSchema.TableColumn colvarVersionDate = new TableSchema.TableColumn(schema);
				colvarVersionDate.ColumnName = "VersionDate";
				colvarVersionDate.DataType = DbType.DateTime;
				colvarVersionDate.MaxLength = 0;
				colvarVersionDate.AutoIncrement = false;
				colvarVersionDate.IsNullable = false;
				colvarVersionDate.IsPrimaryKey = false;
				colvarVersionDate.IsForeignKey = false;
				colvarVersionDate.IsReadOnly = false;
				colvarVersionDate.DefaultSetting = @"";
				colvarVersionDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVersionDate);
				
				TableSchema.TableColumn colvarModifiedDate = new TableSchema.TableColumn(schema);
				colvarModifiedDate.ColumnName = "ModifiedDate";
				colvarModifiedDate.DataType = DbType.DateTime;
				colvarModifiedDate.MaxLength = 0;
				colvarModifiedDate.AutoIncrement = false;
				colvarModifiedDate.IsNullable = false;
				colvarModifiedDate.IsPrimaryKey = false;
				colvarModifiedDate.IsForeignKey = false;
				colvarModifiedDate.IsReadOnly = false;
				
						colvarModifiedDate.DefaultSetting = @"(getdate())";
				colvarModifiedDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarModifiedDate);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["Default"].AddSchema("AWBuildVersion",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("SystemInformationID")]
		public byte SystemInformationID 
		{
			get { return GetColumnValue<byte>(Columns.SystemInformationID); }

			set { SetColumnValue(Columns.SystemInformationID, value); }

		}

		  
		[XmlAttribute("DatabaseVersion")]
		public string DatabaseVersion 
		{
			get { return GetColumnValue<string>(Columns.DatabaseVersion); }

			set { SetColumnValue(Columns.DatabaseVersion, value); }

		}

		  
		[XmlAttribute("VersionDate")]
		public DateTime VersionDate 
		{
			get { return GetColumnValue<DateTime>(Columns.VersionDate); }

			set { SetColumnValue(Columns.VersionDate, value); }

		}

		  
		[XmlAttribute("ModifiedDate")]
		public DateTime ModifiedDate 
		{
			get { return GetColumnValue<DateTime>(Columns.ModifiedDate); }

			set { SetColumnValue(Columns.ModifiedDate, value); }

		}

		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varDatabaseVersion,DateTime varVersionDate,DateTime varModifiedDate)
		{
			AWBuildVersion item = new AWBuildVersion();
			
			item.DatabaseVersion = varDatabaseVersion;
			
			item.VersionDate = varVersionDate;
			
			item.ModifiedDate = varModifiedDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(byte varSystemInformationID,string varDatabaseVersion,DateTime varVersionDate,DateTime varModifiedDate)
		{
			AWBuildVersion item = new AWBuildVersion();
			
				item.SystemInformationID = varSystemInformationID;
			
				item.DatabaseVersion = varDatabaseVersion;
			
				item.VersionDate = varVersionDate;
			
				item.ModifiedDate = varModifiedDate;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		#endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string SystemInformationID = @"SystemInformationID";
			 public static string DatabaseVersion = @"Database Version";
			 public static string VersionDate = @"VersionDate";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}

		#endregion
	}

}

