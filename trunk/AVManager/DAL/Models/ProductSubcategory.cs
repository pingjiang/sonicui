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
	/// Strongly-typed collection for the ProductSubcategory class.
	/// </summary>
	[Serializable]
	public partial class ProductSubcategoryCollection : ActiveList<ProductSubcategory, ProductSubcategoryCollection> 
	{	   
		public ProductSubcategoryCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the ProductSubcategory table.
	/// </summary>
	[Serializable]
	public partial class ProductSubcategory : ActiveRecord<ProductSubcategory>
	{
		#region .ctors and Default Settings
		
		public ProductSubcategory()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public ProductSubcategory(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public ProductSubcategory(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public ProductSubcategory(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("ProductSubcategory", TableType.Table, DataService.GetInstance("Default"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Production";
				//columns
				
				TableSchema.TableColumn colvarProductSubcategoryID = new TableSchema.TableColumn(schema);
				colvarProductSubcategoryID.ColumnName = "ProductSubcategoryID";
				colvarProductSubcategoryID.DataType = DbType.Int32;
				colvarProductSubcategoryID.MaxLength = 0;
				colvarProductSubcategoryID.AutoIncrement = true;
				colvarProductSubcategoryID.IsNullable = false;
				colvarProductSubcategoryID.IsPrimaryKey = true;
				colvarProductSubcategoryID.IsForeignKey = false;
				colvarProductSubcategoryID.IsReadOnly = false;
				colvarProductSubcategoryID.DefaultSetting = @"";
				colvarProductSubcategoryID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProductSubcategoryID);
				
				TableSchema.TableColumn colvarProductCategoryID = new TableSchema.TableColumn(schema);
				colvarProductCategoryID.ColumnName = "ProductCategoryID";
				colvarProductCategoryID.DataType = DbType.Int32;
				colvarProductCategoryID.MaxLength = 0;
				colvarProductCategoryID.AutoIncrement = false;
				colvarProductCategoryID.IsNullable = false;
				colvarProductCategoryID.IsPrimaryKey = false;
				colvarProductCategoryID.IsForeignKey = true;
				colvarProductCategoryID.IsReadOnly = false;
				colvarProductCategoryID.DefaultSetting = @"";
				
					colvarProductCategoryID.ForeignKeyTableName = "ProductCategory";
				schema.Columns.Add(colvarProductCategoryID);
				
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
				DataService.Providers["Default"].AddSchema("ProductSubcategory",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("ProductSubcategoryID")]
		public int ProductSubcategoryID 
		{
			get { return GetColumnValue<int>(Columns.ProductSubcategoryID); }

			set { SetColumnValue(Columns.ProductSubcategoryID, value); }

		}

		  
		[XmlAttribute("ProductCategoryID")]
		public int ProductCategoryID 
		{
			get { return GetColumnValue<int>(Columns.ProductCategoryID); }

			set { SetColumnValue(Columns.ProductCategoryID, value); }

		}

		  
		[XmlAttribute("Name")]
		public string Name 
		{
			get { return GetColumnValue<string>(Columns.Name); }

			set { SetColumnValue(Columns.Name, value); }

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
		
		
		#region PrimaryKey Methods
		
		public AVManager.DAL.ProductCollection ProductRecords()
		{
			return new AVManager.DAL.ProductCollection().Where(Product.Columns.ProductSubcategoryID, ProductSubcategoryID).Load();
		}

		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a ProductCategory ActiveRecord object related to this ProductSubcategory
		/// 
		/// </summary>
		public AVManager.DAL.ProductCategory ProductCategory
		{
			get { return AVManager.DAL.ProductCategory.FetchByID(this.ProductCategoryID); }

			set { SetColumnValue("ProductCategoryID", value.ProductCategoryID); }

		}

		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varProductCategoryID,string varName,Guid varRowguid,DateTime varModifiedDate)
		{
			ProductSubcategory item = new ProductSubcategory();
			
			item.ProductCategoryID = varProductCategoryID;
			
			item.Name = varName;
			
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
		public static void Update(int varProductSubcategoryID,int varProductCategoryID,string varName,Guid varRowguid,DateTime varModifiedDate)
		{
			ProductSubcategory item = new ProductSubcategory();
			
				item.ProductSubcategoryID = varProductSubcategoryID;
			
				item.ProductCategoryID = varProductCategoryID;
			
				item.Name = varName;
			
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
			 public static string ProductSubcategoryID = @"ProductSubcategoryID";
			 public static string ProductCategoryID = @"ProductCategoryID";
			 public static string Name = @"Name";
			 public static string Rowguid = @"rowguid";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}

		#endregion
	}

}

