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

namespace SportsPro
{
    public partial class frmTechnicianIncidents : Form
    {
        private List<Technician> technicianList;
       
        public frmTechnicianIncidents()
        {
            InitializeComponent();
        }

        private void frmTechnicianIncidents_Load(object sender, EventArgs e)
        {
            TechSupportDB.SetConnectionString(ConfigurationManager.
                                                ConnectionStrings["SportsPro.Properties.Settings.TechSupportConnectionString"].
                                                    ConnectionString);

            technicianList = TechnicianDB.GetTechnicianList();
            nameComboBox.DataSource = technicianList;

            nameComboBox.SelectedIndex = 0; 
        }

        private void nameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Incident> incidentsList;

            technicianBindingSource.Clear();

            if (nameComboBox.SelectedIndex > -1)
            {
                int intTechID = technicianList[nameComboBox.SelectedIndex].TechID;

                Technician technician = TechnicianDB.GetTechnician(intTechID);
                technicianBindingSource.Add(technician);

                incidentsList = IncidentDB.GetOpenTechnicianIncidents(intTechID);
                incidentDataGridView.DataSource = incidentsList;
            }
        }
    }
}
