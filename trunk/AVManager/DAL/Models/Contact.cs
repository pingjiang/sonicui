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
	/// Strongly-typed collection for the Contact class.
	/// </summary>
	[Serializable]
	public partial class ContactCollection : ActiveList<Contact, ContactCollection> 
	{	   
		public ContactCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the Contact table.
	/// </summary>
	[Serializable]
	public partial class Contact : ActiveRecord<Contact>
	{
		#region .ctors and Default Settings
		
		public Contact()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public Contact(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public Contact(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public Contact(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Contact", TableType.Table, DataService.GetInstance("Default"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Person";
				//columns
				
				TableSchema.TableColumn colvarContactID = new TableSchema.TableColumn(schema);
				colvarContactID.ColumnName = "ContactID";
				colvarContactID.DataType = DbType.Int32;
				colvarContactID.MaxLength = 0;
				colvarContactID.AutoIncrement = true;
				colvarContactID.IsNullable = false;
				colvarContactID.IsPrimaryKey = true;
				colvarContactID.IsForeignKey = false;
				colvarContactID.IsReadOnly = false;
				colvarContactID.DefaultSetting = @"";
				colvarContactID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarContactID);
				
				TableSchema.TableColumn colvarNameStyle = new TableSchema.TableColumn(schema);
				colvarNameStyle.ColumnName = "NameStyle";
				colvarNameStyle.DataType = DbType.Boolean;
				colvarNameStyle.MaxLength = 0;
				colvarNameStyle.AutoIncrement = false;
				colvarNameStyle.IsNullable = false;
				colvarNameStyle.IsPrimaryKey = false;
				colvarNameStyle.IsForeignKey = false;
				colvarNameStyle.IsReadOnly = false;
				
						colvarNameStyle.DefaultSetting = @"((0))";
				colvarNameStyle.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNameStyle);
				
				TableSchema.TableColumn colvarTitle = new TableSchema.TableColumn(schema);
				colvarTitle.ColumnName = "Title";
				colvarTitle.DataType = DbType.String;
				colvarTitle.MaxLength = 8;
				colvarTitle.AutoIncrement = false;
				colvarTitle.IsNullable = true;
				colvarTitle.IsPrimaryKey = false;
				colvarTitle.IsForeignKey = false;
				colvarTitle.IsReadOnly = false;
				colvarTitle.DefaultSetting = @"";
				colvarTitle.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTitle);
				
				TableSchema.TableColumn colvarFirstName = new TableSchema.TableColumn(schema);
				colvarFirstName.ColumnName = "FirstName";
				colvarFirstName.DataType = DbType.String;
				colvarFirstName.MaxLength = 50;
				colvarFirstName.AutoIncrement = false;
				colvarFirstName.IsNullable = false;
				colvarFirstName.IsPrimaryKey = false;
				colvarFirstName.IsForeignKey = false;
				colvarFirstName.IsReadOnly = false;
				colvarFirstName.DefaultSetting = @"";
				colvarFirstName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFirstName);
				
				TableSchema.TableColumn colvarMiddleName = new TableSchema.TableColumn(schema);
				colvarMiddleName.ColumnName = "MiddleName";
				colvarMiddleName.DataType = DbType.String;
				colvarMiddleName.MaxLength = 50;
				colvarMiddleName.AutoIncrement = false;
				colvarMiddleName.IsNullable = true;
				colvarMiddleName.IsPrimaryKey = false;
				colvarMiddleName.IsForeignKey = false;
				colvarMiddleName.IsReadOnly = false;
				colvarMiddleName.DefaultSetting = @"";
				colvarMiddleName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMiddleName);
				
				TableSchema.TableColumn colvarLastName = new TableSchema.TableColumn(schema);
				colvarLastName.ColumnName = "LastName";
				colvarLastName.DataType = DbType.String;
				colvarLastName.MaxLength = 50;
				colvarLastName.AutoIncrement = false;
				colvarLastName.IsNullable = false;
				colvarLastName.IsPrimaryKey = false;
				colvarLastName.IsForeignKey = false;
				colvarLastName.IsReadOnly = false;
				colvarLastName.DefaultSetting = @"";
				colvarLastName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLastName);
				
				TableSchema.TableColumn colvarSuffix = new TableSchema.TableColumn(schema);
				colvarSuffix.ColumnName = "Suffix";
				colvarSuffix.DataType = DbType.String;
				colvarSuffix.MaxLength = 10;
				colvarSuffix.AutoIncrement = false;
				colvarSuffix.IsNullable = true;
				colvarSuffix.IsPrimaryKey = false;
				colvarSuffix.IsForeignKey = false;
				colvarSuffix.IsReadOnly = false;
				colvarSuffix.DefaultSetting = @"";
				colvarSuffix.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSuffix);
				
				TableSchema.TableColumn colvarEmailAddress = new TableSchema.TableColumn(schema);
				colvarEmailAddress.ColumnName = "EmailAddress";
				colvarEmailAddress.DataType = DbType.String;
				colvarEmailAddress.MaxLength = 50;
				colvarEmailAddress.AutoIncrement = false;
				colvarEmailAddress.IsNullable = true;
				colvarEmailAddress.IsPrimaryKey = false;
				colvarEmailAddress.IsForeignKey = false;
				colvarEmailAddress.IsReadOnly = false;
				colvarEmailAddress.DefaultSetting = @"";
				colvarEmailAddress.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEmailAddress);
				
				TableSchema.TableColumn colvarEmailPromotion = new TableSchema.TableColumn(schema);
				colvarEmailPromotion.ColumnName = "EmailPromotion";
				colvarEmailPromotion.DataType = DbType.Int32;
				colvarEmailPromotion.MaxLength = 0;
				colvarEmailPromotion.AutoIncrement = false;
				colvarEmailPromotion.IsNullable = false;
				colvarEmailPromotion.IsPrimaryKey = false;
				colvarEmailPromotion.IsForeignKey = false;
				colvarEmailPromotion.IsReadOnly = false;
				
						colvarEmailPromotion.DefaultSetting = @"((0))";
				colvarEmailPromotion.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEmailPromotion);
				
				TableSchema.TableColumn colvarPhone = new TableSchema.TableColumn(schema);
				colvarPhone.ColumnName = "Phone";
				colvarPhone.DataType = DbType.String;
				colvarPhone.MaxLength = 25;
				colvarPhone.AutoIncrement = false;
				colvarPhone.IsNullable = true;
				colvarPhone.IsPrimaryKey = false;
				colvarPhone.IsForeignKey = false;
				colvarPhone.IsReadOnly = false;
				colvarPhone.DefaultSetting = @"";
				colvarPhone.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPhone);
				
				TableSchema.TableColumn colvarPasswordHash = new TableSchema.TableColumn(schema);
				colvarPasswordHash.ColumnName = "PasswordHash";
				colvarPasswordHash.DataType = DbType.String;
				colvarPasswordHash.MaxLength = 40;
				colvarPasswordHash.AutoIncrement = false;
				colvarPasswordHash.IsNullable = false;
				colvarPasswordHash.IsPrimaryKey = false;
				colvarPasswordHash.IsForeignKey = false;
				colvarPasswordHash.IsReadOnly = false;
				colvarPasswordHash.DefaultSetting = @"";
				colvarPasswordHash.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPasswordHash);
				
				TableSchema.TableColumn colvarPasswordSalt = new TableSchema.TableColumn(schema);
				colvarPasswordSalt.ColumnName = "PasswordSalt";
				colvarPasswordSalt.DataType = DbType.String;
				colvarPasswordSalt.MaxLength = 10;
				colvarPasswordSalt.AutoIncrement = false;
				colvarPasswordSalt.IsNullable = false;
				colvarPasswordSalt.IsPrimaryKey = false;
				colvarPasswordSalt.IsForeignKey = false;
				colvarPasswordSalt.IsReadOnly = false;
				colvarPasswordSalt.DefaultSetting = @"";
				colvarPasswordSalt.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPasswordSalt);
				
				TableSchema.TableColumn colvarAdditionalContactInfo = new TableSchema.TableColumn(schema);
				colvarAdditionalContactInfo.ColumnName = "AdditionalContactInfo";
				colvarAdditionalContactInfo.DataType = DbType.String;
				colvarAdditionalContactInfo.MaxLength = -1;
				colvarAdditionalContactInfo.AutoIncrement = false;
				colvarAdditionalContactInfo.IsNullable = true;
				colvarAdditionalContactInfo.IsPrimaryKey = false;
				colvarAdditionalContactInfo.IsForeignKey = false;
				colvarAdditionalContactInfo.IsReadOnly = false;
				colvarAdditionalContactInfo.DefaultSetting = @"";
				colvarAdditionalContactInfo.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAdditionalContactInfo);
				
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
				DataService.Providers["Default"].AddSchema("Contact",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("ContactID")]
		public int ContactID 
		{
			get { return GetColumnValue<int>(Columns.ContactID); }

			set { SetColumnValue(Columns.ContactID, value); }

		}

		  
		[XmlAttribute("NameStyle")]
		public bool NameStyle 
		{
			get { return GetColumnValue<bool>(Columns.NameStyle); }

			set { SetColumnValue(Columns.NameStyle, value); }

		}

		  
		[XmlAttribute("Title")]
		public string Title 
		{
			get { return GetColumnValue<string>(Columns.Title); }

			set { SetColumnValue(Columns.Title, value); }

		}

		  
		[XmlAttribute("FirstName")]
		public string FirstName 
		{
			get { return GetColumnValue<string>(Columns.FirstName); }

			set { SetColumnValue(Columns.FirstName, value); }

		}

		  
		[XmlAttribute("MiddleName")]
		public string MiddleName 
		{
			get { return GetColumnValue<string>(Columns.MiddleName); }

			set { SetColumnValue(Columns.MiddleName, value); }

		}

		  
		[XmlAttribute("LastName")]
		public string LastName 
		{
			get { return GetColumnValue<string>(Columns.LastName); }

			set { SetColumnValue(Columns.LastName, value); }

		}

		  
		[XmlAttribute("Suffix")]
		public string Suffix 
		{
			get { return GetColumnValue<string>(Columns.Suffix); }

			set { SetColumnValue(Columns.Suffix, value); }

		}

		  
		[XmlAttribute("EmailAddress")]
		public string EmailAddress 
		{
			get { return GetColumnValue<string>(Columns.EmailAddress); }

			set { SetColumnValue(Columns.EmailAddress, value); }

		}

		  
		[XmlAttribute("EmailPromotion")]
		public int EmailPromotion 
		{
			get { return GetColumnValue<int>(Columns.EmailPromotion); }

			set { SetColumnValue(Columns.EmailPromotion, value); }

		}

		  
		[XmlAttribute("Phone")]
		public string Phone 
		{
			get { return GetColumnValue<string>(Columns.Phone); }

			set { SetColumnValue(Columns.Phone, value); }

		}

		  
		[XmlAttribute("PasswordHash")]
		public string PasswordHash 
		{
			get { return GetColumnValue<string>(Columns.PasswordHash); }

			set { SetColumnValue(Columns.PasswordHash, value); }

		}

		  
		[XmlAttribute("PasswordSalt")]
		public string PasswordSalt 
		{
			get { return GetColumnValue<string>(Columns.PasswordSalt); }

			set { SetColumnValue(Columns.PasswordSalt, value); }

		}

		  
		[XmlAttribute("AdditionalContactInfo")]
		public string AdditionalContactInfo 
		{
			get { return GetColumnValue<string>(Columns.AdditionalContactInfo); }

			set { SetColumnValue(Columns.AdditionalContactInfo, value); }

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
		
		public AVManager.DAL.EmployeeCollection EmployeeRecords()
		{
			return new AVManager.DAL.EmployeeCollection().Where(Employee.Columns.ContactID, ContactID).Load();
		}

		public AVManager.DAL.VendorContactCollection VendorContactRecords()
		{
			return new AVManager.DAL.VendorContactCollection().Where(VendorContact.Columns.ContactID, ContactID).Load();
		}

		public AVManager.DAL.ContactCreditCardCollection ContactCreditCardRecords()
		{
			return new AVManager.DAL.ContactCreditCardCollection().Where(ContactCreditCard.Columns.ContactID, ContactID).Load();
		}

		public AVManager.DAL.IndividualCollection IndividualRecords()
		{
			return new AVManager.DAL.IndividualCollection().Where(Individual.Columns.ContactID, ContactID).Load();
		}

		public AVManager.DAL.SalesOrderHeaderCollection SalesOrderHeaderRecords()
		{
			return new AVManager.DAL.SalesOrderHeaderCollection().Where(SalesOrderHeader.Columns.ContactID, ContactID).Load();
		}

		public AVManager.DAL.StoreContactCollection StoreContactRecords()
		{
			return new AVManager.DAL.StoreContactCollection().Where(StoreContact.Columns.ContactID, ContactID).Load();
		}

		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		#region Many To Many Helpers
		
		 
		public AVManager.DAL.ContactTypeCollection GetContactTypeCollection() { return Contact.GetContactTypeCollection(this.ContactID); }

		public static AVManager.DAL.ContactTypeCollection GetContactTypeCollection(int varContactID)
		{
			SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
				"SELECT * FROM ContactType INNER JOIN StoreContact ON "+
				"ContactType.ContactTypeID=StoreContact.ContactTypeID WHERE StoreContact.ContactID=@ContactID", Contact.Schema.Provider.Name);
			
			cmd.AddParameter("@ContactID", varContactID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			ContactTypeCollection coll = new ContactTypeCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}

		
		public static void SaveContactTypeMap(int varContactID, ContactTypeCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM StoreContact WHERE ContactID=@ContactID", Contact.Schema.Provider.Name);
			cmdDel.AddParameter("@ContactID", varContactID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (ContactType item in items)
			{
				StoreContact varStoreContact = new StoreContact();
				varStoreContact.SetColumnValue("ContactID", varContactID);
				varStoreContact.SetColumnValue("ContactTypeID", item.GetPrimaryKeyValue());
				varStoreContact.Save();
			}

		}

		public static void SaveContactTypeMap(int varContactID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM StoreContact WHERE ContactID=@ContactID", Contact.Schema.Provider.Name);
			cmdDel.AddParameter("@ContactID", varContactID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					StoreContact varStoreContact = new StoreContact();
					varStoreContact.SetColumnValue("ContactID", varContactID);
					varStoreContact.SetColumnValue("ContactTypeID", l.Value);
					varStoreContact.Save();
				}

			}

		}

		public static void SaveContactTypeMap(int varContactID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM StoreContact WHERE ContactID=@ContactID", Contact.Schema.Provider.Name);
			cmdDel.AddParameter("@ContactID", varContactID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				StoreContact varStoreContact = new StoreContact();
				varStoreContact.SetColumnValue("ContactID", varContactID);
				varStoreContact.SetColumnValue("ContactTypeID", item);
				varStoreContact.Save();
			}

		}

		
		public static void DeleteContactTypeMap(int varContactID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM StoreContact WHERE ContactID=@ContactID", Contact.Schema.Provider.Name);
			cmdDel.AddParameter("@ContactID", varContactID);
			DataService.ExecuteQuery(cmdDel);
		}

		
		 
		public AVManager.DAL.StoreCollection GetStoreCollection() { return Contact.GetStoreCollection(this.ContactID); }

		public static AVManager.DAL.StoreCollection GetStoreCollection(int varContactID)
		{
			SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
				"SELECT * FROM Store INNER JOIN StoreContact ON "+
				"Store.CustomerID=StoreContact.CustomerID WHERE StoreContact.ContactID=@ContactID", Contact.Schema.Provider.Name);
			
			cmd.AddParameter("@ContactID", varContactID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			StoreCollection coll = new StoreCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}

		
		public static void SaveStoreMap(int varContactID, StoreCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM StoreContact WHERE ContactID=@ContactID", Contact.Schema.Provider.Name);
			cmdDel.AddParameter("@ContactID", varContactID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Store item in items)
			{
				StoreContact varStoreContact = new StoreContact();
				varStoreContact.SetColumnValue("ContactID", varContactID);
				varStoreContact.SetColumnValue("CustomerID", item.GetPrimaryKeyValue());
				varStoreContact.Save();
			}

		}

		public static void SaveStoreMap(int varContactID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM StoreContact WHERE ContactID=@ContactID", Contact.Schema.Provider.Name);
			cmdDel.AddParameter("@ContactID", varContactID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					StoreContact varStoreContact = new StoreContact();
					varStoreContact.SetColumnValue("ContactID", varContactID);
					varStoreContact.SetColumnValue("CustomerID", l.Value);
					varStoreContact.Save();
				}

			}

		}

		public static void SaveStoreMap(int varContactID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM StoreContact WHERE ContactID=@ContactID", Contact.Schema.Provider.Name);
			cmdDel.AddParameter("@ContactID", varContactID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				StoreContact varStoreContact = new StoreContact();
				varStoreContact.SetColumnValue("ContactID", varContactID);
				varStoreContact.SetColumnValue("CustomerID", item);
				varStoreContact.Save();
			}

		}

		
		public static void DeleteStoreMap(int varContactID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM StoreContact WHERE ContactID=@ContactID", Contact.Schema.Provider.Name);
			cmdDel.AddParameter("@ContactID", varContactID);
			DataService.ExecuteQuery(cmdDel);
		}

		
		 
		public AVManager.DAL.VendorCollection GetVendorCollection() { return Contact.GetVendorCollection(this.ContactID); }

		public static AVManager.DAL.VendorCollection GetVendorCollection(int varContactID)
		{
			SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
				"SELECT * FROM Vendor INNER JOIN VendorContact ON "+
				"Vendor.VendorID=VendorContact.VendorID WHERE VendorContact.ContactID=@ContactID", Contact.Schema.Provider.Name);
			
			cmd.AddParameter("@ContactID", varContactID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			VendorCollection coll = new VendorCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}

		
		public static void SaveVendorMap(int varContactID, VendorCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM VendorContact WHERE ContactID=@ContactID", Contact.Schema.Provider.Name);
			cmdDel.AddParameter("@ContactID", varContactID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Vendor item in items)
			{
				VendorContact varVendorContact = new VendorContact();
				varVendorContact.SetColumnValue("ContactID", varContactID);
				varVendorContact.SetColumnValue("VendorID", item.GetPrimaryKeyValue());
				varVendorContact.Save();
			}

		}

		public static void SaveVendorMap(int varContactID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM VendorContact WHERE ContactID=@ContactID", Contact.Schema.Provider.Name);
			cmdDel.AddParameter("@ContactID", varContactID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					VendorContact varVendorContact = new VendorContact();
					varVendorContact.SetColumnValue("ContactID", varContactID);
					varVendorContact.SetColumnValue("VendorID", l.Value);
					varVendorContact.Save();
				}

			}

		}

		public static void SaveVendorMap(int varContactID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM VendorContact WHERE ContactID=@ContactID", Contact.Schema.Provider.Name);
			cmdDel.AddParameter("@ContactID", varContactID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				VendorContact varVendorContact = new VendorContact();
				varVendorContact.SetColumnValue("ContactID", varContactID);
				varVendorContact.SetColumnValue("VendorID", item);
				varVendorContact.Save();
			}

		}

		
		public static void DeleteVendorMap(int varContactID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM VendorContact WHERE ContactID=@ContactID", Contact.Schema.Provider.Name);
			cmdDel.AddParameter("@ContactID", varContactID);
			DataService.ExecuteQuery(cmdDel);
		}

		
		 
		public AVManager.DAL.CreditCardCollection GetCreditCardCollection() { return Contact.GetCreditCardCollection(this.ContactID); }

		public static AVManager.DAL.CreditCardCollection GetCreditCardCollection(int varContactID)
		{
			SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
				"SELECT * FROM CreditCard INNER JOIN ContactCreditCard ON "+
				"CreditCard.CreditCardID=ContactCreditCard.CreditCardID WHERE ContactCreditCard.ContactID=@ContactID", Contact.Schema.Provider.Name);
			
			cmd.AddParameter("@ContactID", varContactID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			CreditCardCollection coll = new CreditCardCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}

		
		public static void SaveCreditCardMap(int varContactID, CreditCardCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM ContactCreditCard WHERE ContactID=@ContactID", Contact.Schema.Provider.Name);
			cmdDel.AddParameter("@ContactID", varContactID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (CreditCard item in items)
			{
				ContactCreditCard varContactCreditCard = new ContactCreditCard();
				varContactCreditCard.SetColumnValue("ContactID", varContactID);
				varContactCreditCard.SetColumnValue("CreditCardID", item.GetPrimaryKeyValue());
				varContactCreditCard.Save();
			}

		}

		public static void SaveCreditCardMap(int varContactID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM ContactCreditCard WHERE ContactID=@ContactID", Contact.Schema.Provider.Name);
			cmdDel.AddParameter("@ContactID", varContactID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					ContactCreditCard varContactCreditCard = new ContactCreditCard();
					varContactCreditCard.SetColumnValue("ContactID", varContactID);
					varContactCreditCard.SetColumnValue("CreditCardID", l.Value);
					varContactCreditCard.Save();
				}

			}

		}

		public static void SaveCreditCardMap(int varContactID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM ContactCreditCard WHERE ContactID=@ContactID", Contact.Schema.Provider.Name);
			cmdDel.AddParameter("@ContactID", varContactID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				ContactCreditCard varContactCreditCard = new ContactCreditCard();
				varContactCreditCard.SetColumnValue("ContactID", varContactID);
				varContactCreditCard.SetColumnValue("CreditCardID", item);
				varContactCreditCard.Save();
			}

		}

		
		public static void DeleteCreditCardMap(int varContactID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM ContactCreditCard WHERE ContactID=@ContactID", Contact.Schema.Provider.Name);
			cmdDel.AddParameter("@ContactID", varContactID);
			DataService.ExecuteQuery(cmdDel);
		}

		
		#endregion
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(bool varNameStyle,string varTitle,string varFirstName,string varMiddleName,string varLastName,string varSuffix,string varEmailAddress,int varEmailPromotion,string varPhone,string varPasswordHash,string varPasswordSalt,string varAdditionalContactInfo,Guid varRowguid,DateTime varModifiedDate)
		{
			Contact item = new Contact();
			
			item.NameStyle = varNameStyle;
			
			item.Title = varTitle;
			
			item.FirstName = varFirstName;
			
			item.MiddleName = varMiddleName;
			
			item.LastName = varLastName;
			
			item.Suffix = varSuffix;
			
			item.EmailAddress = varEmailAddress;
			
			item.EmailPromotion = varEmailPromotion;
			
			item.Phone = varPhone;
			
			item.PasswordHash = varPasswordHash;
			
			item.PasswordSalt = varPasswordSalt;
			
			item.AdditionalContactInfo = varAdditionalContactInfo;
			
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
		public static void Update(int varContactID,bool varNameStyle,string varTitle,string varFirstName,string varMiddleName,string varLastName,string varSuffix,string varEmailAddress,int varEmailPromotion,string varPhone,string varPasswordHash,string varPasswordSalt,string varAdditionalContactInfo,Guid varRowguid,DateTime varModifiedDate)
		{
			Contact item = new Contact();
			
				item.ContactID = varContactID;
			
				item.NameStyle = varNameStyle;
			
				item.Title = varTitle;
			
				item.FirstName = varFirstName;
			
				item.MiddleName = varMiddleName;
			
				item.LastName = varLastName;
			
				item.Suffix = varSuffix;
			
				item.EmailAddress = varEmailAddress;
			
				item.EmailPromotion = varEmailPromotion;
			
				item.Phone = varPhone;
			
				item.PasswordHash = varPasswordHash;
			
				item.PasswordSalt = varPasswordSalt;
			
				item.AdditionalContactInfo = varAdditionalContactInfo;
			
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
			 public static string ContactID = @"ContactID";
			 public static string NameStyle = @"NameStyle";
			 public static string Title = @"Title";
			 public static string FirstName = @"FirstName";
			 public static string MiddleName = @"MiddleName";
			 public static string LastName = @"LastName";
			 public static string Suffix = @"Suffix";
			 public static string EmailAddress = @"EmailAddress";
			 public static string EmailPromotion = @"EmailPromotion";
			 public static string Phone = @"Phone";
			 public static string PasswordHash = @"PasswordHash";
			 public static string PasswordSalt = @"PasswordSalt";
			 public static string AdditionalContactInfo = @"AdditionalContactInfo";
			 public static string Rowguid = @"rowguid";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}

		#endregion
	}

}

