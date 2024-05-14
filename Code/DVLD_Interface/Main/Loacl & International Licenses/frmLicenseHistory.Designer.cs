namespace DVLD_Interface
{
    partial class frmLicenseHistory
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTotalLocalRecords = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbDriverLicenses = new System.Windows.Forms.GroupBox();
            this.tcLicensesHistory = new System.Windows.Forms.TabControl();
            this.tpLocal = new System.Windows.Forms.TabPage();
            this.dgvLocal = new System.Windows.Forms.DataGridView();
            this.cmsLocalLicenses = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLocalLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.tpInternational = new System.Windows.Forms.TabPage();
            this.lblTotalInternationalRecords = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvInternational = new System.Windows.Forms.DataGridView();
            this.cmsInternationalLicenses = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showInternationalLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.ctrPersonCardWithSearchBar1 = new DVLD_Interface.ctrPersonCardWithSearchBar();
            this.gbDriverLicenses.SuspendLayout();
            this.tcLicensesHistory.SuspendLayout();
            this.tpLocal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocal)).BeginInit();
            this.cmsLocalLicenses.SuspendLayout();
            this.tpInternational.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternational)).BeginInit();
            this.cmsInternationalLicenses.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTitle.Location = new System.Drawing.Point(412, 19);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(306, 48);
            this.lblTitle.TabIndex = 35;
            this.lblTitle.Tag = "";
            this.lblTitle.Text = "License History";
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.BackColor = System.Drawing.Color.Crimson;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = global::DVLD_Interface.Properties.Resources.close_gray;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1021, 781);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(137, 56);
            this.btnClose.TabIndex = 38;
            this.btnClose.Text = "       Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTotalLocalRecords
            // 
            this.lblTotalLocalRecords.AutoSize = true;
            this.lblTotalLocalRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalLocalRecords.Location = new System.Drawing.Point(141, 163);
            this.lblTotalLocalRecords.Name = "lblTotalLocalRecords";
            this.lblTotalLocalRecords.Size = new System.Drawing.Size(24, 25);
            this.lblTotalLocalRecords.TabIndex = 37;
            this.lblTotalLocalRecords.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 25);
            this.label1.TabIndex = 36;
            this.label1.Text = "# Records:";
            // 
            // gbDriverLicenses
            // 
            this.gbDriverLicenses.Controls.Add(this.tcLicensesHistory);
            this.gbDriverLicenses.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDriverLicenses.Location = new System.Drawing.Point(27, 509);
            this.gbDriverLicenses.Name = "gbDriverLicenses";
            this.gbDriverLicenses.Size = new System.Drawing.Size(1127, 269);
            this.gbDriverLicenses.TabIndex = 39;
            this.gbDriverLicenses.TabStop = false;
            this.gbDriverLicenses.Text = "Driver Licenses";
            // 
            // tcLicensesHistory
            // 
            this.tcLicensesHistory.Controls.Add(this.tpLocal);
            this.tcLicensesHistory.Controls.Add(this.tpInternational);
            this.tcLicensesHistory.Location = new System.Drawing.Point(16, 38);
            this.tcLicensesHistory.Name = "tcLicensesHistory";
            this.tcLicensesHistory.SelectedIndex = 0;
            this.tcLicensesHistory.Size = new System.Drawing.Size(1097, 225);
            this.tcLicensesHistory.TabIndex = 0;
            // 
            // tpLocal
            // 
            this.tpLocal.BackColor = System.Drawing.Color.White;
            this.tpLocal.Controls.Add(this.dgvLocal);
            this.tpLocal.Controls.Add(this.label2);
            this.tpLocal.Controls.Add(this.lblTotalLocalRecords);
            this.tpLocal.Controls.Add(this.label1);
            this.tpLocal.Location = new System.Drawing.Point(4, 29);
            this.tpLocal.Name = "tpLocal";
            this.tpLocal.Padding = new System.Windows.Forms.Padding(3);
            this.tpLocal.Size = new System.Drawing.Size(1089, 192);
            this.tpLocal.TabIndex = 0;
            this.tpLocal.Text = "Local";
            // 
            // dgvLocal
            // 
            this.dgvLocal.AllowUserToAddRows = false;
            this.dgvLocal.AllowUserToDeleteRows = false;
            this.dgvLocal.AllowUserToOrderColumns = true;
            this.dgvLocal.BackgroundColor = System.Drawing.Color.White;
            this.dgvLocal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocal.ContextMenuStrip = this.cmsLocalLicenses;
            this.dgvLocal.Location = new System.Drawing.Point(11, 40);
            this.dgvLocal.Name = "dgvLocal";
            this.dgvLocal.ReadOnly = true;
            this.dgvLocal.RowHeadersWidth = 51;
            this.dgvLocal.RowTemplate.Height = 24;
            this.dgvLocal.Size = new System.Drawing.Size(1064, 120);
            this.dgvLocal.TabIndex = 38;
            // 
            // cmsLocalLicenses
            // 
            this.cmsLocalLicenses.BackColor = System.Drawing.Color.White;
            this.cmsLocalLicenses.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmsLocalLicenses.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsLocalLicenses.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLocalLicenseToolStripMenuItem});
            this.cmsLocalLicenses.Name = "contextMenuStrip1";
            this.cmsLocalLicenses.Size = new System.Drawing.Size(262, 34);
            // 
            // showLocalLicenseToolStripMenuItem
            // 
            this.showLocalLicenseToolStripMenuItem.Image = global::DVLD_Interface.Properties.Resources.driving_license2;
            this.showLocalLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showLocalLicenseToolStripMenuItem.Name = "showLocalLicenseToolStripMenuItem";
            this.showLocalLicenseToolStripMenuItem.Size = new System.Drawing.Size(261, 30);
            this.showLocalLicenseToolStripMenuItem.Text = "Show License Details";
            this.showLocalLicenseToolStripMenuItem.Click += new System.EventHandler(this.showLocalLicenseToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(236, 25);
            this.label2.TabIndex = 37;
            this.label2.Text = "Local Licenses History:";
            // 
            // tpInternational
            // 
            this.tpInternational.BackColor = System.Drawing.Color.White;
            this.tpInternational.Controls.Add(this.lblTotalInternationalRecords);
            this.tpInternational.Controls.Add(this.label5);
            this.tpInternational.Controls.Add(this.dgvInternational);
            this.tpInternational.Controls.Add(this.label3);
            this.tpInternational.Location = new System.Drawing.Point(4, 29);
            this.tpInternational.Name = "tpInternational";
            this.tpInternational.Padding = new System.Windows.Forms.Padding(3);
            this.tpInternational.Size = new System.Drawing.Size(1089, 192);
            this.tpInternational.TabIndex = 1;
            this.tpInternational.Text = "International";
            // 
            // lblTotalInternationalRecords
            // 
            this.lblTotalInternationalRecords.AutoSize = true;
            this.lblTotalInternationalRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalInternationalRecords.Location = new System.Drawing.Point(141, 163);
            this.lblTotalInternationalRecords.Name = "lblTotalInternationalRecords";
            this.lblTotalInternationalRecords.Size = new System.Drawing.Size(24, 25);
            this.lblTotalInternationalRecords.TabIndex = 42;
            this.lblTotalInternationalRecords.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 25);
            this.label5.TabIndex = 41;
            this.label5.Text = "# Records:";
            // 
            // dgvInternational
            // 
            this.dgvInternational.AllowUserToAddRows = false;
            this.dgvInternational.AllowUserToDeleteRows = false;
            this.dgvInternational.AllowUserToOrderColumns = true;
            this.dgvInternational.BackgroundColor = System.Drawing.Color.White;
            this.dgvInternational.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternational.ContextMenuStrip = this.cmsInternationalLicenses;
            this.dgvInternational.Location = new System.Drawing.Point(11, 40);
            this.dgvInternational.Name = "dgvInternational";
            this.dgvInternational.ReadOnly = true;
            this.dgvInternational.RowHeadersWidth = 51;
            this.dgvInternational.RowTemplate.Height = 24;
            this.dgvInternational.Size = new System.Drawing.Size(1064, 120);
            this.dgvInternational.TabIndex = 40;
            // 
            // cmsInternationalLicenses
            // 
            this.cmsInternationalLicenses.BackColor = System.Drawing.Color.White;
            this.cmsInternationalLicenses.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmsInternationalLicenses.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsInternationalLicenses.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showInternationalLicenseToolStripMenuItem});
            this.cmsInternationalLicenses.Name = "contextMenuStrip1";
            this.cmsInternationalLicenses.Size = new System.Drawing.Size(262, 62);
            // 
            // showInternationalLicenseToolStripMenuItem
            // 
            this.showInternationalLicenseToolStripMenuItem.Image = global::DVLD_Interface.Properties.Resources.driving_license2;
            this.showInternationalLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showInternationalLicenseToolStripMenuItem.Name = "showInternationalLicenseToolStripMenuItem";
            this.showInternationalLicenseToolStripMenuItem.Size = new System.Drawing.Size(261, 30);
            this.showInternationalLicenseToolStripMenuItem.Text = "Show License Details";
            this.showInternationalLicenseToolStripMenuItem.Click += new System.EventHandler(this.showInternationalLicenseToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(303, 25);
            this.label3.TabIndex = 39;
            this.label3.Text = "International Licenses History:";
            // 
            // ctrPersonCardWithSearchBar1
            // 
            this.ctrPersonCardWithSearchBar1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctrPersonCardWithSearchBar1.BackColor = System.Drawing.Color.White;
            this.ctrPersonCardWithSearchBar1.Location = new System.Drawing.Point(27, 70);
            this.ctrPersonCardWithSearchBar1.MaximumSize = new System.Drawing.Size(1174, 466);
            this.ctrPersonCardWithSearchBar1.Name = "ctrPersonCardWithSearchBar1";
            this.ctrPersonCardWithSearchBar1.Size = new System.Drawing.Size(1131, 419);
            this.ctrPersonCardWithSearchBar1.TabIndex = 0;
            // 
            // frmLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1189, 847);
            this.Controls.Add(this.gbDriverLicenses);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.ctrPersonCardWithSearchBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmLicenseHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "License History";
            this.Load += new System.EventHandler(this.frmLicenseHistory_Load);
            this.gbDriverLicenses.ResumeLayout(false);
            this.tcLicensesHistory.ResumeLayout(false);
            this.tpLocal.ResumeLayout(false);
            this.tpLocal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocal)).EndInit();
            this.cmsLocalLicenses.ResumeLayout(false);
            this.tpInternational.ResumeLayout(false);
            this.tpInternational.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternational)).EndInit();
            this.cmsInternationalLicenses.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrPersonCardWithSearchBar ctrPersonCardWithSearchBar1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTotalLocalRecords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbDriverLicenses;
        private System.Windows.Forms.TabControl tcLicensesHistory;
        private System.Windows.Forms.TabPage tpLocal;
        private System.Windows.Forms.TabPage tpInternational;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvLocal;
        private System.Windows.Forms.DataGridView dgvInternational;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotalInternationalRecords;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem showLocalLicenseToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsLocalLicenses;
        private System.Windows.Forms.ContextMenuStrip cmsInternationalLicenses;
        private System.Windows.Forms.ToolStripMenuItem showInternationalLicenseToolStripMenuItem;
    }
}