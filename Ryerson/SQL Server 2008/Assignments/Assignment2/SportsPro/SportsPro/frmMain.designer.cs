namespace SportsPro
{
    partial class frmMain
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
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileExportTechnicianIncidents = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMaintenance = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMaintenanceMaintainProducts = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMaintenanceMaintainCustomers = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMaintenanceMaintainTechnicians = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRegistration = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRegistrationRegisterProducts = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRegistrationDisplayProductsByCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRegistrationDisplayCustomersByProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIncidents = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIncidentsCreateIncident = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIncidentsAssignIncidents = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIncidentsUpdateIncident = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIncidentsDisplayOpenIncidents = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIncidentsDisplayOpenIncidentsByTechnician = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIncidentsDisplayIncidentsbyProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIncidentsDisplayIncidentSummaryByProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIncidentsDisplayIncidentsByCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblName = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnuMain.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuMaintenance,
            this.mnuRegistration,
            this.mnuIncidents});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(632, 24);
            this.mnuMain.TabIndex = 1;
            this.mnuMain.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileExportTechnicianIncidents,
            this.mnuFileExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(35, 20);
            this.mnuFile.Text = "File";
            // 
            // mnuFileExportTechnicianIncidents
            // 
            this.mnuFileExportTechnicianIncidents.Name = "mnuFileExportTechnicianIncidents";
            this.mnuFileExportTechnicianIncidents.Size = new System.Drawing.Size(217, 22);
            this.mnuFileExportTechnicianIncidents.Text = "Export Technician Incidents";
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(217, 22);
            this.mnuFileExit.Text = "Exit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // mnuMaintenance
            // 
            this.mnuMaintenance.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMaintenanceMaintainProducts,
            this.mnuMaintenanceMaintainCustomers,
            this.mnuMaintenanceMaintainTechnicians});
            this.mnuMaintenance.Name = "mnuMaintenance";
            this.mnuMaintenance.Size = new System.Drawing.Size(80, 20);
            this.mnuMaintenance.Text = "Maintenance";
            // 
            // mnuMaintenanceMaintainProducts
            // 
            this.mnuMaintenanceMaintainProducts.Name = "mnuMaintenanceMaintainProducts";
            this.mnuMaintenanceMaintainProducts.Size = new System.Drawing.Size(183, 22);
            this.mnuMaintenanceMaintainProducts.Text = "Maintain Products";
            this.mnuMaintenanceMaintainProducts.Click += new System.EventHandler(this.mnuMaintenanceMaintainProducts_Click);
            // 
            // mnuMaintenanceMaintainCustomers
            // 
            this.mnuMaintenanceMaintainCustomers.Name = "mnuMaintenanceMaintainCustomers";
            this.mnuMaintenanceMaintainCustomers.Size = new System.Drawing.Size(183, 22);
            this.mnuMaintenanceMaintainCustomers.Text = "Maintain Customers";
            this.mnuMaintenanceMaintainCustomers.Click += new System.EventHandler(this.mnuMaintenanceMaintainCustomers_Click);
            // 
            // mnuMaintenanceMaintainTechnicians
            // 
            this.mnuMaintenanceMaintainTechnicians.Name = "mnuMaintenanceMaintainTechnicians";
            this.mnuMaintenanceMaintainTechnicians.Size = new System.Drawing.Size(183, 22);
            this.mnuMaintenanceMaintainTechnicians.Text = "Maintain Technicians";
            // 
            // mnuRegistration
            // 
            this.mnuRegistration.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRegistrationRegisterProducts,
            this.mnuRegistrationDisplayProductsByCustomer,
            this.mnuRegistrationDisplayCustomersByProduct});
            this.mnuRegistration.Name = "mnuRegistration";
            this.mnuRegistration.Size = new System.Drawing.Size(77, 20);
            this.mnuRegistration.Text = "Registration";
            // 
            // mnuRegistrationRegisterProducts
            // 
            this.mnuRegistrationRegisterProducts.Name = "mnuRegistrationRegisterProducts";
            this.mnuRegistrationRegisterProducts.Size = new System.Drawing.Size(228, 22);
            this.mnuRegistrationRegisterProducts.Text = "Register Products";
            // 
            // mnuRegistrationDisplayProductsByCustomer
            // 
            this.mnuRegistrationDisplayProductsByCustomer.Name = "mnuRegistrationDisplayProductsByCustomer";
            this.mnuRegistrationDisplayProductsByCustomer.Size = new System.Drawing.Size(228, 22);
            this.mnuRegistrationDisplayProductsByCustomer.Text = "Display Products by Customer";
            // 
            // mnuRegistrationDisplayCustomersByProduct
            // 
            this.mnuRegistrationDisplayCustomersByProduct.Name = "mnuRegistrationDisplayCustomersByProduct";
            this.mnuRegistrationDisplayCustomersByProduct.Size = new System.Drawing.Size(228, 22);
            this.mnuRegistrationDisplayCustomersByProduct.Text = "Display Customers by Product";
            // 
            // mnuIncidents
            // 
            this.mnuIncidents.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuIncidentsCreateIncident,
            this.mnuIncidentsAssignIncidents,
            this.mnuIncidentsUpdateIncident,
            this.mnuIncidentsDisplayOpenIncidents,
            this.mnuIncidentsDisplayOpenIncidentsByTechnician,
            this.mnuIncidentsDisplayIncidentsbyProduct,
            this.mnuIncidentsDisplayIncidentSummaryByProduct,
            this.mnuIncidentsDisplayIncidentsByCustomer});
            this.mnuIncidents.Name = "mnuIncidents";
            this.mnuIncidents.Size = new System.Drawing.Size(63, 20);
            this.mnuIncidents.Text = "Incidents";
            // 
            // mnuIncidentsCreateIncident
            // 
            this.mnuIncidentsCreateIncident.Name = "mnuIncidentsCreateIncident";
            this.mnuIncidentsCreateIncident.Size = new System.Drawing.Size(263, 22);
            this.mnuIncidentsCreateIncident.Text = "Create Incident";
            this.mnuIncidentsCreateIncident.Click += new System.EventHandler(this.mnuIncidentsCreateIncident_Click);
            // 
            // mnuIncidentsAssignIncidents
            // 
            this.mnuIncidentsAssignIncidents.Name = "mnuIncidentsAssignIncidents";
            this.mnuIncidentsAssignIncidents.Size = new System.Drawing.Size(263, 22);
            this.mnuIncidentsAssignIncidents.Text = "Assign Incidents";
            // 
            // mnuIncidentsUpdateIncident
            // 
            this.mnuIncidentsUpdateIncident.Name = "mnuIncidentsUpdateIncident";
            this.mnuIncidentsUpdateIncident.Size = new System.Drawing.Size(263, 22);
            this.mnuIncidentsUpdateIncident.Text = "Update Incident";
            // 
            // mnuIncidentsDisplayOpenIncidents
            // 
            this.mnuIncidentsDisplayOpenIncidents.Name = "mnuIncidentsDisplayOpenIncidents";
            this.mnuIncidentsDisplayOpenIncidents.Size = new System.Drawing.Size(263, 22);
            this.mnuIncidentsDisplayOpenIncidents.Text = "Display Open Incidents";
            this.mnuIncidentsDisplayOpenIncidents.Click += new System.EventHandler(this.mnuIncidentsDisplayOpenIncidents_Click);
            // 
            // mnuIncidentsDisplayOpenIncidentsByTechnician
            // 
            this.mnuIncidentsDisplayOpenIncidentsByTechnician.Name = "mnuIncidentsDisplayOpenIncidentsByTechnician";
            this.mnuIncidentsDisplayOpenIncidentsByTechnician.Size = new System.Drawing.Size(263, 22);
            this.mnuIncidentsDisplayOpenIncidentsByTechnician.Text = "Display Open Incidents by Technician";
            this.mnuIncidentsDisplayOpenIncidentsByTechnician.Click += new System.EventHandler(this.mnuIncidentsDisplayOpenIncidentsByTechnician_Click);
            // 
            // mnuIncidentsDisplayIncidentsbyProduct
            // 
            this.mnuIncidentsDisplayIncidentsbyProduct.Name = "mnuIncidentsDisplayIncidentsbyProduct";
            this.mnuIncidentsDisplayIncidentsbyProduct.Size = new System.Drawing.Size(263, 22);
            this.mnuIncidentsDisplayIncidentsbyProduct.Text = "Display Incidents by Product";
            this.mnuIncidentsDisplayIncidentsbyProduct.Click += new System.EventHandler(this.mnuIncidentsDisplayIncidentsbyProduct_Click);
            // 
            // mnuIncidentsDisplayIncidentSummaryByProduct
            // 
            this.mnuIncidentsDisplayIncidentSummaryByProduct.Name = "mnuIncidentsDisplayIncidentSummaryByProduct";
            this.mnuIncidentsDisplayIncidentSummaryByProduct.Size = new System.Drawing.Size(263, 22);
            this.mnuIncidentsDisplayIncidentSummaryByProduct.Text = "Display Incident Summary by Product";
            // 
            // mnuIncidentsDisplayIncidentsByCustomer
            // 
            this.mnuIncidentsDisplayIncidentsByCustomer.Name = "mnuIncidentsDisplayIncidentsByCustomer";
            this.mnuIncidentsDisplayIncidentsByCustomer.Size = new System.Drawing.Size(263, 22);
            this.mnuIncidentsDisplayIncidentsByCustomer.Text = "Display Incidents by Customer";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblName});
            this.statusStrip1.Location = new System.Drawing.Point(0, 431);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(632, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblName
            // 
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(163, 17);
            this.lblName.Text = "Student Name: Anneil Balkissoon";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mnuMain);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuMain;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SportsPro System";
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuMaintenance;
        private System.Windows.Forms.ToolStripMenuItem mnuRegistration;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExportTechnicianIncidents;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.ToolStripMenuItem mnuIncidents;
        private System.Windows.Forms.ToolStripMenuItem mnuMaintenanceMaintainProducts;
        private System.Windows.Forms.ToolStripMenuItem mnuMaintenanceMaintainCustomers;
        private System.Windows.Forms.ToolStripMenuItem mnuMaintenanceMaintainTechnicians;
        private System.Windows.Forms.ToolStripMenuItem mnuRegistrationRegisterProducts;
        private System.Windows.Forms.ToolStripMenuItem mnuRegistrationDisplayProductsByCustomer;
        private System.Windows.Forms.ToolStripMenuItem mnuRegistrationDisplayCustomersByProduct;
        private System.Windows.Forms.ToolStripMenuItem mnuIncidentsCreateIncident;
        private System.Windows.Forms.ToolStripMenuItem mnuIncidentsAssignIncidents;
        private System.Windows.Forms.ToolStripMenuItem mnuIncidentsUpdateIncident;
        private System.Windows.Forms.ToolStripMenuItem mnuIncidentsDisplayOpenIncidents;
        private System.Windows.Forms.ToolStripMenuItem mnuIncidentsDisplayOpenIncidentsByTechnician;
        private System.Windows.Forms.ToolStripMenuItem mnuIncidentsDisplayIncidentsbyProduct;
        private System.Windows.Forms.ToolStripMenuItem mnuIncidentsDisplayIncidentSummaryByProduct;
        private System.Windows.Forms.ToolStripMenuItem mnuIncidentsDisplayIncidentsByCustomer;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblName;
    }
}

