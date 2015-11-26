using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Customer
/// </summary>
public class Customer
{
    private int m_intID;
    private string m_strName;
    private string m_strAddress;
    private string m_strCity;
    private string m_strState;
    private string m_strZIPCode;
    private string m_strPhone;
    private string m_strEmail;

    public int ID
    {
        get { return m_intID; }
        set { m_intID = value; }
    }

    public string Name
    {
        get { return m_strName; }
        set { m_strName = value; }
    }

    public string Address
    {
        get { return m_strAddress; }
        set { m_strAddress = value; }
    }

    public string City
    {
        get { return m_strCity; }
        set { m_strCity = value; }
    }

    public string State
    {
        get { return m_strState; }
        set { m_strState = value; }
    }

    public string ZIPCode
    {
        get { return m_strZIPCode; }
        set { m_strZIPCode = value; }
    }

    public string Phone
    {
        get { return m_strPhone; }
        set { m_strPhone = value; }
    }

    public string Email
    {
        get { return m_strEmail; }
        set { m_strEmail = value; }
    }

    public Customer()
	{      
		//
		// TODO: Add constructor logic here
		//
	}

    public string ContactDisplay()
    {
        string displayString = m_strName + ": " + m_strPhone + "; " + m_strEmail;            
        return displayString;
    }
}
