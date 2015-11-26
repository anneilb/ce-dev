using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Exercise4
{
    public partial class Form1 : Form
    {
        private NumberPublisher NumPub;
        
        public Form1()
        {
            InitializeComponent();
            SubscribeControls();            
        }

        private void SubscribeControls()
        {

            NumPub = new NumberPublisher();
            
            //Subscribe controls to publisher event
            txtNumber.SubscribeToNumberPublisher(NumPub);
            trkChange.SubscribeToNumberPublisher(NumPub); 
            
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (txtNumber.Text!="")
            {
                NumPub.Value = Int32.Parse(txtNumber.Text);
            }
        }

        private void trkChange_ValueChanged(object sender, EventArgs e)
        {
            NumPub.Value = trkChange.Value;
        }       
    }

    public class TextBoxNumber : System.Windows.Forms.TextBox
    {
        //Subscribe delegate method NumberHasChanged to NumberPublisher's ValueChanged event
        public void SubscribeToNumberPublisher(NumberPublisher NumPub)
        {
            NumPub.ValueChanged += new NumberPublisher.ValueChangeHandler(NumberHasChanged);
        }

        private void NumberHasChanged(int intValue)
        {
            this.Text = "" + intValue;
        }
    }

    public class TrackBarNumber : System.Windows.Forms.TrackBar
    {
        //Subscribe delegate method NumberHasChanged to NumberPublisher's ValueChanged event
        public void SubscribeToNumberPublisher(NumberPublisher NumPub)
        {
            NumPub.ValueChanged += new NumberPublisher.ValueChangeHandler(NumberHasChanged);
        }

        private void NumberHasChanged(int intValue)
        {
            this.Value = intValue;
        }
    }
    
}
