using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

public partial class IncidentAssignment : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSelectIncidentNext_Click(object sender, EventArgs e)
    {
        if (grdSelectIncident.SelectedIndex != -1)
        {
            DataRowView SelectedIncident = GetSelectedIncident();
            AddIncidentToSession(SelectedIncident);
            mvwAssignIncident.ActiveViewIndex = 1;
        }
        else
        {
            lblSelectIncidentError.Text = "An incident must be selected.";
        }
    }

    protected void btnSelectTechNext_Click(object sender, EventArgs e)
    {
        if (grdSelectTech.SelectedIndex != -1)
        {
            DataRowView SelectedIncident = GetSessionIncident();
            DataRowView SelectedTech = GetSelectedTech();
            AddTechToSession(SelectedTech);

            if (SelectedIncident != null)
            {
                lblSummary.Text = "Incident for customer " + SelectedIncident["CustomerName"] +
                                  " and product " + SelectedIncident["ProductCode"].ToString().Trim() +
                                  " will be assigned to technician " + SelectedTech["Name"] + ".";

                mvwAssignIncident.ActiveViewIndex = 2;
            }
            else
            {
                lblSelectTechError.Text = "Error reading session data.";
            }
        }
        else
        {
            lblSelectTechError.Text = "A technician must be selected.";
        }
    }    

    protected void btnAssignIncident_Click(object sender, EventArgs e)
    {
        DataRowView SelectedIncident = GetSelectedIncident();
        DataRowView SelectedTech = GetSelectedTech();

        if (SelectedIncident != null && SelectedTech != null)
        {
            SqlDataSource3.UpdateParameters["IncidentID"].DefaultValue = "" + SelectedIncident["IncidentID"];
            SqlDataSource3.UpdateParameters["TechID"].DefaultValue = "" + SelectedTech["TechID"];

            try
            {
                SqlDataSource3.Update();
                
                grdSelectIncident.SelectedIndex = -1;
                grdSelectTech.SelectedIndex = -1;

                grdSelectIncident.DataBind();
                grdSelectTech.DataBind();

                mvwAssignIncident.ActiveViewIndex = 0;
            }
            catch (Exception ex)
            {
                //lblSummaryError.Text = "A database error has occurred. <br /><br />" +
                //                "Message: " + ex.Message;

                Session["Exception"] = ex;
                Response.Redirect("~/ErrorPages/ErrorMessage.aspx");
            }
        }
        else
        {
            lblSummaryError.Text = "Error reading session data.";
        }
    }

    private DataRowView GetSelectedIncident()
    {
        DataView IncidentsTable = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
        IncidentsTable.RowFilter = "IncidentID = " + grdSelectIncident.SelectedValue;
        DataRowView row = (DataRowView)IncidentsTable[0];

        return row;
    }

    private DataRowView GetSelectedTech()
    {
        DataView TechniciansTable = (DataView)SqlDataSource2.Select(DataSourceSelectArguments.Empty);
        TechniciansTable.RowFilter = "TechID = " + grdSelectTech.SelectedValue;
        DataRowView row = (DataRowView)TechniciansTable[0];

        return row;
    }

    private void AddIncidentToSession(DataRowView SelectedIncident)
    {
        if (this.Session["SelectedIncident"] == null)
        {
            this.Session.Add("SelectedIncident", SelectedIncident);
        }
        else
        {
            this.Session["SelectedIncident"] = SelectedIncident;
        }
    }

    private DataRowView GetSessionIncident()
    {
        DataRowView SessionIncident;

        if (this.Session["SelectedIncident"] != null)
        {
            SessionIncident = (DataRowView)this.Session["SelectedIncident"];
        }
        else
        {
            SessionIncident = null;
        }

        return SessionIncident;
    }

    private void AddTechToSession(DataRowView SelectedTech)
    {
        if (this.Session["SelectedTech"] == null)
        {
            this.Session.Add("SelectedTech", SelectedTech);
        }
        else
        {
            this.Session["SelectedTech"] = SelectedTech;
        }
    }

    private DataRowView GetSessionTech()
    {
        DataRowView SessionTech;

        if (this.Session["SelectedTech"] != null)
        {
            SessionTech = (DataRowView)this.Session["SelectedTech"];
        }
        else
        {
            SessionTech = null;
        }

        return SessionTech;
    }
}
