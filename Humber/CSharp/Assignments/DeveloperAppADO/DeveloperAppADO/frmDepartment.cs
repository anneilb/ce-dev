using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DeveloperAppADO
{
    public partial class frmDepartment : Form
    {
        private DataLayer m_DL;
        private bool m_blnPopulating;   //avoid firing events when populating UI
        private bool m_blnForceOwnerRefresh;

        public frmDepartment(ref DataLayer objDL)
        {
            InitializeComponent();
            m_DL = objDL;

            InitializeUI();
        }

        private void cboID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_blnPopulating)
            {
                return;
            }
            else
            {
                PopulateFields();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            PopulateFields();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }


        private void btnInsert_Click(object sender, EventArgs e)
        {
            Department objDepartment;

            if (ValidateFields())
            {
                //Determine if Department with provided ID already exists, if so overwrite...
                if (FindDepartment(cboID.Text, out objDepartment))
                {
                    if (UpdateDepartment(ref objDepartment))
                    {
                        MessageBox.Show(this, "Existing department updated.", "Existing Department Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        m_blnForceOwnerRefresh = true;
                    }
                }
                else
                {
                    //...Otherwise create a new Developer and add to DB
                    if (AddDepartment())
                    {
                        PopulateDepartmentIDComboList();
                        MessageBox.Show(this, "Department record added.", "Department Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        m_blnForceOwnerRefresh = true;
                    }
                }
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Department objDepartment;

            if (ValidateFields())
            {
                //Determine if department with provided ID already exists, if so overwrite...
                if (FindDepartment(cboID.Text, out objDepartment))
                {
                    if (UpdateDepartment(ref objDepartment))
                    {
                        MessageBox.Show(this, "Department record updated.", "Department Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        m_blnForceOwnerRefresh = true;
                    }
                }
                else
                {
                    MessageBox.Show(this, String.Format("An existing department record was not found for ID '{0}'", cboID.Text), "Department Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            Department objDepartment;

            //Get the department record for the currently entered ID and confirm delete
            if (GetCurrentDepartment(out objDepartment))
            {
                if (DialogResult.Yes == MessageBox.Show(this, String.Format("Are you sure you want to delete the Department record for ID '{0}'?", objDepartment.ID), "Delete Department?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2))
                {
                    if (DeleteDepartment(ref objDepartment))
                    {
                        PopulateDepartmentIDComboList();
                        ClearAllFields();

                        MessageBox.Show(this, String.Format("Department record deleted for ID '{0}'", objDepartment.ID), "Department Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        m_blnForceOwnerRefresh = true;
                    }
                }
            }
        }

        //------------------------------------------------------------------------------------
        //Procedure: ManageDepartments
        //Purpose:   Public method for displaying the dialog
        //Accepts:   NA
        //Returns:   NA
        public bool ManageDepartments()
        {
            m_blnForceOwnerRefresh = false;    
            this.ShowDialog();
            
            return m_blnForceOwnerRefresh;
        }

        //------------------------------------------------------------------------------------
        //Procedure: PopulateFields
        //Purpose:   Populates the fields using the currently selected ID
        //Accepts:   NA
        //Returns:   NA
        private void PopulateFields()
        {
            Department objDepartment;

            //Just get the record for the currently entered ID and display
            if (GetCurrentDepartment(out objDepartment))
            {
                DisplayDepartment(ref objDepartment);
            }
        }

        //------------------------------------------------------------------------------------
        //Procedure: GetCurrentDepartment
        //Purpose:   Gets the department record for the currently entered ID
        //           Used by Search functions.
        //Accepts:   ref Department objDepartment: Department object that was retrieved
        //Returns:   True if success, False if not
        private bool GetCurrentDepartment(out Department objDepartment)
        {
            if (ValidateID(cboID.Text))
            {
                if (FindDepartment(cboID.Text, out objDepartment))
                {
                    return true;
                }
                else
                {
                    MessageBox.Show(this, String.Format("An existing department record was not found for ID: {0}", cboID.Text), "Department Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else
            {
                objDepartment = null;
                return false;
            }
        }

        //------------------------------------------------------------------------------------
        //Procedure: FindDepartment
        //Purpose:   Provides functionality for retrieving a department record
        //           Used by Insert, Update, Delete and Search buttons.
        //Accepts:   string strID: ID of department record to find
        //           ref Department objDepartment: Department object that was found
        //Returns:   True if Department was retrieved, False if not
        private bool FindDepartment(string strID, out Department objDepartment)
        {
            Department objDept;
            int intID;

            intID = Int32.Parse(strID.Trim());

            objDept = new Department(ref m_DL);
            objDept.Populate(intID);

            if (!objDept.IsNew)
            {
                objDepartment = objDept;
                return true;
            }

            objDepartment = null;
            return false;
        }

        //------------------------------------------------------------------------------------
        //Procedure: AddDepartment
        //Purpose:   Provides functionality for adding a department record
        //           Used by Insert button.
        //Accepts:   NA
        //Returns:   True if success, false if not
        private bool AddDepartment()
        {
            bool blnResult = false;

            Department newDepartment = new Department(ref m_DL);

            newDepartment.ID = int.Parse(cboID.Text.Trim());
            newDepartment.Name = txtName.Text;

            //Write record to DB
            blnResult = newDepartment.Update();

            return blnResult;
        }

        //------------------------------------------------------------------------------------
        //Procedure: UpdateDepartment
        //Purpose:   Provides functionality for updating a department record
        //           Used by Insert and Update buttons.
        //Accepts:   ref Department objDepartment: Department record to update
        //Returns:   True if success, false if not
        private bool UpdateDepartment(ref Department objDepartment)
        {
            bool blnResult = false;

            objDepartment.Name = txtName.Text;

            //Write record to DB
            blnResult = objDepartment.Update();

            return blnResult;
        }
        
        //------------------------------------------------------------------------------------
        //Procedure: DeleteDepartment
        //Purpose:   Deletes a department record
        //           Used by Delete button.
        //Accepts:   ref Department objDeveloper: department record to delete
        //Returns:   True if success, false if not
        private bool DeleteDepartment(ref Department objDepartment)
        {
            bool blnResult = false;

            blnResult = objDepartment.Delete();

            return blnResult;
        }

        //------------------------------------------------------------------------------------
        //Procedure: ClearAllFields
        //Purpose:   Clears all fields on the dialog
        //           Used by Clear and Delete buttons.
        //Accepts:   NA
        //Returns:   NA
        private void ClearAllFields()
        {
            cboID.Text = "";
            txtName.Text = "";
        }

        //------------------------------------------------------------------------------------
        //Procedure: DisplayDepartment
        //Purpose:   Provides functionality for displaying a department record
        //           Used by Search, Next and Previous buttons.
        //Accepts:   ref Department objDepartment: department record to display
        //Returns:   NA
        private void DisplayDepartment(ref Department objDepartment)
        {
            cboID.Text = objDepartment.ID.ToString();
            txtName.Text = objDepartment.Name;
        }

        //------------------------------------------------------------------------------------
        //Procedure: ValidateFields
        //Purpose:   Provides some basic validation for required fields
        //           Used by Insert and Update buttons
        //Accepts:   NA
        //Returns:   True if all fields are valid, False if not
        private bool ValidateFields()
        {
            string strTemp;

            // Do some basic validation

            // ID
            if (!ValidateID(cboID.Text))
            {
                return false;
            }

            // Department Name
            strTemp = txtName.Text.Trim();

            if (strTemp.Length == 0)
            {
                MessageBox.Show(this, "You must enter a Name.", "Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // All fields should be valid, return success
            return true;
        }

        //------------------------------------------------------------------------------------
        //Procedure: ValidateID
        //Purpose:   Helper routine for ValidateFields() to validate the Department ID
        //           Used by Search and Delete buttons
        //Accepts:   string strID
        //Returns:   True if ID is valid, False if not
        private bool ValidateID(string strID)
        {
            int intTemp;

            strID = strID.Trim();

            if (strID.Length == 0)
            {
                MessageBox.Show(this, "You must enter a Department ID.", "Department ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!Int32.TryParse(strID, out intTemp))
            {
                MessageBox.Show(this, "You must enter an numeric value for Department ID.", "Department ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                if (intTemp <= 0)
                {
                    MessageBox.Show(this, "You must enter an numeric value greater than 0 for Department ID.", "Department ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }
        
        //------------------------------------------------------------------------------------
        //Procedure: InitializeUI
        //Purpose:   Initialize various interface components
        //Accepts:   NA
        //Returns:   NA
        private void InitializeUI()
        {
            PopulateDepartmentIDComboList();
        }

        //------------------------------------------------------------------------------------
        //Procedure: PopulateDepartmentIDComboList
        //Purpose:   Populates the department ID combo box from the DB
        //Accepts:   NA
        //Returns:   NA
        private void PopulateDepartmentIDComboList()
        {
            object[] aIDs;

            m_blnPopulating = true;

            cboID.Items.Clear();
            aIDs = m_DL.GetIDList(DataLayer.TblDepartment);

            if (aIDs != null)
            {
                cboID.Items.AddRange(aIDs);
            }

            m_blnPopulating = false;
        }
    }
}
