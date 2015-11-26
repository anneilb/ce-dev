namespace ClientApp
{
    partial class frmCalculator
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
            this.lblChequing = new System.Windows.Forms.Label();
            this.txtTotalChequing = new System.Windows.Forms.TextBox();
            this.txtTotalSavings = new System.Windows.Forms.TextBox();
            this.lblSavings = new System.Windows.Forms.Label();
            this.txtTotalRRSP = new System.Windows.Forms.TextBox();
            this.lblRRSP = new System.Windows.Forms.Label();
            this.txtTermInYears = new System.Windows.Forms.TextBox();
            this.lblTerm = new System.Windows.Forms.Label();
            this.txtInterestRate = new System.Windows.Forms.TextBox();
            this.lblInterestRate = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtFutureValue = new System.Windows.Forms.TextBox();
            this.lblFutureValue = new System.Windows.Forms.Label();
            this.btnClearAllFields = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblChequing
            // 
            this.lblChequing.AutoSize = true;
            this.lblChequing.Location = new System.Drawing.Point(7, 11);
            this.lblChequing.Name = "lblChequing";
            this.lblChequing.Size = new System.Drawing.Size(137, 13);
            this.lblChequing.TabIndex = 0;
            this.lblChequing.Text = "Total of Chequing Account:";
            // 
            // txtTotalChequing
            // 
            this.txtTotalChequing.Location = new System.Drawing.Point(147, 8);
            this.txtTotalChequing.Name = "txtTotalChequing";
            this.txtTotalChequing.Size = new System.Drawing.Size(100, 20);
            this.txtTotalChequing.TabIndex = 1;
            // 
            // txtTotalSavings
            // 
            this.txtTotalSavings.Location = new System.Drawing.Point(147, 34);
            this.txtTotalSavings.Name = "txtTotalSavings";
            this.txtTotalSavings.Size = new System.Drawing.Size(100, 20);
            this.txtTotalSavings.TabIndex = 3;
            // 
            // lblSavings
            // 
            this.lblSavings.AutoSize = true;
            this.lblSavings.Location = new System.Drawing.Point(7, 37);
            this.lblSavings.Name = "lblSavings";
            this.lblSavings.Size = new System.Drawing.Size(130, 13);
            this.lblSavings.TabIndex = 2;
            this.lblSavings.Text = "Total of Savings Account:";
            // 
            // txtTotalRRSP
            // 
            this.txtTotalRRSP.Location = new System.Drawing.Point(147, 60);
            this.txtTotalRRSP.Name = "txtTotalRRSP";
            this.txtTotalRRSP.Size = new System.Drawing.Size(100, 20);
            this.txtTotalRRSP.TabIndex = 5;
            // 
            // lblRRSP
            // 
            this.lblRRSP.AutoSize = true;
            this.lblRRSP.Location = new System.Drawing.Point(7, 63);
            this.lblRRSP.Name = "lblRRSP";
            this.lblRRSP.Size = new System.Drawing.Size(118, 13);
            this.lblRRSP.TabIndex = 4;
            this.lblRRSP.Text = "Total in RRSPAccount:";
            // 
            // txtTermInYears
            // 
            this.txtTermInYears.Location = new System.Drawing.Point(147, 86);
            this.txtTermInYears.Name = "txtTermInYears";
            this.txtTermInYears.Size = new System.Drawing.Size(100, 20);
            this.txtTermInYears.TabIndex = 7;
            // 
            // lblTerm
            // 
            this.lblTerm.AutoSize = true;
            this.lblTerm.Location = new System.Drawing.Point(7, 89);
            this.lblTerm.Name = "lblTerm";
            this.lblTerm.Size = new System.Drawing.Size(75, 13);
            this.lblTerm.TabIndex = 6;
            this.lblTerm.Text = "Term in Years:";
            // 
            // txtInterestRate
            // 
            this.txtInterestRate.Location = new System.Drawing.Point(147, 112);
            this.txtInterestRate.Name = "txtInterestRate";
            this.txtInterestRate.Size = new System.Drawing.Size(100, 20);
            this.txtInterestRate.TabIndex = 9;
            // 
            // lblInterestRate
            // 
            this.lblInterestRate.AutoSize = true;
            this.lblInterestRate.Location = new System.Drawing.Point(7, 115);
            this.lblInterestRate.Name = "lblInterestRate";
            this.lblInterestRate.Size = new System.Drawing.Size(82, 13);
            this.lblInterestRate.TabIndex = 8;
            this.lblInterestRate.Text = "Interest Rate %:";
            // 
            // btnCalculate
            // 
            this.btnCalculate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCalculate.Location = new System.Drawing.Point(256, 6);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 12;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(256, 66);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 14;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtFutureValue
            // 
            this.txtFutureValue.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtFutureValue.Enabled = false;
            this.txtFutureValue.Location = new System.Drawing.Point(147, 152);
            this.txtFutureValue.Name = "txtFutureValue";
            this.txtFutureValue.Size = new System.Drawing.Size(100, 20);
            this.txtFutureValue.TabIndex = 11;
            // 
            // lblFutureValue
            // 
            this.lblFutureValue.AutoSize = true;
            this.lblFutureValue.Location = new System.Drawing.Point(7, 155);
            this.lblFutureValue.Name = "lblFutureValue";
            this.lblFutureValue.Size = new System.Drawing.Size(70, 13);
            this.lblFutureValue.TabIndex = 10;
            this.lblFutureValue.Text = "Future Value:";
            // 
            // btnClearAllFields
            // 
            this.btnClearAllFields.Location = new System.Drawing.Point(256, 37);
            this.btnClearAllFields.Name = "btnClearAllFields";
            this.btnClearAllFields.Size = new System.Drawing.Size(75, 23);
            this.btnClearAllFields.TabIndex = 13;
            this.btnClearAllFields.Text = "Clear All";
            this.btnClearAllFields.UseVisualStyleBackColor = true;
            this.btnClearAllFields.Click += new System.EventHandler(this.btnClearAllFields_Click);
            // 
            // frmCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 179);
            this.Controls.Add(this.btnClearAllFields);
            this.Controls.Add(this.txtFutureValue);
            this.Controls.Add(this.lblFutureValue);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.txtInterestRate);
            this.Controls.Add(this.lblInterestRate);
            this.Controls.Add(this.txtTermInYears);
            this.Controls.Add(this.lblTerm);
            this.Controls.Add(this.txtTotalRRSP);
            this.Controls.Add(this.lblRRSP);
            this.Controls.Add(this.txtTotalSavings);
            this.Controls.Add(this.lblSavings);
            this.Controls.Add(this.txtTotalChequing);
            this.Controls.Add(this.lblChequing);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmCalculator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Future Value Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblChequing;
        private System.Windows.Forms.TextBox txtTotalChequing;
        private System.Windows.Forms.TextBox txtTotalSavings;
        private System.Windows.Forms.Label lblSavings;
        private System.Windows.Forms.TextBox txtTotalRRSP;
        private System.Windows.Forms.Label lblRRSP;
        private System.Windows.Forms.TextBox txtTermInYears;
        private System.Windows.Forms.Label lblTerm;
        private System.Windows.Forms.TextBox txtInterestRate;
        private System.Windows.Forms.Label lblInterestRate;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtFutureValue;
        private System.Windows.Forms.Label lblFutureValue;
        private System.Windows.Forms.Button btnClearAllFields;
    }
}

