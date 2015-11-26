using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Exercise4
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
            Application.Run(new Form1());
        }
    }

    public class NumberPublisher
    {

        public delegate void ValueChangeHandler(int intValue);
        public event ValueChangeHandler ValueChanged;

        const int VALUE_MIN = 0;
        const int VALUE_MAX = 100;

        private int intValue;

        public int Value
        {
            get { return intValue; }
            
            set 
            {
                if ((value >= VALUE_MIN) && (value <= VALUE_MAX))
                {                
                    intValue = value;
                    OnValueChanged(value);
                }
            }
        }

        protected virtual void OnValueChanged(int intChangeValue)
        {
            if (ValueChanged != null)
            {
                ValueChanged(intChangeValue); 
            }
        }        

    }

}
