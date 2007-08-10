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
	/// Strongly-typed collection for the CreditCard class.
	/// </summary>
	[Serializable]
	public partial class CreditCardCollection : ActiveList<CreditCard, CreditCardCollection> 
	{	   
		public CreditCardCollection() {}

	}

	/// <summary>
	/// This is an ActiveRecord class which wraps the CreditCard table.
	/// </summary>
	[Serializable]
	public partial class CreditCard : ActiveRecord<CreditCard>
	{
		#region .ctors and Default Settings
		
		public CreditCard()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}

		
		private void InitSetDefaults() { SetDefaults(); }

		
		public CreditCard(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}

		public CreditCard(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}

		 
		public CreditCard(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("CreditCard", TableType.Table, DataService.GetInstance("Default"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"Sales";
				//columns
				
				TableSchema.TableColumn colvarCreditCardID = new TableSchema.TableColumn(schema);
				colvarCreditCardID.ColumnName = "CreditCardID";
				colvarCreditCardID.DataType = DbType.Int32;
				colvarCreditCardID.MaxLength = 0;
				colvarCreditCardID.AutoIncrement = true;
				colvarCreditCardID.IsNullable = false;
				colvarCreditCardID.IsPrimaryKey = true;
				colvarCreditCardID.IsForeignKey = false;
				colvarCreditCardID.IsReadOnly = false;
				colvarCreditCardID.DefaultSetting = @"";
				colvarCreditCardID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCreditCardID);
				
				TableSchema.TableColumn colvarCardType = new TableSchema.TableColumn(schema);
				colvarCardType.ColumnName = "CardType";
				colvarCardType.DataType = DbType.String;
				colvarCardType.MaxLength = 50;
				colvarCardType.AutoIncrement = false;
				colvarCardType.IsNullable = false;
				colvarCardType.IsPrimaryKey = false;
				colvarCardType.IsForeignKey = false;
				colvarCardType.IsReadOnly = false;
				colvarCardType.DefaultSetting = @"";
				colvarCardType.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCardType);
				
				TableSchema.TableColumn colvarCardNumber = new TableSchema.TableColumn(schema);
				colvarCardNumber.ColumnName = "CardNumber";
				colvarCardNumber.DataType = DbType.String;
				colvarCardNumber.MaxLength = 25;
				colvarCardNumber.AutoIncrement = false;
				colvarCardNumber.IsNullable = false;
				colvarCardNumber.IsPrimaryKey = false;
				colvarCardNumber.IsForeignKey = false;
				colvarCardNumber.IsReadOnly = false;
				colvarCardNumber.DefaultSetting = @"";
				colvarCardNumber.ForeignKeyTableName = "";
				schema.Columns.Add(colvarCardNumber);
				
				TableSchema.TableColumn colvarExpMonth = new TableSchema.TableColumn(schema);
				colvarExpMonth.ColumnName = "ExpMonth";
				colvarExpMonth.DataType = DbType.Byte;
				colvarExpMonth.MaxLength = 0;
				colvarExpMonth.AutoIncrement = false;
				colvarExpMonth.IsNullable = false;
				colvarExpMonth.IsPrimaryKey = false;
				colvarExpMonth.IsForeignKey = false;
				colvarExpMonth.IsReadOnly = false;
				colvarExpMonth.DefaultSetting = @"";
				colvarExpMonth.ForeignKeyTableName = "";
				schema.Columns.Add(colvarExpMonth);
				
				TableSchema.TableColumn colvarExpYear = new TableSchema.TableColumn(schema);
				colvarExpYear.ColumnName = "ExpYear";
				colvarExpYear.DataType = DbType.Int16;
				colvarExpYear.MaxLength = 0;
				colvarExpYear.AutoIncrement = false;
				colvarExpYear.IsNullable = false;
				colvarExpYear.IsPrimaryKey = false;
				colvarExpYear.IsForeignKey = false;
				colvarExpYear.IsReadOnly = false;
				colvarExpYear.DefaultSetting = @"";
				colvarExpYear.ForeignKeyTableName = "";
				schema.Columns.Add(colvarExpYear);
				
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
				DataService.Providers["Default"].AddSchema("CreditCard",schema);
			}

		}

		#endregion
		
		#region Props
		
		  
		[XmlAttribute("CreditCardID")]
		public int CreditCardID 
		{
			get { return GetColumnValue<int>(Columns.CreditCardID); }

			set { SetColumnValue(Columns.CreditCardID, value); }

		}

		  
		[XmlAttribute("CardType")]
		public string CardType 
		{
			get { return GetColumnValue<string>(Columns.CardType); }

			set { SetColumnValue(Columns.CardType, value); }

		}

		  
		[XmlAttribute("CardNumber")]
		public string CardNumber 
		{
			get { return GetColumnValue<string>(Columns.CardNumber); }

			set { SetColumnValue(Columns.CardNumber, value); }

		}

		  
		[XmlAttribute("ExpMonth")]
		public byte ExpMonth 
		{
			get { return GetColumnValue<byte>(Columns.ExpMonth); }

			set { SetColumnValue(Columns.ExpMonth, value); }

		}

		  
		[XmlAttribute("ExpYear")]
		public short ExpYear 
		{
			get { return GetColumnValue<short>(Columns.ExpYear); }

			set { SetColumnValue(Columns.ExpYear, value); }

		}

		  
		[XmlAttribute("ModifiedDate")]
		public DateTime ModifiedDate 
		{
			get { return GetColumnValue<DateTime>(Columns.ModifiedDate); }

			set { SetColumnValue(Columns.ModifiedDate, value); }

		}

		
		#endregion
		
		
		#region PrimaryKey Methods
		
		public AVManager.DAL.ContactCreditCardCollection ContactCreditCardRecords()
		{
			return new AVManager.DAL.ContactCreditCardCollection().Where(ContactCreditCard.Columns.CreditCardID, CreditCardID).Load();
		}

		public AVManager.DAL.SalesOrderHeaderCollection SalesOrderHeaderRecords()
		{
			return new AVManager.DAL.SalesOrderHeaderCollection().Where(SalesOrderHeader.Columns.CreditCardID, CreditCardID).Load();
		}

		#endregion
		
			
		
		//no foreign key tables defined (0)
		
		
		
		#region Many To Many Helpers
		
		 
		public AVManager.DAL.ContactCollection GetContactCollection() { return CreditCard.GetContactCollection(this.CreditCardID); }

		public static AVManager.DAL.ContactCollection GetContactCollection(int varCreditCardID)
		{
			SubSonic.QueryCommand cmd = new SubSonic.QueryCommand(
				"SELECT * FROM Contact INNER JOIN ContactCreditCard ON "+
				"Contact.ContactID=ContactCreditCard.ContactID WHERE ContactCreditCard.CreditCardID=@CreditCardID", CreditCard.Schema.Provider.Name);
			
			cmd.AddParameter("@CreditCardID", varCreditCardID, DbType.Int32);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			ContactCollection coll = new ContactCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}

		
		public static void SaveContactMap(int varCreditCardID, ContactCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM ContactCreditCard WHERE CreditCardID=@CreditCardID", CreditCard.Schema.Provider.Name);
			cmdDel.AddParameter("@CreditCardID", varCreditCardID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (Contact item in items)
			{
				ContactCreditCard varContactCreditCard = new ContactCreditCard();
				varContactCreditCard.SetColumnValue("CreditCardID", varCreditCardID);
				varContactCreditCard.SetColumnValue("ContactID", item.GetPrimaryKeyValue());
				varContactCreditCard.Save();
			}

		}

		public static void SaveContactMap(int varCreditCardID, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM ContactCreditCard WHERE CreditCardID=@CreditCardID", CreditCard.Schema.Provider.Name);
			cmdDel.AddParameter("@CreditCardID", varCreditCardID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					ContactCreditCard varContactCreditCard = new ContactCreditCard();
					varContactCreditCard.SetColumnValue("CreditCardID", varCreditCardID);
					varContactCreditCard.SetColumnValue("ContactID", l.Value);
					varContactCreditCard.Save();
				}

			}

		}

		public static void SaveContactMap(int varCreditCardID , int[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM ContactCreditCard WHERE CreditCardID=@CreditCardID", CreditCard.Schema.Provider.Name);
			cmdDel.AddParameter("@CreditCardID", varCreditCardID);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (int item in itemList) 
			{
				ContactCreditCard varContactCreditCard = new ContactCreditCard();
				varContactCreditCard.SetColumnValue("CreditCardID", varCreditCardID);
				varContactCreditCard.SetColumnValue("ContactID", item);
				varContactCreditCard.Save();
			}

		}

		
		public static void DeleteContactMap(int varCreditCardID) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM ContactCreditCard WHERE CreditCardID=@CreditCardID", CreditCard.Schema.Provider.Name);
			cmdDel.AddParameter("@CreditCardID", varCreditCardID);
			DataService.ExecuteQuery(cmdDel);
		}

		
		#endregion
		
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varCardType,string varCardNumber,byte varExpMonth,short varExpYear,DateTime varModifiedDate)
		{
			CreditCard item = new CreditCard();
			
			item.CardType = varCardType;
			
			item.CardNumber = varCardNumber;
			
			item.ExpMonth = varExpMonth;
			
			item.ExpYear = varExpYear;
			
			item.ModifiedDate = varModifiedDate;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}

		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(int varCreditCardID,string varCardType,string varCardNumber,byte varExpMonth,short varExpYear,DateTime varModifiedDate)
		{
			CreditCard item = new CreditCard();
			
				item.CreditCardID = varCreditCardID;
			
				item.CardType = varCardType;
			
				item.CardNumber = varCardNumber;
			
				item.ExpMonth = varExpMonth;
			
				item.ExpYear = varExpYear;
			
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
			 public static string CreditCardID = @"CreditCardID";
			 public static string CardType = @"CardType";
			 public static string CardNumber = @"CardNumber";
			 public static string ExpMonth = @"ExpMonth";
			 public static string ExpYear = @"ExpYear";
			 public static string ModifiedDate = @"ModifiedDate";
						
		}

		#endregion
	}

}

