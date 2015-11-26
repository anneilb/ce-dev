using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics; 

public partial class CustomerIncidentDisplay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            ddlCustomers.DataBind();
            DataList1.DataBind();
        }
    }
    
    protected void ddlCustomers_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ddlCustomers.DataBind();
    }
}
