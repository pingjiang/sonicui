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
	/// Strongly-typed collection for the ProductVendor class.
	/// </summary>
	[Serializable]
	public partial class ProductVendorCollection : ActiveList<ProductVendor, ProductVendorCollection> 
	{	   
		public ProductVendorCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the ProductVendor table.
	/// </summary>
	[Serializable]
	public partial class ProductVendor : ActiveRecord<ProductVendor>
	{
		#region .ctors and Default Settings
		
		public ProductVendor()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public ProductVendor(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public ProductVendor(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public ProductVendor(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("ProductVendor", TableType.Table, DataService.GetInstance("Default"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Purchasing";
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
				
				TableSchema.TableColumn colvarVendorID = new TableSchema.TableColumn(schema);
				colvarVendorID.ColumnName = "VendorID";
				colvarVendorID.DataType = DbType.Int32;
				colvarVendorID.MaxLength = 0;
				colvarVendorID.AutoIncrement = false;
				colvarVendorID.IsNullable = false;
				colvarVendorID.IsPrimaryKey = true;
				colvarVendorID.IsForeignKey = true;
				colvarVendorID.IsReadOnly = false;
				colvarVendorID.DefaultSetting = @"";
				
					colvarVendorID.ForeignKeyTableName = "Vendor";
				schema.Columns.Add(colvarVendorID);
				
				TableSchema.TableColumn colvarAverageLeadTime = new TableSchema.TableColumn(schema);
				colvarAverageLeadTime.ColumnName = "AverageLeadTime";
				colvarAverageLeadTime.DataType = DbType.Int32;
				colvarAverageLeadTime.MaxLength = 0;
				colvarAverageLeadTime.AutoIncrement = false;
				colvarAverageLeadTime.IsNullable = false;
				colvarAverageLeadTime.IsPrimaryKey = false;
				colvarAverageLeadTime.IsForeignKey = false;
				colvarAverageLeadTime.IsReadOnly = false;
				colvarAverageLeadTime.DefaultSetting = @"";
				colvarAverageLeadTime.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAverageLeadTime);
				
				TableSchema.TableColumn colvarStandardPrice = new TableSchema.TableColumn(schema);
				colvarStandardPrice.ColumnName = "StandardPrice";
				colvarStandardPrice.DataType = DbType.Currency;
				colvarStandardPrice.MaxLength = 0;
				colvarStandardPrice.AutoIncrement = false;
				colvarStandardPrice.IsNullable = false;
				colvarStandardPrice.IsPrimaryKey = false;
				colvarStandardPrice.IsForeignKey = false;
				colvarStandardPrice.IsReadOnly = false;
				colvarStandardPrice.DefaultSetting = @"";
				colvarStandardPrice.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStandardPrice);
				
				TableSchema.TableColumn colvarLastReceiptCost = new TableSchema.TableColumn(schema);
				colvarLastReceiptCost.ColumnName = "LastReceiptCost";
				colvarLastReceiptCost.DataType = DbType.Currency;
				colvarLastReceiptCost.MaxLength = 0;
				colvarLastReceiptCost.AutoIncrement = false;
				colvarLastReceiptCost.IsNullable = true;
				colvarLastReceiptCost.IsPrimaryKey = false;
				colvarLastReceiptCost.IsForeignKey = false;
				colvarLastReceiptCost.IsReadOnly = false;
				colvarLastReceiptCost.DefaultSetting = @"";
				colvarLastReceiptCost.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLastReceiptCost);
				
				TableSchema.TableColumn colvarLastReceiptDate = new TableSchema.TableColumn(schema);
				colvarLastReceiptDate.ColumnName = "LastReceiptDate";
				colvarLastReceiptDate.DataType = DbType.DateTime;
				colvarLastReceiptDate.MaxLength = 0;
				colvarLastReceiptDate.AutoIncrement = false;
				colvarLastReceiptDate.IsNullable = true;
				colvarLastReceiptDate.IsPrimaryKey = false;
				colvarLastReceiptDate.IsForeignKey = false;
				colvarLastReceiptDate.IsReadOnly = false;
				colvarLastReceiptDate.DefaultSetting = @"";
				colvarLastReceiptDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLastReceiptDate);
				
				TableSchema.TableColumn colvarMinOrderQty = new TableSchema.TableColumn(schema);
				colvarMinOrderQty.ColumnName = "MinOrderQty";
				colvarMinOrderQty.DataType = DbType.Int32;
				colvarMinOrderQty.MaxLength = 0;
				colvarMinOrderQty.AutoIncrement = false;
				colvarMinOrderQty.IsNullable = false;
				colvarMinOrderQty.IsPrimaryKey = false;
				colvarMinOrderQty.IsForeignKey = false;
				colvarMinOrderQty.IsReadOnly = false;
				colvarMinOrderQty.DefaultSetting = @"";
				colvarMinOrderQty.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMinOrderQty);
				
				TableSchema.TableColumn colvarMaxOrderQty = new TableSchema.TableColumn(schema);
				colvarMaxOrderQty.ColumnName = "MaxOrderQty";
				colvarMaxOrderQty.DataType = DbType.Int32;
				colvarMaxOrderQty.MaxLength = 0;
				colvarMaxOrderQty.AutoIncrement = false;
				colvarMaxOrderQty.IsNullable = false;
				colvarMaxOrderQty.IsPrimaryKey = false;
				colvarMaxOrderQty.IsForeignKey = false;
				colvarMaxOrderQty.IsReadOnly = false;
				colvarMaxOrderQty.DefaultSetting = @"";
				colvarMaxOrderQty.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMaxOrderQty);
				
				TableSchema.TableColumn colvarOnOrderQty = new TableSchema.TableColumn(schema);
				colvarOnOrderQty.ColumnName = "OnOrderQty";
				colvarOnOrderQty.DataType = DbType.Int32;
				colvarOnOrderQty.MaxLength = 0;
				colvarOnOrderQty.AutoIncrement = false;
				colvarOnOrderQty.IsNullable = true;
				colvarOnOrderQty.IsPrimaryKey = false;
				colvarOnOrderQty.IsForeignKey = false;
				colvarOnOrderQty.IsReadOnly = false;
				colvarOnOrderQty.DefaultSetting = @"";
				colvarOnOrderQty.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOnOrderQty);
				
				TableSchema.TableColumn colvarUnitMeasureCode = new TableSchema.TableColumn(schema);
				colvarUnitMeasureCode.ColumnName = "UnitMeasureCode";
				colvarUnitMeasureCode.DataType = DbType.String;
				colvarUnitMeasureCode.MaxLength = 3;
				colvarUnitMeasureCode.AutoIncrement = false;
				colvarUnitMeasureCode.IsNullable = false;
				colvarUnitMeasureCode.IsPrimaryKey = false;
				colvarUnitMeasureCode.IsForeignKey = true;
				colvarUnitMeasureCode.IsReadOnly = false;
				colvarUnitMeasureCode.DefaultSetting = @"";
				
					colvarUnitMeasureCode.ForeignKeyTableName = "UnitMeasure";
				schema.Columns.Add(colvarUnitMeasureCode);
				
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
				DataService.Providers["Default"].AddSchema("ProductVendor",schema);
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

		  
		[XmlAttribute("VendorID")]
		public int VendorID 
		{
			get { return GetColumnValue<int>(Columns.VendorID); }

			set { SetColumnValue(Columns.VendorID, value); }

		}

		  
		[XmlAttribute("AverageLeadTime")]
		public int AverageLeadTime 
		{
			get { return GetColumnValue<int>(Columns.AverageLeadTime); }

			set { SetColumnValue(Columns.AverageLeadTime, value); }

		}

		  
		[XmlAttribute("StandardPrice")]
		public decimal StandardPrice 
		{
			get { return GetColumnValue<decimal>(Columns.StandardPrice); }

			set { SetColumnValue(Columns.StandardPrice, value); }

		}

		  
		[XmlAttribute("LastReceiptCost")]
		public decimal? LastReceiptCost 
		{
			get { return GetColumnValue<decimal?>(Columns.LastReceiptCost); }

			set { SetColumnValue(Columns.LastReceiptCost, value); }

		}

		  
		[XmlAttribute("LastReceiptDate")]
		public DateTime? LastReceiptDate 
		{
			get { return GetColumnValue<DateTime?>(Columns.LastReceiptDate); }

			set { SetColumnValue(Columns.LastReceiptDate, value); }

		}

		  
		[XmlAttribute("MinOrderQty")]
		public int MinOrderQty 
		{
			get { return GetColumnValue<int>(Columns.MinOrderQty); }

			set { SetColumnValue(Columns.MinOrderQty, value); }

		}

		  
		[XmlAttribute("MaxOrderQty")]
		public int MaxOrderQty 
		{
			get { return GetColumnValue<int>(Columns.MaxOrderQty); }

			set { SetColumnValue(Columns.MaxOrderQty, value); }

		}

		  
		[XmlAttribute("OnOrderQty")]
		public int? OnOrderQty 
		{
			get { return GetColumnValue<int?>(Columns.OnOrderQty); }

			set { SetColumnValue(Columns.OnOrderQty, value); }

		}

		  
		[XmlAttribute("UnitMeasureCode")]
		public string UnitMeasureCode 
		{
			get { return GetColumnValue<string>(Columns.UnitMeasureCode); }

			set { SetColumnValue(Columns.UnitMeasureCode, value); }

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
		/// Returns a Product ActiveRecord object related to this ProductVendor
		/// 
		/// </summary>
		public AVManager.DAL.Product Product
		{
			get { return AVManager.DAL.Product.FetchByID(this.ProductID); }

			set { SetColumnValue("ProductID", value.ProductID); }

		}

		
		
		/// <summary>
		/// Returns a UnitMeasure ActiveRecord object related to this ProductVendor
		/// 
		/// </summary>
		public AVManager.DAL.UnitMeasure UnitMeasure
		{
			get { return AVManager.DAL.UnitMeasure.FetchByID(this.UnitMeasureCode); }

			set { SetColumnValue("UnitMeasureCode", value.UnitMeasureCode); }

		}

		
		
		/// <summary>
		/// Returns a Vendor ActiveRecord object related to this ProductVendor
		/// 
		/// </summary>
		public AVManager.DAL.Vendor Vendor
		{
			get { return AVManager.DAL.Vendor.FetchByID(this.VendorID); }

			set { SetColumnValue("VendorID", value.VendorID); }

		}

		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varProductID,int varVendorID,int varAverageLeadTime,decimal varStandardPrice,decimal? varLastReceiptCost,DateTime? varLastReceiptDate,int varMinOrderQty,int varMaxOrderQty,int? varOnOrderQty,string varUnitMeasureCode,DateTime varModifiedDate)
		{
			ProductVendor item = new ProductVendor();
			
			item.ProductID = varProductID;
			
			item.VendorID = varVendorID;
			
			item.AverageLeadTime = varAverageLeadTime;
			
			item.StandardPrice = varStandardPrice;
			
			item.LastReceiptCost = varLastReceiptCost;
			
			item.LastReceiptDate = varLastReceiptDate;
			
			item.MinOrderQty = varMinOrderQty;
			
			item.MaxOrderQty = varMaxOrderQty;
			
			item.OnOrderQty = varOnOrderQty;
			
			item.UnitMeasureCode = varUnitMeasureCode;
			
			item.ModifiedDate = varModifiedDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varProductID,int varVendorID,int varAverageLeadTime,decimal varStandardPrice,decimal? varLastReceiptCost,DateTime? varLastReceiptDate,int varMinOrderQty,int varMaxOrderQty,int? varOnOrderQty,string varUnitMeasureCode,DateTime varModifiedDate)
		{
			ProductVendor item = new ProductVendor();
			
				item.ProductID = varProductID;
			
				item.VendorID = varVendorID;
			
				item.AverageLeadTime = varAverageLeadTime;
			
				item.StandardPrice = varStandardPrice;
			
				item.LastReceiptCost = varLastReceiptCost;
			
				item.LastReceiptDate = varLastReceiptDate;
			
				item.MinOrderQty = varMinOrderQty;
			
				item.MaxOrderQty = varMaxOrderQty;
			
				item.OnOrderQty = varOnOrderQty;
			
				item.UnitMeasureCode = varUnitMeasureCode;
			
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
			 public static string VendorID = @"VendorID";
			 public static string AverageLeadTime = @"AverageLeadTime";
			 public static string StandardPrice = @"StandardPrice";
			 public static string LastReceiptCost = @"LastReceiptCost";
			 public static string LastReceiptDate = @"LastReceiptDate";
			 public static string MinOrderQty = @"MinOrderQty";
			 public static string MaxOrderQty = @"MaxOrderQty";
			 public static string OnOrderQty = @"OnOrderQty";
			 public static string UnitMeasureCode = @"UnitMeasureCode";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}

		#endregion
	}

}

