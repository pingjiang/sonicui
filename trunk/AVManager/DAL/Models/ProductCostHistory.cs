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
	/// Strongly-typed collection for the ProductCostHistory class.
	/// </summary>
	[Serializable]
	public partial class ProductCostHistoryCollection : ActiveList<ProductCostHistory, ProductCostHistoryCollection> 
	{	   
		public ProductCostHistoryCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the ProductCostHistory table.
	/// </summary>
	[Serializable]
	public partial class ProductCostHistory : ActiveRecord<ProductCostHistory>
	{
		#region .ctors and Default Settings
		
		public ProductCostHistory()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public ProductCostHistory(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public ProductCostHistory(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public ProductCostHistory(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("ProductCostHistory", TableType.Table, DataService.GetInstance("Default"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Production";
				//columns
				
				TableSchema.TableColumn colvarProductID = new TableSchema.TableColumn(schema);
				colvarProductID.ColumnName = "ProductID";
				colvarProductID.DataType = DbType.Int32;
				colvarProductID.MaxLength = 0;
				colvarProductID.AutoIncrement = false;
				colvarProductID.IsNullable = false;
				colvarProductID.IsPrimaryKey = true;
				colvarProductID.IsForeignKey = true;
				colvarProductID.IsReadOnly = false;
				colvarProductID.DefaultSetting = @"";
				
					colvarProductID.ForeignKeyTableName = "Product";
				schema.Columns.Add(colvarProductID);
				
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
				
				TableSchema.TableColumn colvarStandardCost = new TableSchema.TableColumn(schema);
				colvarStandardCost.ColumnName = "StandardCost";
				colvarStandardCost.DataType = DbType.Currency;
				colvarStandardCost.MaxLength = 0;
				colvarStandardCost.AutoIncrement = false;
				colvarStandardCost.IsNullable = false;
				colvarStandardCost.IsPrimaryKey = false;
				colvarStandardCost.IsForeignKey = false;
				colvarStandardCost.IsReadOnly = false;
				colvarStandardCost.DefaultSetting = @"";
				colvarStandardCost.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStandardCost);
				
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
				DataService.Providers["Default"].AddSchema("ProductCostHistory",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("ProductID")]
		public int ProductID 
		{
			get { return GetColumnValue<int>(Columns.ProductID); }

			set { SetColumnValue(Columns.ProductID, value); }

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

		  
		[XmlAttribute("StandardCost")]
		public decimal StandardCost 
		{
			get { return GetColumnValue<decimal>(Columns.StandardCost); }

			set { SetColumnValue(Columns.StandardCost, value); }

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
		/// Returns a Product ActiveRecord object related to this ProductCostHistory
		/// 
		/// </summary>
		public AVManager.DAL.Product Product
		{
			get { return AVManager.DAL.Product.FetchByID(this.ProductID); }

			set { SetColumnValue("ProductID", value.ProductID); }

		}

		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varProductID,DateTime varStartDate,DateTime? varEndDate,decimal varStandardCost,DateTime varModifiedDate)
		{
			ProductCostHistory item = new ProductCostHistory();
			
			item.ProductID = varProductID;
			
			item.StartDate = varStartDate;
			
			item.EndDate = varEndDate;
			
			item.StandardCost = varStandardCost;
			
			item.ModifiedDate = varModifiedDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varProductID,DateTime varStartDate,DateTime? varEndDate,decimal varStandardCost,DateTime varModifiedDate)
		{
			ProductCostHistory item = new ProductCostHistory();
			
				item.ProductID = varProductID;
			
				item.StartDate = varStartDate;
			
				item.EndDate = varEndDate;
			
				item.StandardCost = varStandardCost;
			
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
			 public static string ProductID = @"ProductID";
			 public static string StartDate = @"StartDate";
			 public static string EndDate = @"EndDate";
			 public static string StandardCost = @"StandardCost";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}

		#endregion
	}

}

