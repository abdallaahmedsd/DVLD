using DVLD_Business;
using DVLD_Interface.Main.Licenses;
using System;
using System.Windows.Forms;

namespace DVLD_Interface
{
    public partial class frmNewInternationalLicense : Form
    {
        clsLicense _License;
        clsInternationalLicense _InternationalLicense;
        clsApplication _Application;
        clsDriver _Driver;
        clsManageAppTypes _service = clsManageAppTypes.Find((int)clsApplication.enApplicationType.NewInternationalLicense);

        public frmNewInternationalLicense()
        {
            InitializeComponent();
        }

        private void _LoadData()
        {
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblExpiryDate.Text = DateTime.Now.ToShortDateString();
            lblApplicationFees.Text = _service.ApplicationFees.ToString("0.00"); 
        }

        private void _FillApplicationObject()
        {
            _Application.ApplicationDate = DateTime.Now;
            _Application.LastStatusDate = DateTime.Now;
            _Application.ApplicationStatusID = 3; // Completed
            _Application.ApplicantPersonID = _Driver.PersonID;
            _Application.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;
            _Application.PaidFees = _service.ApplicationFees;
            _Application.ApplicationTypeID = _service.ApplicationID;
        }

        private void _FillInternationalLicenseObject()
        {
            _InternationalLicense.DriverID = _Driver.DriverID;
            _InternationalLicense.IssuedUsingLocalLicenseID = _License.LicenseID;
            _InternationalLicense.ApplicationID = _Application.ApplicationID;
            _InternationalLicense.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;
            _InternationalLicense.IssueDate = DateTime.Now;
            _InternationalLicense.ExpiryDate = DateTime.Now.AddYears(1); // Handle me later
            _InternationalLicense.IsActive = true;
        }

        private void _FillFormWithInternationalLicenseInfo()
        {
            lbl_IL_AppID.Text = _Application.ApplicationID.ToString();
            lblApplicationDate.Text = _Application.ApplicationDate.ToShortDateString();
            lblIssueDate.Text = _InternationalLicense.IssueDate.ToShortDateString();
            lblExpiryDate.Text = _InternationalLicense.ExpiryDate.ToShortDateString();
            lblApplicationFees.Text = _Application.PaidFees.ToString("0.00");
            lblInternationalLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString();
            lblLocalLicenseID.Text = _License.LicenseID.ToString();
            lblCreatedBy.Text = clsUser.Find(_InternationalLicense.CreatedByUserID).UserName;

            llblShowLicenseInfo.Enabled = true;
            btnIssueLicense.Enabled = false;
            gbFind.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNewInternationalLicense_Load(object sender, EventArgs e)
        {
            _LoadData();
            mtxtFind.Focus();
        }

        private void btnFindPerson_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(mtxtFind.Text))
            {
                ctrDriverCard1.LoadLicenseInfo(int.Parse(mtxtFind.Text));
                int licenseID = ctrDriverCard1.GetCurrentLicenseID;
                lblLocalLicenseID.Text = (licenseID != -1 ? licenseID.ToString() : "????");
                llblShowLicensesHistory.Enabled = (licenseID != -1);
            }
        }

        private void mtxtFind_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnFindLicense.PerformClick();
            }
        }

        private void btnIssueLicense_Click(object sender, EventArgs e)
        {
            if(ctrDriverCard1.GetCurrentLicenseID == -1)
            {
                MessageBox.Show("Please select a local license first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _License = clsLicense.FindByLicenseID(ctrDriverCard1.GetCurrentLicenseID);

            // Check if person is already has an international license
            int internationalLicenseID = clsInternationalLicense.GetActiveInternationalLicenseIDByDriverID(_License.DriverID);
            if(internationalLicenseID != -1)
            {
                MessageBox.Show($"Person already has an active international license with ID ({internationalLicenseID})", "Already Has License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if person doesn't has a local license with the class 3 (Class 3 - Ordinary driving license) 
            if (!clsLicense.isPersonHaveLicenseWithSameClass(3, _License.DriverID))
            {
                MessageBox.Show("Sorry, person must have a license with 'Class 3 - Ordinary driving license'", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if the license is not active
            if (!_License.IsActive)
            {
                MessageBox.Show("Sorry your license is deactivated", "Deactivated License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if the license has been expired
            if (_License.ExpiryDate < DateTime.Now)
            {
                MessageBox.Show("Sorry your license is expired", "Expired License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Driver = clsDriver.FindByDriverID(_License.DriverID);
            _Application = new clsApplication();
            _FillApplicationObject();

            if(!_Application.Save())
            {
                MessageBox.Show("Cannot create an international license application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _InternationalLicense = new clsInternationalLicense();
            _FillInternationalLicenseObject();

            if (MessageBox.Show("Are you sure you wanna issue an international license?", "Confirm Issue License", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_InternationalLicense.Save())
                {
                    MessageBox.Show($"License has been issued successfully with ID ({_InternationalLicense.InternationalLicenseID})", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _FillFormWithInternationalLicenseInfo();
                }
                else
                {
                    clsApplication.DeleteApplication(_Application.ApplicationID);
                    MessageBox.Show("Cannot issue an international license application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void llblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ctrDriverCard1.GetCurrentLicenseID != -1)
            {
                _License = clsLicense.FindByLicenseID(ctrDriverCard1.GetCurrentLicenseID);
                _Driver = clsDriver.FindByDriverID(_License.DriverID);
                frmLicenseHistory frm = new frmLicenseHistory(_Driver.PersonID);
                frm.ShowDialog();
            }
        }

        private void llblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowInternationalLicenseCard frm = new frmShowInternationalLicenseCard(_InternationalLicense.InternationalLicenseID);
            frm.ShowDialog();
        }

    }
}
