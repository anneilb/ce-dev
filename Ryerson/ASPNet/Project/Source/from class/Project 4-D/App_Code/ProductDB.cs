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
/// Summary description for ProductDB
/// </summary>
[DataObject(true)]
public class ProductDB
{

    //DB path and connection string for creating DB connection
    //private const string DbPath = "TechSupport";
    //private const string DbConnection = "Data Source=localhost;Initial Catalog=" + DbPath + ";Integrated Security=True";

    //Table name constants
    private const string TblProducts = "Products";
    private const string TblRegistrations = "Registrations";
    
    //Field name constants
    private const string FldProductCode = "ProductCode";
    private const string FldName = "Name";
    private const string FldVersion = "Version";
    private const string FldReleaseDate = "ReleaseDate";
    private const string FldCustomerID = "CustomerID";

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

    ~ProductDB()
    {
        CloseDBConnection();
        m_DB = null;
    }

    private static void CloseDBConnection()
    {
        m_DB.CloseConnection();
    }

    //Gets customer record list
    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public static IEnumerable GetCustomerProducts(int CustomerID)
    {
        SqlDataReader dr;
        string strSQL;

        InitializeDB();

        strSQL = "SELECT " +
                 TblProducts + "." + FldProductCode + ", " +
                 TblProducts + "." + FldName +
                 " FROM " + TblProducts +
                 " INNER JOIN " + TblRegistrations +
                 " ON " + TblProducts + "." + FldProductCode +
                 " = " + TblRegistrations + "." + FldProductCode +
                 " WHERE (" + TblRegistrations + "." + FldCustomerID +
                 " = " + CustomerID + ") ORDER BY " + FldName;

        dr = m_DB.SelectDirect(strSQL, TblProducts);

        return dr;
    }

}
