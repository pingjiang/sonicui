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
	/// Strongly-typed collection for the SalesTerritoryHistory class.
	/// </summary>
	[Serializable]
	public partial class SalesTerritoryHistoryCollection : ActiveList<SalesTerritoryHistory, SalesTerritoryHistoryCollection> 
	{	   
		public SalesTerritoryHistoryCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the SalesTerritoryHistory table.
	/// </summary>
	[Serializable]
	public partial class SalesTerritoryHistory : ActiveRecord<SalesTerritoryHistory>
	{
		#region .ctors and Default Settings
		
		public SalesTerritoryHistory()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public SalesTerritoryHistory(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public SalesTerritoryHistory(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public SalesTerritoryHistory(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("SalesTerritoryHistory", TableType.Table, DataService.GetInstance("Default"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Sales";
				//columns
				
				TableSchema.TableColumn colvarSalesPersonID = new TableSchema.TableColumn(schema);
				colvarSalesPersonID.ColumnName = "SalesPersonID";
				colvarSalesPersonID.DataType = DbType.Int32;
				colvarSalesPersonID.MaxLength = 0;
				colvarSalesPersonID.AutoIncrement = false;
				colvarSalesPersonID.IsNullable = false;
				colvarSalesPersonID.IsPrimaryKey = true;
				colvarSalesPersonID.IsForeignKey = true;
				colvarSalesPersonID.IsReadOnly = false;
				colvarSalesPersonID.DefaultSetting = @"";
				
					colvarSalesPersonID.ForeignKeyTableName = "SalesPerson";
				schema.Columns.Add(colvarSalesPersonID);
				
				TableSchema.TableColumn colvarTerritoryID = new TableSchema.TableColumn(schema);
				colvarTerritoryID.ColumnName = "TerritoryID";
				colvarTerritoryID.DataType = DbType.Int32;
				colvarTerritoryID.MaxLength = 0;
				colvarTerritoryID.AutoIncrement = false;
				colvarTerritoryID.IsNullable = false;
				colvarTerritoryID.IsPrimaryKey = true;
				colvarTerritoryID.IsForeignKey = true;
				colvarTerritoryID.IsReadOnly = false;
				colvarTerritoryID.DefaultSetting = @"";
				
					colvarTerritoryID.ForeignKeyTableName = "SalesTerritory";
				schema.Columns.Add(colvarTerritoryID);
				
				TableSchema.TableColumn colvarStartDate = new TableSchema.TableColumn(schema);
				colvarStartDate.ColumnName = "StartDate";
				colvarStartDate.DataType = DbType.DateTime;
				colvarStartDate.MaxLength = 0;
				colvarStartDate.AutoIncrement = false;
				colvarStartDate.IsNullable = false;
				colvarStartDate.IsPrimaryKey = true;
				colvarStartDate.IsForeignKey = false;
				colvarStartDate.IsReadOnly = false;
				colvarStartDate.DefaultSetting = @"";
				colvarStartDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStartDate);
				
				TableSchema.TableColumn colvarEndDate = new TableSchema.TableColumn(schema);
				colvarEndDate.ColumnName = "EndDate";
				colvarEndDate.DataType = DbType.DateTime;
				colvarEndDate.MaxLength = 0;
				colvarEndDate.AutoIncrement = false;
				colvarEndDate.IsNullable = true;
				colvarEndDate.IsPrimaryKey = false;
				colvarEndDate.IsForeignKey = false;
				colvarEndDate.IsReadOnly = false;
				colvarEndDate.DefaultSetting = @"";
				colvarEndDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEndDate);
				
				TableSchema.TableColumn colvarRowguid = new TableSchema.TableColumn(schema);
				colvarRowguid.ColumnName = "rowguid";
				colvarRowguid.DataType = DbType.Guid;
				colvarRowguid.MaxLength = 0;
				colvarRowguid.AutoIncrement = false;
				colvarRowguid.IsNullable = false;
				colvarRowguid.IsPrimaryKey = false;
				colvarRowguid.IsForeignKey = false;
				colvarRowguid.IsReadOnly = false;
				
						colvarRowguid.DefaultSetting = @"(newid())";
				colvarRowguid.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRowguid);
				
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
				DataService.Providers["Default"].AddSchema("SalesTerritoryHistory",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("SalesPersonID")]
		public int SalesPersonID 
		{
			get { return GetColumnValue<int>(Columns.SalesPersonID); }

			set { SetColumnValue(Columns.SalesPersonID, value); }

		}

		  
		[XmlAttribute("TerritoryID")]
		public int TerritoryID 
		{
			get { return GetColumnValue<int>(Columns.TerritoryID); }

			set { SetColumnValue(Columns.TerritoryID, value); }

		}

		  
		[XmlAttribute("StartDate")]
		public DateTime StartDate 
		{
			get { return GetColumnValue<DateTime>(Columns.StartDate); }

			set { SetColumnValue(Columns.StartDate, value); }

		}

		  
		[XmlAttribute("EndDate")]
		public DateTime? EndDate 
		{
			get { return GetColumnValue<DateTime?>(Columns.EndDate); }

			set { SetColumnValue(Columns.EndDate, value); }

		}

		  
		[XmlAttribute("Rowguid")]
		public Guid Rowguid 
		{
			get { return GetColumnValue<Guid>(Columns.Rowguid); }

			set { SetColumnValue(Columns.Rowguid, value); }

		}

		  
		[XmlAttribute("ModifiedDate")]
		public DateTime ModifiedDate 
		{
			get { return GetColumnValue<DateTime>(Columns.ModifiedDate); }

			set { SetColumnValue(Columns.ModifiedDate, value); }

		}

		
		#endregion
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SalesPerson ActiveRecord object related to this SalesTerritoryHistory
		/// 
		/// </summary>
		public AVManager.DAL.SalesPerson SalesPerson
		{
			get { return AVManager.DAL.SalesPerson.FetchByID(this.SalesPersonID); }

			set { SetColumnValue("SalesPersonID", value.SalesPersonID); }

		}

		
		
		/// <summary>
		/// Returns a SalesTerritory ActiveRecord object related to this SalesTerritoryHistory
		/// 
		/// </summary>
		public AVManager.DAL.SalesTerritory SalesTerritory
		{
			get { return AVManager.DAL.SalesTerritory.FetchByID(this.TerritoryID); }

			set { SetColumnValue("TerritoryID", value.TerritoryID); }

		}

		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varSalesPersonID,int varTerritoryID,DateTime varStartDate,DateTime? varEndDate,Guid varRowguid,DateTime varModifiedDate)
		{
			SalesTerritoryHistory item = new SalesTerritoryHistory();
			
			item.SalesPersonID = varSalesPersonID;
			
			item.TerritoryID = varTerritoryID;
			
			item.StartDate = varStartDate;
			
			item.EndDate = varEndDate;
			
			item.Rowguid = varRowguid;
			
			item.ModifiedDate = varModifiedDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varSalesPersonID,int varTerritoryID,DateTime varStartDate,DateTime? varEndDate,Guid varRowguid,DateTime varModifiedDate)
		{
			SalesTerritoryHistory item = new SalesTerritoryHistory();
			
				item.SalesPersonID = varSalesPersonID;
			
				item.TerritoryID = varTerritoryID;
			
				item.StartDate = varStartDate;
			
				item.EndDate = varEndDate;
			
				item.Rowguid = varRowguid;
			
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
			 public static string SalesPersonID = @"SalesPersonID";
			 public static string TerritoryID = @"TerritoryID";
			 public static string StartDate = @"StartDate";
			 public static string EndDate = @"EndDate";
			 public static string Rowguid = @"rowguid";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}

		#endregion
	}

}

