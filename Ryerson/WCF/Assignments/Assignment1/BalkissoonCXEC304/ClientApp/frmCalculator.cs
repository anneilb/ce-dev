using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using ClientApp.FutureValueCalculatorProxy;

namespace ClientApp
{
    public partial class frmCalculator : Form
    {
        public frmCalculator()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            FutureValueCalculatorClient fvCalculator = new FutureValueCalculatorClient();            
            double dblTotalChequing = 0;
            double dblTotalSavings = 0;
            double dblTotalRRSP = 0;
            double dblPresentValue = 0;
            double dblInterestRate = 0;
            int intTermInYears = 0;
            double dblFutureValue = 0;

            
            if (ValidateFields())
            {
                dblTotalChequing = double.Parse(txtTotalChequing.Text);
                dblTotalSavings = double.Parse(txtTotalSavings.Text);
                dblTotalRRSP = double.Parse(txtTotalRRSP.Text);
                dblInterestRate = double.Parse(txtInterestRate.Text);
                intTermInYears = int.Parse(txtTermInYears.Text);

                dblPresentValue = dblTotalChequing + dblTotalSavings + dblTotalRRSP;
                dblFutureValue = fvCalculator.Calculate(dblPresentValue, dblInterestRate, intTermInYears);

                txtFutureValue.Text = "" + dblFutureValue;
            }
        }

        private bool ValidateFields()
        {
            string strTest;
            double dblTest;
            int intTest;

            //Chequing
            strTest = txtTotalChequing.Text.Trim();

            if (strTest.Length > 0)
            {
                if(!double.TryParse(strTest, out dblTest))
                {
                    MessageBox.Show(this, "You must enter a numeric value for Total Chequing", 
                                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show(this, "You must enter a value for Total Chequing", 
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //Savings
            strTest = txtTotalSavings.Text.Trim();

            if (strTest.Length > 0)
            {
                if (!double.TryParse(strTest, out dblTest))
                {
                    MessageBox.Show(this, "You must enter a numeric value for Total Savings", 
                                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show(this, "You must enter a value for Total Savings", 
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //RRSP
            strTest = txtTotalRRSP.Text.Trim();

            if (strTest.Length > 0)
            {
                if (!double.TryParse(strTest, out dblTest))
                {
                    MessageBox.Show(this, "You must enter a numeric value for Total RRSP", 
                                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show(this, "You must enter a value for Total RRSP", 
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //Term in Years
            strTest = txtTermInYears.Text.Trim();

            if (strTest.Length > 0)
            {
                if (!int.TryParse(strTest, out intTest))
                {
                    MessageBox.Show(this, "You must enter a numeric value for Term in Years",
                                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show(this, "You must enter a value for Term in Years",
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //Interest Rate
            strTest = txtInterestRate.Text.Trim();

            if (strTest.Length > 0)
            {
                if (!double.TryParse(strTest, out dblTest))
                {
                    MessageBox.Show(this, "You must enter a numeric value for Interest Rate", 
                                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show(this, "You must enter a value for Interest Rate", 
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true; 
        }

        private void ClearAllFields()
        {
            txtTotalChequing.Text = "";
            txtTotalSavings.Text = "";
            txtTotalRRSP.Text = "";
            txtInterestRate.Text = "";
            txtTermInYears.Text = "";
            txtFutureValue.Text = "";                        
        }

        private void btnClearAllFields_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
