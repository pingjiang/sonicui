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
	/// Strongly-typed collection for the TransactionHistoryArchive class.
	/// </summary>
	[Serializable]
	public partial class TransactionHistoryArchiveCollection : ActiveList<TransactionHistoryArchive, TransactionHistoryArchiveCollection> 
	{	   
		public TransactionHistoryArchiveCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the TransactionHistoryArchive table.
	/// </summary>
	[Serializable]
	public partial class TransactionHistoryArchive : ActiveRecord<TransactionHistoryArchive>
	{
		#region .ctors and Default Settings
		
		public TransactionHistoryArchive()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public TransactionHistoryArchive(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public TransactionHistoryArchive(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public TransactionHistoryArchive(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("TransactionHistoryArchive", TableType.Table, DataService.GetInstance("Default"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Production";
				//columns
				
				TableSchema.TableColumn colvarTransactionID = new TableSchema.TableColumn(schema);
				colvarTransactionID.ColumnName = "TransactionID";
				colvarTransactionID.DataType = DbType.Int32;
				colvarTransactionID.MaxLength = 0;
				colvarTransactionID.AutoIncrement = false;
				colvarTransactionID.IsNullable = false;
				colvarTransactionID.IsPrimaryKey = true;
				colvarTransactionID.IsForeignKey = false;
				colvarTransactionID.IsReadOnly = false;
				colvarTransactionID.DefaultSetting = @"";
				colvarTransactionID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTransactionID);
				
				TableSchema.TableColumn colvarProductID = new TableSchema.TableColumn(schema);
				colvarProductID.ColumnName = "ProductID";
				colvarProductID.DataType = DbType.Int32;
				colvarProductID.MaxLength = 0;
				colvarProductID.AutoIncrement = false;
				colvarProductID.IsNullable = false;
				colvarProductID.IsPrimaryKey = false;
				colvarProductID.IsForeignKey = false;
				colvarProductID.IsReadOnly = false;
				colvarProductID.DefaultSetting = @"";
				colvarProductID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarProductID);
				
				TableSchema.TableColumn colvarReferenceOrderID = new TableSchema.TableColumn(schema);
				colvarReferenceOrderID.ColumnName = "ReferenceOrderID";
				colvarReferenceOrderID.DataType = DbType.Int32;
				colvarReferenceOrderID.MaxLength = 0;
				colvarReferenceOrderID.AutoIncrement = false;
				colvarReferenceOrderID.IsNullable = false;
				colvarReferenceOrderID.IsPrimaryKey = false;
				colvarReferenceOrderID.IsForeignKey = false;
				colvarReferenceOrderID.IsReadOnly = false;
				colvarReferenceOrderID.DefaultSetting = @"";
				colvarReferenceOrderID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarReferenceOrderID);
				
				TableSchema.TableColumn colvarReferenceOrderLineID = new TableSchema.TableColumn(schema);
				colvarReferenceOrderLineID.ColumnName = "ReferenceOrderLineID";
				colvarReferenceOrderLineID.DataType = DbType.Int32;
				colvarReferenceOrderLineID.MaxLength = 0;
				colvarReferenceOrderLineID.AutoIncrement = false;
				colvarReferenceOrderLineID.IsNullable = false;
				colvarReferenceOrderLineID.IsPrimaryKey = false;
				colvarReferenceOrderLineID.IsForeignKey = false;
				colvarReferenceOrderLineID.IsReadOnly = false;
				
						colvarReferenceOrderLineID.DefaultSetting = @"((0))";
				colvarReferenceOrderLineID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarReferenceOrderLineID);
				
				TableSchema.TableColumn colvarTransactionDate = new TableSchema.TableColumn(schema);
				colvarTransactionDate.ColumnName = "TransactionDate";
				colvarTransactionDate.DataType = DbType.DateTime;
				colvarTransactionDate.MaxLength = 0;
				colvarTransactionDate.AutoIncrement = false;
				colvarTransactionDate.IsNullable = false;
				colvarTransactionDate.IsPrimaryKey = false;
				colvarTransactionDate.IsForeignKey = false;
				colvarTransactionDate.IsReadOnly = false;
				
						colvarTransactionDate.DefaultSetting = @"(getdate())";
				colvarTransactionDate.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTransactionDate);
				
				TableSchema.TableColumn colvarTransactionType = new TableSchema.TableColumn(schema);
				colvarTransactionType.ColumnName = "TransactionType";
				colvarTransactionType.DataType = DbType.String;
				colvarTransactionType.MaxLength = 1;
				colvarTransactionType.AutoIncrement = false;
				colvarTransactionType.IsNullable = false;
				colvarTransactionType.IsPrimaryKey = false;
				colvarTransactionType.IsForeignKey = false;
				colvarTransactionType.IsReadOnly = false;
				colvarTransactionType.DefaultSetting = @"";
				colvarTransactionType.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTransactionType);
				
				TableSchema.TableColumn colvarQuantity = new TableSchema.TableColumn(schema);
				colvarQuantity.ColumnName = "Quantity";
				colvarQuantity.DataType = DbType.Int32;
				colvarQuantity.MaxLength = 0;
				colvarQuantity.AutoIncrement = false;
				colvarQuantity.IsNullable = false;
				colvarQuantity.IsPrimaryKey = false;
				colvarQuantity.IsForeignKey = false;
				colvarQuantity.IsReadOnly = false;
				colvarQuantity.DefaultSetting = @"";
				colvarQuantity.ForeignKeyTableName = "";
				schema.Columns.Add(colvarQuantity);
				
				TableSchema.TableColumn colvarActualCost = new TableSchema.TableColumn(schema);
				colvarActualCost.ColumnName = "ActualCost";
				colvarActualCost.DataType = DbType.Currency;
				colvarActualCost.MaxLength = 0;
				colvarActualCost.AutoIncrement = false;
				colvarActualCost.IsNullable = false;
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
				DataService.Providers["Default"].AddSchema("TransactionHistoryArchive",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("TransactionID")]
		public int TransactionID 
		{
			get { return GetColumnValue<int>(Columns.TransactionID); }

			set { SetColumnValue(Columns.TransactionID, value); }

		}

		  
		[XmlAttribute("ProductID")]
		public int ProductID 
		{
			get { return GetColumnValue<int>(Columns.ProductID); }

			set { SetColumnValue(Columns.ProductID, value); }

		}

		  
		[XmlAttribute("ReferenceOrderID")]
		public int ReferenceOrderID 
		{
			get { return GetColumnValue<int>(Columns.ReferenceOrderID); }

			set { SetColumnValue(Columns.ReferenceOrderID, value); }

		}

		  
		[XmlAttribute("ReferenceOrderLineID")]
		public int ReferenceOrderLineID 
		{
			get { return GetColumnValue<int>(Columns.ReferenceOrderLineID); }

			set { SetColumnValue(Columns.ReferenceOrderLineID, value); }

		}

		  
		[XmlAttribute("TransactionDate")]
		public DateTime TransactionDate 
		{
			get { return GetColumnValue<DateTime>(Columns.TransactionDate); }

			set { SetColumnValue(Columns.TransactionDate, value); }

		}

		  
		[XmlAttribute("TransactionType")]
		public string TransactionType 
		{
			get { return GetColumnValue<string>(Columns.TransactionType); }

			set { SetColumnValue(Columns.TransactionType, value); }

		}

		  
		[XmlAttribute("Quantity")]
		public int Quantity 
		{
			get { return GetColumnValue<int>(Columns.Quantity); }

			set { SetColumnValue(Columns.Quantity, value); }

		}

		  
		[XmlAttribute("ActualCost")]
		public decimal ActualCost 
		{
			get { return GetColumnValue<decimal>(Columns.ActualCost); }

			set { SetColumnValue(Columns.ActualCost, value); }

		}

		  
		[XmlAttribute("ModifiedDate")]
		public DateTime ModifiedDate 
		{
			get { return GetColumnValue<DateTime>(Columns.ModifiedDate); }

			set { SetColumnValue(Columns.ModifiedDate, value); }

		}

		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varTransactionID,int varProductID,int varReferenceOrderID,int varReferenceOrderLineID,DateTime varTransactionDate,string varTransactionType,int varQuantity,decimal varActualCost,DateTime varModifiedDate)
		{
			TransactionHistoryArchive item = new TransactionHistoryArchive();
			
			item.TransactionID = varTransactionID;
			
			item.ProductID = varProductID;
			
			item.ReferenceOrderID = varReferenceOrderID;
			
			item.ReferenceOrderLineID = varReferenceOrderLineID;
			
			item.TransactionDate = varTransactionDate;
			
			item.TransactionType = varTransactionType;
			
			item.Quantity = varQuantity;
			
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
		public static void Update(int varTransactionID,int varProductID,int varReferenceOrderID,int varReferenceOrderLineID,DateTime varTransactionDate,string varTransactionType,int varQuantity,decimal varActualCost,DateTime varModifiedDate)
		{
			TransactionHistoryArchive item = new TransactionHistoryArchive();
			
				item.TransactionID = varTransactionID;
			
				item.ProductID = varProductID;
			
				item.ReferenceOrderID = varReferenceOrderID;
			
				item.ReferenceOrderLineID = varReferenceOrderLineID;
			
				item.TransactionDate = varTransactionDate;
			
				item.TransactionType = varTransactionType;
			
				item.Quantity = varQuantity;
			
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
			 public static string TransactionID = @"TransactionID";
			 public static string ProductID = @"ProductID";
			 public static string ReferenceOrderID = @"ReferenceOrderID";
			 public static string ReferenceOrderLineID = @"ReferenceOrderLineID";
			 public static string TransactionDate = @"TransactionDate";
			 public static string TransactionType = @"TransactionType";
			 public static string Quantity = @"Quantity";
			 public static string ActualCost = @"ActualCost";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}

		#endregion
	}

}

