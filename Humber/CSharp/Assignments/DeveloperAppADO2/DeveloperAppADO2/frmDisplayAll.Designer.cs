namespace DeveloperAppADO2
{
    partial class frmDisplayAll
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
            this.grdDisplay = new System.Windows.Forms.DataGrid();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDisplay
            // 
            this.grdDisplay.DataMember = "";
            this.grdDisplay.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.grdDisplay.Location = new System.Drawing.Point(8, 8);
            this.grdDisplay.Name = "grdDisplay";
            this.grdDisplay.ReadOnly = true;
            this.grdDisplay.Size = new System.Drawing.Size(380, 188);
            this.grdDisplay.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(396, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(64, 24);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmDisplayAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 205);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grdDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmDisplayAll";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Display All Developers\' Details";
            ((System.ComponentModel.ISupportInitialize)(this.grdDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGrid grdDisplay;
        private System.Windows.Forms.Button btnClose;
    }
}