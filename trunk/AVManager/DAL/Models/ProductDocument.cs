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
	/// Strongly-typed collection for the ProductDocument class.
	/// </summary>
	[Serializable]
	public partial class ProductDocumentCollection : ActiveList<ProductDocument, ProductDocumentCollection> 
	{	   
		public ProductDocumentCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the ProductDocument table.
	/// </summary>
	[Serializable]
	public partial class ProductDocument : ActiveRecord<ProductDocument>
	{
		#region .ctors and Default Settings
		
		public ProductDocument()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public ProductDocument(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public ProductDocument(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public ProductDocument(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("ProductDocument", TableType.Table, DataService.GetInstance("Default"));
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
				
				TableSchema.TableColumn colvarDocumentID = new TableSchema.TableColumn(schema);
				colvarDocumentID.ColumnName = "DocumentID";
				colvarDocumentID.DataType = DbType.Int32;
				colvarDocumentID.MaxLength = 0;
				colvarDocumentID.AutoIncrement = false;
				colvarDocumentID.IsNullable = false;
				colvarDocumentID.IsPrimaryKey = true;
				colvarDocumentID.IsForeignKey = true;
				colvarDocumentID.IsReadOnly = false;
				colvarDocumentID.DefaultSetting = @"";
				
					colvarDocumentID.ForeignKeyTableName = "Document";
				schema.Columns.Add(colvarDocumentID);
				
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
				DataService.Providers["Default"].AddSchema("ProductDocument",schema);
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

		  
		[XmlAttribute("DocumentID")]
		public int DocumentID 
		{
			get { return GetColumnValue<int>(Columns.DocumentID); }

			set { SetColumnValue(Columns.DocumentID, value); }

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
		/// Returns a Document ActiveRecord object related to this ProductDocument
		/// 
		/// </summary>
		public AVManager.DAL.Document Document
		{
			get { return AVManager.DAL.Document.FetchByID(this.DocumentID); }

			set { SetColumnValue("DocumentID", value.DocumentID); }

		}

		
		
		/// <summary>
		/// Returns a Product ActiveRecord object related to this ProductDocument
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
		public static void Insert(int varProductID,int varDocumentID,DateTime varModifiedDate)
		{
			ProductDocument item = new ProductDocument();
			
			item.ProductID = varProductID;
			
			item.DocumentID = varDocumentID;
			
			item.ModifiedDate = varModifiedDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varProductID,int varDocumentID,DateTime varModifiedDate)
		{
			ProductDocument item = new ProductDocument();
			
				item.ProductID = varProductID;
			
				item.DocumentID = varDocumentID;
			
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
			 public static string DocumentID = @"DocumentID";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}

		#endregion
	}

}

