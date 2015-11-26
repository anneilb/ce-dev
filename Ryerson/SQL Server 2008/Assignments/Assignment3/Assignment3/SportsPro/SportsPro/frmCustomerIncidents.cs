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
    public partial class frmCustomerIncidents : Form
    {
        TechSupportDataContext techSupport;
                
        public frmCustomerIncidents()
        {
            InitializeComponent();
        }

        private void frmCustomerIncidents_Load(object sender, EventArgs e)
        {
            SQLDataContext.SetConnectionString(ConfigurationManager.
                                ConnectionStrings["SportsPro.Properties.Settings.TechSupportConnectionString"].
                                    ConnectionString);

            techSupport = SQLDataContext.GetTechSupportDataContext();

            LoadCustomerList();
            nameComboBox.SelectedIndex = 0;
        }

        private void LoadCustomerList()
        {
            var customers = from customer in techSupport.SQLCustomers
                            orderby customer.Name
                            select customer;

            nameComboBox.DataSource = customers;
        }

        private void nameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (nameComboBox.SelectedIndex > -1)
            {
                DisplayVendorDetails();
            }            
        }

        private void DisplayVendorDetails()
        {
            var selectedCustomer = (from customer in techSupport.SQLCustomers
                                    where customer.CustomerID == (int)nameComboBox.SelectedValue
                                    select customer).Single();
            
            sQLCustomerBindingSource.Clear();
            sQLCustomerBindingSource.Add(selectedCustomer);

            sQLIncidentDataGridView.DataSource = selectedCustomer.SQLIncidents;
        }
        
    }
}
