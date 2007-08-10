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
	/// Strongly-typed collection for the CustomerAddress class.
	/// </summary>
	[Serializable]
	public partial class CustomerAddressCollection : ActiveList<CustomerAddress, CustomerAddressCollection> 
	{	   
		public CustomerAddressCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the CustomerAddress table.
	/// </summary>
	[Serializable]
	public partial class CustomerAddress : ActiveRecord<CustomerAddress>
	{
		#region .ctors and Default Settings
		
		public CustomerAddress()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public CustomerAddress(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public CustomerAddress(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public CustomerAddress(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("CustomerAddress", TableType.Table, DataService.GetInstance("Default"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Sales";
				//columns
				
				TableSchema.TableColumn colvarCustomerID = new TableSchema.TableColumn(schema);
				colvarCustomerID.ColumnName = "CustomerID";
				colvarCustomerID.DataType = DbType.Int32;
				colvarCustomerID.MaxLength = 0;
				colvarCustomerID.AutoIncrement = false;
				colvarCustomerID.IsNullable = false;
				colvarCustomerID.IsPrimaryKey = true;
				colvarCustomerID.IsForeignKey = true;
				colvarCustomerID.IsReadOnly = false;
				colvarCustomerID.DefaultSetting = @"";
				
					colvarCustomerID.ForeignKeyTableName = "Customer";
				schema.Columns.Add(colvarCustomerID);
				
				TableSchema.TableColumn colvarAddressID = new TableSchema.TableColumn(schema);
				colvarAddressID.ColumnName = "AddressID";
				colvarAddressID.DataType = DbType.Int32;
				colvarAddressID.MaxLength = 0;
				colvarAddressID.AutoIncrement = false;
				colvarAddressID.IsNullable = false;
				colvarAddressID.IsPrimaryKey = true;
				colvarAddressID.IsForeignKey = true;
				colvarAddressID.IsReadOnly = false;
				colvarAddressID.DefaultSetting = @"";
				
					colvarAddressID.ForeignKeyTableName = "Address";
				schema.Columns.Add(colvarAddressID);
				
				TableSchema.TableColumn colvarAddressTypeID = new TableSchema.TableColumn(schema);
				colvarAddressTypeID.ColumnName = "AddressTypeID";
				colvarAddressTypeID.DataType = DbType.Int32;
				colvarAddressTypeID.MaxLength = 0;
				colvarAddressTypeID.AutoIncrement = false;
				colvarAddressTypeID.IsNullable = false;
				colvarAddressTypeID.IsPrimaryKey = false;
				colvarAddressTypeID.IsForeignKey = true;
				colvarAddressTypeID.IsReadOnly = false;
				colvarAddressTypeID.DefaultSetting = @"";
				
					colvarAddressTypeID.ForeignKeyTableName = "AddressType";
				schema.Columns.Add(colvarAddressTypeID);
				
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
				DataService.Providers["Default"].AddSchema("CustomerAddress",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("CustomerID")]
		public int CustomerID 
		{
			get { return GetColumnValue<int>(Columns.CustomerID); }

			set { SetColumnValue(Columns.CustomerID, value); }

		}

		  
		[XmlAttribute("AddressID")]
		public int AddressID 
		{
			get { return GetColumnValue<int>(Columns.AddressID); }

			set { SetColumnValue(Columns.AddressID, value); }

		}

		  
		[XmlAttribute("AddressTypeID")]
		public int AddressTypeID 
		{
			get { return GetColumnValue<int>(Columns.AddressTypeID); }

			set { SetColumnValue(Columns.AddressTypeID, value); }

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
		
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Address ActiveRecord object related to this CustomerAddress
		/// 
		/// </summary>
		public AVManager.DAL.Address Address
		{
			get { return AVManager.DAL.Address.FetchByID(this.AddressID); }

			set { SetColumnValue("AddressID", value.AddressID); }

		}

		
		
		/// <summary>
		/// Returns a AddressType ActiveRecord object related to this CustomerAddress
		/// 
		/// </summary>
		public AVManager.DAL.AddressType AddressType
		{
			get { return AVManager.DAL.AddressType.FetchByID(this.AddressTypeID); }

			set { SetColumnValue("AddressTypeID", value.AddressTypeID); }

		}

		
		
		/// <summary>
		/// Returns a Customer ActiveRecord object related to this CustomerAddress
		/// 
		/// </summary>
		public AVManager.DAL.Customer Customer
		{
			get { return AVManager.DAL.Customer.FetchByID(this.CustomerID); }

			set { SetColumnValue("CustomerID", value.CustomerID); }

		}

		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varCustomerID,int varAddressID,int varAddressTypeID,Guid varRowguid,DateTime varModifiedDate)
		{
			CustomerAddress item = new CustomerAddress();
			
			item.CustomerID = varCustomerID;
			
			item.AddressID = varAddressID;
			
			item.AddressTypeID = varAddressTypeID;
			
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
		public static void Update(int varCustomerID,int varAddressID,int varAddressTypeID,Guid varRowguid,DateTime varModifiedDate)
		{
			CustomerAddress item = new CustomerAddress();
			
				item.CustomerID = varCustomerID;
			
				item.AddressID = varAddressID;
			
				item.AddressTypeID = varAddressTypeID;
			
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
			 public static string CustomerID = @"CustomerID";
			 public static string AddressID = @"AddressID";
			 public static string AddressTypeID = @"AddressTypeID";
			 public static string Rowguid = @"rowguid";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}

		#endregion
	}

}

