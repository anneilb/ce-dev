namespace SportsPro
{
    partial class frmCustomerProducts
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label nameLabel;
            this.techSupportDataSet4A = new SportsPro.TechSupportDataSet4A();
            this.customersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.customersTableAdapter = new SportsPro.TechSupportDataSet4ATableAdapters.CustomersTableAdapter();
            this.tableAdapterManager = new SportsPro.TechSupportDataSet4ATableAdapters.TableAdapterManager();
            this.nameComboBox = new System.Windows.Forms.ComboBox();
            this.registrationsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.registrationsTableAdapter = new SportsPro.TechSupportDataSet4ATableAdapters.RegistrationsTableAdapter();
            this.registrationsDataGridView = new System.Windows.Forms.DataGridView();
            this.colCustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRegistrationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            nameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.techSupportDataSet4A)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registrationsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registrationsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(7, 15);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(38, 13);
            nameLabel.TabIndex = 1;
            nameLabel.Text = "Name:";
            // 
            // techSupportDataSet4A
            // 
            this.techSupportDataSet4A.DataSetName = "TechSupportDataSet4A";
            this.techSupportDataSet4A.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // customersBindingSource
            // 
            this.customersBindingSource.DataMember = "Customers";
            this.customersBindingSource.DataSource = this.techSupportDataSet4A;
            // 
            // customersTableAdapter
            // 
            this.customersTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = SportsPro.TechSupportDataSet4ATableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // nameComboBox
            // 
            this.nameComboBox.DisplayMember = "Name";
            this.nameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nameComboBox.FormattingEnabled = true;
            this.nameComboBox.Location = new System.Drawing.Point(51, 12);
            this.nameComboBox.Name = "nameComboBox";
            this.nameComboBox.Size = new System.Drawing.Size(199, 21);
            this.nameComboBox.TabIndex = 2;
            this.nameComboBox.ValueMember = "CustomerID";
            this.nameComboBox.SelectedIndexChanged += new System.EventHandler(this.nameComboBox_SelectedIndexChanged);
            // 
            // registrationsBindingSource
            // 
            this.registrationsBindingSource.DataMember = "Registrations";
            this.registrationsBindingSource.DataSource = this.techSupportDataSet4A;
            // 
            // registrationsTableAdapter
            // 
            this.registrationsTableAdapter.ClearBeforeFill = true;
            // 
            // registrationsDataGridView
            // 
            this.registrationsDataGridView.AllowUserToAddRows = false;
            this.registrationsDataGridView.AllowUserToDeleteRows = false;
            this.registrationsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.registrationsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.registrationsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCustomerID,
            this.colProductCode,
            this.colProductName,
            this.colRegistrationDate});
            this.registrationsDataGridView.Location = new System.Drawing.Point(10, 55);
            this.registrationsDataGridView.Name = "registrationsDataGridView";
            this.registrationsDataGridView.ReadOnly = true;
            this.registrationsDataGridView.Size = new System.Drawing.Size(570, 226);
            this.registrationsDataGridView.TabIndex = 3;
            // 
            // colCustomerID
            // 
            this.colCustomerID.DataPropertyName = "CustomerID";
            this.colCustomerID.HeaderText = "Customer ID";
            this.colCustomerID.Name = "colCustomerID";
            this.colCustomerID.ReadOnly = true;
            this.colCustomerID.Visible = false;
            // 
            // colProductCode
            // 
            this.colProductCode.DataPropertyName = "ProductCode";
            this.colProductCode.HeaderText = "Product Code";
            this.colProductCode.Name = "colProductCode";
            this.colProductCode.ReadOnly = true;
            // 
            // colProductName
            // 
            this.colProductName.DataPropertyName = "Name";
            this.colProductName.HeaderText = "Name";
            this.colProductName.Name = "colProductName";
            this.colProductName.ReadOnly = true;
            this.colProductName.Width = 275;
            // 
            // colRegistrationDate
            // 
            this.colRegistrationDate.DataPropertyName = "RegistrationDate";
            this.colRegistrationDate.HeaderText = "Registration Date";
            this.colRegistrationDate.Name = "colRegistrationDate";
            this.colRegistrationDate.ReadOnly = true;
            this.colRegistrationDate.Width = 115;
            // 
            // frmCustomerProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 293);
            this.Controls.Add(this.registrationsDataGridView);
            this.Controls.Add(nameLabel);
            this.Controls.Add(this.nameComboBox);
            this.Name = "frmCustomerProducts";
            this.Text = "Products by Customer";
            this.Load += new System.EventHandler(this.frmCustomerProducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.techSupportDataSet4A)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registrationsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registrationsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TechSupportDataSet4A techSupportDataSet4A;
        private System.Windows.Forms.BindingSource customersBindingSource;
        private SportsPro.TechSupportDataSet4ATableAdapters.CustomersTableAdapter customersTableAdapter;
        private SportsPro.TechSupportDataSet4ATableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ComboBox nameComboBox;
        private System.Windows.Forms.BindingSource registrationsBindingSource;
        private SportsPro.TechSupportDataSet4ATableAdapters.RegistrationsTableAdapter registrationsTableAdapter;
        private System.Windows.Forms.DataGridView registrationsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegistrationDate;
    }
}