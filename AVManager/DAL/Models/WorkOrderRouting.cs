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
	/// Strongly-typed collection for the WorkOrderRouting class.
	/// </summary>
	[Serializable]
	public partial class WorkOrderRoutingCollection : ActiveList<WorkOrderRouting, WorkOrderRoutingCollection> 
	{	   
		public WorkOrderRoutingCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the WorkOrderRouting table.
	/// </summary>
	[Serializable]
	public partial class WorkOrderRouting : ActiveRecord<WorkOrderRouting>
	{
		#region .ctors and Default Settings
		
		public WorkOrderRouting()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public WorkOrderRouting(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public WorkOrderRouting(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public WorkOrderRouting(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("WorkOrderRouting", TableType.Table, DataService.GetInstance("Default"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Production";
				//columns
				
				TableSchema.TableColumn colvarWorkOrderID = new TableSchema.TableColumn(schema);
				colvarWorkOrderID.ColumnName = "WorkOrderID";
				colvarWorkOrderID.DataType = DbType.Int32;
				colvarWorkOrderID.MaxLength = 0;
				colvarWorkOrderID.AutoIncrement = false;
				colvarWorkOrderID.IsNullable = false;
				colvarWorkOrderID.IsPrimaryKey = true;
				colvarWorkOrderID.IsForeignKey = true;
				colvarWorkOrderID.IsReadOnly = false;
				colvarWorkOrderID.DefaultSetting = @"";
				
					colvarWorkOrderID.ForeignKeyTableName = "WorkOrder";
				schema.Columns.Add(colvarWorkOrderID);
				
				TableSchema.TableColumn colvarProductID = new TableSchema.TableColumn(schema);
				colvarProductID.ColumnName = "ProductID";
				colvarProductID.DataType = DbType.Int32;
				colvarProductID.MaxLength = 0;
				colvarProductID.AutoIncrement = false;
				colvarProductID.IsNullable = false;
				colvarProductID.IsPrimaryKey = true;
				colvarProductID.IsForeignKey = false;
				colvarProductID.IsReadOnly = false;
				colvarProductID.DefaultSetting = @"";
				colvarProductID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProductID);
				
				TableSchema.TableColumn colvarOperationSequence = new TableSchema.TableColumn(schema);
				colvarOperationSequence.ColumnName = "OperationSequence";
				colvarOperationSequence.DataType = DbType.Int16;
				colvarOperationSequence.MaxLength = 0;
				colvarOperationSequence.AutoIncrement = false;
				colvarOperationSequence.IsNullable = false;
				colvarOperationSequence.IsPrimaryKey = true;
				colvarOperationSequence.IsForeignKey = false;
				colvarOperationSequence.IsReadOnly = false;
				colvarOperationSequence.DefaultSetting = @"";
				colvarOperationSequence.ForeignKeyTableName = "";
				schema.Columns.Add(colvarOperationSequence);
				
				TableSchema.TableColumn colvarLocationID = new TableSchema.TableColumn(schema);
				colvarLocationID.ColumnName = "LocationID";
				colvarLocationID.DataType = DbType.Int16;
				colvarLocationID.MaxLength = 0;
				colvarLocationID.AutoIncrement = false;
				colvarLocationID.IsNullable = false;
				colvarLocationID.IsPrimaryKey = false;
				colvarLocationID.IsForeignKey = true;
				colvarLocationID.IsReadOnly = false;
				colvarLocationID.DefaultSetting = @"";
				
					colvarLocationID.ForeignKeyTableName = "Location";
				schema.Columns.Add(colvarLocationID);
				
				TableSchema.TableColumn colvarScheduledStartDate = new TableSchema.TableColumn(schema);
				colvarScheduledStartDate.ColumnName = "ScheduledStartDate";
				colvarScheduledStartDate.DataType = DbType.DateTime;
				colvarScheduledStartDate.MaxLength = 0;
				colvarScheduledStartDate.AutoIncrement = false;
				colvarScheduledStartDate.IsNullable = false;
				colvarScheduledStartDate.IsPrimaryKey = false;
				colvarScheduledStartDate.IsForeignKey = false;
				colvarScheduledStartDate.IsReadOnly = false;
				colvarScheduledStartDate.DefaultSetting = @"";
				colvarScheduledStartDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarScheduledStartDate);
				
				TableSchema.TableColumn colvarScheduledEndDate = new TableSchema.TableColumn(schema);
				colvarScheduledEndDate.ColumnName = "ScheduledEndDate";
				colvarScheduledEndDate.DataType = DbType.DateTime;
				colvarScheduledEndDate.MaxLength = 0;
				colvarScheduledEndDate.AutoIncrement = false;
				colvarScheduledEndDate.IsNullable = false;
				colvarScheduledEndDate.IsPrimaryKey = false;
				colvarScheduledEndDate.IsForeignKey = false;
				colvarScheduledEndDate.IsReadOnly = false;
				colvarScheduledEndDate.DefaultSetting = @"";
				colvarScheduledEndDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarScheduledEndDate);
				
				TableSchema.TableColumn colvarActualStartDate = new TableSchema.TableColumn(schema);
				colvarActualStartDate.ColumnName = "ActualStartDate";
				colvarActualStartDate.DataType = DbType.DateTime;
				colvarActualStartDate.MaxLength = 0;
				colvarActualStartDate.AutoIncrement = false;
				colvarActualStartDate.IsNullable = true;
				colvarActualStartDate.IsPrimaryKey = false;
				colvarActualStartDate.IsForeignKey = false;
				colvarActualStartDate.IsReadOnly = false;
				colvarActualStartDate.DefaultSetting = @"";
				colvarActualStartDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarActualStartDate);
				
				TableSchema.TableColumn colvarActualEndDate = new TableSchema.TableColumn(schema);
				colvarActualEndDate.ColumnName = "ActualEndDate";
				colvarActualEndDate.DataType = DbType.DateTime;
				colvarActualEndDate.MaxLength = 0;
				colvarActualEndDate.AutoIncrement = false;
				colvarActualEndDate.IsNullable = true;
				colvarActualEndDate.IsPrimaryKey = false;
				colvarActualEndDate.IsForeignKey = false;
				colvarActualEndDate.IsReadOnly = false;
				colvarActualEndDate.DefaultSetting = @"";
				colvarActualEndDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarActualEndDate);
				
				TableSchema.TableColumn colvarActualResourceHrs = new TableSchema.TableColumn(schema);
				colvarActualResourceHrs.ColumnName = "ActualResourceHrs";
				colvarActualResourceHrs.DataType = DbType.Decimal;
				colvarActualResourceHrs.MaxLength = 0;
				colvarActualResourceHrs.AutoIncrement = false;
				colvarActualResourceHrs.IsNullable = true;
				colvarActualResourceHrs.IsPrimaryKey = false;
				colvarActualResourceHrs.IsForeignKey = false;
				colvarActualResourceHrs.IsReadOnly = false;
				colvarActualResourceHrs.DefaultSetting = @"";
				colvarActualResourceHrs.ForeignKeyTableName = "";
				schema.Columns.Add(colvarActualResourceHrs);
				
				TableSchema.TableColumn colvarPlannedCost = new TableSchema.TableColumn(schema);
				colvarPlannedCost.ColumnName = "PlannedCost";
				colvarPlannedCost.DataType = DbType.Currency;
				colvarPlannedCost.MaxLength = 0;
				colvarPlannedCost.AutoIncrement = false;
				colvarPlannedCost.IsNullable = false;
				colvarPlannedCost.IsPrimaryKey = false;
				colvarPlannedCost.IsForeignKey = false;
				colvarPlannedCost.IsReadOnly = false;
				colvarPlannedCost.DefaultSetting = @"";
				colvarPlannedCost.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPlannedCost);
				
				TableSchema.TableColumn colvarActualCost = new TableSchema.TableColumn(schema);
				colvarActualCost.ColumnName = "ActualCost";
				colvarActualCost.DataType = DbType.Currency;
				colvarActualCost.MaxLength = 0;
				colvarActualCost.AutoIncrement = false;
				colvarActualCost.IsNullable = true;
				colvarActualCost.IsPrimaryKey = false;
				colvarActualCost.IsForeignKey = false;
				colvarActualCost.IsReadOnly = false;
				colvarActualCost.DefaultSetting = @"";
				colvarActualCost.ForeignKeyTableName = "";
				schema.Columns.Add(colvarActualCost);
				
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
				DataService.Providers["Default"].AddSchema("WorkOrderRouting",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("WorkOrderID")]
		public int WorkOrderID 
		{
			get { return GetColumnValue<int>(Columns.WorkOrderID); }

			set { SetColumnValue(Columns.WorkOrderID, value); }

		}

		  
		[XmlAttribute("ProductID")]
		public int ProductID 
		{
			get { return GetColumnValue<int>(Columns.ProductID); }

			set { SetColumnValue(Columns.ProductID, value); }

		}

		  
		[XmlAttribute("OperationSequence")]
		public short OperationSequence 
		{
			get { return GetColumnValue<short>(Columns.OperationSequence); }

			set { SetColumnValue(Columns.OperationSequence, value); }

		}

		  
		[XmlAttribute("LocationID")]
		public short LocationID 
		{
			get { return GetColumnValue<short>(Columns.LocationID); }

			set { SetColumnValue(Columns.LocationID, value); }

		}

		  
		[XmlAttribute("ScheduledStartDate")]
		public DateTime ScheduledStartDate 
		{
			get { return GetColumnValue<DateTime>(Columns.ScheduledStartDate); }

			set { SetColumnValue(Columns.ScheduledStartDate, value); }

		}

		  
		[XmlAttribute("ScheduledEndDate")]
		public DateTime ScheduledEndDate 
		{
			get { return GetColumnValue<DateTime>(Columns.ScheduledEndDate); }

			set { SetColumnValue(Columns.ScheduledEndDate, value); }

		}

		  
		[XmlAttribute("ActualStartDate")]
		public DateTime? ActualStartDate 
		{
			get { return GetColumnValue<DateTime?>(Columns.ActualStartDate); }

			set { SetColumnValue(Columns.ActualStartDate, value); }

		}

		  
		[XmlAttribute("ActualEndDate")]
		public DateTime? ActualEndDate 
		{
			get { return GetColumnValue<DateTime?>(Columns.ActualEndDate); }

			set { SetColumnValue(Columns.ActualEndDate, value); }

		}

		  
		[XmlAttribute("ActualResourceHrs")]
		public decimal? ActualResourceHrs 
		{
			get { return GetColumnValue<decimal?>(Columns.ActualResourceHrs); }

			set { SetColumnValue(Columns.ActualResourceHrs, value); }

		}

		  
		[XmlAttribute("PlannedCost")]
		public decimal PlannedCost 
		{
			get { return GetColumnValue<decimal>(Columns.PlannedCost); }

			set { SetColumnValue(Columns.PlannedCost, value); }

		}

		  
		[XmlAttribute("ActualCost")]
		public decimal? ActualCost 
		{
			get { return GetColumnValue<decimal?>(Columns.ActualCost); }

			set { SetColumnValue(Columns.ActualCost, value); }

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
		/// Returns a Location ActiveRecord object related to this WorkOrderRouting
		/// 
		/// </summary>
		public AVManager.DAL.Location Location
		{
			get { return AVManager.DAL.Location.FetchByID(this.LocationID); }

			set { SetColumnValue("LocationID", value.LocationID); }

		}

		
		
		/// <summary>
		/// Returns a WorkOrder ActiveRecord object related to this WorkOrderRouting
		/// 
		/// </summary>
		public AVManager.DAL.WorkOrder WorkOrder
		{
			get { return AVManager.DAL.WorkOrder.FetchByID(this.WorkOrderID); }

			set { SetColumnValue("WorkOrderID", value.WorkOrderID); }

		}

		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varWorkOrderID,int varProductID,short varOperationSequence,short varLocationID,DateTime varScheduledStartDate,DateTime varScheduledEndDate,DateTime? varActualStartDate,DateTime? varActualEndDate,decimal? varActualResourceHrs,decimal varPlannedCost,decimal? varActualCost,DateTime varModifiedDate)
		{
			WorkOrderRouting item = new WorkOrderRouting();
			
			item.WorkOrderID = varWorkOrderID;
			
			item.ProductID = varProductID;
			
			item.OperationSequence = varOperationSequence;
			
			item.LocationID = varLocationID;
			
			item.ScheduledStartDate = varScheduledStartDate;
			
			item.ScheduledEndDate = varScheduledEndDate;
			
			item.ActualStartDate = varActualStartDate;
			
			item.ActualEndDate = varActualEndDate;
			
			item.ActualResourceHrs = varActualResourceHrs;
			
			item.PlannedCost = varPlannedCost;
			
			item.ActualCost = varActualCost;
			
			item.ModifiedDate = varModifiedDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varWorkOrderID,int varProductID,short varOperationSequence,short varLocationID,DateTime varScheduledStartDate,DateTime varScheduledEndDate,DateTime? varActualStartDate,DateTime? varActualEndDate,decimal? varActualResourceHrs,decimal varPlannedCost,decimal? varActualCost,DateTime varModifiedDate)
		{
			WorkOrderRouting item = new WorkOrderRouting();
			
				item.WorkOrderID = varWorkOrderID;
			
				item.ProductID = varProductID;
			
				item.OperationSequence = varOperationSequence;
			
				item.LocationID = varLocationID;
			
				item.ScheduledStartDate = varScheduledStartDate;
			
				item.ScheduledEndDate = varScheduledEndDate;
			
				item.ActualStartDate = varActualStartDate;
			
				item.ActualEndDate = varActualEndDate;
			
				item.ActualResourceHrs = varActualResourceHrs;
			
				item.PlannedCost = varPlannedCost;
			
				item.ActualCost = varActualCost;
			
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
			 public static string WorkOrderID = @"WorkOrderID";
			 public static string ProductID = @"ProductID";
			 public static string OperationSequence = @"OperationSequence";
			 public static string LocationID = @"LocationID";
			 public static string ScheduledStartDate = @"ScheduledStartDate";
			 public static string ScheduledEndDate = @"ScheduledEndDate";
			 public static string ActualStartDate = @"ActualStartDate";
			 public static string ActualEndDate = @"ActualEndDate";
			 public static string ActualResourceHrs = @"ActualResourceHrs";
			 public static string PlannedCost = @"PlannedCost";
			 public static string ActualCost = @"ActualCost";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}

		#endregion
	}

}

