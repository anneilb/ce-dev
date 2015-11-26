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
using System.Data.Linq;

namespace SportsPro
{
    public partial class frmUnassignedIncidents : Form
    {
        private TechSupportDataContext techSupport;
        private IOrderedQueryable<SQLIncident> incidentList;
        private CurrencyManager cm;         
        
        public frmUnassignedIncidents()
        {
            InitializeComponent();
        }

        private void frmUnassignedIncidents_Load(object sender, EventArgs e)
        {
            SQLDataContext.SetConnectionString(ConfigurationManager.
                                ConnectionStrings["SportsPro.Properties.Settings.TechSupportConnectionString"].
                                    ConnectionString);

            techSupport = SQLDataContext.GetTechSupportDataContext();
            LoadUnassignedIncidents();
            
            //set up currency control  
            cm = (CurrencyManager)sQLIncidentDataGridView.BindingContext[incidentList];          
        }

        private void LoadUnassignedIncidents()
        {
            var unassignedIncidents = from incident in techSupport.SQLIncidents
                                      where incident.TechID.HasValue == false
                                      orderby incident.DateOpened descending
                                      select incident;

            incidentList = unassignedIncidents; 
            sQLIncidentBindingSource.DataSource = incidentList; 
        }

        private void sQLIncidentDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {           
            if (e.ColumnIndex == 4) //Assign Incident button clicked
            {
                int intRowIndex = e.RowIndex;
                DataGridViewRow row = sQLIncidentDataGridView.Rows[intRowIndex];
                DataGridViewCell cell = row.Cells[0];
                int incidentID = (int)cell.Value;

                //Display the Assign Incident form
                Form incidentAssignmentForm = new frmIncidentAssignment(); 
                incidentAssignmentForm.Tag = incidentID;
                DialogResult result = incidentAssignmentForm.ShowDialog(this);

                if (result == DialogResult.OK || result == DialogResult.Retry)
                {
                    cm.Refresh();
                    LoadUnassignedIncidents();
                }
            }
        }
    }
}
