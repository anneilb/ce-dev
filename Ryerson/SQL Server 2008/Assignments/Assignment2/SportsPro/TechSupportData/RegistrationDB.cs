using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace TechSupportData
{
    public static class RegistrationDB
    {
        //Table name constants
        public const string TblRegistrations = "Registrations";

        //Field name constants
        public const string FldCustomerID = "CustomerID";
        public const string FldProductCode = "ProductCode";
        public const string FldRegistrationDate = "RegistrationDate";

        public static bool ProductRegistered(int customerID, string productCode)
        {
            DBManager DB = TechSupportDB.GetDBManager();
            SortedList slParams = new SortedList();
            bool blnResult;

            string strSelect = "SELECT COUNT(*) FROM " + TblRegistrations +
                               " WHERE " + FldCustomerID + "=@" + FldCustomerID + 
                               " AND " + FldProductCode + "=@" + FldProductCode;

            slParams.Add(FldCustomerID, customerID);
            slParams.Add(FldProductCode, productCode);

            blnResult = ((int)DB.GetScalar(strSelect, CommandType.Text, slParams) > 0);

            return blnResult;
        }
    }
}
