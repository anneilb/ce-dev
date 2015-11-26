namespace SportsPro
{
    partial class frmOpenIncidents
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
            this.lvwIncidents = new System.Windows.Forms.ListView();
            this.colProductCode = new System.Windows.Forms.ColumnHeader();
            this.colDateOpened = new System.Windows.Forms.ColumnHeader();
            this.colCustomer = new System.Windows.Forms.ColumnHeader();
            this.colTechnician = new System.Windows.Forms.ColumnHeader();
            this.colTitle = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lvwIncidents
            // 
            this.lvwIncidents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwIncidents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colProductCode,
            this.colDateOpened,
            this.colCustomer,
            this.colTechnician,
            this.colTitle});
            this.lvwIncidents.Location = new System.Drawing.Point(13, 13);
            this.lvwIncidents.Name = "lvwIncidents";
            this.lvwIncidents.Size = new System.Drawing.Size(567, 268);
            this.lvwIncidents.TabIndex = 0;
            this.lvwIncidents.UseCompatibleStateImageBehavior = false;
            this.lvwIncidents.View = System.Windows.Forms.View.Details;
            // 
            // colProductCode
            // 
            this.colProductCode.Text = "Product Code";
            this.colProductCode.Width = 80;
            // 
            // colDateOpened
            // 
            this.colDateOpened.Text = "Date Opened";
            this.colDateOpened.Width = 80;
            // 
            // colCustomer
            // 
            this.colCustomer.Text = "Customer";
            this.colCustomer.Width = 110;
            // 
            // colTechnician
            // 
            this.colTechnician.Text = "Technician";
            this.colTechnician.Width = 110;
            // 
            // colTitle
            // 
            this.colTitle.Text = "Title";
            this.colTitle.Width = 180;
            // 
            // frmOpenIncidents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 293);
            this.Controls.Add(this.lvwIncidents);
            this.Name = "frmOpenIncidents";
            this.Text = "Open Incidents";
            this.Load += new System.EventHandler(this.frmOpenIncidents_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwIncidents;
        private System.Windows.Forms.ColumnHeader colProductCode;
        private System.Windows.Forms.ColumnHeader colDateOpened;
        private System.Windows.Forms.ColumnHeader colCustomer;
        private System.Windows.Forms.ColumnHeader colTechnician;
        private System.Windows.Forms.ColumnHeader colTitle;
    }
}