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
	/// Strongly-typed collection for the Department class.
	/// </summary>
	[Serializable]
	public partial class DepartmentCollection : ActiveList<Department, DepartmentCollection> 
	{	   
		public DepartmentCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the Department table.
	/// </summary>
	[Serializable]
	public partial class Department : ActiveRecord<Department>
	{
		#region .ctors and Default Settings
		
		public Department()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public Department(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public Department(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public Department(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Department", TableType.Table, DataService.GetInstance("Default"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"HumanResources";
				//columns
				
				TableSchema.TableColumn colvarDepartmentID = new TableSchema.TableColumn(schema);
				colvarDepartmentID.ColumnName = "DepartmentID";
				colvarDepartmentID.DataType = DbType.Int16;
				colvarDepartmentID.MaxLength = 0;
				colvarDepartmentID.AutoIncrement = true;
				colvarDepartmentID.IsNullable = false;
				colvarDepartmentID.IsPrimaryKey = true;
				colvarDepartmentID.IsForeignKey = false;
				colvarDepartmentID.IsReadOnly = false;
				colvarDepartmentID.DefaultSetting = @"";
				colvarDepartmentID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDepartmentID);
				
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
				
				TableSchema.TableColumn colvarGroupName = new TableSchema.TableColumn(schema);
				colvarGroupName.ColumnName = "GroupName";
				colvarGroupName.DataType = DbType.String;
				colvarGroupName.MaxLength = 50;
				colvarGroupName.AutoIncrement = false;
				colvarGroupName.IsNullable = false;
				colvarGroupName.IsPrimaryKey = false;
				colvarGroupName.IsForeignKey = false;
				colvarGroupName.IsReadOnly = false;
				colvarGroupName.DefaultSetting = @"";
				colvarGroupName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGroupName);
				
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
				DataService.Providers["Default"].AddSchema("Department",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("DepartmentID")]
		public short DepartmentID 
		{
			get { return GetColumnValue<short>(Columns.DepartmentID); }

			set { SetColumnValue(Columns.DepartmentID, value); }

		}

		  
		[XmlAttribute("Name")]
		public string Name 
		{
			get { return GetColumnValue<string>(Columns.Name); }

			set { SetColumnValue(Columns.Name, value); }

		}

		  
		[XmlAttribute("GroupName")]
		public string GroupName 
		{
			get { return GetColumnValue<string>(Columns.GroupName); }

			set { SetColumnValue(Columns.GroupName, value); }

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
			return new AVManager.DAL.EmployeeDepartmentHistoryCollection().Where(EmployeeDepartmentHistory.Columns.DepartmentID, DepartmentID).Load();
		}

		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		#region Many To Many Helpers
		
		 
		public AVManager.DAL.EmployeeCollection GetEmployeeCollection() { return Department.GetEmployeeCollection(this.DepartmentID); }

		public static AVManager.DAL.EmployeeCollection GetEmployeeCollection(short varDepartmentID)
		{
			SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
				"SELECT * FROM Employee INNER JOIN EmployeeDepartmentHistory ON "+
				"Employee.EmployeeID=EmployeeDepartmentHistory.EmployeeID WHERE EmployeeDepartmentHistory.DepartmentID=@DepartmentID", Department.Schema.Provider.Name);
			
			cmd.AddParameter("@DepartmentID", varDepartmentID, DbType.Int16);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			EmployeeCollection coll = new EmployeeCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}

		
		public static void SaveEmployeeMap(short varDepartmentID, EmployeeCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM EmployeeDepartmentHistory WHERE DepartmentID=@DepartmentID", Department.Schema.Provider.Name);
			cmdDel.AddParameter("@DepartmentID", varDepartmentID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Employee item in items)
			{
				EmployeeDepartmentHistory varEmployeeDepartmentHistory = new EmployeeDepartmentHistory();
				varEmployeeDepartmentHistory.SetColumnValue("DepartmentID", varDepartmentID);
				varEmployeeDepartmentHistory.SetColumnValue("EmployeeID", item.GetPrimaryKeyValue());
				varEmployeeDepartmentHistory.Save();
			}

		}

		public static void SaveEmployeeMap(short varDepartmentID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM EmployeeDepartmentHistory WHERE DepartmentID=@DepartmentID", Department.Schema.Provider.Name);
			cmdDel.AddParameter("@DepartmentID", varDepartmentID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					EmployeeDepartmentHistory varEmployeeDepartmentHistory = new EmployeeDepartmentHistory();
					varEmployeeDepartmentHistory.SetColumnValue("DepartmentID", varDepartmentID);
					varEmployeeDepartmentHistory.SetColumnValue("EmployeeID", l.Value);
					varEmployeeDepartmentHistory.Save();
				}

			}

		}

		public static void SaveEmployeeMap(short varDepartmentID , short[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM EmployeeDepartmentHistory WHERE DepartmentID=@DepartmentID", Department.Schema.Provider.Name);
			cmdDel.AddParameter("@DepartmentID", varDepartmentID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (short item in itemList) 
			{
				EmployeeDepartmentHistory varEmployeeDepartmentHistory = new EmployeeDepartmentHistory();
				varEmployeeDepartmentHistory.SetColumnValue("DepartmentID", varDepartmentID);
				varEmployeeDepartmentHistory.SetColumnValue("EmployeeID", item);
				varEmployeeDepartmentHistory.Save();
			}

		}

		
		public static void DeleteEmployeeMap(short varDepartmentID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM EmployeeDepartmentHistory WHERE DepartmentID=@DepartmentID", Department.Schema.Provider.Name);
			cmdDel.AddParameter("@DepartmentID", varDepartmentID);
			DataService.ExecuteQuery(cmdDel);
		}

		
		 
		public AVManager.DAL.ShiftCollection GetShiftCollection() { return Department.GetShiftCollection(this.DepartmentID); }

		public static AVManager.DAL.ShiftCollection GetShiftCollection(short varDepartmentID)
		{
			SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
				"SELECT * FROM Shift INNER JOIN EmployeeDepartmentHistory ON "+
				"Shift.ShiftID=EmployeeDepartmentHistory.ShiftID WHERE EmployeeDepartmentHistory.DepartmentID=@DepartmentID", Department.Schema.Provider.Name);
			
			cmd.AddParameter("@DepartmentID", varDepartmentID, DbType.Int16);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			ShiftCollection coll = new ShiftCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}

		
		public static void SaveShiftMap(short varDepartmentID, ShiftCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM EmployeeDepartmentHistory WHERE DepartmentID=@DepartmentID", Department.Schema.Provider.Name);
			cmdDel.AddParameter("@DepartmentID", varDepartmentID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Shift item in items)
			{
				EmployeeDepartmentHistory varEmployeeDepartmentHistory = new EmployeeDepartmentHistory();
				varEmployeeDepartmentHistory.SetColumnValue("DepartmentID", varDepartmentID);
				varEmployeeDepartmentHistory.SetColumnValue("ShiftID", item.GetPrimaryKeyValue());
				varEmployeeDepartmentHistory.Save();
			}

		}

		public static void SaveShiftMap(short varDepartmentID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM EmployeeDepartmentHistory WHERE DepartmentID=@DepartmentID", Department.Schema.Provider.Name);
			cmdDel.AddParameter("@DepartmentID", varDepartmentID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					EmployeeDepartmentHistory varEmployeeDepartmentHistory = new EmployeeDepartmentHistory();
					varEmployeeDepartmentHistory.SetColumnValue("DepartmentID", varDepartmentID);
					varEmployeeDepartmentHistory.SetColumnValue("ShiftID", l.Value);
					varEmployeeDepartmentHistory.Save();
				}

			}

		}

		public static void SaveShiftMap(short varDepartmentID , short[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM EmployeeDepartmentHistory WHERE DepartmentID=@DepartmentID", Department.Schema.Provider.Name);
			cmdDel.AddParameter("@DepartmentID", varDepartmentID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (short item in itemList) 
			{
				EmployeeDepartmentHistory varEmployeeDepartmentHistory = new EmployeeDepartmentHistory();
				varEmployeeDepartmentHistory.SetColumnValue("DepartmentID", varDepartmentID);
				varEmployeeDepartmentHistory.SetColumnValue("ShiftID", item);
				varEmployeeDepartmentHistory.Save();
			}

		}

		
		public static void DeleteShiftMap(short varDepartmentID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM EmployeeDepartmentHistory WHERE DepartmentID=@DepartmentID", Department.Schema.Provider.Name);
			cmdDel.AddParameter("@DepartmentID", varDepartmentID);
			DataService.ExecuteQuery(cmdDel);
		}

		
		#endregion
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varName,string varGroupName,DateTime varModifiedDate)
		{
			Department item = new Department();
			
			item.Name = varName;
			
			item.GroupName = varGroupName;
			
			item.ModifiedDate = varModifiedDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(short varDepartmentID,string varName,string varGroupName,DateTime varModifiedDate)
		{
			Department item = new Department();
			
				item.DepartmentID = varDepartmentID;
			
				item.Name = varName;
			
				item.GroupName = varGroupName;
			
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
			 public static string DepartmentID = @"DepartmentID";
			 public static string Name = @"Name";
			 public static string GroupName = @"GroupName";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}

		#endregion
	}

}

