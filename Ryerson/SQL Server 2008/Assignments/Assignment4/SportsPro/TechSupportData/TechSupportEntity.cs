using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TechSupportData
{
    public static class TechSupportEntity
    {
        private static Entities m_techSupportEF;
        private static string m_connectionString = "";

        public static Entities GetTechSupportEntities()
        {
            Entities techSupportEF = null;

            if (m_techSupportEF == null)
            {
                if (m_connectionString.Length > 0)
                {
                    m_techSupportEF = new Entities(m_connectionString);
                    techSupportEF = m_techSupportEF;
                }
            }
            else
            {
                techSupportEF = m_techSupportEF;
            }

            return techSupportEF;
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

                    if (m_techSupportEF != null)
                    {
                        m_techSupportEF.Connection.Close();
                        m_techSupportEF.Connection.ConnectionString = m_connectionString;
                        m_techSupportEF.Connection.Open();
                    }
                }
            }
        }
    }
}
