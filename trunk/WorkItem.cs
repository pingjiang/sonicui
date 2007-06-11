using System;
using System.Collections.Generic;
using System.Text;

namespace SonicUI
{
    public class WorkItem
    {
        string tableName;

        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }
        string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        bool create;

        public bool Create
        {
            get { return create; }
            set { create = value; }
        }
    }
}
