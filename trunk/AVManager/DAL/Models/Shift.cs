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
	/// Strongly-typed collection for the Shift class.
	/// </summary>
	[Serializable]
	public partial class ShiftCollection : ActiveList<Shift, ShiftCollection> 
	{	   
		public ShiftCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the Shift table.
	/// </summary>
	[Serializable]
	public partial class Shift : ActiveRecord<Shift>
	{
		#region .ctors and Default Settings
		
		public Shift()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public Shift(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public Shift(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public Shift(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Shift", TableType.Table, DataService.GetInstance("Default"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"HumanResources";
				//columns
				
				TableSchema.TableColumn colvarShiftID = new TableSchema.TableColumn(schema);
				colvarShiftID.ColumnName = "ShiftID";
				colvarShiftID.DataType = DbType.Byte;
				colvarShiftID.MaxLength = 0;
				colvarShiftID.AutoIncrement = true;
				colvarShiftID.IsNullable = false;
				colvarShiftID.IsPrimaryKey = true;
				colvarShiftID.IsForeignKey = false;
				colvarShiftID.IsReadOnly = false;
				colvarShiftID.DefaultSetting = @"";
				colvarShiftID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarShiftID);
				
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
				
				TableSchema.TableColumn colvarStartTime = new TableSchema.TableColumn(schema);
				colvarStartTime.ColumnName = "StartTime";
				colvarStartTime.DataType = DbType.DateTime;
				colvarStartTime.MaxLength = 0;
				colvarStartTime.AutoIncrement = false;
				colvarStartTime.IsNullable = false;
				colvarStartTime.IsPrimaryKey = false;
				colvarStartTime.IsForeignKey = false;
				colvarStartTime.IsReadOnly = false;
				colvarStartTime.DefaultSetting = @"";
				colvarStartTime.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStartTime);
				
				TableSchema.TableColumn colvarEndTime = new TableSchema.TableColumn(schema);
				colvarEndTime.ColumnName = "EndTime";
				colvarEndTime.DataType = DbType.DateTime;
				colvarEndTime.MaxLength = 0;
				colvarEndTime.AutoIncrement = false;
				colvarEndTime.IsNullable = false;
				colvarEndTime.IsPrimaryKey = false;
				colvarEndTime.IsForeignKey = false;
				colvarEndTime.IsReadOnly = false;
				colvarEndTime.DefaultSetting = @"";
				colvarEndTime.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEndTime);
				
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
				DataService.Providers["Default"].AddSchema("Shift",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("ShiftID")]
		public byte ShiftID 
		{
			get { return GetColumnValue<byte>(Columns.ShiftID); }

			set { SetColumnValue(Columns.ShiftID, value); }

		}

		  
		[XmlAttribute("Name")]
		public string Name 
		{
			get { return GetColumnValue<string>(Columns.Name); }

			set { SetColumnValue(Columns.Name, value); }

		}

		  
		[XmlAttribute("StartTime")]
		public DateTime StartTime 
		{
			get { return GetColumnValue<DateTime>(Columns.StartTime); }

			set { SetColumnValue(Columns.StartTime, value); }

		}

		  
		[XmlAttribute("EndTime")]
		public DateTime EndTime 
		{
			get { return GetColumnValue<DateTime>(Columns.EndTime); }

			set { SetColumnValue(Columns.EndTime, value); }

		}

		  
		[XmlAttribute("ModifiedDate")]
		public DateTime ModifiedDate 
		{
			get { return GetColumnValue<DateTime>(Columns.ModifiedDate); }

			set { SetColumnValue(Columns.ModifiedDate, value); }

		}

		
		#endregion
		
		
		#region PrimaryKey Methods
		
		public AVManager.DAL.EmployeeDepartmentHistoryCollection EmployeeDepartmentHistoryRecords()
		{
			return new AVManager.DAL.EmployeeDepartmentHistoryCollection().Where(EmployeeDepartmentHistory.Columns.ShiftID, ShiftID).Load();
		}

		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		#region Many To Many Helpers
		
		 
		public AVManager.DAL.DepartmentCollection GetDepartmentCollection() { return Shift.GetDepartmentCollection(this.ShiftID); }

		public static AVManager.DAL.DepartmentCollection GetDepartmentCollection(byte varShiftID)
		{
			SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
				"SELECT * FROM Department INNER JOIN EmployeeDepartmentHistory ON "+
				"Department.DepartmentID=EmployeeDepartmentHistory.DepartmentID WHERE EmployeeDepartmentHistory.ShiftID=@ShiftID", Shift.Schema.Provider.Name);
			
			cmd.AddParameter("@ShiftID", varShiftID, DbType.Byte);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			DepartmentCollection coll = new DepartmentCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}

		
		public static void SaveDepartmentMap(byte varShiftID, DepartmentCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM EmployeeDepartmentHistory WHERE ShiftID=@ShiftID", Shift.Schema.Provider.Name);
			cmdDel.AddParameter("@ShiftID", varShiftID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Department item in items)
			{
				EmployeeDepartmentHistory varEmployeeDepartmentHistory = new EmployeeDepartmentHistory();
				varEmployeeDepartmentHistory.SetColumnValue("ShiftID", varShiftID);
				varEmployeeDepartmentHistory.SetColumnValue("DepartmentID", item.GetPrimaryKeyValue());
				varEmployeeDepartmentHistory.Save();
			}

		}

		public static void SaveDepartmentMap(byte varShiftID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM EmployeeDepartmentHistory WHERE ShiftID=@ShiftID", Shift.Schema.Provider.Name);
			cmdDel.AddParameter("@ShiftID", varShiftID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					EmployeeDepartmentHistory varEmployeeDepartmentHistory = new EmployeeDepartmentHistory();
					varEmployeeDepartmentHistory.SetColumnValue("ShiftID", varShiftID);
					varEmployeeDepartmentHistory.SetColumnValue("DepartmentID", l.Value);
					varEmployeeDepartmentHistory.Save();
				}

			}

		}

		public static void SaveDepartmentMap(byte varShiftID , byte[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM EmployeeDepartmentHistory WHERE ShiftID=@ShiftID", Shift.Schema.Provider.Name);
			cmdDel.AddParameter("@ShiftID", varShiftID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (byte item in itemList) 
			{
				EmployeeDepartmentHistory varEmployeeDepartmentHistory = new EmployeeDepartmentHistory();
				varEmployeeDepartmentHistory.SetColumnValue("ShiftID", varShiftID);
				varEmployeeDepartmentHistory.SetColumnValue("DepartmentID", item);
				varEmployeeDepartmentHistory.Save();
			}

		}

		
		public static void DeleteDepartmentMap(byte varShiftID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM EmployeeDepartmentHistory WHERE ShiftID=@ShiftID", Shift.Schema.Provider.Name);
			cmdDel.AddParameter("@ShiftID", varShiftID);
			DataService.ExecuteQuery(cmdDel);
		}

		
		 
		public AVManager.DAL.EmployeeCollection GetEmployeeCollection() { return Shift.GetEmployeeCollection(this.ShiftID); }

		public static AVManager.DAL.EmployeeCollection GetEmployeeCollection(byte varShiftID)
		{
			SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
				"SELECT * FROM Employee INNER JOIN EmployeeDepartmentHistory ON "+
				"Employee.EmployeeID=EmployeeDepartmentHistory.EmployeeID WHERE EmployeeDepartmentHistory.ShiftID=@ShiftID", Shift.Schema.Provider.Name);
			
			cmd.AddParameter("@ShiftID", varShiftID, DbType.Byte);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			EmployeeCollection coll = new EmployeeCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}

		
		public static void SaveEmployeeMap(byte varShiftID, EmployeeCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM EmployeeDepartmentHistory WHERE ShiftID=@ShiftID", Shift.Schema.Provider.Name);
			cmdDel.AddParameter("@ShiftID", varShiftID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Employee item in items)
			{
				EmployeeDepartmentHistory varEmployeeDepartmentHistory = new EmployeeDepartmentHistory();
				varEmployeeDepartmentHistory.SetColumnValue("ShiftID", varShiftID);
				varEmployeeDepartmentHistory.SetColumnValue("EmployeeID", item.GetPrimaryKeyValue());
				varEmployeeDepartmentHistory.Save();
			}

		}

		public static void SaveEmployeeMap(byte varShiftID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM EmployeeDepartmentHistory WHERE ShiftID=@ShiftID", Shift.Schema.Provider.Name);
			cmdDel.AddParameter("@ShiftID", varShiftID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					EmployeeDepartmentHistory varEmployeeDepartmentHistory = new EmployeeDepartmentHistory();
					varEmployeeDepartmentHistory.SetColumnValue("ShiftID", varShiftID);
					varEmployeeDepartmentHistory.SetColumnValue("EmployeeID", l.Value);
					varEmployeeDepartmentHistory.Save();
				}

			}

		}

		public static void SaveEmployeeMap(byte varShiftID , byte[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM EmployeeDepartmentHistory WHERE ShiftID=@ShiftID", Shift.Schema.Provider.Name);
			cmdDel.AddParameter("@ShiftID", varShiftID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (byte item in itemList) 
			{
				EmployeeDepartmentHistory varEmployeeDepartmentHistory = new EmployeeDepartmentHistory();
				varEmployeeDepartmentHistory.SetColumnValue("ShiftID", varShiftID);
				varEmployeeDepartmentHistory.SetColumnValue("EmployeeID", item);
				varEmployeeDepartmentHistory.Save();
			}

		}

		
		public static void DeleteEmployeeMap(byte varShiftID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM EmployeeDepartmentHistory WHERE ShiftID=@ShiftID", Shift.Schema.Provider.Name);
			cmdDel.AddParameter("@ShiftID", varShiftID);
			DataService.ExecuteQuery(cmdDel);
		}

		
		#endregion
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varName,DateTime varStartTime,DateTime varEndTime,DateTime varModifiedDate)
		{
			Shift item = new Shift();
			
			item.Name = varName;
			
			item.StartTime = varStartTime;
			
			item.EndTime = varEndTime;
			
			item.ModifiedDate = varModifiedDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(byte varShiftID,string varName,DateTime varStartTime,DateTime varEndTime,DateTime varModifiedDate)
		{
			Shift item = new Shift();
			
				item.ShiftID = varShiftID;
			
				item.Name = varName;
			
				item.StartTime = varStartTime;
			
				item.EndTime = varEndTime;
			
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
			 public static string ShiftID = @"ShiftID";
			 public static string Name = @"Name";
			 public static string StartTime = @"StartTime";
			 public static string EndTime = @"EndTime";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}

		#endregion
	}

}

