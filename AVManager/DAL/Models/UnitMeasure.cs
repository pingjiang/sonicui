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
	/// Strongly-typed collection for the UnitMeasure class.
	/// </summary>
	[Serializable]
	public partial class UnitMeasureCollection : ActiveList<UnitMeasure, UnitMeasureCollection> 
	{	   
		public UnitMeasureCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the UnitMeasure table.
	/// </summary>
	[Serializable]
	public partial class UnitMeasure : ActiveRecord<UnitMeasure>
	{
		#region .ctors and Default Settings
		
		public UnitMeasure()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public UnitMeasure(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public UnitMeasure(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public UnitMeasure(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("UnitMeasure", TableType.Table, DataService.GetInstance("Default"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Production";
				//columns
				
				TableSchema.TableColumn colvarUnitMeasureCode = new TableSchema.TableColumn(schema);
				colvarUnitMeasureCode.ColumnName = "UnitMeasureCode";
				colvarUnitMeasureCode.DataType = DbType.String;
				colvarUnitMeasureCode.MaxLength = 3;
				colvarUnitMeasureCode.AutoIncrement = false;
				colvarUnitMeasureCode.IsNullable = false;
				colvarUnitMeasureCode.IsPrimaryKey = true;
				colvarUnitMeasureCode.IsForeignKey = false;
				colvarUnitMeasureCode.IsReadOnly = false;
				colvarUnitMeasureCode.DefaultSetting = @"";
				colvarUnitMeasureCode.ForeignKeyTableName = "";
				schema.Columns.Add(colvarUnitMeasureCode);
				
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
				DataService.Providers["Default"].AddSchema("UnitMeasure",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("UnitMeasureCode")]
		public string UnitMeasureCode 
		{
			get { return GetColumnValue<string>(Columns.UnitMeasureCode); }

			set { SetColumnValue(Columns.UnitMeasureCode, value); }

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
		
		public AVManager.DAL.BillOfMaterialCollection BillOfMaterials()
		{
			return new AVManager.DAL.BillOfMaterialCollection().Where(BillOfMaterial.Columns.UnitMeasureCode, UnitMeasureCode).Load();
		}

		public AVManager.DAL.ProductCollection ProductRecords()
		{
			return new AVManager.DAL.ProductCollection().Where(Product.Columns.SizeUnitMeasureCode, UnitMeasureCode).Load();
		}

		public AVManager.DAL.ProductCollection ProductRecordsFromUnitMeasure()
		{
			return new AVManager.DAL.ProductCollection().Where(Product.Columns.WeightUnitMeasureCode, UnitMeasureCode).Load();
		}

		public AVManager.DAL.ProductVendorCollection ProductVendorRecords()
		{
			return new AVManager.DAL.ProductVendorCollection().Where(ProductVendor.Columns.UnitMeasureCode, UnitMeasureCode).Load();
		}

		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		#region Many To Many Helpers
		
		 
		public AVManager.DAL.ProductCollection GetProductCollection() { return UnitMeasure.GetProductCollection(this.UnitMeasureCode); }

		public static AVManager.DAL.ProductCollection GetProductCollection(string varUnitMeasureCode)
		{
			SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
				"SELECT * FROM Product INNER JOIN ProductVendor ON "+
				"Product.ProductID=ProductVendor.ProductID WHERE ProductVendor.UnitMeasureCode=@UnitMeasureCode", UnitMeasure.Schema.Provider.Name);
			
			cmd.AddParameter("@UnitMeasureCode", varUnitMeasureCode, DbType.String);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			ProductCollection coll = new ProductCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}

		
		public static void SaveProductMap(string varUnitMeasureCode, ProductCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM ProductVendor WHERE UnitMeasureCode=@UnitMeasureCode", UnitMeasure.Schema.Provider.Name);
			cmdDel.AddParameter("@UnitMeasureCode", varUnitMeasureCode);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Product item in items)
			{
				ProductVendor varProductVendor = new ProductVendor();
				varProductVendor.SetColumnValue("UnitMeasureCode", varUnitMeasureCode);
				varProductVendor.SetColumnValue("ProductID", item.GetPrimaryKeyValue());
				varProductVendor.Save();
			}

		}

		public static void SaveProductMap(string varUnitMeasureCode, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM ProductVendor WHERE UnitMeasureCode=@UnitMeasureCode", UnitMeasure.Schema.Provider.Name);
			cmdDel.AddParameter("@UnitMeasureCode", varUnitMeasureCode);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					ProductVendor varProductVendor = new ProductVendor();
					varProductVendor.SetColumnValue("UnitMeasureCode", varUnitMeasureCode);
					varProductVendor.SetColumnValue("ProductID", l.Value);
					varProductVendor.Save();
				}

			}

		}

		public static void SaveProductMap(string varUnitMeasureCode , string[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM ProductVendor WHERE UnitMeasureCode=@UnitMeasureCode", UnitMeasure.Schema.Provider.Name);
			cmdDel.AddParameter("@UnitMeasureCode", varUnitMeasureCode);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (string item in itemList) 
			{
				ProductVendor varProductVendor = new ProductVendor();
				varProductVendor.SetColumnValue("UnitMeasureCode", varUnitMeasureCode);
				varProductVendor.SetColumnValue("ProductID", item);
				varProductVendor.Save();
			}

		}

		
		public static void DeleteProductMap(string varUnitMeasureCode) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM ProductVendor WHERE UnitMeasureCode=@UnitMeasureCode", UnitMeasure.Schema.Provider.Name);
			cmdDel.AddParameter("@UnitMeasureCode", varUnitMeasureCode);
			DataService.ExecuteQuery(cmdDel);
		}

		
		 
		public AVManager.DAL.VendorCollection GetVendorCollection() { return UnitMeasure.GetVendorCollection(this.UnitMeasureCode); }

		public static AVManager.DAL.VendorCollection GetVendorCollection(string varUnitMeasureCode)
		{
			SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
				"SELECT * FROM Vendor INNER JOIN ProductVendor ON "+
				"Vendor.VendorID=ProductVendor.VendorID WHERE ProductVendor.UnitMeasureCode=@UnitMeasureCode", UnitMeasure.Schema.Provider.Name);
			
			cmd.AddParameter("@UnitMeasureCode", varUnitMeasureCode, DbType.String);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			VendorCollection coll = new VendorCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}

		
		public static void SaveVendorMap(string varUnitMeasureCode, VendorCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM ProductVendor WHERE UnitMeasureCode=@UnitMeasureCode", UnitMeasure.Schema.Provider.Name);
			cmdDel.AddParameter("@UnitMeasureCode", varUnitMeasureCode);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Vendor item in items)
			{
				ProductVendor varProductVendor = new ProductVendor();
				varProductVendor.SetColumnValue("UnitMeasureCode", varUnitMeasureCode);
				varProductVendor.SetColumnValue("VendorID", item.GetPrimaryKeyValue());
				varProductVendor.Save();
			}

		}

		public static void SaveVendorMap(string varUnitMeasureCode, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM ProductVendor WHERE UnitMeasureCode=@UnitMeasureCode", UnitMeasure.Schema.Provider.Name);
			cmdDel.AddParameter("@UnitMeasureCode", varUnitMeasureCode);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					ProductVendor varProductVendor = new ProductVendor();
					varProductVendor.SetColumnValue("UnitMeasureCode", varUnitMeasureCode);
					varProductVendor.SetColumnValue("VendorID", l.Value);
					varProductVendor.Save();
				}

			}

		}

		public static void SaveVendorMap(string varUnitMeasureCode , string[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM ProductVendor WHERE UnitMeasureCode=@UnitMeasureCode", UnitMeasure.Schema.Provider.Name);
			cmdDel.AddParameter("@UnitMeasureCode", varUnitMeasureCode);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (string item in itemList) 
			{
				ProductVendor varProductVendor = new ProductVendor();
				varProductVendor.SetColumnValue("UnitMeasureCode", varUnitMeasureCode);
				varProductVendor.SetColumnValue("VendorID", item);
				varProductVendor.Save();
			}

		}

		
		public static void DeleteVendorMap(string varUnitMeasureCode) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM ProductVendor WHERE UnitMeasureCode=@UnitMeasureCode", UnitMeasure.Schema.Provider.Name);
			cmdDel.AddParameter("@UnitMeasureCode", varUnitMeasureCode);
			DataService.ExecuteQuery(cmdDel);
		}

		
		#endregion
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varUnitMeasureCode,string varName,DateTime varModifiedDate)
		{
			UnitMeasure item = new UnitMeasure();
			
			item.UnitMeasureCode = varUnitMeasureCode;
			
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
		public static void Update(string varUnitMeasureCode,string varName,DateTime varModifiedDate)
		{
			UnitMeasure item = new UnitMeasure();
			
				item.UnitMeasureCode = varUnitMeasureCode;
			
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
			 public static string UnitMeasureCode = @"UnitMeasureCode";
			 public static string Name = @"Name";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}

		#endregion
	}

}

