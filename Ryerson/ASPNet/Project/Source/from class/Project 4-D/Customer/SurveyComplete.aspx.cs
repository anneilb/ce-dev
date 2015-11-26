using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SurveyComplete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Survey objSurvey = (Survey)GetSurvey();

        if (objSurvey.Contact)
        {
            lblContactResponse.Text = string.Format("A customer service representative will contact you by {0} within 24 hours.", objSurvey.ContactBy);         
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
