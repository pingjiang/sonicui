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
	/// Strongly-typed collection for the Employee class.
	/// </summary>
	[Serializable]
	public partial class EmployeeCollection : ActiveList<Employee, EmployeeCollection> 
	{	   
		public EmployeeCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the Employee table.
	/// </summary>
	[Serializable]
	public partial class Employee : ActiveRecord<Employee>
	{
		#region .ctors and Default Settings
		
		public Employee()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public Employee(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public Employee(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public Employee(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Employee", TableType.Table, DataService.GetInstance("Default"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"HumanResources";
				//columns
				
				TableSchema.TableColumn colvarEmployeeID = new TableSchema.TableColumn(schema);
				colvarEmployeeID.ColumnName = "EmployeeID";
				colvarEmployeeID.DataType = DbType.Int32;
				colvarEmployeeID.MaxLength = 0;
				colvarEmployeeID.AutoIncrement = true;
				colvarEmployeeID.IsNullable = false;
				colvarEmployeeID.IsPrimaryKey = true;
				colvarEmployeeID.IsForeignKey = false;
				colvarEmployeeID.IsReadOnly = false;
				colvarEmployeeID.DefaultSetting = @"";
				colvarEmployeeID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarEmployeeID);
				
				TableSchema.TableColumn colvarNationalIDNumber = new TableSchema.TableColumn(schema);
				colvarNationalIDNumber.ColumnName = "NationalIDNumber";
				colvarNationalIDNumber.DataType = DbType.String;
				colvarNationalIDNumber.MaxLength = 15;
				colvarNationalIDNumber.AutoIncrement = false;
				colvarNationalIDNumber.IsNullable = false;
				colvarNationalIDNumber.IsPrimaryKey = false;
				colvarNationalIDNumber.IsForeignKey = false;
				colvarNationalIDNumber.IsReadOnly = false;
				colvarNationalIDNumber.DefaultSetting = @"";
				colvarNationalIDNumber.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNationalIDNumber);
				
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
				
				TableSchema.TableColumn colvarLoginID = new TableSchema.TableColumn(schema);
				colvarLoginID.ColumnName = "LoginID";
				colvarLoginID.DataType = DbType.String;
				colvarLoginID.MaxLength = 256;
				colvarLoginID.AutoIncrement = false;
				colvarLoginID.IsNullable = false;
				colvarLoginID.IsPrimaryKey = false;
				colvarLoginID.IsForeignKey = false;
				colvarLoginID.IsReadOnly = false;
				colvarLoginID.DefaultSetting = @"";
				colvarLoginID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarLoginID);
				
				TableSchema.TableColumn colvarManagerID = new TableSchema.TableColumn(schema);
				colvarManagerID.ColumnName = "ManagerID";
				colvarManagerID.DataType = DbType.Int32;
				colvarManagerID.MaxLength = 0;
				colvarManagerID.AutoIncrement = false;
				colvarManagerID.IsNullable = true;
				colvarManagerID.IsPrimaryKey = false;
				colvarManagerID.IsForeignKey = true;
				colvarManagerID.IsReadOnly = false;
				colvarManagerID.DefaultSetting = @"";
				
					colvarManagerID.ForeignKeyTableName = "Employee";
				schema.Columns.Add(colvarManagerID);
				
				TableSchema.TableColumn colvarTitle = new TableSchema.TableColumn(schema);
				colvarTitle.ColumnName = "Title";
				colvarTitle.DataType = DbType.String;
				colvarTitle.MaxLength = 50;
				colvarTitle.AutoIncrement = false;
				colvarTitle.IsNullable = false;
				colvarTitle.IsPrimaryKey = false;
				colvarTitle.IsForeignKey = false;
				colvarTitle.IsReadOnly = false;
				colvarTitle.DefaultSetting = @"";
				colvarTitle.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTitle);
				
				TableSchema.TableColumn colvarBirthDate = new TableSchema.TableColumn(schema);
				colvarBirthDate.ColumnName = "BirthDate";
				colvarBirthDate.DataType = DbType.DateTime;
				colvarBirthDate.MaxLength = 0;
				colvarBirthDate.AutoIncrement = false;
				colvarBirthDate.IsNullable = false;
				colvarBirthDate.IsPrimaryKey = false;
				colvarBirthDate.IsForeignKey = false;
				colvarBirthDate.IsReadOnly = false;
				colvarBirthDate.DefaultSetting = @"";
				colvarBirthDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarBirthDate);
				
				TableSchema.TableColumn colvarMaritalStatus = new TableSchema.TableColumn(schema);
				colvarMaritalStatus.ColumnName = "MaritalStatus";
				colvarMaritalStatus.DataType = DbType.String;
				colvarMaritalStatus.MaxLength = 1;
				colvarMaritalStatus.AutoIncrement = false;
				colvarMaritalStatus.IsNullable = false;
				colvarMaritalStatus.IsPrimaryKey = false;
				colvarMaritalStatus.IsForeignKey = false;
				colvarMaritalStatus.IsReadOnly = false;
				colvarMaritalStatus.DefaultSetting = @"";
				colvarMaritalStatus.ForeignKeyTableName = "";
				schema.Columns.Add(colvarMaritalStatus);
				
				TableSchema.TableColumn colvarGender = new TableSchema.TableColumn(schema);
				colvarGender.ColumnName = "Gender";
				colvarGender.DataType = DbType.String;
				colvarGender.MaxLength = 1;
				colvarGender.AutoIncrement = false;
				colvarGender.IsNullable = false;
				colvarGender.IsPrimaryKey = false;
				colvarGender.IsForeignKey = false;
				colvarGender.IsReadOnly = false;
				colvarGender.DefaultSetting = @"";
				colvarGender.ForeignKeyTableName = "";
				schema.Columns.Add(colvarGender);
				
				TableSchema.TableColumn colvarHireDate = new TableSchema.TableColumn(schema);
				colvarHireDate.ColumnName = "HireDate";
				colvarHireDate.DataType = DbType.DateTime;
				colvarHireDate.MaxLength = 0;
				colvarHireDate.AutoIncrement = false;
				colvarHireDate.IsNullable = false;
				colvarHireDate.IsPrimaryKey = false;
				colvarHireDate.IsForeignKey = false;
				colvarHireDate.IsReadOnly = false;
				colvarHireDate.DefaultSetting = @"";
				colvarHireDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarHireDate);
				
				TableSchema.TableColumn colvarSalariedFlag = new TableSchema.TableColumn(schema);
				colvarSalariedFlag.ColumnName = "SalariedFlag";
				colvarSalariedFlag.DataType = DbType.Boolean;
				colvarSalariedFlag.MaxLength = 0;
				colvarSalariedFlag.AutoIncrement = false;
				colvarSalariedFlag.IsNullable = false;
				colvarSalariedFlag.IsPrimaryKey = false;
				colvarSalariedFlag.IsForeignKey = false;
				colvarSalariedFlag.IsReadOnly = false;
				
						colvarSalariedFlag.DefaultSetting = @"((1))";
				colvarSalariedFlag.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSalariedFlag);
				
				TableSchema.TableColumn colvarVacationHours = new TableSchema.TableColumn(schema);
				colvarVacationHours.ColumnName = "VacationHours";
				colvarVacationHours.DataType = DbType.Int16;
				colvarVacationHours.MaxLength = 0;
				colvarVacationHours.AutoIncrement = false;
				colvarVacationHours.IsNullable = false;
				colvarVacationHours.IsPrimaryKey = false;
				colvarVacationHours.IsForeignKey = false;
				colvarVacationHours.IsReadOnly = false;
				
						colvarVacationHours.DefaultSetting = @"((0))";
				colvarVacationHours.ForeignKeyTableName = "";
				schema.Columns.Add(colvarVacationHours);
				
				TableSchema.TableColumn colvarSickLeaveHours = new TableSchema.TableColumn(schema);
				colvarSickLeaveHours.ColumnName = "SickLeaveHours";
				colvarSickLeaveHours.DataType = DbType.Int16;
				colvarSickLeaveHours.MaxLength = 0;
				colvarSickLeaveHours.AutoIncrement = false;
				colvarSickLeaveHours.IsNullable = false;
				colvarSickLeaveHours.IsPrimaryKey = false;
				colvarSickLeaveHours.IsForeignKey = false;
				colvarSickLeaveHours.IsReadOnly = false;
				
						colvarSickLeaveHours.DefaultSetting = @"((0))";
				colvarSickLeaveHours.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSickLeaveHours);
				
				TableSchema.TableColumn colvarCurrentFlag = new TableSchema.TableColumn(schema);
				colvarCurrentFlag.ColumnName = "CurrentFlag";
				colvarCurrentFlag.DataType = DbType.Boolean;
				colvarCurrentFlag.MaxLength = 0;
				colvarCurrentFlag.AutoIncrement = false;
				colvarCurrentFlag.IsNullable = false;
				colvarCurrentFlag.IsPrimaryKey = false;
				colvarCurrentFlag.IsForeignKey = false;
				colvarCurrentFlag.IsReadOnly = false;
				
						colvarCurrentFlag.DefaultSetting = @"((1))";
				colvarCurrentFlag.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCurrentFlag);
				
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
				DataService.Providers["Default"].AddSchema("Employee",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("EmployeeID")]
		public int EmployeeID 
		{
			get { return GetColumnValue<int>(Columns.EmployeeID); }

			set { SetColumnValue(Columns.EmployeeID, value); }

		}

		  
		[XmlAttribute("NationalIDNumber")]
		public string NationalIDNumber 
		{
			get { return GetColumnValue<string>(Columns.NationalIDNumber); }

			set { SetColumnValue(Columns.NationalIDNumber, value); }

		}

		  
		[XmlAttribute("ContactID")]
		public int ContactID 
		{
			get { return GetColumnValue<int>(Columns.ContactID); }

			set { SetColumnValue(Columns.ContactID, value); }

		}

		  
		[XmlAttribute("LoginID")]
		public string LoginID 
		{
			get { return GetColumnValue<string>(Columns.LoginID); }

			set { SetColumnValue(Columns.LoginID, value); }

		}

		  
		[XmlAttribute("ManagerID")]
		public int? ManagerID 
		{
			get { return GetColumnValue<int?>(Columns.ManagerID); }

			set { SetColumnValue(Columns.ManagerID, value); }

		}

		  
		[XmlAttribute("Title")]
		public string Title 
		{
			get { return GetColumnValue<string>(Columns.Title); }

			set { SetColumnValue(Columns.Title, value); }

		}

		  
		[XmlAttribute("BirthDate")]
		public DateTime BirthDate 
		{
			get { return GetColumnValue<DateTime>(Columns.BirthDate); }

			set { SetColumnValue(Columns.BirthDate, value); }

		}

		  
		[XmlAttribute("MaritalStatus")]
		public string MaritalStatus 
		{
			get { return GetColumnValue<string>(Columns.MaritalStatus); }

			set { SetColumnValue(Columns.MaritalStatus, value); }

		}

		  
		[XmlAttribute("Gender")]
		public string Gender 
		{
			get { return GetColumnValue<string>(Columns.Gender); }

			set { SetColumnValue(Columns.Gender, value); }

		}

		  
		[XmlAttribute("HireDate")]
		public DateTime HireDate 
		{
			get { return GetColumnValue<DateTime>(Columns.HireDate); }

			set { SetColumnValue(Columns.HireDate, value); }

		}

		  
		[XmlAttribute("SalariedFlag")]
		public bool SalariedFlag 
		{
			get { return GetColumnValue<bool>(Columns.SalariedFlag); }

			set { SetColumnValue(Columns.SalariedFlag, value); }

		}

		  
		[XmlAttribute("VacationHours")]
		public short VacationHours 
		{
			get { return GetColumnValue<short>(Columns.VacationHours); }

			set { SetColumnValue(Columns.VacationHours, value); }

		}

		  
		[XmlAttribute("SickLeaveHours")]
		public short SickLeaveHours 
		{
			get { return GetColumnValue<short>(Columns.SickLeaveHours); }

			set { SetColumnValue(Columns.SickLeaveHours, value); }

		}

		  
		[XmlAttribute("CurrentFlag")]
		public bool CurrentFlag 
		{
			get { return GetColumnValue<bool>(Columns.CurrentFlag); }

			set { SetColumnValue(Columns.CurrentFlag, value); }

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
		
		public AVManager.DAL.EmployeeCollection ChildEmployeeRecords()
		{
			return new AVManager.DAL.EmployeeCollection().Where(Employee.Columns.ManagerID, EmployeeID).Load();
		}

		public AVManager.DAL.EmployeeAddressCollection EmployeeAddressRecords()
		{
			return new AVManager.DAL.EmployeeAddressCollection().Where(EmployeeAddress.Columns.EmployeeID, EmployeeID).Load();
		}

		public AVManager.DAL.EmployeeDepartmentHistoryCollection EmployeeDepartmentHistoryRecords()
		{
			return new AVManager.DAL.EmployeeDepartmentHistoryCollection().Where(EmployeeDepartmentHistory.Columns.EmployeeID, EmployeeID).Load();
		}

		public AVManager.DAL.EmployeePayHistoryCollection EmployeePayHistoryRecords()
		{
			return new AVManager.DAL.EmployeePayHistoryCollection().Where(EmployeePayHistory.Columns.EmployeeID, EmployeeID).Load();
		}

		public AVManager.DAL.JobCandidateCollection JobCandidateRecords()
		{
			return new AVManager.DAL.JobCandidateCollection().Where(JobCandidate.Columns.EmployeeID, EmployeeID).Load();
		}

		public AVManager.DAL.PurchaseOrderHeaderCollection PurchaseOrderHeaderRecords()
		{
			return new AVManager.DAL.PurchaseOrderHeaderCollection().Where(PurchaseOrderHeader.Columns.EmployeeID, EmployeeID).Load();
		}

		public AVManager.DAL.SalesPersonCollection SalesPersonRecords()
		{
			return new AVManager.DAL.SalesPersonCollection().Where(SalesPerson.Columns.SalesPersonID, EmployeeID).Load();
		}

		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a Employee ActiveRecord object related to this Employee
		/// 
		/// </summary>
		public AVManager.DAL.Employee ParentEmployee
		{
			get { return AVManager.DAL.Employee.FetchByID(this.ManagerID); }

			set { SetColumnValue("ManagerID", value.EmployeeID); }

		}

		
		
		/// <summary>
		/// Returns a Contact ActiveRecord object related to this Employee
		/// 
		/// </summary>
		public AVManager.DAL.Contact Contact
		{
			get { return AVManager.DAL.Contact.FetchByID(this.ContactID); }

			set { SetColumnValue("ContactID", value.ContactID); }

		}

		
		
		#endregion
		
		
		
		#region Many To Many Helpers
		
		 
		public AVManager.DAL.AddressCollection GetAddressCollection() { return Employee.GetAddressCollection(this.EmployeeID); }

		public static AVManager.DAL.AddressCollection GetAddressCollection(int varEmployeeID)
		{
			SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
				"SELECT * FROM Address INNER JOIN EmployeeAddress ON "+
				"Address.AddressID=EmployeeAddress.AddressID WHERE EmployeeAddress.EmployeeID=@EmployeeID", Employee.Schema.Provider.Name);
			
			cmd.AddParameter("@EmployeeID", varEmployeeID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			AddressCollection coll = new AddressCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}

		
		public static void SaveAddressMap(int varEmployeeID, AddressCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM EmployeeAddress WHERE EmployeeID=@EmployeeID", Employee.Schema.Provider.Name);
			cmdDel.AddParameter("@EmployeeID", varEmployeeID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Address item in items)
			{
				EmployeeAddress varEmployeeAddress = new EmployeeAddress();
				varEmployeeAddress.SetColumnValue("EmployeeID", varEmployeeID);
				varEmployeeAddress.SetColumnValue("AddressID", item.GetPrimaryKeyValue());
				varEmployeeAddress.Save();
			}

		}

		public static void SaveAddressMap(int varEmployeeID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM EmployeeAddress WHERE EmployeeID=@EmployeeID", Employee.Schema.Provider.Name);
			cmdDel.AddParameter("@EmployeeID", varEmployeeID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					EmployeeAddress varEmployeeAddress = new EmployeeAddress();
					varEmployeeAddress.SetColumnValue("EmployeeID", varEmployeeID);
					varEmployeeAddress.SetColumnValue("AddressID", l.Value);
					varEmployeeAddress.Save();
				}

			}

		}

		public static void SaveAddressMap(int varEmployeeID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM EmployeeAddress WHERE EmployeeID=@EmployeeID", Employee.Schema.Provider.Name);
			cmdDel.AddParameter("@EmployeeID", varEmployeeID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				EmployeeAddress varEmployeeAddress = new EmployeeAddress();
				varEmployeeAddress.SetColumnValue("EmployeeID", varEmployeeID);
				varEmployeeAddress.SetColumnValue("AddressID", item);
				varEmployeeAddress.Save();
			}

		}

		
		public static void DeleteAddressMap(int varEmployeeID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM EmployeeAddress WHERE EmployeeID=@EmployeeID", Employee.Schema.Provider.Name);
			cmdDel.AddParameter("@EmployeeID", varEmployeeID);
			DataService.ExecuteQuery(cmdDel);
		}

		
		 
		public AVManager.DAL.DepartmentCollection GetDepartmentCollection() { return Employee.GetDepartmentCollection(this.EmployeeID); }

		public static AVManager.DAL.DepartmentCollection GetDepartmentCollection(int varEmployeeID)
		{
			SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
				"SELECT * FROM Department INNER JOIN EmployeeDepartmentHistory ON "+
				"Department.DepartmentID=EmployeeDepartmentHistory.DepartmentID WHERE EmployeeDepartmentHistory.EmployeeID=@EmployeeID", Employee.Schema.Provider.Name);
			
			cmd.AddParameter("@EmployeeID", varEmployeeID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			DepartmentCollection coll = new DepartmentCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}

		
		public static void SaveDepartmentMap(int varEmployeeID, DepartmentCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM EmployeeDepartmentHistory WHERE EmployeeID=@EmployeeID", Employee.Schema.Provider.Name);
			cmdDel.AddParameter("@EmployeeID", varEmployeeID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Department item in items)
			{
				EmployeeDepartmentHistory varEmployeeDepartmentHistory = new EmployeeDepartmentHistory();
				varEmployeeDepartmentHistory.SetColumnValue("EmployeeID", varEmployeeID);
				varEmployeeDepartmentHistory.SetColumnValue("DepartmentID", item.GetPrimaryKeyValue());
				varEmployeeDepartmentHistory.Save();
			}

		}

		public static void SaveDepartmentMap(int varEmployeeID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM EmployeeDepartmentHistory WHERE EmployeeID=@EmployeeID", Employee.Schema.Provider.Name);
			cmdDel.AddParameter("@EmployeeID", varEmployeeID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					EmployeeDepartmentHistory varEmployeeDepartmentHistory = new EmployeeDepartmentHistory();
					varEmployeeDepartmentHistory.SetColumnValue("EmployeeID", varEmployeeID);
					varEmployeeDepartmentHistory.SetColumnValue("DepartmentID", l.Value);
					varEmployeeDepartmentHistory.Save();
				}

			}

		}

		public static void SaveDepartmentMap(int varEmployeeID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM EmployeeDepartmentHistory WHERE EmployeeID=@EmployeeID", Employee.Schema.Provider.Name);
			cmdDel.AddParameter("@EmployeeID", varEmployeeID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				EmployeeDepartmentHistory varEmployeeDepartmentHistory = new EmployeeDepartmentHistory();
				varEmployeeDepartmentHistory.SetColumnValue("EmployeeID", varEmployeeID);
				varEmployeeDepartmentHistory.SetColumnValue("DepartmentID", item);
				varEmployeeDepartmentHistory.Save();
			}

		}

		
		public static void DeleteDepartmentMap(int varEmployeeID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM EmployeeDepartmentHistory WHERE EmployeeID=@EmployeeID", Employee.Schema.Provider.Name);
			cmdDel.AddParameter("@EmployeeID", varEmployeeID);
			DataService.ExecuteQuery(cmdDel);
		}

		
		 
		public AVManager.DAL.ShiftCollection GetShiftCollection() { return Employee.GetShiftCollection(this.EmployeeID); }

		public static AVManager.DAL.ShiftCollection GetShiftCollection(int varEmployeeID)
		{
			SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
				"SELECT * FROM Shift INNER JOIN EmployeeDepartmentHistory ON "+
				"Shift.ShiftID=EmployeeDepartmentHistory.ShiftID WHERE EmployeeDepartmentHistory.EmployeeID=@EmployeeID", Employee.Schema.Provider.Name);
			
			cmd.AddParameter("@EmployeeID", varEmployeeID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			ShiftCollection coll = new ShiftCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}

		
		public static void SaveShiftMap(int varEmployeeID, ShiftCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM EmployeeDepartmentHistory WHERE EmployeeID=@EmployeeID", Employee.Schema.Provider.Name);
			cmdDel.AddParameter("@EmployeeID", varEmployeeID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Shift item in items)
			{
				EmployeeDepartmentHistory varEmployeeDepartmentHistory = new EmployeeDepartmentHistory();
				varEmployeeDepartmentHistory.SetColumnValue("EmployeeID", varEmployeeID);
				varEmployeeDepartmentHistory.SetColumnValue("ShiftID", item.GetPrimaryKeyValue());
				varEmployeeDepartmentHistory.Save();
			}

		}

		public static void SaveShiftMap(int varEmployeeID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM EmployeeDepartmentHistory WHERE EmployeeID=@EmployeeID", Employee.Schema.Provider.Name);
			cmdDel.AddParameter("@EmployeeID", varEmployeeID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					EmployeeDepartmentHistory varEmployeeDepartmentHistory = new EmployeeDepartmentHistory();
					varEmployeeDepartmentHistory.SetColumnValue("EmployeeID", varEmployeeID);
					varEmployeeDepartmentHistory.SetColumnValue("ShiftID", l.Value);
					varEmployeeDepartmentHistory.Save();
				}

			}

		}

		public static void SaveShiftMap(int varEmployeeID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM EmployeeDepartmentHistory WHERE EmployeeID=@EmployeeID", Employee.Schema.Provider.Name);
			cmdDel.AddParameter("@EmployeeID", varEmployeeID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				EmployeeDepartmentHistory varEmployeeDepartmentHistory = new EmployeeDepartmentHistory();
				varEmployeeDepartmentHistory.SetColumnValue("EmployeeID", varEmployeeID);
				varEmployeeDepartmentHistory.SetColumnValue("ShiftID", item);
				varEmployeeDepartmentHistory.Save();
			}

		}

		
		public static void DeleteShiftMap(int varEmployeeID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM EmployeeDepartmentHistory WHERE EmployeeID=@EmployeeID", Employee.Schema.Provider.Name);
			cmdDel.AddParameter("@EmployeeID", varEmployeeID);
			DataService.ExecuteQuery(cmdDel);
		}

		
		#endregion
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varNationalIDNumber,int varContactID,string varLoginID,int? varManagerID,string varTitle,DateTime varBirthDate,string varMaritalStatus,string varGender,DateTime varHireDate,bool varSalariedFlag,short varVacationHours,short varSickLeaveHours,bool varCurrentFlag,Guid varRowguid,DateTime varModifiedDate)
		{
			Employee item = new Employee();
			
			item.NationalIDNumber = varNationalIDNumber;
			
			item.ContactID = varContactID;
			
			item.LoginID = varLoginID;
			
			item.ManagerID = varManagerID;
			
			item.Title = varTitle;
			
			item.BirthDate = varBirthDate;
			
			item.MaritalStatus = varMaritalStatus;
			
			item.Gender = varGender;
			
			item.HireDate = varHireDate;
			
			item.SalariedFlag = varSalariedFlag;
			
			item.VacationHours = varVacationHours;
			
			item.SickLeaveHours = varSickLeaveHours;
			
			item.CurrentFlag = varCurrentFlag;
			
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
		public static void Update(int varEmployeeID,string varNationalIDNumber,int varContactID,string varLoginID,int? varManagerID,string varTitle,DateTime varBirthDate,string varMaritalStatus,string varGender,DateTime varHireDate,bool varSalariedFlag,short varVacationHours,short varSickLeaveHours,bool varCurrentFlag,Guid varRowguid,DateTime varModifiedDate)
		{
			Employee item = new Employee();
			
				item.EmployeeID = varEmployeeID;
			
				item.NationalIDNumber = varNationalIDNumber;
			
				item.ContactID = varContactID;
			
				item.LoginID = varLoginID;
			
				item.ManagerID = varManagerID;
			
				item.Title = varTitle;
			
				item.BirthDate = varBirthDate;
			
				item.MaritalStatus = varMaritalStatus;
			
				item.Gender = varGender;
			
				item.HireDate = varHireDate;
			
				item.SalariedFlag = varSalariedFlag;
			
				item.VacationHours = varVacationHours;
			
				item.SickLeaveHours = varSickLeaveHours;
			
				item.CurrentFlag = varCurrentFlag;
			
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
			 public static string EmployeeID = @"EmployeeID";
			 public static string NationalIDNumber = @"NationalIDNumber";
			 public static string ContactID = @"ContactID";
			 public static string LoginID = @"LoginID";
			 public static string ManagerID = @"ManagerID";
			 public static string Title = @"Title";
			 public static string BirthDate = @"BirthDate";
			 public static string MaritalStatus = @"MaritalStatus";
			 public static string Gender = @"Gender";
			 public static string HireDate = @"HireDate";
			 public static string SalariedFlag = @"SalariedFlag";
			 public static string VacationHours = @"VacationHours";
			 public static string SickLeaveHours = @"SickLeaveHours";
			 public static string CurrentFlag = @"CurrentFlag";
			 public static string Rowguid = @"rowguid";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}

		#endregion
	}

}

