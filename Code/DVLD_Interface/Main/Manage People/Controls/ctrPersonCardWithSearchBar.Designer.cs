namespace DVLD_Interface
{
    partial class ctrPersonCardWithSearchBar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrPersonCardWithSearchBar));
            this.gbFindBy = new System.Windows.Forms.GroupBox();
            this.btnFindPerson = new System.Windows.Forms.Button();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.txtFindBy = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFindBy = new System.Windows.Forms.ComboBox();
            this.ctrPersonCard1 = new DVLD_Interface.ctrPersonCard();
            this.gbFindBy.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFindBy
            // 
            resources.ApplyResources(this.gbFindBy, "gbFindBy");
            this.gbFindBy.Controls.Add(this.btnFindPerson);
            this.gbFindBy.Controls.Add(this.btnAddPerson);
            this.gbFindBy.Controls.Add(this.txtFindBy);
            this.gbFindBy.Controls.Add(this.label2);
            this.gbFindBy.Controls.Add(this.cbFindBy);
            this.gbFindBy.Name = "gbFindBy";
            this.gbFindBy.TabStop = false;
            // 
            // btnFindPerson
            // 
            resources.ApplyResources(this.btnFindPerson, "btnFindPerson");
            this.btnFindPerson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFindPerson.Image = global::DVLD_Interface.Properties.Resources.find_person;
            this.btnFindPerson.Name = "btnFindPerson";
            this.btnFindPerson.UseVisualStyleBackColor = true;
            this.btnFindPerson.Click += new System.EventHandler(this.btnFindPerson_Click);
            // 
            // btnAddPerson
            // 
            resources.ApplyResources(this.btnAddPerson, "btnAddPerson");
            this.btnAddPerson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddPerson.Image = global::DVLD_Interface.Properties.Resources.add_new_person;
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // txtFindBy
            // 
            this.txtFindBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txtFindBy, "txtFindBy");
            this.txtFindBy.Name = "txtFindBy";
            this.txtFindBy.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFindBy_KeyUp);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // cbFindBy
            // 
            this.cbFindBy.BackColor = System.Drawing.Color.White;
            this.cbFindBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbFindBy, "cbFindBy");
            this.cbFindBy.FormattingEnabled = true;
            this.cbFindBy.Items.AddRange(new object[] {
            resources.GetString("cbFindBy.Items"),
            resources.GetString("cbFindBy.Items1")});
            this.cbFindBy.Name = "cbFindBy";
            this.cbFindBy.SelectedIndexChanged += new System.EventHandler(this.cbFindBy_SelectedIndexChanged);
            // 
            // ctrPersonCard1
            // 
            resources.ApplyResources(this.ctrPersonCard1, "ctrPersonCard1");
            this.ctrPersonCard1.BackColor = System.Drawing.Color.White;
            this.ctrPersonCard1.Name = "ctrPersonCard1";
            // 
            // ctrPersonCardWithSearchBar
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbFindBy);
            this.Controls.Add(this.ctrPersonCard1);
            this.Name = "ctrPersonCardWithSearchBar";
            this.Load += new System.EventHandler(this.ctrPersonCardWithSearchBar_Load);
            this.gbFindBy.ResumeLayout(false);
            this.gbFindBy.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrPersonCard ctrPersonCard1;
        private System.Windows.Forms.GroupBox gbFindBy;
        private System.Windows.Forms.TextBox txtFindBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFindBy;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.Button btnFindPerson;
    }
}
