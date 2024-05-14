using DVLD_Business;
using DVLD_Interface.Main.Licenses;
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
    public partial class frmLicenseHistory : Form
    {
        int _personID;
        public frmLicenseHistory(int personID)
        {
            _personID = personID;   
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

        private void _LoadLocalLicenses()
        {
            clsDriver driver = clsDriver.FindByPersonID(_personID);
            if (driver != null)
            {
                DataTable LoadRecords = clsLicense.GetLocalLicenses(driver.DriverID);
                if (LoadRecords != null)
                {
                    dgvLocal.DataSource = LoadRecords;
                    // Set Fill Mode to all cells
                    dgvLocal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    // Change the column name
                    _ChangeColumnName(LoadRecords, "LicenseID", "License ID");
                    _ChangeColumnName(LoadRecords, "ApplicationID", "App ID");
                    _ChangeColumnName(LoadRecords, "ClassName", "Class Name");
                    _ChangeColumnName(LoadRecords, "IssueDate", "Issue Date");
                    _ChangeColumnName(LoadRecords, "ExpiryDate", "Expiry Date");
                    _ChangeColumnName(LoadRecords, "isActive", "is Active");

                    //Set AutoSizeMode for the FullName column to AutoSize
                    dgvLocal.Columns["Class Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    // Customize the header style for the entire DataGridView
                    DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
                    headerStyle.Font = new Font("Arial", 9, FontStyle.Bold);
                    headerStyle.BackColor = Color.LightBlue;
                    headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Center the text
                    dgvLocal.ColumnHeadersDefaultCellStyle = headerStyle;

                    // Customize the cell style for the entire DataGridView
                    DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
                    cellStyle.Font = new Font("Arial", 9); // Set the smaller font size
                    dgvLocal.DefaultCellStyle = cellStyle;

                    lblTotalLocalRecords.Text = LoadRecords.Rows.Count.ToString();
                }
            }
        }

        private void _LoadInternationalLicenses()
        {
            clsDriver driver = clsDriver.FindByPersonID(_personID);
            if (driver != null)
            {
                DataTable LoadRecords = clsInternationalLicense.GetInternationalLicenses(driver.DriverID);
                if (LoadRecords != null)
                {
                    dgvInternational.DataSource = LoadRecords;
                    // Set Fill Mode to all cells
                    dgvInternational.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    // Change the column name
                    _ChangeColumnName(LoadRecords, "InternationalLicenseID", "Int.License ID");
                    _ChangeColumnName(LoadRecords, "ApplicationID", "Application ID");
                    _ChangeColumnName(LoadRecords, "IssuedUsingLocalLicenseID", "L.License ID");
                    _ChangeColumnName(LoadRecords, "DriverID", "Driver ID");
                    _ChangeColumnName(LoadRecords, "IssueDate", "Issue Date");
                    _ChangeColumnName(LoadRecords, "ExpiryDate", "Expiry Date");
                    _ChangeColumnName(LoadRecords, "isActive", "is Active");

                    //Set AutoSizeMode for the FullName column to AutoSize
                    //dgvInternational.Columns["Class Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    // Customize the header style for the entire DataGridView
                    DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
                    headerStyle.Font = new Font("Arial", 9, FontStyle.Bold);
                    headerStyle.BackColor = Color.LightBlue;
                    headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Center the text
                    dgvInternational.ColumnHeadersDefaultCellStyle = headerStyle;

                    // Customize the cell style for the entire DataGridView
                    DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
                    cellStyle.Font = new Font("Arial", 9); // Set the smaller font size
                    dgvInternational.DefaultCellStyle = cellStyle;

                    lblTotalInternationalRecords.Text = LoadRecords.Rows.Count.ToString();
                }
            }
        }

        private void _LoadData()
        {
            ctrPersonCardWithSearchBar1.EnableSearchBar();
            ctrPersonCardWithSearchBar1.LoadPersonInfo(_personID);
            _LoadLocalLicenses();
            _LoadInternationalLicenses();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLicenseHistory_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void showLocalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvLocal.Rows.Count > 0)
            {
                frmShowLicenseCard frm = new frmShowLicenseCard((int)dgvLocal.CurrentRow.Cells[0].Value);
                frm.ShowDialog();
            }
        }

        private void showInternationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvInternational.Rows.Count > 0)
            {
                frmShowInternationalLicenseCard frm = new frmShowInternationalLicenseCard((int)dgvInternational.CurrentRow.Cells[0].Value);
                frm.ShowDialog();
            }
        }
    }
}
