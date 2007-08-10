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
	/// Strongly-typed collection for the ProductPhoto class.
	/// </summary>
	[Serializable]
	public partial class ProductPhotoCollection : ActiveList<ProductPhoto, ProductPhotoCollection> 
	{	   
		public ProductPhotoCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the ProductPhoto table.
	/// </summary>
	[Serializable]
	public partial class ProductPhoto : ActiveRecord<ProductPhoto>
	{
		#region .ctors and Default Settings
		
		public ProductPhoto()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public ProductPhoto(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public ProductPhoto(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public ProductPhoto(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("ProductPhoto", TableType.Table, DataService.GetInstance("Default"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Production";
				//columns
				
				TableSchema.TableColumn colvarProductPhotoID = new TableSchema.TableColumn(schema);
				colvarProductPhotoID.ColumnName = "ProductPhotoID";
				colvarProductPhotoID.DataType = DbType.Int32;
				colvarProductPhotoID.MaxLength = 0;
				colvarProductPhotoID.AutoIncrement = true;
				colvarProductPhotoID.IsNullable = false;
				colvarProductPhotoID.IsPrimaryKey = true;
				colvarProductPhotoID.IsForeignKey = false;
				colvarProductPhotoID.IsReadOnly = false;
				colvarProductPhotoID.DefaultSetting = @"";
				colvarProductPhotoID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProductPhotoID);
				
				TableSchema.TableColumn colvarThumbNailPhoto = new TableSchema.TableColumn(schema);
				colvarThumbNailPhoto.ColumnName = "ThumbNailPhoto";
				colvarThumbNailPhoto.DataType = DbType.Binary;
				colvarThumbNailPhoto.MaxLength = -1;
				colvarThumbNailPhoto.AutoIncrement = false;
				colvarThumbNailPhoto.IsNullable = true;
				colvarThumbNailPhoto.IsPrimaryKey = false;
				colvarThumbNailPhoto.IsForeignKey = false;
				colvarThumbNailPhoto.IsReadOnly = false;
				colvarThumbNailPhoto.DefaultSetting = @"";
				colvarThumbNailPhoto.ForeignKeyTableName = "";
				schema.Columns.Add(colvarThumbNailPhoto);
				
				TableSchema.TableColumn colvarThumbnailPhotoFileName = new TableSchema.TableColumn(schema);
				colvarThumbnailPhotoFileName.ColumnName = "ThumbnailPhotoFileName";
				colvarThumbnailPhotoFileName.DataType = DbType.String;
				colvarThumbnailPhotoFileName.MaxLength = 50;
				colvarThumbnailPhotoFileName.AutoIncrement = false;
				colvarThumbnailPhotoFileName.IsNullable = true;
				colvarThumbnailPhotoFileName.IsPrimaryKey = false;
				colvarThumbnailPhotoFileName.IsForeignKey = false;
				colvarThumbnailPhotoFileName.IsReadOnly = false;
				colvarThumbnailPhotoFileName.DefaultSetting = @"";
				colvarThumbnailPhotoFileName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarThumbnailPhotoFileName);
				
				TableSchema.TableColumn colvarLargePhoto = new TableSchema.TableColumn(schema);
				colvarLargePhoto.ColumnName = "LargePhoto";
				colvarLargePhoto.DataType = DbType.Binary;
				colvarLargePhoto.MaxLength = -1;
				colvarLargePhoto.AutoIncrement = false;
				colvarLargePhoto.IsNullable = true;
				colvarLargePhoto.IsPrimaryKey = false;
				colvarLargePhoto.IsForeignKey = false;
				colvarLargePhoto.IsReadOnly = false;
				colvarLargePhoto.DefaultSetting = @"";
				colvarLargePhoto.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLargePhoto);
				
				TableSchema.TableColumn colvarLargePhotoFileName = new TableSchema.TableColumn(schema);
				colvarLargePhotoFileName.ColumnName = "LargePhotoFileName";
				colvarLargePhotoFileName.DataType = DbType.String;
				colvarLargePhotoFileName.MaxLength = 50;
				colvarLargePhotoFileName.AutoIncrement = false;
				colvarLargePhotoFileName.IsNullable = true;
				colvarLargePhotoFileName.IsPrimaryKey = false;
				colvarLargePhotoFileName.IsForeignKey = false;
				colvarLargePhotoFileName.IsReadOnly = false;
				colvarLargePhotoFileName.DefaultSetting = @"";
				colvarLargePhotoFileName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLargePhotoFileName);
				
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
				DataService.Providers["Default"].AddSchema("ProductPhoto",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("ProductPhotoID")]
		public int ProductPhotoID 
		{
			get { return GetColumnValue<int>(Columns.ProductPhotoID); }

			set { SetColumnValue(Columns.ProductPhotoID, value); }

		}

		  
		[XmlAttribute("ThumbNailPhoto")]
		public byte[] ThumbNailPhoto 
		{
			get { return GetColumnValue<byte[]>(Columns.ThumbNailPhoto); }

			set { SetColumnValue(Columns.ThumbNailPhoto, value); }

		}

		  
		[XmlAttribute("ThumbnailPhotoFileName")]
		public string ThumbnailPhotoFileName 
		{
			get { return GetColumnValue<string>(Columns.ThumbnailPhotoFileName); }

			set { SetColumnValue(Columns.ThumbnailPhotoFileName, value); }

		}

		  
		[XmlAttribute("LargePhoto")]
		public byte[] LargePhoto 
		{
			get { return GetColumnValue<byte[]>(Columns.LargePhoto); }

			set { SetColumnValue(Columns.LargePhoto, value); }

		}

		  
		[XmlAttribute("LargePhotoFileName")]
		public string LargePhotoFileName 
		{
			get { return GetColumnValue<string>(Columns.LargePhotoFileName); }

			set { SetColumnValue(Columns.LargePhotoFileName, value); }

		}

		  
		[XmlAttribute("ModifiedDate")]
		public DateTime ModifiedDate 
		{
			get { return GetColumnValue<DateTime>(Columns.ModifiedDate); }

			set { SetColumnValue(Columns.ModifiedDate, value); }

		}

		
		#endregion
		
		
		#region PrimaryKey Methods
		
		public AVManager.DAL.ProductProductPhotoCollection ProductProductPhotoRecords()
		{
			return new AVManager.DAL.ProductProductPhotoCollection().Where(ProductProductPhoto.Columns.ProductPhotoID, ProductPhotoID).Load();
		}

		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		#region Many To Many Helpers
		
		 
		public AVManager.DAL.ProductCollection GetProductCollection() { return ProductPhoto.GetProductCollection(this.ProductPhotoID); }

		public static AVManager.DAL.ProductCollection GetProductCollection(int varProductPhotoID)
		{
			SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
				"SELECT * FROM Product INNER JOIN ProductProductPhoto ON "+
				"Product.ProductID=ProductProductPhoto.ProductID WHERE ProductProductPhoto.ProductPhotoID=@ProductPhotoID", ProductPhoto.Schema.Provider.Name);
			
			cmd.AddParameter("@ProductPhotoID", varProductPhotoID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			ProductCollection coll = new ProductCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}

		
		public static void SaveProductMap(int varProductPhotoID, ProductCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM ProductProductPhoto WHERE ProductPhotoID=@ProductPhotoID", ProductPhoto.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductPhotoID", varProductPhotoID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Product item in items)
			{
				ProductProductPhoto varProductProductPhoto = new ProductProductPhoto();
				varProductProductPhoto.SetColumnValue("ProductPhotoID", varProductPhotoID);
				varProductProductPhoto.SetColumnValue("ProductID", item.GetPrimaryKeyValue());
				varProductProductPhoto.Save();
			}

		}

		public static void SaveProductMap(int varProductPhotoID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM ProductProductPhoto WHERE ProductPhotoID=@ProductPhotoID", ProductPhoto.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductPhotoID", varProductPhotoID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					ProductProductPhoto varProductProductPhoto = new ProductProductPhoto();
					varProductProductPhoto.SetColumnValue("ProductPhotoID", varProductPhotoID);
					varProductProductPhoto.SetColumnValue("ProductID", l.Value);
					varProductProductPhoto.Save();
				}

			}

		}

		public static void SaveProductMap(int varProductPhotoID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM ProductProductPhoto WHERE ProductPhotoID=@ProductPhotoID", ProductPhoto.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductPhotoID", varProductPhotoID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				ProductProductPhoto varProductProductPhoto = new ProductProductPhoto();
				varProductProductPhoto.SetColumnValue("ProductPhotoID", varProductPhotoID);
				varProductProductPhoto.SetColumnValue("ProductID", item);
				varProductProductPhoto.Save();
			}

		}

		
		public static void DeleteProductMap(int varProductPhotoID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM ProductProductPhoto WHERE ProductPhotoID=@ProductPhotoID", ProductPhoto.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductPhotoID", varProductPhotoID);
			DataService.ExecuteQuery(cmdDel);
		}

		
		#endregion
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(byte[] varThumbNailPhoto,string varThumbnailPhotoFileName,byte[] varLargePhoto,string varLargePhotoFileName,DateTime varModifiedDate)
		{
			ProductPhoto item = new ProductPhoto();
			
			item.ThumbNailPhoto = varThumbNailPhoto;
			
			item.ThumbnailPhotoFileName = varThumbnailPhotoFileName;
			
			item.LargePhoto = varLargePhoto;
			
			item.LargePhotoFileName = varLargePhotoFileName;
			
			item.ModifiedDate = varModifiedDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varProductPhotoID,byte[] varThumbNailPhoto,string varThumbnailPhotoFileName,byte[] varLargePhoto,string varLargePhotoFileName,DateTime varModifiedDate)
		{
			ProductPhoto item = new ProductPhoto();
			
				item.ProductPhotoID = varProductPhotoID;
			
				item.ThumbNailPhoto = varThumbNailPhoto;
			
				item.ThumbnailPhotoFileName = varThumbnailPhotoFileName;
			
				item.LargePhoto = varLargePhoto;
			
				item.LargePhotoFileName = varLargePhotoFileName;
			
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
			 public static string ProductPhotoID = @"ProductPhotoID";
			 public static string ThumbNailPhoto = @"ThumbNailPhoto";
			 public static string ThumbnailPhotoFileName = @"ThumbnailPhotoFileName";
			 public static string LargePhoto = @"LargePhoto";
			 public static string LargePhotoFileName = @"LargePhotoFileName";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}

		#endregion
	}

}

