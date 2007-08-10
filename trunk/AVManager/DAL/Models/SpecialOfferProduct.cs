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
	/// Strongly-typed collection for the SpecialOfferProduct class.
	/// </summary>
	[Serializable]
	public partial class SpecialOfferProductCollection : ActiveList<SpecialOfferProduct, SpecialOfferProductCollection> 
	{	   
		public SpecialOfferProductCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the SpecialOfferProduct table.
	/// </summary>
	[Serializable]
	public partial class SpecialOfferProduct : ActiveRecord<SpecialOfferProduct>
	{
		#region .ctors and Default Settings
		
		public SpecialOfferProduct()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public SpecialOfferProduct(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public SpecialOfferProduct(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public SpecialOfferProduct(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("SpecialOfferProduct", TableType.Table, DataService.GetInstance("Default"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Sales";
				//columns
				
				TableSchema.TableColumn colvarSpecialOfferID = new TableSchema.TableColumn(schema);
				colvarSpecialOfferID.ColumnName = "SpecialOfferID";
				colvarSpecialOfferID.DataType = DbType.Int32;
				colvarSpecialOfferID.MaxLength = 0;
				colvarSpecialOfferID.AutoIncrement = false;
				colvarSpecialOfferID.IsNullable = false;
				colvarSpecialOfferID.IsPrimaryKey = true;
				colvarSpecialOfferID.IsForeignKey = true;
				colvarSpecialOfferID.IsReadOnly = false;
				colvarSpecialOfferID.DefaultSetting = @"";
				
					colvarSpecialOfferID.ForeignKeyTableName = "SpecialOffer";
				schema.Columns.Add(colvarSpecialOfferID);
				
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
				DataService.Providers["Default"].AddSchema("SpecialOfferProduct",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("SpecialOfferID")]
		public int SpecialOfferID 
		{
			get { return GetColumnValue<int>(Columns.SpecialOfferID); }

			set { SetColumnValue(Columns.SpecialOfferID, value); }

		}

		  
		[XmlAttribute("ProductID")]
		public int ProductID 
		{
			get { return GetColumnValue<int>(Columns.ProductID); }

			set { SetColumnValue(Columns.ProductID, value); }

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
		
		public AVManager.DAL.SalesOrderDetailCollection SalesOrderDetailRecords()
		{
			return new AVManager.DAL.SalesOrderDetailCollection().Where(SalesOrderDetail.Columns.ProductID, SpecialOfferID).Load();
		}

		public AVManager.DAL.SalesOrderDetailCollection SalesOrderDetailRecordsFromSpecialOfferProduct()
		{
			return new AVManager.DAL.SalesOrderDetailCollection().Where(SalesOrderDetail.Columns.SpecialOfferID, SpecialOfferID).Load();
		}

		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Product ActiveRecord object related to this SpecialOfferProduct
		/// 
		/// </summary>
		public AVManager.DAL.Product Product
		{
			get { return AVManager.DAL.Product.FetchByID(this.ProductID); }

			set { SetColumnValue("ProductID", value.ProductID); }

		}

		
		
		/// <summary>
		/// Returns a SpecialOffer ActiveRecord object related to this SpecialOfferProduct
		/// 
		/// </summary>
		public AVManager.DAL.SpecialOffer SpecialOffer
		{
			get { return AVManager.DAL.SpecialOffer.FetchByID(this.SpecialOfferID); }

			set { SetColumnValue("SpecialOfferID", value.SpecialOfferID); }

		}

		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varSpecialOfferID,int varProductID,Guid varRowguid,DateTime varModifiedDate)
		{
			SpecialOfferProduct item = new SpecialOfferProduct();
			
			item.SpecialOfferID = varSpecialOfferID;
			
			item.ProductID = varProductID;
			
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
		public static void Update(int varSpecialOfferID,int varProductID,Guid varRowguid,DateTime varModifiedDate)
		{
			SpecialOfferProduct item = new SpecialOfferProduct();
			
				item.SpecialOfferID = varSpecialOfferID;
			
				item.ProductID = varProductID;
			
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
			 public static string SpecialOfferID = @"SpecialOfferID";
			 public static string ProductID = @"ProductID";
			 public static string Rowguid = @"rowguid";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}

		#endregion
	}

}

