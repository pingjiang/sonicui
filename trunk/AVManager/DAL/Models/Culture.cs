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
	/// Strongly-typed collection for the Culture class.
	/// </summary>
	[Serializable]
	public partial class CultureCollection : ActiveList<Culture, CultureCollection> 
	{	   
		public CultureCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the Culture table.
	/// </summary>
	[Serializable]
	public partial class Culture : ActiveRecord<Culture>
	{
		#region .ctors and Default Settings
		
		public Culture()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public Culture(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public Culture(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public Culture(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Culture", TableType.Table, DataService.GetInstance("Default"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Production";
				//columns
				
				TableSchema.TableColumn colvarCultureID = new TableSchema.TableColumn(schema);
				colvarCultureID.ColumnName = "CultureID";
				colvarCultureID.DataType = DbType.String;
				colvarCultureID.MaxLength = 6;
				colvarCultureID.AutoIncrement = false;
				colvarCultureID.IsNullable = false;
				colvarCultureID.IsPrimaryKey = true;
				colvarCultureID.IsForeignKey = false;
				colvarCultureID.IsReadOnly = false;
				colvarCultureID.DefaultSetting = @"";
				colvarCultureID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCultureID);
				
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
				DataService.Providers["Default"].AddSchema("Culture",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("CultureID")]
		public string CultureID 
		{
			get { return GetColumnValue<string>(Columns.CultureID); }

			set { SetColumnValue(Columns.CultureID, value); }

		}

		  
		[XmlAttribute("Name")]
		public string Name 
		{
			get { return GetColumnValue<string>(Columns.Name); }

			set { SetColumnValue(Columns.Name, value); }

		}

		  
		[XmlAttribute("ModifiedDate")]
		public DateTime ModifiedDate 
		{
			get { return GetColumnValue<DateTime>(Columns.ModifiedDate); }

			set { SetColumnValue(Columns.ModifiedDate, value); }

		}

		
		#endregion
		
		
		#region PrimaryKey Methods
		
		public AVManager.DAL.ProductModelProductDescriptionCultureCollection ProductModelProductDescriptionCultureRecords()
		{
			return new AVManager.DAL.ProductModelProductDescriptionCultureCollection().Where(ProductModelProductDescriptionCulture.Columns.CultureID, CultureID).Load();
		}

		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		#region Many To Many Helpers
		
		 
		public AVManager.DAL.ProductDescriptionCollection GetProductDescriptionCollection() { return Culture.GetProductDescriptionCollection(this.CultureID); }

		public static AVManager.DAL.ProductDescriptionCollection GetProductDescriptionCollection(string varCultureID)
		{
			SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
				"SELECT * FROM ProductDescription INNER JOIN ProductModelProductDescriptionCulture ON "+
				"ProductDescription.ProductDescriptionID=ProductModelProductDescriptionCulture.ProductDescriptionID WHERE ProductModelProductDescriptionCulture.CultureID=@CultureID", Culture.Schema.Provider.Name);
			
			cmd.AddParameter("@CultureID", varCultureID, DbType.String);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			ProductDescriptionCollection coll = new ProductDescriptionCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}

		
		public static void SaveProductDescriptionMap(string varCultureID, ProductDescriptionCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM ProductModelProductDescriptionCulture WHERE CultureID=@CultureID", Culture.Schema.Provider.Name);
			cmdDel.AddParameter("@CultureID", varCultureID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (ProductDescription item in items)
			{
				ProductModelProductDescriptionCulture varProductModelProductDescriptionCulture = new ProductModelProductDescriptionCulture();
				varProductModelProductDescriptionCulture.SetColumnValue("CultureID", varCultureID);
				varProductModelProductDescriptionCulture.SetColumnValue("ProductDescriptionID", item.GetPrimaryKeyValue());
				varProductModelProductDescriptionCulture.Save();
			}

		}

		public static void SaveProductDescriptionMap(string varCultureID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM ProductModelProductDescriptionCulture WHERE CultureID=@CultureID", Culture.Schema.Provider.Name);
			cmdDel.AddParameter("@CultureID", varCultureID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					ProductModelProductDescriptionCulture varProductModelProductDescriptionCulture = new ProductModelProductDescriptionCulture();
					varProductModelProductDescriptionCulture.SetColumnValue("CultureID", varCultureID);
					varProductModelProductDescriptionCulture.SetColumnValue("ProductDescriptionID", l.Value);
					varProductModelProductDescriptionCulture.Save();
				}

			}

		}

		public static void SaveProductDescriptionMap(string varCultureID , string[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM ProductModelProductDescriptionCulture WHERE CultureID=@CultureID", Culture.Schema.Provider.Name);
			cmdDel.AddParameter("@CultureID", varCultureID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (string item in itemList) 
			{
				ProductModelProductDescriptionCulture varProductModelProductDescriptionCulture = new ProductModelProductDescriptionCulture();
				varProductModelProductDescriptionCulture.SetColumnValue("CultureID", varCultureID);
				varProductModelProductDescriptionCulture.SetColumnValue("ProductDescriptionID", item);
				varProductModelProductDescriptionCulture.Save();
			}

		}

		
		public static void DeleteProductDescriptionMap(string varCultureID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM ProductModelProductDescriptionCulture WHERE CultureID=@CultureID", Culture.Schema.Provider.Name);
			cmdDel.AddParameter("@CultureID", varCultureID);
			DataService.ExecuteQuery(cmdDel);
		}

		
		 
		public AVManager.DAL.ProductModelCollection GetProductModelCollection() { return Culture.GetProductModelCollection(this.CultureID); }

		public static AVManager.DAL.ProductModelCollection GetProductModelCollection(string varCultureID)
		{
			SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
				"SELECT * FROM ProductModel INNER JOIN ProductModelProductDescriptionCulture ON "+
				"ProductModel.ProductModelID=ProductModelProductDescriptionCulture.ProductModelID WHERE ProductModelProductDescriptionCulture.CultureID=@CultureID", Culture.Schema.Provider.Name);
			
			cmd.AddParameter("@CultureID", varCultureID, DbType.String);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			ProductModelCollection coll = new ProductModelCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}

		
		public static void SaveProductModelMap(string varCultureID, ProductModelCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM ProductModelProductDescriptionCulture WHERE CultureID=@CultureID", Culture.Schema.Provider.Name);
			cmdDel.AddParameter("@CultureID", varCultureID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (ProductModel item in items)
			{
				ProductModelProductDescriptionCulture varProductModelProductDescriptionCulture = new ProductModelProductDescriptionCulture();
				varProductModelProductDescriptionCulture.SetColumnValue("CultureID", varCultureID);
				varProductModelProductDescriptionCulture.SetColumnValue("ProductModelID", item.GetPrimaryKeyValue());
				varProductModelProductDescriptionCulture.Save();
			}

		}

		public static void SaveProductModelMap(string varCultureID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM ProductModelProductDescriptionCulture WHERE CultureID=@CultureID", Culture.Schema.Provider.Name);
			cmdDel.AddParameter("@CultureID", varCultureID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					ProductModelProductDescriptionCulture varProductModelProductDescriptionCulture = new ProductModelProductDescriptionCulture();
					varProductModelProductDescriptionCulture.SetColumnValue("CultureID", varCultureID);
					varProductModelProductDescriptionCulture.SetColumnValue("ProductModelID", l.Value);
					varProductModelProductDescriptionCulture.Save();
				}

			}

		}

		public static void SaveProductModelMap(string varCultureID , string[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM ProductModelProductDescriptionCulture WHERE CultureID=@CultureID", Culture.Schema.Provider.Name);
			cmdDel.AddParameter("@CultureID", varCultureID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (string item in itemList) 
			{
				ProductModelProductDescriptionCulture varProductModelProductDescriptionCulture = new ProductModelProductDescriptionCulture();
				varProductModelProductDescriptionCulture.SetColumnValue("CultureID", varCultureID);
				varProductModelProductDescriptionCulture.SetColumnValue("ProductModelID", item);
				varProductModelProductDescriptionCulture.Save();
			}

		}

		
		public static void DeleteProductModelMap(string varCultureID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM ProductModelProductDescriptionCulture WHERE CultureID=@CultureID", Culture.Schema.Provider.Name);
			cmdDel.AddParameter("@CultureID", varCultureID);
			DataService.ExecuteQuery(cmdDel);
		}

		
		#endregion
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varCultureID,string varName,DateTime varModifiedDate)
		{
			Culture item = new Culture();
			
			item.CultureID = varCultureID;
			
			item.Name = varName;
			
			item.ModifiedDate = varModifiedDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(string varCultureID,string varName,DateTime varModifiedDate)
		{
			Culture item = new Culture();
			
				item.CultureID = varCultureID;
			
				item.Name = varName;
			
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
			 public static string CultureID = @"CultureID";
			 public static string Name = @"Name";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}

		#endregion
	}

}

