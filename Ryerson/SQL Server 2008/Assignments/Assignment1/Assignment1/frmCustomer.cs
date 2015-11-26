using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Assignment1
{
    public partial class frmCustomer : Form
    {
        public frmCustomer()
        {
            InitializeComponent();
        }

        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.customersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.techSupportDataSet2C);

        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            int customerID = (int)this.Tag;
            this.customersTableAdapter.Fill(this.techSupportDataSet2C.Customers, customerID);
        }
    }
}
