using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace TechSupportData
{
    public static class TechSupportDB
    {
        private static string m_connectionString = "";
        private static DBManager m_DBManager;
        
        public static SqlConnection GetConnection()
        {
            throw new NotImplementedException();
        }

        public static void SetConnectionString(string connectionString)
        {
            //Set connection string if not set or different, and  
            //set up DBManager connection string accordingly
            if (connectionString.Length > 0)
            { 
                if (m_connectionString.Length == 0)                    
                {
                    m_connectionString = connectionString;
                }
                else if (!connectionString.Equals(m_connectionString))
                {
                    m_connectionString = connectionString;

                    if (m_DBManager != null)
                    {
                        m_DBManager.CloseConnection();
                        m_DBManager.ConnectionString = m_connectionString;
                    }
                }
            }
        }

        //Returns the singleton instance of the DBManager class
        public static DBManager GetDBManager()
        {
            DBManager DBMan = null;

            if (m_DBManager == null)
            {
                if (m_connectionString.Length > 0)
                {
                    m_DBManager = new DBManager(m_connectionString);
                    DBMan = m_DBManager;
                }
            }
            else
            {
                DBMan = m_DBManager;
            }
            
            return DBMan;
        }
    }
}
