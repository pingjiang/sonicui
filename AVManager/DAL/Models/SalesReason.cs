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
	/// Strongly-typed collection for the SalesReason class.
	/// </summary>
	[Serializable]
	public partial class SalesReasonCollection : ActiveList<SalesReason, SalesReasonCollection> 
	{	   
		public SalesReasonCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the SalesReason table.
	/// </summary>
	[Serializable]
	public partial class SalesReason : ActiveRecord<SalesReason>
	{
		#region .ctors and Default Settings
		
		public SalesReason()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public SalesReason(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public SalesReason(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public SalesReason(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("SalesReason", TableType.Table, DataService.GetInstance("Default"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Sales";
				//columns
				
				TableSchema.TableColumn colvarSalesReasonID = new TableSchema.TableColumn(schema);
				colvarSalesReasonID.ColumnName = "SalesReasonID";
				colvarSalesReasonID.DataType = DbType.Int32;
				colvarSalesReasonID.MaxLength = 0;
				colvarSalesReasonID.AutoIncrement = true;
				colvarSalesReasonID.IsNullable = false;
				colvarSalesReasonID.IsPrimaryKey = true;
				colvarSalesReasonID.IsForeignKey = false;
				colvarSalesReasonID.IsReadOnly = false;
				colvarSalesReasonID.DefaultSetting = @"";
				colvarSalesReasonID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSalesReasonID);
				
				TableSchema.TableColumn colvarName = new TableSchema.TableColumn(schema);
				colvarName.ColumnName = "Name";
				colvarName.DataType = DbType.String;
				colvarName.MaxLength = 50;
				colvarName.AutoIncrement = false;
				colvarName.IsNullable = false;
				colvarName.IsPrimaryKey = false;
				colvarName.IsForeignKey = false;
				colvarName.IsReadOnly = false;
				colvarName.DefaultSetting = @"";
				colvarName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarName);
				
				TableSchema.TableColumn colvarReasonType = new TableSchema.TableColumn(schema);
				colvarReasonType.ColumnName = "ReasonType";
				colvarReasonType.DataType = DbType.String;
				colvarReasonType.MaxLength = 50;
				colvarReasonType.AutoIncrement = false;
				colvarReasonType.IsNullable = false;
				colvarReasonType.IsPrimaryKey = false;
				colvarReasonType.IsForeignKey = false;
				colvarReasonType.IsReadOnly = false;
				colvarReasonType.DefaultSetting = @"";
				colvarReasonType.ForeignKeyTableName = "";
				schema.Columns.Add(colvarReasonType);
				
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
				DataService.Providers["Default"].AddSchema("SalesReason",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("SalesReasonID")]
		public int SalesReasonID 
		{
			get { return GetColumnValue<int>(Columns.SalesReasonID); }

			set { SetColumnValue(Columns.SalesReasonID, value); }

		}

		  
		[XmlAttribute("Name")]
		public string Name 
		{
			get { return GetColumnValue<string>(Columns.Name); }

			set { SetColumnValue(Columns.Name, value); }

		}

		  
		[XmlAttribute("ReasonType")]
		public string ReasonType 
		{
			get { return GetColumnValue<string>(Columns.ReasonType); }

			set { SetColumnValue(Columns.ReasonType, value); }

		}

		  
		[XmlAttribute("ModifiedDate")]
		public DateTime ModifiedDate 
		{
			get { return GetColumnValue<DateTime>(Columns.ModifiedDate); }

			set { SetColumnValue(Columns.ModifiedDate, value); }

		}

		
		#endregion
		
		
		#region PrimaryKey Methods
		
		public AVManager.DAL.SalesOrderHeaderSalesReasonCollection SalesOrderHeaderSalesReasonRecords()
		{
			return new AVManager.DAL.SalesOrderHeaderSalesReasonCollection().Where(SalesOrderHeaderSalesReason.Columns.SalesReasonID, SalesReasonID).Load();
		}

		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		#region Many To Many Helpers
		
		 
		public AVManager.DAL.SalesOrderHeaderCollection GetSalesOrderHeaderCollection() { return SalesReason.GetSalesOrderHeaderCollection(this.SalesReasonID); }

		public static AVManager.DAL.SalesOrderHeaderCollection GetSalesOrderHeaderCollection(int varSalesReasonID)
		{
			SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
				"SELECT * FROM SalesOrderHeader INNER JOIN SalesOrderHeaderSalesReason ON "+
				"SalesOrderHeader.SalesOrderID=SalesOrderHeaderSalesReason.SalesOrderID WHERE SalesOrderHeaderSalesReason.SalesReasonID=@SalesReasonID", SalesReason.Schema.Provider.Name);
			
			cmd.AddParameter("@SalesReasonID", varSalesReasonID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			SalesOrderHeaderCollection coll = new SalesOrderHeaderCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}

		
		public static void SaveSalesOrderHeaderMap(int varSalesReasonID, SalesOrderHeaderCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM SalesOrderHeaderSalesReason WHERE SalesReasonID=@SalesReasonID", SalesReason.Schema.Provider.Name);
			cmdDel.AddParameter("@SalesReasonID", varSalesReasonID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (SalesOrderHeader item in items)
			{
				SalesOrderHeaderSalesReason varSalesOrderHeaderSalesReason = new SalesOrderHeaderSalesReason();
				varSalesOrderHeaderSalesReason.SetColumnValue("SalesReasonID", varSalesReasonID);
				varSalesOrderHeaderSalesReason.SetColumnValue("SalesOrderID", item.GetPrimaryKeyValue());
				varSalesOrderHeaderSalesReason.Save();
			}

		}

		public static void SaveSalesOrderHeaderMap(int varSalesReasonID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM SalesOrderHeaderSalesReason WHERE SalesReasonID=@SalesReasonID", SalesReason.Schema.Provider.Name);
			cmdDel.AddParameter("@SalesReasonID", varSalesReasonID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					SalesOrderHeaderSalesReason varSalesOrderHeaderSalesReason = new SalesOrderHeaderSalesReason();
					varSalesOrderHeaderSalesReason.SetColumnValue("SalesReasonID", varSalesReasonID);
					varSalesOrderHeaderSalesReason.SetColumnValue("SalesOrderID", l.Value);
					varSalesOrderHeaderSalesReason.Save();
				}

			}

		}

		public static void SaveSalesOrderHeaderMap(int varSalesReasonID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM SalesOrderHeaderSalesReason WHERE SalesReasonID=@SalesReasonID", SalesReason.Schema.Provider.Name);
			cmdDel.AddParameter("@SalesReasonID", varSalesReasonID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				SalesOrderHeaderSalesReason varSalesOrderHeaderSalesReason = new SalesOrderHeaderSalesReason();
				varSalesOrderHeaderSalesReason.SetColumnValue("SalesReasonID", varSalesReasonID);
				varSalesOrderHeaderSalesReason.SetColumnValue("SalesOrderID", item);
				varSalesOrderHeaderSalesReason.Save();
			}

		}

		
		public static void DeleteSalesOrderHeaderMap(int varSalesReasonID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM SalesOrderHeaderSalesReason WHERE SalesReasonID=@SalesReasonID", SalesReason.Schema.Provider.Name);
			cmdDel.AddParameter("@SalesReasonID", varSalesReasonID);
			DataService.ExecuteQuery(cmdDel);
		}

		
		#endregion
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varName,string varReasonType,DateTime varModifiedDate)
		{
			SalesReason item = new SalesReason();
			
			item.Name = varName;
			
			item.ReasonType = varReasonType;
			
			item.ModifiedDate = varModifiedDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varSalesReasonID,string varName,string varReasonType,DateTime varModifiedDate)
		{
			SalesReason item = new SalesReason();
			
				item.SalesReasonID = varSalesReasonID;
			
				item.Name = varName;
			
				item.ReasonType = varReasonType;
			
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
			 public static string SalesReasonID = @"SalesReasonID";
			 public static string Name = @"Name";
			 public static string ReasonType = @"ReasonType";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}

		#endregion
	}

}

