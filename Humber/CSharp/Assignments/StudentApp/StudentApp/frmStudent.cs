
//----------------------------------------------------------------------------
// Title:       Assignment #1
// Course:      CPAN 702 - C# .net
// Professor:   Muthana Zouri
// Student:     Anneil Balkissoon
// Student #:   825-626-633
// ---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace StudentApp
{
    public partial class frmStudent : Form
    {
        ArrayList aStudents;

        public frmStudent()
        {
            InitializeComponent();
            aStudents = new ArrayList(); 
        }

        private void frmStudent_Load(object sender, EventArgs e)
        {
            //
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            aStudents = null; 
            Application.Exit();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

            ClearAllFields();

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {

            Student objStudent;

            if (ValidateFields() == true)
            {
                //Determine if student with provided ID already exists, if so overwrite...
                if (FindStudent(txtStudentID.Text, out objStudent) == true)
                {                    
                    UpdateStudent(ref objStudent);

                    MessageBox.Show(this, "Existing student record updated.", "Existing Student Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //...Otherwise create a new student and add to array
                    AddStudent();

                    MessageBox.Show(this, "Student record added.", "Student Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            Student objStudent;

            if (ValidateFields() == true)
            {
                //Determine if student with provided ID already exists, if so overwrite...
                if (FindStudent(txtStudentID.Text, out objStudent) == true)
                {
                    UpdateStudent(ref objStudent);

                    MessageBox.Show(this, "Student record updated.", "Student Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show(this, String.Format("An existing student record was not found for ID '{0}'", txtStudentID.Text), "Student Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            Student objStudent;

            //Get the student record for the currently entered ID and confirm delete
            if (GetCurrentStudent(out objStudent))
            {
                if (DialogResult.Yes == MessageBox.Show(this, String.Format("Are you sure you want to delete the student record for ID '{0}'?", objStudent.ID), "Delete Student?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2))
                {
                    DeleteStudent(ref objStudent);
                    ClearAllFields();

                }
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            Student objStudent;

            //Just get the student record for the currently entered ID and display
            if (GetCurrentStudent(out objStudent))
            {
                DisplayStudent(ref objStudent);
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            Student objStudent;
            Student nextStudent;
            int intNextIndex;

            if (GetCurrentStudent(out objStudent))
            {
                intNextIndex = aStudents.IndexOf(objStudent);
                intNextIndex++;

                //Check if index is past EOF
                if (intNextIndex > (aStudents.Count - 1))
                {
                    //just display the current record
                    DisplayStudent(ref objStudent);
                    MessageBox.Show(this, "The end of the file has been reached.", "EOF Reached", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    //Display the next record
                    nextStudent = new Student();
                    nextStudent = (Student)aStudents[intNextIndex];
                    DisplayStudent(ref nextStudent);
                }
            }

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            
            Student objStudent;
            Student previousStudent;
            int intPreviousIndex;

            if (GetCurrentStudent(out objStudent))
            {
                intPreviousIndex = aStudents.IndexOf(objStudent);
                intPreviousIndex--;

                //Check if index is before BOF
                if (intPreviousIndex < 0)
                {
                    //just display the current record
                    DisplayStudent(ref objStudent);
                    MessageBox.Show(this, "The beginning of the file has been reached.", "BOF Reached", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    //Display the previous record
                    previousStudent = new Student();
                    previousStudent = (Student)aStudents[intPreviousIndex];
                    DisplayStudent(ref previousStudent);
                }
            }

        }

        private void btnDisplayAllRecords_Click(object sender, EventArgs e)
        {

            if (aStudents.Count > 0)
            {
                MessageBox.Show(this, DisplayAllRecords(), "Display All Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(this, "No records to display", "No Records", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }        

        //------------------------------------------------------------------------------------
        //Procedure: ValidateFields
        //Purpose:   Provides some basic validation for required fields
        //           Used by Insert and Update buttons
        //Accepts:   NA
        //Returns:   True if all fields are valid, False if not
        private Boolean ValidateFields()
        {
            string strTemp;
            int intTemp;

            // Do some basic validation

            // Student ID
            if (ValidateID(txtStudentID.Text) == false)
            {
                return false;
            }

            // Student Name
            strTemp = txtStudentName.Text.Trim();

            if (strTemp.Length == 0)
            {
                MessageBox.Show(this, "You must enter a Name.", "Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //Student Department
            strTemp = txtDepartment.Text.Trim();

            if (strTemp.Length == 0)
            {
                MessageBox.Show(this, "You must enter a Department.", "Department", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //Student Major
            strTemp = txtMajor.Text.Trim();

            if (strTemp.Length == 0)
            {
                MessageBox.Show(this, "You must enter a Major.", "Major", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Student Semester
            intTemp = 0;
            strTemp = txtSemester.Text.Trim();

            if (strTemp.Length == 0)
            {
                MessageBox.Show(this, "You must enter a Semester.", "Semester", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (Int32.TryParse(strTemp, out intTemp) == false)
            {
                MessageBox.Show(this, "You must enter an numeric value for Semester.", "Semester", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                if ((intTemp <= 0) || (intTemp > 4))
                {
                    MessageBox.Show(this, "You must enter 1 through 4 for Semester.", "Semester", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            // All fields should be valid, return success
            return true;
        }

        //------------------------------------------------------------------------------------
        //Procedure: ValidateID
        //Purpose:   Helper routine for ValidateFields() to validate the student ID
        //           Used by Search, Delete, Next and Previous buttons
        //Accepts:   string strID
        //Returns:   True if ID is valid, False if not
        private Boolean ValidateID(string strID)
        {

            int intTemp;

            strID = strID.Trim();

            if (strID.Length == 0)
            {
                MessageBox.Show(this, "You must enter an ID.", "ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (Int32.TryParse(strID, out intTemp) == false)
            {
                MessageBox.Show(this, "You must enter an numeric value for ID.", "ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                if (intTemp <= 0)
                {
                    MessageBox.Show(this, "You must enter an numeric value greater than 0 for ID.", "ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;

        }

        //------------------------------------------------------------------------------------
        //Procedure: FindStudent
        //Purpose:   Provides core functionality for finding a student record
        //           Used by Insert, Update, Delete and Search buttons.
        //Accepts:   string strID: ID of student record to find
        //           out Student objStudent: Student object that was found
        //Returns:   True if Student was found, False if not
        private Boolean FindStudent(string strID, out Student objStudent)
        {

            int intID;

            intID = Int32.Parse(strID.Trim());

            foreach (Student s in aStudents)
            {
                if (s.ID == intID)
                {
                    objStudent = s;
                    return true; 
                }
            }

            objStudent = null;
            return false;

        }

        //------------------------------------------------------------------------------------
        //Procedure: GetCurrentStudent
        //Purpose:   Gets the student record for the currently entered ID
        //           Used by Search, Next and Previous buttons.
        //Accepts:   out Student objStudent: Student object that was found
        //Returns:   True if success, False if not
        private Boolean GetCurrentStudent(out Student objStudent)
        {

            if (ValidateID(txtStudentID.Text) == true)
            {
                if (FindStudent(txtStudentID.Text, out objStudent) == true)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show(this, String.Format("An existing student record was not found for ID: {0}", txtStudentID.Text),"Student Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else
            {
                objStudent = null;
                return false; 
            }
        }

        //------------------------------------------------------------------------------------
        //Procedure: AddStudent
        //Purpose:   Provides core functionality for adding a student record
        //           Used by Insert button.
        //Accepts:   NA
        //Returns:   NA
        private void AddStudent()
        {

            Student newStudent = new Student();

            newStudent.ID = Int32.Parse(txtStudentID.Text.Trim());
            newStudent.Name = txtStudentName.Text;
            newStudent.Department = txtDepartment.Text;
            newStudent.Major = txtMajor.Text;
            newStudent.Semester = Int32.Parse(txtSemester.Text.Trim());

            aStudents.Add(newStudent);

        }

        //------------------------------------------------------------------------------------
        //Procedure: UpdateStudent
        //Purpose:   Provides core functionality for updating a student record
        //           Used by Insert and Update buttons.
        //Accepts:   ref Student objStudent: student record to update
        //Returns:   NA
        private void UpdateStudent(ref Student objStudent)
        {

            objStudent.Name = txtStudentName.Text;
            objStudent.Department = txtDepartment.Text;
            objStudent.Major = txtMajor.Text;
            objStudent.Semester = Int32.Parse(txtSemester.Text.Trim());

        }

        //------------------------------------------------------------------------------------
        //Procedure: DeleteStudent
        //Purpose:   Deletes a student record
        //           Used by Delete button.
        //Accepts:   ref Student objStudent: student record to delete
        //Returns:   NA
        private void DeleteStudent(ref Student objStudent)
        {

            aStudents.Remove(objStudent);
            
        }

        //------------------------------------------------------------------------------------
        //Procedure: ClearAllFields
        //Purpose:   Clears all fields on the dialog
        //           Used by Clear and Delete buttons.
        //Accepts:   NA
        //Returns:   NA
        private void ClearAllFields()
        {

            txtStudentID.Text = "";
            txtStudentName.Text = "";
            txtDepartment.Text = "";
            txtMajor.Text = "";
            txtSemester.Text = "";  

        }

        //------------------------------------------------------------------------------------
        //Procedure: DisplayStudent
        //Purpose:   Provides core functionality for displaying a student record
        //           Used by Search, Next and Previous buttons.
        //Accepts:   ref Student objStudent: student record to update
        //Returns:   NA
        private void DisplayStudent(ref Student objStudent)
        {

            txtStudentID.Text = objStudent.ID.ToString(); 
            txtStudentName.Text = objStudent.Name;
            txtDepartment.Text = objStudent.Department;
            txtMajor.Text = objStudent.Major;
            txtSemester.Text = objStudent.Semester.ToString();

        }

        //------------------------------------------------------------------------------------
        //Procedure: DisplayAllRecords
        //Purpose:   Displays all student records in a message box
        //           Used by Display All Records button.
        //Accepts:   NA
        //Returns:   NA
        private string DisplayAllRecords()
        {

            string strTemp;

            strTemp = "ID\tName\tDepartment\tMajor\tSemester";
            strTemp = strTemp + "\n-------------------------------------------------------------------------";

            foreach (Student s in aStudents)
            {
                strTemp = strTemp + "\n" + s.ToString();
            }

            return strTemp;

        }

    }
}
