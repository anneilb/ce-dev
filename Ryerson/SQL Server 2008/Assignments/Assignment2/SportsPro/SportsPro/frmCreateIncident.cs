using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TechSupportData;
using System.Configuration;

namespace SportsPro
{
    public partial class frmCreateIncident : Form
    {
        public frmCreateIncident()
        {
            InitializeComponent();
        }

        private void frmCreateIncident_Load(object sender, EventArgs e)
        {
            TechSupportDB.SetConnectionString(ConfigurationManager.
                                                ConnectionStrings["SportsPro.Properties.Settings.TechSupportConnectionString"].
                                                    ConnectionString);
            
            PopulateComboBoxes();
        }

        private void PopulateComboBoxes()
        {
            List<Customer> customerList;
            List<Product> productList;

            customerList = CustomerDB.GetCustomerList();
            cboCustomers.DataSource = customerList;
            cboCustomers.DisplayMember = CustomerDB.FldName;
            cboCustomers.ValueMember = CustomerDB.FldCustomerID;

            productList = ProductDB.GetProductList();
            cboProducts.DataSource = productList;
            cboProducts.DisplayMember = ProductDB.FldName;
            cboProducts.ValueMember = ProductDB.FldProductCode;
        }

        private void btnCreateIncident_Click(object sender, EventArgs e)
        {
            int intResult; 

            if (this.IsValid())
            {
                //Create the incident record if valid
                Incident incident = new Incident();

                incident.CustomerID = (int)cboCustomers.SelectedValue;
                incident.ProductCode = (string)cboProducts.SelectedValue;
                incident.DateOpened = DateTime.Now;
                incident.Title = txtTitle.Text;
                incident.Description = txtDescription.Text;

                intResult = IncidentDB.AddIncident(incident);

                if (intResult == 1)
                    this.Close();
            }
        }

        private bool IsValid()
        {
            bool blnResult = true;

            blnResult = (Validator.IsPresent(cboCustomers, "Customer") &&
                         Validator.IsPresent(cboProducts, "Product") &&
                         Validator.IsPresent(txtTitle, "Title") &&
                         Validator.IsPresent(txtDescription, "Description") &&
                         IsSelectedProductRegistered());

            return blnResult;
        }

        private bool IsSelectedProductRegistered()
        {
            bool blnResult;

            blnResult =  RegistrationDB.ProductRegistered((int)(cboCustomers.SelectedValue),
                                                          (string)cboProducts.SelectedValue);

            if(!blnResult)
                Validator.ShowError("The selected product is not registered for this customer");
            
            return blnResult;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
