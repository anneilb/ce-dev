using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace DeveloperApp
{

    interface IMyInterface
    {
        string EmpInfo();
    }

    enum TAX: uint 
    {
        PT = 20,
        FP = 30
    }

    class Employee: IMyInterface  
    {
        protected int empID;
        protected string empName;
        protected double empGrossSalary;
        protected bool empStatusFullTime;

        public int ID
        {
            get { return empID; }
            set { empID = value; }
        }

        public string Name
        {
            get { return empName; }
            set { empName = value; }
        }

        public double GrossSalary
        {
            get { return empGrossSalary; }
            set { empGrossSalary = value; }
        }

        public bool StatusFullTime
        {
            get { return empStatusFullTime; }
            set { empStatusFullTime = value; }
        }

        public virtual string EmpInfo()
        {
            string strResult = "";
            double dblTax = 0;
            double dblNetSalary = 0;


            //Output basic details
            strResult = "\nDeveloper Details:";

            strResult = strResult + 
                        "\n\nID: " + this.ID +
                        "\nFull Name: " + this.Name +
                        "\nStatus: ";

            //figure out status string
            if (this.StatusFullTime)
            {
                strResult = strResult + "Full Time";
            }
            else
            {
                strResult = strResult + "Part Time";
            }            

            //figure out net salary
            if(this.StatusFullTime)
            {
                dblTax = ((double)TAX.FP * 0.01) * this.GrossSalary;
                dblNetSalary = this.GrossSalary - dblTax;
            }
            else
            {
                dblTax = ((double)TAX.PT * 0.01) * this.GrossSalary;
                dblNetSalary = this.GrossSalary - dblTax;
            }

            strResult = strResult + "\nNet Salary: " + dblNetSalary;

            return strResult;
 
        }

    }

    class Project
    {
        private int projectID;
        private string projectName;
        private DateTime projectDueDate;


        public int ID
        {
            get{return projectID;} 
            set{projectID = value;}
        }

        public string Name
        {
            get{return projectName;} 
            set{projectName = value;}
        }

        public DateTime DueDate
        {
            get{return projectDueDate;} 
            set{projectDueDate = value;}
        }

        public override string ToString()
        {
            string strResult = "";

            strResult = "\nID: " + this.ID +
                        "\nName: " + this.Name +
                        "\nDueDate: " + this.DueDate.ToString("MM/dd/yyyy", null);

            return strResult;
        }

    }

    sealed class Developer : Employee
    {
        private Project[] currentProject;

        public Project[] CurrentProjects
        {
            get { return currentProject; }
            set { currentProject = value; }
        }

        public override string EmpInfo()
        {
            string strResult = "";
                        
            //Get the Developer info from the base class
            strResult = base.EmpInfo();
            
            //Append the number of projects
            strResult = strResult + "\nNumber of Projects: " + this.CurrentProjects.Length;

            //Append the project details
            strResult = strResult + "\n\nProject Details: ";
            
            foreach (Project pr in this.CurrentProjects)
            {
                strResult = strResult + "\n" + pr.ToString(); 
            }

            return strResult;
        }

    }
     
   
    class Program
    {
        static SortedList slDevelopers;  

        static void Main(string[] args)
        {
            bool blnResult = true;

            slDevelopers = new SortedList();
            
            while(blnResult)
            {
                DisplayMenu();
                blnResult = Select();
            }

            System.Console.WriteLine("\nProgram terminated.");
            System.Console.ReadLine(); 

        }

        static void DisplayMenu()
        {
            string strMenu = "";
            
            strMenu = "\nDeveloper App" +
                      "\n\n1. Enter the developer information" +
                      "\n2. View a specific developer’s information" +
                      "\n3. View all developers’ information" +
                      "\n4. Quit" +
                      "\n\nPlease make your selection: ";

            System.Console.Clear();
            System.Console.WriteLine(strMenu);
        }

        static bool Select()
        {
            string strInput = "";
            int intInput = 0;
            bool blnResult = false;

            strInput = Console.ReadLine();

            if (Int32.TryParse(strInput, out intInput) == false)
            {
                System.Console.WriteLine("\nInvalid input. Please try again.");
                return true;
            }

            switch (intInput)
            {

                case 1:

                    InputDeveloper();
                    blnResult = true;
                    break;

                case 2:
                    
                    ViewDeveloper();
                    blnResult = true;
                    break;

                case 3:

                    ViewAllDevelopers();
                    blnResult = true;
                    break;

                case 4:
                    
                    //Quit
                    blnResult = false;
                    break;

                default:
                    
                    System.Console.WriteLine("\nInvalid input. Please try again.");
                    System.Console.ReadLine();
                    blnResult = true;
                    break;

            }

            return blnResult;

        }

        static void InputDeveloper()
        {
            Developer objDev = new Developer();
            int intNumProjects = 0;            
                        
            System.Console.Clear();
            System.Console.WriteLine("Input Developer");
            System.Console.WriteLine("\nID (numeric):");
            objDev.ID = Int32.Parse(System.Console.ReadLine());
            System.Console.WriteLine("Name:");
            objDev.Name = System.Console.ReadLine();
            System.Console.WriteLine("Gross Salary (numeric):");
            objDev.GrossSalary = double.Parse(System.Console.ReadLine());
            System.Console.WriteLine("Status (Full Time=True, Part Time=False):");
            objDev.StatusFullTime = bool.Parse(System.Console.ReadLine());
            System.Console.WriteLine("Number of Projects (numeric):");
            intNumProjects = Int32.Parse(System.Console.ReadLine());
            objDev.CurrentProjects = new Project[intNumProjects];           
            
            //Initialize projects
            System.Console.WriteLine("\nInput Projects:");

            for (int x = 0; x < intNumProjects; x++)
            {
                objDev.CurrentProjects[x] = new Project();
                System.Console.WriteLine("\nID (numeric):");
                objDev.CurrentProjects[x].ID = Int32.Parse(System.Console.ReadLine());
                System.Console.WriteLine("Name:");
                objDev.CurrentProjects[x].Name = System.Console.ReadLine();
                System.Console.WriteLine("Due Date (MM/dd/yyyy):");
                objDev.CurrentProjects[x].DueDate = DateTime.ParseExact(System.Console.ReadLine(), "MM/dd/yyyy", null);
            }

            //Finally add the developer object to the collection
            slDevelopers.Add(objDev.ID, objDev);
                      
        }

        static void ViewDeveloper()
        {
            int intID = 0;
            Developer objDev;

            System.Console.Clear();
            System.Console.WriteLine("View Developer");
            System.Console.WriteLine("\nEnter ID (numeric):");
            intID = Int32.Parse(System.Console.ReadLine());

            //Check if collection contains key, if so get Developer object and display it
            if (slDevelopers.ContainsKey(intID))
            {
                objDev = (Developer)slDevelopers[intID];
                System.Console.Write(objDev.EmpInfo());
                System.Console.ReadLine();
            }
            else
            {
                System.Console.WriteLine("A developer for that ID does not exist.");
                System.Console.ReadLine();
            }
                        
        }

        static void ViewAllDevelopers()
        {

            IDictionaryEnumerator objDEItem;
            Developer objDev;
            string strResult = "";

            objDEItem = slDevelopers.GetEnumerator();

            while (objDEItem.MoveNext())
            {
                objDev = (Developer)objDEItem.Value;
                strResult = strResult + "\n" + objDev.EmpInfo();
            }

            System.Console.Clear();
            System.Console.WriteLine("View All Developers");
            System.Console.Write(strResult);

            System.Console.ReadLine();

        }

    }
}
