using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SportsPro
{
    public partial class frmCustomerProducts : Form
    {
        public frmCustomerProducts()
        {
            InitializeComponent();
        }

        private void frmCustomerProducts_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'techSupportDataSet4A.Registrations' table. You can move, or remove it, as needed.
            this.registrationsTableAdapter.Fill(this.techSupportDataSet4A.Registrations);
            // TODO: This line of code loads data into the 'techSupportDataSet4A.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.techSupportDataSet4A.Customers);                                                

            LoadCustomersComboBox();
            nameComboBox.SelectedIndex = 0;
        }

        private void LoadCustomersComboBox()
        {
            var customers = from customer in techSupportDataSet4A.Customers                           
                            orderby customer.Name
                            select customer;

            DataView customerView = customers.AsDataView();
            nameComboBox.DataSource = customerView;
        }

        private void nameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (nameComboBox.SelectedIndex > -1)
            {
                var registrations = from registration in techSupportDataSet4A.Registrations
                                    where registration.CustomerID == (int)nameComboBox.SelectedValue
                                    orderby registration.RegistrationDate descending
                                    select registration;

                DataView registrationView = registrations.AsDataView();
                registrationsDataGridView.DataSource = registrationView;
            }
        }

    }
}
