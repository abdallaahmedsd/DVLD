namespace DVLD_Interface.Main.Licenses
{
    partial class frmManageInternationalLicenses
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
            this.txtFilterBy = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.lblTotalRecords = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_IDL_Apps = new System.Windows.Forms.DataGridView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnNewInternationalLicense = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.showPersonDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.licenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_IDL_App_CRUD = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_IDL_Apps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.cms_IDL_App_CRUD.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFilterBy
            // 
            this.txtFilterBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilterBy.Location = new System.Drawing.Point(374, 254);
            this.txtFilterBy.Multiline = true;
            this.txtFilterBy.Name = "txtFilterBy";
            this.txtFilterBy.Size = new System.Drawing.Size(231, 28);
            this.txtFilterBy.TabIndex = 43;
            this.txtFilterBy.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFilterBy_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 257);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 25);
            this.label2.TabIndex = 42;
            this.label2.Text = "Filter By:";
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.BackColor = System.Drawing.Color.White;
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.ItemHeight = 20;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "Driver ID",
            "Int.License ID",
            "Local License ID"});
            this.cbFilterBy.Location = new System.Drawing.Point(142, 254);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(226, 28);
            this.cbFilterBy.TabIndex = 41;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // lblTotalRecords
            // 
            this.lblTotalRecords.AutoSize = true;
            this.lblTotalRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRecords.Location = new System.Drawing.Point(165, 712);
            this.lblTotalRecords.Name = "lblTotalRecords";
            this.lblTotalRecords.Size = new System.Drawing.Size(24, 25);
            this.lblTotalRecords.TabIndex = 38;
            this.lblTotalRecords.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 712);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 25);
            this.label1.TabIndex = 37;
            this.label1.Text = "# Records:";
            // 
            // dgv_IDL_Apps
            // 
            this.dgv_IDL_Apps.AllowUserToAddRows = false;
            this.dgv_IDL_Apps.AllowUserToDeleteRows = false;
            this.dgv_IDL_Apps.AllowUserToOrderColumns = true;
            this.dgv_IDL_Apps.BackgroundColor = System.Drawing.Color.White;
            this.dgv_IDL_Apps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_IDL_Apps.ContextMenuStrip = this.cms_IDL_App_CRUD;
            this.dgv_IDL_Apps.Location = new System.Drawing.Point(32, 298);
            this.dgv_IDL_Apps.Name = "dgv_IDL_Apps";
            this.dgv_IDL_Apps.ReadOnly = true;
            this.dgv_IDL_Apps.RowHeadersWidth = 51;
            this.dgv_IDL_Apps.RowTemplate.Height = 24;
            this.dgv_IDL_Apps.Size = new System.Drawing.Size(1351, 380);
            this.dgv_IDL_Apps.TabIndex = 36;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(220, 164);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(958, 48);
            this.lblTitle.TabIndex = 35;
            this.lblTitle.Text = "Manage International  Driving License Applications";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_Interface.Properties.Resources.world1;
            this.pictureBox2.Location = new System.Drawing.Point(569, 37);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(49, 41);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 44;
            this.pictureBox2.TabStop = false;
            // 
            // btnNewInternationalLicense
            // 
            this.btnNewInternationalLicense.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNewInternationalLicense.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewInternationalLicense.Image = global::DVLD_Interface.Properties.Resources.personal_card_add;
            this.btnNewInternationalLicense.Location = new System.Drawing.Point(1294, 230);
            this.btnNewInternationalLicense.Name = "btnNewInternationalLicense";
            this.btnNewInternationalLicense.Size = new System.Drawing.Size(89, 62);
            this.btnNewInternationalLicense.TabIndex = 40;
            this.btnNewInternationalLicense.UseVisualStyleBackColor = true;
            this.btnNewInternationalLicense.Click += new System.EventHandler(this.btnNewInternationalLicense_Click);
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
            this.btnClose.Location = new System.Drawing.Point(1246, 696);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(137, 56);
            this.btnClose.TabIndex = 39;
            this.btnClose.Text = "       Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Interface.Properties.Resources.application_list;
            this.pictureBox1.Location = new System.Drawing.Point(593, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(174, 135);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // showPersonDetailsToolStripMenuItem
            // 
            this.showPersonDetailsToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showPersonDetailsToolStripMenuItem.Image = global::DVLD_Interface.Properties.Resources.view_details_small1;
            this.showPersonDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showPersonDetailsToolStripMenuItem.Name = "showPersonDetailsToolStripMenuItem";
            this.showPersonDetailsToolStripMenuItem.Size = new System.Drawing.Size(319, 38);
            this.showPersonDetailsToolStripMenuItem.Text = "Show Person Details";
            this.showPersonDetailsToolStripMenuItem.Click += new System.EventHandler(this.showPersonDetailsToolStripMenuItem_Click);
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Image = global::DVLD_Interface.Properties.Resources.driving_license2;
            this.showLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(319, 38);
            this.showLicenseToolStripMenuItem.Text = "Show License";
            this.showLicenseToolStripMenuItem.Click += new System.EventHandler(this.showLicenseToolStripMenuItem_Click);
            // 
            // licenseHistoryToolStripMenuItem
            // 
            this.licenseHistoryToolStripMenuItem.Image = global::DVLD_Interface.Properties.Resources.license_history;
            this.licenseHistoryToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.licenseHistoryToolStripMenuItem.Name = "licenseHistoryToolStripMenuItem";
            this.licenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(319, 38);
            this.licenseHistoryToolStripMenuItem.Text = "Show Person License History";
            this.licenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.licenseHistoryToolStripMenuItem_Click);
            // 
            // cms_IDL_App_CRUD
            // 
            this.cms_IDL_App_CRUD.BackColor = System.Drawing.Color.White;
            this.cms_IDL_App_CRUD.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cms_IDL_App_CRUD.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cms_IDL_App_CRUD.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPersonDetailsToolStripMenuItem,
            this.showLicenseToolStripMenuItem,
            this.licenseHistoryToolStripMenuItem});
            this.cms_IDL_App_CRUD.Name = "contextMenuStrip1";
            this.cms_IDL_App_CRUD.Size = new System.Drawing.Size(320, 118);
            // 
            // frmManageInternationalLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1412, 764);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.txtFilterBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.btnNewInternationalLicense);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTotalRecords);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_IDL_Apps);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmManageInternationalLicenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage International Licenses";
            this.Load += new System.EventHandler(this.frmManageInternationalLicenses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_IDL_Apps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.cms_IDL_App_CRUD.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtFilterBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Button btnNewInternationalLicense;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTotalRecords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_IDL_Apps;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip cms_IDL_App_CRUD;
        private System.Windows.Forms.ToolStripMenuItem showPersonDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem licenseHistoryToolStripMenuItem;
    }
}