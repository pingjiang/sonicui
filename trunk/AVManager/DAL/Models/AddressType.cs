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
	/// Strongly-typed collection for the AddressType class.
	/// </summary>
	[Serializable]
	public partial class AddressTypeCollection : ActiveList<AddressType, AddressTypeCollection> 
	{	   
		public AddressTypeCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the AddressType table.
	/// </summary>
	[Serializable]
	public partial class AddressType : ActiveRecord<AddressType>
	{
		#region .ctors and Default Settings
		
		public AddressType()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public AddressType(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public AddressType(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public AddressType(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("AddressType", TableType.Table, DataService.GetInstance("Default"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Person";
				//columns
				
				TableSchema.TableColumn colvarAddressTypeID = new TableSchema.TableColumn(schema);
				colvarAddressTypeID.ColumnName = "AddressTypeID";
				colvarAddressTypeID.DataType = DbType.Int32;
				colvarAddressTypeID.MaxLength = 0;
				colvarAddressTypeID.AutoIncrement = true;
				colvarAddressTypeID.IsNullable = false;
				colvarAddressTypeID.IsPrimaryKey = true;
				colvarAddressTypeID.IsForeignKey = false;
				colvarAddressTypeID.IsReadOnly = false;
				colvarAddressTypeID.DefaultSetting = @"";
				colvarAddressTypeID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAddressTypeID);
				
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
				DataService.Providers["Default"].AddSchema("AddressType",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("AddressTypeID")]
		public int AddressTypeID 
		{
			get { return GetColumnValue<int>(Columns.AddressTypeID); }

			set { SetColumnValue(Columns.AddressTypeID, value); }

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
		
		public AVManager.DAL.VendorAddressCollection VendorAddressRecords()
		{
			return new AVManager.DAL.VendorAddressCollection().Where(VendorAddress.Columns.AddressTypeID, AddressTypeID).Load();
		}

		public AVManager.DAL.CustomerAddressCollection CustomerAddressRecords()
		{
			return new AVManager.DAL.CustomerAddressCollection().Where(CustomerAddress.Columns.AddressTypeID, AddressTypeID).Load();
		}

		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		#region Many To Many Helpers
		
		 
		public AVManager.DAL.AddressCollection GetAddressCollection() { return AddressType.GetAddressCollection(this.AddressTypeID); }

		public static AVManager.DAL.AddressCollection GetAddressCollection(int varAddressTypeID)
		{
			SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
				"SELECT * FROM Address INNER JOIN VendorAddress ON "+
				"Address.AddressID=VendorAddress.AddressID WHERE VendorAddress.AddressTypeID=@AddressTypeID", AddressType.Schema.Provider.Name);
			
			cmd.AddParameter("@AddressTypeID", varAddressTypeID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			AddressCollection coll = new AddressCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}

		
		public static void SaveAddressMap(int varAddressTypeID, AddressCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM VendorAddress WHERE AddressTypeID=@AddressTypeID", AddressType.Schema.Provider.Name);
			cmdDel.AddParameter("@AddressTypeID", varAddressTypeID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Address item in items)
			{
				VendorAddress varVendorAddress = new VendorAddress();
				varVendorAddress.SetColumnValue("AddressTypeID", varAddressTypeID);
				varVendorAddress.SetColumnValue("AddressID", item.GetPrimaryKeyValue());
				varVendorAddress.Save();
			}

		}

		public static void SaveAddressMap(int varAddressTypeID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM VendorAddress WHERE AddressTypeID=@AddressTypeID", AddressType.Schema.Provider.Name);
			cmdDel.AddParameter("@AddressTypeID", varAddressTypeID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					VendorAddress varVendorAddress = new VendorAddress();
					varVendorAddress.SetColumnValue("AddressTypeID", varAddressTypeID);
					varVendorAddress.SetColumnValue("AddressID", l.Value);
					varVendorAddress.Save();
				}

			}

		}

		public static void SaveAddressMap(int varAddressTypeID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM VendorAddress WHERE AddressTypeID=@AddressTypeID", AddressType.Schema.Provider.Name);
			cmdDel.AddParameter("@AddressTypeID", varAddressTypeID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				VendorAddress varVendorAddress = new VendorAddress();
				varVendorAddress.SetColumnValue("AddressTypeID", varAddressTypeID);
				varVendorAddress.SetColumnValue("AddressID", item);
				varVendorAddress.Save();
			}

		}

		
		public static void DeleteAddressMap(int varAddressTypeID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM VendorAddress WHERE AddressTypeID=@AddressTypeID", AddressType.Schema.Provider.Name);
			cmdDel.AddParameter("@AddressTypeID", varAddressTypeID);
			DataService.ExecuteQuery(cmdDel);
		}

		
		 
		public AVManager.DAL.VendorCollection GetVendorCollection() { return AddressType.GetVendorCollection(this.AddressTypeID); }

		public static AVManager.DAL.VendorCollection GetVendorCollection(int varAddressTypeID)
		{
			SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
				"SELECT * FROM Vendor INNER JOIN VendorAddress ON "+
				"Vendor.VendorID=VendorAddress.VendorID WHERE VendorAddress.AddressTypeID=@AddressTypeID", AddressType.Schema.Provider.Name);
			
			cmd.AddParameter("@AddressTypeID", varAddressTypeID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			VendorCollection coll = new VendorCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}

		
		public static void SaveVendorMap(int varAddressTypeID, VendorCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM VendorAddress WHERE AddressTypeID=@AddressTypeID", AddressType.Schema.Provider.Name);
			cmdDel.AddParameter("@AddressTypeID", varAddressTypeID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Vendor item in items)
			{
				VendorAddress varVendorAddress = new VendorAddress();
				varVendorAddress.SetColumnValue("AddressTypeID", varAddressTypeID);
				varVendorAddress.SetColumnValue("VendorID", item.GetPrimaryKeyValue());
				varVendorAddress.Save();
			}

		}

		public static void SaveVendorMap(int varAddressTypeID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM VendorAddress WHERE AddressTypeID=@AddressTypeID", AddressType.Schema.Provider.Name);
			cmdDel.AddParameter("@AddressTypeID", varAddressTypeID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					VendorAddress varVendorAddress = new VendorAddress();
					varVendorAddress.SetColumnValue("AddressTypeID", varAddressTypeID);
					varVendorAddress.SetColumnValue("VendorID", l.Value);
					varVendorAddress.Save();
				}

			}

		}

		public static void SaveVendorMap(int varAddressTypeID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM VendorAddress WHERE AddressTypeID=@AddressTypeID", AddressType.Schema.Provider.Name);
			cmdDel.AddParameter("@AddressTypeID", varAddressTypeID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				VendorAddress varVendorAddress = new VendorAddress();
				varVendorAddress.SetColumnValue("AddressTypeID", varAddressTypeID);
				varVendorAddress.SetColumnValue("VendorID", item);
				varVendorAddress.Save();
			}

		}

		
		public static void DeleteVendorMap(int varAddressTypeID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM VendorAddress WHERE AddressTypeID=@AddressTypeID", AddressType.Schema.Provider.Name);
			cmdDel.AddParameter("@AddressTypeID", varAddressTypeID);
			DataService.ExecuteQuery(cmdDel);
		}

		
		 
		public AVManager.DAL.CustomerCollection GetCustomerCollection() { return AddressType.GetCustomerCollection(this.AddressTypeID); }

		public static AVManager.DAL.CustomerCollection GetCustomerCollection(int varAddressTypeID)
		{
			SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
				"SELECT * FROM Customer INNER JOIN CustomerAddress ON "+
				"Customer.CustomerID=CustomerAddress.CustomerID WHERE CustomerAddress.AddressTypeID=@AddressTypeID", AddressType.Schema.Provider.Name);
			
			cmd.AddParameter("@AddressTypeID", varAddressTypeID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			CustomerCollection coll = new CustomerCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}

		
		public static void SaveCustomerMap(int varAddressTypeID, CustomerCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM CustomerAddress WHERE AddressTypeID=@AddressTypeID", AddressType.Schema.Provider.Name);
			cmdDel.AddParameter("@AddressTypeID", varAddressTypeID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Customer item in items)
			{
				CustomerAddress varCustomerAddress = new CustomerAddress();
				varCustomerAddress.SetColumnValue("AddressTypeID", varAddressTypeID);
				varCustomerAddress.SetColumnValue("CustomerID", item.GetPrimaryKeyValue());
				varCustomerAddress.Save();
			}

		}

		public static void SaveCustomerMap(int varAddressTypeID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM CustomerAddress WHERE AddressTypeID=@AddressTypeID", AddressType.Schema.Provider.Name);
			cmdDel.AddParameter("@AddressTypeID", varAddressTypeID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					CustomerAddress varCustomerAddress = new CustomerAddress();
					varCustomerAddress.SetColumnValue("AddressTypeID", varAddressTypeID);
					varCustomerAddress.SetColumnValue("CustomerID", l.Value);
					varCustomerAddress.Save();
				}

			}

		}

		public static void SaveCustomerMap(int varAddressTypeID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM CustomerAddress WHERE AddressTypeID=@AddressTypeID", AddressType.Schema.Provider.Name);
			cmdDel.AddParameter("@AddressTypeID", varAddressTypeID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				CustomerAddress varCustomerAddress = new CustomerAddress();
				varCustomerAddress.SetColumnValue("AddressTypeID", varAddressTypeID);
				varCustomerAddress.SetColumnValue("CustomerID", item);
				varCustomerAddress.Save();
			}

		}

		
		public static void DeleteCustomerMap(int varAddressTypeID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM CustomerAddress WHERE AddressTypeID=@AddressTypeID", AddressType.Schema.Provider.Name);
			cmdDel.AddParameter("@AddressTypeID", varAddressTypeID);
			DataService.ExecuteQuery(cmdDel);
		}

		
		#endregion
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varName,Guid varRowguid,DateTime varModifiedDate)
		{
			AddressType item = new AddressType();
			
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
		public static void Update(int varAddressTypeID,string varName,Guid varRowguid,DateTime varModifiedDate)
		{
			AddressType item = new AddressType();
			
				item.AddressTypeID = varAddressTypeID;
			
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
			 public static string AddressTypeID = @"AddressTypeID";
			 public static string Name = @"Name";
			 public static string Rowguid = @"rowguid";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}

		#endregion
	}

}

