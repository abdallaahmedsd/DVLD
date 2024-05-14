using DVLD_Business;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD_Interface
{
    public partial class frmManagePeople : Form
    {
        public frmManagePeople()
        {
            InitializeComponent();
        }

        private void _Load_Refresh_People_List()
        {
            if (clsPerson.GetPeopleList() != null)
            {
                DataTable records = clsPerson.GetPeopleList();
                dgvPeople.DataSource = records;

                // Change header column name
                dgvPeople.Columns["FirstName"].HeaderText = "First Name";
                dgvPeople.Columns["SecondName"].HeaderText = "Second Name";
                dgvPeople.Columns["ThirdName"].HeaderText = "Third Name";
                dgvPeople.Columns["LastName"].HeaderText = "Last Name";
                dgvPeople.Columns["PersonID"].HeaderText = "Person ID";
                dgvPeople.Columns["NationalNo"].HeaderText = "National No";
                dgvPeople.Columns["DateOfBirth"].HeaderText = "Birthdate";
                dgvPeople.Columns["DateOFBirth"].HeaderText = "Birthdate";
                dgvPeople.Columns["CountryName"].HeaderText = "Country Name";

                // Customize the header style for the entire DataGridView
                DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
                headerStyle.Font = new Font("Arial", 9, FontStyle.Bold); 
                headerStyle.BackColor = Color.LightBlue;
                headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Center the text
                dgvPeople.ColumnHeadersDefaultCellStyle = headerStyle;

                // Set AutoSizeColumnsMode to Fill
                dgvPeople.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


                lblTotalRecords.Text = records.Rows.Count.ToString();
            }
        }

        public void frmManagePeople_Load(object sender, EventArgs e)
        {
            _Load_Refresh_People_List();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson(-1);
            frm.ShowDialog();

            _Load_Refresh_People_List();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson(-1);
            frm.ShowDialog();
            _Load_Refresh_People_List();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _Load_Refresh_People_List();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show($"Are you sure you wanna delete person [{dgvPeople.CurrentRow.Cells[0].Value}] ?", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if(clsPerson.DeletePerson((int)dgvPeople.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person deleted successfully!", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Load_Refresh_People_List();
                }
                else
                {
                    MessageBox.Show("Cannot delete this person, because has data linked to them", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _Load_Refresh_People_List();
        }

        private void dgvPeople_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _Load_Refresh_People_List();
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is unimplemented yet!", "Unimplemented", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is unimplemented yet!", "Unimplemented", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

    }
}
