using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TechSupportData
{
    public static class SQLDataContext
    {
        private static TechSupportDataContext m_techSupportSQL;
        private static string m_connectionString = "";

        public static TechSupportDataContext GetTechSupportDataContext()
        {
            TechSupportDataContext techSupportSQL = null;

            if (m_techSupportSQL == null)
            {
                if (m_connectionString.Length > 0)
                {
                    m_techSupportSQL = new TechSupportDataContext(m_connectionString);
                    techSupportSQL = m_techSupportSQL;
                }
            }
            else
            {
                techSupportSQL = m_techSupportSQL;
            }

            return techSupportSQL;
        }

        public static void SetConnectionString(string connectionString)
        {
            //Set connection string if not set or different, and  
            //set up TechSupportDataContext connection string accordingly
            if (connectionString.Length > 0)
            {
                if (m_connectionString.Length == 0)
                {
                    m_connectionString = connectionString;
                }
                else if (!connectionString.Equals(m_connectionString))
                {
                    m_connectionString = connectionString;

                    if (m_techSupportSQL != null)
                    {
                        m_techSupportSQL.Connection.Close();
                        m_techSupportSQL.Connection.ConnectionString = m_connectionString;
                        m_techSupportSQL.Connection.Open();  
                    }
                }
            }
        }
    }
}
