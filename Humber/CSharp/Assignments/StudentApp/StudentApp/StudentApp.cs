
//----------------------------------------------------------------------------
// Title:       Assignment #1
// Course:      CPAN 702 - C# .net
// Professor:   Muthana Zouri
// Student:     Anneil Balkissoon
// Student #:   825-626-633
// ---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StudentApp
{
    static class StudentApp
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmStudent());
        }
    }

    //Class Student
    public class Student
    {
        private int intID;
        private string strName;
        private string strDepartment;
        private string strMajor;
        private int intSemester;

        public int ID
        {
            get
            { return intID; }
            set
            { intID = value; }
        }

        public int Semester
        {
            get
            { return intSemester; }
            set
            { intSemester = value; }
        }

        public string Name
        {
            get
            { return strName; }
            set
            { strName = value; }
        }

        public string Department
        {
            get
            { return strDepartment; }
            set
            { strDepartment = value; }
        }

        public string Major
        {
            get
            { return strMajor; }
            set
            { strMajor = value; }
        }

        public override string ToString()
        {
            string strTemp;

            strTemp = String.Format("{0}\t{1}\t{2}\t{3}\t{4}", this.ID, this.Name, this.Department, this.Major, this.Semester);

            return strTemp;
        }
        
    }
}
