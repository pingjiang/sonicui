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
	/// Strongly-typed collection for the SalesPersonQuotaHistory class.
	/// </summary>
	[Serializable]
	public partial class SalesPersonQuotaHistoryCollection : ActiveList<SalesPersonQuotaHistory, SalesPersonQuotaHistoryCollection> 
	{	   
		public SalesPersonQuotaHistoryCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the SalesPersonQuotaHistory table.
	/// </summary>
	[Serializable]
	public partial class SalesPersonQuotaHistory : ActiveRecord<SalesPersonQuotaHistory>
	{
		#region .ctors and Default Settings
		
		public SalesPersonQuotaHistory()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public SalesPersonQuotaHistory(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public SalesPersonQuotaHistory(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public SalesPersonQuotaHistory(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("SalesPersonQuotaHistory", TableType.Table, DataService.GetInstance("Default"));
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
				
				TableSchema.TableColumn colvarQuotaDate = new TableSchema.TableColumn(schema);
				colvarQuotaDate.ColumnName = "QuotaDate";
				colvarQuotaDate.DataType = DbType.DateTime;
				colvarQuotaDate.MaxLength = 0;
				colvarQuotaDate.AutoIncrement = false;
				colvarQuotaDate.IsNullable = false;
				colvarQuotaDate.IsPrimaryKey = true;
				colvarQuotaDate.IsForeignKey = false;
				colvarQuotaDate.IsReadOnly = false;
				colvarQuotaDate.DefaultSetting = @"";
				colvarQuotaDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarQuotaDate);
				
				TableSchema.TableColumn colvarSalesQuota = new TableSchema.TableColumn(schema);
				colvarSalesQuota.ColumnName = "SalesQuota";
				colvarSalesQuota.DataType = DbType.Currency;
				colvarSalesQuota.MaxLength = 0;
				colvarSalesQuota.AutoIncrement = false;
				colvarSalesQuota.IsNullable = false;
				colvarSalesQuota.IsPrimaryKey = false;
				colvarSalesQuota.IsForeignKey = false;
				colvarSalesQuota.IsReadOnly = false;
				colvarSalesQuota.DefaultSetting = @"";
				colvarSalesQuota.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSalesQuota);
				
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
				DataService.Providers["Default"].AddSchema("SalesPersonQuotaHistory",schema);
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

		  
		[XmlAttribute("QuotaDate")]
		public DateTime QuotaDate 
		{
			get { return GetColumnValue<DateTime>(Columns.QuotaDate); }

			set { SetColumnValue(Columns.QuotaDate, value); }

		}

		  
		[XmlAttribute("SalesQuota")]
		public decimal SalesQuota 
		{
			get { return GetColumnValue<decimal>(Columns.SalesQuota); }

			set { SetColumnValue(Columns.SalesQuota, value); }

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
		/// Returns a SalesPerson ActiveRecord object related to this SalesPersonQuotaHistory
		/// 
		/// </summary>
		public AVManager.DAL.SalesPerson SalesPerson
		{
			get { return AVManager.DAL.SalesPerson.FetchByID(this.SalesPersonID); }

			set { SetColumnValue("SalesPersonID", value.SalesPersonID); }

		}

		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varSalesPersonID,DateTime varQuotaDate,decimal varSalesQuota,Guid varRowguid,DateTime varModifiedDate)
		{
			SalesPersonQuotaHistory item = new SalesPersonQuotaHistory();
			
			item.SalesPersonID = varSalesPersonID;
			
			item.QuotaDate = varQuotaDate;
			
			item.SalesQuota = varSalesQuota;
			
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
		public static void Update(int varSalesPersonID,DateTime varQuotaDate,decimal varSalesQuota,Guid varRowguid,DateTime varModifiedDate)
		{
			SalesPersonQuotaHistory item = new SalesPersonQuotaHistory();
			
				item.SalesPersonID = varSalesPersonID;
			
				item.QuotaDate = varQuotaDate;
			
				item.SalesQuota = varSalesQuota;
			
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
			 public static string QuotaDate = @"QuotaDate";
			 public static string SalesQuota = @"SalesQuota";
			 public static string Rowguid = @"rowguid";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}

		#endregion
	}

}

