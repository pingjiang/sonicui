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
	/// Strongly-typed collection for the ContactType class.
	/// </summary>
	[Serializable]
	public partial class ContactTypeCollection : ActiveList<ContactType, ContactTypeCollection> 
	{	   
		public ContactTypeCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the ContactType table.
	/// </summary>
	[Serializable]
	public partial class ContactType : ActiveRecord<ContactType>
	{
		#region .ctors and Default Settings
		
		public ContactType()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public ContactType(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public ContactType(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public ContactType(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("ContactType", TableType.Table, DataService.GetInstance("Default"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Person";
				//columns
				
				TableSchema.TableColumn colvarContactTypeID = new TableSchema.TableColumn(schema);
				colvarContactTypeID.ColumnName = "ContactTypeID";
				colvarContactTypeID.DataType = DbType.Int32;
				colvarContactTypeID.MaxLength = 0;
				colvarContactTypeID.AutoIncrement = true;
				colvarContactTypeID.IsNullable = false;
				colvarContactTypeID.IsPrimaryKey = true;
				colvarContactTypeID.IsForeignKey = false;
				colvarContactTypeID.IsReadOnly = false;
				colvarContactTypeID.DefaultSetting = @"";
				colvarContactTypeID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarContactTypeID);
				
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
				DataService.Providers["Default"].AddSchema("ContactType",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("ContactTypeID")]
		public int ContactTypeID 
		{
			get { return GetColumnValue<int>(Columns.ContactTypeID); }

			set { SetColumnValue(Columns.ContactTypeID, value); }

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
		
		public AVManager.DAL.VendorContactCollection VendorContactRecords()
		{
			return new AVManager.DAL.VendorContactCollection().Where(VendorContact.Columns.ContactTypeID, ContactTypeID).Load();
		}

		public AVManager.DAL.StoreContactCollection StoreContactRecords()
		{
			return new AVManager.DAL.StoreContactCollection().Where(StoreContact.Columns.ContactTypeID, ContactTypeID).Load();
		}

		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		#region Many To Many Helpers
		
		 
		public AVManager.DAL.ContactCollection GetContactCollection() { return ContactType.GetContactCollection(this.ContactTypeID); }

		public static AVManager.DAL.ContactCollection GetContactCollection(int varContactTypeID)
		{
			SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
				"SELECT * FROM Contact INNER JOIN StoreContact ON "+
				"Contact.ContactID=StoreContact.ContactID WHERE StoreContact.ContactTypeID=@ContactTypeID", ContactType.Schema.Provider.Name);
			
			cmd.AddParameter("@ContactTypeID", varContactTypeID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			ContactCollection coll = new ContactCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}

		
		public static void SaveContactMap(int varContactTypeID, ContactCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM StoreContact WHERE ContactTypeID=@ContactTypeID", ContactType.Schema.Provider.Name);
			cmdDel.AddParameter("@ContactTypeID", varContactTypeID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Contact item in items)
			{
				StoreContact varStoreContact = new StoreContact();
				varStoreContact.SetColumnValue("ContactTypeID", varContactTypeID);
				varStoreContact.SetColumnValue("ContactID", item.GetPrimaryKeyValue());
				varStoreContact.Save();
			}

		}

		public static void SaveContactMap(int varContactTypeID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM StoreContact WHERE ContactTypeID=@ContactTypeID", ContactType.Schema.Provider.Name);
			cmdDel.AddParameter("@ContactTypeID", varContactTypeID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					StoreContact varStoreContact = new StoreContact();
					varStoreContact.SetColumnValue("ContactTypeID", varContactTypeID);
					varStoreContact.SetColumnValue("ContactID", l.Value);
					varStoreContact.Save();
				}

			}

		}

		public static void SaveContactMap(int varContactTypeID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM StoreContact WHERE ContactTypeID=@ContactTypeID", ContactType.Schema.Provider.Name);
			cmdDel.AddParameter("@ContactTypeID", varContactTypeID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				StoreContact varStoreContact = new StoreContact();
				varStoreContact.SetColumnValue("ContactTypeID", varContactTypeID);
				varStoreContact.SetColumnValue("ContactID", item);
				varStoreContact.Save();
			}

		}

		
		public static void DeleteContactMap(int varContactTypeID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM StoreContact WHERE ContactTypeID=@ContactTypeID", ContactType.Schema.Provider.Name);
			cmdDel.AddParameter("@ContactTypeID", varContactTypeID);
			DataService.ExecuteQuery(cmdDel);
		}

		
		 
		public AVManager.DAL.StoreCollection GetStoreCollection() { return ContactType.GetStoreCollection(this.ContactTypeID); }

		public static AVManager.DAL.StoreCollection GetStoreCollection(int varContactTypeID)
		{
			SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
				"SELECT * FROM Store INNER JOIN StoreContact ON "+
				"Store.CustomerID=StoreContact.CustomerID WHERE StoreContact.ContactTypeID=@ContactTypeID", ContactType.Schema.Provider.Name);
			
			cmd.AddParameter("@ContactTypeID", varContactTypeID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			StoreCollection coll = new StoreCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}

		
		public static void SaveStoreMap(int varContactTypeID, StoreCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM StoreContact WHERE ContactTypeID=@ContactTypeID", ContactType.Schema.Provider.Name);
			cmdDel.AddParameter("@ContactTypeID", varContactTypeID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Store item in items)
			{
				StoreContact varStoreContact = new StoreContact();
				varStoreContact.SetColumnValue("ContactTypeID", varContactTypeID);
				varStoreContact.SetColumnValue("CustomerID", item.GetPrimaryKeyValue());
				varStoreContact.Save();
			}

		}

		public static void SaveStoreMap(int varContactTypeID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM StoreContact WHERE ContactTypeID=@ContactTypeID", ContactType.Schema.Provider.Name);
			cmdDel.AddParameter("@ContactTypeID", varContactTypeID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					StoreContact varStoreContact = new StoreContact();
					varStoreContact.SetColumnValue("ContactTypeID", varContactTypeID);
					varStoreContact.SetColumnValue("CustomerID", l.Value);
					varStoreContact.Save();
				}

			}

		}

		public static void SaveStoreMap(int varContactTypeID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM StoreContact WHERE ContactTypeID=@ContactTypeID", ContactType.Schema.Provider.Name);
			cmdDel.AddParameter("@ContactTypeID", varContactTypeID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				StoreContact varStoreContact = new StoreContact();
				varStoreContact.SetColumnValue("ContactTypeID", varContactTypeID);
				varStoreContact.SetColumnValue("CustomerID", item);
				varStoreContact.Save();
			}

		}

		
		public static void DeleteStoreMap(int varContactTypeID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM StoreContact WHERE ContactTypeID=@ContactTypeID", ContactType.Schema.Provider.Name);
			cmdDel.AddParameter("@ContactTypeID", varContactTypeID);
			DataService.ExecuteQuery(cmdDel);
		}

		
		 
		public AVManager.DAL.VendorCollection GetVendorCollection() { return ContactType.GetVendorCollection(this.ContactTypeID); }

		public static AVManager.DAL.VendorCollection GetVendorCollection(int varContactTypeID)
		{
			SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
				"SELECT * FROM Vendor INNER JOIN VendorContact ON "+
				"Vendor.VendorID=VendorContact.VendorID WHERE VendorContact.ContactTypeID=@ContactTypeID", ContactType.Schema.Provider.Name);
			
			cmd.AddParameter("@ContactTypeID", varContactTypeID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			VendorCollection coll = new VendorCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}

		
		public static void SaveVendorMap(int varContactTypeID, VendorCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM VendorContact WHERE ContactTypeID=@ContactTypeID", ContactType.Schema.Provider.Name);
			cmdDel.AddParameter("@ContactTypeID", varContactTypeID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Vendor item in items)
			{
				VendorContact varVendorContact = new VendorContact();
				varVendorContact.SetColumnValue("ContactTypeID", varContactTypeID);
				varVendorContact.SetColumnValue("VendorID", item.GetPrimaryKeyValue());
				varVendorContact.Save();
			}

		}

		public static void SaveVendorMap(int varContactTypeID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM VendorContact WHERE ContactTypeID=@ContactTypeID", ContactType.Schema.Provider.Name);
			cmdDel.AddParameter("@ContactTypeID", varContactTypeID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					VendorContact varVendorContact = new VendorContact();
					varVendorContact.SetColumnValue("ContactTypeID", varContactTypeID);
					varVendorContact.SetColumnValue("VendorID", l.Value);
					varVendorContact.Save();
				}

			}

		}

		public static void SaveVendorMap(int varContactTypeID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM VendorContact WHERE ContactTypeID=@ContactTypeID", ContactType.Schema.Provider.Name);
			cmdDel.AddParameter("@ContactTypeID", varContactTypeID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				VendorContact varVendorContact = new VendorContact();
				varVendorContact.SetColumnValue("ContactTypeID", varContactTypeID);
				varVendorContact.SetColumnValue("VendorID", item);
				varVendorContact.Save();
			}

		}

		
		public static void DeleteVendorMap(int varContactTypeID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM VendorContact WHERE ContactTypeID=@ContactTypeID", ContactType.Schema.Provider.Name);
			cmdDel.AddParameter("@ContactTypeID", varContactTypeID);
			DataService.ExecuteQuery(cmdDel);
		}

		
		#endregion
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varName,DateTime varModifiedDate)
		{
			ContactType item = new ContactType();
			
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
		public static void Update(int varContactTypeID,string varName,DateTime varModifiedDate)
		{
			ContactType item = new ContactType();
			
				item.ContactTypeID = varContactTypeID;
			
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
			 public static string ContactTypeID = @"ContactTypeID";
			 public static string Name = @"Name";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}

		#endregion
	}

}

