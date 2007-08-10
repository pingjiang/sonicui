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
	/// Strongly-typed collection for the CurrencyRate class.
	/// </summary>
	[Serializable]
	public partial class CurrencyRateCollection : ActiveList<CurrencyRate, CurrencyRateCollection> 
	{	   
		public CurrencyRateCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the CurrencyRate table.
	/// </summary>
	[Serializable]
	public partial class CurrencyRate : ActiveRecord<CurrencyRate>
	{
		#region .ctors and Default Settings
		
		public CurrencyRate()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public CurrencyRate(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public CurrencyRate(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public CurrencyRate(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("CurrencyRate", TableType.Table, DataService.GetInstance("Default"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Sales";
				//columns
				
				TableSchema.TableColumn colvarCurrencyRateID = new TableSchema.TableColumn(schema);
				colvarCurrencyRateID.ColumnName = "CurrencyRateID";
				colvarCurrencyRateID.DataType = DbType.Int32;
				colvarCurrencyRateID.MaxLength = 0;
				colvarCurrencyRateID.AutoIncrement = true;
				colvarCurrencyRateID.IsNullable = false;
				colvarCurrencyRateID.IsPrimaryKey = true;
				colvarCurrencyRateID.IsForeignKey = false;
				colvarCurrencyRateID.IsReadOnly = false;
				colvarCurrencyRateID.DefaultSetting = @"";
				colvarCurrencyRateID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCurrencyRateID);
				
				TableSchema.TableColumn colvarCurrencyRateDate = new TableSchema.TableColumn(schema);
				colvarCurrencyRateDate.ColumnName = "CurrencyRateDate";
				colvarCurrencyRateDate.DataType = DbType.DateTime;
				colvarCurrencyRateDate.MaxLength = 0;
				colvarCurrencyRateDate.AutoIncrement = false;
				colvarCurrencyRateDate.IsNullable = false;
				colvarCurrencyRateDate.IsPrimaryKey = false;
				colvarCurrencyRateDate.IsForeignKey = false;
				colvarCurrencyRateDate.IsReadOnly = false;
				colvarCurrencyRateDate.DefaultSetting = @"";
				colvarCurrencyRateDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCurrencyRateDate);
				
				TableSchema.TableColumn colvarFromCurrencyCode = new TableSchema.TableColumn(schema);
				colvarFromCurrencyCode.ColumnName = "FromCurrencyCode";
				colvarFromCurrencyCode.DataType = DbType.String;
				colvarFromCurrencyCode.MaxLength = 3;
				colvarFromCurrencyCode.AutoIncrement = false;
				colvarFromCurrencyCode.IsNullable = false;
				colvarFromCurrencyCode.IsPrimaryKey = false;
				colvarFromCurrencyCode.IsForeignKey = true;
				colvarFromCurrencyCode.IsReadOnly = false;
				colvarFromCurrencyCode.DefaultSetting = @"";
				
					colvarFromCurrencyCode.ForeignKeyTableName = "Currency";
				schema.Columns.Add(colvarFromCurrencyCode);
				
				TableSchema.TableColumn colvarToCurrencyCode = new TableSchema.TableColumn(schema);
				colvarToCurrencyCode.ColumnName = "ToCurrencyCode";
				colvarToCurrencyCode.DataType = DbType.String;
				colvarToCurrencyCode.MaxLength = 3;
				colvarToCurrencyCode.AutoIncrement = false;
				colvarToCurrencyCode.IsNullable = false;
				colvarToCurrencyCode.IsPrimaryKey = false;
				colvarToCurrencyCode.IsForeignKey = true;
				colvarToCurrencyCode.IsReadOnly = false;
				colvarToCurrencyCode.DefaultSetting = @"";
				
					colvarToCurrencyCode.ForeignKeyTableName = "Currency";
				schema.Columns.Add(colvarToCurrencyCode);
				
				TableSchema.TableColumn colvarAverageRate = new TableSchema.TableColumn(schema);
				colvarAverageRate.ColumnName = "AverageRate";
				colvarAverageRate.DataType = DbType.Currency;
				colvarAverageRate.MaxLength = 0;
				colvarAverageRate.AutoIncrement = false;
				colvarAverageRate.IsNullable = false;
				colvarAverageRate.IsPrimaryKey = false;
				colvarAverageRate.IsForeignKey = false;
				colvarAverageRate.IsReadOnly = false;
				colvarAverageRate.DefaultSetting = @"";
				colvarAverageRate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarAverageRate);
				
				TableSchema.TableColumn colvarEndOfDayRate = new TableSchema.TableColumn(schema);
				colvarEndOfDayRate.ColumnName = "EndOfDayRate";
				colvarEndOfDayRate.DataType = DbType.Currency;
				colvarEndOfDayRate.MaxLength = 0;
				colvarEndOfDayRate.AutoIncrement = false;
				colvarEndOfDayRate.IsNullable = false;
				colvarEndOfDayRate.IsPrimaryKey = false;
				colvarEndOfDayRate.IsForeignKey = false;
				colvarEndOfDayRate.IsReadOnly = false;
				colvarEndOfDayRate.DefaultSetting = @"";
				colvarEndOfDayRate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEndOfDayRate);
				
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
				DataService.Providers["Default"].AddSchema("CurrencyRate",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("CurrencyRateID")]
		public int CurrencyRateID 
		{
			get { return GetColumnValue<int>(Columns.CurrencyRateID); }

			set { SetColumnValue(Columns.CurrencyRateID, value); }

		}

		  
		[XmlAttribute("CurrencyRateDate")]
		public DateTime CurrencyRateDate 
		{
			get { return GetColumnValue<DateTime>(Columns.CurrencyRateDate); }

			set { SetColumnValue(Columns.CurrencyRateDate, value); }

		}

		  
		[XmlAttribute("FromCurrencyCode")]
		public string FromCurrencyCode 
		{
			get { return GetColumnValue<string>(Columns.FromCurrencyCode); }

			set { SetColumnValue(Columns.FromCurrencyCode, value); }

		}

		  
		[XmlAttribute("ToCurrencyCode")]
		public string ToCurrencyCode 
		{
			get { return GetColumnValue<string>(Columns.ToCurrencyCode); }

			set { SetColumnValue(Columns.ToCurrencyCode, value); }

		}

		  
		[XmlAttribute("AverageRate")]
		public decimal AverageRate 
		{
			get { return GetColumnValue<decimal>(Columns.AverageRate); }

			set { SetColumnValue(Columns.AverageRate, value); }

		}

		  
		[XmlAttribute("EndOfDayRate")]
		public decimal EndOfDayRate 
		{
			get { return GetColumnValue<decimal>(Columns.EndOfDayRate); }

			set { SetColumnValue(Columns.EndOfDayRate, value); }

		}

		  
		[XmlAttribute("ModifiedDate")]
		public DateTime ModifiedDate 
		{
			get { return GetColumnValue<DateTime>(Columns.ModifiedDate); }

			set { SetColumnValue(Columns.ModifiedDate, value); }

		}

		
		#endregion
		
		
		#region PrimaryKey Methods
		
		public AVManager.DAL.SalesOrderHeaderCollection SalesOrderHeaderRecords()
		{
			return new AVManager.DAL.SalesOrderHeaderCollection().Where(SalesOrderHeader.Columns.CurrencyRateID, CurrencyRateID).Load();
		}

		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Currency ActiveRecord object related to this CurrencyRate
		/// 
		/// </summary>
		public AVManager.DAL.Currency Currency
		{
			get { return AVManager.DAL.Currency.FetchByID(this.FromCurrencyCode); }

			set { SetColumnValue("FromCurrencyCode", value.CurrencyCode); }

		}

		
		
		/// <summary>
		/// Returns a Currency ActiveRecord object related to this CurrencyRate
		/// 
		/// </summary>
		public AVManager.DAL.Currency CurrencyToToCurrencyCode
		{
			get { return AVManager.DAL.Currency.FetchByID(this.ToCurrencyCode); }

			set { SetColumnValue("ToCurrencyCode", value.CurrencyCode); }

		}

		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(DateTime varCurrencyRateDate,string varFromCurrencyCode,string varToCurrencyCode,decimal varAverageRate,decimal varEndOfDayRate,DateTime varModifiedDate)
		{
			CurrencyRate item = new CurrencyRate();
			
			item.CurrencyRateDate = varCurrencyRateDate;
			
			item.FromCurrencyCode = varFromCurrencyCode;
			
			item.ToCurrencyCode = varToCurrencyCode;
			
			item.AverageRate = varAverageRate;
			
			item.EndOfDayRate = varEndOfDayRate;
			
			item.ModifiedDate = varModifiedDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varCurrencyRateID,DateTime varCurrencyRateDate,string varFromCurrencyCode,string varToCurrencyCode,decimal varAverageRate,decimal varEndOfDayRate,DateTime varModifiedDate)
		{
			CurrencyRate item = new CurrencyRate();
			
				item.CurrencyRateID = varCurrencyRateID;
			
				item.CurrencyRateDate = varCurrencyRateDate;
			
				item.FromCurrencyCode = varFromCurrencyCode;
			
				item.ToCurrencyCode = varToCurrencyCode;
			
				item.AverageRate = varAverageRate;
			
				item.EndOfDayRate = varEndOfDayRate;
			
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
			 public static string CurrencyRateID = @"CurrencyRateID";
			 public static string CurrencyRateDate = @"CurrencyRateDate";
			 public static string FromCurrencyCode = @"FromCurrencyCode";
			 public static string ToCurrencyCode = @"ToCurrencyCode";
			 public static string AverageRate = @"AverageRate";
			 public static string EndOfDayRate = @"EndOfDayRate";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}

		#endregion
	}

}

