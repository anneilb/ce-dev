using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Survey
/// </summary>
public class Survey
{
    private int m_intCustomerID;
    private int m_intIncidentID;
    private int m_intResponseTime;
    private int m_intTechEfficiency;
    private int m_intResolution;
    private string m_strComments;
    private bool m_blnContact;
    private string m_strContactBy;

    public int CustomerID
    {
        get { return m_intCustomerID; }
        set { m_intCustomerID = value; }
    }

    public int IncidentID
    {
        get { return m_intIncidentID; }
        set { m_intIncidentID = value; }
    }

    public int ResponseTime
    {
        get { return m_intResponseTime; }
        set { m_intResponseTime = value; }
    }

    public int TechEfficiency
    {
        get { return m_intTechEfficiency; }
        set { m_intTechEfficiency = value; }
    }

    public int Resolution
    {
        get { return m_intResolution; }
        set { m_intResolution = value; }
    }

    public string Comments
    {
        get { return m_strComments; }
        set { m_strComments = value; }
    }

    public bool Contact
    {
        get { return m_blnContact; }
        set { m_blnContact = value; }
    }

    public string ContactBy
    {
        get { return m_strContactBy; }
        set { m_strContactBy = value; }
    }
    
	public Survey()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
