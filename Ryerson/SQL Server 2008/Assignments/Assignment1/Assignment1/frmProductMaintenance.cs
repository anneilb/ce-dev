using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Assignment1
{
    public partial class frmProductMaintenance : Form
    {
        public frmProductMaintenance()
        {
            InitializeComponent();
        }

        private void productsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();

            try
            {
                this.productsBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.techSupportDataSet2A);
            }
            catch (DBConcurrencyException)
            {
                MessageBox.Show("A concurrency error occurred. The row was not updated.",
                                "Concurrency error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DataException ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
                this.productsBindingSource.CancelEdit();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Server error # " + ex.Number + ": " + ex.Message, ex.GetType().ToString(), 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmProductMaintenance_Load(object sender, EventArgs e)
        {
            try
            {
                this.productsTableAdapter.Fill(this.techSupportDataSet2A.Products);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Server error # " + ex.Number + ": " + ex.Message, ex.GetType().ToString(),
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void productsDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            int row = e.RowIndex + 1;
            int col = e.ColumnIndex + 1;

            string strErrorMessage = "A data error occurred.\nRow: " + row + 
                                     ", Column: " + col + "\nError: " + e.Exception.Message;
            MessageBox.Show(strErrorMessage, "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void bindingNavigatorCancelItem_Click(object sender, EventArgs e)
        {
            this.productsBindingSource.CancelEdit();
        }
    }
}
