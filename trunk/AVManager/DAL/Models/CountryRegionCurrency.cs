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
	/// Strongly-typed collection for the CountryRegionCurrency class.
	/// </summary>
	[Serializable]
	public partial class CountryRegionCurrencyCollection : ActiveList<CountryRegionCurrency, CountryRegionCurrencyCollection> 
	{	   
		public CountryRegionCurrencyCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the CountryRegionCurrency table.
	/// </summary>
	[Serializable]
	public partial class CountryRegionCurrency : ActiveRecord<CountryRegionCurrency>
	{
		#region .ctors and Default Settings
		
		public CountryRegionCurrency()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public CountryRegionCurrency(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public CountryRegionCurrency(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public CountryRegionCurrency(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("CountryRegionCurrency", TableType.Table, DataService.GetInstance("Default"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Sales";
				//columns
				
				TableSchema.TableColumn colvarCountryRegionCode = new TableSchema.TableColumn(schema);
				colvarCountryRegionCode.ColumnName = "CountryRegionCode";
				colvarCountryRegionCode.DataType = DbType.String;
				colvarCountryRegionCode.MaxLength = 3;
				colvarCountryRegionCode.AutoIncrement = false;
				colvarCountryRegionCode.IsNullable = false;
				colvarCountryRegionCode.IsPrimaryKey = true;
				colvarCountryRegionCode.IsForeignKey = true;
				colvarCountryRegionCode.IsReadOnly = false;
				colvarCountryRegionCode.DefaultSetting = @"";
				
					colvarCountryRegionCode.ForeignKeyTableName = "CountryRegion";
				schema.Columns.Add(colvarCountryRegionCode);
				
				TableSchema.TableColumn colvarCurrencyCode = new TableSchema.TableColumn(schema);
				colvarCurrencyCode.ColumnName = "CurrencyCode";
				colvarCurrencyCode.DataType = DbType.String;
				colvarCurrencyCode.MaxLength = 3;
				colvarCurrencyCode.AutoIncrement = false;
				colvarCurrencyCode.IsNullable = false;
				colvarCurrencyCode.IsPrimaryKey = true;
				colvarCurrencyCode.IsForeignKey = true;
				colvarCurrencyCode.IsReadOnly = false;
				colvarCurrencyCode.DefaultSetting = @"";
				
					colvarCurrencyCode.ForeignKeyTableName = "Currency";
				schema.Columns.Add(colvarCurrencyCode);
				
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
				DataService.Providers["Default"].AddSchema("CountryRegionCurrency",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("CountryRegionCode")]
		public string CountryRegionCode 
		{
			get { return GetColumnValue<string>(Columns.CountryRegionCode); }

			set { SetColumnValue(Columns.CountryRegionCode, value); }

		}

		  
		[XmlAttribute("CurrencyCode")]
		public string CurrencyCode 
		{
			get { return GetColumnValue<string>(Columns.CurrencyCode); }

			set { SetColumnValue(Columns.CurrencyCode, value); }

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
		/// Returns a CountryRegion ActiveRecord object related to this CountryRegionCurrency
		/// 
		/// </summary>
		public AVManager.DAL.CountryRegion CountryRegion
		{
			get { return AVManager.DAL.CountryRegion.FetchByID(this.CountryRegionCode); }

			set { SetColumnValue("CountryRegionCode", value.CountryRegionCode); }

		}

		
		
		/// <summary>
		/// Returns a Currency ActiveRecord object related to this CountryRegionCurrency
		/// 
		/// </summary>
		public AVManager.DAL.Currency Currency
		{
			get { return AVManager.DAL.Currency.FetchByID(this.CurrencyCode); }

			set { SetColumnValue("CurrencyCode", value.CurrencyCode); }

		}

		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varCountryRegionCode,string varCurrencyCode,DateTime varModifiedDate)
		{
			CountryRegionCurrency item = new CountryRegionCurrency();
			
			item.CountryRegionCode = varCountryRegionCode;
			
			item.CurrencyCode = varCurrencyCode;
			
			item.ModifiedDate = varModifiedDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(string varCountryRegionCode,string varCurrencyCode,DateTime varModifiedDate)
		{
			CountryRegionCurrency item = new CountryRegionCurrency();
			
				item.CountryRegionCode = varCountryRegionCode;
			
				item.CurrencyCode = varCurrencyCode;
			
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
			 public static string CountryRegionCode = @"CountryRegionCode";
			 public static string CurrencyCode = @"CurrencyCode";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}

		#endregion
	}

}

