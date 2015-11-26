using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise3Lib
{

    public interface IGeneric
    {
        string SemesterInfo();

    }

    public class Employee
    {
        private string sEmpID;
        private string sFirstName;
        private string sLastName;
        private DateTime dDateOfBirth;
        private Boolean bEmpStatus;
        private string sEmpDep;

        public string EmpID
        {
            get
            {
                return sEmpID;
            }
            set
            {
                sEmpID = value;
            }
        }

        public string FirstName
        {
            get
            {
                return sFirstName;
            }
            set
            {
                sFirstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return sLastName;
            }
            set
            {
                sLastName = value;
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return dDateOfBirth;
            }
            set
            {
                dDateOfBirth = value;
            }
        }

        public Boolean EmpStatus
        {
            get
            {
                return bEmpStatus;
            }
            set
            {
                bEmpStatus = value;
            }
        }

        public string EmpDep
        {
            get
            {
                return sEmpDep;
            }
            set
            {
                sEmpDep = value;
            }
        }

        public virtual string SemesterInfo()
        {
            return "";
        }
    }

    public sealed class Professor : Employee, IGeneric
    {
        private int iNoOfCourses;
        private int iNoOfStudents;
        private string sSemester;

        public int NoOfCourses
        {
            get
            {
                return iNoOfCourses;
            }
            set
            {
                iNoOfCourses = value;
            }
        }

        public int NoOfStudents
        {
            get
            {
                return iNoOfStudents;
            }
            set
            {
                iNoOfStudents = value;
            }
        }

        public string Semester
        {
            get
            {
                return sSemester;
            }
            set
            {
                sSemester = value;
            }
        }

        public override string SemesterInfo()
        {
            string sResult;

            sResult = "\nID: " + this.EmpID;
            sResult = sResult + "\nFull name: " + this.FirstName + " " + this.LastName;
            sResult = sResult + "\nDate of birth: " + this.DateOfBirth.ToString("MM/dd/yyyy", null);
            sResult = sResult + "\nEmployee status: " + this.EmpStatus;
            sResult = sResult + "\nDepartment: " + this.EmpDep;
            sResult = sResult + "\nNumber of courses: " + this.NoOfCourses;
            sResult = sResult + "\nNumber of students: " + this.NoOfStudents;
            sResult = sResult + "\nSemester: " + this.Semester;

            return sResult;
        }

    }

}
