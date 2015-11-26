using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;


namespace TechSupportData
{
    public static class CustomerDB
    {
        //Table name constants
        public const string TblCustomers = "Customers";
        //private const string TblIncidents = "Incidents";

        //Field name constants
        public const string FldCustomerID = "CustomerID";
        public const string FldName = "Name";
        public const string FldAddress = "Address";
        public const string FldCity = "City";
        public const string FldState = "State";
        public const string FldZipCode = "ZipCode";
        public const string FldPhone = "Phone";
        public const string FldEmail = "Email";
        public const string FldTechID = "TechID";

        public static string GetCustomerName(int customerID)
        {
            DBManager DB = TechSupportDB.GetDBManager();
            SortedList slParams = new SortedList();
            string strResult;
            
            string strSelect = "SELECT " + FldName + " FROM " + TblCustomers + 
                               " WHERE " + FldCustomerID + "=@" + FldCustomerID;

            slParams.Add(FldCustomerID, customerID);

            strResult = (string)DB.GetScalar(strSelect, CommandType.Text, slParams);

            return strResult;
        }

        public static List<Customer> GetCustomerList()
        {
            DBManager DB = TechSupportDB.GetDBManager();            
            List<Customer> customerList = new List<Customer>();
            SqlDataReader dr;

            string strSelect = "SELECT " + FldCustomerID + ", " + FldName +
                               " FROM " + TblCustomers + " ORDER BY " + FldName;

            dr = DB.SelectDirect(strSelect, CommandType.Text);

            while(dr.Read())
            {
                Customer customer = new Customer();
                customer.CustomerID = (int)dr[FldCustomerID];
                customer.Name = dr[FldName].ToString();
                customerList.Add(customer); 
            }

            dr.Close();

            return customerList;
        }

    }
}
