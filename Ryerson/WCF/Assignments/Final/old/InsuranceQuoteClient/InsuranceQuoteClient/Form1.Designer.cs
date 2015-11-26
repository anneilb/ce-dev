namespace InsuranceQuoteClient
{
    partial class Form1
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
            this.lblInsuredName = new System.Windows.Forms.Label();
            this.txtInsuredName = new System.Windows.Forms.TextBox();
            this.txtInsuredAddress = new System.Windows.Forms.TextBox();
            this.lblInsuredAddress = new System.Windows.Forms.Label();
            this.txtInsuredAge = new System.Windows.Forms.TextBox();
            this.lblInsuredAge = new System.Windows.Forms.Label();
            this.txtVehicleMake = new System.Windows.Forms.TextBox();
            this.lblVehicleMake = new System.Windows.Forms.Label();
            this.txtVehicleYearBuilt = new System.Windows.Forms.TextBox();
            this.lblVehicleYearBuilt = new System.Windows.Forms.Label();
            this.btnGetQuote = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblMonthlyAmount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblInsuredName
            // 
            this.lblInsuredName.AutoSize = true;
            this.lblInsuredName.Location = new System.Drawing.Point(4, 8);
            this.lblInsuredName.Name = "lblInsuredName";
            this.lblInsuredName.Size = new System.Drawing.Size(38, 13);
            this.lblInsuredName.TabIndex = 0;
            this.lblInsuredName.Text = "Name:";
            // 
            // txtInsuredName
            // 
            this.txtInsuredName.Location = new System.Drawing.Point(67, 5);
            this.txtInsuredName.Name = "txtInsuredName";
            this.txtInsuredName.Size = new System.Drawing.Size(133, 20);
            this.txtInsuredName.TabIndex = 1;
            // 
            // txtInsuredAddress
            // 
            this.txtInsuredAddress.Location = new System.Drawing.Point(67, 31);
            this.txtInsuredAddress.Name = "txtInsuredAddress";
            this.txtInsuredAddress.Size = new System.Drawing.Size(133, 20);
            this.txtInsuredAddress.TabIndex = 3;
            // 
            // lblInsuredAddress
            // 
            this.lblInsuredAddress.AutoSize = true;
            this.lblInsuredAddress.Location = new System.Drawing.Point(4, 34);
            this.lblInsuredAddress.Name = "lblInsuredAddress";
            this.lblInsuredAddress.Size = new System.Drawing.Size(48, 13);
            this.lblInsuredAddress.TabIndex = 2;
            this.lblInsuredAddress.Text = "Address:";
            // 
            // txtInsuredAge
            // 
            this.txtInsuredAge.Location = new System.Drawing.Point(67, 57);
            this.txtInsuredAge.Name = "txtInsuredAge";
            this.txtInsuredAge.Size = new System.Drawing.Size(133, 20);
            this.txtInsuredAge.TabIndex = 5;
            // 
            // lblInsuredAge
            // 
            this.lblInsuredAge.AutoSize = true;
            this.lblInsuredAge.Location = new System.Drawing.Point(4, 60);
            this.lblInsuredAge.Name = "lblInsuredAge";
            this.lblInsuredAge.Size = new System.Drawing.Size(29, 13);
            this.lblInsuredAge.TabIndex = 4;
            this.lblInsuredAge.Text = "Age:";
            // 
            // txtVehicleMake
            // 
            this.txtVehicleMake.Location = new System.Drawing.Point(67, 83);
            this.txtVehicleMake.Name = "txtVehicleMake";
            this.txtVehicleMake.Size = new System.Drawing.Size(133, 20);
            this.txtVehicleMake.TabIndex = 7;
            // 
            // lblVehicleMake
            // 
            this.lblVehicleMake.AutoSize = true;
            this.lblVehicleMake.Location = new System.Drawing.Point(4, 86);
            this.lblVehicleMake.Name = "lblVehicleMake";
            this.lblVehicleMake.Size = new System.Drawing.Size(56, 13);
            this.lblVehicleMake.TabIndex = 6;
            this.lblVehicleMake.Text = "Car Make:";
            // 
            // txtVehicleYearBuilt
            // 
            this.txtVehicleYearBuilt.Location = new System.Drawing.Point(67, 109);
            this.txtVehicleYearBuilt.Name = "txtVehicleYearBuilt";
            this.txtVehicleYearBuilt.Size = new System.Drawing.Size(133, 20);
            this.txtVehicleYearBuilt.TabIndex = 9;
            // 
            // lblVehicleYearBuilt
            // 
            this.lblVehicleYearBuilt.AutoSize = true;
            this.lblVehicleYearBuilt.Location = new System.Drawing.Point(4, 112);
            this.lblVehicleYearBuilt.Name = "lblVehicleYearBuilt";
            this.lblVehicleYearBuilt.Size = new System.Drawing.Size(55, 13);
            this.lblVehicleYearBuilt.TabIndex = 8;
            this.lblVehicleYearBuilt.Text = "Year Built:";
            // 
            // btnGetQuote
            // 
            this.btnGetQuote.Location = new System.Drawing.Point(208, 5);
            this.btnGetQuote.Name = "btnGetQuote";
            this.btnGetQuote.Size = new System.Drawing.Size(70, 24);
            this.btnGetQuote.TabIndex = 10;
            this.btnGetQuote.Text = "Get Quote";
            this.btnGetQuote.UseVisualStyleBackColor = true;
            this.btnGetQuote.Click += new System.EventHandler(this.btnGetQuote_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(208, 35);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(70, 24);
            this.btnReset.TabIndex = 11;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblMonthlyAmount
            // 
            this.lblMonthlyAmount.AutoSize = true;
            this.lblMonthlyAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonthlyAmount.Location = new System.Drawing.Point(12, 144);
            this.lblMonthlyAmount.Name = "lblMonthlyAmount";
            this.lblMonthlyAmount.Size = new System.Drawing.Size(0, 13);
            this.lblMonthlyAmount.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 167);
            this.Controls.Add(this.lblMonthlyAmount);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnGetQuote);
            this.Controls.Add(this.txtVehicleYearBuilt);
            this.Controls.Add(this.lblVehicleYearBuilt);
            this.Controls.Add(this.txtVehicleMake);
            this.Controls.Add(this.lblVehicleMake);
            this.Controls.Add(this.txtInsuredAge);
            this.Controls.Add(this.lblInsuredAge);
            this.Controls.Add(this.txtInsuredAddress);
            this.Controls.Add(this.lblInsuredAddress);
            this.Controls.Add(this.txtInsuredName);
            this.Controls.Add(this.lblInsuredName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Insurance Quote";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInsuredName;
        private System.Windows.Forms.TextBox txtInsuredName;
        private System.Windows.Forms.TextBox txtInsuredAddress;
        private System.Windows.Forms.Label lblInsuredAddress;
        private System.Windows.Forms.TextBox txtInsuredAge;
        private System.Windows.Forms.Label lblInsuredAge;
        private System.Windows.Forms.TextBox txtVehicleMake;
        private System.Windows.Forms.Label lblVehicleMake;
        private System.Windows.Forms.TextBox txtVehicleYearBuilt;
        private System.Windows.Forms.Label lblVehicleYearBuilt;
        private System.Windows.Forms.Button btnGetQuote;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblMonthlyAmount;
    }
}

