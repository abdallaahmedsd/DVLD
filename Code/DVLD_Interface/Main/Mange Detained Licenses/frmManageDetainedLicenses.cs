using DVLD_Business;
using DVLD_Interface.Main.Detain_Licenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Interface.Main.Mange_Detained_Licenses
{
    public partial class frmManageDetainedLicenses : Form
    {
        DataTable dtDetainedLicenses;
        public frmManageDetainedLicenses()
        {
            InitializeComponent();
        }

        private void _Load_Refresh_Data()
        {
            dtDetainedLicenses = clsDetainAndReleaseLicense.GetDetainedLicensesList();
            if (dtDetainedLicenses != null)
            {
                dgvDetainedLicenses.DataSource = dtDetainedLicenses;
                // Set Fill Mode to all cells
                dgvDetainedLicenses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Change the columns name
                _ChangeColumnName(dtDetainedLicenses, "ReleaseApplicationID", "ReleaseAppID");

                //Set AutoSizeMode for the FullName column to AutoSize
                dgvDetainedLicenses.Columns["FullName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                // Customize the header style for the entire DataGridView
                DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
                headerStyle.Font = new Font("Arial", 9, FontStyle.Bold);
                headerStyle.BackColor = Color.LightBlue;
                headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Center the text
                dgvDetainedLicenses.ColumnHeadersDefaultCellStyle = headerStyle;

                // Customize the cell style for the entire DataGridView
                DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
                cellStyle.Font = new Font("Arial", 8); // Set the smaller font size
                dgvDetainedLicenses.DefaultCellStyle = cellStyle;

                lblTotalRecords.Text = dtDetainedLicenses.Rows.Count.ToString();
            }
        }

        private void _NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a digit or a control key (e.g., Backspace, Delete)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If not a digit or a control key, suppress the key press
                e.Handled = true;
            }
        }

        static void _ChangeColumnName(DataTable dataTable, string originalColumnName, string newColumnName)
        {
            // Check if the original column exists
            if (dataTable.Columns.Contains(originalColumnName))
            {
                // Change the column name
                dataTable.Columns[originalColumnName].ColumnName = newColumnName;
            }
        }

        private void _Filter()
        {
            if (cbFilterBy.Text == "None")
            {
                txtFilterBy.Visible = false;

                // Select all LDL_Apps
                _ShowAllDetainedLicenses();
            }
            else
            {
                txtFilterBy.Visible = true;
                txtFilterBy.Focus();
                if (cbFilterBy.Text == "Detain ID")
                {
                    txtFilterBy.KeyPress += _NumericTextBox_KeyPress;
                    _FilterBy("DetainID");
                }
                else if (cbFilterBy.Text == "License ID")
                {
                    txtFilterBy.KeyPress += _NumericTextBox_KeyPress;
                    _FilterBy("LicenseID");
                }
                else if (cbFilterBy.Text == "National No")
                {
                    _FilterBy("NationalNo");
                }
                else if (cbFilterBy.Text == "Full Name")
                    _FilterBy("FullName");
            }
        }

        private void _FilterBy(string fieldName)
        {
            DataView DetainedLicenses_DataView = dtDetainedLicenses.DefaultView;

            if (!string.IsNullOrWhiteSpace(txtFilterBy.Text))
            {
                string searchFor = txtFilterBy.Text;
                string sign = "=";

                if (fieldName == "NationalNo" || fieldName == "FullName")
                {
                    searchFor = $"'%{searchFor}%'";
                    sign = "LIKE";
                }

                DetainedLicenses_DataView.RowFilter = $"{fieldName} {sign} {searchFor}";
                dgvDetainedLicenses.DataSource = DetainedLicenses_DataView;
            }
            else
            {
                _ShowAllDetainedLicenses();
            }

            lblTotalRecords.Text = DetainedLicenses_DataView.Count.ToString();
        }

        private void _ShowAllDetainedLicenses()
        {
            DataView DetainedLicenses_DataView = dtDetainedLicenses.DefaultView;
            DetainedLicenses_DataView.RowFilter = "";
            dgvDetainedLicenses.DataSource = DetainedLicenses_DataView;
            lblTotalRecords.Text = DetainedLicenses_DataView.Count.ToString();
        }

        private void frmManageDetainedLicenses_Load(object sender, EventArgs e)
        {
            _Load_Refresh_Data();
            cbFilterBy.SelectedIndex = 0;
        }

        private void btnReleaseLicense_Click(object sender, EventArgs e)
        {
            frmReleaseLicense frm = new frmReleaseLicense(-1);
            frm.ShowDialog();
            _Load_Refresh_Data();
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
            _Load_Refresh_Data();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvDetainedLicenses != null)
            {
                clsLicense license = clsLicense.FindByLicenseID((int)dgvDetainedLicenses.CurrentRow.Cells["LicenseID"].Value);
                clsDriver driver = clsDriver.FindByDriverID(license.DriverID);
                frmPersonDetails frm = new frmPersonDetails(driver.PersonID);
                frm.ShowDialog();
            }
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvDetainedLicenses != null)
            {
                frmShowLicenseCard frm = new frmShowLicenseCard((int)dgvDetainedLicenses.CurrentRow.Cells["LicenseID"].Value);
                frm.ShowDialog();
            }
        }

        private void licenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvDetainedLicenses != null)
            {
                clsLicense license = clsLicense.FindByLicenseID((int)dgvDetainedLicenses.CurrentRow.Cells["LicenseID"].Value);
                clsDriver driver = clsDriver.FindByDriverID(license.DriverID);
                frmLicenseHistory frm = new frmLicenseHistory(driver.PersonID);
                frm.ShowDialog();
            }
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvDetainedLicenses != null)
            {
                frmReleaseLicense frm = new frmReleaseLicense((int)dgvDetainedLicenses.CurrentRow.Cells["LicenseID"].Value);
                frm.ShowDialog();
                _Load_Refresh_Data();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cms_DetainedLicenses_CRUD_Opening(object sender, CancelEventArgs e)
        {
            if (dgvDetainedLicenses != null)
            {
                releaseDetainedLicenseToolStripMenuItem.Enabled = (bool)dgvDetainedLicenses.CurrentRow.Cells["isReleased"].Value ? false : true;
            }
        }

        private void cms_DetainedLicenses_CRUD_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            releaseDetainedLicenseToolStripMenuItem.Enabled = true;
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterBy.Clear();
            _Filter();
        }

        private void txtFilterBy_KeyUp(object sender, KeyEventArgs e)
        {
            _Filter();
        }

    }
}
