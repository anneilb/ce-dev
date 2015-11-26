using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration; 
using TechSupportData;
using System.Data.SqlClient;

namespace SportsPro
{
    public partial class frmOpenIncidents : Form
    {
        public frmOpenIncidents()
        {
            InitializeComponent();
        }

        private void frmOpenIncidents_Load(object sender, EventArgs e)
        {
            TechSupportDB.SetConnectionString(ConfigurationManager.
                                                ConnectionStrings["SportsPro.Properties.Settings.TechSupportConnectionString"].
                                                    ConnectionString);

            //TechSupportDB.SetConnectionString("Data Source=localhost;Initial Catalog=TechSupportx;Integrated Security=True"); 
         
            PopulateIncidentsList();                            
        }

        private void PopulateIncidentsList()
        {
            try
            {
                List<Incident> incidentsList = IncidentDB.GetOpenIncidents();
                ListViewItem lvwItem;

                foreach (Incident incident in incidentsList)
                {
                    lvwItem = lvwIncidents.Items.Add(incident.ProductCode);
                    lvwItem.SubItems.Add(incident.DateOpened.ToShortDateString());
                    lvwItem.SubItems.Add(incident.CustomerName);
                    lvwItem.SubItems.Add(incident.TechnicianName);
                    lvwItem.SubItems.Add(incident.Title);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "SQL Exception " + ex.Number, MessageBoxButtons.OK,
                                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
