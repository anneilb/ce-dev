using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace DeveloperAppADO2
{

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmDeveloper());
        }
    }

    public class Department
    {
        private DataLayer m_DL;
        private int m_intID;
        //private int intDeveloperID;
        private string m_strName;
        private bool m_blnIsNew;


        public Department(ref DataLayer objDL)
        {
            m_DL = objDL;
            m_blnIsNew = true; 
        }

        public int ID
        {
            get
            { return m_intID; }
            set
            { m_intID = value; }
        }

        public string Name
        {
            get
            { return m_strName; }
            set
            { m_strName = value; }
        }

        public bool IsNew
        {
            get
            { return m_blnIsNew; }
        }

        //Return an string representation of this Object's properties 
        public override string ToString()
        {
            string strTemp;

            strTemp = String.Format("\nID: {0}\nName: {1}", m_intID, m_strName);

            return strTemp;
        }

        //Return an array of this Object's properties 
        public object[] ToArray()
        {
            object[] aProps = new object[2] 
                              {
                                  m_intID, 
                                  m_strName, 
                              };

            return aProps;
        }

        //Return an sorted list of this Object's properties 
        public SortedList ToSortedList()
        {
            SortedList slProps = ToSortedList(false);
            return slProps;
        }

        //Overloaded method to exclude the ID for use in building Update statement
        public SortedList ToSortedList(bool blnExcludeID)
        {
            SortedList slProps = new SortedList();

            //Exclude the ID?
            if (!blnExcludeID)
            {
                slProps.Add(DataLayer.FldID, m_intID);
            }

            slProps.Add(DataLayer.FldDepartmentName, m_strName);

            return slProps;
        }

        //Populates this department object from DB
        public void Populate(int intID)
        {
            SqlDataReader dr;

            //Get department record
            dr = m_DL.GetDepartment(intID);

            if (!dr.IsClosed)
            {
                if (dr.HasRows)
                {
                    //Only one record should have been returned
                    dr.Read();
                    m_intID = (int)dr[DataLayer.FldID];
                    m_strName = (string)dr[DataLayer.FldDepartmentName];
                    m_blnIsNew = false;
                }

                dr.Close();
            }
            //Close open connection made for retrieving data reader
            m_DL.CloseDBConnection();
        }

        //Updates this department's DB record
        public bool Update()
        {
            bool blnResult = false;

            //Try to Insert/Update department record based on IsNew flag
            if (m_blnIsNew)
            {
                blnResult = m_DL.InsertDepartment(ToSortedList());
            }
            else
            {
                blnResult = m_DL.UpdateDepartment(m_intID, ToSortedList(true));
            }

            return blnResult;
        }

        //Deletes this department's DB record
        public bool Delete()
        {
            bool blnResult = false;

            //Try to Delete department record based on IsNew flag
            if (!m_blnIsNew)
            {
                blnResult = m_DL.DeleteDepartment(m_intID);
            }

            return blnResult;
        }

    }   


    public class Developer
    {
        private DataLayer m_DL;
        private SortedList m_slDepartments; 
        private int m_intID;
        private string m_strName;
        private double m_dblSalary;
        private bool m_blnIsNew;
        

        public Developer(ref DataLayer objDL)
        {
            m_DL = objDL;
            m_slDepartments = new SortedList();
            m_blnIsNew = true;
        }

        public int ID
        {
            get
            { return m_intID; }
            set
            { m_intID = value; }
        }

        public string Name
        {
            get
            { return m_strName; }
            set
            { m_strName = value; }
        }

        public SortedList Departments
        {
            get
            { return m_slDepartments; }
        }

        public double Salary
        {
            get
            { return m_dblSalary; }
            set
            { m_dblSalary = value; }
        }

        public bool IsNew
        {
            get
            { return m_blnIsNew; }
        }

        //Adds a department object to this Developer's collection of departments
        public bool AddDepartment(int intDepartmentID)
        {
            Department objDept;
            bool blnResult = false;

            if(!m_slDepartments.ContainsKey(intDepartmentID))
            {
                objDept = new Department(ref m_DL);
                objDept.Populate(intDepartmentID);

                if (!objDept.IsNew)
                {
                    m_slDepartments.Add(objDept.ID, objDept);
                    blnResult = true;
                }
            }

            return blnResult;
        }

        //Removes a department object from this Developer's collection of departments
        public bool RemoveDepartment(int intDepartmentID)
        {
            bool blnResult = false;

            if (m_slDepartments.ContainsKey(intDepartmentID))
            {
                m_slDepartments.Remove(intDepartmentID);
                blnResult = true;
            }

            return blnResult;
        }

        //Return an string representation of this Object's properties 
        public override string ToString()
        {
            string strTemp;
            IDictionaryEnumerator objDEItem;
            Department objDept;

            strTemp = "\nDeveloper Details\n";
            strTemp = String.Format("\nID: {0}\nName: {1}\nSalary: {2}", m_intID, m_strName, m_dblSalary);
            strTemp = strTemp + "\n\nDepartment Details";

            objDEItem = m_slDepartments.GetEnumerator();
            
            while(objDEItem.MoveNext())
            {
                objDept = (Department)objDEItem.Value;
                strTemp = strTemp + "\n" + objDept.ToString();
            }

            return strTemp;
        }

        //Return an array of this Object's properties 
        public object[] ToArray()
        {
            object[] aProps = new object[3] 
                              {
                                  m_intID, 
                                  m_strName, 
                                  m_dblSalary,
                              };

            return aProps;
        }

        //Return an sorted list of this Object's properties 
        public SortedList ToSortedList()
        {
            SortedList slProps = ToSortedList(false);
            return slProps;
        }

        //Overloaded method to exclude the ID for use in building Update statement
        public SortedList ToSortedList(bool blnExcludeID)
        {
            SortedList slProps = new SortedList();

            //Exclude the ID?
            if (!blnExcludeID)
            {
                slProps.Add(DataLayer.FldID, m_intID);
            }

            slProps.Add(DataLayer.FldDeveloperName, m_strName);
            slProps.Add(DataLayer.FldDeveloperSalary, m_dblSalary);

            return slProps;
        }

        //Populate method used to populate developer object from DB
        public void Populate(int intID)
        {
            SqlDataReader dr;
            DataSet ds;
            DataRow[] aDr;

            //Get developer record
            dr = m_DL.GetDeveloper(intID);

            if (!dr.IsClosed)
            {
                if (dr.HasRows)
                {
                    //Only one record should have been returned                
                    dr.Read();
                    m_intID = (int)dr[DataLayer.FldID];
                    m_strName = (string)dr[DataLayer.FldDeveloperName];
                    m_dblSalary = (double)dr[DataLayer.FldDeveloperSalary];
                    m_blnIsNew = false;
                }

                dr.Close(); 
            }
            //Close open connection made for retrieving data reader
            m_DL.CloseDBConnection();

            //At this point if no developer record was retrieved, there's no need to continue
            if (!m_blnIsNew)
            {
                //Get department records
                ds = new DataSet();
                ds = m_DL.GetDeveloperDepartments(m_intID);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[DataLayer.TblDeveloperDepartments].Rows.Count > 0)
                    {
                        aDr = ds.Tables[DataLayer.TblDeveloperDepartments].Select();

                        //Add each department record to Departments collection
                        foreach (DataRow d in aDr)
                        {
                            AddDepartment((int)d[DataLayer.FldDevDeptsDepartmentID]);
                        }
                    }
                }
            }
        }

        //Updates or Inserts a developer record and it's department records
        public bool Update()
        {
            IDictionaryEnumerator objDEItem;
            Department objDept;
            bool blnResult = false;            

            //Try to Insert/Update developer record based on IsNew flag
            if (m_blnIsNew)
            {
                blnResult = m_DL.InsertDeveloper(ToSortedList());
            }
            else
            {
                blnResult = m_DL.UpdateDeveloper(m_intID, ToSortedList(true));
                
                if(blnResult)
                {
                    //Try to delete existing Developer Department records (re-insert current records, if any)
                    m_DL.DeleteDeveloperDepartments(m_intID);
                }
            }

            if (blnResult)
            {
                //Try to insert dveloper's department records
                if (m_slDepartments.Count > 0)
                {
                    objDEItem = m_slDepartments.GetEnumerator();

                    while (objDEItem.MoveNext())
                    {
                        //Create array of developer deparment values to be inserted
                        objDept = (Department)objDEItem.Value;

                        SortedList slValues = new SortedList();
                        
                        //slValues.Add(DataLayer.FldID, null); 
                        slValues.Add(DataLayer.FldDevDeptsDeveloperID, m_intID);
                        slValues.Add(DataLayer.FldDevDeptsDepartmentID, objDept.ID);

                        blnResult = m_DL.InsertDeveloperDepartment(slValues);
                    }
                }                
            }
            
            return blnResult;
        }

        //Deletes a developer record and it's department records
        public bool Delete()
        {
            bool blnResult = false;

            //Try to Insert/Update developer record based on IsNew flag
            if (!m_blnIsNew)
            {
                blnResult = m_DL.DeleteDeveloper(m_intID);

                if (blnResult)
                {
                    //Need to do this? Delete Developer Trigger should kick in here
                    //Try to delete existing Developer Department records
                    m_DL.DeleteDeveloperDepartments(m_intID);
                }
            }

            return blnResult;
        }

    }

    public class DataLayer
    {
        //DB path and connection string for creating DB connection
        private const string DbPath = "D:\\Visual Studio 2008\\SQL Data Source\\DeveloperDB.mdf";
        private const string DbConnection = "Data Source=.\\SQLEXPRESS;AttachDbFilename=" + DbPath + 
                                            ";Integrated Security=True;Connect Timeout=30;User Instance=True";

        //Table name constants
        public const string TblDeveloper = "Developer";
        public const string TblDepartment = "Department";
        public const string TblDeveloperDepartments = "DeveloperDepartments";
        public const string TblVwDeveloperDepartmentDetails = "vw_DeveloperDepartmentDetails";

        //Field name constants
        public const string FldID = "ID"; //Generic ID field name
        //Developer table       
        public const string FldDeveloperName = "Name";
        public const string FldDeveloperSalary = "Salary";
        //Department table
        public const string FldDepartmentName = "Name";
        //DeveloperDepartments table
        public const string FldDevDeptsDeveloperID = "DeveloperID";
        public const string FldDevDeptsDepartmentID = "DepartmentID";        

        private DBManager m_DB;
        
        public DataLayer()
        {
            m_DB = new DBManager(DbConnection);
        }

        ~DataLayer()
        {
            m_DB = null;
        }

        public void CloseDBConnection()
        {
            m_DB.CloseConnection();
        }
        
        //Inserts a developer record
        public bool InsertDeveloper(SortedList slValues)
        {            
            bool blnResult = false;

            blnResult = (m_DB.InsertDirect(TblDeveloper, slValues) > 0);
            return blnResult;
        }

        //Inserts a department record
        public bool InsertDepartment(SortedList slValues)
        {
            bool blnResult = false;

            blnResult = (m_DB.InsertDirect(TblDepartment, slValues) > 0);
            return blnResult;
        }

        //Inserts a developer department record
        public bool InsertDeveloperDepartment(SortedList slValues)
        {
            bool blnResult = false;

            blnResult = (m_DB.InsertDirect(TblDeveloperDepartments, slValues) > 0);
            return blnResult;
        }

        //Updates a developer record
        public bool UpdateDeveloper(int intID, SortedList slValues)
        {
            bool blnResult = false;

            blnResult = (m_DB.UpdateDirect(TblDeveloper, FldID + "=" + intID, slValues) > 0);
            return blnResult;
        }

        //Updates a department record
        public bool UpdateDepartment(int intID, SortedList slValues)
        {
            bool blnResult = false;

            blnResult = (m_DB.UpdateDirect(TblDepartment, FldID + "=" + intID, slValues) > 0);
            return blnResult;
        }
                
        //Deletes a developer record
        public bool DeleteDeveloper(int intID)
        {
            bool blnResult = false;

            blnResult = (m_DB.DeleteDirect(TblDeveloper, FldID + "=" + intID) > 0);
            return blnResult;
        }

        //Deletes a department record
        public bool DeleteDepartment(int intID)
        {
            bool blnResult = false;

            blnResult = (m_DB.DeleteDirect(TblDepartment, FldID + "=" + intID) > 0);
            return blnResult;
        }

        //Deletes all developer department records
        public bool DeleteDeveloperDepartments(int intDeveloperID)
        {
            bool blnResult = false;

            blnResult = (m_DB.DeleteDirect(TblDeveloperDepartments, FldDevDeptsDeveloperID + "=" + intDeveloperID) > 0);
            return blnResult;
        }

        //Gets a developer record
        public SqlDataReader GetDeveloper(int intID)
        {
            SqlDataReader dr;
            string strSQL;

            strSQL = "SELECT * FROM " + TblDeveloper + " WHERE " + FldID + "=" + intID;
            dr = m_DB.SelectDirect(strSQL, TblDeveloper);

            return dr;
        }

        //Gets a developer record
        public DataSet GetDevelopers()
        {
            DataSet ds;
            string strSQL;

            strSQL = "SELECT * FROM " + TblDeveloper + " ORDER BY " + FldID;
            ds = m_DB.Select(strSQL, TblDeveloper);

            return ds;
        }

        //Gets a department record
        public SqlDataReader GetDepartment(int intID)
        {
            SqlDataReader dr;
            string strSQL;

            strSQL = "SELECT * FROM " + TblDepartment + " WHERE " + FldID + "=" + intID;
            dr = m_DB.SelectDirect(strSQL, TblDepartment);

            return dr;
        }

        //Gets an array of all IDs from a specified table
        public object[] GetIDList(string strTableName)
        {
            object[] aIDs = null;
            DataSet ds;
            DataRow[] aDr;
            string strSQL;

            strSQL = "SELECT " + FldID + " FROM " + strTableName + " ORDER BY " + FldID;
            ds = m_DB.Select(strSQL, strTableName);

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[strTableName].Rows.Count > 0)
                {
                    aDr = ds.Tables[strTableName].Select();
                    aIDs = new object[ds.Tables[strTableName].Rows.Count];

                    for (int x = 0; x < aIDs.Length; x++)
                    {
                        aIDs[x] = aDr[x][FldID];
                    }
                }
            }

            return aIDs;
        }

        //Gets a dataset containing all department records
        public DataSet GetDepartments()
        {
            DataSet ds;
            string strSQL;

            strSQL = "SELECT * FROM " + TblDepartment + " ORDER BY " + FldID;
            ds = m_DB.Select(strSQL, TblDepartment);

            return ds;
        }  
              
        //Gets all developer department records
        public DataSet GetDeveloperDepartments(int intID)
        {
            DataSet ds;
            string strSQL;

            strSQL = "SELECT * FROM " + TblDeveloperDepartments +
                     " WHERE " + FldDevDeptsDeveloperID + "=" + intID;

            ds = m_DB.Select(strSQL, TblDeveloperDepartments);

            return ds;
        }

        //Gets all developer department records
        public DataSet GetDevelopersDepartments()
        {
            DataSet ds;
            string strSQL;

            strSQL = "SELECT * FROM " + TblDeveloperDepartments + " ORDER BY " + FldDevDeptsDeveloperID;

            ds = m_DB.Select(strSQL, TblDeveloperDepartments);

            return ds;
        }

        //Gets all developer department records
        public DataSet GetDeveloperDepartmentDetails()
        {
            DataSet ds;
            string strSQL;

            strSQL = "SELECT * FROM " + TblVwDeveloperDepartmentDetails + " ORDER BY " + FldDevDeptsDeveloperID;
            ds = m_DB.Select(strSQL, TblVwDeveloperDepartmentDetails);

            return ds;
        }        

    }

    public class DBManager
    {
        private SqlConnection m_conDB;
        private string m_strConnectionString;


        public DBManager(string strConnection)
        {
            m_strConnectionString = strConnection;
        }

        ~DBManager()
        {
            CloseConnection();
        }

        //Creates Connection object and opens it
        private bool CreateConnection()
        {
            bool blnResult = false;

            if (m_conDB == null)
            {
                m_conDB = new SqlConnection(m_strConnectionString);
            }            
            
            if (m_conDB.State == System.Data.ConnectionState.Closed)
            {
                m_conDB.Open();
                blnResult = true;
            }

            return blnResult;
        }

        //Checks if Connection object is open and closes it
        public void CloseConnection()
        {
            if (m_conDB.State == System.Data.ConnectionState.Open)
            {
                m_conDB.Close();
            }
        }        

        //Generic SQL Insert method
        public int Insert(string strTable, params object[] aValues)
        {
            SqlDataAdapter da;
            SqlCommandBuilder cb;
            DataSet ds;
            DataRow dr;
            string strSQL = "";
            int intResult = 0;

            if (CreateConnection())
            {
                strSQL = "SELECT * FROM " + strTable;
                da = new SqlDataAdapter();
                
                //Get the dataset using the Select query that has been composed
                ds = GetDataSet(strTable, strSQL, ref da);

                //use the command builder to generate the Insert and Update commands that we'll need later
                cb = new SqlCommandBuilder(da);                
                da.InsertCommand = cb.GetInsertCommand();
                da.UpdateCommand = cb.GetUpdateCommand();

                //Insert the new record
                dr = ds.Tables[strTable].NewRow();
                dr.ItemArray = aValues;
                ds.Tables[strTable].Rows.Add(dr);

                //Update table and determine number of rows affected (should only be one)
                intResult = da.Update(ds, strTable);

                CloseConnection();
            }

            return intResult;
        }

        //Generic SQL Update method
        public int Update(string strTable, string strWhere, SortedList slValues)
        {
            SqlDataAdapter da;
            SqlCommandBuilder cb;
            DataSet ds;
            DataRow[] aDr = null;
            IDictionaryEnumerator objDEItem;
            string strSQL = "";
            string strKey = "";
            int intResult = 0;

            if (CreateConnection())
            {
                strSQL = "SELECT * FROM " + strTable;
                da = new SqlDataAdapter();

                //Get the dataset using the Select query that has been composed
                ds = GetDataSet(strTable, strSQL, ref da);

                //use the command builder to generate the Update command that we'll need later
                cb = new SqlCommandBuilder(da);
                da.UpdateCommand = cb.GetUpdateCommand();

                //Get the records to Update using where clause
                if (strWhere.Length > 0)
                {
                    aDr = ds.Tables[strTable].Select(strWhere);
                }
                else
                {
                    aDr = ds.Tables[strTable].Select();
                }
                
                if (aDr != null)
                {   
                    //Loop through each row
                    foreach (DataRow dr in aDr)
                    {
                        objDEItem = slValues.GetEnumerator();
                        
                        //Loop through field values collection and update row
                        while(objDEItem.MoveNext())
                        {
                            //Determine key and use it to update corresponding column in datarow                            
                            //strKey = slValues.GetKey(slValues.IndexOfValue(o)).ToString();
                            strKey = objDEItem.Key.ToString();
                            dr[strKey] = objDEItem.Value;
                        }
                    }
                }

                //Update table and determine number of rows affected
                intResult = da.Update(ds, strTable);

                CloseConnection();
            }

            return intResult;
        }

        //Generic SQL Delete method
        public int Delete(string strTable, string strWhere)
        {
            SqlDataAdapter da;
            SqlCommandBuilder cb;
            DataSet ds;
            DataRow[] aDr = null;
            string strSQL = "";
            int intResult = 0;

            if (CreateConnection())
            {
                strSQL = "SELECT * FROM " + strTable;
                da = new SqlDataAdapter();

                //Get the dataset using the Select query that has been composed
                ds = GetDataSet(strTable, strSQL, ref da);

                //use the command builder to generate the Delete and Update commands that we'll need later
                cb = new SqlCommandBuilder(da);
                da.DeleteCommand = cb.GetDeleteCommand();
                da.UpdateCommand = cb.GetUpdateCommand();

                //Get the row to Delete using where clause, if none supplied get all rows
                if (strWhere.Length > 0)
                {
                    aDr = ds.Tables[strTable].Select(strWhere);
                }
                else
                {
                    aDr = ds.Tables[strTable].Select();
                }

                if (aDr != null)
                {
                    //Loop through each row and Delete it
                    foreach (DataRow dr in aDr)
                    {
                        dr.Delete();
                    }                        
                }

                //Update table and determine number of rows affected
                intResult = da.Update(ds, strTable);

                CloseConnection();
            }

            return intResult;
        }

        //Generic SQL Select method
        public DataSet Select(string strSelectQuery, string strTable)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            if (CreateConnection())
            {
                //Get the dataset using the Select query that has been composed
                ds = GetDataSet(strTable, strSelectQuery, ref da);

                CloseConnection();
            }

            return ds;
        }

        //Generic SQL Insert method for direct insertion using an INSERT statement
        public int InsertDirect(string strTable, SortedList slValues)
        {
            IDictionaryEnumerator objDEItem;
            SqlCommand cmd;
            int intResult = 0;
            string strSQL = "";
            string strKey = "";
            string strFields = "";
            string strValues = "";

            if (CreateConnection())
            {
                cmd = m_conDB.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;

                if (slValues.Count > 0)
                {
                    objDEItem = slValues.GetEnumerator();

                    //Loop through field values collection and insert row
                    while (objDEItem.MoveNext())
                    {
                        //Determine key and use it to insert data into corresponding column                            
                        strKey = objDEItem.Key.ToString();

                        if (strFields.Length > 0)
                        {
                            strFields = strFields + ", ";
                        }
                        //build up the field names to insert
                        strFields = strFields + strKey;

                        if (strValues.Length > 0)
                        {
                            strValues = strValues + ", ";
                        }
                        //build up the values to insert
                        strValues = strValues + FormatSQLValue(objDEItem.Value);
                    }

                    strFields = "(" + strFields + ")";
                    strValues = "(" + strValues + ")";
                }

                //Compose the full SQL command
                strSQL = "INSERT INTO " + strTable + " " + strFields + " VALUES " + strValues;
                cmd.CommandText = strSQL;

                intResult = cmd.ExecuteNonQuery();

                CloseConnection();
            }

            return intResult;
        }

        //Generic SQL Update method for direct update using an UPDATE statement
        public int UpdateDirect(string strTable, string strWhere, SortedList slValues)
        {
            IDictionaryEnumerator objDEItem;
            SqlCommand cmd;
            int intResult = 0;
            string strSQL = "";
            string strKey = "";
            string strValues = "";
            string strFilter = "";

            if (CreateConnection())
            {
                cmd = m_conDB.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;

                if (slValues.Count > 0)
                {
                    objDEItem = slValues.GetEnumerator();

                    //Loop through field values collection and update row
                    while (objDEItem.MoveNext())
                    {
                        //Determine key and use it to update corresponding column                            
                        strKey = objDEItem.Key.ToString();

                        if (strValues.Length > 0)
                        {
                            strValues = strValues + ", ";
                        }

                        strValues = strValues + strKey + "=" + FormatSQLValue(objDEItem.Value);
                    }

                    //strValues = "(" + strValues + ")";
                }

                //Build Where clause
                if (strWhere.Length > 0)
                {
                    strFilter = " WHERE " + strWhere; 
                }

                //Compose the full SQL command 
                strSQL = "UPDATE " + strTable + " SET " + strValues + strFilter;
                cmd.CommandText = strSQL;

                intResult = cmd.ExecuteNonQuery();

                CloseConnection();
            }

            return intResult;
        }

        //Generic SQL Delete method for direct delete using a DELETE statement
        public int DeleteDirect(string strTable, string strWhere)
        {
            SqlCommand cmd;
            int intResult = 0;
            string strSQL = "";
            string strFilter = "";

            if (CreateConnection())
            {
                cmd = m_conDB.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;

                //Build Where clause
                if (strWhere.Length > 0)
                {
                    strFilter = " WHERE " + strWhere;
                }

                //Compose the full SQL command 
                strSQL = "DELETE FROM " + strTable + strFilter;
                cmd.CommandText = strSQL;

                intResult = cmd.ExecuteNonQuery();

                CloseConnection();
            }

            return intResult;
        }

        //Generic SQL Select method for direct read of a data table in the DB
        public SqlDataReader SelectDirect(string strSelectQuery, string strTable)
        {
            SqlDataReader dr = null;

            if (CreateConnection())
            {
                //Get the data reader using the Select query that has been composed
                dr = GetDataReader(strTable, strSelectQuery);

                //CloseConnection();
            }

            return dr;
        }
        
        private DataSet GetDataSet(string strTable, string strSelectQuery, ref SqlDataAdapter da)
        {
            SqlCommand cmd;
            DataSet ds = new DataSet();
            
            //Set up command object and using Select statment and init data adapter
            cmd = m_conDB.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = strSelectQuery;                
            da.SelectCommand = cmd;

            //Use the data adapter to populate the data set
            //Use single table name if supplied
            if (strTable.Length > 0)
            {
                da.Fill(ds, strTable);
            }
            else
            {
                da.Fill(ds);
            }

            return ds; 
        }

        private SqlDataReader GetDataReader(string strTable, string strSelectQuery)
        {
            SqlCommand cmd;
            SqlDataReader dr;

            //Set up command object and using Select statment and init data reader
            cmd = m_conDB.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = strSelectQuery;
            dr = cmd.ExecuteReader();
           
            return dr;
        }        

        //Formats an object array for insertion into a SQL Insert or Update statement
        private string FormatSQLArray(params object[] aValues)
        {
            string strItem = "";
            string strResult = "";

            foreach (object o in aValues)
            {
                strItem = FormatSQLValue(o);

                //Build the result string
                if (strResult == "")
                {
                    strResult = strItem;
                }
                else
                {
                    strResult = strResult + "," + strItem;
                }
            }

            return strResult;
        }

        //Formats an object for insertion into SQL statement according to it's type
        private string FormatSQLValue(object objValue)
        {
            string strItem = "";

            if (objValue == null)
            {
                strItem = "Null";
            }
            else if (objValue.GetType().ToString() == "System.Int32")
            {
                strItem = "" + (Int32)objValue;
            }
            else if (objValue.GetType().ToString() == "System.Double")
            {
                strItem = "" + (Double)objValue;
            }
            else if (objValue.GetType().ToString() == "System.String")
            {
                strItem = "'" + (String)objValue + "'";

            }
            else if (objValue.GetType().ToString() == "System.Boolean")
            {
                strItem = "" + (Boolean)objValue;
            }
            else
            {
                //unknown type - try to set anyway
                strItem = objValue.ToString();
            }

            return strItem;
        }

    }

}
