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
	/// Strongly-typed collection for the StateProvince class.
	/// </summary>
	[Serializable]
	public partial class StateProvinceCollection : ActiveList<StateProvince, StateProvinceCollection> 
	{	   
		public StateProvinceCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the StateProvince table.
	/// </summary>
	[Serializable]
	public partial class StateProvince : ActiveRecord<StateProvince>
	{
		#region .ctors and Default Settings
		
		public StateProvince()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public StateProvince(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public StateProvince(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public StateProvince(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("StateProvince", TableType.Table, DataService.GetInstance("Default"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Person";
				//columns
				
				TableSchema.TableColumn colvarStateProvinceID = new TableSchema.TableColumn(schema);
				colvarStateProvinceID.ColumnName = "StateProvinceID";
				colvarStateProvinceID.DataType = DbType.Int32;
				colvarStateProvinceID.MaxLength = 0;
				colvarStateProvinceID.AutoIncrement = true;
				colvarStateProvinceID.IsNullable = false;
				colvarStateProvinceID.IsPrimaryKey = true;
				colvarStateProvinceID.IsForeignKey = false;
				colvarStateProvinceID.IsReadOnly = false;
				colvarStateProvinceID.DefaultSetting = @"";
				colvarStateProvinceID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStateProvinceID);
				
				TableSchema.TableColumn colvarStateProvinceCode = new TableSchema.TableColumn(schema);
				colvarStateProvinceCode.ColumnName = "StateProvinceCode";
				colvarStateProvinceCode.DataType = DbType.String;
				colvarStateProvinceCode.MaxLength = 3;
				colvarStateProvinceCode.AutoIncrement = false;
				colvarStateProvinceCode.IsNullable = false;
				colvarStateProvinceCode.IsPrimaryKey = false;
				colvarStateProvinceCode.IsForeignKey = false;
				colvarStateProvinceCode.IsReadOnly = false;
				colvarStateProvinceCode.DefaultSetting = @"";
				colvarStateProvinceCode.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStateProvinceCode);
				
				TableSchema.TableColumn colvarCountryRegionCode = new TableSchema.TableColumn(schema);
				colvarCountryRegionCode.ColumnName = "CountryRegionCode";
				colvarCountryRegionCode.DataType = DbType.String;
				colvarCountryRegionCode.MaxLength = 3;
				colvarCountryRegionCode.AutoIncrement = false;
				colvarCountryRegionCode.IsNullable = false;
				colvarCountryRegionCode.IsPrimaryKey = false;
				colvarCountryRegionCode.IsForeignKey = true;
				colvarCountryRegionCode.IsReadOnly = false;
				colvarCountryRegionCode.DefaultSetting = @"";
				
					colvarCountryRegionCode.ForeignKeyTableName = "CountryRegion";
				schema.Columns.Add(colvarCountryRegionCode);
				
				TableSchema.TableColumn colvarIsOnlyStateProvinceFlag = new TableSchema.TableColumn(schema);
				colvarIsOnlyStateProvinceFlag.ColumnName = "IsOnlyStateProvinceFlag";
				colvarIsOnlyStateProvinceFlag.DataType = DbType.Boolean;
				colvarIsOnlyStateProvinceFlag.MaxLength = 0;
				colvarIsOnlyStateProvinceFlag.AutoIncrement = false;
				colvarIsOnlyStateProvinceFlag.IsNullable = false;
				colvarIsOnlyStateProvinceFlag.IsPrimaryKey = false;
				colvarIsOnlyStateProvinceFlag.IsForeignKey = false;
				colvarIsOnlyStateProvinceFlag.IsReadOnly = false;
				
						colvarIsOnlyStateProvinceFlag.DefaultSetting = @"((1))";
				colvarIsOnlyStateProvinceFlag.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIsOnlyStateProvinceFlag);
				
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
				
				TableSchema.TableColumn colvarTerritoryID = new TableSchema.TableColumn(schema);
				colvarTerritoryID.ColumnName = "TerritoryID";
				colvarTerritoryID.DataType = DbType.Int32;
				colvarTerritoryID.MaxLength = 0;
				colvarTerritoryID.AutoIncrement = false;
				colvarTerritoryID.IsNullable = false;
				colvarTerritoryID.IsPrimaryKey = false;
				colvarTerritoryID.IsForeignKey = true;
				colvarTerritoryID.IsReadOnly = false;
				colvarTerritoryID.DefaultSetting = @"";
				
					colvarTerritoryID.ForeignKeyTableName = "SalesTerritory";
				schema.Columns.Add(colvarTerritoryID);
				
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
				DataService.Providers["Default"].AddSchema("StateProvince",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("StateProvinceID")]
		public int StateProvinceID 
		{
			get { return GetColumnValue<int>(Columns.StateProvinceID); }

			set { SetColumnValue(Columns.StateProvinceID, value); }

		}

		  
		[XmlAttribute("StateProvinceCode")]
		public string StateProvinceCode 
		{
			get { return GetColumnValue<string>(Columns.StateProvinceCode); }

			set { SetColumnValue(Columns.StateProvinceCode, value); }

		}

		  
		[XmlAttribute("CountryRegionCode")]
		public string CountryRegionCode 
		{
			get { return GetColumnValue<string>(Columns.CountryRegionCode); }

			set { SetColumnValue(Columns.CountryRegionCode, value); }

		}

		  
		[XmlAttribute("IsOnlyStateProvinceFlag")]
		public bool IsOnlyStateProvinceFlag 
		{
			get { return GetColumnValue<bool>(Columns.IsOnlyStateProvinceFlag); }

			set { SetColumnValue(Columns.IsOnlyStateProvinceFlag, value); }

		}

		  
		[XmlAttribute("Name")]
		public string Name 
		{
			get { return GetColumnValue<string>(Columns.Name); }

			set { SetColumnValue(Columns.Name, value); }

		}

		  
		[XmlAttribute("TerritoryID")]
		public int TerritoryID 
		{
			get { return GetColumnValue<int>(Columns.TerritoryID); }

			set { SetColumnValue(Columns.TerritoryID, value); }

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
		
		public AVManager.DAL.AddressCollection AddressRecords()
		{
			return new AVManager.DAL.AddressCollection().Where(Address.Columns.StateProvinceID, StateProvinceID).Load();
		}

		public AVManager.DAL.SalesTaxRateCollection SalesTaxRateRecords()
		{
			return new AVManager.DAL.SalesTaxRateCollection().Where(SalesTaxRate.Columns.StateProvinceID, StateProvinceID).Load();
		}

		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a CountryRegion ActiveRecord object related to this StateProvince
		/// 
		/// </summary>
		public AVManager.DAL.CountryRegion CountryRegion
		{
			get { return AVManager.DAL.CountryRegion.FetchByID(this.CountryRegionCode); }

			set { SetColumnValue("CountryRegionCode", value.CountryRegionCode); }

		}

		
		
		/// <summary>
		/// Returns a SalesTerritory ActiveRecord object related to this StateProvince
		/// 
		/// </summary>
		public AVManager.DAL.SalesTerritory SalesTerritory
		{
			get { return AVManager.DAL.SalesTerritory.FetchByID(this.TerritoryID); }

			set { SetColumnValue("TerritoryID", value.TerritoryID); }

		}

		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varStateProvinceCode,string varCountryRegionCode,bool varIsOnlyStateProvinceFlag,string varName,int varTerritoryID,Guid varRowguid,DateTime varModifiedDate)
		{
			StateProvince item = new StateProvince();
			
			item.StateProvinceCode = varStateProvinceCode;
			
			item.CountryRegionCode = varCountryRegionCode;
			
			item.IsOnlyStateProvinceFlag = varIsOnlyStateProvinceFlag;
			
			item.Name = varName;
			
			item.TerritoryID = varTerritoryID;
			
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
		public static void Update(int varStateProvinceID,string varStateProvinceCode,string varCountryRegionCode,bool varIsOnlyStateProvinceFlag,string varName,int varTerritoryID,Guid varRowguid,DateTime varModifiedDate)
		{
			StateProvince item = new StateProvince();
			
				item.StateProvinceID = varStateProvinceID;
			
				item.StateProvinceCode = varStateProvinceCode;
			
				item.CountryRegionCode = varCountryRegionCode;
			
				item.IsOnlyStateProvinceFlag = varIsOnlyStateProvinceFlag;
			
				item.Name = varName;
			
				item.TerritoryID = varTerritoryID;
			
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
			 public static string StateProvinceID = @"StateProvinceID";
			 public static string StateProvinceCode = @"StateProvinceCode";
			 public static string CountryRegionCode = @"CountryRegionCode";
			 public static string IsOnlyStateProvinceFlag = @"IsOnlyStateProvinceFlag";
			 public static string Name = @"Name";
			 public static string TerritoryID = @"TerritoryID";
			 public static string Rowguid = @"rowguid";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}

		#endregion
	}

}

