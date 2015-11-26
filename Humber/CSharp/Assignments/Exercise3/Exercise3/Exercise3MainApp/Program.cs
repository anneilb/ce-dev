using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exercise3Lib;

namespace Exercise3MainApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Professor objProf = new Professor();

            System.Console.WriteLine("Input Semester Info");
            System.Console.WriteLine("Please enter the Empoyee ID:");
            objProf.EmpID = System.Console.ReadLine();
            System.Console.WriteLine("Please enter the First Name:");
            objProf.FirstName = System.Console.ReadLine();
            System.Console.WriteLine("Please enter the Last Name:");
            objProf.LastName = System.Console.ReadLine();
            System.Console.WriteLine("Please enter the Date of Birth (MM/dd/yyyy):");
            objProf.DateOfBirth = DateTime.ParseExact(System.Console.ReadLine(), "MM/dd/yyyy", null);
            System.Console.WriteLine("Please enter the Employee Status (True/False):");
            objProf.EmpStatus = Boolean.Parse(System.Console.ReadLine());
            System.Console.WriteLine("Please enter the Employee Department:");
            objProf.EmpDep = System.Console.ReadLine();
            System.Console.WriteLine("Please enter the Number of Courses:");
            objProf.NoOfCourses = Int32.Parse(System.Console.ReadLine());
            System.Console.WriteLine("Please enter the Number of Students:");
            objProf.NoOfStudents = Int32.Parse(System.Console.ReadLine());
            System.Console.WriteLine("Please enter the Semester:");
            objProf.Semester = System.Console.ReadLine();

            System.Console.WriteLine("\nOutput Semester Info" + objProf.SemesterInfo());
            System.Console.ReadKey();   

            //sResult = "\nID: " + this.EmpID;
            //sResult = sResult + "\nFull name: " + this.FirstName + " " + this.LastName;
            //sResult = sResult + "\nDate of birth: " + this.DateOfBirth;
            //sResult = sResult + "\nEmployee status: " + this.EmpStatus;
            //sResult = sResult + "\nDepartment: " + this.EmpDep;
            //sResult = sResult + "\nNumber of courses: " + this.NoOfCourses;
            //sResult = sResult + "\nNumber of students: " + this.NoOfStudents;
            //sResult = sResult + "\nSemester: " + this.Semester;

        }
    }
}
