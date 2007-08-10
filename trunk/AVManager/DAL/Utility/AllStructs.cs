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
	#region Tables Struct
	public partial struct Tables
	{
		
		public static string Address = @"Address";
        
		public static string AddressType = @"AddressType";
        
		public static string AWBuildVersion = @"AWBuildVersion";
        
		public static string BillOfMaterial = @"BillOfMaterials";
        
		public static string Contact = @"Contact";
        
		public static string ContactCreditCard = @"ContactCreditCard";
        
		public static string ContactType = @"ContactType";
        
		public static string CountryRegion = @"CountryRegion";
        
		public static string CountryRegionCurrency = @"CountryRegionCurrency";
        
		public static string CreditCard = @"CreditCard";
        
		public static string Culture = @"Culture";
        
		public static string Currency = @"Currency";
        
		public static string CurrencyRate = @"CurrencyRate";
        
		public static string Customer = @"Customer";
        
		public static string CustomerAddress = @"CustomerAddress";
        
		public static string DatabaseLog = @"DatabaseLog";
        
		public static string Department = @"Department";
        
		public static string Document = @"Document";
        
		public static string Employee = @"Employee";
        
		public static string EmployeeAddress = @"EmployeeAddress";
        
		public static string EmployeeDepartmentHistory = @"EmployeeDepartmentHistory";
        
		public static string EmployeePayHistory = @"EmployeePayHistory";
        
		public static string ErrorLog = @"ErrorLog";
        
		public static string Illustration = @"Illustration";
        
		public static string Individual = @"Individual";
        
		public static string JobCandidate = @"JobCandidate";
        
		public static string Location = @"Location";
        
		public static string Product = @"Product";
        
		public static string ProductCategory = @"ProductCategory";
        
		public static string ProductCostHistory = @"ProductCostHistory";
        
		public static string ProductDescription = @"ProductDescription";
        
		public static string ProductDocument = @"ProductDocument";
        
		public static string ProductInventory = @"ProductInventory";
        
		public static string ProductListPriceHistory = @"ProductListPriceHistory";
        
		public static string ProductModel = @"ProductModel";
        
		public static string ProductModelIllustration = @"ProductModelIllustration";
        
		public static string ProductModelProductDescriptionCulture = @"ProductModelProductDescriptionCulture";
        
		public static string ProductPhoto = @"ProductPhoto";
        
		public static string ProductProductPhoto = @"ProductProductPhoto";
        
		public static string ProductReview = @"ProductReview";
        
		public static string ProductSubcategory = @"ProductSubcategory";
        
		public static string ProductVendor = @"ProductVendor";
        
		public static string PurchaseOrderDetail = @"PurchaseOrderDetail";
        
		public static string PurchaseOrderHeader = @"PurchaseOrderHeader";
        
		public static string SalesOrderDetail = @"SalesOrderDetail";
        
		public static string SalesOrderHeader = @"SalesOrderHeader";
        
		public static string SalesOrderHeaderSalesReason = @"SalesOrderHeaderSalesReason";
        
		public static string SalesPerson = @"SalesPerson";
        
		public static string SalesPersonQuotaHistory = @"SalesPersonQuotaHistory";
        
		public static string SalesReason = @"SalesReason";
        
		public static string SalesTaxRate = @"SalesTaxRate";
        
		public static string SalesTerritory = @"SalesTerritory";
        
		public static string SalesTerritoryHistory = @"SalesTerritoryHistory";
        
		public static string ScrapReason = @"ScrapReason";
        
		public static string Shift = @"Shift";
        
		public static string ShipMethod = @"ShipMethod";
        
		public static string ShoppingCartItem = @"ShoppingCartItem";
        
		public static string SpecialOffer = @"SpecialOffer";
        
		public static string SpecialOfferProduct = @"SpecialOfferProduct";
        
		public static string StateProvince = @"StateProvince";
        
		public static string Store = @"Store";
        
		public static string StoreContact = @"StoreContact";
        
		public static string TransactionHistory = @"TransactionHistory";
        
		public static string TransactionHistoryArchive = @"TransactionHistoryArchive";
        
		public static string UnitMeasure = @"UnitMeasure";
        
		public static string Vendor = @"Vendor";
        
		public static string VendorAddress = @"VendorAddress";
        
		public static string VendorContact = @"VendorContact";
        
		public static string WorkOrder = @"WorkOrder";
        
		public static string WorkOrderRouting = @"WorkOrderRouting";
        
	}

	#endregion
    #region View Struct
    public partial struct Views 
    {
		
		public static string VAdditionalContactInfo = @"vAdditionalContactInfo";
        
		public static string VEmployee = @"vEmployee";
        
		public static string VEmployeeDepartment = @"vEmployeeDepartment";
        
		public static string VEmployeeDepartmentHistory = @"vEmployeeDepartmentHistory";
        
		public static string VIndividualCustomer = @"vIndividualCustomer";
        
		public static string VIndividualDemographic = @"vIndividualDemographics";
        
		public static string VJobCandidate = @"vJobCandidate";
        
		public static string VJobCandidateEducation = @"vJobCandidateEducation";
        
		public static string VJobCandidateEmployment = @"vJobCandidateEmployment";
        
		public static string VProductAndDescription = @"vProductAndDescription";
        
		public static string VProductModelCatalogDescription = @"vProductModelCatalogDescription";
        
		public static string VProductModelInstruction = @"vProductModelInstructions";
        
		public static string VSalesPerson = @"vSalesPerson";
        
		public static string VSalesPersonSalesByFiscalYear = @"vSalesPersonSalesByFiscalYears";
        
		public static string VStateProvinceCountryRegion = @"vStateProvinceCountryRegion";
        
		public static string VStoreWithDemographic = @"vStoreWithDemographics";
        
		public static string VVendor = @"vVendor";
        
    }

    #endregion
}

#region Databases
public partial struct Databases 
{
	
	public static string Default = @"Default";
    
}

#endregion
