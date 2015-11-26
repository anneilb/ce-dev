using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IncidentCreation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAddIncident_Click(object sender, EventArgs e)
    {
        if (this.IsValid)
        {
            ObjectDataSource3.InsertParameters["CustomerID"].DefaultValue = ddlCustomers.SelectedValue;
            ObjectDataSource3.InsertParameters["ProductCode"].DefaultValue = ddlProducts.SelectedValue.Trim();
            ObjectDataSource3.InsertParameters["Title"].DefaultValue = txtTitle.Text;
            ObjectDataSource3.InsertParameters["Description"].DefaultValue = txtDescription.Text;
                        
            try
            {
                ObjectDataSource3.Insert();
                ddlCustomers.SelectedValue = "-1";
                ddlProducts.SelectedValue = "-1";  
                txtTitle.Text = "";
                txtDescription.Text = "";
            }
            catch (Exception ex)
            {
                //lblError.Text = "A database error has occurred. <br /><br />" +
                //                "Message: " + ex.Message;

                Session["Exception"] = ex;
                Response.Redirect("~/ErrorPages/ErrorMessage.aspx");
            }
        }
    }
}
