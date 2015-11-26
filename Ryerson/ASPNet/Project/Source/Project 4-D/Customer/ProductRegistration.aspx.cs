using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Net.Mail;
using System.Net;

public partial class ProductRegistration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            EnableControls(false);
            txtCustomerID.Focus();
        }
    }

    private void EnableControls(bool Enable)
    {
        lblCustomerNameLabel.Enabled = Enable;
        lblCustomerName.Enabled = Enable;
        lblSelectProduct.Enabled = Enable;
        ddlSelectProduct.Enabled = Enable;
        btnRegisterProduct.Enabled = Enable;
    }

    protected void vldCustomCustomerID_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (this.IsValid)
        {
            args.IsValid = CustomerDB.CustomerIDExists(int.Parse(args.Value));
        }
    }

    protected void btnGetCustomer_Click(object sender, EventArgs e)
    {
        if (this.IsValid)
        {
            //SqlDataSource1.SelectParameters["CustomerID"].DefaultValue = txtCustomerID.Text;
            //SqlDataSource1.DataBind();
            DataView CustomersTable = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
            DataRowView row = (DataRowView)CustomersTable[0];

            lblCustomerName.Text = row["Name"].ToString();
            EnableControls(true);
        }
        else
        {
            lblCustomerName.Text = "";
            ddlSelectProduct.SelectedValue = "-1";
            EnableControls(false);
        }
    }

    protected void btnRegisterProduct_Click(object sender, EventArgs e)
    {
        //Validate customer ID again, as it may have been changed
        this.Validate("CustomerID");

        if (this.IsValid)
        {
            SqlDataSource3.InsertParameters["CustomerID"].DefaultValue = txtCustomerID.Text;
            SqlDataSource3.InsertParameters["ProductCode"].DefaultValue = ddlSelectProduct.SelectedValue;
            SqlDataSource3.InsertParameters["RegistrationDate"].DefaultValue = "" + DateTime.Today;

            try
            {
                SqlDataSource3.Insert();

                //send email
                SendConfirmationEmail();

                txtCustomerID.Text = "";
                txtCustomerID.Focus();
                lblCustomerName.Text = "";
                ddlSelectProduct.SelectedValue = "-1";
                EnableControls(false);
            }
            catch (Exception ex)
            {
                //lblError.Text = "A database error has occurred. <br /><br />" +
                //"Message: " + ex.Message; 

                Session["Exception"] = ex;
                Response.Redirect("~/ErrorPages/ErrorMessage.aspx");
            }
        }
        else
        {
            //lblCustomerName.Text = "";
            //ddlSelectProduct.SelectedValue = "-1";
            //EnableControls(false);
        }
    }

    private void SendConfirmationEmail()
    {
        MailMessage Msg;        
        SmtpClient MailClient;
        NetworkCredential MyCredentials;
        
        DataView CustomersTable = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
        DataRowView CustomerRecord = (DataRowView)CustomersTable[0];

        Msg = new MailMessage();

        //Msg.From = new MailAddress("sportspro@sportsprosoftware.com");
        Msg.From = new MailAddress("spamanneil@gmail.com");
        Msg.To.Add(new MailAddress(CustomerRecord["Email"].ToString()));
 
        Msg.Subject = "Product Registration";
        Msg.Body = "Thank you for registering " + ddlSelectProduct.SelectedItem.Text + " with us. " + 
                   "You will be notified of any future updates.\n\nThe Sports Pro Team";

        MyCredentials = new NetworkCredential("spamanneil@gmail.com", "crappy88");
        MailClient = new SmtpClient("smtp.gmail.com", 587); //465 
        MailClient.EnableSsl = true;  
        MailClient.UseDefaultCredentials = false;
        MailClient.Credentials = MyCredentials;

        MailClient.Send(Msg);
    }
}
