using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for CustomerDB
/// </summary>
[DataObject(true)]
public static class CustomerDB
{
	
    //DB path and connection string for creating DB connection
    //private const string DbPath = "TechSupport";
    //private const string DbConnection = "Data Source=localhost;Initial Catalog=" + DbPath + ";Integrated Security=True";

    //Table name constants
    private const string TblCustomers = "Customers";
    private const string TblIncidents = "Incidents";

    //Field name constants
    private const string FldCustomerID = "CustomerID";
    private const string FldName = "Name";
    private const string FldAddress = "Address";
    private const string FldCity = "City";
    private const string FldState = "State";
    private const string FldZipCode = "ZipCode";
    private const string FldPhone = "Phone";
    private const string FldEmail = "Email";
    private const string FldTechID = "TechID";
    

    private static DBManager m_DB;

    private static void InitializeDB()
    {
        if (m_DB == null)
        {
            m_DB = new DBManager(GetConnectionString());
        }   
    }

    private static string GetConnectionString()
    {
        return ConfigurationManager.ConnectionStrings
                ["TechSupportConnectionString"].ConnectionString; 
    }
    
    private static void CloseDBConnection()
    {
        m_DB.CloseConnection();
    }

    //Gets customer record list
    [DataObjectMethod(DataObjectMethodType.Select,true)] 
    public static IEnumerable GetCustomerList()
    {
        SqlDataReader dr;
        string strSQL;

        InitializeDB();

        strSQL = "SELECT " + FldCustomerID + ", " + FldName 
                    + " FROM " + TblCustomers + " ORDER BY " + FldName;

        dr = m_DB.SelectDirect(strSQL, TblCustomers);

        return dr;
    }

    [DataObjectMethod(DataObjectMethodType.Select)] 
    public static IEnumerable GetCustomersWithIncidents()
    {
        SqlDataReader dr;
        string strSQL;

        InitializeDB();

        strSQL = "SELECT " + FldCustomerID + ", " + FldName +
                 " FROM " + TblCustomers + 
                 " WHERE " + FldCustomerID + " IN" +
                 " (SELECT DISTINCT " + FldCustomerID +
                 " FROM " + TblIncidents + 
                 " WHERE " + FldTechID + " IS NOT NULL)" +
                 " ORDER BY " + FldName;

        dr = m_DB.SelectDirect(strSQL, TblCustomers);

        return dr;
    } 

    public static bool CustomerIDExists(int intCustomerID)
    {
        //Determine if CustomerID exists in Customer table
        DataSet ds;
        string strSQL;
        bool blnResult = false;

        InitializeDB();

        strSQL = "SELECT " + FldCustomerID + " FROM " + TblCustomers + 
                 " WHERE " + FldCustomerID + "=" + intCustomerID;
        
        ds = m_DB.Select(strSQL, TblCustomers);

        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[TblCustomers].Rows.Count > 0)
            {
                blnResult = true;
            }
        }

        return blnResult;
    } 
}
