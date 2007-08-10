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
	/// Strongly-typed collection for the ContactCreditCard class.
	/// </summary>
	[Serializable]
	public partial class ContactCreditCardCollection : ActiveList<ContactCreditCard, ContactCreditCardCollection> 
	{	   
		public ContactCreditCardCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the ContactCreditCard table.
	/// </summary>
	[Serializable]
	public partial class ContactCreditCard : ActiveRecord<ContactCreditCard>
	{
		#region .ctors and Default Settings
		
		public ContactCreditCard()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public ContactCreditCard(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public ContactCreditCard(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public ContactCreditCard(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("ContactCreditCard", TableType.Table, DataService.GetInstance("Default"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Sales";
				//columns
				
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
				
				TableSchema.TableColumn colvarCreditCardID = new TableSchema.TableColumn(schema);
				colvarCreditCardID.ColumnName = "CreditCardID";
				colvarCreditCardID.DataType = DbType.Int32;
				colvarCreditCardID.MaxLength = 0;
				colvarCreditCardID.AutoIncrement = false;
				colvarCreditCardID.IsNullable = false;
				colvarCreditCardID.IsPrimaryKey = true;
				colvarCreditCardID.IsForeignKey = true;
				colvarCreditCardID.IsReadOnly = false;
				colvarCreditCardID.DefaultSetting = @"";
				
					colvarCreditCardID.ForeignKeyTableName = "CreditCard";
				schema.Columns.Add(colvarCreditCardID);
				
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
				DataService.Providers["Default"].AddSchema("ContactCreditCard",schema);
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

		  
		[XmlAttribute("CreditCardID")]
		public int CreditCardID 
		{
			get { return GetColumnValue<int>(Columns.CreditCardID); }

			set { SetColumnValue(Columns.CreditCardID, value); }

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
		/// Returns a Contact ActiveRecord object related to this ContactCreditCard
		/// 
		/// </summary>
		public AVManager.DAL.Contact Contact
		{
			get { return AVManager.DAL.Contact.FetchByID(this.ContactID); }

			set { SetColumnValue("ContactID", value.ContactID); }

		}

		
		
		/// <summary>
		/// Returns a CreditCard ActiveRecord object related to this ContactCreditCard
		/// 
		/// </summary>
		public AVManager.DAL.CreditCard CreditCard
		{
			get { return AVManager.DAL.CreditCard.FetchByID(this.CreditCardID); }

			set { SetColumnValue("CreditCardID", value.CreditCardID); }

		}

		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varContactID,int varCreditCardID,DateTime varModifiedDate)
		{
			ContactCreditCard item = new ContactCreditCard();
			
			item.ContactID = varContactID;
			
			item.CreditCardID = varCreditCardID;
			
			item.ModifiedDate = varModifiedDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varContactID,int varCreditCardID,DateTime varModifiedDate)
		{
			ContactCreditCard item = new ContactCreditCard();
			
				item.ContactID = varContactID;
			
				item.CreditCardID = varCreditCardID;
			
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
			 public static string CreditCardID = @"CreditCardID";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}

		#endregion
	}

}

