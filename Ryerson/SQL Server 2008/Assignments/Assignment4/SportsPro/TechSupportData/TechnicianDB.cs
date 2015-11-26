using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace TechSupportData
{
    public static class TechnicianDB
    {
        //Table name constants
        public const string TblTechnicians = "Technicians";

        //Field name constants
        public const string FldTechID = "TechID";
        public const string FldName = "Name";
        public const string FldEmail = "Email";
        public const string FldPhone = "Phone";

        public static string GetTechnicianName(int techID)
        {
            DBManager DB = TechSupportDB.GetDBManager();
            SortedList slParams = new SortedList();
            string strResult;

            string strSelect = "SELECT " + FldName + " FROM " + TblTechnicians +
                               " WHERE " + FldTechID + "=@" + FldTechID;

            slParams.Add(FldTechID, techID);

            strResult = (string)DB.GetScalar(strSelect, CommandType.Text, slParams);

            return strResult;
        }

        public static List<Technician> GetTechnicianList()
        {
            DBManager DB = TechSupportDB.GetDBManager();
            List<Technician> technicianList = new List<Technician>();
            SqlDataReader dr;

            string strSelect = "SELECT " + FldTechID + ", " + FldName +
                               " FROM " + TblTechnicians + " ORDER BY " + FldName;

            dr = DB.SelectDirect(strSelect, CommandType.Text);

            while (dr.Read())
            {
                Technician technician = new Technician();
                technician.TechID = (int)dr[FldTechID];
                technician.Name = dr[FldName].ToString();
                technicianList.Add(technician);
            }

            dr.Close();

            return technicianList;
        }

        public static Technician GetTechnician(int techID)
        {
            DBManager DB = TechSupportDB.GetDBManager();
            SortedList slParams = new SortedList();
            SqlDataReader dr;
            Technician technician = null;

            string strSelect = "SELECT " + FldTechID + ", " + FldName + ", "
                                         + FldEmail + ", " + FldPhone + 
                               " FROM " + TblTechnicians + 
                               " WHERE " + FldTechID + "=@" + FldTechID;

            slParams.Add(FldTechID, techID);

            dr = DB.SelectDirect(strSelect, CommandType.Text, slParams);

            if (dr.Read())
            {
                technician = new Technician();
                technician.TechID = (int)dr[FldTechID];
                technician.Name = dr[FldName].ToString();
                technician.Email = dr[FldEmail].ToString();
                technician.Phone = dr[FldPhone].ToString();
            }

            dr.Close();

            return technician;
        }
    }
}
