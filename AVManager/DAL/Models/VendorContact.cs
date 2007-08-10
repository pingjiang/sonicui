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
	/// Strongly-typed collection for the VendorContact class.
	/// </summary>
	[Serializable]
	public partial class VendorContactCollection : ActiveList<VendorContact, VendorContactCollection> 
	{	   
		public VendorContactCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the VendorContact table.
	/// </summary>
	[Serializable]
	public partial class VendorContact : ActiveRecord<VendorContact>
	{
		#region .ctors and Default Settings
		
		public VendorContact()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public VendorContact(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public VendorContact(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public VendorContact(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("VendorContact", TableType.Table, DataService.GetInstance("Default"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Purchasing";
				//columns
				
				TableSchema.TableColumn colvarVendorID = new TableSchema.TableColumn(schema);
				colvarVendorID.ColumnName = "VendorID";
				colvarVendorID.DataType = DbType.Int32;
				colvarVendorID.MaxLength = 0;
				colvarVendorID.AutoIncrement = false;
				colvarVendorID.IsNullable = false;
				colvarVendorID.IsPrimaryKey = true;
				colvarVendorID.IsForeignKey = true;
				colvarVendorID.IsReadOnly = false;
				colvarVendorID.DefaultSetting = @"";
				
					colvarVendorID.ForeignKeyTableName = "Vendor";
				schema.Columns.Add(colvarVendorID);
				
				TableSchema.TableColumn colvarContactID = new TableSchema.TableColumn(schema);
				colvarContactID.ColumnName = "ContactID";
				colvarContactID.DataType = DbType.Int32;
				colvarContactID.MaxLength = 0;
				colvarContactID.AutoIncrement = false;
				colvarContactID.IsNullable = false;
				colvarContactID.IsPrimaryKey = true;
				colvarContactID.IsForeignKey = true;
				colvarContactID.IsReadOnly = false;
				colvarContactID.DefaultSetting = @"";
				
					colvarContactID.ForeignKeyTableName = "Contact";
				schema.Columns.Add(colvarContactID);
				
				TableSchema.TableColumn colvarContactTypeID = new TableSchema.TableColumn(schema);
				colvarContactTypeID.ColumnName = "ContactTypeID";
				colvarContactTypeID.DataType = DbType.Int32;
				colvarContactTypeID.MaxLength = 0;
				colvarContactTypeID.AutoIncrement = false;
				colvarContactTypeID.IsNullable = false;
				colvarContactTypeID.IsPrimaryKey = false;
				colvarContactTypeID.IsForeignKey = true;
				colvarContactTypeID.IsReadOnly = false;
				colvarContactTypeID.DefaultSetting = @"";
				
					colvarContactTypeID.ForeignKeyTableName = "ContactType";
				schema.Columns.Add(colvarContactTypeID);
				
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
				DataService.Providers["Default"].AddSchema("VendorContact",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("VendorID")]
		public int VendorID 
		{
			get { return GetColumnValue<int>(Columns.VendorID); }

			set { SetColumnValue(Columns.VendorID, value); }

		}

		  
		[XmlAttribute("ContactID")]
		public int ContactID 
		{
			get { return GetColumnValue<int>(Columns.ContactID); }

			set { SetColumnValue(Columns.ContactID, value); }

		}

		  
		[XmlAttribute("ContactTypeID")]
		public int ContactTypeID 
		{
			get { return GetColumnValue<int>(Columns.ContactTypeID); }

			set { SetColumnValue(Columns.ContactTypeID, value); }

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
		/// Returns a Contact ActiveRecord object related to this VendorContact
		/// 
		/// </summary>
		public AVManager.DAL.Contact Contact
		{
			get { return AVManager.DAL.Contact.FetchByID(this.ContactID); }

			set { SetColumnValue("ContactID", value.ContactID); }

		}

		
		
		/// <summary>
		/// Returns a ContactType ActiveRecord object related to this VendorContact
		/// 
		/// </summary>
		public AVManager.DAL.ContactType ContactType
		{
			get { return AVManager.DAL.ContactType.FetchByID(this.ContactTypeID); }

			set { SetColumnValue("ContactTypeID", value.ContactTypeID); }

		}

		
		
		/// <summary>
		/// Returns a Vendor ActiveRecord object related to this VendorContact
		/// 
		/// </summary>
		public AVManager.DAL.Vendor Vendor
		{
			get { return AVManager.DAL.Vendor.FetchByID(this.VendorID); }

			set { SetColumnValue("VendorID", value.VendorID); }

		}

		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varVendorID,int varContactID,int varContactTypeID,DateTime varModifiedDate)
		{
			VendorContact item = new VendorContact();
			
			item.VendorID = varVendorID;
			
			item.ContactID = varContactID;
			
			item.ContactTypeID = varContactTypeID;
			
			item.ModifiedDate = varModifiedDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varVendorID,int varContactID,int varContactTypeID,DateTime varModifiedDate)
		{
			VendorContact item = new VendorContact();
			
				item.VendorID = varVendorID;
			
				item.ContactID = varContactID;
			
				item.ContactTypeID = varContactTypeID;
			
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
			 public static string VendorID = @"VendorID";
			 public static string ContactID = @"ContactID";
			 public static string ContactTypeID = @"ContactTypeID";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}

		#endregion
	}

}

