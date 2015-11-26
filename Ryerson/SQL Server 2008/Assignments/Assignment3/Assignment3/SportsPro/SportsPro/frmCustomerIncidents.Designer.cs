namespace SportsPro
{
    partial class frmCustomerIncidents
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
            System.Windows.Forms.Label addressLabel;
            System.Windows.Forms.Label cityLabel;
            System.Windows.Forms.Label emailLabel;
            System.Windows.Forms.Label phoneLabel;
            System.Windows.Forms.Label nameLabel;
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.cityTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.phoneTextBox = new System.Windows.Forms.TextBox();
            this.stateTextBox = new System.Windows.Forms.TextBox();
            this.zipCodeTextBox = new System.Windows.Forms.TextBox();
            this.nameComboBox = new System.Windows.Forms.ComboBox();
            this.sQLIncidentDataGridView = new System.Windows.Forms.DataGridView();
            this.sQLCustomerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sQLIncidentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colIncidentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateOpened = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateClosed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            addressLabel = new System.Windows.Forms.Label();
            cityLabel = new System.Windows.Forms.Label();
            emailLabel = new System.Windows.Forms.Label();
            phoneLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sQLIncidentDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sQLCustomerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sQLIncidentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // addressLabel
            // 
            addressLabel.AutoSize = true;
            addressLabel.Location = new System.Drawing.Point(9, 42);
            addressLabel.Name = "addressLabel";
            addressLabel.Size = new System.Drawing.Size(48, 13);
            addressLabel.TabIndex = 1;
            addressLabel.Text = "Address:";
            // 
            // cityLabel
            // 
            cityLabel.AutoSize = true;
            cityLabel.Location = new System.Drawing.Point(9, 68);
            cityLabel.Name = "cityLabel";
            cityLabel.Size = new System.Drawing.Size(79, 13);
            cityLabel.TabIndex = 3;
            cityLabel.Text = "City, State, Zip:";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new System.Drawing.Point(9, 96);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(35, 13);
            emailLabel.TabIndex = 7;
            emailLabel.Text = "Email:";
            // 
            // phoneLabel
            // 
            phoneLabel.AutoSize = true;
            phoneLabel.Location = new System.Drawing.Point(9, 122);
            phoneLabel.Name = "phoneLabel";
            phoneLabel.Size = new System.Drawing.Size(41, 13);
            phoneLabel.TabIndex = 11;
            phoneLabel.Text = "Phone:";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(9, 15);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(38, 13);
            nameLabel.TabIndex = 16;
            nameLabel.Text = "Name:";
            // 
            // addressTextBox
            // 
            this.addressTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sQLCustomerBindingSource, "Address", true));
            this.addressTextBox.Location = new System.Drawing.Point(94, 39);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.ReadOnly = true;
            this.addressTextBox.Size = new System.Drawing.Size(297, 20);
            this.addressTextBox.TabIndex = 2;
            // 
            // cityTextBox
            // 
            this.cityTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sQLCustomerBindingSource, "City", true));
            this.cityTextBox.Location = new System.Drawing.Point(94, 65);
            this.cityTextBox.Name = "cityTextBox";
            this.cityTextBox.ReadOnly = true;
            this.cityTextBox.Size = new System.Drawing.Size(138, 20);
            this.cityTextBox.TabIndex = 4;
            // 
            // emailTextBox
            // 
            this.emailTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sQLCustomerBindingSource, "Email", true));
            this.emailTextBox.Location = new System.Drawing.Point(94, 93);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.ReadOnly = true;
            this.emailTextBox.Size = new System.Drawing.Size(297, 20);
            this.emailTextBox.TabIndex = 8;
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sQLCustomerBindingSource, "Phone", true));
            this.phoneTextBox.Location = new System.Drawing.Point(94, 119);
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.ReadOnly = true;
            this.phoneTextBox.Size = new System.Drawing.Size(138, 20);
            this.phoneTextBox.TabIndex = 12;
            // 
            // stateTextBox
            // 
            this.stateTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sQLCustomerBindingSource, "State", true));
            this.stateTextBox.Location = new System.Drawing.Point(238, 65);
            this.stateTextBox.Name = "stateTextBox";
            this.stateTextBox.ReadOnly = true;
            this.stateTextBox.Size = new System.Drawing.Size(47, 20);
            this.stateTextBox.TabIndex = 14;
            // 
            // zipCodeTextBox
            // 
            this.zipCodeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sQLCustomerBindingSource, "ZipCode", true));
            this.zipCodeTextBox.Location = new System.Drawing.Point(291, 65);
            this.zipCodeTextBox.Name = "zipCodeTextBox";
            this.zipCodeTextBox.ReadOnly = true;
            this.zipCodeTextBox.Size = new System.Drawing.Size(100, 20);
            this.zipCodeTextBox.TabIndex = 16;
            // 
            // nameComboBox
            // 
            this.nameComboBox.DisplayMember = "Name";
            this.nameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nameComboBox.FormattingEnabled = true;
            this.nameComboBox.Location = new System.Drawing.Point(94, 12);
            this.nameComboBox.Name = "nameComboBox";
            this.nameComboBox.Size = new System.Drawing.Size(297, 21);
            this.nameComboBox.TabIndex = 17;
            this.nameComboBox.ValueMember = "CustomerID";
            this.nameComboBox.SelectedIndexChanged += new System.EventHandler(this.nameComboBox_SelectedIndexChanged);
            // 
            // sQLIncidentDataGridView
            // 
            this.sQLIncidentDataGridView.AllowUserToAddRows = false;
            this.sQLIncidentDataGridView.AllowUserToDeleteRows = false;
            this.sQLIncidentDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sQLIncidentDataGridView.AutoGenerateColumns = false;
            this.sQLIncidentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sQLIncidentDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIncidentID,
            this.colProductCode,
            this.colDateOpened,
            this.colDateClosed,
            this.colTitle});
            this.sQLIncidentDataGridView.DataSource = this.sQLIncidentBindingSource;
            this.sQLIncidentDataGridView.Location = new System.Drawing.Point(12, 145);
            this.sQLIncidentDataGridView.Name = "sQLIncidentDataGridView";
            this.sQLIncidentDataGridView.ReadOnly = true;
            this.sQLIncidentDataGridView.Size = new System.Drawing.Size(568, 216);
            this.sQLIncidentDataGridView.TabIndex = 17;
            // 
            // sQLCustomerBindingSource
            // 
            this.sQLCustomerBindingSource.DataSource = typeof(TechSupportData.SQLCustomer);
            // 
            // sQLIncidentBindingSource
            // 
            this.sQLIncidentBindingSource.DataSource = typeof(TechSupportData.SQLIncident);
            // 
            // colIncidentID
            // 
            this.colIncidentID.DataPropertyName = "IncidentID";
            this.colIncidentID.HeaderText = "Incident ID";
            this.colIncidentID.Name = "colIncidentID";
            this.colIncidentID.ReadOnly = true;
            this.colIncidentID.Width = 90;
            // 
            // colProductCode
            // 
            this.colProductCode.DataPropertyName = "ProductCode";
            this.colProductCode.HeaderText = "Product Code";
            this.colProductCode.Name = "colProductCode";
            this.colProductCode.ReadOnly = true;
            // 
            // colDateOpened
            // 
            this.colDateOpened.DataPropertyName = "DateOpened";
            this.colDateOpened.HeaderText = "Date Opened";
            this.colDateOpened.Name = "colDateOpened";
            this.colDateOpened.ReadOnly = true;
            // 
            // colDateClosed
            // 
            this.colDateClosed.DataPropertyName = "DateClosed";
            this.colDateClosed.HeaderText = "Date Closed";
            this.colDateClosed.Name = "colDateClosed";
            this.colDateClosed.ReadOnly = true;
            // 
            // colTitle
            // 
            this.colTitle.DataPropertyName = "Title";
            this.colTitle.HeaderText = "Title";
            this.colTitle.Name = "colTitle";
            this.colTitle.ReadOnly = true;
            this.colTitle.Width = 150;
            // 
            // frmCustomerIncidents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 373);
            this.Controls.Add(this.sQLIncidentDataGridView);
            this.Controls.Add(nameLabel);
            this.Controls.Add(this.nameComboBox);
            this.Controls.Add(addressLabel);
            this.Controls.Add(this.addressTextBox);
            this.Controls.Add(cityLabel);
            this.Controls.Add(this.cityTextBox);
            this.Controls.Add(emailLabel);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(phoneLabel);
            this.Controls.Add(this.phoneTextBox);
            this.Controls.Add(this.stateTextBox);
            this.Controls.Add(this.zipCodeTextBox);
            this.Name = "frmCustomerIncidents";
            this.Text = "Incidents by Customer";
            this.Load += new System.EventHandler(this.frmCustomerIncidents_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sQLIncidentDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sQLCustomerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sQLIncidentBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource sQLCustomerBindingSource;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.TextBox cityTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox phoneTextBox;
        private System.Windows.Forms.TextBox stateTextBox;
        private System.Windows.Forms.TextBox zipCodeTextBox;
        private System.Windows.Forms.ComboBox nameComboBox;
        private System.Windows.Forms.BindingSource sQLIncidentBindingSource;
        private System.Windows.Forms.DataGridView sQLIncidentDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIncidentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateOpened;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateClosed;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
    }
}