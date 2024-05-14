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

namespace DVLD_Interface.Main.Licenses
{
    public partial class frmManageInternationalLicenses : Form
    {
        DataTable dtApplications;

        public frmManageInternationalLicenses()
        {
            InitializeComponent();
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

        private void _Load_Refresh_IDL_Apps_List()
        {
            DataTable LoadRecords = clsInternationalLicense.GetInternationalLicensesList();
            if (LoadRecords != null)
            {
                dtApplications = LoadRecords;
                dgv_IDL_Apps.DataSource = dtApplications;

                // Set Fill Mode to all cells
                dgv_IDL_Apps.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Change columns names
                _ChangeColumnName(dtApplications, "IssuedUsingLocalLicenseID", "L.LicenseID");
                _ChangeColumnName(dtApplications, "InternationalLicenseID", "Int.LicenseID");

                // Customize the header style for the entire DataGridView
                DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
                headerStyle.Font = new Font("Arial", 9, FontStyle.Bold);
                headerStyle.BackColor = Color.LightBlue;
                headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Center the text
                dgv_IDL_Apps.ColumnHeadersDefaultCellStyle = headerStyle;

                // Customize the cell style for the entire DataGridView
                DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
                cellStyle.Font = new Font("Arial", 9); // Set the smaller font size
                dgv_IDL_Apps.DefaultCellStyle = cellStyle;

                lblTotalRecords.Text = dtApplications.Rows.Count.ToString();
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

        private void _Filter()
        {
            if (cbFilterBy.Text == "None")
            {
                txtFilterBy.Visible = false;

                // Select all LDL_Apps
                _ShowAllInternationalLicenseApps();
            }
            else
            {
                txtFilterBy.Visible = true;
                txtFilterBy.Focus();
                txtFilterBy.KeyPress += _NumericTextBox_KeyPress;
                if (cbFilterBy.Text == "Driver ID")
                    _FilterBy("DriverID");
                else if (cbFilterBy.Text == "Int.License ID")
                    _FilterBy("InternationalLicenseID");
                else if (cbFilterBy.Text == "Local License ID")
                    _FilterBy("IssuedUsingLocalLicenseID");
            }
        }

        private void _FilterBy(string fieldName)
        {
            DataView LDL_Apps_DataView = dtApplications.DefaultView;

            if (!string.IsNullOrWhiteSpace(txtFilterBy.Text))
            {
                string searchFor = txtFilterBy.Text;

                LDL_Apps_DataView.RowFilter = $"{fieldName} = {searchFor}";
                dgv_IDL_Apps.DataSource = LDL_Apps_DataView;
                lblTotalRecords.Text = LDL_Apps_DataView.Count.ToString();
            }
            else
            {
                _ShowAllInternationalLicenseApps();
            }

        }

        private void _ShowAllInternationalLicenseApps()
        {
            DataView LDL_Apps_DataView = dtApplications.DefaultView;
            LDL_Apps_DataView.RowFilter = "";
            dgv_IDL_Apps.DataSource = LDL_Apps_DataView;
            lblTotalRecords.Text = LDL_Apps_DataView.Count.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmManageInternationalLicenses_Load(object sender, EventArgs e)
        {
            _Load_Refresh_IDL_Apps_List();
            cbFilterBy.SelectedIndex = 0;
        }

        private void btnNewInternationalLicense_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicense frm = new frmNewInternationalLicense();
            frm.ShowDialog();
            _Load_Refresh_IDL_Apps_List();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv_IDL_Apps != null)
            {
                frmShowInternationalLicenseCard frm = new frmShowInternationalLicenseCard((int)dgv_IDL_Apps.CurrentRow.Cells[0].Value);
                frm.ShowDialog();
            }
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv_IDL_Apps != null)
            {
                clsDriver driver = clsDriver.FindByDriverID((int)dgv_IDL_Apps.CurrentRow.Cells["DriverID"].Value);
                frmPersonDetails frm = new frmPersonDetails(driver.PersonID);
                frm.ShowDialog();
            }
        }

        private void licenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv_IDL_Apps != null)
            {
                clsDriver driver = clsDriver.FindByDriverID((int)dgv_IDL_Apps.CurrentRow.Cells["DriverID"].Value);
                frmLicenseHistory frm = new frmLicenseHistory(driver.PersonID);
                frm.ShowDialog();
            }
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
