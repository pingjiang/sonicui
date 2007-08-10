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
	/// Strongly-typed collection for the Document class.
	/// </summary>
	[Serializable]
	public partial class DocumentCollection : ActiveList<Document, DocumentCollection> 
	{	   
		public DocumentCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the Document table.
	/// </summary>
	[Serializable]
	public partial class Document : ActiveRecord<Document>
	{
		#region .ctors and Default Settings
		
		public Document()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public Document(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public Document(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public Document(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Document", TableType.Table, DataService.GetInstance("Default"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Production";
				//columns
				
				TableSchema.TableColumn colvarDocumentID = new TableSchema.TableColumn(schema);
				colvarDocumentID.ColumnName = "DocumentID";
				colvarDocumentID.DataType = DbType.Int32;
				colvarDocumentID.MaxLength = 0;
				colvarDocumentID.AutoIncrement = true;
				colvarDocumentID.IsNullable = false;
				colvarDocumentID.IsPrimaryKey = true;
				colvarDocumentID.IsForeignKey = false;
				colvarDocumentID.IsReadOnly = false;
				colvarDocumentID.DefaultSetting = @"";
				colvarDocumentID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDocumentID);
				
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
				
				TableSchema.TableColumn colvarFileName = new TableSchema.TableColumn(schema);
				colvarFileName.ColumnName = "FileName";
				colvarFileName.DataType = DbType.String;
				colvarFileName.MaxLength = 400;
				colvarFileName.AutoIncrement = false;
				colvarFileName.IsNullable = false;
				colvarFileName.IsPrimaryKey = false;
				colvarFileName.IsForeignKey = false;
				colvarFileName.IsReadOnly = false;
				colvarFileName.DefaultSetting = @"";
				colvarFileName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFileName);
				
				TableSchema.TableColumn colvarFileExtension = new TableSchema.TableColumn(schema);
				colvarFileExtension.ColumnName = "FileExtension";
				colvarFileExtension.DataType = DbType.String;
				colvarFileExtension.MaxLength = 8;
				colvarFileExtension.AutoIncrement = false;
				colvarFileExtension.IsNullable = false;
				colvarFileExtension.IsPrimaryKey = false;
				colvarFileExtension.IsForeignKey = false;
				colvarFileExtension.IsReadOnly = false;
				colvarFileExtension.DefaultSetting = @"";
				colvarFileExtension.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFileExtension);
				
				TableSchema.TableColumn colvarRevision = new TableSchema.TableColumn(schema);
				colvarRevision.ColumnName = "Revision";
				colvarRevision.DataType = DbType.String;
				colvarRevision.MaxLength = 5;
				colvarRevision.AutoIncrement = false;
				colvarRevision.IsNullable = false;
				colvarRevision.IsPrimaryKey = false;
				colvarRevision.IsForeignKey = false;
				colvarRevision.IsReadOnly = false;
				colvarRevision.DefaultSetting = @"";
				colvarRevision.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRevision);
				
				TableSchema.TableColumn colvarChangeNumber = new TableSchema.TableColumn(schema);
				colvarChangeNumber.ColumnName = "ChangeNumber";
				colvarChangeNumber.DataType = DbType.Int32;
				colvarChangeNumber.MaxLength = 0;
				colvarChangeNumber.AutoIncrement = false;
				colvarChangeNumber.IsNullable = false;
				colvarChangeNumber.IsPrimaryKey = false;
				colvarChangeNumber.IsForeignKey = false;
				colvarChangeNumber.IsReadOnly = false;
				
						colvarChangeNumber.DefaultSetting = @"((0))";
				colvarChangeNumber.ForeignKeyTableName = "";
				schema.Columns.Add(colvarChangeNumber);
				
				TableSchema.TableColumn colvarStatus = new TableSchema.TableColumn(schema);
				colvarStatus.ColumnName = "Status";
				colvarStatus.DataType = DbType.Byte;
				colvarStatus.MaxLength = 0;
				colvarStatus.AutoIncrement = false;
				colvarStatus.IsNullable = false;
				colvarStatus.IsPrimaryKey = false;
				colvarStatus.IsForeignKey = false;
				colvarStatus.IsReadOnly = false;
				colvarStatus.DefaultSetting = @"";
				colvarStatus.ForeignKeyTableName = "";
				schema.Columns.Add(colvarStatus);
				
				TableSchema.TableColumn colvarDocumentSummary = new TableSchema.TableColumn(schema);
				colvarDocumentSummary.ColumnName = "DocumentSummary";
				colvarDocumentSummary.DataType = DbType.String;
				colvarDocumentSummary.MaxLength = -1;
				colvarDocumentSummary.AutoIncrement = false;
				colvarDocumentSummary.IsNullable = true;
				colvarDocumentSummary.IsPrimaryKey = false;
				colvarDocumentSummary.IsForeignKey = false;
				colvarDocumentSummary.IsReadOnly = false;
				colvarDocumentSummary.DefaultSetting = @"";
				colvarDocumentSummary.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDocumentSummary);
				
				TableSchema.TableColumn colvarDocumentX = new TableSchema.TableColumn(schema);
				colvarDocumentX.ColumnName = "Document";
				colvarDocumentX.DataType = DbType.Binary;
				colvarDocumentX.MaxLength = -1;
				colvarDocumentX.AutoIncrement = false;
				colvarDocumentX.IsNullable = true;
				colvarDocumentX.IsPrimaryKey = false;
				colvarDocumentX.IsForeignKey = false;
				colvarDocumentX.IsReadOnly = false;
				colvarDocumentX.DefaultSetting = @"";
				colvarDocumentX.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDocumentX);
				
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
				DataService.Providers["Default"].AddSchema("Document",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("DocumentID")]
		public int DocumentID 
		{
			get { return GetColumnValue<int>(Columns.DocumentID); }

			set { SetColumnValue(Columns.DocumentID, value); }

		}

		  
		[XmlAttribute("Title")]
		public string Title 
		{
			get { return GetColumnValue<string>(Columns.Title); }

			set { SetColumnValue(Columns.Title, value); }

		}

		  
		[XmlAttribute("FileName")]
		public string FileName 
		{
			get { return GetColumnValue<string>(Columns.FileName); }

			set { SetColumnValue(Columns.FileName, value); }

		}

		  
		[XmlAttribute("FileExtension")]
		public string FileExtension 
		{
			get { return GetColumnValue<string>(Columns.FileExtension); }

			set { SetColumnValue(Columns.FileExtension, value); }

		}

		  
		[XmlAttribute("Revision")]
		public string Revision 
		{
			get { return GetColumnValue<string>(Columns.Revision); }

			set { SetColumnValue(Columns.Revision, value); }

		}

		  
		[XmlAttribute("ChangeNumber")]
		public int ChangeNumber 
		{
			get { return GetColumnValue<int>(Columns.ChangeNumber); }

			set { SetColumnValue(Columns.ChangeNumber, value); }

		}

		  
		[XmlAttribute("Status")]
		public byte Status 
		{
			get { return GetColumnValue<byte>(Columns.Status); }

			set { SetColumnValue(Columns.Status, value); }

		}

		  
		[XmlAttribute("DocumentSummary")]
		public string DocumentSummary 
		{
			get { return GetColumnValue<string>(Columns.DocumentSummary); }

			set { SetColumnValue(Columns.DocumentSummary, value); }

		}

		  
		[XmlAttribute("DocumentX")]
		public byte[] DocumentX 
		{
			get { return GetColumnValue<byte[]>(Columns.DocumentX); }

			set { SetColumnValue(Columns.DocumentX, value); }

		}

		  
		[XmlAttribute("ModifiedDate")]
		public DateTime ModifiedDate 
		{
			get { return GetColumnValue<DateTime>(Columns.ModifiedDate); }

			set { SetColumnValue(Columns.ModifiedDate, value); }

		}

		
		#endregion
		
		
		#region PrimaryKey Methods
		
		public AVManager.DAL.ProductDocumentCollection ProductDocumentRecords()
		{
			return new AVManager.DAL.ProductDocumentCollection().Where(ProductDocument.Columns.DocumentID, DocumentID).Load();
		}

		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		#region Many To Many Helpers
		
		 
		public AVManager.DAL.ProductCollection GetProductCollection() { return Document.GetProductCollection(this.DocumentID); }

		public static AVManager.DAL.ProductCollection GetProductCollection(int varDocumentID)
		{
			SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
				"SELECT * FROM Product INNER JOIN ProductDocument ON "+
				"Product.ProductID=ProductDocument.ProductID WHERE ProductDocument.DocumentID=@DocumentID", Document.Schema.Provider.Name);
			
			cmd.AddParameter("@DocumentID", varDocumentID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			ProductCollection coll = new ProductCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}

		
		public static void SaveProductMap(int varDocumentID, ProductCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM ProductDocument WHERE DocumentID=@DocumentID", Document.Schema.Provider.Name);
			cmdDel.AddParameter("@DocumentID", varDocumentID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Product item in items)
			{
				ProductDocument varProductDocument = new ProductDocument();
				varProductDocument.SetColumnValue("DocumentID", varDocumentID);
				varProductDocument.SetColumnValue("ProductID", item.GetPrimaryKeyValue());
				varProductDocument.Save();
			}

		}

		public static void SaveProductMap(int varDocumentID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM ProductDocument WHERE DocumentID=@DocumentID", Document.Schema.Provider.Name);
			cmdDel.AddParameter("@DocumentID", varDocumentID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					ProductDocument varProductDocument = new ProductDocument();
					varProductDocument.SetColumnValue("DocumentID", varDocumentID);
					varProductDocument.SetColumnValue("ProductID", l.Value);
					varProductDocument.Save();
				}

			}

		}

		public static void SaveProductMap(int varDocumentID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM ProductDocument WHERE DocumentID=@DocumentID", Document.Schema.Provider.Name);
			cmdDel.AddParameter("@DocumentID", varDocumentID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				ProductDocument varProductDocument = new ProductDocument();
				varProductDocument.SetColumnValue("DocumentID", varDocumentID);
				varProductDocument.SetColumnValue("ProductID", item);
				varProductDocument.Save();
			}

		}

		
		public static void DeleteProductMap(int varDocumentID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM ProductDocument WHERE DocumentID=@DocumentID", Document.Schema.Provider.Name);
			cmdDel.AddParameter("@DocumentID", varDocumentID);
			DataService.ExecuteQuery(cmdDel);
		}

		
		#endregion
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varTitle,string varFileName,string varFileExtension,string varRevision,int varChangeNumber,byte varStatus,string varDocumentSummary,byte[] varDocumentX,DateTime varModifiedDate)
		{
			Document item = new Document();
			
			item.Title = varTitle;
			
			item.FileName = varFileName;
			
			item.FileExtension = varFileExtension;
			
			item.Revision = varRevision;
			
			item.ChangeNumber = varChangeNumber;
			
			item.Status = varStatus;
			
			item.DocumentSummary = varDocumentSummary;
			
			item.DocumentX = varDocumentX;
			
			item.ModifiedDate = varModifiedDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varDocumentID,string varTitle,string varFileName,string varFileExtension,string varRevision,int varChangeNumber,byte varStatus,string varDocumentSummary,byte[] varDocumentX,DateTime varModifiedDate)
		{
			Document item = new Document();
			
				item.DocumentID = varDocumentID;
			
				item.Title = varTitle;
			
				item.FileName = varFileName;
			
				item.FileExtension = varFileExtension;
			
				item.Revision = varRevision;
			
				item.ChangeNumber = varChangeNumber;
			
				item.Status = varStatus;
			
				item.DocumentSummary = varDocumentSummary;
			
				item.DocumentX = varDocumentX;
			
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
			 public static string DocumentID = @"DocumentID";
			 public static string Title = @"Title";
			 public static string FileName = @"FileName";
			 public static string FileExtension = @"FileExtension";
			 public static string Revision = @"Revision";
			 public static string ChangeNumber = @"ChangeNumber";
			 public static string Status = @"Status";
			 public static string DocumentSummary = @"DocumentSummary";
			 public static string DocumentX = @"Document";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}

		#endregion
	}

}

