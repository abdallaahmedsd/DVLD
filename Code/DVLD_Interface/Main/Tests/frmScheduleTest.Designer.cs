namespace DVLD_Interface
{
    partial class frmScheduleTest
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
            this.gbTestInfo = new System.Windows.Forms.GroupBox();
            this.lblShowMessage = new System.Windows.Forms.Label();
            this.dtpTestDate = new System.Windows.Forms.DateTimePicker();
            this.gbRetakeTestInfo = new System.Windows.Forms.GroupBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.lblRetakeTestID = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblRetakeTestFees = new System.Windows.Forms.Label();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTotalFees = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblTestFees = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.lblTrail = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pbTestImage = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblLicenseClass = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblDrivingLicenseAppID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbTestInfo.SuspendLayout();
            this.gbRetakeTestInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbTestInfo
            // 
            this.gbTestInfo.Controls.Add(this.lblShowMessage);
            this.gbTestInfo.Controls.Add(this.dtpTestDate);
            this.gbTestInfo.Controls.Add(this.gbRetakeTestInfo);
            this.gbTestInfo.Controls.Add(this.btnSave);
            this.gbTestInfo.Controls.Add(this.lblTestFees);
            this.gbTestInfo.Controls.Add(this.pictureBox4);
            this.gbTestInfo.Controls.Add(this.label2);
            this.gbTestInfo.Controls.Add(this.pictureBox6);
            this.gbTestInfo.Controls.Add(this.lblBirthDate);
            this.gbTestInfo.Controls.Add(this.lblTrail);
            this.gbTestInfo.Controls.Add(this.pictureBox5);
            this.gbTestInfo.Controls.Add(this.label5);
            this.gbTestInfo.Controls.Add(this.lblName);
            this.gbTestInfo.Controls.Add(this.pictureBox7);
            this.gbTestInfo.Controls.Add(this.label9);
            this.gbTestInfo.Controls.Add(this.lblTitle);
            this.gbTestInfo.Controls.Add(this.pbTestImage);
            this.gbTestInfo.Controls.Add(this.pictureBox2);
            this.gbTestInfo.Controls.Add(this.lblLicenseClass);
            this.gbTestInfo.Controls.Add(this.label3);
            this.gbTestInfo.Controls.Add(this.pictureBox1);
            this.gbTestInfo.Controls.Add(this.lblDrivingLicenseAppID);
            this.gbTestInfo.Controls.Add(this.label1);
            this.gbTestInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTestInfo.Location = new System.Drawing.Point(16, 24);
            this.gbTestInfo.Name = "gbTestInfo";
            this.gbTestInfo.Size = new System.Drawing.Size(678, 685);
            this.gbTestInfo.TabIndex = 0;
            this.gbTestInfo.TabStop = false;
            this.gbTestInfo.Text = "VisionTest";
            // 
            // lblShowMessage
            // 
            this.lblShowMessage.AutoSize = true;
            this.lblShowMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowMessage.ForeColor = System.Drawing.Color.Red;
            this.lblShowMessage.Location = new System.Drawing.Point(49, 185);
            this.lblShowMessage.Name = "lblShowMessage";
            this.lblShowMessage.Size = new System.Drawing.Size(508, 20);
            this.lblShowMessage.TabIndex = 64;
            this.lblShowMessage.Text = "This person is already took this test. Appointment is locked";
            this.lblShowMessage.Visible = false;
            // 
            // dtpTestDate
            // 
            this.dtpTestDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTestDate.Location = new System.Drawing.Point(217, 406);
            this.dtpTestDate.Name = "dtpTestDate";
            this.dtpTestDate.Size = new System.Drawing.Size(189, 26);
            this.dtpTestDate.TabIndex = 0;
            // 
            // gbRetakeTestInfo
            // 
            this.gbRetakeTestInfo.Controls.Add(this.pictureBox10);
            this.gbRetakeTestInfo.Controls.Add(this.lblRetakeTestID);
            this.gbRetakeTestInfo.Controls.Add(this.label11);
            this.gbRetakeTestInfo.Controls.Add(this.lblRetakeTestFees);
            this.gbRetakeTestInfo.Controls.Add(this.pictureBox9);
            this.gbRetakeTestInfo.Controls.Add(this.label8);
            this.gbRetakeTestInfo.Controls.Add(this.lblTotalFees);
            this.gbRetakeTestInfo.Controls.Add(this.pictureBox8);
            this.gbRetakeTestInfo.Controls.Add(this.label6);
            this.gbRetakeTestInfo.Enabled = false;
            this.gbRetakeTestInfo.Location = new System.Drawing.Point(18, 493);
            this.gbRetakeTestInfo.Name = "gbRetakeTestInfo";
            this.gbRetakeTestInfo.Size = new System.Drawing.Size(642, 122);
            this.gbRetakeTestInfo.TabIndex = 63;
            this.gbRetakeTestInfo.TabStop = false;
            this.gbRetakeTestInfo.Text = "Retake Test Info";
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = global::DVLD_Interface.Properties.Resources.field_numeric;
            this.pictureBox10.Location = new System.Drawing.Point(136, 74);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(38, 32);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox10.TabIndex = 69;
            this.pictureBox10.TabStop = false;
            // 
            // lblRetakeTestID
            // 
            this.lblRetakeTestID.AutoSize = true;
            this.lblRetakeTestID.Location = new System.Drawing.Point(180, 80);
            this.lblRetakeTestID.Name = "lblRetakeTestID";
            this.lblRetakeTestID.Size = new System.Drawing.Size(45, 20);
            this.lblRetakeTestID.TabIndex = 68;
            this.lblRetakeTestID.Text = "????";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(13, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 20);
            this.label11.TabIndex = 67;
            this.label11.Text = "R.App ID:";
            // 
            // lblRetakeTestFees
            // 
            this.lblRetakeTestFees.AutoSize = true;
            this.lblRetakeTestFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetakeTestFees.Location = new System.Drawing.Point(180, 31);
            this.lblRetakeTestFees.Name = "lblRetakeTestFees";
            this.lblRetakeTestFees.Size = new System.Drawing.Size(45, 20);
            this.lblRetakeTestFees.TabIndex = 66;
            this.lblRetakeTestFees.Text = "????";
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = global::DVLD_Interface.Properties.Resources.money;
            this.pictureBox9.Location = new System.Drawing.Point(136, 25);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(38, 32);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox9.TabIndex = 65;
            this.pictureBox9.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 20);
            this.label8.TabIndex = 64;
            this.label8.Text = "R.App Fees:";
            // 
            // lblTotalFees
            // 
            this.lblTotalFees.AutoSize = true;
            this.lblTotalFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalFees.Location = new System.Drawing.Point(558, 31);
            this.lblTotalFees.Name = "lblTotalFees";
            this.lblTotalFees.Size = new System.Drawing.Size(45, 20);
            this.lblTotalFees.TabIndex = 63;
            this.lblTotalFees.Text = "????";
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::DVLD_Interface.Properties.Resources.money;
            this.pictureBox8.Location = new System.Drawing.Point(514, 25);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(38, 32);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 62;
            this.pictureBox8.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(394, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 20);
            this.label6.TabIndex = 61;
            this.label6.Text = "Total Fees:";
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = global::DVLD_Interface.Properties.Resources.diskette;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(523, 621);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(137, 56);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "       Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblTestFees
            // 
            this.lblTestFees.AutoSize = true;
            this.lblTestFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestFees.Location = new System.Drawing.Point(217, 453);
            this.lblTestFees.Name = "lblTestFees";
            this.lblTestFees.Size = new System.Drawing.Size(45, 20);
            this.lblTestFees.TabIndex = 60;
            this.lblTestFees.Text = "????";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLD_Interface.Properties.Resources.money;
            this.pictureBox4.Location = new System.Drawing.Point(173, 447);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(38, 32);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 59;
            this.pictureBox4.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 453);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 58;
            this.label2.Text = "Fees:";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::DVLD_Interface.Properties.Resources.calendar_week;
            this.pictureBox6.Location = new System.Drawing.Point(173, 403);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(38, 32);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 57;
            this.pictureBox6.TabStop = false;
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.AutoSize = true;
            this.lblBirthDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBirthDate.Location = new System.Drawing.Point(21, 409);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(98, 20);
            this.lblBirthDate.TabIndex = 56;
            this.lblBirthDate.Text = "Test Date:";
            // 
            // lblTrail
            // 
            this.lblTrail.AutoSize = true;
            this.lblTrail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrail.Location = new System.Drawing.Point(217, 365);
            this.lblTrail.Name = "lblTrail";
            this.lblTrail.Size = new System.Drawing.Size(18, 20);
            this.lblTrail.TabIndex = 54;
            this.lblTrail.Text = "0";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::DVLD_Interface.Properties.Resources.trails;
            this.pictureBox5.Location = new System.Drawing.Point(173, 359);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(38, 32);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 53;
            this.pictureBox5.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 365);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 20);
            this.label5.TabIndex = 52;
            this.label5.Text = "Trail:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.Maroon;
            this.lblName.Location = new System.Drawing.Point(217, 321);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(49, 20);
            this.lblName.TabIndex = 48;
            this.lblName.Text = "????";
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::DVLD_Interface.Properties.Resources.nickname;
            this.pictureBox7.Location = new System.Drawing.Point(173, 315);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(38, 32);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 47;
            this.pictureBox7.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(21, 321);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 20);
            this.label9.TabIndex = 46;
            this.label9.Text = "Person Name:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTitle.Location = new System.Drawing.Point(181, 126);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(287, 48);
            this.lblTitle.TabIndex = 34;
            this.lblTitle.Tag = "";
            this.lblTitle.Text = "Schedule Test";
            // 
            // pbTestImage
            // 
            this.pbTestImage.Image = global::DVLD_Interface.Properties.Resources.eye_bigger;
            this.pbTestImage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pbTestImage.Location = new System.Drawing.Point(260, 25);
            this.pbTestImage.Name = "pbTestImage";
            this.pbTestImage.Size = new System.Drawing.Size(131, 98);
            this.pbTestImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTestImage.TabIndex = 33;
            this.pbTestImage.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_Interface.Properties.Resources.cards;
            this.pictureBox2.Location = new System.Drawing.Point(173, 271);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(38, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // lblLicenseClass
            // 
            this.lblLicenseClass.AutoSize = true;
            this.lblLicenseClass.Location = new System.Drawing.Point(217, 277);
            this.lblLicenseClass.Name = "lblLicenseClass";
            this.lblLicenseClass.Size = new System.Drawing.Size(45, 20);
            this.lblLicenseClass.TabIndex = 13;
            this.lblLicenseClass.Text = "????";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 277);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Driving Class:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Interface.Properties.Resources.field_numeric;
            this.pictureBox1.Location = new System.Drawing.Point(173, 227);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // lblDrivingLicenseAppID
            // 
            this.lblDrivingLicenseAppID.AutoSize = true;
            this.lblDrivingLicenseAppID.Location = new System.Drawing.Point(217, 233);
            this.lblDrivingLicenseAppID.Name = "lblDrivingLicenseAppID";
            this.lblDrivingLicenseAppID.Size = new System.Drawing.Size(45, 20);
            this.lblDrivingLicenseAppID.TabIndex = 10;
            this.lblDrivingLicenseAppID.Text = "????";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "L.D.L.App ID:";
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
            this.btnClose.Location = new System.Drawing.Point(294, 723);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(137, 56);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "       Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmScheduleTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(709, 791);
            this.Controls.Add(this.gbTestInfo);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmScheduleTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Schedule Test";
            this.Load += new System.EventHandler(this.frmScheduleTest_Load);
            this.gbTestInfo.ResumeLayout(false);
            this.gbTestInfo.PerformLayout();
            this.gbRetakeTestInfo.ResumeLayout(false);
            this.gbRetakeTestInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTestInfo;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblLicenseClass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblDrivingLicenseAppID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pbTestImage;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTrail;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblBirthDate;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label lblTestFees;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox gbRetakeTestInfo;
        private System.Windows.Forms.Label lblRetakeTestFees;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTotalFees;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.Label lblRetakeTestID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpTestDate;
        private System.Windows.Forms.Label lblShowMessage;
    }
}