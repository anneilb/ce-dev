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
using System.Reflection;

namespace SportsPro
{
    public partial class frmIncidentAssignment : Form
    {
        private TechSupportDataContext techSupport;
        private SQLIncident selectedIncident;

        public frmIncidentAssignment()
        {
            InitializeComponent();
        }

        private void frmIncidentAssignment_Load(object sender, EventArgs e)
        {
            SQLDataContext.SetConnectionString(ConfigurationManager.
                                ConnectionStrings["SportsPro.Properties.Settings.TechSupportConnectionString"].
                                    ConnectionString);

            techSupport = SQLDataContext.GetTechSupportDataContext();

            InitializeUI();
        }

        private void InitializeUI()
        {
            LoadIncidentDetails();
            LoadTechnicianList();
        }

        private void LoadIncidentDetails()
        {
            var unassignedIncident = (from incident in techSupport.SQLIncidents
                                      where incident.IncidentID == (int)this.Tag
                                      select incident).Single();
            
            selectedIncident = unassignedIncident;
            sQLIncidentBindingSource.DataSource = selectedIncident;                 
        }

        private void LoadTechnicianList()
        {
            var technicians = from technician in techSupport.SQLTechnicians
                              orderby technician.Name
                              select technician;

            technicianComboBox.DataSource = technicians;
            technicianComboBox.SelectedIndex = -1;
        }

        private void DisplayConcurrencyConflicts()
        {
            string strMessage = string.Empty;

            foreach (ObjectChangeConflict objConflict in techSupport.ChangeConflicts)
            {
                SQLIncident incident = (SQLIncident)objConflict.Object;

                if (objConflict.MemberConflicts.Count == 0)
                {
                    strMessage = "Incident " + incident.IncidentID + " has been deleted.";
                    this.DialogResult = DialogResult.Abort;
                }
                else
                {
                    foreach (MemberChangeConflict memberConflict in objConflict.MemberConflicts)
                    {
                        MemberInfo memberInfo = memberConflict.Member;
                        if (memberInfo.Name == "TechID")
                        {
                            strMessage = "Incident " + incident.IncidentID + " TechID field has been changed.";

                            if (memberConflict.OriginalValue == null)
                                strMessage += "\nOriginal value: Null";
                            else
                                strMessage += "\nOriginal value: " + memberConflict.OriginalValue.ToString();

                            if (memberConflict.CurrentValue == null)
                                strMessage += "\nCurrent value: Null";
                            else
                                strMessage += "\nCurrent value: " + memberConflict.CurrentValue.ToString();

                            if (memberConflict.DatabaseValue == null)
                                strMessage += "\nDatabase value: Null";
                            else
                                strMessage += "\nDatabase value: " + memberConflict.DatabaseValue.ToString(); 
                        }
                    } 
                    
                    this.DialogResult = DialogResult.Retry;   
                }
            }

            MessageBox.Show(strMessage, "Member Conflicts", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {           
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            try
            {
                selectedIncident.TechID = (int)technicianComboBox.SelectedValue;
                techSupport.SubmitChanges();
                this.DialogResult = DialogResult.OK;
           }
            catch (ChangeConflictException)
            {
                DisplayConcurrencyConflicts();
            }
            finally
            {
                this.Close();
            }
        }        
        
        private void technicianComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (technicianComboBox.SelectedIndex > -1)
                btnAssign.Enabled = true;
            else
                btnAssign.Enabled = false;
        }
    }


}
