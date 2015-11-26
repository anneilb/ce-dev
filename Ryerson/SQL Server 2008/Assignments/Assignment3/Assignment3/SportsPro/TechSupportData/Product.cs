using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TechSupportData
{
    public class Product
    {
        private string productCode;
        private string name;

        public string ProductCode
        {
            get { return productCode; }
            set { productCode = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}
