using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TechSupportData
{
    public class Incident
    {
        private int incidentID;
        private int customerID;
        private string productCode;
        private int? techID;
        private DateTime dateOpened;
        private DateTime? dateClosed;
        private string title;
        private string description;
        
        public int IncidentID
        {
            get { return incidentID; }
            set { incidentID = value; }
        }

        public int CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }

        public string ProductCode
        {
            get { return productCode; }
            set { productCode = value; }
        }

        public int? TechID
        {
            get
            {
                if (techID.HasValue)
                {
                    return techID;
                }
                else
                {
                    return null;
                }
            }

            set { techID = value; }
        }

        public DateTime DateOpened
        {
            get { return dateOpened; }
            set { dateOpened = value; }
        }

        public DateTime? DateClosed
        {
            get { return dateClosed; }
            set { dateClosed = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string CustomerName
        {            
            get 
            { 
                string strResult = CustomerDB.GetCustomerName(this.CustomerID);
                return strResult;
            }            
        }

        public string TechnicianName
        {
            get
            {
                string strResult = "";
                int intParam;

                if (this.TechID != null)
                {
                    intParam = (int)this.TechID;
                    strResult = TechnicianDB.GetTechnicianName(intParam);
                }
                    
                return strResult;
            }            
        }

        public string ProductName
        {
            get
            {
                string strResult = "";

                strResult = ProductDB.GetProductName(this.ProductCode);
                return strResult;
            }
        }
    }
}
