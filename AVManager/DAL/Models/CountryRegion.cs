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
	/// Strongly-typed collection for the CountryRegion class.
	/// </summary>
	[Serializable]
	public partial class CountryRegionCollection : ActiveList<CountryRegion, CountryRegionCollection> 
	{	   
		public CountryRegionCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the CountryRegion table.
	/// </summary>
	[Serializable]
	public partial class CountryRegion : ActiveRecord<CountryRegion>
	{
		#region .ctors and Default Settings
		
		public CountryRegion()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public CountryRegion(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public CountryRegion(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public CountryRegion(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("CountryRegion", TableType.Table, DataService.GetInstance("Default"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Person";
				//columns
				
				TableSchema.TableColumn colvarCountryRegionCode = new TableSchema.TableColumn(schema);
				colvarCountryRegionCode.ColumnName = "CountryRegionCode";
				colvarCountryRegionCode.DataType = DbType.String;
				colvarCountryRegionCode.MaxLength = 3;
				colvarCountryRegionCode.AutoIncrement = false;
				colvarCountryRegionCode.IsNullable = false;
				colvarCountryRegionCode.IsPrimaryKey = true;
				colvarCountryRegionCode.IsForeignKey = false;
				colvarCountryRegionCode.IsReadOnly = false;
				colvarCountryRegionCode.DefaultSetting = @"";
				colvarCountryRegionCode.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCountryRegionCode);
				
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
				DataService.Providers["Default"].AddSchema("CountryRegion",schema);
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
		
		public AVManager.DAL.StateProvinceCollection StateProvinceRecords()
		{
			return new AVManager.DAL.StateProvinceCollection().Where(StateProvince.Columns.CountryRegionCode, CountryRegionCode).Load();
		}

		public AVManager.DAL.CountryRegionCurrencyCollection CountryRegionCurrencyRecords()
		{
			return new AVManager.DAL.CountryRegionCurrencyCollection().Where(CountryRegionCurrency.Columns.CountryRegionCode, CountryRegionCode).Load();
		}

		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		#region Many To Many Helpers
		
		 
		public AVManager.DAL.CurrencyCollection GetCurrencyCollection() { return CountryRegion.GetCurrencyCollection(this.CountryRegionCode); }

		public static AVManager.DAL.CurrencyCollection GetCurrencyCollection(string varCountryRegionCode)
		{
			SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
				"SELECT * FROM Currency INNER JOIN CountryRegionCurrency ON "+
				"Currency.CurrencyCode=CountryRegionCurrency.CurrencyCode WHERE CountryRegionCurrency.CountryRegionCode=@CountryRegionCode", CountryRegion.Schema.Provider.Name);
			
			cmd.AddParameter("@CountryRegionCode", varCountryRegionCode, DbType.String);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			CurrencyCollection coll = new CurrencyCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}

		
		public static void SaveCurrencyMap(string varCountryRegionCode, CurrencyCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM CountryRegionCurrency WHERE CountryRegionCode=@CountryRegionCode", CountryRegion.Schema.Provider.Name);
			cmdDel.AddParameter("@CountryRegionCode", varCountryRegionCode);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Currency item in items)
			{
				CountryRegionCurrency varCountryRegionCurrency = new CountryRegionCurrency();
				varCountryRegionCurrency.SetColumnValue("CountryRegionCode", varCountryRegionCode);
				varCountryRegionCurrency.SetColumnValue("CurrencyCode", item.GetPrimaryKeyValue());
				varCountryRegionCurrency.Save();
			}

		}

		public static void SaveCurrencyMap(string varCountryRegionCode, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM CountryRegionCurrency WHERE CountryRegionCode=@CountryRegionCode", CountryRegion.Schema.Provider.Name);
			cmdDel.AddParameter("@CountryRegionCode", varCountryRegionCode);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					CountryRegionCurrency varCountryRegionCurrency = new CountryRegionCurrency();
					varCountryRegionCurrency.SetColumnValue("CountryRegionCode", varCountryRegionCode);
					varCountryRegionCurrency.SetColumnValue("CurrencyCode", l.Value);
					varCountryRegionCurrency.Save();
				}

			}

		}

		public static void SaveCurrencyMap(string varCountryRegionCode , string[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM CountryRegionCurrency WHERE CountryRegionCode=@CountryRegionCode", CountryRegion.Schema.Provider.Name);
			cmdDel.AddParameter("@CountryRegionCode", varCountryRegionCode);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (string item in itemList) 
			{
				CountryRegionCurrency varCountryRegionCurrency = new CountryRegionCurrency();
				varCountryRegionCurrency.SetColumnValue("CountryRegionCode", varCountryRegionCode);
				varCountryRegionCurrency.SetColumnValue("CurrencyCode", item);
				varCountryRegionCurrency.Save();
			}

		}

		
		public static void DeleteCurrencyMap(string varCountryRegionCode) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM CountryRegionCurrency WHERE CountryRegionCode=@CountryRegionCode", CountryRegion.Schema.Provider.Name);
			cmdDel.AddParameter("@CountryRegionCode", varCountryRegionCode);
			DataService.ExecuteQuery(cmdDel);
		}

		
		#endregion
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varCountryRegionCode,string varName,DateTime varModifiedDate)
		{
			CountryRegion item = new CountryRegion();
			
			item.CountryRegionCode = varCountryRegionCode;
			
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
		public static void Update(string varCountryRegionCode,string varName,DateTime varModifiedDate)
		{
			CountryRegion item = new CountryRegion();
			
				item.CountryRegionCode = varCountryRegionCode;
			
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
			 public static string CountryRegionCode = @"CountryRegionCode";
			 public static string Name = @"Name";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}

		#endregion
	}

}

