using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

public partial class ContactDisplay : System.Web.UI.Page
{
    private SortedList m_slContactList; 

    protected void Page_Load(object sender, EventArgs e)
    {
        m_slContactList = GetCart();

        if (!this.IsPostBack)
        {
            DisplayContactList(m_slContactList);
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

    private void DisplayContactList(SortedList slContactList)
    {
        lstContacts.Items.Clear();

        if (slContactList.Count > 0)
        {
            foreach (DictionaryEntry objItem in slContactList)
            {
                Customer c = (Customer)objItem.Value;
                lstContacts.Items.Add(c.ContactDisplay());
            }
        }

    }
    protected void btnRemoveContact_Click(object sender, EventArgs e)
    {
        if (m_slContactList.Count > 0)
        {
            if (lstContacts.SelectedIndex > -1)
            {
                m_slContactList.RemoveAt(lstContacts.SelectedIndex);
                DisplayContactList(m_slContactList);
            }
        }
    }
    protected void btnEmptyList_Click(object sender, EventArgs e)
    {
        if (m_slContactList.Count > 0)
        {
            m_slContactList.Clear();
            DisplayContactList(m_slContactList);
        }
    }
}
