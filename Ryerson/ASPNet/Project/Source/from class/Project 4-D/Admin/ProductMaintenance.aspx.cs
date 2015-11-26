using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductMaintenance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnAddProduct_Click(object sender, EventArgs e)
    {
        SqlDataSource1.InsertParameters["ProductCode"].DefaultValue = txtAddProductCode.Text;
        SqlDataSource1.InsertParameters["Name"].DefaultValue = txtAddProductName.Text;
        SqlDataSource1.InsertParameters["Version"].DefaultValue = txtAddProductVersion.Text;
        SqlDataSource1.InsertParameters["ReleaseDate"].DefaultValue = txtAddProductReleaseDate.Text;

        try
        {
            SqlDataSource1.Insert();
            txtAddProductCode.Text = "";
            txtAddProductName.Text = "";
            txtAddProductVersion.Text = "";
            txtAddProductReleaseDate.Text = "";
        }
        catch (Exception ex)
        {
            //lblError.Text = "A database error has occurred. <br /><br />" +
            //                "Message: " + ex.Message;

            Session["Exception"] = ex;
            Response.Redirect("~/ErrorPages/ErrorMessage.aspx");
        }
    }
    
    protected void grdProducts_RowUpdated(object sender, GridViewUpdatedEventArgs e)
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
            lblError.Text = "Another user may have updated that product.<br /> Please try again.";
        }
    }

    protected void grdProducts_RowDeleted(object sender, GridViewDeletedEventArgs e)
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
    }
}
