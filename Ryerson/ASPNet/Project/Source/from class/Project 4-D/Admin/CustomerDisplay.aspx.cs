using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

public partial class _CustomerDisplay : System.Web.UI.Page 
{
    private Customer m_objSelectedCustomer;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            ddlCustomers.DataBind();
        }

        m_objSelectedCustomer = GetSelectedCustomer();
        lblAddress.Text = m_objSelectedCustomer.Address + "\n" +
                          m_objSelectedCustomer.City + ", " +
                          m_objSelectedCustomer.State + "  " +
                          m_objSelectedCustomer.ZIPCode;
        lblPhone.Text = m_objSelectedCustomer.Phone;
        lblEmail.Text = m_objSelectedCustomer.Email;
        lblContactExists.Visible = false;

    }

    private Customer GetSelectedCustomer()
    {
        DataView customersTable = (DataView)AccessDataSource1.Select(DataSourceSelectArguments.Empty);
        customersTable.RowFilter = "CustomerID = '" + ddlCustomers.SelectedValue + "'";
        DataRowView row = (DataRowView)customersTable[0];

        Customer c = new Customer();
        c.ID = (int)row["CustomerID"];
        c.Name = row["Name"].ToString();
        c.Address = row["Address"].ToString();
        c.City = row["City"].ToString();
        c.State = row["State"].ToString();
        c.ZIPCode = row["ZipCode"].ToString();
        c.Phone = row["Phone"].ToString();
        c.Email = row["Email"].ToString();
        
        return c;          
    }
    protected void btnAddToContacts_Click(object sender, EventArgs e)
    {
        if (this.IsValid)
        {
            Customer c = new Customer();
            c = m_objSelectedCustomer;
            AddToCart(c);          
        }
    }

    private void AddToCart(Customer c)
    {
        SortedList slContactList = GetCart();
        int intCustomerID = m_objSelectedCustomer.ID;

        lblContactExists.Visible = false;

        if (slContactList.ContainsKey(intCustomerID))
        {
            lblContactExists.Visible = true;
        }
        else
        {
            slContactList.Add(intCustomerID, c);
            this.Response.Redirect("~/Admin/ContactDisplay.aspx");
        }
    }

    private SortedList GetCart()
    {
        if (this.Session["ContactList"] == null)
        {
            this.Session.Add("ContactList", new SortedList());
        }

        return (SortedList)this.Session["ContactList"];
    }
 
}
