using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Assignment1
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void mnuMaintenanceMaintainProducts_Click(object sender, EventArgs e)
        {
            Form productMaintForm = new frmProductMaintenance();
            productMaintForm.MdiParent = this;
            productMaintForm.Show();
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuMaintenanceMaintainCustomers_Click(object sender, EventArgs e)
        {
            Form customerMaintForm = new frmCustomerMaintenance();
            customerMaintForm.MdiParent = this;
            customerMaintForm.Show();
        }

        private void mnuIncidentsDisplayIncidentsbyProduct_Click(object sender, EventArgs e)
        {
            Form productIncidentsForm = new frmProductIncidents();
            productIncidentsForm.MdiParent = this;
            productIncidentsForm.Show();
        }
    }
}
