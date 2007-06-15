using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Data.SqlServerCe;
using System.Data.Common;
using SubSonic.Utilities;

namespace SubSonic
{
    public class SqlCEProvider : DataProvider
    {
        override internal DbConnection CreateConnection()
        {
            return CreateConnection(DefaultConnectionString);
        }

        override internal DbConnection CreateConnection(string newConnectionString)
        {
            SqlCeConnection retVal = new SqlCeConnection(newConnectionString);
            retVal.Open();
            return retVal;
        }
        private static void AddParams(SqlCeCommand cmd, QueryCommand qry)
        {
            if (qry.Parameters != null)
            {
                foreach (QueryParameter param in qry.Parameters)
                {
                    SqlCeParameter sqlParam = new SqlCeParameter(param.ParameterName, Utility.GetSqlDBType(param.DataType));
                    sqlParam.Direction = param.Mode;

                    //output parameters need to define a size
                    //our default is 50
                    if (sqlParam.Direction == ParameterDirection.Output || sqlParam.Direction == ParameterDirection.InputOutput)
                    {
                        sqlParam.Size = param.Size;
                    }

                    //fix for NULLs as parameter values
                    if (param.ParameterValue == null || Utility.IsMatch(param.ParameterValue.ToString(), "null"))
                    {
                        sqlParam.Value = DBNull.Value;
                    }
                    else if (param.DataType == DbType.Guid)
                    {
                        string paramValue = param.ParameterValue.ToString();
                        if (!String.IsNullOrEmpty(paramValue))
                        {
                            if (!Utility.IsMatch(paramValue, SqlSchemaVariable.DEFAULT))
                            {
                                sqlParam.Value = new Guid(param.ParameterValue.ToString());
                            }
                        }
                        else
                        {
                            sqlParam.Value = DBNull.Value;
                        }
                    }
                    else
                    {
                        sqlParam.Value = param.ParameterValue;
                    }

                    cmd.Parameters.Add(sqlParam);

                }
            }
        }

        private static void CheckoutOutputParams(SqlCeCommand cmd, QueryCommand qry)
        {
            if (qry.CommandType == CommandType.StoredProcedure && qry.HasOutputParams())
            {
                //loop the params, getting the values and setting them for the return
                foreach (QueryParameter param in qry.Parameters)
                {
                    if (param.Mode == ParameterDirection.InputOutput || param.Mode == ParameterDirection.Output)
                    {
                        object oVal = cmd.Parameters[param.ParameterName].Value;
                        qry.OutputValues.Add(oVal);
                    }
                }
            }
        }

        public override IDataReader GetReader(QueryCommand qry)
        {
            AutomaticConnectionScope automaticConnectionScope = new AutomaticConnectionScope(this);
            SqlCeCommand cmd = new SqlCeCommand(qry.CommandSql);
            cmd.CommandType = qry.CommandType;
            cmd.CommandTimeout = 0;
            AddParams(cmd, qry);

            cmd.Connection = automaticConnectionScope.GetConnection<SqlCeConnection>();
            //let this bubble up
            IDataReader rdr;

            //Thanks jcoenen!
            try
            {
                // if it is a shared connection, we shouldn't be telling the reader to close it when it is done
                if (automaticConnectionScope.IsUsingSharedConnection)
                    rdr = cmd.ExecuteReader();
                else
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (SqlCeException)
            {
                // AutoConnectionScope will figure out what to do with the connection
                automaticConnectionScope.Dispose();
                //rethrow retaining stack trace.
                throw;
            }
            CheckoutOutputParams(cmd, qry);

            return rdr;
        }

        public override T GetDataSet<T>(QueryCommand qry)
        {
            T ds = new T();
            if (qry.CommandType == CommandType.Text)
            {
                qry.CommandSql = "/* GetDataSet() */ " + qry.CommandSql;
            }
            SqlCeCommand cmd = new SqlCeCommand(qry.CommandSql);
            cmd.CommandType = qry.CommandType;
            cmd.CommandTimeout = 0;
            SqlCeDataAdapter da = new SqlCeDataAdapter(cmd);

            AddTableMappings(da, ds);
            using (AutomaticConnectionScope conn = new AutomaticConnectionScope(this))
            {
                cmd.Connection = conn.GetConnection<SqlCeConnection>();
                AddParams(cmd, qry);
                da.Fill(ds);

                CheckoutOutputParams(cmd, qry);

                return ds;
            }
        }

        public override object ExecuteScalar(QueryCommand qry)
        {
            //using (SqlCeConnection conn = new SqlCeConnection(connectionString))
            using (AutomaticConnectionScope automaticConnectionScope = new AutomaticConnectionScope(this))
            {
                SqlCeCommand cmd = new SqlCeCommand(qry.CommandSql);
                cmd.CommandType = qry.CommandType;
                cmd.CommandTimeout = 0;
                AddParams(cmd, qry);
                cmd.Connection = automaticConnectionScope.GetConnection<SqlCeConnection>();

                object result = null;
                if (qry.CommandSql.ToLower().Contains("insert"))
                {
                    cmd.ExecuteScalar();
                    SqlCeCommand outcmd = new SqlCeCommand(SqlFragment.SELECT + "@@IDENTITY" + SqlFragment.AS + "newID;");
                    outcmd.CommandType = CommandType.Text;
                    outcmd.Connection = automaticConnectionScope.GetConnection<SqlCeConnection>();
                    result = outcmd.ExecuteScalar();
                }
                else
                {
                    result = cmd.ExecuteScalar(); 
                }
                CheckoutOutputParams(cmd, qry);
                return result;
            }
        }

        public override int ExecuteQuery(QueryCommand qry)
        {
            using (AutomaticConnectionScope automaticConnectionScope = new AutomaticConnectionScope(this))
            {
                SqlCeCommand cmd = new SqlCeCommand(qry.CommandSql);
                cmd.CommandType = qry.CommandType;
                cmd.CommandTimeout = 0;

                AddParams(cmd, qry);
                cmd.Connection = automaticConnectionScope.GetConnection<SqlCeConnection>();
                Console.WriteLine(cmd.CommandText);
                int result = cmd.ExecuteNonQuery();
                CheckoutOutputParams(cmd, qry);
                return result;
            }
        }


        private static DataSet dsManyToManyCheck = new DataSet();
        private const string MANY_TO_MANY_CHECK_ALL =
@"SELECT 
    FK_Table = FK.TABLE_NAME, 
    FK_Column = CU.COLUMN_NAME, 
    PK_Table  = PK.TABLE_NAME, 
    PK_Column = PT.COLUMN_NAME, 
    Constraint_Name = C.CONSTRAINT_NAME
FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS C
INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS FK ON C.CONSTRAINT_NAME = FK.CONSTRAINT_NAME
INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS PK ON C.UNIQUE_CONSTRAINT_NAME = PK.CONSTRAINT_NAME
INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE CU ON C.CONSTRAINT_NAME = CU.CONSTRAINT_NAME
INNER JOIN    
(    
    SELECT i1.TABLE_NAME, i2.COLUMN_NAME
    FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS i1
    INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE i2 ON i1.CONSTRAINT_NAME = i2.CONSTRAINT_NAME
    WHERE i1.CONSTRAINT_TYPE = 'PRIMARY KEY'
)
PT ON PT.TABLE_NAME = PK.TABLE_NAME

WHERE FK.TABLE_NAME IN
    (
        SELECT tc.table_Name FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS tc
        JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS kcu ON tc.Constraint_name = kcu.Constraint_Name
        JOIN 
        (
            SELECT tc.Table_Name, kcu.Column_Name AS Column_Name FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS tc
            JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS kcu ON tc.Constraint_name = kcu.Constraint_Name
            WHERE Constraint_Type = 'FOREIGN KEY'
        ) 
        AS t ON t.Table_Name = tc.table_Name AND t.Column_Name = kcu.Column_Name
        WHERE Constraint_Type = 'PRIMARY KEY'
        GROUP BY tc.Constraint_Name, tc.Table_Name HAVING COUNT(*) > 1   
    )"; //Thanks Jim!


        private static DataSet dsColumns = new DataSet();
        private const string TABLE_COLUMN_SQL_ALL =
@"SELECT 
    'DataBase' AS [Database],
    'dbo' AS Owner, 
    TABLE_NAME AS TableName, 
    COLUMN_NAME AS ColumnName, 
    ORDINAL_POSITION AS OrdinalPosition, 
    COLUMN_DEFAULT AS DefaultSetting, 
    IS_NULLABLE AS IsNullable, DATA_TYPE AS DataType, 
    CHARACTER_MAXIMUM_LENGTH AS MaxLength, 
    DATETIME_PRECISION AS DatePrecision,
	case when AUTOINC_SEED is not null then 1 else 0 end AS IsIdentity,
	0 as IsComputed
FROM  INFORMATION_SCHEMA.COLUMNS";

        private static DataSet dsIndex = new DataSet();
        private const string INDEX_SQL_ALL =
@"SELECT
    KCU.TABLE_NAME as TableName,
    KCU.COLUMN_NAME as ColumnName, 
    TC.CONSTRAINT_TYPE as ConstraintType 
FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE KCU
JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS TC
ON KCU.CONSTRAINT_NAME=TC.CONSTRAINT_NAME";

        private static DataSet dsFK = new DataSet();
        private const string FOREIGN_TABLE_LIST_ALL =
@"select c.CONSTRAINT_NAME as Constraint_Name, c.COLUMN_NAME as PK_Column, cr.COLUMN_NAME as FK_Column, cr.TABLE_NAME as FK_Table
from INFORMATION_SCHEMA.TABLE_CONSTRAINTS fk 
join INFORMATION_SCHEMA.KEY_COLUMN_USAGE c on c.CONSTRAINT_NAME = fk.CONSTRAINT_NAME
join INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS rc on rc.CONSTRAINT_NAME = fk.CONSTRAINT_NAME
join INFORMATION_SCHEMA.KEY_COLUMN_USAGE cr on cr.CONSTRAINT_NAME = rc.UNIQUE_CONSTRAINT_NAME 
	and cr.ORDINAL_POSITION = c.ORDINAL_POSITION
where fk.CONSTRAINT_TYPE = 'FOREIGN KEY'
order by c.CONSTRAINT_NAME, c.ORDINAL_POSITION";


        private static DataSet dsPK = new DataSet();
        private const string PRIMARY_TABLE_LIST_ALL =
@"SELECT 
    TC.TABLE_NAME AS PK_TABLE,
    KCU.TABLE_NAME AS FK_TABLE,
    KCU.COLUMN_NAME AS FK_COLUMN
FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE KCU
JOIN INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS RC ON KCU.CONSTRAINT_NAME=RC.CONSTRAINT_NAME
JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS TC ON RC.UNIQUE_CONSTRAINT_NAME=TC.CONSTRAINT_NAME";

        private static DataSet dsManyToManyMap = new DataSet();
        private const string MANY_TO_MANY_FOREIGN_MAP_ALL =
@"SELECT 
    FK_Table  = FK.TABLE_NAME,
    FK_Column = CU.COLUMN_NAME,
    PK_Table  = PK.TABLE_NAME,
    PK_Column = PT.COLUMN_NAME, Constraint_Name = C.CONSTRAINT_NAME
FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS C
INNER JOIN 	INFORMATION_SCHEMA.TABLE_CONSTRAINTS FK ON C.CONSTRAINT_NAME = FK.CONSTRAINT_NAME
INNER JOIN  INFORMATION_SCHEMA.TABLE_CONSTRAINTS PK ON C.UNIQUE_CONSTRAINT_NAME = PK.CONSTRAINT_NAME
INNER JOIN  INFORMATION_SCHEMA.KEY_COLUMN_USAGE CU ON C.CONSTRAINT_NAME = CU.CONSTRAINT_NAME
INNER JOIN	
    (
        SELECT i1.TABLE_NAME, i2.COLUMN_NAME
        FROM  INFORMATION_SCHEMA.TABLE_CONSTRAINTS i1
        INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE i2 ON i1.CONSTRAINT_NAME = i2.CONSTRAINT_NAME
        WHERE i1.CONSTRAINT_TYPE = 'PRIMARY KEY'
    ) 
PT ON PT.TABLE_NAME = PK.TABLE_NAME";

        private static DataSet dsExtendedProperties = new DataSet();

        private const string EXTENDED_PROPERTIES_ALL =
@"SELECT 
    t.name AS [TABLE_NAME], 
    c.name AS [COLUMN_NAME], 
    ep.name AS [EXTENDED_NAME],
    value AS [EXTENDED_VALUE]
FROM sys.extended_properties AS ep
INNER JOIN sys.tables AS t ON ep.major_id = t.object_id 
LEFT JOIN sys.columns AS c ON ep.major_id = c.object_id AND ep.minor_id = c.column_id
WHERE class = 1 OR class = 3";

        private const string EXTENDED_PROPERTIES_TABLES_2000 =
@"SELECT 
    objname AS TABLE_NAME,
    [name] AS EXTENDED_NAME,
    [value] AS EXTENDED_VALUE
FROM fn_listextendedproperty (NULL, 'SCHEMA', '{0}', 'TABLE', default, NULL, NULL);";

        private const string EXTENDED_PROPERTIES_COLUMNS_2000 =
@"SELECT 
    objname AS COLUMN_NAME,
    [name] AS EXTENDED_NAME,
    [value] AS EXTENDED_VALUE
FROM fn_listextendedproperty (NULL, 'SCHEMA', '{0}', 'TABLE', '{1}', 'COLUMN', DEFAULT);";



        private void LoadExtendedPropertyDataSet()
        {
            if (dsExtendedProperties.Tables[Name] == null)
            {
                QueryCommand cmdExtProps = new QueryCommand(EXTENDED_PROPERTIES_ALL, Name);
                DataTable dt = new DataTable(Name);
                dt.Load(GetReader(cmdExtProps));
                dsExtendedProperties.Tables.Add(dt);
            }
        }

        private void SetExtendedTableProperties(TableSchema.AbstractTableSchema tblSchema)
        {
            if (UseExtendedProperties)
            {
                DataRow[] drTableProps = null;
                if (Utility.IsSql2005(this))
                {
                    LoadExtendedPropertyDataSet();
                    drTableProps = dsExtendedProperties.Tables[Name].Select("TABLE_NAME ='" + tblSchema.TableName + "' AND COLUMN_NAME IS NULL");
                }
                else if (Utility.IsSql2000(this))
                {
                    string query = String.Format(EXTENDED_PROPERTIES_TABLES_2000, tblSchema.SchemaName);
                    QueryCommand cmdTable = new QueryCommand(query, Name);
                    DataTable dt = new DataTable(Name);
                    dt.Load(GetReader(cmdTable));
                    drTableProps = dt.Select("TABLE_NAME ='" + tblSchema.TableName + "'");
                }
                if (drTableProps != null)
                {
                    for (int i = 0; i < drTableProps.Length; i++)
                    {
                        tblSchema.ExtendedProperties.Add(new TableSchema.ExtendedProperty(drTableProps[i]["EXTENDED_NAME"].ToString(), drTableProps[i]["EXTENDED_VALUE"].ToString()));
                    }
                    tblSchema.ApplyExtendedProperties();
                }
            }
        }

        private void SetExtendedColumnProperties(TableSchema.AbstractTableSchema tblSchema, TableSchema.TableColumn col)
        {
            if (UseExtendedProperties && Utility.IsSql2005(this))
            {
                DataRow[] drColumnProps = null;
                if (Utility.IsSql2005(this))
                {
                    LoadExtendedPropertyDataSet();
                    drColumnProps = dsExtendedProperties.Tables[Name].Select("TABLE_NAME ='" + tblSchema.TableName + "' AND COLUMN_NAME = '" + col.ColumnName + "'");
                }
                else if (Utility.IsSql2000(this))
                {
                    string query = String.Format(EXTENDED_PROPERTIES_COLUMNS_2000, tblSchema.SchemaName, tblSchema.TableName);
                    QueryCommand cmdColumn = new QueryCommand(query, Name);
                    DataTable dt = new DataTable(Name);
                    dt.Load(GetReader(cmdColumn));
                    drColumnProps = dt.Select("COLUMN_NAME ='" + col.ColumnName + "'");
                }
                if (drColumnProps != null)
                {
                    for (int j = 0; j < drColumnProps.Length; j++)
                    {
                        col.ExtendedProperties.Add(new TableSchema.ExtendedProperty(drColumnProps[j]["EXTENDED_NAME"].ToString(), drColumnProps[j]["EXTENDED_VALUE"].ToString()));
                        col.ApplyExtendedProperties();
                    }
                }
            }
        }

        public override TableSchema.Table GetTableSchema(string tableName, TableType tableType)
        {
            TableSchema.TableColumnCollection columns = new TableSchema.TableColumnCollection();
            TableSchema.Table tbl = new TableSchema.Table(tableName, tableType, this);
            //SetExtendedTableProperties(tbl);

            string columnqry = @"SELECT
    TABLE_NAME AS TableName, 
    COLUMN_NAME AS ColumnName,
 
    DATA_TYPE AS DataType,     IS_NULLABLE AS IsNullable,
    case when CHARACTER_MAXIMUM_LENGTH is null then 0  else CHARACTER_MAXIMUM_LENGTH end AS MaxLength,
    case when AUTOINC_SEED is null then 0 else 1 end as IsIdentity

    FROM  INFORMATION_SCHEMA.COLUMNS";
            tbl.ForeignKeys = new TableSchema.ForeignKeyTableCollection();

            if (dsColumns.Tables[Name] == null)
            {
                QueryCommand cmdColumns = new QueryCommand(columnqry, Name);
                cmdColumns.CommandTimeout = 0;
                DataTable dt = new DataTable(Name);
                dt.Load(GetReader(cmdColumns));
                dsColumns.Tables.Add(dt);
            }

            DataRow[] drColumns = dsColumns.Tables[Name].Select("TableName ='" + tableName + "'");

            for (int i = 0; i < drColumns.Length; i++)
            {
                string nativeDataType = drColumns[i][SqlSchemaVariable.DATA_TYPE].ToString().ToLower();
                TableSchema.TableColumn column = new TableSchema.TableColumn(tbl);
                column.ColumnName = drColumns[i][SqlSchemaVariable.COLUMN_NAME].ToString();
                column.DataType = GetDbType(nativeDataType);
               /* if (drColumns[i][SqlSchemaVariable.COLUMN_DEFAULT] != DBNull.Value)
                {
                    string defaultSetting = drColumns[i][SqlSchemaVariable.COLUMN_DEFAULT].ToString().Trim();
                    if (defaultSetting.ToLower().IndexOf("newsequentialid()") > -1)
                    {
                        column.DefaultSetting = SqlSchemaVariable.DEFAULT;
                    }
                    else
                    {
                        column.DefaultSetting = defaultSetting;
                    }
                }*/
                column.AutoIncrement = Convert.ToBoolean(drColumns[i][SqlSchemaVariable.IS_IDENTITY]);
                int maxLength;
                int.TryParse(drColumns[i][SqlSchemaVariable.MAX_LENGTH].ToString(), out maxLength);
                column.MaxLength = maxLength;
                column.IsNullable = drColumns[i][SqlSchemaVariable.IS_NULLABLE].ToString() == "YES";
                //Does Not Support Computed Columns 
                bool isComputed = false;
                column.IsReadOnly = (nativeDataType == "timestamp");
                columns.Add(column);
                //tbl.SchemaName = drColumns[i]["Owner"].ToString();
                SetExtendedColumnProperties(tbl, column);
            }

            if (dsIndex.Tables[Name] == null)
            {
                QueryCommand cmdIndex = new QueryCommand(INDEX_SQL_ALL, Name);
                cmdIndex.CommandTimeout = 0;
                DataTable dt = new DataTable(Name);
                dt.Load(GetReader(cmdIndex));
                dsIndex.Tables.Add(dt);
            }

            DataRow[] drIndexes = dsIndex.Tables[Name].Select("TableName ='" + tableName + "'");
            for (int i = 0; i < drIndexes.Length; i++)
            {
                string colName = drIndexes[i][SqlSchemaVariable.COLUMN_NAME].ToString();
                string constraintType = drIndexes[i][SqlSchemaVariable.CONSTRAINT_TYPE].ToString();
                TableSchema.TableColumn column = columns.GetColumn(colName);

                if (Utility.IsMatch(constraintType, SqlSchemaVariable.PRIMARY_KEY))
                {
                    column.IsPrimaryKey = true;
                }
                else if (Utility.IsMatch(constraintType, SqlSchemaVariable.FOREIGN_KEY))
                {
                    column.IsForeignKey = true;
                }
                //HACK: Allow second pass naming adjust based on whether a column is keyed
                column.ColumnName = column.ColumnName;
                SetExtendedColumnProperties(tbl, column);
            }

            if (dsPK.Tables[Name] == null)
            {
                QueryCommand cmdPK = new QueryCommand(PRIMARY_TABLE_LIST_ALL, Name);
                cmdPK.CommandTimeout = 0;
                DataTable dt = new DataTable(Name);
                dt.Load(GetReader(cmdPK));
                dsPK.Tables.Add(dt);
            }

            DataRow[] drPK = dsPK.Tables[Name].Select("PK_Table ='" + tableName + "'");
            for (int i = 0; i < drPK.Length; i++)
            {
                string colName = drPK[i]["FK_Column"].ToString();
                string fkName = drPK[i]["FK_Table"].ToString();

                //columns.GetColumn(colName).PrimaryKeyTableName = fkName;
                TableSchema.PrimaryKeyTable pkTable = new TableSchema.PrimaryKeyTable(this);
                pkTable.ColumnName = colName;
                pkTable.TableName = fkName;
                SetExtendedTableProperties(pkTable);
                tbl.PrimaryKeyTables.Add(pkTable);
            }

            if (dsFK.Tables[Name] == null)
            {
                QueryCommand cmdFK = new QueryCommand(FOREIGN_TABLE_LIST_ALL, Name);
                DataTable dt = new DataTable(Name);
                dt.Load(GetReader(cmdFK));
                dsFK.Tables.Add(dt);
            }

            DataRow[] drFK = dsFK.Tables[Name].Select("FK_Table ='" + tableName + "'");
            ArrayList usedConstraints = new ArrayList();
            for (int i = 0; i < drFK.Length; i++)
            {
                string constraintName = drFK[i]["Constraint_Name"].ToString();
                if (!usedConstraints.Contains(constraintName))
                {
                    usedConstraints.Add(constraintName);
                    string colName = drFK[i]["FK_Column"].ToString();
                    string fkName = drFK[i]["PK_Table"].ToString();
                    columns.GetColumn(colName).ForeignKeyTableName = fkName;
                    TableSchema.ForeignKeyTable fkTable = new TableSchema.ForeignKeyTable(this);
                    fkTable.ColumnName = colName;
                    fkTable.TableName = fkName;
                    SetExtendedTableProperties(fkTable);
                    tbl.ForeignKeys.Add(fkTable);
                }
            }

            // untill i can figure out the problem with nested queries .. this is not supported
            //if (dsManyToManyCheck.Tables[Name] == null)
            //{
            //    QueryCommand cmdM2M = new QueryCommand(MANY_TO_MANY_CHECK_ALL, Name);
            //    DataTable dt = new DataTable(Name);
            //    dt.Load(GetReader(cmdM2M));
            //    dsManyToManyCheck.Tables.Add(dt);
            //}

            //DataRow[] drs = dsManyToManyCheck.Tables[Name].Select("PK_Table = '" + tableName + "'");
            //if (drs.Length > 0)
            //{
            //    for (int count = 0; count < drs.Length; count++)
            //    {
            //        string mapTable = drs[count]["FK_Table"].ToString();
            //        string localKey = drs[count]["FK_Column"].ToString();
            //        if (dsManyToManyMap.Tables[Name] == null)
            //        {
            //            QueryCommand cmdM2MMap = new QueryCommand(MANY_TO_MANY_FOREIGN_MAP_ALL, Name);
            //            DataTable dt = new DataTable(Name);
            //            dt.Load(GetReader(cmdM2MMap));
            //            dsManyToManyMap.Tables.Add(dt);
            //        }


            //        DataRow[] drMap = dsManyToManyMap.Tables[Name].Select("FK_Table = '" + mapTable + "' AND PK_Table <> '" + tableName + "'");

            //        for (int i = 0; i < drMap.Length; i++)
            //        {
            //            TableSchema.ManyToManyRelationship m = new TableSchema.ManyToManyRelationship(mapTable, tbl.Provider);
            //            m.ForeignTableName = drMap[i]["PK_Table"].ToString();
            //            m.ForeignPrimaryKey = drMap[i]["PK_Column"].ToString();
            //            m.MapTableLocalTableKeyColumn = localKey;
            //            m.MapTableForeignTableKeyColumn = drMap[i]["FK_Column"].ToString();
            //            tbl.ManyToManys.Add(m);
            //        }
            //    }
            //}
            tbl.Columns = columns;
            return tbl;
        }

        private const string SP_PARAM_SQL_ALL = @"SELECT SPECIFIC_NAME AS SPName, ORDINAL_POSITION AS OrdinalPosition, 
                                                PARAMETER_MODE AS ParamType, IS_RESULT AS IsResult, PARAMETER_NAME AS Name, 
                                                DATA_TYPE AS DataType, CHARACTER_MAXIMUM_LENGTH AS DataLength, REPLACE(PARAMETER_NAME, '@', '') 
                                                AS CleanName, PARAMETER_MODE as [mode]
                                                FROM INFORMATION_SCHEMA.PARAMETERS";

        private DataTable dtParamSql = null;


        public override IDataReader GetSPParams(string spName)
        {
            if (dtParamSql == null)
            {
                QueryCommand cmdSP = new QueryCommand(SP_PARAM_SQL_ALL, Name);
                dtParamSql = new DataTable();
                dtParamSql.Load(GetReader(cmdSP));
            }

            DataView dv = new DataView(dtParamSql);
            dv.RowFilter = "SPName = '" + spName + "'";
            dv.Sort = "OrdinalPosition";
            DataTable dtNew = dv.ToTable();
            return dtNew.CreateDataReader();
        }

        public override string[] GetSPList()
        {
            QueryCommand cmd = new QueryCommand("/* GetSPList() */ " + SP_SQL, Name);

            //QueryCommand cmd = new QueryCommand("/* GetSPList() */ select name from sysobjects where xtype = 'P' AND name not like 'sp_%'", Name);
            StringBuilder sList = new StringBuilder();
            using (IDataReader rdr = GetReader(cmd))
            {
                while (rdr.Read())
                {
                    sList.Append(rdr[0]);
                    sList.Append("|");
                }
                rdr.Close();
            }
            string strList = sList.ToString();
            return strList.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public override string[] GetViewNameList()
        {
            if (ViewNames == null || !CurrentConnectionStringIsDefault)
            {
                QueryCommand cmd = new QueryCommand("/* GetViewNameList() */ " + VIEW_SQL, Name);
                StringBuilder sList = new StringBuilder();
                using (IDataReader rdr = GetReader(cmd))
                {
                    while (rdr.Read())
                    {
                        string viewName = rdr[SqlSchemaVariable.NAME].ToString();

                        if (String.IsNullOrEmpty(ViewStartsWith) || viewName.StartsWith(ViewStartsWith))
                        {
                            sList.Append(rdr[SqlSchemaVariable.NAME]);
                            sList.Append("|");
                        }
                    }
                    rdr.Close();
                }
                string strList = sList.ToString();
                string[] tempViewNames = strList.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                Array.Sort(tempViewNames);
                if (CurrentConnectionStringIsDefault)
                {
                    ViewNames = tempViewNames;
                }
                else
                {
                    return tempViewNames;
                }
            }
            return ViewNames;
        }

        public override string[] GetTableNameList()
        {
            if (TableNames == null || !CurrentConnectionStringIsDefault)
            {
                QueryCommand cmd = new QueryCommand("select TABLE_NAME from INFORMATION_SCHEMA.TABLES where TABLE_TYPE = 'TABLE'");
                cmd.CommandTimeout = 0;
                StringBuilder sList = new StringBuilder();
                using (IDataReader rdr = GetReader(cmd))
                {
                    while (rdr.Read())
                    {
                        sList.Append(rdr[0]);
                        sList.Append("|");
                    }
                    rdr.Close();
                }
                string strList = sList.ToString();
                string[] tempTableNames = strList.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                Array.Sort(tempTableNames);
                if (CurrentConnectionStringIsDefault)
                {
                    TableNames = tempTableNames;
                }
                else
                {
                    return tempTableNames;
                }
            }
            return TableNames;
        }

        public override ArrayList GetPrimaryKeyTableNames(string tableName)
        {
            QueryCommand cmd = new QueryCommand("/* GetPrimaryKeyTableNames(" + tableName + ") */ " + GET_PRIMARY_KEY_SQL, Name);
            cmd.AddParameter("tblName", tableName);
            ArrayList list = new ArrayList();

            using (IDataReader rdr = GetReader(cmd))
            {
                while (rdr.Read())
                {
                    list.Add(new string[] { rdr[SqlSchemaVariable.TABLE_NAME].ToString(), rdr[SqlSchemaVariable.COLUMN_NAME].ToString() });
                }
                rdr.Close();
            }
            return list;
        }

        public override TableSchema.Table[] GetPrimaryKeyTables(string tableName)
        {
            QueryCommand cmd = new QueryCommand("/* GetPrimaryKeyTables(" + tableName + ") */ " + GET_PRIMARY_KEY_SQL, Name);
            cmd.AddParameter("tblName", tableName);
            ArrayList names = new ArrayList();

            using (IDataReader rdr = GetReader(cmd))
            {
                while (rdr.Read())
                {
                    names.Add(rdr[SqlSchemaVariable.TABLE_NAME].ToString());
                }
                rdr.Close();
            }

            if (names.Count > 0)
            {
                TableSchema.Table[] tables = new TableSchema.Table[names.Count];

                for (int i = 0; i < names.Count; i++)
                {
                    tables[i] = DataService.GetSchema((string)names[i], Name, TableType.Table);
                }
                return tables;
            }
            return null;
        }

        public override string GetForeignKeyTableName(string fkColumnName, string tableName)
        {
            QueryCommand cmd = new QueryCommand("/* GetForeignKeyTableName(" + fkColumnName + "," + tableName + ") */ " + GET_FOREIGN_KEY_SQL, Name);
            cmd.AddParameter("columnName", fkColumnName);
            cmd.AddParameter("tblName", tableName);

            object result = ExecuteScalar(cmd);
            if (result == null)
            {
                return null;
            }
            return result.ToString();
        }

        public override string GetForeignKeyTableName(string fkColumnName)
        {
            QueryCommand cmd = new QueryCommand("/* GetForeignKeyTableName(" + fkColumnName + ") */ " + GET_TABLE_SQL, Name);
            cmd.AddParameter("columnName", fkColumnName);

            object result = ExecuteScalar(cmd);
            if (result == null)
            {
                return null;
            }
            return result.ToString();
        }

        public override string[] GetForeignKeyTables(string tableName)
        {
            QueryCommand cmd = new QueryCommand("/* GetForeignKeyTables(" + tableName + ") */ " + FOREIGN_TABLE_LIST, Name);
            cmd.AddParameter("@tblName", tableName);
            StringBuilder sList = new StringBuilder();
            using (IDataReader rdr = GetReader(cmd))
            {
                while (rdr.Read())
                {
                    sList.Append(rdr["TABLE_NAME"]);
                    sList.Append("|");
                }
                rdr.Close();
            }
            string strList = sList.ToString();
            return strList.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public override DbType GetDbType(string sqlType)
        {
            switch (sqlType)
            {
                case "varchar":
                    return DbType.String;
                case "nvarchar":
                    return DbType.String;
                case "int":
                    return DbType.Int32;
                case "uniqueidentifier":
                    return DbType.Guid;
                case "datetime":
                    return DbType.DateTime;
                case "bigint":
                    return DbType.Int64;
                case "binary":
                    return DbType.Binary;
                case "bit":
                    return DbType.Boolean;
                case "char":
                    return DbType.AnsiStringFixedLength;
                case "decimal":
                    return DbType.Decimal;
                case "float":
                    return DbType.Double;
                case "image":
                    return DbType.Binary;
                case "money":
                    return DbType.Currency;
                case "nchar":
                    return DbType.String;
                case "ntext":
                    return DbType.String;
                case "numeric":
                    return DbType.Decimal;
                case "real":
                    return DbType.Decimal;
                case "smalldatetime":
                    return DbType.DateTime;
                case "smallint":
                    return DbType.Int16;
                case "smallmoney":
                    return DbType.Currency;
                case "sql_variant":
                    return DbType.String;
                case "sysname":
                    return DbType.String;
                case "text":
                    return DbType.String;
                case "timestamp":
                    return DbType.Byte;
                case "tinyint":
                    return DbType.Int16;
                case "varbinary":
                    return DbType.Binary;
                default:
                    return DbType.String;
            }
        }

        public override IDbCommand GetCommand(QueryCommand qry)
        {
            SqlCeCommand cmd = new SqlCeCommand(qry.CommandSql);
            AddParams(cmd, qry);
            return cmd;
        }

        #region Schema Bits

        const string TABLE_BY_PK = @"SELECT TC.TABLE_NAME as tableName 
                        FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE KCU
                        JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS TC
                        ON KCU.CONSTRAINT_NAME=TC.CONSTRAINT_NAME 
                        WHERE column_name=@columnName
                        AND CONSTRAINT_TYPE='PRIMARY KEY'
                        AND TC.TABLE_NAME NOT LIKE '%'+@mapSuffix
                        AND KCU.ORDINAL_POSITION=1";

        const string FOREIGN_TABLE_LIST = @"SELECT KCU.COLUMN_NAME,TC.TABLE_NAME
                    FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE KCU
                    JOIN INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS RC ON KCU.CONSTRAINT_NAME=RC.CONSTRAINT_NAME
                    JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS TC  ON RC.UNIQUE_CONSTRAINT_NAME=TC.CONSTRAINT_NAME
                    WHERE KCU.TABLE_NAME=@tblName";

        private const string SP_SQL = @"SELECT SPECIFIC_NAME AS SPName, ROUTINE_DEFINITION AS SQL, CREATED AS CreatedOn, LAST_ALTERED AS ModifiedOn 
                                    FROM INFORMATION_SCHEMA.ROUTINES
                                    WHERE ROUTINE_TYPE='PROCEDURE' AND SPECIFIC_NAME NOT LIKE 'sp_%diagram%'";

        private const string TABLE_SQL = @"SELECT TABLE_CATALOG AS [Database], TABLE_SCHEMA AS Owner, TABLE_NAME AS Name, TABLE_TYPE 
                                        FROM INFORMATION_SCHEMA.TABLES
                                        WHERE (TABLE_TYPE = 'BASE TABLE') AND (TABLE_NAME <> N'sysdiagrams') AND (TABLE_NAME <> N'dtproperties')";

        private const string VIEW_SQL = @"SELECT TABLE_CATALOG AS [Database], TABLE_SCHEMA AS Owner, TABLE_NAME AS Name, TABLE_TYPE
                                        FROM INFORMATION_SCHEMA.TABLES
                                        WHERE (TABLE_TYPE = 'VIEW') AND (TABLE_NAME <> N'sysdiagrams')";

        private const string GET_TABLE_SQL = @"SELECT KCU.TABLE_NAME as TableName
                                            FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE KCU
                                            JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS TC
                                            ON KCU.CONSTRAINT_NAME=TC.CONSTRAINT_NAME
                                            WHERE KCU.COLUMN_NAME=@columnName AND TC.CONSTRAINT_TYPE='PRIMARY KEY'";

        private const string GET_FOREIGN_KEY_SQL = @"SELECT TC.TABLE_NAME AS TableName
                                           FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE KCU
                                           JOIN INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS RC ON KCU.CONSTRAINT_NAME=RC.CONSTRAINT_NAME
                                           JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS TC  ON RC.UNIQUE_CONSTRAINT_NAME=TC.CONSTRAINT_NAME
                                           WHERE KCU.COLUMN_NAME=@columnName AND KCU.TABLE_NAME = @tblName";

        private const string GET_PRIMARY_KEY_SQL = @"SELECT KCU.TABLE_NAME AS TableName, KCU.COLUMN_NAME AS ColumnName
                                           FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE KCU
                                           JOIN INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS RC ON KCU.CONSTRAINT_NAME=RC.CONSTRAINT_NAME
                                           JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS TC ON RC.UNIQUE_CONSTRAINT_NAME=TC.CONSTRAINT_NAME
                                           WHERE TC.TABLE_NAME = @tblName";
        //thanks Jon G!
        private const string PAGING_VIEW_SQL = @"					
					DECLARE @Page int
					DECLARE @PageSize int

					SET @Page = {4}
					SET @PageSize = {5}

					SET NOCOUNT ON
                
                    
                    SELECT * INTO #temp FROM {0} WHERE 1 = 0
                    ALTER TABLE #temp ADD _indexID int PRIMARY KEY IDENTITY(1,1)
                    
                    INSERT INTO #temp SELECT * FROM {0} {2} {3}
                    

                    SELECT * FROM #temp
                    WHERE _indexID BETWEEN ((@Page - 1) * @PageSize + 1) AND (@Page * @PageSize)
					
                    --clean up
                    DROP TABLE #temp
                    ";


        private const string PAGING_SQL = @"					
					DECLARE @Page int
					DECLARE @PageSize int

					SET @Page = {5}
					SET @PageSize = {6}

					SET NOCOUNT ON

					-- create a temp table to hold order ids
					DECLARE @TempTable TABLE (IndexId int identity, _keyID {7})

					-- insert the table ids and row numbers into the memory table
					INSERT INTO @TempTable
					(
					  _keyID
					)
					SELECT 
						{0}
					FROM
						[{1}]
					{3}
					{4}

					-- select only those rows belonging to the proper page
					SELECT 
					{2}
					FROM {1}
					INNER JOIN @TempTable t ON [{1}].[{0}] = t.[_keyID]
					WHERE t.IndexId BETWEEN ((@Page - 1) * @PageSize + 1) AND (@Page * @PageSize)";

        #endregion

        /// <summary>
        /// Executes a transaction using the passed-commands
        /// </summary>
        /// <param name="commands"></param>
        public override void ExecuteTransaction(QueryCommandCollection commands)
        {
            //make sure we have at least one
            if (commands.Count > 0)
            {
                SqlCeCommand cmd = null;

                //a using statement will make sure we close off the connection

                using (AutomaticConnectionScope conn = new AutomaticConnectionScope(this))
                {
                    //open up the connection and start the transaction
                    if (conn.GetConnection<SqlCeConnection>().State == ConnectionState.Closed)
                        conn.GetConnection<SqlCeConnection>().Open();

                    SqlCeTransaction trans = conn.GetConnection<SqlCeConnection>().BeginTransaction();

                    foreach (QueryCommand qry in commands)
                    {
                        if (qry.CommandType == CommandType.Text)
                        {
                            qry.CommandSql = "/* ExecuteTransaction() */ " + qry.CommandSql;
                        }
                        cmd = new SqlCeCommand(qry.CommandSql, conn.GetConnection<SqlCeConnection>(), trans);
                        cmd.CommandType = qry.CommandType;

                        foreach (QueryParameter param in qry.Parameters)
                        {
                            SqlCeParameter sqlParam = new SqlCeParameter();
                            sqlParam.Value = param.ParameterValue;
                            sqlParam.ParameterName = param.ParameterName;
                            sqlParam.DbType = param.DataType;
                            cmd.Transaction = trans;
                            cmd.Parameters.Add(sqlParam);
                        }
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (SqlCeException x)
                        {
                            //if there's an error, roll everything back
                            trans.Rollback();

                            //clean up
                            conn.GetConnection<SqlCeConnection>().Close();
                            cmd.Dispose();

                            //throw the error retaining the stack.
                            throw new Exception(x.Message);
                        }
                    }
                    //if we get to this point, we're good to go
                    trans.Commit();

                    //close off the connection
                    conn.GetConnection<SqlCeConnection>().Close();
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }
            else
            {
                throw new Exception("No commands present");
            }
        }

        #region SQL Builders

        public override string GetSql(Query qry)
        {
            string result = String.Empty;
            switch (qry.QueryType)
            {
                case QueryType.Select:
                    result = GetSelectSql(qry);
                    break;
                case QueryType.Update:
                    result = GetUpdateSql(qry);
                    break;
                case QueryType.Insert:
                    result = GetInsertSql(qry);
                    break;
                case QueryType.Delete:
                    result = GetDeleteSql(qry);
                    break;
            }
            return result;
        }

        //this is only used with the SQL constructors below
        //it's not used in the command builders above, which need to set the parameters
        //right at the time of the command build

        /// <summary>
        /// Creates a SELECT statement based on the Query object settings
        /// </summary>
        /// <returns></returns>
        public override string GetSelectSql(Query qry)
        {
            TableSchema.Table table = qry.Schema;

            //different rules for how to do TOP
            string select = "/* GetSelectSql(" + table.Name + ") */ " + SqlFragment.SELECT + " ";

            StringBuilder order = new StringBuilder();
            StringBuilder query = new StringBuilder();
            string columns;

            //append on the selectList, which is a property that can be set
            //and is "*" by default

            if (qry.SelectList != null && qry.SelectList.Trim().Length >= 2)
            {
                columns = qry.SelectList;
            }
            else
            {
                columns = GetQualifiedSelect(table);
            }

            string where = BuildWhere(qry);

            //Finally, do the orderby

            if (qry.OrderByCollection.Count > 0)
            {
                for (int j = 0; j < qry.OrderByCollection.Count; j++)
                {
                    string orderString = qry.OrderByCollection[j].OrderString;
                    if (!String.IsNullOrEmpty(orderString))
                    {
                        order.Append(orderString);
                        if (j + 1 != qry.OrderByCollection.Count)
                        {
                            order.Append(", ");
                        }
                    }
                }
            }
            else
            {
                if (table.PrimaryKey != null)
                {
                    order.Append(OrderBy.Asc(table.PrimaryKey.ColumnName).OrderString);
                }
            }

            if (qry.PageIndex < 0)
            {
                query.Append(select);
                query.Append(columns);
                query.Append(SqlFragment.FROM);
                query.Append(Utility.QualifyColumnName(table.SchemaName, table.Name, qry.Provider));
                query.Append(where);
                query.Append(order);
                query.Append(";");
            }
            else
            {
                if (table.PrimaryKey != null)
                {
                    query.Append(string.Format(PAGING_SQL, table.PrimaryKey.ColumnName, table.Name, columns, where, order, qry.PageIndex, qry.PageSize, Utility.GetSqlDBType(table.PrimaryKey.DataType)));
                    query.Append(";");
                }
                else
                {
                    //pretend it's a view
                    query.Append(string.Format(PAGING_VIEW_SQL, table.Name, columns, where, order, qry.PageIndex, qry.PageSize));
                    query.Append(";");

                }
            }

            return query.ToString();
        }

        /// <summary>
        /// Returns a qualified list of columns ([Table].[Column])
        /// </summary>
        /// <returns></returns>
        protected static string GetQualifiedSelect(TableSchema.Table table)
        {
            StringBuilder sb = new StringBuilder();
            foreach (TableSchema.TableColumn tc in table.Columns)
            {
                sb.AppendFormat(",[{0}].[{1}]",table.Name, tc.ColumnName);
            }

            string result = sb.ToString();
            if (result.Length > 1)
                result = sb.ToString().Substring(1);

            return result;
        }

        /// <summary>
        /// Loops the TableColums[] array for the object, creating a SQL string
        /// for use as an INSERT statement
        /// </summary>
        /// <returns></returns>
        public override string GetInsertSql(Query qry)
        {
            TableSchema.Table table = qry.Schema;

            //split the TablNames and loop out the SQL
            string insertSQL = "/* GetInsertSql(" + table.Name + ") */ " + SqlFragment.INSERT_INTO + Utility.QualifyColumnName(table.SchemaName, table.Name, qry.Provider);
            //string client = DataService.GetClientType();

            string cols = String.Empty;
            string pars = String.Empty;

            //returns Guid from VS2005 only!
            bool primaryKeyIsGuid = false;
            string primaryKeyName = "";

            bool isFirstColumn = true;
            //if table columns are null toss an exception
            foreach (TableSchema.TableColumn col in table.Columns)
            {
                string colName = col.ColumnName;
                if (!(col.DataType == DbType.Guid && col.DefaultSetting != null && col.DefaultSetting == SqlSchemaVariable.DEFAULT))
                {
                    if (!col.AutoIncrement && !col.IsReadOnly)
                    {
                        if (!isFirstColumn)
                        {
                            cols += ",";
                            pars += ",";
                        }

                        isFirstColumn = false;

                        cols += DelimitDbName(colName);
                        pars += Utility.PrefixParameter(colName, this);
                    }
                    if (col.IsPrimaryKey && col.DataType == DbType.Guid)
                    {
                        primaryKeyName = col.ColumnName;
                        primaryKeyIsGuid = true;
                    }
                }
            }

            insertSQL += "(" + cols + ") ";

            //Non Guid's
           // string getInsertValue = SqlFragment.SELECT + "@@IDENTITY" + SqlFragment.AS + "newID;";
            // SQL Server 2005
            /*if (primaryKeyIsGuid)
            {
                if (Utility.IsSql2005(this))
                {
                    insertSQL += " OUTPUT INSERTED.[" + primaryKeyName + "]";
                }
                else
                {
                    getInsertValue = " SELECT @" + primaryKeyName + " as newID;";
                }
            }*/

            insertSQL += "VALUES(" + pars + ");";
            //insertSQL += getInsertValue;

            return insertSQL;
        }

        #endregion

        #region Command Builders

        public override QueryCommand BuildCommand(Query qry)
        {
            QueryCommand cmd = null;
            switch (qry.QueryType)
            {
                case QueryType.Select:
                    cmd = BuildSelectCommand(qry);
                    break;
                case QueryType.Update:
                    cmd = BuildUpdateCommand(qry);
                    break;

                case QueryType.Insert:
                    cmd = null;
                    break;

                case QueryType.Delete:
                    cmd = BuildDeleteCommand(qry);
                    break;
            }
            return cmd;
        }



        #endregion

        #region SQL Scripters
        public override string ScriptData(string tableName)
        {
            return ScriptData(tableName, DataService.Provider.Name);
        }
        public override string ScriptData(string tableName, string providerName)
        {
            StringBuilder fieldList = new StringBuilder();
            StringBuilder insertStatement = new StringBuilder();
            StringBuilder statements = new StringBuilder();
            StringBuilder result = new StringBuilder();
            StringBuilder disableConstraint = new StringBuilder();
            disableConstraint.AppendLine("ALTER TABLE [" + tableName + "] NOCHECK CONSTRAINT ALL");
            disableConstraint.AppendLine("GO");

            StringBuilder enableConstraint = new StringBuilder();
            enableConstraint.AppendLine("ALTER TABLE [" + tableName + "] CHECK CONSTRAINT ALL");
            enableConstraint.AppendLine("GO");

            //QueryCommand cmd = new QueryCommand("SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE TABLE_NAME='"+ tableName +"'");
            //List<string> constraints = new List<string>();
            //using (IDataReader rdr = GetReader(cmd))
            //{
            //    while (rdr.Read())
            //    {
            //        constraints.Add(rdr["CONSTRAINT_NAME"].ToString());
            //    }
            //    if (!rdr.IsClosed)
            //    {
            //        rdr.Close();
            //    }
            //}



            insertStatement.Append("INSERT INTO [" + tableName + "] ");

            //pull the schema for this table
            TableSchema.Table table = Query.BuildTableSchema(tableName, providerName);

            //build the insert list.
            string lastColumnName = table.Columns[table.Columns.Count - 1].ColumnName;
            foreach (TableSchema.TableColumn col in table.Columns)
            {
                fieldList.Append("[");
                fieldList.Append(col.ColumnName);
                fieldList.Append("]");

                if (!Utility.IsMatch(col.ColumnName, lastColumnName))
                    fieldList.Append(", ");
            }

            //complete the insert statement
            insertStatement.Append("(");
            insertStatement.Append(fieldList);
            insertStatement.AppendLine(")");

            //get the table data
            IDataReader rdr = new Query(table).ExecuteReader();
            //bool isNumeric = false;
            //TableSchema.TableColumn thisColumn=null;


            while (rdr.Read())
            {
                StringBuilder thisStatement = new StringBuilder();
                thisStatement.Append(insertStatement);
                thisStatement.Append("VALUES(");
                //loop the schema and pull out the values from the reader
                foreach (TableSchema.TableColumn col in table.Columns)
                {
                    object oData = rdr[col.ColumnName];
                    if (oData != null && oData != DBNull.Value)
                    {
                        if (col.DataType == DbType.Boolean)
                        {
                            bool bData = Convert.ToBoolean(oData);
                            thisStatement.Append(bData ? "1" : " 0");
                        }
                        else if (col.DataType == DbType.Byte || col.DataType == DbType.Binary)
                        {
                            thisStatement.Append("0x");
                            thisStatement.Append(Utility.ByteArrayToString((Byte[])oData).ToUpper());
                        }
                        else if (col.IsNumeric)
                        {
                            thisStatement.Append(oData);
                        }
                        else
                        {
                            thisStatement.Append("'");
                            thisStatement.Append(oData.ToString().Replace("'", "''"));
                            thisStatement.Append("'");
                        }
                    }
                    else
                    {
                        thisStatement.Append("NULL");
                    }

                    if (!Utility.IsMatch(col.ColumnName, lastColumnName))
                        thisStatement.Append(", ");
                }

                //add in a closing paren
                thisStatement.AppendLine(")");
                statements.Append(thisStatement);
            }
            rdr.Close();


            //if identity is set for the PK, set IDENTITY INSERT to true
            result.AppendLine(disableConstraint.ToString());
            if (table.PrimaryKey != null)
            {
                if (table.PrimaryKey.AutoIncrement)
                {
                    result.AppendLine("SET IDENTITY_INSERT [" + tableName + "] ON ");
                }
            }
            result.AppendLine("PRINT 'Begin inserting data in " + tableName + "'");
            result.Append(statements);

            if (table.PrimaryKey != null)
            {
                if (table.PrimaryKey.AutoIncrement)
                {
                    result.AppendLine("SET IDENTITY_INSERT [" + tableName + "] OFF ");
                }
            }
            result.AppendLine(enableConstraint.ToString());
            return result.ToString();
        }


        public override string ScriptSchema()
        {
            /*
            SqlCeConnection conn = new SqlCeConnection(this.connectionString);
            SqlCeConnectionStringBuilder cString = new SqlCeConnectionStringBuilder(this.connectionString);
            ServerConnection sconn = new ServerConnection(conn);
            Server server = new Server(sconn);
            Database db = server.Databases[cString.InitialCatalog];
            Transfer trans = new Transfer(db);

            //set the objects to copy
            trans.CopyAllTables = true;
            trans.CopyAllDefaults = true;
            trans.CopyAllUserDefinedFunctions = true;
            trans.CopyAllStoredProcedures = true;
            trans.CopyAllViews = true;
            trans.CopyData = true;
            trans.CopySchema = true;
            trans.CopyAllDefaults = true;
            trans.DropDestinationObjectsFirst = true;
            trans.UseDestinationTransaction = true;

            trans.Options.AnsiFile = true;
            trans.Options.ClusteredIndexes = true;
            trans.Options.DriAll = true;
            trans.Options.IncludeHeaders = true;
            trans.Options.IncludeIfNotExists = true;
            trans.Options.SchemaQualify = true;
            

            StringCollection script = trans.ScriptTransfer();
            
           
            foreach (string s in script) {
                result += s + Environment.NewLine;
            }
             * */
            string result = "";
            return result + Environment.NewLine + Environment.NewLine;
        }

        #endregion

        public override DbCommand GetDbCommand(QueryCommand qry)
        {
            DbCommand cmd;
            //SqlCeConnection conn = new SqlCeConnection(connectionString);
            AutomaticConnectionScope conn = new AutomaticConnectionScope(this);

            cmd = conn.Connection.CreateCommand();
            cmd.CommandText = qry.CommandSql;
            cmd.CommandType = qry.CommandType;

            foreach (QueryParameter par in qry.Parameters)
            {
                cmd.Parameters.Add(par);
            }

            return cmd;
        }



        public override string GetTableNameByPrimaryKey(string pkName, string providerName)
        {

            QueryCommand cmd = new QueryCommand("/* GetTableNameByPrimaryKey(" + pkName + ") */ " + TABLE_BY_PK, providerName);
            cmd.Parameters.Add("@columnName", pkName);
            cmd.Parameters.Add("@mapSuffix", ManyToManySuffix);
            object oResult = DataService.ExecuteScalar(cmd);
            string result = string.Empty;
            if (oResult != null)
                result = oResult.ToString();

            return result;

        }

        internal override string GetDatabaseVersion(string providerName)
        {
            return "3.5";
        }
        public override void SetParameter(IDataReader rdr, StoredProcedure.Parameter par)
        {
            par.DBType = GetDbType(rdr[SqlSchemaVariable.DATA_TYPE].ToString());
            string sMode = rdr[SqlSchemaVariable.MODE].ToString();
            if (sMode == SqlSchemaVariable.MODE_INOUT)
                par.Mode = ParameterDirection.InputOutput;
            par.Name = rdr[SqlSchemaVariable.NAME].ToString();
        }
        public override string GetParameterPrefix()
        {
            return SqlSchemaVariable.PARAMETER_PREFIX;
        }
    }
}
