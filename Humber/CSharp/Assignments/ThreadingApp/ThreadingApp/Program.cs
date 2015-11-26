using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading; 

namespace ThreadingApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmThreadRace());
        }
    }

    public class ProgressThread
    {
        private ProgressPanel m_Panel;
        private ProgressGenerator m_Generator;
        private int m_intProgressTotal; 
        
        public ProgressThread(ref ProgressPanel pp, ref ProgressGenerator pg)
        {
            m_Panel = pp;
            m_Generator = pg;
        }

        public void IncrementProgress()
        {
            Random rndProgressLost = new Random();
            int intProgressValue = 0;

            while (m_intProgressTotal <= m_Panel.ClientRectangle.Height)
            {
                lock (m_Generator)
                {
                    intProgressValue = m_Generator.ProgressValue;
                }

                //Determine this amount of progress (original value minus amount lost)
                intProgressValue = intProgressValue - rndProgressLost.Next(0, intProgressValue + 1);

                //Add the amount to the total and set the Progress property on the panel
                m_intProgressTotal = m_intProgressTotal + intProgressValue;
                m_Panel.Progress = m_intProgressTotal;                

                //Simulate time taken to go back and access Generator
                Thread.Sleep(100); //half a second
            }
        }
    }

    public class ProgressGenerator
    {
        Random m_rndProgressAmount;
        int m_intProgressValue;

        public int ProgressValue
        {
            //Spit out random amounts of progress
            get { return m_rndProgressAmount.Next(0, m_intProgressValue + 1); }
            set { m_intProgressValue = value; }
        }

        public ProgressGenerator(int intSeed)
        {
            m_intProgressValue = intSeed;
            m_rndProgressAmount = new Random();
        }    
    }

}
