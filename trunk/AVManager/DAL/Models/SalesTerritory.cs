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
	/// Strongly-typed collection for the SalesTerritory class.
	/// </summary>
	[Serializable]
	public partial class SalesTerritoryCollection : ActiveList<SalesTerritory, SalesTerritoryCollection> 
	{	   
		public SalesTerritoryCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the SalesTerritory table.
	/// </summary>
	[Serializable]
	public partial class SalesTerritory : ActiveRecord<SalesTerritory>
	{
		#region .ctors and Default Settings
		
		public SalesTerritory()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public SalesTerritory(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public SalesTerritory(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public SalesTerritory(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("SalesTerritory", TableType.Table, DataService.GetInstance("Default"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Sales";
				//columns
				
				TableSchema.TableColumn colvarTerritoryID = new TableSchema.TableColumn(schema);
				colvarTerritoryID.ColumnName = "TerritoryID";
				colvarTerritoryID.DataType = DbType.Int32;
				colvarTerritoryID.MaxLength = 0;
				colvarTerritoryID.AutoIncrement = true;
				colvarTerritoryID.IsNullable = false;
				colvarTerritoryID.IsPrimaryKey = true;
				colvarTerritoryID.IsForeignKey = false;
				colvarTerritoryID.IsReadOnly = false;
				colvarTerritoryID.DefaultSetting = @"";
				colvarTerritoryID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTerritoryID);
				
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
				
				TableSchema.TableColumn colvarCountryRegionCode = new TableSchema.TableColumn(schema);
				colvarCountryRegionCode.ColumnName = "CountryRegionCode";
				colvarCountryRegionCode.DataType = DbType.String;
				colvarCountryRegionCode.MaxLength = 3;
				colvarCountryRegionCode.AutoIncrement = false;
				colvarCountryRegionCode.IsNullable = false;
				colvarCountryRegionCode.IsPrimaryKey = false;
				colvarCountryRegionCode.IsForeignKey = false;
				colvarCountryRegionCode.IsReadOnly = false;
				colvarCountryRegionCode.DefaultSetting = @"";
				colvarCountryRegionCode.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCountryRegionCode);
				
				TableSchema.TableColumn colvarGroup = new TableSchema.TableColumn(schema);
				colvarGroup.ColumnName = "Group";
				colvarGroup.DataType = DbType.String;
				colvarGroup.MaxLength = 50;
				colvarGroup.AutoIncrement = false;
				colvarGroup.IsNullable = false;
				colvarGroup.IsPrimaryKey = false;
				colvarGroup.IsForeignKey = false;
				colvarGroup.IsReadOnly = false;
				colvarGroup.DefaultSetting = @"";
				colvarGroup.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGroup);
				
				TableSchema.TableColumn colvarSalesYTD = new TableSchema.TableColumn(schema);
				colvarSalesYTD.ColumnName = "SalesYTD";
				colvarSalesYTD.DataType = DbType.Currency;
				colvarSalesYTD.MaxLength = 0;
				colvarSalesYTD.AutoIncrement = false;
				colvarSalesYTD.IsNullable = false;
				colvarSalesYTD.IsPrimaryKey = false;
				colvarSalesYTD.IsForeignKey = false;
				colvarSalesYTD.IsReadOnly = false;
				
						colvarSalesYTD.DefaultSetting = @"((0.00))";
				colvarSalesYTD.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSalesYTD);
				
				TableSchema.TableColumn colvarSalesLastYear = new TableSchema.TableColumn(schema);
				colvarSalesLastYear.ColumnName = "SalesLastYear";
				colvarSalesLastYear.DataType = DbType.Currency;
				colvarSalesLastYear.MaxLength = 0;
				colvarSalesLastYear.AutoIncrement = false;
				colvarSalesLastYear.IsNullable = false;
				colvarSalesLastYear.IsPrimaryKey = false;
				colvarSalesLastYear.IsForeignKey = false;
				colvarSalesLastYear.IsReadOnly = false;
				
						colvarSalesLastYear.DefaultSetting = @"((0.00))";
				colvarSalesLastYear.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSalesLastYear);
				
				TableSchema.TableColumn colvarCostYTD = new TableSchema.TableColumn(schema);
				colvarCostYTD.ColumnName = "CostYTD";
				colvarCostYTD.DataType = DbType.Currency;
				colvarCostYTD.MaxLength = 0;
				colvarCostYTD.AutoIncrement = false;
				colvarCostYTD.IsNullable = false;
				colvarCostYTD.IsPrimaryKey = false;
				colvarCostYTD.IsForeignKey = false;
				colvarCostYTD.IsReadOnly = false;
				
						colvarCostYTD.DefaultSetting = @"((0.00))";
				colvarCostYTD.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCostYTD);
				
				TableSchema.TableColumn colvarCostLastYear = new TableSchema.TableColumn(schema);
				colvarCostLastYear.ColumnName = "CostLastYear";
				colvarCostLastYear.DataType = DbType.Currency;
				colvarCostLastYear.MaxLength = 0;
				colvarCostLastYear.AutoIncrement = false;
				colvarCostLastYear.IsNullable = false;
				colvarCostLastYear.IsPrimaryKey = false;
				colvarCostLastYear.IsForeignKey = false;
				colvarCostLastYear.IsReadOnly = false;
				
						colvarCostLastYear.DefaultSetting = @"((0.00))";
				colvarCostLastYear.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCostLastYear);
				
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
				DataService.Providers["Default"].AddSchema("SalesTerritory",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("TerritoryID")]
		public int TerritoryID 
		{
			get { return GetColumnValue<int>(Columns.TerritoryID); }

			set { SetColumnValue(Columns.TerritoryID, value); }

		}

		  
		[XmlAttribute("Name")]
		public string Name 
		{
			get { return GetColumnValue<string>(Columns.Name); }

			set { SetColumnValue(Columns.Name, value); }

		}

		  
		[XmlAttribute("CountryRegionCode")]
		public string CountryRegionCode 
		{
			get { return GetColumnValue<string>(Columns.CountryRegionCode); }

			set { SetColumnValue(Columns.CountryRegionCode, value); }

		}

		  
		[XmlAttribute("Group")]
		public string Group 
		{
			get { return GetColumnValue<string>(Columns.Group); }

			set { SetColumnValue(Columns.Group, value); }

		}

		  
		[XmlAttribute("SalesYTD")]
		public decimal SalesYTD 
		{
			get { return GetColumnValue<decimal>(Columns.SalesYTD); }

			set { SetColumnValue(Columns.SalesYTD, value); }

		}

		  
		[XmlAttribute("SalesLastYear")]
		public decimal SalesLastYear 
		{
			get { return GetColumnValue<decimal>(Columns.SalesLastYear); }

			set { SetColumnValue(Columns.SalesLastYear, value); }

		}

		  
		[XmlAttribute("CostYTD")]
		public decimal CostYTD 
		{
			get { return GetColumnValue<decimal>(Columns.CostYTD); }

			set { SetColumnValue(Columns.CostYTD, value); }

		}

		  
		[XmlAttribute("CostLastYear")]
		public decimal CostLastYear 
		{
			get { return GetColumnValue<decimal>(Columns.CostLastYear); }

			set { SetColumnValue(Columns.CostLastYear, value); }

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
		
		public AVManager.DAL.StateProvinceCollection StateProvinceRecords()
		{
			return new AVManager.DAL.StateProvinceCollection().Where(StateProvince.Columns.TerritoryID, TerritoryID).Load();
		}

		public AVManager.DAL.CustomerCollection CustomerRecords()
		{
			return new AVManager.DAL.CustomerCollection().Where(Customer.Columns.TerritoryID, TerritoryID).Load();
		}

		public AVManager.DAL.SalesOrderHeaderCollection SalesOrderHeaderRecords()
		{
			return new AVManager.DAL.SalesOrderHeaderCollection().Where(SalesOrderHeader.Columns.TerritoryID, TerritoryID).Load();
		}

		public AVManager.DAL.SalesPersonCollection SalesPersonRecords()
		{
			return new AVManager.DAL.SalesPersonCollection().Where(SalesPerson.Columns.TerritoryID, TerritoryID).Load();
		}

		public AVManager.DAL.SalesTerritoryHistoryCollection SalesTerritoryHistoryRecords()
		{
			return new AVManager.DAL.SalesTerritoryHistoryCollection().Where(SalesTerritoryHistory.Columns.TerritoryID, TerritoryID).Load();
		}

		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		#region Many To Many Helpers
		
		 
		public AVManager.DAL.SalesPersonCollection GetSalesPersonCollection() { return SalesTerritory.GetSalesPersonCollection(this.TerritoryID); }

		public static AVManager.DAL.SalesPersonCollection GetSalesPersonCollection(int varTerritoryID)
		{
			SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
				"SELECT * FROM SalesPerson INNER JOIN SalesTerritoryHistory ON "+
				"SalesPerson.SalesPersonID=SalesTerritoryHistory.SalesPersonID WHERE SalesTerritoryHistory.TerritoryID=@TerritoryID", SalesTerritory.Schema.Provider.Name);
			
			cmd.AddParameter("@TerritoryID", varTerritoryID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			SalesPersonCollection coll = new SalesPersonCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}

		
		public static void SaveSalesPersonMap(int varTerritoryID, SalesPersonCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM SalesTerritoryHistory WHERE TerritoryID=@TerritoryID", SalesTerritory.Schema.Provider.Name);
			cmdDel.AddParameter("@TerritoryID", varTerritoryID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (SalesPerson item in items)
			{
				SalesTerritoryHistory varSalesTerritoryHistory = new SalesTerritoryHistory();
				varSalesTerritoryHistory.SetColumnValue("TerritoryID", varTerritoryID);
				varSalesTerritoryHistory.SetColumnValue("SalesPersonID", item.GetPrimaryKeyValue());
				varSalesTerritoryHistory.Save();
			}

		}

		public static void SaveSalesPersonMap(int varTerritoryID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM SalesTerritoryHistory WHERE TerritoryID=@TerritoryID", SalesTerritory.Schema.Provider.Name);
			cmdDel.AddParameter("@TerritoryID", varTerritoryID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					SalesTerritoryHistory varSalesTerritoryHistory = new SalesTerritoryHistory();
					varSalesTerritoryHistory.SetColumnValue("TerritoryID", varTerritoryID);
					varSalesTerritoryHistory.SetColumnValue("SalesPersonID", l.Value);
					varSalesTerritoryHistory.Save();
				}

			}

		}

		public static void SaveSalesPersonMap(int varTerritoryID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM SalesTerritoryHistory WHERE TerritoryID=@TerritoryID", SalesTerritory.Schema.Provider.Name);
			cmdDel.AddParameter("@TerritoryID", varTerritoryID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				SalesTerritoryHistory varSalesTerritoryHistory = new SalesTerritoryHistory();
				varSalesTerritoryHistory.SetColumnValue("TerritoryID", varTerritoryID);
				varSalesTerritoryHistory.SetColumnValue("SalesPersonID", item);
				varSalesTerritoryHistory.Save();
			}

		}

		
		public static void DeleteSalesPersonMap(int varTerritoryID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM SalesTerritoryHistory WHERE TerritoryID=@TerritoryID", SalesTerritory.Schema.Provider.Name);
			cmdDel.AddParameter("@TerritoryID", varTerritoryID);
			DataService.ExecuteQuery(cmdDel);
		}

		
		#endregion
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varName,string varCountryRegionCode,string varGroup,decimal varSalesYTD,decimal varSalesLastYear,decimal varCostYTD,decimal varCostLastYear,Guid varRowguid,DateTime varModifiedDate)
		{
			SalesTerritory item = new SalesTerritory();
			
			item.Name = varName;
			
			item.CountryRegionCode = varCountryRegionCode;
			
			item.Group = varGroup;
			
			item.SalesYTD = varSalesYTD;
			
			item.SalesLastYear = varSalesLastYear;
			
			item.CostYTD = varCostYTD;
			
			item.CostLastYear = varCostLastYear;
			
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
		public static void Update(int varTerritoryID,string varName,string varCountryRegionCode,string varGroup,decimal varSalesYTD,decimal varSalesLastYear,decimal varCostYTD,decimal varCostLastYear,Guid varRowguid,DateTime varModifiedDate)
		{
			SalesTerritory item = new SalesTerritory();
			
				item.TerritoryID = varTerritoryID;
			
				item.Name = varName;
			
				item.CountryRegionCode = varCountryRegionCode;
			
				item.Group = varGroup;
			
				item.SalesYTD = varSalesYTD;
			
				item.SalesLastYear = varSalesLastYear;
			
				item.CostYTD = varCostYTD;
			
				item.CostLastYear = varCostLastYear;
			
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
			 public static string TerritoryID = @"TerritoryID";
			 public static string Name = @"Name";
			 public static string CountryRegionCode = @"CountryRegionCode";
			 public static string Group = @"Group";
			 public static string SalesYTD = @"SalesYTD";
			 public static string SalesLastYear = @"SalesLastYear";
			 public static string CostYTD = @"CostYTD";
			 public static string CostLastYear = @"CostLastYear";
			 public static string Rowguid = @"rowguid";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}

		#endregion
	}

}

