namespace SportsPro
{
    partial class frmUnassignedIncidents
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
            this.sQLIncidentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sQLIncidentDataGridView = new System.Windows.Forms.DataGridView();
            this.incidentIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateOpened = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssignIncident = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.sQLIncidentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sQLIncidentDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // sQLIncidentBindingSource
            // 
            this.sQLIncidentBindingSource.DataSource = typeof(TechSupportData.SQLIncident);
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
            this.incidentIDDataGridViewTextBoxColumn,
            this.colProductCode,
            this.colDateOpened,
            this.colTitle,
            this.colAssignIncident});
            this.sQLIncidentDataGridView.DataSource = this.sQLIncidentBindingSource;
            this.sQLIncidentDataGridView.Location = new System.Drawing.Point(12, 12);
            this.sQLIncidentDataGridView.Name = "sQLIncidentDataGridView";
            this.sQLIncidentDataGridView.ReadOnly = true;
            this.sQLIncidentDataGridView.Size = new System.Drawing.Size(568, 269);
            this.sQLIncidentDataGridView.TabIndex = 1;
            this.sQLIncidentDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.sQLIncidentDataGridView_CellContentClick);
            // 
            // incidentIDDataGridViewTextBoxColumn
            // 
            this.incidentIDDataGridViewTextBoxColumn.DataPropertyName = "IncidentID";
            this.incidentIDDataGridViewTextBoxColumn.HeaderText = "IncidentID";
            this.incidentIDDataGridViewTextBoxColumn.Name = "incidentIDDataGridViewTextBoxColumn";
            this.incidentIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.incidentIDDataGridViewTextBoxColumn.Visible = false;
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
            // colTitle
            // 
            this.colTitle.DataPropertyName = "Title";
            this.colTitle.HeaderText = "Title";
            this.colTitle.Name = "colTitle";
            this.colTitle.ReadOnly = true;
            this.colTitle.Width = 220;
            // 
            // colAssignIncident
            // 
            this.colAssignIncident.HeaderText = "";
            this.colAssignIncident.Name = "colAssignIncident";
            this.colAssignIncident.ReadOnly = true;
            this.colAssignIncident.Text = "Assign Incident";
            this.colAssignIncident.UseColumnTextForButtonValue = true;
            // 
            // frmUnassignedIncidents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 293);
            this.Controls.Add(this.sQLIncidentDataGridView);
            this.Name = "frmUnassignedIncidents";
            this.Text = "Unassigned Incidents";
            this.Load += new System.EventHandler(this.frmUnassignedIncidents_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sQLIncidentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sQLIncidentDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource sQLIncidentBindingSource;
        private System.Windows.Forms.DataGridView sQLIncidentDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn incidentIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateOpened;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
        private System.Windows.Forms.DataGridViewButtonColumn colAssignIncident;
    }
}