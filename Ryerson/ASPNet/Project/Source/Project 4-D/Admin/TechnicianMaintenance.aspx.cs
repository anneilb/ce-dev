using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TechnicianMaintenance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void FormView1_ItemDeleted(object sender, FormViewDeletedEventArgs e)
    {
        if (e.Exception != null)
        {
            lblError.Text = "A database error has occurred. <br /><br />" +
                            "Message: " + e.Exception.Message;
            e.ExceptionHandled = true;
        }
        else if (e.AffectedRows == 0)
        {
            lblError.Text = "Another user may have updated that product.<br /> Please try again.";
        }
        else
        {
            //no errors occurred
            ddlTechnician.DataBind();
        }
    }
    protected void FormView1_ItemInserted(object sender, FormViewInsertedEventArgs e)
    {
        if (e.Exception != null)
        {
            lblError.Text = "A database error has occurred. <br /><br />" +
                            "Message: " + e.Exception.Message;
            e.ExceptionHandled = true;
            e.KeepInInsertMode = true;
        }
        else
        {
            //no errors occurred
            ddlTechnician.DataBind();
        }
    }
    protected void FormView1_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
    {
        if (e.Exception != null)
        {
            lblError.Text = "A database error has occurred. <br /><br />" +
                            "Message: " + e.Exception.Message;
            e.ExceptionHandled = true;
            e.KeepInEditMode = true;
        }
        else if (e.AffectedRows == 0)
        {
            lblError.Text = "Another user may have updated that technician.<br /> Please try again.";
        }
        else
        {
            //no errors occurred
            ddlTechnician.DataBind();
        }
    }
 
    protected void FormView1_ModeChanging(object sender, FormViewModeEventArgs e)
    {
        if(e.NewMode == FormViewMode.Edit)
        {
            vldSummaryTech.ValidationGroup = "EditTech";
        }
        else if(e.NewMode == FormViewMode.Insert)
        {
            vldSummaryTech.ValidationGroup = "InsertTech";

        }
    }
}
