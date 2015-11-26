using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TechSupportData
{
    public class Customer
    {
        private int customerID;
        private string name;

        public int CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}
