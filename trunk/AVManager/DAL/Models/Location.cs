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
	/// Strongly-typed collection for the Location class.
	/// </summary>
	[Serializable]
	public partial class LocationCollection : ActiveList<Location, LocationCollection> 
	{	   
		public LocationCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the Location table.
	/// </summary>
	[Serializable]
	public partial class Location : ActiveRecord<Location>
	{
		#region .ctors and Default Settings
		
		public Location()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public Location(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public Location(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public Location(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Location", TableType.Table, DataService.GetInstance("Default"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Production";
				//columns
				
				TableSchema.TableColumn colvarLocationID = new TableSchema.TableColumn(schema);
				colvarLocationID.ColumnName = "LocationID";
				colvarLocationID.DataType = DbType.Int16;
				colvarLocationID.MaxLength = 0;
				colvarLocationID.AutoIncrement = true;
				colvarLocationID.IsNullable = false;
				colvarLocationID.IsPrimaryKey = true;
				colvarLocationID.IsForeignKey = false;
				colvarLocationID.IsReadOnly = false;
				colvarLocationID.DefaultSetting = @"";
				colvarLocationID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLocationID);
				
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
				
				TableSchema.TableColumn colvarCostRate = new TableSchema.TableColumn(schema);
				colvarCostRate.ColumnName = "CostRate";
				colvarCostRate.DataType = DbType.Currency;
				colvarCostRate.MaxLength = 0;
				colvarCostRate.AutoIncrement = false;
				colvarCostRate.IsNullable = false;
				colvarCostRate.IsPrimaryKey = false;
				colvarCostRate.IsForeignKey = false;
				colvarCostRate.IsReadOnly = false;
				
						colvarCostRate.DefaultSetting = @"((0.00))";
				colvarCostRate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCostRate);
				
				TableSchema.TableColumn colvarAvailability = new TableSchema.TableColumn(schema);
				colvarAvailability.ColumnName = "Availability";
				colvarAvailability.DataType = DbType.Decimal;
				colvarAvailability.MaxLength = 0;
				colvarAvailability.AutoIncrement = false;
				colvarAvailability.IsNullable = false;
				colvarAvailability.IsPrimaryKey = false;
				colvarAvailability.IsForeignKey = false;
				colvarAvailability.IsReadOnly = false;
				
						colvarAvailability.DefaultSetting = @"((0.00))";
				colvarAvailability.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAvailability);
				
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
				DataService.Providers["Default"].AddSchema("Location",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("LocationID")]
		public short LocationID 
		{
			get { return GetColumnValue<short>(Columns.LocationID); }

			set { SetColumnValue(Columns.LocationID, value); }

		}

		  
		[XmlAttribute("Name")]
		public string Name 
		{
			get { return GetColumnValue<string>(Columns.Name); }

			set { SetColumnValue(Columns.Name, value); }

		}

		  
		[XmlAttribute("CostRate")]
		public decimal CostRate 
		{
			get { return GetColumnValue<decimal>(Columns.CostRate); }

			set { SetColumnValue(Columns.CostRate, value); }

		}

		  
		[XmlAttribute("Availability")]
		public decimal Availability 
		{
			get { return GetColumnValue<decimal>(Columns.Availability); }

			set { SetColumnValue(Columns.Availability, value); }

		}

		  
		[XmlAttribute("ModifiedDate")]
		public DateTime ModifiedDate 
		{
			get { return GetColumnValue<DateTime>(Columns.ModifiedDate); }

			set { SetColumnValue(Columns.ModifiedDate, value); }

		}

		
		#endregion
		
		
		#region PrimaryKey Methods
		
		public AVManager.DAL.ProductInventoryCollection ProductInventoryRecords()
		{
			return new AVManager.DAL.ProductInventoryCollection().Where(ProductInventory.Columns.LocationID, LocationID).Load();
		}

		public AVManager.DAL.WorkOrderRoutingCollection WorkOrderRoutingRecords()
		{
			return new AVManager.DAL.WorkOrderRoutingCollection().Where(WorkOrderRouting.Columns.LocationID, LocationID).Load();
		}

		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		#region Many To Many Helpers
		
		 
		public AVManager.DAL.ProductCollection GetProductCollection() { return Location.GetProductCollection(this.LocationID); }

		public static AVManager.DAL.ProductCollection GetProductCollection(short varLocationID)
		{
			SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
				"SELECT * FROM Product INNER JOIN ProductInventory ON "+
				"Product.ProductID=ProductInventory.ProductID WHERE ProductInventory.LocationID=@LocationID", Location.Schema.Provider.Name);
			
			cmd.AddParameter("@LocationID", varLocationID, DbType.Int16);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			ProductCollection coll = new ProductCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}

		
		public static void SaveProductMap(short varLocationID, ProductCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM ProductInventory WHERE LocationID=@LocationID", Location.Schema.Provider.Name);
			cmdDel.AddParameter("@LocationID", varLocationID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Product item in items)
			{
				ProductInventory varProductInventory = new ProductInventory();
				varProductInventory.SetColumnValue("LocationID", varLocationID);
				varProductInventory.SetColumnValue("ProductID", item.GetPrimaryKeyValue());
				varProductInventory.Save();
			}

		}

		public static void SaveProductMap(short varLocationID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM ProductInventory WHERE LocationID=@LocationID", Location.Schema.Provider.Name);
			cmdDel.AddParameter("@LocationID", varLocationID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					ProductInventory varProductInventory = new ProductInventory();
					varProductInventory.SetColumnValue("LocationID", varLocationID);
					varProductInventory.SetColumnValue("ProductID", l.Value);
					varProductInventory.Save();
				}

			}

		}

		public static void SaveProductMap(short varLocationID , short[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM ProductInventory WHERE LocationID=@LocationID", Location.Schema.Provider.Name);
			cmdDel.AddParameter("@LocationID", varLocationID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (short item in itemList) 
			{
				ProductInventory varProductInventory = new ProductInventory();
				varProductInventory.SetColumnValue("LocationID", varLocationID);
				varProductInventory.SetColumnValue("ProductID", item);
				varProductInventory.Save();
			}

		}

		
		public static void DeleteProductMap(short varLocationID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM ProductInventory WHERE LocationID=@LocationID", Location.Schema.Provider.Name);
			cmdDel.AddParameter("@LocationID", varLocationID);
			DataService.ExecuteQuery(cmdDel);
		}

		
		#endregion
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varName,decimal varCostRate,decimal varAvailability,DateTime varModifiedDate)
		{
			Location item = new Location();
			
			item.Name = varName;
			
			item.CostRate = varCostRate;
			
			item.Availability = varAvailability;
			
			item.ModifiedDate = varModifiedDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(short varLocationID,string varName,decimal varCostRate,decimal varAvailability,DateTime varModifiedDate)
		{
			Location item = new Location();
			
				item.LocationID = varLocationID;
			
				item.Name = varName;
			
				item.CostRate = varCostRate;
			
				item.Availability = varAvailability;
			
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
			 public static string LocationID = @"LocationID";
			 public static string Name = @"Name";
			 public static string CostRate = @"CostRate";
			 public static string Availability = @"Availability";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}

		#endregion
	}

}

