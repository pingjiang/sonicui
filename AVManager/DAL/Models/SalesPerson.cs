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
	/// Strongly-typed collection for the SalesPerson class.
	/// </summary>
	[Serializable]
	public partial class SalesPersonCollection : ActiveList<SalesPerson, SalesPersonCollection> 
	{	   
		public SalesPersonCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the SalesPerson table.
	/// </summary>
	[Serializable]
	public partial class SalesPerson : ActiveRecord<SalesPerson>
	{
		#region .ctors and Default Settings
		
		public SalesPerson()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public SalesPerson(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public SalesPerson(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public SalesPerson(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("SalesPerson", TableType.Table, DataService.GetInstance("Default"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Sales";
				//columns
				
				TableSchema.TableColumn colvarSalesPersonID = new TableSchema.TableColumn(schema);
				colvarSalesPersonID.ColumnName = "SalesPersonID";
				colvarSalesPersonID.DataType = DbType.Int32;
				colvarSalesPersonID.MaxLength = 0;
				colvarSalesPersonID.AutoIncrement = false;
				colvarSalesPersonID.IsNullable = false;
				colvarSalesPersonID.IsPrimaryKey = true;
				colvarSalesPersonID.IsForeignKey = true;
				colvarSalesPersonID.IsReadOnly = false;
				colvarSalesPersonID.DefaultSetting = @"";
				
					colvarSalesPersonID.ForeignKeyTableName = "Employee";
				schema.Columns.Add(colvarSalesPersonID);
				
				TableSchema.TableColumn colvarTerritoryID = new TableSchema.TableColumn(schema);
				colvarTerritoryID.ColumnName = "TerritoryID";
				colvarTerritoryID.DataType = DbType.Int32;
				colvarTerritoryID.MaxLength = 0;
				colvarTerritoryID.AutoIncrement = false;
				colvarTerritoryID.IsNullable = true;
				colvarTerritoryID.IsPrimaryKey = false;
				colvarTerritoryID.IsForeignKey = true;
				colvarTerritoryID.IsReadOnly = false;
				colvarTerritoryID.DefaultSetting = @"";
				
					colvarTerritoryID.ForeignKeyTableName = "SalesTerritory";
				schema.Columns.Add(colvarTerritoryID);
				
				TableSchema.TableColumn colvarSalesQuota = new TableSchema.TableColumn(schema);
				colvarSalesQuota.ColumnName = "SalesQuota";
				colvarSalesQuota.DataType = DbType.Currency;
				colvarSalesQuota.MaxLength = 0;
				colvarSalesQuota.AutoIncrement = false;
				colvarSalesQuota.IsNullable = true;
				colvarSalesQuota.IsPrimaryKey = false;
				colvarSalesQuota.IsForeignKey = false;
				colvarSalesQuota.IsReadOnly = false;
				colvarSalesQuota.DefaultSetting = @"";
				colvarSalesQuota.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSalesQuota);
				
				TableSchema.TableColumn colvarBonus = new TableSchema.TableColumn(schema);
				colvarBonus.ColumnName = "Bonus";
				colvarBonus.DataType = DbType.Currency;
				colvarBonus.MaxLength = 0;
				colvarBonus.AutoIncrement = false;
				colvarBonus.IsNullable = false;
				colvarBonus.IsPrimaryKey = false;
				colvarBonus.IsForeignKey = false;
				colvarBonus.IsReadOnly = false;
				
						colvarBonus.DefaultSetting = @"((0.00))";
				colvarBonus.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBonus);
				
				TableSchema.TableColumn colvarCommissionPct = new TableSchema.TableColumn(schema);
				colvarCommissionPct.ColumnName = "CommissionPct";
				colvarCommissionPct.DataType = DbType.Currency;
				colvarCommissionPct.MaxLength = 0;
				colvarCommissionPct.AutoIncrement = false;
				colvarCommissionPct.IsNullable = false;
				colvarCommissionPct.IsPrimaryKey = false;
				colvarCommissionPct.IsForeignKey = false;
				colvarCommissionPct.IsReadOnly = false;
				
						colvarCommissionPct.DefaultSetting = @"((0.00))";
				colvarCommissionPct.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCommissionPct);
				
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
				DataService.Providers["Default"].AddSchema("SalesPerson",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("SalesPersonID")]
		public int SalesPersonID 
		{
			get { return GetColumnValue<int>(Columns.SalesPersonID); }

			set { SetColumnValue(Columns.SalesPersonID, value); }

		}

		  
		[XmlAttribute("TerritoryID")]
		public int? TerritoryID 
		{
			get { return GetColumnValue<int?>(Columns.TerritoryID); }

			set { SetColumnValue(Columns.TerritoryID, value); }

		}

		  
		[XmlAttribute("SalesQuota")]
		public decimal? SalesQuota 
		{
			get { return GetColumnValue<decimal?>(Columns.SalesQuota); }

			set { SetColumnValue(Columns.SalesQuota, value); }

		}

		  
		[XmlAttribute("Bonus")]
		public decimal Bonus 
		{
			get { return GetColumnValue<decimal>(Columns.Bonus); }

			set { SetColumnValue(Columns.Bonus, value); }

		}

		  
		[XmlAttribute("CommissionPct")]
		public decimal CommissionPct 
		{
			get { return GetColumnValue<decimal>(Columns.CommissionPct); }

			set { SetColumnValue(Columns.CommissionPct, value); }

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
		
		public AVManager.DAL.SalesOrderHeaderCollection SalesOrderHeaderRecords()
		{
			return new AVManager.DAL.SalesOrderHeaderCollection().Where(SalesOrderHeader.Columns.SalesPersonID, SalesPersonID).Load();
		}

		public AVManager.DAL.SalesPersonQuotaHistoryCollection SalesPersonQuotaHistoryRecords()
		{
			return new AVManager.DAL.SalesPersonQuotaHistoryCollection().Where(SalesPersonQuotaHistory.Columns.SalesPersonID, SalesPersonID).Load();
		}

		public AVManager.DAL.SalesTerritoryHistoryCollection SalesTerritoryHistoryRecords()
		{
			return new AVManager.DAL.SalesTerritoryHistoryCollection().Where(SalesTerritoryHistory.Columns.SalesPersonID, SalesPersonID).Load();
		}

		public AVManager.DAL.StoreCollection StoreRecords()
		{
			return new AVManager.DAL.StoreCollection().Where(Store.Columns.SalesPersonID, SalesPersonID).Load();
		}

		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Employee ActiveRecord object related to this SalesPerson
		/// 
		/// </summary>
		public AVManager.DAL.Employee Employee
		{
			get { return AVManager.DAL.Employee.FetchByID(this.SalesPersonID); }

			set { SetColumnValue("SalesPersonID", value.EmployeeID); }

		}

		
		
		/// <summary>
		/// Returns a SalesTerritory ActiveRecord object related to this SalesPerson
		/// 
		/// </summary>
		public AVManager.DAL.SalesTerritory SalesTerritory
		{
			get { return AVManager.DAL.SalesTerritory.FetchByID(this.TerritoryID); }

			set { SetColumnValue("TerritoryID", value.TerritoryID); }

		}

		
		
		#endregion
		
		
		
		#region Many To Many Helpers
		
		 
		public AVManager.DAL.SalesTerritoryCollection GetSalesTerritoryCollection() { return SalesPerson.GetSalesTerritoryCollection(this.SalesPersonID); }

		public static AVManager.DAL.SalesTerritoryCollection GetSalesTerritoryCollection(int varSalesPersonID)
		{
			SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
				"SELECT * FROM SalesTerritory INNER JOIN SalesTerritoryHistory ON "+
				"SalesTerritory.TerritoryID=SalesTerritoryHistory.TerritoryID WHERE SalesTerritoryHistory.SalesPersonID=@SalesPersonID", SalesPerson.Schema.Provider.Name);
			
			cmd.AddParameter("@SalesPersonID", varSalesPersonID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			SalesTerritoryCollection coll = new SalesTerritoryCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}

		
		public static void SaveSalesTerritoryMap(int varSalesPersonID, SalesTerritoryCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM SalesTerritoryHistory WHERE SalesPersonID=@SalesPersonID", SalesPerson.Schema.Provider.Name);
			cmdDel.AddParameter("@SalesPersonID", varSalesPersonID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (SalesTerritory item in items)
			{
				SalesTerritoryHistory varSalesTerritoryHistory = new SalesTerritoryHistory();
				varSalesTerritoryHistory.SetColumnValue("SalesPersonID", varSalesPersonID);
				varSalesTerritoryHistory.SetColumnValue("TerritoryID", item.GetPrimaryKeyValue());
				varSalesTerritoryHistory.Save();
			}

		}

		public static void SaveSalesTerritoryMap(int varSalesPersonID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM SalesTerritoryHistory WHERE SalesPersonID=@SalesPersonID", SalesPerson.Schema.Provider.Name);
			cmdDel.AddParameter("@SalesPersonID", varSalesPersonID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					SalesTerritoryHistory varSalesTerritoryHistory = new SalesTerritoryHistory();
					varSalesTerritoryHistory.SetColumnValue("SalesPersonID", varSalesPersonID);
					varSalesTerritoryHistory.SetColumnValue("TerritoryID", l.Value);
					varSalesTerritoryHistory.Save();
				}

			}

		}

		public static void SaveSalesTerritoryMap(int varSalesPersonID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM SalesTerritoryHistory WHERE SalesPersonID=@SalesPersonID", SalesPerson.Schema.Provider.Name);
			cmdDel.AddParameter("@SalesPersonID", varSalesPersonID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				SalesTerritoryHistory varSalesTerritoryHistory = new SalesTerritoryHistory();
				varSalesTerritoryHistory.SetColumnValue("SalesPersonID", varSalesPersonID);
				varSalesTerritoryHistory.SetColumnValue("TerritoryID", item);
				varSalesTerritoryHistory.Save();
			}

		}

		
		public static void DeleteSalesTerritoryMap(int varSalesPersonID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM SalesTerritoryHistory WHERE SalesPersonID=@SalesPersonID", SalesPerson.Schema.Provider.Name);
			cmdDel.AddParameter("@SalesPersonID", varSalesPersonID);
			DataService.ExecuteQuery(cmdDel);
		}

		
		#endregion
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varSalesPersonID,int? varTerritoryID,decimal? varSalesQuota,decimal varBonus,decimal varCommissionPct,decimal varSalesYTD,decimal varSalesLastYear,Guid varRowguid,DateTime varModifiedDate)
		{
			SalesPerson item = new SalesPerson();
			
			item.SalesPersonID = varSalesPersonID;
			
			item.TerritoryID = varTerritoryID;
			
			item.SalesQuota = varSalesQuota;
			
			item.Bonus = varBonus;
			
			item.CommissionPct = varCommissionPct;
			
			item.SalesYTD = varSalesYTD;
			
			item.SalesLastYear = varSalesLastYear;
			
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
		public static void Update(int varSalesPersonID,int? varTerritoryID,decimal? varSalesQuota,decimal varBonus,decimal varCommissionPct,decimal varSalesYTD,decimal varSalesLastYear,Guid varRowguid,DateTime varModifiedDate)
		{
			SalesPerson item = new SalesPerson();
			
				item.SalesPersonID = varSalesPersonID;
			
				item.TerritoryID = varTerritoryID;
			
				item.SalesQuota = varSalesQuota;
			
				item.Bonus = varBonus;
			
				item.CommissionPct = varCommissionPct;
			
				item.SalesYTD = varSalesYTD;
			
				item.SalesLastYear = varSalesLastYear;
			
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
			 public static string SalesPersonID = @"SalesPersonID";
			 public static string TerritoryID = @"TerritoryID";
			 public static string SalesQuota = @"SalesQuota";
			 public static string Bonus = @"Bonus";
			 public static string CommissionPct = @"CommissionPct";
			 public static string SalesYTD = @"SalesYTD";
			 public static string SalesLastYear = @"SalesLastYear";
			 public static string Rowguid = @"rowguid";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}

		#endregion
	}

}

