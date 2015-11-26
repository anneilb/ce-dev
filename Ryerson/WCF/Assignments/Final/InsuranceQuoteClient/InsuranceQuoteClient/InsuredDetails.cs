using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InsuranceQuoteClient.InsuranceQuoteServiceProxy;

namespace InsuranceQuoteClient
{
    public partial class InsuredDetails : Form
    {
        public InsuredDetails()
        {
            InitializeComponent();
        }

        private void btnGetQuote_Click(object sender, EventArgs e)
        {
            InsuranceQuoteServiceClient svcInsuranceQuote = new InsuranceQuoteServiceClient();
            InsuredInfo objInsuredInfo = new InsuredInfo(); 
            InsuranceQuoteInfo objQuoteInfo;
            
            objInsuredInfo.Name = txtInsuredName.Text;
            objInsuredInfo.Address = txtInsuredAddress.Text;          
            objInsuredInfo.Age = txtInsuredAge.Text;
            objInsuredInfo.VehicleMake = txtVehicleMake.Text;
            objInsuredInfo.VehicleYearBuilt = cboVehicleYearBuilt.SelectedIndex;

            try
            {
                //objQuoteInfo = svcInsuranceQuote.GetQuote(objInsuredInfo);
                objQuoteInfo = svcInsuranceQuote.GetQuoteUsingMessageContract(objInsuredInfo);
                lblMonthlyAmount.Text = string.Format("Your premium will be ${0} per month.", objQuoteInfo.MontlyTotal);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Service Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                                    
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtInsuredName.Text = "";
            txtInsuredAddress.Text = "";
            txtInsuredAge.Text = "";
            txtVehicleMake.Text = "";
            cboVehicleYearBuilt.SelectedIndex = -1;
            lblMonthlyAmount.Text = "";
        }
    }
}
