using System;
using System.Collections.Generic;
using System.Collections;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data; 

namespace UserDBApp
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
            Application.Run(new Form1());
        }
    }

    public class User
    {
        private DataLayer m_DL;
        private string m_strFName;
        private string m_strLName;
        private string m_strAddress;
        private string m_strUemail;
        private bool m_blnIsNew;


        public User(ref DataLayer objDL)
        {
            m_DL = objDL;
            m_blnIsNew = true;
        }

        public string FName
        {
            get
            { return m_strFName; }
            set
            { m_strFName = value; }
        }

        public string LName
        {
            get
            { return m_strLName; }
            set
            { m_strLName = value; }
        }

        public string Address
        {
            get
            { return m_strAddress; }
            set
            { m_strAddress = value; }
        }

        public string Uemail
        {
            get
            { return m_strUemail; }
            set
            { m_strUemail = value; }
        } 
        
        public bool IsNew
        {
            get
            { return m_blnIsNew; }
        }       
        
        //Return an array of this Object's properties 
        public object[] ToArray()
        {
            object[] aProps = new object[4] 
                              {
                                  m_strFName, 
                                  m_strLName, 
                                  m_strAddress,
                                  m_strUemail
                              };

            return aProps;
        }

        //method for use in building Update statement
        public SortedList ToSortedList()
        {
            SortedList slProps = new SortedList();

            slProps.Add(DataLayer.FldUserFName, m_strFName);
            slProps.Add(DataLayer.FldUserLName, m_strLName);
            slProps.Add(DataLayer.FldUserAddress, m_strAddress);
            slProps.Add(DataLayer.FldUserUemail, m_strUemail);

            return slProps;
        }

        //Populate method used to populate developer object from DB
        public void Populate(string strUemail)
        {
            SqlDataReader dr;

            //Get developer record
            dr = m_DL.GetUser(strUemail);

            if (!dr.IsClosed)
            {
                if (dr.HasRows)
                {
                    //Only one record should have been returned                
                    dr.Read();
                    m_strFName = (string)dr[DataLayer.FldUserFName];
                    m_strLName = (string)dr[DataLayer.FldUserLName];
                    m_strAddress = (string)dr[DataLayer.FldUserAddress];
                    m_strUemail = (string)dr[DataLayer.FldUserUemail];
                    m_blnIsNew = false;
                }

                dr.Close();
            }
            
            //Close open connection made for retrieving data reader
            m_DL.CloseDBConnection();
        }

        //Updates or Inserts a developer record and it's department records
        public bool Update()
        {
            bool blnResult = false;

            //Try to Insert/Update developer record based on IsNew flag
            if (m_blnIsNew)
            {
                blnResult = m_DL.InsertUser(ToSortedList());
            }
            else
            {
                blnResult = m_DL.UpdateUser(m_strUemail, ToSortedList());
            }

            return blnResult;
        }
    }

    public class DataLayer
    {
        //DB path and connection string for creating DB connection
        private const string DbPath = "UserDB";
        private const string DbConnection = "Data Source=J130-N-020;Initial Catalog=" + DbPath + ";Integrated Security=True";

        //Table name constants
        public const string TblUser = "User";

        //Field name constants
        //Developer table       
        public const string FldUserFName = "Fname";
        public const string FldUserLName = "Lname";
        public const string FldUserAddress = "Address";
        public const string FldUserUemail = "Uemail";

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
        public bool InsertUser(SortedList slValues)
        {
            bool blnResult = false;

            blnResult = (m_DB.InsertDirect(TblUser, slValues) > 0);
            return blnResult;
        }
        
        //Updates a developer record
        public bool UpdateUser(string strUemail, SortedList slValues)
        {
            bool blnResult = false;

            blnResult = (m_DB.UpdateDirect(TblUser, FldUserUemail + "='" + strUemail + "'", slValues) > 0);
            return blnResult;
        } 

        //Gets a developer record
        public SqlDataReader GetUser(string strUemail)
        {
            SqlDataReader dr;
            string strSQL;

            strSQL = "SELECT * FROM " + TblUser + " WHERE " + FldUserUemail + "='" + strUemail + "'";
            dr = m_DB.SelectDirect(strSQL, TblUser);

            return dr;
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
                        while (objDEItem.MoveNext())
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
            SqlDataReader dr;
            SqlCommand cmd;

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