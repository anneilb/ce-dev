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
/// Summary description for IncidentDB
/// </summary>
[DataObject(true)]
public class IncidentDB
{
	
    //DB path and connection string for creating DB connection
    //private const string DbPath = "TechSupport";
    //private const string DbConnection = "Data Source=localhost;Initial Catalog=" + DbPath + ";Integrated Security=True";

    private const string DateValueNull = "01/01/0001 12:00:00 AM";
    
    //Table name constants
    private const string TblIncidents = "Incidents";

    //Field name constants
    private const string FldIncidentID = "IncidentID";
    private const string FldCustomerID = "CustomerID";
    private const string FldProductCode = "ProductCode";
    private const string FldTechID = "TechID";
    private const string FldDateOpened = "DateOpened";
    private const string FldDateClosed = "DateClosed";
    private const string FldTitle = "Title";
    private const string FldDescription = "Description";
    

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

    ~IncidentDB()
    {
        CloseDBConnection();
        m_DB = null;
    }

    private static void CloseDBConnection()
    {
        m_DB.CloseConnection();
    }

    //Gets customer record list
    [DataObjectMethod(DataObjectMethodType.Select,true)] 
    public static IEnumerable GetIncidents()
    {
        SqlDataReader dr;
        string strSQL;

        InitializeDB();

        strSQL = "SELECT * FROM " + TblIncidents + " ORDER BY " + FldDateOpened;
        dr = m_DB.SelectDirect(strSQL, TblIncidents);

        return dr;
    }

    [DataObjectMethod(DataObjectMethodType.Select)]
    public static IEnumerable GetCustomerIncidents(int CustomerID)
    {
        SqlDataReader dr;
        string strSQL;

        InitializeDB();

        strSQL = "SELECT " + FldIncidentID + ", " + FldProductCode + ", " +
                 FldDateOpened + ", " + FldDateClosed + ", " +
                 FldTitle + ", " + FldDescription +
                 " FROM " + TblIncidents + 
                 " WHERE " + FldCustomerID + " = " + CustomerID +
                 " ORDER BY " + FldDateOpened;

        dr = m_DB.SelectDirect(strSQL, TblIncidents);

        return dr;
    }
    
    //Inserts an incident record
    [DataObjectMethod(DataObjectMethodType.Insert, true)] 
    public static void InsertIncident(int CustomerID, string ProductCode, string Title, string Description)
    {
        SortedList slValues = new SortedList();

        InitializeDB();

        slValues.Add(FldCustomerID, CustomerID);
        slValues.Add(FldProductCode, ProductCode);
        slValues.Add(FldTechID, null);
        slValues.Add(FldDateOpened, DateTime.Today);
        slValues.Add(FldDateClosed, null);
        slValues.Add(FldTitle, Title);
        slValues.Add(FldDescription, Description);

        m_DB.InsertDirect(TblIncidents, slValues);        
    }

    //Updates an incident record
    [DataObjectMethod(DataObjectMethodType.Update, true)]
    public static int UpdateIncident(DateTime DateClosed, string Description,
                                      int original_IncidentID, string original_ProductCode,
                                      DateTime original_DateOpened, object original_DateClosed,
                                      string original_Title, string original_Description)
    {
        SortedList slValues = new SortedList();
        SortedList slOriginalValues = new SortedList();
        string strWhere = "";
        int intResult = 0;
        DateTime dteTemp;

        InitializeDB();        
         
        //handle null dates properly
        if (DateClosed == Convert.ToDateTime(DateValueNull))
        {
            slValues.Add(FldDateClosed, null);
        }
        else
        {
            slValues.Add(FldDateClosed, DateClosed.ToString("yyyy-MM-dd")); //for handling SQL date problems
        }

        slValues.Add(FldDescription, Description);

        slOriginalValues.Add(FldIncidentID, original_IncidentID);
        slOriginalValues.Add(FldProductCode, original_ProductCode);
        slOriginalValues.Add(FldDateOpened, original_DateOpened.ToString("yyyy-MM-dd")); //for handling SQL date compare problems
        slOriginalValues.Add(FldTitle, original_Title);
        slOriginalValues.Add(FldDescription, original_Description);

        //handle null dates properly
        if(original_DateClosed.GetType().ToString() == "System.DBNull")
        {            
            strWhere = FldDateClosed + " IS NULL";
        }
        else if(original_DateClosed.GetType().ToString() == "System.DateTime")
        {
            if ((DateTime)original_DateClosed == Convert.ToDateTime(DateValueNull))
            {
                strWhere = FldDateClosed + " IS NULL";
            }
            else
            {
                dteTemp = (DateTime)original_DateClosed;
                slOriginalValues.Add(FldDateClosed, dteTemp.ToString("yyyy-MM-dd")); //for handling SQL date compare problems
            }                       
        }

        intResult = m_DB.UpdateDirect(TblIncidents, strWhere, slValues, slOriginalValues);
        
        return intResult;
    }      

}
