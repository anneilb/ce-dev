using System;
using System.Collections.Generic;
using System.Text;
using System.Threading; 

namespace ThreadingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t1;
            Thread t2;
            MoneyAccount ma1;
            MoneyAccount ma2;

            ma1 = new MoneyAccount(3000);
            ma2 = new MoneyAccount(3000);

            TransferThread tt1 = new TransferThread("Thread1", ref ma1, ref ma2);
            TransferThread tt2 = new TransferThread("Thread2", ref ma2, ref ma1);

            t1 = new Thread(new ThreadStart(tt1.TransferMoney));
            t2 = new Thread(new ThreadStart(tt2.TransferMoney));

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();
        }
    }

    public class TransferThread
    {
        private MoneyAccount m_TargetAcct;
        private MoneyAccount m_SourceAcct;
        private string m_strName;

        public string Name
        {
            set{ m_strName = value;}
        }
        
        public TransferThread(string strName, ref MoneyAccount TargetAcct, ref MoneyAccount SourceAcct)
        {
            m_TargetAcct = TargetAcct;
            m_SourceAcct = SourceAcct;
        }
        
        public void TransferMoney()
        {
            Random rndProgressLost = new Random();
            int intMoneyValue = 0;

            while (m_SourceAcct.MoneyValue <= m_TargetAcct.MoneyValue)
            {
                lock (m_SourceAcct)
                {
                    intMoneyValue = m_SourceAcct.MoneyValue;
                }

                m_TargetAcct.MoneyValue = m_TargetAcct.MoneyValue + intMoneyValue;

                System.Console.WriteLine(m_strName + " Target Account Value = " + m_TargetAcct.MoneyValue);
                System.Console.WriteLine(m_strName + " Source Account Value = " + m_SourceAcct.MoneyValue);

                //Simulate time taken to go back and access Generator
                Thread.Sleep(100); //half a second
            }
        }
    }

    public class MoneyAccount
    {
        Random m_rndMoneyAmount;
        int m_intMoneyValue;

        public int MoneyValue
        {
            //Spit out random amounts of progress
            get { return m_intMoneyValue; }
            set { m_intMoneyValue = value; }
        }

        public MoneyAccount(int intSeed)
        {
            m_intMoneyValue = intSeed;
        }
    }
}
