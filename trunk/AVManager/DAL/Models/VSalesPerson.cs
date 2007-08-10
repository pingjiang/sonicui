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

namespace AVManager.DAL{
    /// <summary>
    /// Strongly-typed collection for the VSalesPerson class.
    /// </summary>
    [Serializable]
    public partial class VSalesPersonCollection : ReadOnlyList<VSalesPerson, VSalesPersonCollection>
    {        
        public VSalesPersonCollection() {}

    }

    /// <summary>
    /// This is  Read-only wrapper class for the vSalesPerson view.
    /// </summary>
    [Serializable]
    public partial class VSalesPerson : ReadOnlyRecord<VSalesPerson> 
    {
    
	    #region Default Settings
	    protected static void SetSQLProps() 
	    {
		    GetTableSchema();
	    }

	    #endregion
        #region Schema Accessor
	    public static TableSchema.Table Schema
        {
            get
            {
                if (BaseSchema == null)
                {
                    SetSQLProps();
                }

                return BaseSchema;
            }

        }

    	
        private static void GetTableSchema() 
        {
            if(!IsSchemaInitialized)
            {
                //Schema declaration
                TableSchema.Table schema = new TableSchema.Table("vSalesPerson", TableType.View, DataService.GetInstance("Default"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = "Sales";
                //columns
                
                TableSchema.TableColumn colvarSalesPersonID = new TableSchema.TableColumn(schema);
                colvarSalesPersonID.ColumnName = "SalesPersonID";
                colvarSalesPersonID.DataType = DbType.Int32;
                colvarSalesPersonID.MaxLength = 0;
                colvarSalesPersonID.AutoIncrement = false;
                colvarSalesPersonID.IsNullable = false;
                colvarSalesPersonID.IsPrimaryKey = false;
                colvarSalesPersonID.IsForeignKey = false;
                colvarSalesPersonID.IsReadOnly = false;
                
                schema.Columns.Add(colvarSalesPersonID);
                
                TableSchema.TableColumn colvarTitle = new TableSchema.TableColumn(schema);
                colvarTitle.ColumnName = "Title";
                colvarTitle.DataType = DbType.String;
                colvarTitle.MaxLength = 8;
                colvarTitle.AutoIncrement = false;
                colvarTitle.IsNullable = true;
                colvarTitle.IsPrimaryKey = false;
                colvarTitle.IsForeignKey = false;
                colvarTitle.IsReadOnly = false;
                
                schema.Columns.Add(colvarTitle);
                
                TableSchema.TableColumn colvarFirstName = new TableSchema.TableColumn(schema);
                colvarFirstName.ColumnName = "FirstName";
                colvarFirstName.DataType = DbType.String;
                colvarFirstName.MaxLength = 50;
                colvarFirstName.AutoIncrement = false;
                colvarFirstName.IsNullable = false;
                colvarFirstName.IsPrimaryKey = false;
                colvarFirstName.IsForeignKey = false;
                colvarFirstName.IsReadOnly = false;
                
                schema.Columns.Add(colvarFirstName);
                
                TableSchema.TableColumn colvarMiddleName = new TableSchema.TableColumn(schema);
                colvarMiddleName.ColumnName = "MiddleName";
                colvarMiddleName.DataType = DbType.String;
                colvarMiddleName.MaxLength = 50;
                colvarMiddleName.AutoIncrement = false;
                colvarMiddleName.IsNullable = true;
                colvarMiddleName.IsPrimaryKey = false;
                colvarMiddleName.IsForeignKey = false;
                colvarMiddleName.IsReadOnly = false;
                
                schema.Columns.Add(colvarMiddleName);
                
                TableSchema.TableColumn colvarLastName = new TableSchema.TableColumn(schema);
                colvarLastName.ColumnName = "LastName";
                colvarLastName.DataType = DbType.String;
                colvarLastName.MaxLength = 50;
                colvarLastName.AutoIncrement = false;
                colvarLastName.IsNullable = false;
                colvarLastName.IsPrimaryKey = false;
                colvarLastName.IsForeignKey = false;
                colvarLastName.IsReadOnly = false;
                
                schema.Columns.Add(colvarLastName);
                
                TableSchema.TableColumn colvarSuffix = new TableSchema.TableColumn(schema);
                colvarSuffix.ColumnName = "Suffix";
                colvarSuffix.DataType = DbType.String;
                colvarSuffix.MaxLength = 10;
                colvarSuffix.AutoIncrement = false;
                colvarSuffix.IsNullable = true;
                colvarSuffix.IsPrimaryKey = false;
                colvarSuffix.IsForeignKey = false;
                colvarSuffix.IsReadOnly = false;
                
                schema.Columns.Add(colvarSuffix);
                
                TableSchema.TableColumn colvarJobTitle = new TableSchema.TableColumn(schema);
                colvarJobTitle.ColumnName = "JobTitle";
                colvarJobTitle.DataType = DbType.String;
                colvarJobTitle.MaxLength = 50;
                colvarJobTitle.AutoIncrement = false;
                colvarJobTitle.IsNullable = false;
                colvarJobTitle.IsPrimaryKey = false;
                colvarJobTitle.IsForeignKey = false;
                colvarJobTitle.IsReadOnly = false;
                
                schema.Columns.Add(colvarJobTitle);
                
                TableSchema.TableColumn colvarPhone = new TableSchema.TableColumn(schema);
                colvarPhone.ColumnName = "Phone";
                colvarPhone.DataType = DbType.String;
                colvarPhone.MaxLength = 25;
                colvarPhone.AutoIncrement = false;
                colvarPhone.IsNullable = true;
                colvarPhone.IsPrimaryKey = false;
                colvarPhone.IsForeignKey = false;
                colvarPhone.IsReadOnly = false;
                
                schema.Columns.Add(colvarPhone);
                
                TableSchema.TableColumn colvarEmailAddress = new TableSchema.TableColumn(schema);
                colvarEmailAddress.ColumnName = "EmailAddress";
                colvarEmailAddress.DataType = DbType.String;
                colvarEmailAddress.MaxLength = 50;
                colvarEmailAddress.AutoIncrement = false;
                colvarEmailAddress.IsNullable = true;
                colvarEmailAddress.IsPrimaryKey = false;
                colvarEmailAddress.IsForeignKey = false;
                colvarEmailAddress.IsReadOnly = false;
                
                schema.Columns.Add(colvarEmailAddress);
                
                TableSchema.TableColumn colvarEmailPromotion = new TableSchema.TableColumn(schema);
                colvarEmailPromotion.ColumnName = "EmailPromotion";
                colvarEmailPromotion.DataType = DbType.Int32;
                colvarEmailPromotion.MaxLength = 0;
                colvarEmailPromotion.AutoIncrement = false;
                colvarEmailPromotion.IsNullable = false;
                colvarEmailPromotion.IsPrimaryKey = false;
                colvarEmailPromotion.IsForeignKey = false;
                colvarEmailPromotion.IsReadOnly = false;
                
                schema.Columns.Add(colvarEmailPromotion);
                
                TableSchema.TableColumn colvarAddressLine1 = new TableSchema.TableColumn(schema);
                colvarAddressLine1.ColumnName = "AddressLine1";
                colvarAddressLine1.DataType = DbType.String;
                colvarAddressLine1.MaxLength = 60;
                colvarAddressLine1.AutoIncrement = false;
                colvarAddressLine1.IsNullable = false;
                colvarAddressLine1.IsPrimaryKey = false;
                colvarAddressLine1.IsForeignKey = false;
                colvarAddressLine1.IsReadOnly = false;
                
                schema.Columns.Add(colvarAddressLine1);
                
                TableSchema.TableColumn colvarAddressLine2 = new TableSchema.TableColumn(schema);
                colvarAddressLine2.ColumnName = "AddressLine2";
                colvarAddressLine2.DataType = DbType.String;
                colvarAddressLine2.MaxLength = 60;
                colvarAddressLine2.AutoIncrement = false;
                colvarAddressLine2.IsNullable = true;
                colvarAddressLine2.IsPrimaryKey = false;
                colvarAddressLine2.IsForeignKey = false;
                colvarAddressLine2.IsReadOnly = false;
                
                schema.Columns.Add(colvarAddressLine2);
                
                TableSchema.TableColumn colvarCity = new TableSchema.TableColumn(schema);
                colvarCity.ColumnName = "City";
                colvarCity.DataType = DbType.String;
                colvarCity.MaxLength = 30;
                colvarCity.AutoIncrement = false;
                colvarCity.IsNullable = false;
                colvarCity.IsPrimaryKey = false;
                colvarCity.IsForeignKey = false;
                colvarCity.IsReadOnly = false;
                
                schema.Columns.Add(colvarCity);
                
                TableSchema.TableColumn colvarStateProvinceName = new TableSchema.TableColumn(schema);
                colvarStateProvinceName.ColumnName = "StateProvinceName";
                colvarStateProvinceName.DataType = DbType.String;
                colvarStateProvinceName.MaxLength = 50;
                colvarStateProvinceName.AutoIncrement = false;
                colvarStateProvinceName.IsNullable = false;
                colvarStateProvinceName.IsPrimaryKey = false;
                colvarStateProvinceName.IsForeignKey = false;
                colvarStateProvinceName.IsReadOnly = false;
                
                schema.Columns.Add(colvarStateProvinceName);
                
                TableSchema.TableColumn colvarPostalCode = new TableSchema.TableColumn(schema);
                colvarPostalCode.ColumnName = "PostalCode";
                colvarPostalCode.DataType = DbType.String;
                colvarPostalCode.MaxLength = 15;
                colvarPostalCode.AutoIncrement = false;
                colvarPostalCode.IsNullable = false;
                colvarPostalCode.IsPrimaryKey = false;
                colvarPostalCode.IsForeignKey = false;
                colvarPostalCode.IsReadOnly = false;
                
                schema.Columns.Add(colvarPostalCode);
                
                TableSchema.TableColumn colvarCountryRegionName = new TableSchema.TableColumn(schema);
                colvarCountryRegionName.ColumnName = "CountryRegionName";
                colvarCountryRegionName.DataType = DbType.String;
                colvarCountryRegionName.MaxLength = 50;
                colvarCountryRegionName.AutoIncrement = false;
                colvarCountryRegionName.IsNullable = false;
                colvarCountryRegionName.IsPrimaryKey = false;
                colvarCountryRegionName.IsForeignKey = false;
                colvarCountryRegionName.IsReadOnly = false;
                
                schema.Columns.Add(colvarCountryRegionName);
                
                TableSchema.TableColumn colvarTerritoryName = new TableSchema.TableColumn(schema);
                colvarTerritoryName.ColumnName = "TerritoryName";
                colvarTerritoryName.DataType = DbType.String;
                colvarTerritoryName.MaxLength = 50;
                colvarTerritoryName.AutoIncrement = false;
                colvarTerritoryName.IsNullable = true;
                colvarTerritoryName.IsPrimaryKey = false;
                colvarTerritoryName.IsForeignKey = false;
                colvarTerritoryName.IsReadOnly = false;
                
                schema.Columns.Add(colvarTerritoryName);
                
                TableSchema.TableColumn colvarTerritoryGroup = new TableSchema.TableColumn(schema);
                colvarTerritoryGroup.ColumnName = "TerritoryGroup";
                colvarTerritoryGroup.DataType = DbType.String;
                colvarTerritoryGroup.MaxLength = 50;
                colvarTerritoryGroup.AutoIncrement = false;
                colvarTerritoryGroup.IsNullable = true;
                colvarTerritoryGroup.IsPrimaryKey = false;
                colvarTerritoryGroup.IsForeignKey = false;
                colvarTerritoryGroup.IsReadOnly = false;
                
                schema.Columns.Add(colvarTerritoryGroup);
                
                TableSchema.TableColumn colvarSalesQuota = new TableSchema.TableColumn(schema);
                colvarSalesQuota.ColumnName = "SalesQuota";
                colvarSalesQuota.DataType = DbType.Currency;
                colvarSalesQuota.MaxLength = 0;
                colvarSalesQuota.AutoIncrement = false;
                colvarSalesQuota.IsNullable = true;
                colvarSalesQuota.IsPrimaryKey = false;
                colvarSalesQuota.IsForeignKey = false;
                colvarSalesQuota.IsReadOnly = false;
                
                schema.Columns.Add(colvarSalesQuota);
                
                TableSchema.TableColumn colvarSalesYTD = new TableSchema.TableColumn(schema);
                colvarSalesYTD.ColumnName = "SalesYTD";
                colvarSalesYTD.DataType = DbType.Currency;
                colvarSalesYTD.MaxLength = 0;
                colvarSalesYTD.AutoIncrement = false;
                colvarSalesYTD.IsNullable = false;
                colvarSalesYTD.IsPrimaryKey = false;
                colvarSalesYTD.IsForeignKey = false;
                colvarSalesYTD.IsReadOnly = false;
                
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
                
                schema.Columns.Add(colvarSalesLastYear);
                
                
                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["Default"].AddSchema("vSalesPerson",schema);
            }

        }

        #endregion
        
        #region Query Accessor
	    public static Query CreateQuery()
	    {
		    return new Query(Schema);
	    }

	    #endregion
	    
	    #region .ctors
	    public VSalesPerson()
	    {
            SetSQLProps();
            SetDefaults();
            MarkNew();
        }

        public VSalesPerson(bool useDatabaseDefaults)
	    {
		    SetSQLProps();
		    if(useDatabaseDefaults)
		    {
				ForceDefaults();
			}

			MarkNew();
	    }

	    
	    public VSalesPerson(object keyID)
	    {
		    SetSQLProps();
		    LoadByKey(keyID);
	    }

    	 
	    public VSalesPerson(string columnName, object columnValue)
        {
            SetSQLProps();
            LoadByParam(columnName,columnValue);
        }

        
	    #endregion
	    
	    #region Props
	    
          
        [XmlAttribute("SalesPersonID")]
        public int SalesPersonID 
	    {
		    get
		    {
			    return GetColumnValue<int>("SalesPersonID");
		    }

            set 
		    {
			    SetColumnValue("SalesPersonID", value);
            }

        }

	      
        [XmlAttribute("Title")]
        public string Title 
	    {
		    get
		    {
			    return GetColumnValue<string>("Title");
		    }

            set 
		    {
			    SetColumnValue("Title", value);
            }

        }

	      
        [XmlAttribute("FirstName")]
        public string FirstName 
	    {
		    get
		    {
			    return GetColumnValue<string>("FirstName");
		    }

            set 
		    {
			    SetColumnValue("FirstName", value);
            }

        }

	      
        [XmlAttribute("MiddleName")]
        public string MiddleName 
	    {
		    get
		    {
			    return GetColumnValue<string>("MiddleName");
		    }

            set 
		    {
			    SetColumnValue("MiddleName", value);
            }

        }

	      
        [XmlAttribute("LastName")]
        public string LastName 
	    {
		    get
		    {
			    return GetColumnValue<string>("LastName");
		    }

            set 
		    {
			    SetColumnValue("LastName", value);
            }

        }

	      
        [XmlAttribute("Suffix")]
        public string Suffix 
	    {
		    get
		    {
			    return GetColumnValue<string>("Suffix");
		    }

            set 
		    {
			    SetColumnValue("Suffix", value);
            }

        }

	      
        [XmlAttribute("JobTitle")]
        public string JobTitle 
	    {
		    get
		    {
			    return GetColumnValue<string>("JobTitle");
		    }

            set 
		    {
			    SetColumnValue("JobTitle", value);
            }

        }

	      
        [XmlAttribute("Phone")]
        public string Phone 
	    {
		    get
		    {
			    return GetColumnValue<string>("Phone");
		    }

            set 
		    {
			    SetColumnValue("Phone", value);
            }

        }

	      
        [XmlAttribute("EmailAddress")]
        public string EmailAddress 
	    {
		    get
		    {
			    return GetColumnValue<string>("EmailAddress");
		    }

            set 
		    {
			    SetColumnValue("EmailAddress", value);
            }

        }

	      
        [XmlAttribute("EmailPromotion")]
        public int EmailPromotion 
	    {
		    get
		    {
			    return GetColumnValue<int>("EmailPromotion");
		    }

            set 
		    {
			    SetColumnValue("EmailPromotion", value);
            }

        }

	      
        [XmlAttribute("AddressLine1")]
        public string AddressLine1 
	    {
		    get
		    {
			    return GetColumnValue<string>("AddressLine1");
		    }

            set 
		    {
			    SetColumnValue("AddressLine1", value);
            }

        }

	      
        [XmlAttribute("AddressLine2")]
        public string AddressLine2 
	    {
		    get
		    {
			    return GetColumnValue<string>("AddressLine2");
		    }

            set 
		    {
			    SetColumnValue("AddressLine2", value);
            }

        }

	      
        [XmlAttribute("City")]
        public string City 
	    {
		    get
		    {
			    return GetColumnValue<string>("City");
		    }

            set 
		    {
			    SetColumnValue("City", value);
            }

        }

	      
        [XmlAttribute("StateProvinceName")]
        public string StateProvinceName 
	    {
		    get
		    {
			    return GetColumnValue<string>("StateProvinceName");
		    }

            set 
		    {
			    SetColumnValue("StateProvinceName", value);
            }

        }

	      
        [XmlAttribute("PostalCode")]
        public string PostalCode 
	    {
		    get
		    {
			    return GetColumnValue<string>("PostalCode");
		    }

            set 
		    {
			    SetColumnValue("PostalCode", value);
            }

        }

	      
        [XmlAttribute("CountryRegionName")]
        public string CountryRegionName 
	    {
		    get
		    {
			    return GetColumnValue<string>("CountryRegionName");
		    }

            set 
		    {
			    SetColumnValue("CountryRegionName", value);
            }

        }

	      
        [XmlAttribute("TerritoryName")]
        public string TerritoryName 
	    {
		    get
		    {
			    return GetColumnValue<string>("TerritoryName");
		    }

            set 
		    {
			    SetColumnValue("TerritoryName", value);
            }

        }

	      
        [XmlAttribute("TerritoryGroup")]
        public string TerritoryGroup 
	    {
		    get
		    {
			    return GetColumnValue<string>("TerritoryGroup");
		    }

            set 
		    {
			    SetColumnValue("TerritoryGroup", value);
            }

        }

	      
        [XmlAttribute("SalesQuota")]
        public decimal? SalesQuota 
	    {
		    get
		    {
			    return GetColumnValue<decimal?>("SalesQuota");
		    }

            set 
		    {
			    SetColumnValue("SalesQuota", value);
            }

        }

	      
        [XmlAttribute("SalesYTD")]
        public decimal SalesYTD 
	    {
		    get
		    {
			    return GetColumnValue<decimal>("SalesYTD");
		    }

            set 
		    {
			    SetColumnValue("SalesYTD", value);
            }

        }

	      
        [XmlAttribute("SalesLastYear")]
        public decimal SalesLastYear 
	    {
		    get
		    {
			    return GetColumnValue<decimal>("SalesLastYear");
		    }

            set 
		    {
			    SetColumnValue("SalesLastYear", value);
            }

        }

	    
	    #endregion
    
	    #region Columns Struct
	    public struct Columns
	    {
		    
		    
            public static string SalesPersonID = @"SalesPersonID";
            
            public static string Title = @"Title";
            
            public static string FirstName = @"FirstName";
            
            public static string MiddleName = @"MiddleName";
            
            public static string LastName = @"LastName";
            
            public static string Suffix = @"Suffix";
            
            public static string JobTitle = @"JobTitle";
            
            public static string Phone = @"Phone";
            
            public static string EmailAddress = @"EmailAddress";
            
            public static string EmailPromotion = @"EmailPromotion";
            
            public static string AddressLine1 = @"AddressLine1";
            
            public static string AddressLine2 = @"AddressLine2";
            
            public static string City = @"City";
            
            public static string StateProvinceName = @"StateProvinceName";
            
            public static string PostalCode = @"PostalCode";
            
            public static string CountryRegionName = @"CountryRegionName";
            
            public static string TerritoryName = @"TerritoryName";
            
            public static string TerritoryGroup = @"TerritoryGroup";
            
            public static string SalesQuota = @"SalesQuota";
            
            public static string SalesYTD = @"SalesYTD";
            
            public static string SalesLastYear = @"SalesLastYear";
            
	    }

	    #endregion
    }

}

