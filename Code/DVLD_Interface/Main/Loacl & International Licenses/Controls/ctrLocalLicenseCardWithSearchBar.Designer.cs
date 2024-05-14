namespace DVLD_Interface.Main.Licenses
{
    partial class ctrLocalLicenseCardWithSearchBar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbFind = new System.Windows.Forms.GroupBox();
            this.mtxtFind = new System.Windows.Forms.MaskedTextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.btnFindLicense = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ctrDriverCard1 = new DVLD_Interface.ctrDriverCard();
            this.gbFind.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFind
            // 
            this.gbFind.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbFind.Controls.Add(this.mtxtFind);
            this.gbFind.Controls.Add(this.pictureBox4);
            this.gbFind.Controls.Add(this.btnFindLicense);
            this.gbFind.Controls.Add(this.label2);
            this.gbFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.gbFind.Location = new System.Drawing.Point(2, 3);
            this.gbFind.MaximumSize = new System.Drawing.Size(1127, 92);
            this.gbFind.Name = "gbFind";
            this.gbFind.Size = new System.Drawing.Size(1127, 76);
            this.gbFind.TabIndex = 0;
            this.gbFind.TabStop = false;
            this.gbFind.Text = "Filter";
            // 
            // mtxtFind
            // 
            this.mtxtFind.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mtxtFind.Location = new System.Drawing.Point(474, 30);
            this.mtxtFind.Mask = "0000000000";
            this.mtxtFind.Name = "mtxtFind";
            this.mtxtFind.PromptChar = ' ';
            this.mtxtFind.Size = new System.Drawing.Size(268, 26);
            this.mtxtFind.TabIndex = 1;
            this.mtxtFind.ValidatingType = typeof(int);
            this.mtxtFind.Click += new System.EventHandler(this.mtxtFind_Click);
            this.mtxtFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtxtFind_KeyDown);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLD_Interface.Properties.Resources.field_numeric;
            this.pictureBox4.Location = new System.Drawing.Point(430, 27);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(38, 32);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 31;
            this.pictureBox4.TabStop = false;
            // 
            // btnFindLicense
            // 
            this.btnFindLicense.BackColor = System.Drawing.Color.SeaGreen;
            this.btnFindLicense.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnFindLicense.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFindLicense.Image = global::DVLD_Interface.Properties.Resources.search;
            this.btnFindLicense.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFindLicense.Location = new System.Drawing.Point(748, 18);
            this.btnFindLicense.Name = "btnFindLicense";
            this.btnFindLicense.Size = new System.Drawing.Size(70, 47);
            this.btnFindLicense.TabIndex = 2;
            this.btnFindLicense.UseVisualStyleBackColor = false;
            this.btnFindLicense.Click += new System.EventHandler(this.btnFindLicense_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(256, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 20);
            this.label2.TabIndex = 24;
            this.label2.Text = "Enter License ID:";
            // 
            // ctrDriverCard1
            // 
            this.ctrDriverCard1.BackColor = System.Drawing.Color.White;
            this.ctrDriverCard1.Location = new System.Drawing.Point(0, 85);
            this.ctrDriverCard1.Name = "ctrDriverCard1";
            this.ctrDriverCard1.Size = new System.Drawing.Size(1133, 354);
            this.ctrDriverCard1.TabIndex = 3;
            // 
            // ctrLocalLicenseCardWithSearchBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbFind);
            this.Controls.Add(this.ctrDriverCard1);
            this.Name = "ctrLocalLicenseCardWithSearchBar";
            this.Size = new System.Drawing.Size(1132, 437);
            this.gbFind.ResumeLayout(false);
            this.gbFind.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrDriverCard ctrDriverCard1;
        private System.Windows.Forms.GroupBox gbFind;
        private System.Windows.Forms.Button btnFindLicense;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.MaskedTextBox mtxtFind;
    }
}
