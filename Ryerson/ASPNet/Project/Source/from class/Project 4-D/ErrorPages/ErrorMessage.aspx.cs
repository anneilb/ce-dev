using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ErrorMessage : System.Web.UI.Page
{    
    protected void Page_Load(object sender, EventArgs e)
    {
        string strUrLReferrer;

        if (!this.IsPostBack)
        {
            Exception ex = (Exception)Session["Exception"];
            lblError.Text = ex.Message;
            Session.Remove("Exception");

            if (Request.UrlReferrer != null)
            {
                strUrLReferrer = Request.UrlReferrer.ToString(); 
               
                if(Session["ErrUrlReferrer"] == null)
                {
                    Session.Add("ErrUrlReferrer", strUrLReferrer);
                }
                else
                {
                    Session["ErrUrlReferrer"] = strUrLReferrer;
                }
            }  
        }
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        string strUrLReferrer;

        if (Session["ErrUrlReferrer"] != null)
        {
            strUrLReferrer = Session["ErrUrlReferrer"].ToString();
            Response.Redirect(strUrLReferrer);
        }
        else
        {
            /*Just return to default page if we can't 
            figure out the previous page for some reason*/
            Response.Redirect("~/Default.aspx");
        }            
    }
}
