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
	/// Strongly-typed collection for the Individual class.
	/// </summary>
	[Serializable]
	public partial class IndividualCollection : ActiveList<Individual, IndividualCollection> 
	{	   
		public IndividualCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the Individual table.
	/// </summary>
	[Serializable]
	public partial class Individual : ActiveRecord<Individual>
	{
		#region .ctors and Default Settings
		
		public Individual()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public Individual(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public Individual(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public Individual(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Individual", TableType.Table, DataService.GetInstance("Default"));
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
				
				TableSchema.TableColumn colvarContactID = new TableSchema.TableColumn(schema);
				colvarContactID.ColumnName = "ContactID";
				colvarContactID.DataType = DbType.Int32;
				colvarContactID.MaxLength = 0;
				colvarContactID.AutoIncrement = false;
				colvarContactID.IsNullable = false;
				colvarContactID.IsPrimaryKey = false;
				colvarContactID.IsForeignKey = true;
				colvarContactID.IsReadOnly = false;
				colvarContactID.DefaultSetting = @"";
				
					colvarContactID.ForeignKeyTableName = "Contact";
				schema.Columns.Add(colvarContactID);
				
				TableSchema.TableColumn colvarDemographics = new TableSchema.TableColumn(schema);
				colvarDemographics.ColumnName = "Demographics";
				colvarDemographics.DataType = DbType.String;
				colvarDemographics.MaxLength = -1;
				colvarDemographics.AutoIncrement = false;
				colvarDemographics.IsNullable = true;
				colvarDemographics.IsPrimaryKey = false;
				colvarDemographics.IsForeignKey = false;
				colvarDemographics.IsReadOnly = false;
				colvarDemographics.DefaultSetting = @"";
				colvarDemographics.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDemographics);
				
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
				DataService.Providers["Default"].AddSchema("Individual",schema);
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

		  
		[XmlAttribute("ContactID")]
		public int ContactID 
		{
			get { return GetColumnValue<int>(Columns.ContactID); }

			set { SetColumnValue(Columns.ContactID, value); }

		}

		  
		[XmlAttribute("Demographics")]
		public string Demographics 
		{
			get { return GetColumnValue<string>(Columns.Demographics); }

			set { SetColumnValue(Columns.Demographics, value); }

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
		/// Returns a Contact ActiveRecord object related to this Individual
		/// 
		/// </summary>
		public AVManager.DAL.Contact Contact
		{
			get { return AVManager.DAL.Contact.FetchByID(this.ContactID); }

			set { SetColumnValue("ContactID", value.ContactID); }

		}

		
		
		/// <summary>
		/// Returns a Customer ActiveRecord object related to this Individual
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
		public static void Insert(int varCustomerID,int varContactID,string varDemographics,DateTime varModifiedDate)
		{
			Individual item = new Individual();
			
			item.CustomerID = varCustomerID;
			
			item.ContactID = varContactID;
			
			item.Demographics = varDemographics;
			
			item.ModifiedDate = varModifiedDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varCustomerID,int varContactID,string varDemographics,DateTime varModifiedDate)
		{
			Individual item = new Individual();
			
				item.CustomerID = varCustomerID;
			
				item.ContactID = varContactID;
			
				item.Demographics = varDemographics;
			
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
			 public static string ContactID = @"ContactID";
			 public static string Demographics = @"Demographics";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}

		#endregion
	}

}

