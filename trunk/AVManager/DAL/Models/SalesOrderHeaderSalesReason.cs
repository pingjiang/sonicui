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
	/// Strongly-typed collection for the SalesOrderHeaderSalesReason class.
	/// </summary>
	[Serializable]
	public partial class SalesOrderHeaderSalesReasonCollection : ActiveList<SalesOrderHeaderSalesReason, SalesOrderHeaderSalesReasonCollection> 
	{	   
		public SalesOrderHeaderSalesReasonCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the SalesOrderHeaderSalesReason table.
	/// </summary>
	[Serializable]
	public partial class SalesOrderHeaderSalesReason : ActiveRecord<SalesOrderHeaderSalesReason>
	{
		#region .ctors and Default Settings
		
		public SalesOrderHeaderSalesReason()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public SalesOrderHeaderSalesReason(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public SalesOrderHeaderSalesReason(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public SalesOrderHeaderSalesReason(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("SalesOrderHeaderSalesReason", TableType.Table, DataService.GetInstance("Default"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Sales";
				//columns
				
				TableSchema.TableColumn colvarSalesOrderID = new TableSchema.TableColumn(schema);
				colvarSalesOrderID.ColumnName = "SalesOrderID";
				colvarSalesOrderID.DataType = DbType.Int32;
				colvarSalesOrderID.MaxLength = 0;
				colvarSalesOrderID.AutoIncrement = false;
				colvarSalesOrderID.IsNullable = false;
				colvarSalesOrderID.IsPrimaryKey = true;
				colvarSalesOrderID.IsForeignKey = true;
				colvarSalesOrderID.IsReadOnly = false;
				colvarSalesOrderID.DefaultSetting = @"";
				
					colvarSalesOrderID.ForeignKeyTableName = "SalesOrderHeader";
				schema.Columns.Add(colvarSalesOrderID);
				
				TableSchema.TableColumn colvarSalesReasonID = new TableSchema.TableColumn(schema);
				colvarSalesReasonID.ColumnName = "SalesReasonID";
				colvarSalesReasonID.DataType = DbType.Int32;
				colvarSalesReasonID.MaxLength = 0;
				colvarSalesReasonID.AutoIncrement = false;
				colvarSalesReasonID.IsNullable = false;
				colvarSalesReasonID.IsPrimaryKey = true;
				colvarSalesReasonID.IsForeignKey = true;
				colvarSalesReasonID.IsReadOnly = false;
				colvarSalesReasonID.DefaultSetting = @"";
				
					colvarSalesReasonID.ForeignKeyTableName = "SalesReason";
				schema.Columns.Add(colvarSalesReasonID);
				
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
				DataService.Providers["Default"].AddSchema("SalesOrderHeaderSalesReason",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("SalesOrderID")]
		public int SalesOrderID 
		{
			get { return GetColumnValue<int>(Columns.SalesOrderID); }

			set { SetColumnValue(Columns.SalesOrderID, value); }

		}

		  
		[XmlAttribute("SalesReasonID")]
		public int SalesReasonID 
		{
			get { return GetColumnValue<int>(Columns.SalesReasonID); }

			set { SetColumnValue(Columns.SalesReasonID, value); }

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
		/// Returns a SalesOrderHeader ActiveRecord object related to this SalesOrderHeaderSalesReason
		/// 
		/// </summary>
		public AVManager.DAL.SalesOrderHeader SalesOrderHeader
		{
			get { return AVManager.DAL.SalesOrderHeader.FetchByID(this.SalesOrderID); }

			set { SetColumnValue("SalesOrderID", value.SalesOrderID); }

		}

		
		
		/// <summary>
		/// Returns a SalesReason ActiveRecord object related to this SalesOrderHeaderSalesReason
		/// 
		/// </summary>
		public AVManager.DAL.SalesReason SalesReason
		{
			get { return AVManager.DAL.SalesReason.FetchByID(this.SalesReasonID); }

			set { SetColumnValue("SalesReasonID", value.SalesReasonID); }

		}

		
		
		#endregion
		
		
		
		//no ManyToMany tables defined (0)
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(int varSalesOrderID,int varSalesReasonID,DateTime varModifiedDate)
		{
			SalesOrderHeaderSalesReason item = new SalesOrderHeaderSalesReason();
			
			item.SalesOrderID = varSalesOrderID;
			
			item.SalesReasonID = varSalesReasonID;
			
			item.ModifiedDate = varModifiedDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varSalesOrderID,int varSalesReasonID,DateTime varModifiedDate)
		{
			SalesOrderHeaderSalesReason item = new SalesOrderHeaderSalesReason();
			
				item.SalesOrderID = varSalesOrderID;
			
				item.SalesReasonID = varSalesReasonID;
			
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
			 public static string SalesOrderID = @"SalesOrderID";
			 public static string SalesReasonID = @"SalesReasonID";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}

		#endregion
	}

}

