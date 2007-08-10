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
    /// Controller class for Department
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class DepartmentController
    {
        // Preload our schema..
        Department thisSchemaLoad = new Department();
        private string userName = string.Empty;
        protected string UserName
        {
            get
            {
				if (userName.Length == 0) 
				{
    				if (System.Web.HttpContext.Current != null)
    				{
						userName=System.Web.HttpContext.Current.User.Identity.Name;
					}

					else
					{
						userName=System.Threading.Thread.CurrentPrincipal.Identity.Name;
					}

				}

				return userName;
            }

        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public DepartmentCollection FetchAll()
        {
            DepartmentCollection coll = new DepartmentCollection();
            Query qry = new Query(Department.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public DepartmentCollection FetchByID(object DepartmentID)
        {
            DepartmentCollection coll = new DepartmentCollection().Where("DepartmentID", DepartmentID).Load();
            return coll;
        }

		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public DepartmentCollection FetchByQuery(Query qry)
        {
            DepartmentCollection coll = new DepartmentCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object DepartmentID)
        {
            return (Department.Delete(DepartmentID) == 1);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object DepartmentID)
        {
            return (Department.Destroy(DepartmentID) == 1);
        }

        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string Name,string GroupName,DateTime ModifiedDate)
	    {
		    Department item = new Department();
		    
            item.Name = Name;
            
            item.GroupName = GroupName;
            
            item.ModifiedDate = ModifiedDate;
            
	    
		    item.Save(UserName);
	    }

    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(short DepartmentID,string Name,string GroupName,DateTime ModifiedDate)
	    {
		    Department item = new Department();
		    
				item.DepartmentID = DepartmentID;
				
				item.Name = Name;
				
				item.GroupName = GroupName;
				
				item.ModifiedDate = ModifiedDate;
				
		    item.MarkOld();
		    item.Save(UserName);
	    }

    }

}

