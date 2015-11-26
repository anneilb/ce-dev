using System;
using System.Collections.Generic;
using System.Collections; 
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace TechSupportData
{
    public static class IncidentDB
    {
        private const string DateValueNull = "01/01/0001 12:00:00 AM";

        //Table name constants
        public const string TblIncidents = "Incidents";

        //Field name constants
        public const string FldIncidentID = "IncidentID";
        public const string FldCustomerID = "CustomerID";
        public const string FldProductCode = "ProductCode";
        public const string FldTechID = "TechID";
        public const string FldDateOpened = "DateOpened";
        public const string FldDateClosed = "DateClosed";
        public const string FldTitle = "Title";
        public const string FldDescription = "Description";

        public static List<Incident> GetOpenIncidents()
        {
            DBManager DB = TechSupportDB.GetDBManager();  
            List<Incident> incidentList = new List<Incident>();
            SqlDataReader dr;

            string strSelect = "SELECT " + FldCustomerID + ", " + FldProductCode + ", " + FldTechID + ", " +
                                            FldDateOpened + ", " + FldTitle + 
                                 " FROM " + TblIncidents + " WHERE " + FldDateClosed + " IS NULL";

            dr = DB.SelectDirect(strSelect, CommandType.Text);            

            while(dr.Read())
            {
                Incident incident = new Incident();
                incident.CustomerID = (int)dr[FldCustomerID];
                incident.ProductCode = dr[FldProductCode].ToString();

                if (dr[FldTechID].GetType().ToString() == "System.DBNull")
                    incident.TechID = null;
                else
                    incident.TechID = (int)dr[FldTechID];

                incident.DateOpened = (DateTime)dr[FldDateOpened];
                incident.Title = dr[FldTitle].ToString();
                incidentList.Add(incident); 
            }

            dr.Close();

            return incidentList;
        }

        public static List<Incident> GetOpenTechnicianIncidents(int techID)
        {
            DBManager DB = TechSupportDB.GetDBManager();
            SortedList slParams = new SortedList();
            List<Incident> incidentList = new List<Incident>();
            SqlDataReader dr;

            string strSelect = "SELECT " + FldCustomerID + ", " + FldProductCode + ", " +
                                            FldDateOpened + ", " + FldTitle +
                               " FROM " + TblIncidents + 
                               " WHERE " + FldTechID + "=@" + FldTechID + 
                               " AND " + FldDateClosed + " IS NULL";

            slParams.Add(FldTechID, techID);

            dr = DB.SelectDirect(strSelect, CommandType.Text, slParams);

            while (dr.Read())
            {
                Incident incident = new Incident();
                incident.CustomerID = (int)dr[FldCustomerID];
                incident.ProductCode = dr[FldProductCode].ToString();
                incident.DateOpened = (DateTime)dr[FldDateOpened];
                incident.Title = dr[FldTitle].ToString();
                incidentList.Add(incident);
            }

            dr.Close();

            return incidentList;
        }

        public static int AddIncident(Incident incident)
        {
            DBManager DB = TechSupportDB.GetDBManager();
            SortedList slParams = new SortedList();
            int intResult = 0;

            slParams.Add(FldCustomerID, incident.CustomerID);
            slParams.Add(FldProductCode, incident.ProductCode);
            slParams.Add(FldDateOpened, incident.DateOpened);
            slParams.Add(FldTitle,incident.Title);
            slParams.Add(FldDescription, incident.Description);

            intResult = DB.InsertDirect(TblIncidents, CommandType.Text, slParams);

            return intResult;
        }

    }
}
