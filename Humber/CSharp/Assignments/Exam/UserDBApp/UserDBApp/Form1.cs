using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UserDBApp
{
    public partial class Form1 : Form
    {
        private DataLayer m_DL;

        public Form1()
        {
            InitializeComponent();
            m_DL = new DataLayer();

        }         


        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            User objUser;

            if (FindUser(txtUemail.Text, out objUser))
            {
                if (UpdateUser(ref objUser))
                {
                    MessageBox.Show(this, "Existing user updated.", "Existing User Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (AddUser())
                {
                    MessageBox.Show(this, "User record added.", "User Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        
  
        private bool FindUser(string strUemail, out User objUser)
        {
            User objU;
            string email;

            email = strUemail.Trim();

            objU = new User(ref m_DL);
            objU.Populate(email);

            if (!objU.IsNew)
            {
                objUser = objU;
                return true;
            }

            objUser = null;
            return false;
        }


        private bool AddUser()
        {
            bool blnResult = false;

            User newUser = new User(ref m_DL);

            newUser.FName = txtFname.Text.Trim();
            newUser.LName = txtLname.Text.Trim();
            newUser.Address = txtAddress.Text.Trim();
            newUser.Uemail = txtUemail.Text.Trim();

            //Write record to DB
            blnResult = newUser.Update();

            return blnResult;
        }
         
        private bool UpdateUser(ref User objUser)
        {
            bool blnResult = false;

            objUser.FName = txtFname.Text.Trim();
            objUser.LName = txtLname.Text.Trim();
            objUser.Address = txtAddress.Text.Trim();
            objUser.Uemail = txtUemail.Text.Trim();

            //Write record to DB
            blnResult = objUser.Update();

            return blnResult;
        }
       
        private void ClearAllFields()
        {
            txtFname.Text = "";
            txtLname.Text = "";
            txtAddress.Text = "";
            txtUemail.Text = "";
        } 

    }
}