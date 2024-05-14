using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Interface
{
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
        }

        private DataTable _AllRecords = new DataTable();

        private void _Load_Refresh_Users_List()
        {
            DataTable LoadRecords = clsUser.GetUsersList();
            if (LoadRecords != null)
            {
                _AllRecords = LoadRecords;
                dgvUsers.DataSource = LoadRecords;

                // Change header column name
                dgvUsers.Columns["FullName"].HeaderText = "Full Name";
                dgvUsers.Columns["UserID"].HeaderText = "User ID";
                dgvUsers.Columns["PersonID"].HeaderText = "Person ID";
                dgvUsers.Columns["UserName"].HeaderText = "User Name";
                dgvUsers.Columns["IsActive"].HeaderText = "is Active?";

                // Set Fill Mode to all cells
                dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Set AutoSizeMode for the FullName column to AutoSize
                dgvUsers.Columns["FullName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                // Customize the header style for the entire DataGridView
                DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
                headerStyle.Font = new Font("Arial", 11, FontStyle.Bold);
                headerStyle.BackColor = Color.LightBlue;
                headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Center the text
                dgvUsers.ColumnHeadersDefaultCellStyle = headerStyle;

                // Customize the cell style for the entire DataGridView
                DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
                cellStyle.Font = new Font("Arial", 10); // Set the smaller font size
                dgvUsers.DefaultCellStyle = cellStyle;

                lblTotalRecords.Text = _AllRecords.Rows.Count.ToString();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _ShowAllUsers()
        {
            DataView UsersDataView = _AllRecords.DefaultView;
            UsersDataView.RowFilter = "";
            dgvUsers.DataSource = UsersDataView;
            lblTotalRecords.Text = UsersDataView.Count.ToString();
        }

        private void _FilterBy(string fieldName)
        {
            DataView UsersDataView = _AllRecords.DefaultView;

            if (!string.IsNullOrWhiteSpace(txtFilterBy.Text))
            {
                string searchFor = txtFilterBy.Text;
                string sign = "=";

                if (fieldName == "UserName" || fieldName == "FullName")
                {
                    searchFor = $"'%{searchFor}%'";
                    sign = "LIKE";
                }
                UsersDataView.RowFilter = $"{fieldName} {sign} {searchFor}";
                dgvUsers.DataSource = UsersDataView;
            }
            else
            {
                _ShowAllUsers();
            }

            lblTotalRecords.Text = UsersDataView.Count.ToString();
        }

        private void _FilterByActivation()
        {
            if (cbIsActive.Text == "All")
            {
                _ShowAllUsers();
            }
            else if (cbIsActive.Text == "Yes")
            {
                DataView UsersDataView = _AllRecords.DefaultView;
                UsersDataView.RowFilter = "isActive = 'true'";
                dgvUsers.DataSource = UsersDataView;

                lblTotalRecords.Text = UsersDataView.Count.ToString();
            }
            else if (cbIsActive.Text == "No")
            {
                DataView UsersDataView = _AllRecords.DefaultView;
                UsersDataView.RowFilter = "isActive = 'false'";
                dgvUsers.DataSource = UsersDataView;
                lblTotalRecords.Text = UsersDataView.Count.ToString();
            }
        }

        private void _Filter()
        {
            if (cbFilterBy.Text == "None")
            {
                cbIsActive.Visible = false;
                txtFilterBy.Visible = false;

                // Select all users
                _ShowAllUsers();
            }
            else if(cbFilterBy.Text == "isActive")
            {
                cbIsActive.Visible = true;
                txtFilterBy.Visible = false;
                _FilterByActivation();
            }
            else
            {
                txtFilterBy.Visible = true;
                cbIsActive.Visible = false;
                txtFilterBy.Focus();
                if (cbFilterBy.Text == "User ID")
                {
                    txtFilterBy.KeyPress += NumericTextBox_KeyPress;
                    _FilterBy("UserID");
                }
                else if (cbFilterBy.Text == "Person ID")
                {
                    txtFilterBy.KeyPress += NumericTextBox_KeyPress;
                    _FilterBy("PersonID");
                }
                else if (cbFilterBy.Text == "User Name")
                    _FilterBy("UserName");
                else if (cbFilterBy.Text == "Full Name")
                    _FilterBy("FullName");
            }
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _Load_Refresh_Users_List();

            _Filter();

            cbFilterBy.SelectedIndex = 0;
            cbIsActive.SelectedIndex = 0;
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Filter();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterByActivation();
        }

        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a digit or a control key (e.g., Backspace, Delete)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If not a digit or a control key, suppress the key press
                e.Handled = true;
            }
        }

        private void txtFilterBy_KeyUp(object sender, KeyEventArgs e)
        {
            _Filter();
        }

        private void dgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmUserInfo frm = new frmUserInfo((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is unimplemented yet!", "Unimplemented", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is unimplemented yet!", "Unimplemented", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser(-1);
            frm.ShowDialog();
            _Load_Refresh_Users_List();
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser(-1);
            frm.ShowDialog();
            _Load_Refresh_Users_List();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _Load_Refresh_Users_List();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are you sure you wanna delete user [{dgvUsers.CurrentRow.Cells[0].Value}] ?", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsUser.DeleteUser((int)dgvUsers.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("User deleted successfully!", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Load_Refresh_Users_List();
                }
                else
                {
                    MessageBox.Show("Cannot delete this user, because has data linked to them", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser(-1);
            frm.ShowDialog();
        }

    }
}
