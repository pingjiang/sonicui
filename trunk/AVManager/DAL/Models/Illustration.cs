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
	/// Strongly-typed collection for the Illustration class.
	/// </summary>
	[Serializable]
	public partial class IllustrationCollection : ActiveList<Illustration, IllustrationCollection> 
	{	   
		public IllustrationCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the Illustration table.
	/// </summary>
	[Serializable]
	public partial class Illustration : ActiveRecord<Illustration>
	{
		#region .ctors and Default Settings
		
		public Illustration()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public Illustration(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public Illustration(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public Illustration(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Illustration", TableType.Table, DataService.GetInstance("Default"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Production";
				//columns
				
				TableSchema.TableColumn colvarIllustrationID = new TableSchema.TableColumn(schema);
				colvarIllustrationID.ColumnName = "IllustrationID";
				colvarIllustrationID.DataType = DbType.Int32;
				colvarIllustrationID.MaxLength = 0;
				colvarIllustrationID.AutoIncrement = true;
				colvarIllustrationID.IsNullable = false;
				colvarIllustrationID.IsPrimaryKey = true;
				colvarIllustrationID.IsForeignKey = false;
				colvarIllustrationID.IsReadOnly = false;
				colvarIllustrationID.DefaultSetting = @"";
				colvarIllustrationID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIllustrationID);
				
				TableSchema.TableColumn colvarDiagram = new TableSchema.TableColumn(schema);
				colvarDiagram.ColumnName = "Diagram";
				colvarDiagram.DataType = DbType.String;
				colvarDiagram.MaxLength = -1;
				colvarDiagram.AutoIncrement = false;
				colvarDiagram.IsNullable = true;
				colvarDiagram.IsPrimaryKey = false;
				colvarDiagram.IsForeignKey = false;
				colvarDiagram.IsReadOnly = false;
				colvarDiagram.DefaultSetting = @"";
				colvarDiagram.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDiagram);
				
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
				DataService.Providers["Default"].AddSchema("Illustration",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("IllustrationID")]
		public int IllustrationID 
		{
			get { return GetColumnValue<int>(Columns.IllustrationID); }

			set { SetColumnValue(Columns.IllustrationID, value); }

		}

		  
		[XmlAttribute("Diagram")]
		public string Diagram 
		{
			get { return GetColumnValue<string>(Columns.Diagram); }

			set { SetColumnValue(Columns.Diagram, value); }

		}

		  
		[XmlAttribute("ModifiedDate")]
		public DateTime ModifiedDate 
		{
			get { return GetColumnValue<DateTime>(Columns.ModifiedDate); }

			set { SetColumnValue(Columns.ModifiedDate, value); }

		}

		
		#endregion
		
		
		#region PrimaryKey Methods
		
		public AVManager.DAL.ProductModelIllustrationCollection ProductModelIllustrationRecords()
		{
			return new AVManager.DAL.ProductModelIllustrationCollection().Where(ProductModelIllustration.Columns.IllustrationID, IllustrationID).Load();
		}

		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		#region Many To Many Helpers
		
		 
		public AVManager.DAL.ProductModelCollection GetProductModelCollection() { return Illustration.GetProductModelCollection(this.IllustrationID); }

		public static AVManager.DAL.ProductModelCollection GetProductModelCollection(int varIllustrationID)
		{
			SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
				"SELECT * FROM ProductModel INNER JOIN ProductModelIllustration ON "+
				"ProductModel.ProductModelID=ProductModelIllustration.ProductModelID WHERE ProductModelIllustration.IllustrationID=@IllustrationID", Illustration.Schema.Provider.Name);
			
			cmd.AddParameter("@IllustrationID", varIllustrationID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			ProductModelCollection coll = new ProductModelCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}

		
		public static void SaveProductModelMap(int varIllustrationID, ProductModelCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM ProductModelIllustration WHERE IllustrationID=@IllustrationID", Illustration.Schema.Provider.Name);
			cmdDel.AddParameter("@IllustrationID", varIllustrationID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (ProductModel item in items)
			{
				ProductModelIllustration varProductModelIllustration = new ProductModelIllustration();
				varProductModelIllustration.SetColumnValue("IllustrationID", varIllustrationID);
				varProductModelIllustration.SetColumnValue("ProductModelID", item.GetPrimaryKeyValue());
				varProductModelIllustration.Save();
			}

		}

		public static void SaveProductModelMap(int varIllustrationID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM ProductModelIllustration WHERE IllustrationID=@IllustrationID", Illustration.Schema.Provider.Name);
			cmdDel.AddParameter("@IllustrationID", varIllustrationID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					ProductModelIllustration varProductModelIllustration = new ProductModelIllustration();
					varProductModelIllustration.SetColumnValue("IllustrationID", varIllustrationID);
					varProductModelIllustration.SetColumnValue("ProductModelID", l.Value);
					varProductModelIllustration.Save();
				}

			}

		}

		public static void SaveProductModelMap(int varIllustrationID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM ProductModelIllustration WHERE IllustrationID=@IllustrationID", Illustration.Schema.Provider.Name);
			cmdDel.AddParameter("@IllustrationID", varIllustrationID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				ProductModelIllustration varProductModelIllustration = new ProductModelIllustration();
				varProductModelIllustration.SetColumnValue("IllustrationID", varIllustrationID);
				varProductModelIllustration.SetColumnValue("ProductModelID", item);
				varProductModelIllustration.Save();
			}

		}

		
		public static void DeleteProductModelMap(int varIllustrationID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM ProductModelIllustration WHERE IllustrationID=@IllustrationID", Illustration.Schema.Provider.Name);
			cmdDel.AddParameter("@IllustrationID", varIllustrationID);
			DataService.ExecuteQuery(cmdDel);
		}

		
		#endregion
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varDiagram,DateTime varModifiedDate)
		{
			Illustration item = new Illustration();
			
			item.Diagram = varDiagram;
			
			item.ModifiedDate = varModifiedDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varIllustrationID,string varDiagram,DateTime varModifiedDate)
		{
			Illustration item = new Illustration();
			
				item.IllustrationID = varIllustrationID;
			
				item.Diagram = varDiagram;
			
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
			 public static string IllustrationID = @"IllustrationID";
			 public static string Diagram = @"Diagram";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}

		#endregion
	}

}

