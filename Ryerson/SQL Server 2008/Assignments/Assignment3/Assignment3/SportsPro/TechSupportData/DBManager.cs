using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Purpose: Provides generic methods for all SQL Server DB operations. 
/// This allows for separation of ADO.NET logic from DB classes.
/// </summary>

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

    public string ConnectionString
    {
        get { return m_strConnectionString; }
        set { m_strConnectionString = value; }
    }

    //Creates Connection object and opens it
    private bool CreateConnection()
    {
        bool blnResult = false;

        try
        {
            if (m_conDB == null)
            {
                m_conDB = new SqlConnection(m_strConnectionString);
            }

            if (m_conDB.State == System.Data.ConnectionState.Closed)
            {
                m_conDB.Open();
                blnResult = true;
            }
            else if (m_conDB.State == System.Data.ConnectionState.Open)
            {
                blnResult = true;
            }
        }
        catch (SqlException ex)
        {
            blnResult = false;              
            CloseConnection();
            m_conDB = null;
            
            throw ex;
        }
        
        return blnResult;        
    }

    //Checks if Connection object is open and closes it
    public void CloseConnection()
    {
        if (m_conDB != null)
        {
            if (m_conDB.State != System.Data.ConnectionState.Closed)
            {
                m_conDB.Close();
            }
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

        try
        {
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
            }
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {
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

        try
        {
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
            }
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {
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

        try
        {
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
            }
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {
            CloseConnection();
        }

        return intResult;
    }

    //Generic SQL Select method
    public DataSet Select(string strSelectQuery, string strTable)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();

        try
        {
            if (CreateConnection())
            {
                //Get the dataset using the Select query that has been composed
                ds = GetDataSet(strTable, strSelectQuery, ref da);
            }
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {
            CloseConnection();
        }

        return ds;
    }

    //Generic SQL Insert method for direct insertion using an INSERT statement or stored proc
    public int InsertDirect(string strCommandText, 
                            CommandType enuCommandType, 
                            SortedList slParameters)
    {
        IDictionaryEnumerator objDEItem;
        SqlCommand cmd = new SqlCommand();
        int intResult = 0;
        string strSQL = "";
        string strKey = "";
        string strFields = "";
        string strValues = "";
        string strParam = "";

        try
        {
            if (CreateConnection())
            {
                if (slParameters.Count > 0)
                {
                    if (enuCommandType == CommandType.Text)
                    {
                        cmd = m_conDB.CreateCommand(); //build command ourselves
                        cmd.CommandType = enuCommandType;

                        objDEItem = slParameters.GetEnumerator();

                        //Loop through field values collection and insert row
                        while (objDEItem.MoveNext())
                        {
                            //Build up the field names to insert. Use key for column name
                            strKey = objDEItem.Key.ToString();
                            AddToCSV(strKey, ref strFields);

                            //Build up the values to insert. Add param indicator if needed
                            strParam = ToParam(strKey);
                            AddToCSV(strParam, ref strValues);

                            cmd.Parameters.AddWithValue(strParam, objDEItem.Value); //Add value to params
                        }

                        strFields = "(" + strFields + ")";
                        strValues = "(" + strValues + ")";

                        //Compose the full SQL command
                        strSQL = "INSERT INTO " + strCommandText + " " + strFields + " VALUES " + strValues;

                        cmd.CommandText = strSQL;
                    }
                    else if (enuCommandType == CommandType.StoredProcedure)
                    {
                        //Support for stored procedures      
                        cmd = GetCommand(strCommandText, enuCommandType, slParameters);
                    }

                    intResult = cmd.ExecuteNonQuery();
                }
            }
        }
        catch (SqlException ex)
        {
            intResult = 0;
            throw ex;
        }
        finally
        {
            CloseConnection();
        }

        return intResult;
    } 

    //overloaded method added to support optimistic concurrency
    public int UpdateDirect(string strTable, string strWhere, SortedList slValues, SortedList slOriginalValues)
    {
        IDictionaryEnumerator objDEItem;
        string strKey = "";
        string strOriginalValues = "";
        int intResult = 0;
        string strFilter = "";

        if (slOriginalValues.Count > 0)
        {
            objDEItem = slOriginalValues.GetEnumerator();

            //Loop through field values collection and update row
            while (objDEItem.MoveNext())
            {
                //Determine key and use it to update corresponding column                            
                strKey = objDEItem.Key.ToString();

                if (strOriginalValues.Length > 0)
                {
                    strOriginalValues = strOriginalValues + " AND ";
                }

                strOriginalValues = strOriginalValues + strKey + "=" + FormatSQLValue(objDEItem.Value);
            }

            //Build Where clause
            if (strWhere.Length > 0)
            {
                strFilter = strWhere + " AND ";
            }

            strFilter = strFilter + strOriginalValues;
        }

        intResult = UpdateDirect(strTable, strFilter, slValues);

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

        try
        {
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
                    strFilter = " WHERE (" + strWhere + ")";
                }

                //Compose the full SQL command 
                strSQL = "UPDATE " + strTable + " SET " + strValues + strFilter;
                cmd.CommandText = strSQL;

                intResult = cmd.ExecuteNonQuery();
            }
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {
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

        try
        {
            if (CreateConnection())
            {
                cmd = m_conDB.CreateCommand();
                cmd.CommandType = CommandType.Text;

                //Build Where clause
                if (strWhere.Length > 0)
                {
                    strFilter = " WHERE (" + strWhere + ")";
                }

                //Compose the full SQL command 
                strSQL = "DELETE FROM " + strTable + strFilter;
                cmd.CommandText = strSQL;

                intResult = cmd.ExecuteNonQuery();
            }
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {
            CloseConnection();
        }

        return intResult;
    }

    //Generic SQL Select method for direct read of a data table in the DB
    public SqlDataReader SelectDirect(string strCommandText,
                                      CommandType enuCommandType)
    {
        SqlDataReader dr;

        //Get the data reader using the Select query passed
        dr = GetDataReader(strCommandText, enuCommandType, null);
        return dr;
    }

    //Generic SQL Select method for direct read of a data table in the DB
    public SqlDataReader SelectDirect(string strCommandText, 
                                      CommandType enuCommandType, 
                                      SortedList slParameters)
    {
        SqlDataReader dr = null;

        //Get the data reader using the Select query & params that have been passed
        dr = GetDataReader(strCommandText, enuCommandType, slParameters);
        return dr;
    }

    public object GetScalar(string strCommandText,
                            CommandType enuCommandType)
    {
        object objValue;
        
        //Set up command object and get scalar value
        objValue = ExecuteScalarCommand(strCommandText, enuCommandType, null);
        return objValue;
    }

    public object GetScalar(string strCommandText, 
                            CommandType enuCommandType, 
                            SortedList slParameters)
    {
        object objValue;

        //Set up command object and get scalar value
        objValue = ExecuteScalarCommand(strCommandText, enuCommandType, slParameters);
        return objValue;
    }
    
    private object ExecuteScalarCommand(string strCommandText,
                                        CommandType enuCommandType,
                                        SortedList slParameters)
    {
        SqlCommand cmd;
        object objValue = null;

        try
        {
            if (CreateConnection())
            {
                //Set up command object and get scalar value
                cmd = GetCommand(strCommandText, enuCommandType, slParameters);
                objValue = cmd.ExecuteScalar();
            }
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {
            CloseConnection();
        }

        return objValue;
    }

    private SqlDataReader GetDataReader(string strCommandText, 
                                        CommandType enuCommandType,
                                        SortedList slParameters)
    {
        SqlCommand cmd;
        SqlDataReader dr = null;

        try
        {
            if (CreateConnection())
            {
                //Set up command object and using text and type
                cmd = GetCommand(strCommandText, enuCommandType, slParameters);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }
        catch (SqlException ex)
        {
            CloseConnection();
            throw ex;
        }

        return dr;
    }

    private SqlCommand GetCommand(string strCommandText, 
                                  CommandType enuCommandType,
                                  SortedList slParameters)
    {
        IDictionaryEnumerator objDEItem;
        SqlCommand cmd;
        string strKey;
        string strParam; 
        object objValue;

        //Set up command object and using text and type
        cmd = m_conDB.CreateCommand();
        cmd.CommandType = enuCommandType;
        cmd.CommandText = strCommandText;

        if (slParameters != null)
        {
            if (slParameters.Count > 0)
            {
                objDEItem = slParameters.GetEnumerator();

                //Loop through field values collection and update row
                while (objDEItem.MoveNext())
                {
                    //Determine key and use it to update corresponding column                            
                    strKey = objDEItem.Key.ToString();
                    strParam = ToParam(strKey); //Add param indicator if needed
                   
                    objValue = objDEItem.Value;
                    cmd.Parameters.AddWithValue(strParam, objValue);
                }
            }
        }

        return cmd;
    }

    private DataSet GetDataSet(string strTable, string strSelectQuery, ref SqlDataAdapter da)
    {
        SqlCommand cmd;
        DataSet ds = new DataSet();

        //Set up command object and using Select statment and init data adapter
        cmd = m_conDB.CreateCommand();
        cmd.CommandType = CommandType.Text;
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

    private void AddToCSV(string strValue, ref string strCommaSeparatedValues)
    {
        if (strCommaSeparatedValues.Length > 0)
            strCommaSeparatedValues = strCommaSeparatedValues + ", " + strValue;
        else
            strCommaSeparatedValues = strValue;
    }

    private string ToParam(string strFieldName)
    {
        string strResult;

        if (!strFieldName.StartsWith("@"))    //Add param indicator if needed
            strResult = "@" + strFieldName;
        else
            strResult = strFieldName;

        return strResult;
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
        else if (objValue.GetType().ToString() == "System.DateTime")
        {
            strItem = "'" + (DateTime)objValue + "'";
        }
        else
        {            
            //unknown type - try to set anyway
            strItem = objValue.ToString();
        }

        return strItem;
    }

}
