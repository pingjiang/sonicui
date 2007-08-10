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
	/// Strongly-typed collection for the ProductModel class.
	/// </summary>
	[Serializable]
	public partial class ProductModelCollection : ActiveList<ProductModel, ProductModelCollection> 
	{	   
		public ProductModelCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the ProductModel table.
	/// </summary>
	[Serializable]
	public partial class ProductModel : ActiveRecord<ProductModel>
	{
		#region .ctors and Default Settings
		
		public ProductModel()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public ProductModel(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public ProductModel(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public ProductModel(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("ProductModel", TableType.Table, DataService.GetInstance("Default"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Production";
				//columns
				
				TableSchema.TableColumn colvarProductModelID = new TableSchema.TableColumn(schema);
				colvarProductModelID.ColumnName = "ProductModelID";
				colvarProductModelID.DataType = DbType.Int32;
				colvarProductModelID.MaxLength = 0;
				colvarProductModelID.AutoIncrement = true;
				colvarProductModelID.IsNullable = false;
				colvarProductModelID.IsPrimaryKey = true;
				colvarProductModelID.IsForeignKey = false;
				colvarProductModelID.IsReadOnly = false;
				colvarProductModelID.DefaultSetting = @"";
				colvarProductModelID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProductModelID);
				
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
				
				TableSchema.TableColumn colvarCatalogDescription = new TableSchema.TableColumn(schema);
				colvarCatalogDescription.ColumnName = "CatalogDescription";
				colvarCatalogDescription.DataType = DbType.String;
				colvarCatalogDescription.MaxLength = -1;
				colvarCatalogDescription.AutoIncrement = false;
				colvarCatalogDescription.IsNullable = true;
				colvarCatalogDescription.IsPrimaryKey = false;
				colvarCatalogDescription.IsForeignKey = false;
				colvarCatalogDescription.IsReadOnly = false;
				colvarCatalogDescription.DefaultSetting = @"";
				colvarCatalogDescription.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCatalogDescription);
				
				TableSchema.TableColumn colvarInstructions = new TableSchema.TableColumn(schema);
				colvarInstructions.ColumnName = "Instructions";
				colvarInstructions.DataType = DbType.String;
				colvarInstructions.MaxLength = -1;
				colvarInstructions.AutoIncrement = false;
				colvarInstructions.IsNullable = true;
				colvarInstructions.IsPrimaryKey = false;
				colvarInstructions.IsForeignKey = false;
				colvarInstructions.IsReadOnly = false;
				colvarInstructions.DefaultSetting = @"";
				colvarInstructions.ForeignKeyTableName = "";
				schema.Columns.Add(colvarInstructions);
				
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
				DataService.Providers["Default"].AddSchema("ProductModel",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("ProductModelID")]
		public int ProductModelID 
		{
			get { return GetColumnValue<int>(Columns.ProductModelID); }

			set { SetColumnValue(Columns.ProductModelID, value); }

		}

		  
		[XmlAttribute("Name")]
		public string Name 
		{
			get { return GetColumnValue<string>(Columns.Name); }

			set { SetColumnValue(Columns.Name, value); }

		}

		  
		[XmlAttribute("CatalogDescription")]
		public string CatalogDescription 
		{
			get { return GetColumnValue<string>(Columns.CatalogDescription); }

			set { SetColumnValue(Columns.CatalogDescription, value); }

		}

		  
		[XmlAttribute("Instructions")]
		public string Instructions 
		{
			get { return GetColumnValue<string>(Columns.Instructions); }

			set { SetColumnValue(Columns.Instructions, value); }

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
			return new AVManager.DAL.ProductCollection().Where(Product.Columns.ProductModelID, ProductModelID).Load();
		}

		public AVManager.DAL.ProductModelIllustrationCollection ProductModelIllustrationRecords()
		{
			return new AVManager.DAL.ProductModelIllustrationCollection().Where(ProductModelIllustration.Columns.ProductModelID, ProductModelID).Load();
		}

		public AVManager.DAL.ProductModelProductDescriptionCultureCollection ProductModelProductDescriptionCultureRecords()
		{
			return new AVManager.DAL.ProductModelProductDescriptionCultureCollection().Where(ProductModelProductDescriptionCulture.Columns.ProductModelID, ProductModelID).Load();
		}

		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		#region Many To Many Helpers
		
		 
		public AVManager.DAL.IllustrationCollection GetIllustrationCollection() { return ProductModel.GetIllustrationCollection(this.ProductModelID); }

		public static AVManager.DAL.IllustrationCollection GetIllustrationCollection(int varProductModelID)
		{
			SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
				"SELECT * FROM Illustration INNER JOIN ProductModelIllustration ON "+
				"Illustration.IllustrationID=ProductModelIllustration.IllustrationID WHERE ProductModelIllustration.ProductModelID=@ProductModelID", ProductModel.Schema.Provider.Name);
			
			cmd.AddParameter("@ProductModelID", varProductModelID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			IllustrationCollection coll = new IllustrationCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}

		
		public static void SaveIllustrationMap(int varProductModelID, IllustrationCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM ProductModelIllustration WHERE ProductModelID=@ProductModelID", ProductModel.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductModelID", varProductModelID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Illustration item in items)
			{
				ProductModelIllustration varProductModelIllustration = new ProductModelIllustration();
				varProductModelIllustration.SetColumnValue("ProductModelID", varProductModelID);
				varProductModelIllustration.SetColumnValue("IllustrationID", item.GetPrimaryKeyValue());
				varProductModelIllustration.Save();
			}

		}

		public static void SaveIllustrationMap(int varProductModelID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM ProductModelIllustration WHERE ProductModelID=@ProductModelID", ProductModel.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductModelID", varProductModelID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					ProductModelIllustration varProductModelIllustration = new ProductModelIllustration();
					varProductModelIllustration.SetColumnValue("ProductModelID", varProductModelID);
					varProductModelIllustration.SetColumnValue("IllustrationID", l.Value);
					varProductModelIllustration.Save();
				}

			}

		}

		public static void SaveIllustrationMap(int varProductModelID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM ProductModelIllustration WHERE ProductModelID=@ProductModelID", ProductModel.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductModelID", varProductModelID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				ProductModelIllustration varProductModelIllustration = new ProductModelIllustration();
				varProductModelIllustration.SetColumnValue("ProductModelID", varProductModelID);
				varProductModelIllustration.SetColumnValue("IllustrationID", item);
				varProductModelIllustration.Save();
			}

		}

		
		public static void DeleteIllustrationMap(int varProductModelID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM ProductModelIllustration WHERE ProductModelID=@ProductModelID", ProductModel.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductModelID", varProductModelID);
			DataService.ExecuteQuery(cmdDel);
		}

		
		 
		public AVManager.DAL.CultureCollection GetCultureCollection() { return ProductModel.GetCultureCollection(this.ProductModelID); }

		public static AVManager.DAL.CultureCollection GetCultureCollection(int varProductModelID)
		{
			SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
				"SELECT * FROM Culture INNER JOIN ProductModelProductDescriptionCulture ON "+
				"Culture.CultureID=ProductModelProductDescriptionCulture.CultureID WHERE ProductModelProductDescriptionCulture.ProductModelID=@ProductModelID", ProductModel.Schema.Provider.Name);
			
			cmd.AddParameter("@ProductModelID", varProductModelID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			CultureCollection coll = new CultureCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}

		
		public static void SaveCultureMap(int varProductModelID, CultureCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM ProductModelProductDescriptionCulture WHERE ProductModelID=@ProductModelID", ProductModel.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductModelID", varProductModelID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Culture item in items)
			{
				ProductModelProductDescriptionCulture varProductModelProductDescriptionCulture = new ProductModelProductDescriptionCulture();
				varProductModelProductDescriptionCulture.SetColumnValue("ProductModelID", varProductModelID);
				varProductModelProductDescriptionCulture.SetColumnValue("CultureID", item.GetPrimaryKeyValue());
				varProductModelProductDescriptionCulture.Save();
			}

		}

		public static void SaveCultureMap(int varProductModelID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM ProductModelProductDescriptionCulture WHERE ProductModelID=@ProductModelID", ProductModel.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductModelID", varProductModelID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					ProductModelProductDescriptionCulture varProductModelProductDescriptionCulture = new ProductModelProductDescriptionCulture();
					varProductModelProductDescriptionCulture.SetColumnValue("ProductModelID", varProductModelID);
					varProductModelProductDescriptionCulture.SetColumnValue("CultureID", l.Value);
					varProductModelProductDescriptionCulture.Save();
				}

			}

		}

		public static void SaveCultureMap(int varProductModelID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM ProductModelProductDescriptionCulture WHERE ProductModelID=@ProductModelID", ProductModel.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductModelID", varProductModelID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				ProductModelProductDescriptionCulture varProductModelProductDescriptionCulture = new ProductModelProductDescriptionCulture();
				varProductModelProductDescriptionCulture.SetColumnValue("ProductModelID", varProductModelID);
				varProductModelProductDescriptionCulture.SetColumnValue("CultureID", item);
				varProductModelProductDescriptionCulture.Save();
			}

		}

		
		public static void DeleteCultureMap(int varProductModelID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM ProductModelProductDescriptionCulture WHERE ProductModelID=@ProductModelID", ProductModel.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductModelID", varProductModelID);
			DataService.ExecuteQuery(cmdDel);
		}

		
		 
		public AVManager.DAL.ProductDescriptionCollection GetProductDescriptionCollection() { return ProductModel.GetProductDescriptionCollection(this.ProductModelID); }

		public static AVManager.DAL.ProductDescriptionCollection GetProductDescriptionCollection(int varProductModelID)
		{
			SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
				"SELECT * FROM ProductDescription INNER JOIN ProductModelProductDescriptionCulture ON "+
				"ProductDescription.ProductDescriptionID=ProductModelProductDescriptionCulture.ProductDescriptionID WHERE ProductModelProductDescriptionCulture.ProductModelID=@ProductModelID", ProductModel.Schema.Provider.Name);
			
			cmd.AddParameter("@ProductModelID", varProductModelID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			ProductDescriptionCollection coll = new ProductDescriptionCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}

		
		public static void SaveProductDescriptionMap(int varProductModelID, ProductDescriptionCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM ProductModelProductDescriptionCulture WHERE ProductModelID=@ProductModelID", ProductModel.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductModelID", varProductModelID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (ProductDescription item in items)
			{
				ProductModelProductDescriptionCulture varProductModelProductDescriptionCulture = new ProductModelProductDescriptionCulture();
				varProductModelProductDescriptionCulture.SetColumnValue("ProductModelID", varProductModelID);
				varProductModelProductDescriptionCulture.SetColumnValue("ProductDescriptionID", item.GetPrimaryKeyValue());
				varProductModelProductDescriptionCulture.Save();
			}

		}

		public static void SaveProductDescriptionMap(int varProductModelID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM ProductModelProductDescriptionCulture WHERE ProductModelID=@ProductModelID", ProductModel.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductModelID", varProductModelID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					ProductModelProductDescriptionCulture varProductModelProductDescriptionCulture = new ProductModelProductDescriptionCulture();
					varProductModelProductDescriptionCulture.SetColumnValue("ProductModelID", varProductModelID);
					varProductModelProductDescriptionCulture.SetColumnValue("ProductDescriptionID", l.Value);
					varProductModelProductDescriptionCulture.Save();
				}

			}

		}

		public static void SaveProductDescriptionMap(int varProductModelID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM ProductModelProductDescriptionCulture WHERE ProductModelID=@ProductModelID", ProductModel.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductModelID", varProductModelID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				ProductModelProductDescriptionCulture varProductModelProductDescriptionCulture = new ProductModelProductDescriptionCulture();
				varProductModelProductDescriptionCulture.SetColumnValue("ProductModelID", varProductModelID);
				varProductModelProductDescriptionCulture.SetColumnValue("ProductDescriptionID", item);
				varProductModelProductDescriptionCulture.Save();
			}

		}

		
		public static void DeleteProductDescriptionMap(int varProductModelID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM ProductModelProductDescriptionCulture WHERE ProductModelID=@ProductModelID", ProductModel.Schema.Provider.Name);
			cmdDel.AddParameter("@ProductModelID", varProductModelID);
			DataService.ExecuteQuery(cmdDel);
		}

		
		#endregion
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varName,string varCatalogDescription,string varInstructions,Guid varRowguid,DateTime varModifiedDate)
		{
			ProductModel item = new ProductModel();
			
			item.Name = varName;
			
			item.CatalogDescription = varCatalogDescription;
			
			item.Instructions = varInstructions;
			
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
		public static void Update(int varProductModelID,string varName,string varCatalogDescription,string varInstructions,Guid varRowguid,DateTime varModifiedDate)
		{
			ProductModel item = new ProductModel();
			
				item.ProductModelID = varProductModelID;
			
				item.Name = varName;
			
				item.CatalogDescription = varCatalogDescription;
			
				item.Instructions = varInstructions;
			
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
			 public static string ProductModelID = @"ProductModelID";
			 public static string Name = @"Name";
			 public static string CatalogDescription = @"CatalogDescription";
			 public static string Instructions = @"Instructions";
			 public static string Rowguid = @"rowguid";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}

		#endregion
	}

}

