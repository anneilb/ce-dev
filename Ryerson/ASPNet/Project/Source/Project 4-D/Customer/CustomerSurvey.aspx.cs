using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class CustomerSurvey : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            EnableControls(false);
            txtCustomerID.Focus();
        }
    }

    protected void btnGetIncidents_Click(object sender, EventArgs e)
    {
        this.Validate("CustomerID");

        if (this.IsValid)
        {
            if (GetSelectedCustomerIncidents(txtCustomerID.Text.Trim()))
            {
                lblNoClosedIncidents.Visible = false;
                EnableControls(true);
                lstIncidents.Focus();
            }
            else
            {
                lblNoClosedIncidents.Visible = true;
                EnableControls(false);
            }
        }
        else
        {
            txtCustomerID.Focus();
        }
    }

    private bool GetSelectedCustomerIncidents(string strCustomerID)
    {
        Incident objIncident;
        bool blnResult = false;

        DataView customerIncidents = (DataView)AccessDataSource1.Select(DataSourceSelectArguments.Empty);
        customerIncidents.RowFilter = "(CustomerID = " + strCustomerID + ") AND (DateClosed IS NOT NULL)";

        lstIncidents.Items.Clear();

        if (customerIncidents.Count > 0)
        {
            //Add instruction item
            lstIncidents.Items.Add(new ListItem("--Select an incident--", "None"));

            foreach (DataRowView row in customerIncidents)
            {
                objIncident = new Incident();
                objIncident.ID = (int)row["IncidentID"];
                objIncident.CustomerID = (int)row["CustomerID"];
                objIncident.ProductCode = row["ProductCode"].ToString();
                objIncident.TechID = (int)row["TechID"];
                objIncident.DateOpened = (DateTime)row["DateOpened"];
                objIncident.DateClosed = (DateTime)row["DateClosed"];
                objIncident.Title = row["Title"].ToString();

                lstIncidents.Items.Add(new ListItem(objIncident.CustomerIncidentDisplay(),
                                                    objIncident.ID.ToString()));
            }

            lstIncidents.SelectedValue = "None";
            blnResult = true;
        }

        return blnResult;
    }

    private void EnableControls(bool Enable)
    {
        lstIncidents.Enabled = Enable;
        lblSurveyInstructions.Enabled = Enable;
        lblResponseTime.Enabled = Enable;
        rblResponseTime.Enabled = Enable;
        lblTechEfficiency.Enabled = Enable;
        rblTechEfficiency.Enabled = Enable;
        lblProblemResolution.Enabled = Enable;
        rblProblemResolution.Enabled = Enable;
        lblComments.Enabled = Enable;
        txtComments.Enabled = Enable;
        chkContact.Enabled = Enable;
        rbContactByEmail.Enabled = Enable;
        rbContactByPhone.Enabled = Enable;
        btnSubmit.Enabled = Enable;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        this.Validate("Incidents");

        if (this.IsValid)
        {
            GetSurveyResults();
            this.Response.Redirect("~/Customer/SurveyComplete.aspx");
        }
    }

    private void GetSurveyResults()
    {
        Survey objSurvey = GetSurvey();

        objSurvey.CustomerID = int.Parse(txtCustomerID.Text.Trim());
        objSurvey.IncidentID = int.Parse(lstIncidents.SelectedValue);
        
        if (rblResponseTime.SelectedIndex > -1)
        {
            objSurvey.ResponseTime = int.Parse(rblResponseTime.SelectedValue);
        }

        if (rblTechEfficiency.SelectedIndex > -1)
        {
            objSurvey.TechEfficiency = int.Parse(rblTechEfficiency.SelectedValue);
        }

        if (rblProblemResolution.SelectedIndex > -1)
        {
            objSurvey.Resolution = int.Parse(rblProblemResolution.SelectedValue);
        }

        objSurvey.Comments = txtComments.Text;

        if (chkContact.Checked)
        {
            objSurvey.Contact = chkContact.Checked;

            if (rbContactByEmail.Checked)
            {
                objSurvey.ContactBy = "Email";
            }
            else if (rbContactByPhone.Checked)
            {
                objSurvey.ContactBy = "Phone";
            }
        }
    }

    private Survey GetSurvey()
    {
        if (this.Session["Survey"] == null)
        {
            this.Session.Add("Survey", new Survey());
        }

        return (Survey)this.Session["Survey"];
    }

}
