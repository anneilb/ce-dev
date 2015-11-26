using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace TechSupportData
{
    public static class ProductDB
    {
        //Table name constants
        public const string TblProducts = "Products";
        //private const string TblRegistrations = "Registrations";

        //Field name constants
        public const string FldProductCode = "ProductCode";
        public const string FldName = "Name";
        public const string FldVersion = "Version";
        public const string FldReleaseDate = "ReleaseDate";
        public const string FldCustomerID = "CustomerID";

        public static List<Product> GetProductList()
        {
            DBManager DB = TechSupportDB.GetDBManager();
            List<Product> productList = new List<Product>();
            SqlDataReader dr;

            string strSelect = "SELECT " + FldProductCode + ", " + FldName +
                               " FROM " + TblProducts + " ORDER BY " + FldName;

            dr = DB.SelectDirect(strSelect, CommandType.Text);

            while (dr.Read())
            {
                Product product = new Product();
                product.ProductCode = dr[FldProductCode].ToString();
                product.Name = dr[FldName].ToString();
                productList.Add(product);
            }

            dr.Close();

            return productList;
        }

        public static string GetProductName(string productCode)
        {
            DBManager DB = TechSupportDB.GetDBManager();
            SortedList slParams = new SortedList();
            string strResult;

            string strSelect = "SELECT " + FldName + " FROM " + TblProducts +
                               " WHERE " + FldProductCode + "=@" + FldProductCode;

            slParams.Add(FldProductCode, productCode);

            strResult = (string)DB.GetScalar(strSelect, CommandType.Text, slParams);

            return strResult;
        }
    }
}
