
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DeveloperAppADO
{
    public partial class frmDeveloper : Form
    {
        private DataLayer m_DL;
        private bool m_blnPopulating;   //avoid firing events when populating UI


        public frmDeveloper()
        {         
            InitializeComponent();
            m_DL = new DataLayer();

            InitializeUI();
        }


        //~frmDeveloper()
        //{
        //}


        private void cboID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_blnPopulating)
            {
                return;
            }
            else
            {
                PopulateDeveloperFields();
            }            
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            PopulateDeveloperFields();
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            m_DL = null;
            Application.Exit();
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }


        private void btnInsert_Click(object sender, EventArgs e)
        {
            Developer objDeveloper;

            if (ValidateFields())
            {
                //Determine if Developer with provided ID already exists, if so overwrite...
                if (FindDeveloper(cboID.Text, out objDeveloper))
                {
                    if (UpdateDeveloper(ref objDeveloper))
                    {
                        MessageBox.Show(this, "Existing developer updated.", "Existing Developer Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    //...Otherwise create a new Developer and add to DB
                    if (AddDeveloper())
                    {
                        PopulateDeveloperIDComboList();
                        MessageBox.Show(this, "Developer record added.", "Developer Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Developer objDeveloper;

            if (ValidateFields())
            {
                //Determine if developer with provided ID already exists, if so overwrite...
                if (FindDeveloper(cboID.Text, out objDeveloper))
                {
                    if (UpdateDeveloper(ref objDeveloper))
                    {
                        MessageBox.Show(this, "Developer record updated.", "Developer Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(this, String.Format("An existing developer record was not found for ID '{0}'", cboID.Text), "Developer Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            Developer objDeveloper;

            //Get the developer record for the currently entered ID and confirm delete
            if (GetCurrentDeveloper(out objDeveloper))
            {
                if (DialogResult.Yes == MessageBox.Show(this, String.Format("Are you sure you want to delete the Developer record for ID '{0}'?", objDeveloper.ID), "Delete Developer?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2))
                {
                    if (DeleteDeveloper(ref objDeveloper))
                    {
                        PopulateDeveloperIDComboList();
                        ClearAllFields();

                        MessageBox.Show(this, String.Format("Developer record deleted for ID '{0}'", objDeveloper.ID), "Developer Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }  

        //------------------------------------------------------------------------------------
        //Procedure: InitializeUI
        //Purpose:   Initialize various interface components
        //Accepts:   NA
        //Returns:   NA
        private void InitializeUI()
        {
            PopulateDeveloperIDComboList();
            PopulateDepartmentList();
        }

        //------------------------------------------------------------------------------------
        //Procedure: PopulateDeveloperIDComboList
        //Purpose:   Populates the dveloper ID combo box from the DB
        //Accepts:   NA
        //Returns:   NA
        private void PopulateDeveloperIDComboList()
        {
            object[] aIDs;
            
            m_blnPopulating = true;

            cboID.Items.Clear();
            aIDs = m_DL.GetIDList(DataLayer.TblDeveloper);

            if (aIDs != null)
            {
                cboID.Items.AddRange(aIDs);
            }

            m_blnPopulating = false;
        }

        //------------------------------------------------------------------------------------
        //Procedure: PopulateDepartmentList
        //Purpose:   Populates the departments list from the DB
        //Accepts:   NA
        //Returns:   NA
        private void PopulateDepartmentList()
        {
            DataSet ds;
            DataRow[] aDr;
            int intCount = 0;
            ListViewItem lstItem;

            lstDepartment.Items.Clear();
            ds = m_DL.GetDepartments();

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[DataLayer.TblDepartment].Rows.Count > 0)
                {
                    intCount = ds.Tables[DataLayer.TblDepartment].Rows.Count;
                    aDr = ds.Tables[DataLayer.TblDepartment].Select();

                    for (int x = 0; x < intCount; x++)
                    {
                        lstItem = lstDepartment.Items.Add(new ListViewItem());
                        lstItem.SubItems.Add(aDr[x][DataLayer.FldID].ToString());
                        lstItem.SubItems.Add(aDr[x][DataLayer.FldDepartmentName].ToString());
                        lstItem.Tag = aDr[x][DataLayer.FldID].ToString();
                    }
                }
            }
        }

        //------------------------------------------------------------------------------------
        //Procedure: PopulateDeveloperFields
        //Purpose:   Populates the developer fields using the currently selected ID
        //Accepts:   NA
        //Returns:   NA
        private void PopulateDeveloperFields()
        {
            Developer objDeveloper;

            //Just get the developer record for the currently entered ID and display
            if(GetCurrentDeveloper(out objDeveloper))
            {
                DisplayDeveloper(ref objDeveloper);
            }
        }

        //------------------------------------------------------------------------------------
        //Procedure: GetCurrentDeveloper
        //Purpose:   Gets the developer record for the currently entered ID
        //           Used by Search functions.
        //Accepts:   ref Developer objDeveloper: Developer object that was retrieved
        //Returns:   True if success, False if not
        private bool GetCurrentDeveloper(out Developer objDeveloper)
        {
            if (ValidateID(cboID.Text))
            {
                if (FindDeveloper(cboID.Text, out objDeveloper))
                {
                    return true;
                }
                else
                {
                    MessageBox.Show(this, String.Format("An existing developer record was not found for ID: {0}", cboID.Text), "Developer Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else
            {
                objDeveloper = null;
                return false;
            }
        }
        
        //------------------------------------------------------------------------------------
        //Procedure: FindDeveloper
        //Purpose:   Provides functionality for retrieving a developer record
        //           Used by Insert, Update, Delete and Search buttons.
        //Accepts:   string strID: ID of developer record to find
        //           ref Developer objDeveloper: Developer object that was found
        //Returns:   True if Developer was retrieved, False if not
        private bool FindDeveloper(string strID, out Developer objDeveloper)
        {
            Developer objDev;
            int intID;

            intID = Int32.Parse(strID.Trim());

            objDev = new Developer(ref m_DL);
            objDev.Populate(intID);

            if (!objDev.IsNew)
            {
                objDeveloper = objDev;
                return true;
            }

            objDeveloper = null;
            return false;
        }

        //------------------------------------------------------------------------------------
        //Procedure: AddDeveloper
        //Purpose:   Provides functionality for adding a developer record
        //           Used by Insert button.
        //Accepts:   NA
        //Returns:   True if success, false if not
        private bool AddDeveloper()
        {
            bool blnResult = false;

            Developer newDeveloper = new Developer(ref m_DL);

            newDeveloper.ID = int.Parse(cboID.Text.Trim());
            newDeveloper.Name = txtName.Text;
            newDeveloper.Salary = double.Parse(txtSalary.Text.Trim());

            //Set departments
            SetDeveloperDepartments(ref newDeveloper);

            //Write record to DB
            blnResult = newDeveloper.Update();

            return blnResult;
        }
        
        //------------------------------------------------------------------------------------
        //Procedure: UpdateDeveloper
        //Purpose:   Provides functionality for updating a developer record
        //           Used by Insert and Update buttons.
        //Accepts:   ref Developer objDeveloper: Developer record to update
        //Returns:   True if success, false if not
        private bool UpdateDeveloper(ref Developer objDeveloper)
        {
            bool blnResult = false;

            objDeveloper.Name = txtName.Text;
            objDeveloper.Salary = double.Parse(txtSalary.Text.Trim());

            //Set departments
            SetDeveloperDepartments(ref objDeveloper);

            //Write record to DB
            blnResult = objDeveloper.Update();

            return blnResult;
        }

        //------------------------------------------------------------------------------------
        //Procedure: SetDeveloperDepartments
        //Purpose:   Provides functionality for setting departments on a developer object
        //           Used by AddDeveloper and UpdateDeveloper.
        //Accepts:   ref Developer objDeveloper: Developer record to set departments on
        //Returns:   NA
        private void SetDeveloperDepartments(ref Developer objDeveloper)
        {
            IEnumerator objEItem;
            ListViewItem lstItem;

            objEItem = lstDepartment.Items.GetEnumerator();

            //Add or Remove department records based on checkbox value
            while (objEItem.MoveNext())
            {
                lstItem = (ListViewItem)objEItem.Current;

                if (lstItem.Checked)
                {
                    objDeveloper.AddDepartment(int.Parse(lstItem.Tag.ToString()));
                }
                else
                {
                    objDeveloper.RemoveDepartment(int.Parse(lstItem.Tag.ToString()));
                }
            }
        }

        //------------------------------------------------------------------------------------
        //Procedure: DeleteDeveloper
        //Purpose:   Deletes a developer record
        //           Used by Delete button.
        //Accepts:   ref Developer objDeveloper: developer record to delete
        //Returns:   True if success, false if not
        private bool DeleteDeveloper(ref Developer objDeveloper)
        {
            bool blnResult = false;

            blnResult = objDeveloper.Delete();

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
            txtSalary.Text = "";

            //Clear selected Departments
            DeselectAllDepartments();
        }

        //------------------------------------------------------------------------------------
        //Procedure: DeselectAllDepartments
        //Purpose:   Provides functionality for deselecting all departments in list
        //Accepts:   NA
        //Returns:   NA
        private void DeselectAllDepartments()
        {
            IEnumerator objEItem;
            ListViewItem lstItem;

            objEItem = lstDepartment.Items.GetEnumerator();

            //Display selected department records
            while (objEItem.MoveNext())
            {
                lstItem = (ListViewItem)objEItem.Current;
                lstItem.Checked = false;
            }
        }

        //------------------------------------------------------------------------------------
        //Procedure: DisplayDeveloper
        //Purpose:   Provides functionality for displaying a developer record
        //           Used by Search, Next and Previous buttons.
        //Accepts:   ref Developer objDeveloper: developer record to display
        //Returns:   NA
        private void DisplayDeveloper(ref Developer objDeveloper)
        {
            cboID.Text = objDeveloper.ID.ToString();
            txtName.Text = objDeveloper.Name;
            txtSalary.Text = objDeveloper.Salary.ToString();

            //Display developer departments
            DisplayDeveloperDepartments(ref objDeveloper);
        }

        //------------------------------------------------------------------------------------
        //Procedure: DisplayDeveloperDepartments
        //Purpose:   Provides functionality for displaying a developers selected departments
        //           Used by DisplayDeveloper
        //Accepts:   ref Developer objDeveloper: developer record to display departments for
        //Returns:   NA
        private void DisplayDeveloperDepartments(ref Developer objDeveloper)
        {
            IEnumerator objEItem;
            ListViewItem lstItem;

            objEItem = lstDepartment.Items.GetEnumerator();

            //Display selected department records
            while (objEItem.MoveNext())
            {
                lstItem = (ListViewItem)objEItem.Current;
                lstItem.Checked = objDeveloper.Departments.ContainsKey(int.Parse(lstItem.Tag.ToString()));
            }
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
            double dblTemp;

            // Do some basic validation

            // Student ID
            if (!ValidateID(cboID.Text))
            {
                return false;
            }

            // Developer Name
            strTemp = txtName.Text.Trim();

            if (strTemp.Length == 0)
            {
                MessageBox.Show(this, "You must enter a Name.", "Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Developer Salary
            dblTemp = 0;
            strTemp = txtSalary.Text.Trim();

            if (strTemp.Length == 0)
            {
                MessageBox.Show(this, "You must enter a Salary.", "Salary", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!Double.TryParse(strTemp, out dblTemp))
            {
                MessageBox.Show(this, "You must enter an numeric value for Salary.", "Salary", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // All fields should be valid, return success
            return true;
        }

        //------------------------------------------------------------------------------------
        //Procedure: ValidateID
        //Purpose:   Helper routine for ValidateFields() to validate the Developer ID
        //           Used by Search and Delete buttons
        //Accepts:   string strID
        //Returns:   True if ID is valid, False if not
        private bool ValidateID(string strID)
        {
            int intTemp;

            strID = strID.Trim();

            if (strID.Length == 0)
            {
                MessageBox.Show(this, "You must enter a Developer ID.", "Developer ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!Int32.TryParse(strID, out intTemp))
            {
                MessageBox.Show(this, "You must enter an numeric value for Developer ID.", "Developer ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                if (intTemp <= 0)
                {
                    MessageBox.Show(this, "You must enter an numeric value greater than 0 for Developer ID.", "Developer ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        private void btnManageDepartments_Click(object sender, EventArgs e)
        {
            frmDepartment fmiDepartment;

            fmiDepartment = new frmDepartment(ref m_DL);
            
            if (fmiDepartment.ManageDepartments())
            {
                //Refresh departments list
                PopulateDepartmentList();

                //We must re-display developer's deparments as the selected items will be lost after a refresh
                if (cboID.Text.Length > 0)
                {
                    //Try to repopulate the information of the currently selected developer
                    PopulateDeveloperFields();
                }
            }
        }

    }
}
