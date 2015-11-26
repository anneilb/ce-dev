using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SportsPro
{
    public partial class frmCustomerMaintenance : Form
    {
        public frmCustomerMaintenance()
        {
            InitializeComponent();
        }

        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            //this.Validate();

            if (IsValidData())
            {
                try
                {
                    this.customersBindingSource.EndEdit();
                    this.tableAdapterManager.UpdateAll(this.techSupportDataSet2B);
                }
                catch (DBConcurrencyException)
                {
                    MessageBox.Show("A concurrency error occurred. The row was not updated.",
                                    "Concurrency error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                    this.customersBindingSource.CancelEdit();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("SQL Server error # " + ex.Number + ": " + ex.Message, ex.GetType().ToString(),
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool IsValidData()
        {
            bool blnResult = false;

            if (customersBindingSource.Count > 0)
            {
                blnResult = (Validator.IsPresent(nameTextBox, "Name") &&
                             Validator.IsPresent(addressTextBox, "Address1") &&
                             Validator.IsPresent(cityTextBox, "City") &&
                             Validator.IsPresent(stateComboBox, "State") &&
                             Validator.IsPresent(zipCodeTextBox, "Zip code"));

                /*IsLength(zipCodeTextBox, "Zip code", 9) &&
                            IsNumeric(zipCodeTextBox, "Zip code")*/
            }
            else
            {
                blnResult = true;
            }

            return blnResult;
        }

 
        private void frmCustomerMaintenance_Load(object sender, EventArgs e)
        {
            Binding b = zipCodeTextBox.DataBindings["Text"];
            b.Format += new ConvertEventHandler(FormatZipCode);
            b.Parse += new ConvertEventHandler(UnFormatZipCode);
            
            try
            {
                this.statesTableAdapter.Fill(this.techSupportDataSet2B.States);
                this.customersTableAdapter.Fill(this.techSupportDataSet2B.Customers);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Server error # " + ex.Number + ": " + ex.Message, ex.GetType().ToString(),
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void UnFormatZipCode(object sender, ConvertEventArgs e)
        {
            if (e.Value.GetType().ToString() == "System.String")
            {
                string s = e.Value.ToString();
                e.Value = s.Replace("-", "");
            }
        }

        void FormatZipCode(object sender, ConvertEventArgs e)
        {
            int intTemp = 0;

            if (e.Value.GetType().ToString() == "System.String")
            {
                string s = e.Value.ToString();

                if (int.TryParse(s, out intTemp))
                {
                    if (s.Length == 9)
                    {
                        e.Value = s.Substring(0, 5) + "-" + s.Substring(5);
                    }
                }
            }
        }

        private void fillByCustomerIDToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                int intCustomerID = Convert.ToInt32(customerIDToolStripTextBox.Text);
                this.customersTableAdapter.FillByCustomerID(this.techSupportDataSet2B.Customers,intCustomerID);
            
                if (customersBindingSource.Count == 0)
                    MessageBox.Show("No customer found with this ID. " + "Please try again.", "Customer Not Found", 
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(FormatException)
            {
                MessageBox.Show("Customer ID must be an integer", "Customer ID Invalid", 
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }            
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, ex.GetType().ToString(),
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.statesTableAdapter.Fill(this.techSupportDataSet2B.States);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, ex.GetType().ToString(),
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void bindingNavigatorCancelItem_Click(object sender, EventArgs e)
        {
            this.customersBindingSource.CancelEdit();
        }
    }
}
