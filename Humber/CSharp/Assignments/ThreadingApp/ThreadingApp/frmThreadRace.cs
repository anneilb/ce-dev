using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ThreadingApp
{
    public partial class frmThreadRace : Form
    {
        private delegate void SetCallBackText(string strText);
        
        private Thread m_t1;
        private Thread m_t2;
        private Thread m_t3;
        private ProgressGenerator m_pg;
        private ProgressThread m_pt1;
        private ProgressThread m_pt2;
        private ProgressThread m_pt3;
        //private BackgroundWorker m_bgWorker;
        private bool m_blnWinnerDeclared;

        public frmThreadRace()
        {
            InitializeComponent();

            //init brush colours
            pnlThread1.ProgressColour = System.Drawing.Brushes.Red;
            pnlThread2.ProgressColour = System.Drawing.Brushes.Green;
            pnlThread3.ProgressColour = System.Drawing.Brushes.Blue;

            //init progress generator seeded with number of preference
            m_pg = new ProgressGenerator(5);

            //init progress threads
            m_pt1 = new ProgressThread(ref pnlThread1, ref m_pg);
            m_pt2 = new ProgressThread(ref pnlThread2, ref m_pg);
            m_pt3 = new ProgressThread(ref pnlThread3, ref m_pg);
            
            m_t1 = new Thread(new ThreadStart(m_pt1.IncrementProgress));
            m_t2 = new Thread(new ThreadStart(m_pt2.IncrementProgress));
            m_t3 = new Thread(new ThreadStart(m_pt3.IncrementProgress));

            m_t1.Name = "Thread 1";
            m_t2.Name = "Thread 2";
            m_t3.Name = "Thread 3";

            //Subscribe to Panel ProgressFinished events in order to determine winner
            pnlThread1.ProgressFinished += new ProgressPanel.ProgresFinishedHandler(pnlThread1_ProgressFinished);
            pnlThread2.ProgressFinished += new ProgressPanel.ProgresFinishedHandler(pnlThread2_ProgressFinished);
            pnlThread3.ProgressFinished += new ProgressPanel.ProgresFinishedHandler(pnlThread3_ProgressFinished);
        }

        private void DeclareWinner(string strThreadName)
        {
            if (!m_blnWinnerDeclared)
            {
                m_blnWinnerDeclared = true;
                this.SetWinnerText(strThreadName);   
            }            
        }

        private void SetWinnerText(string strThreadName)
        {
            if (this.lblWinner.InvokeRequired)
            {
                SetCallBackText d = new SetCallBackText(SetWinnerText);
                this.Invoke(d,new object[] {strThreadName});
            }
            else
            {
                this.lblWinner.Text = strThreadName + "\n is the Winner!";
            }
        }
        
        private void btnGo_Click(object sender, EventArgs e)
        {
            btnGo.Enabled = false;

            m_t1.Start();
            m_t2.Start();
            m_t3.Start();
        }

        private void pnlThread1_ProgressFinished(string strThreadName)
        {
            m_t2.Abort();
            m_t3.Abort();                  
            DeclareWinner(strThreadName);
        }

        private void pnlThread2_ProgressFinished(string strThreadName)
        {
            m_t1.Abort();
            m_t3.Abort();                  
            DeclareWinner(strThreadName);
        }

        private void pnlThread3_ProgressFinished(string strThreadName)
        {
            m_t1.Abort();
            m_t2.Abort();
            DeclareWinner(strThreadName);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            m_t1.Abort();
            m_t2.Abort();
            m_t3.Abort();
            Application.Exit();
        }
    }
  
}
