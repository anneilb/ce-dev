using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Incident
/// </summary>
public class Incident
{
    private int m_intID;
    private int m_intCustomerID;
    private string m_strProductCode;
    private int m_intTechID;
    private DateTime m_dteDateOpened;
    private DateTime m_dteDateClosed;
    private string m_strTitle;
    private string m_strDescription;

    public int ID
    {
        get { return m_intID; }
        set { m_intID = value; }
    }

    public int CustomerID
    {
        get { return m_intCustomerID; }
        set { m_intCustomerID = value; }
    }

    public string ProductCode
    {
        get { return m_strProductCode; }
        set { m_strProductCode = value; }
    }

    public int TechID
    {
        get { return m_intTechID; }
        set { m_intTechID = value; }
    }

    public DateTime DateOpened
    {
        get { return m_dteDateOpened; }
        set { m_dteDateOpened = value; }
    }

    public DateTime DateClosed
    {
        get { return m_dteDateClosed; }
        set { m_dteDateClosed = value; }
    }

    public string Title
    {
        get { return m_strTitle; }
        set { m_strTitle = value; }
    }

    public string Description
    {
        get { return m_strDescription; }
        set { m_strDescription = value; }
    }
    
	public Incident()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string CustomerIncidentDisplay()
    {
        string strResult;
        strResult = string.Format("Incident for product {0} closed {1} ({2})", 
                                    m_strProductCode, m_dteDateClosed.ToShortDateString(), m_strTitle);
        return strResult;
    }

}
