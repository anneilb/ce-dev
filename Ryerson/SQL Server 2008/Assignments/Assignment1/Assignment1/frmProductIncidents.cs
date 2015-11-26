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
    public partial class frmProductIncidents : Form
    {
        public frmProductIncidents()
        {
            InitializeComponent();
        }

        private void productsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.techSupportDataSet2C);

        }

        private void frmProductIncidents_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'techSupportDataSet2C.Incidents' table. You can move, or remove it, as needed.
            this.incidentsTableAdapter.Fill(this.techSupportDataSet2C.Incidents);
            // TODO: This line of code loads data into the 'techSupportDataSet2C.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.techSupportDataSet2C.Products);
        }

        private void incidentsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                int i = e.RowIndex;
                DataGridViewRow row = incidentsDataGridView.Rows[i];
                DataGridViewCell cell = row.Cells[0];
                int customerID = (int)cell.Value;

                Form customerForm = new frmCustomer();
                customerForm.Tag = customerID;
                customerForm.ShowDialog();
            }
        }        

    }
}
