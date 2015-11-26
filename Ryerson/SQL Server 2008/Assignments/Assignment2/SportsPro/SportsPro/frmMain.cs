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

        private void mnuIncidentsDisplayOpenIncidents_Click(object sender, EventArgs e)
        {
            Form openIncidentsForm = new frmOpenIncidents();
            openIncidentsForm.MdiParent = this;
            openIncidentsForm.Show();
        }

        private void mnuIncidentsCreateIncident_Click(object sender, EventArgs e)
        {
            Form createIncidentForm = new frmCreateIncident();
            createIncidentForm.MdiParent = this;
            createIncidentForm.Show();
        }

        private void mnuIncidentsDisplayOpenIncidentsByTechnician_Click(object sender, EventArgs e)
        {
            Form technicianIncidentsForm = new frmTechnicianIncidents();
            technicianIncidentsForm.MdiParent = this;
            technicianIncidentsForm.Show();
        }
    }
}
