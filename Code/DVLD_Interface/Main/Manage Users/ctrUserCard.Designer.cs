﻿namespace DVLD_Interface
{
    partial class ctrUserCard
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
            this.gbUserInfo = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUserID = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblIsActive = new System.Windows.Forms.Label();
            this.ctrPersonCard1 = new DVLD_Interface.ctrPersonCard();
            this.gbUserInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbUserInfo
            // 
            this.gbUserInfo.Controls.Add(this.lblIsActive);
            this.gbUserInfo.Controls.Add(this.pictureBox3);
            this.gbUserInfo.Controls.Add(this.label3);
            this.gbUserInfo.Controls.Add(this.pictureBox2);
            this.gbUserInfo.Controls.Add(this.lblUserName);
            this.gbUserInfo.Controls.Add(this.label4);
            this.gbUserInfo.Controls.Add(this.pictureBox1);
            this.gbUserInfo.Controls.Add(this.lblUserID);
            this.gbUserInfo.Controls.Add(this.label1);
            this.gbUserInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbUserInfo.Location = new System.Drawing.Point(18, 345);
            this.gbUserInfo.Name = "gbUserInfo";
            this.gbUserInfo.Size = new System.Drawing.Size(1124, 103);
            this.gbUserInfo.TabIndex = 1;
            this.gbUserInfo.TabStop = false;
            this.gbUserInfo.Text = "User Information";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(73, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "User ID:";
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Location = new System.Drawing.Point(217, 44);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(45, 20);
            this.lblUserID.TabIndex = 2;
            this.lblUserID.Text = "????";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.Maroon;
            this.lblUserName.Location = new System.Drawing.Point(566, 44);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(49, 20);
            this.lblUserName.TabIndex = 7;
            this.lblUserName.Text = "????";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(407, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "User Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(836, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Is Active?";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD_Interface.Properties.Resources.lock_open;
            this.pictureBox3.Location = new System.Drawing.Point(944, 38);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(38, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 11;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_Interface.Properties.Resources.male;
            this.pictureBox2.Location = new System.Drawing.Point(522, 38);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(38, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Interface.Properties.Resources.field_numeric;
            this.pictureBox1.Location = new System.Drawing.Point(173, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // lblIsActive
            // 
            this.lblIsActive.AutoSize = true;
            this.lblIsActive.Location = new System.Drawing.Point(988, 44);
            this.lblIsActive.Name = "lblIsActive";
            this.lblIsActive.Size = new System.Drawing.Size(45, 20);
            this.lblIsActive.TabIndex = 13;
            this.lblIsActive.Text = "????";
            // 
            // ctrPersonCard1
            // 
            this.ctrPersonCard1.BackColor = System.Drawing.Color.White;
            this.ctrPersonCard1.Location = new System.Drawing.Point(0, 0);
            this.ctrPersonCard1.Name = "ctrPersonCard1";
            this.ctrPersonCard1.Size = new System.Drawing.Size(1162, 351);
            this.ctrPersonCard1.TabIndex = 0;
            // 
            // ctrUserCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbUserInfo);
            this.Controls.Add(this.ctrPersonCard1);
            this.Name = "ctrUserCard";
            this.Size = new System.Drawing.Size(1168, 468);
            this.gbUserInfo.ResumeLayout(false);
            this.gbUserInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrPersonCard ctrPersonCard1;
        private System.Windows.Forms.GroupBox gbUserInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblIsActive;
    }
}
