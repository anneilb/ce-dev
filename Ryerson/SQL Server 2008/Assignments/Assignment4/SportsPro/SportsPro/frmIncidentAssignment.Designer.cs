namespace SportsPro
{
    partial class frmIncidentAssignment
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
            System.Windows.Forms.Label incidentIDLabel;
            System.Windows.Forms.Label productCodeLabel;
            System.Windows.Forms.Label dateOpenedLabel;
            System.Windows.Forms.Label titleLabel;
            System.Windows.Forms.Label descriptionLabel;
            System.Windows.Forms.Label nameLabel;
            this.sQLIncidentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.incidentIDTextBox = new System.Windows.Forms.TextBox();
            this.productCodeTextBox = new System.Windows.Forms.TextBox();
            this.dateOpenedTextBox = new System.Windows.Forms.TextBox();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.sQLTechnicianBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.technicianComboBox = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAssign = new System.Windows.Forms.Button();
            incidentIDLabel = new System.Windows.Forms.Label();
            productCodeLabel = new System.Windows.Forms.Label();
            dateOpenedLabel = new System.Windows.Forms.Label();
            titleLabel = new System.Windows.Forms.Label();
            descriptionLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sQLIncidentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sQLTechnicianBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // incidentIDLabel
            // 
            incidentIDLabel.AutoSize = true;
            incidentIDLabel.Location = new System.Drawing.Point(7, 15);
            incidentIDLabel.Name = "incidentIDLabel";
            incidentIDLabel.Size = new System.Drawing.Size(62, 13);
            incidentIDLabel.TabIndex = 1;
            incidentIDLabel.Text = "Incident ID:";
            // 
            // productCodeLabel
            // 
            productCodeLabel.AutoSize = true;
            productCodeLabel.Location = new System.Drawing.Point(7, 41);
            productCodeLabel.Name = "productCodeLabel";
            productCodeLabel.Size = new System.Drawing.Size(75, 13);
            productCodeLabel.TabIndex = 2;
            productCodeLabel.Text = "Product Code:";
            // 
            // dateOpenedLabel
            // 
            dateOpenedLabel.AutoSize = true;
            dateOpenedLabel.Location = new System.Drawing.Point(7, 67);
            dateOpenedLabel.Name = "dateOpenedLabel";
            dateOpenedLabel.Size = new System.Drawing.Size(74, 13);
            dateOpenedLabel.TabIndex = 4;
            dateOpenedLabel.Text = "Date Opened:";
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Location = new System.Drawing.Point(7, 93);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new System.Drawing.Size(30, 13);
            titleLabel.TabIndex = 6;
            titleLabel.Text = "Title:";
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new System.Drawing.Point(7, 119);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new System.Drawing.Size(63, 13);
            descriptionLabel.TabIndex = 8;
            descriptionLabel.Text = "Description:";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(7, 187);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(63, 13);
            nameLabel.TabIndex = 10;
            nameLabel.Text = "Technician:";
            // 
            // sQLIncidentBindingSource
            // 
            this.sQLIncidentBindingSource.DataSource = typeof(TechSupportData.SQLIncident);
            // 
            // incidentIDTextBox
            // 
            this.incidentIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sQLIncidentBindingSource, "IncidentID", true));
            this.incidentIDTextBox.Location = new System.Drawing.Point(88, 12);
            this.incidentIDTextBox.Name = "incidentIDTextBox";
            this.incidentIDTextBox.ReadOnly = true;
            this.incidentIDTextBox.Size = new System.Drawing.Size(64, 20);
            this.incidentIDTextBox.TabIndex = 2;
            // 
            // productCodeTextBox
            // 
            this.productCodeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sQLIncidentBindingSource, "ProductCode", true));
            this.productCodeTextBox.Location = new System.Drawing.Point(88, 38);
            this.productCodeTextBox.Name = "productCodeTextBox";
            this.productCodeTextBox.ReadOnly = true;
            this.productCodeTextBox.Size = new System.Drawing.Size(120, 20);
            this.productCodeTextBox.TabIndex = 3;
            // 
            // dateOpenedTextBox
            // 
            this.dateOpenedTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sQLIncidentBindingSource, "DateOpened", true));
            this.dateOpenedTextBox.Location = new System.Drawing.Point(88, 64);
            this.dateOpenedTextBox.Name = "dateOpenedTextBox";
            this.dateOpenedTextBox.ReadOnly = true;
            this.dateOpenedTextBox.Size = new System.Drawing.Size(120, 20);
            this.dateOpenedTextBox.TabIndex = 5;
            // 
            // titleTextBox
            // 
            this.titleTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sQLIncidentBindingSource, "Title", true));
            this.titleTextBox.Location = new System.Drawing.Point(88, 90);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.ReadOnly = true;
            this.titleTextBox.Size = new System.Drawing.Size(239, 20);
            this.titleTextBox.TabIndex = 7;
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sQLIncidentBindingSource, "Description", true));
            this.descriptionTextBox.Location = new System.Drawing.Point(88, 116);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.ReadOnly = true;
            this.descriptionTextBox.Size = new System.Drawing.Size(239, 62);
            this.descriptionTextBox.TabIndex = 9;
            // 
            // sQLTechnicianBindingSource
            // 
            this.sQLTechnicianBindingSource.DataSource = typeof(TechSupportData.SQLTechnician);
            // 
            // technicianComboBox
            // 
            this.technicianComboBox.DisplayMember = "Name";
            this.technicianComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.technicianComboBox.FormattingEnabled = true;
            this.technicianComboBox.Location = new System.Drawing.Point(88, 184);
            this.technicianComboBox.Name = "technicianComboBox";
            this.technicianComboBox.Size = new System.Drawing.Size(181, 21);
            this.technicianComboBox.TabIndex = 11;
            this.technicianComboBox.ValueMember = "TechID";
            this.technicianComboBox.SelectedIndexChanged += new System.EventHandler(this.technicianComboBox_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(88, 214);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAssign
            // 
            this.btnAssign.Location = new System.Drawing.Point(169, 214);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(75, 23);
            this.btnAssign.TabIndex = 13;
            this.btnAssign.Text = "Assign";
            this.btnAssign.UseVisualStyleBackColor = true;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // frmIncidentAssignment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 245);
            this.Controls.Add(this.btnAssign);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(nameLabel);
            this.Controls.Add(this.technicianComboBox);
            this.Controls.Add(descriptionLabel);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(titleLabel);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(dateOpenedLabel);
            this.Controls.Add(this.dateOpenedTextBox);
            this.Controls.Add(productCodeLabel);
            this.Controls.Add(this.productCodeTextBox);
            this.Controls.Add(incidentIDLabel);
            this.Controls.Add(this.incidentIDTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIncidentAssignment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Assign Incident";
            this.Load += new System.EventHandler(this.frmIncidentAssignment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sQLIncidentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sQLTechnicianBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource sQLIncidentBindingSource;
        private System.Windows.Forms.TextBox incidentIDTextBox;
        private System.Windows.Forms.TextBox productCodeTextBox;
        private System.Windows.Forms.TextBox dateOpenedTextBox;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.BindingSource sQLTechnicianBindingSource;
        private System.Windows.Forms.ComboBox technicianComboBox;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAssign;
    }
}