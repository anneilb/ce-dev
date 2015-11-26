using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DeveloperAppADO2
{
    public partial class frmDisplayAll : Form
    {
        private DataLayer m_DL;

        public frmDisplayAll(ref DataLayer objDL)
        {
            InitializeComponent();
            m_DL = objDL;
        }

        //------------------------------------------------------------------------------------
        //Procedure: DisplayAllDevelopers
        //Purpose:   Public interface method for display this dialog
        //Accepts:   NA
        //Returns:   True if success, false if not
        public bool DisplayAllDevelopers()
        {
            bool blnResult = false;

            if (BindDataToGrid())
            {
                blnResult = true;
                this.ShowDialog();
            }
            else
            {
                MessageBox.Show(this, "Error binding data to grid.","Display Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return blnResult;
        }

        //------------------------------------------------------------------------------------
        //Procedure: BindDataToGrid
        //Purpose:   Provides functionality for binding a dataset to the DataGrid control
        //Accepts:   NA
        //Returns:   True if success, false if not
        private bool BindDataToGrid()
        {
            DataSet dsDevs;
            DataSet dsDevDepts;
            bool blnResult = false;            
            
            //Get the developer details and department details view, and  
            //create relationship in order to display Master-detail view                        
            dsDevs = m_DL.GetDevelopers();
            dsDevDepts = m_DL.GetDeveloperDepartmentDetails();

            if(dsDevs.Tables.Count > 0)            
            {
                if(dsDevDepts.Tables.Count > 0)
                {
                    dsDevs.Tables.Add(dsDevDepts.Tables[DataLayer.TblVwDeveloperDepartmentDetails].Copy());
                }

                if (dsDevs.Tables.Count == 2)
                {
                    dsDevs.Relations.Add("Departments",dsDevs.Tables[DataLayer.TblDeveloper].Columns[DataLayer.FldID],
                                          dsDevs.Tables[DataLayer.TblVwDeveloperDepartmentDetails].Columns[DataLayer.FldDevDeptsDeveloperID]);                    
                    
                    grdDisplay.SetDataBinding(dsDevs,DataLayer.TblDeveloper);
                    blnResult = true;
                }
            }

            return blnResult;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
