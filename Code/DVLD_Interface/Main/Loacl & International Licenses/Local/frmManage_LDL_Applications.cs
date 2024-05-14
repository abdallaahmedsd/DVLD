using DVLD_Business;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD_Interface
{
    public partial class frmManage_LDL_Applications : Form
    {
        //private clsLDL_Application
        DataTable dtApplications;
        public frmManage_LDL_Applications()
        {
            InitializeComponent();
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

        private void _Load_Refresh_LDL_Apps_List()
        {
            DataTable LoadRecords = clsLDL_Application.Get_LDL_ApplicationsList();
            if (LoadRecords != null)
            {
                dtApplications = LoadRecords;
                dgv_LDL_Apps.DataSource = LoadRecords;

                // Change columns names
                _ChangeColumnName(dtApplications, "FullName", "Full Name");
                _ChangeColumnName(dtApplications, "ClassName", "DrivingLicenseClass");


                // Set Fill Mode to all cells
                dgv_LDL_Apps.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Set AutoSizeMode for the FullName and ClassName columns to AutoSize
                dgv_LDL_Apps.Columns["Full Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgv_LDL_Apps.Columns["DrivingLicenseClass"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                // Customize the header style for the entire DataGridView
                DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
                headerStyle.Font = new Font("Arial", 9, FontStyle.Bold);
                headerStyle.BackColor = Color.LightBlue;
                headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Center the text
                dgv_LDL_Apps.ColumnHeadersDefaultCellStyle = headerStyle;

                // Customize the cell style for the entire DataGridView
                DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
                cellStyle.Font = new Font("Arial", 8); // Set the smaller font size
                dgv_LDL_Apps.DefaultCellStyle = cellStyle;

                lblTotalRecords.Text = dtApplications.Rows.Count.ToString();
            }
        }

        private void _Filter()
        {
            if (cbFilterBy.Text == "None")
            {
                txtFilterBy.Visible = false;

                // Select all LDL_Apps
                _ShowAll_LDL_Apps();
            }
            else
            {
                txtFilterBy.Visible = true;
                txtFilterBy.Focus();
                if (cbFilterBy.Text == "LDL Application ID")
                {
                    txtFilterBy.KeyPress += _NumericTextBox_KeyPress;
                    _FilterBy("LDL_ApplicationID");
                }
                else if (cbFilterBy.Text == "National No")
                {
                    _FilterBy("NationalNo");
                }
                else if (cbFilterBy.Text == "Driving License Class")
                    _FilterBy("DrivingLicenseClass");
                else if (cbFilterBy.Text == "Status")
                    _FilterBy("Status");
            }
        }

        private void _FilterBy(string fieldName)
        {
            DataView LDL_Apps_DataView = dtApplications.DefaultView;

            if (!string.IsNullOrWhiteSpace(txtFilterBy.Text))
            {
                string searchFor = txtFilterBy.Text;
                string sign = "=";

                if (fieldName == "NationalNo" || fieldName == "Status" || fieldName == "DrivingLicenseClass")
                {
                    searchFor = $"'%{searchFor}%'";
                    sign = "LIKE";
                }

                LDL_Apps_DataView.RowFilter = $"{fieldName} {sign} {searchFor}";
                dgv_LDL_Apps.DataSource = LDL_Apps_DataView;
            }
            else
            {
                _ShowAll_LDL_Apps();
            }

            lblTotalRecords.Text = LDL_Apps_DataView.Count.ToString();
        }

        private void _ShowAll_LDL_Apps()
        {
            DataView LDL_Apps_DataView = dtApplications.DefaultView;
            LDL_Apps_DataView.RowFilter = "";
            dgv_LDL_Apps.DataSource = LDL_Apps_DataView;
            lblTotalRecords.Text = LDL_Apps_DataView.Count.ToString();
        }

        private void _Handle_cms_LDL_App_CRUD_Appearance(int LDL_AppID)
        {
            clsLDL_Application _LDL_Application = clsLDL_Application.Find(LDL_AppID);

            if (_LDL_Application != null)
            {
                // When the application status is Canceled or Completed
                string status = clsApplication.GetApplicationStatus(_LDL_Application.ApplicationID);
                if (status.Trim() == "Canceled")
                {
                    //showApplicationsDetailsToolStripMenuItem.Enabled = false;
                    deleteApplicationToolStripMenuItem.Enabled = false;
                    cancelApplicationToolStripMenuItem.Enabled = false;
                    editToolStripMenuItem.Enabled = false;
                    showLicenseToolStripMenuItem.Enabled = false;
                    issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                    scheduleTestToolStripMenuItem.Enabled = false;
                    return;
                }
                else if(status.Trim() == "Completed")
                {
                    cancelApplicationToolStripMenuItem.Enabled = false;
                    editToolStripMenuItem.Enabled = false;
                    deleteApplicationToolStripMenuItem.Enabled = false;
                    issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                }
                else if (status.Trim() == "New")
                {
                    showLicenseToolStripMenuItem.Enabled = false;
                }
                    // Handle tests appearance according to the tests that have been took
                    _HandleTestsItemsAppearance(LDL_AppID);
            }

        }

        private void _HandleTestsItemsAppearance(int LDL_AppID)
        {
            int passedTests = clsTest.GetTotalPassedTests(LDL_AppID);

            if (passedTests < 3)
            {
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
            }

            if (passedTests == 0)
            {
                scheduleVisionTestToolStripMenuItem.Enabled = true;
                scheduleWrittenToolStripMenuItem.Enabled = false;
                scheduleStreetTestToolStripMenuItem.Enabled = false;
            }
            else if (passedTests == 1)
            {
                scheduleVisionTestToolStripMenuItem.Enabled = false;
                scheduleWrittenToolStripMenuItem.Enabled = true;
                scheduleStreetTestToolStripMenuItem.Enabled = false;
            }
            else if (passedTests == 2)
            {
                scheduleVisionTestToolStripMenuItem.Enabled = false;
                scheduleWrittenToolStripMenuItem.Enabled = false;
                scheduleStreetTestToolStripMenuItem.Enabled = true;
            }
            else
            {
                scheduleTestToolStripMenuItem.Enabled = false;

                //clsApplication application = clsApplication.Find(clsLDL_Application.Find((int)dgv_LDL_Apps.CurrentRow.Cells[0].Value).ApplicationID);
                //bool isIssuedLicense = clsLicense.isApplicationConnectedToLicense(application.ApplicationID);
                //if ( isIssuedLicense )
                //{
                //    issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                //}
            }
        }

        private void _ScheduleTestAppointment(ToolStripItem stripItem, clsTestType.enTestType testType)
        {
            frmScheduleTestAppointment frm = new frmScheduleTestAppointment((int)dgv_LDL_Apps.CurrentRow.Cells[0].Value, testType);
            frm.Text = stripItem.Text;
            frm.ShowDialog();
            _Load_Refresh_LDL_Apps_List();
        }

        private void frmManage_LDL_Applications_Load(object sender, EventArgs e)
        {
            _Load_Refresh_LDL_Apps_List();

            cbFilterBy.SelectedIndex = 0;   
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();   
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

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditLocalLicenseApp frm = new frmAddEditLocalLicenseApp((int)dgv_LDL_Apps.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _Load_Refresh_LDL_Apps_List();
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wanna delete this application?", "Confirm Deletion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                clsLDL_Application LDL_Application = clsLDL_Application.Find((int)dgv_LDL_Apps.CurrentRow.Cells[0].Value);
                if (LDL_Application != null)
                {
                    if (clsLDL_Application.Delete_LDL_Application(LDL_Application.LDL_AppID))
                    {
                        if (clsApplication.DeleteApplication(LDL_Application.ApplicationID))
                        {
                            MessageBox.Show("Application has been deleted successfully!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            _Load_Refresh_LDL_Apps_List();
                        }
                        else
                            MessageBox.Show("Application has not been deleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show($"You cannot delete this application because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show($"Cannot find LDL_Application with ID {LDL_Application.LDL_AppID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wanna cancel this application?", "Confirm Cancellation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                clsLDL_Application LDL_Application = clsLDL_Application.Find((int)dgv_LDL_Apps.CurrentRow.Cells[0].Value);
                if (LDL_Application != null)
                {
                    if (clsApplication.CancelApplication(LDL_Application.ApplicationID))
                    {
                        // Change last status date
                        clsApplication application = clsApplication.Find(LDL_Application.ApplicationID);
                        application.LastStatusDate = DateTime.Now;
                        application.Save();

                        MessageBox.Show("Application has been canceled successfully!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        _Load_Refresh_LDL_Apps_List();
                    }
                    else
                        MessageBox.Show("Application has not been canceled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show($"Cannot find LDL_Application with ID {LDL_Application.LDL_AppID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dgv_LDL_Apps_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frm_LDL_ApplicationDetails frm = new frm_LDL_ApplicationDetails((int)dgv_LDL_Apps.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void cms_LDL_App_CRUD_Opened(object sender, EventArgs e)
        {
            _Handle_cms_LDL_App_CRUD_Appearance((int)dgv_LDL_Apps.CurrentRow.Cells[0].Value);
        }

        private void cms_LDL_App_CRUD_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            cms_LDL_App_CRUD.Enabled = true;

            foreach (ToolStripItem item in  cms_LDL_App_CRUD.Items)
            {
                item.Enabled = true;
            }
        }

        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTestAppointment(scheduleVisionTestToolStripMenuItem, clsTestType.enTestType.VisionTest);
        }

        private void scheduleWrittenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTestAppointment(scheduleWrittenToolStripMenuItem, clsTestType.enTestType.WrittenTest);
        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTestAppointment(scheduleStreetTestToolStripMenuItem, clsTestType.enTestType.StreetTest);
        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssueDrivingLicense frm = new frmIssueDrivingLicense((int)dgv_LDL_Apps.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _Load_Refresh_LDL_Apps_List();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsLDL_Application LDL_Application = clsLDL_Application.Find((int)dgv_LDL_Apps.CurrentRow.Cells[0].Value);

            if (LDL_Application != null)
            {
                clsLicense License = clsLicense.FindByApplicationID(LDL_Application.ApplicationID);
                frmShowLicenseCard frm = new frmShowLicenseCard(License.LicenseID);
                frm.ShowDialog();
            }
        }

        private void licenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsLDL_Application LDL_Application = clsLDL_Application.Find((int)dgv_LDL_Apps.CurrentRow.Cells[0].Value);
            if (LDL_Application != null)
            {
                clsApplication Application = clsApplication.Find(LDL_Application.ApplicationID);
                frmLicenseHistory frm = new frmLicenseHistory(Application.ApplicantPersonID);
                frm.ShowDialog();
            }
        }

        private void showApplicationsDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_LDL_ApplicationDetails frm = new frm_LDL_ApplicationDetails((int)dgv_LDL_Apps.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void btnAdd_LDL_App_Click(object sender, EventArgs e)
        {
            frmAddEditLocalLicenseApp frm = new frmAddEditLocalLicenseApp(-1);
            frm.ShowDialog();
            _Load_Refresh_LDL_Apps_List();
        }

    }
}