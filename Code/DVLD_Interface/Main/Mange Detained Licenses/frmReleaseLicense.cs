using DVLD_Business;
using System;
using System.Windows.Forms;

namespace DVLD_Interface.Main.Mange_Detained_Licenses
{
    public partial class frmReleaseLicense : Form
    {
        int _licenseID;
        clsDetainAndReleaseLicense _DetainedLicense;
        clsManageAppTypes _Service = clsManageAppTypes.Find(5); // 5 == Release detained license 
        clsApplication _Application;

        public frmReleaseLicense(int licenseID)
        {
            _licenseID = licenseID;
            InitializeComponent();
        }

        private void _FillFormWithDetainedLicenseInfo()
        {
            lblDetainID.Text = _DetainedLicense.DetainID.ToString();
            lblLicenseID.Text = _DetainedLicense.LicenseID.ToString();
            lblDetainDate.Text = _DetainedLicense.DetainDate.ToShortDateString();
            lblFineFees.Text = _DetainedLicense.FineFees.ToString("0.00");
            lblApplicationFees.Text = _Service.ApplicationFees.ToString("0.00");
            lblTotalFees.Text = (_DetainedLicense.FineFees + _Service.ApplicationFees).ToString("0.00");
        }

        private void _FillReleaseApplicationObject()
        {
            _Application.ApplicationDate = DateTime.Now;
            _Application.LastStatusDate = DateTime.Now;
            _Application.ApplicationStatusID = 3; // 3 == Completed 
            clsLicense license = clsLicense.FindByLicenseID(_DetainedLicense.LicenseID);
            clsDriver driver = clsDriver.FindByDriverID(license.DriverID);
            _Application.ApplicantPersonID = driver.PersonID;
            _Application.ApplicationTypeID = _Service.ApplicationID;
            _Application.PaidFees = _Service.ApplicationFees;
            _Application.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;
        }

        private void _LoadData()
        {
            if (_licenseID != -1)
            {
                _DetainedLicense = clsDetainAndReleaseLicense.FindByLicenseID(_licenseID);
                if (_DetainedLicense != null)
                {
                    _FillFormWithDetainedLicenseInfo();
                }
            }
        }

        private bool _ReleaseLicense(int  licenseID)
        {
            return clsDetainAndReleaseLicense.ReleaseLicense(licenseID, DateTime.Now, clsGlobalSettings.CurrentUser.UserID, _Application.ApplicationID);
        }

        private void frmReleaseLicense_Load(object sender, EventArgs e)
        {
            if(_licenseID != -1)
            {
                ctrLocalLicenseCardWithSearchBar1.LoadLicenseInfo(_licenseID);
                _LoadData();
                llblShowLicensesHistory.Enabled = true;
                btnReleaseLicense.Enabled = true;
            }
        }

        private void ctrLocalLicenseCardWithSearchBar1_OnLicenseSelected(int licenseID)
        {
            lblLicenseID.Text = (licenseID != -1 ? licenseID.ToString() : "????");
            btnReleaseLicense.Enabled = (licenseID != -1);
            llblShowLicensesHistory.Enabled = (licenseID != -1);

            if(licenseID != -1)
            {
                if (!clsDetainAndReleaseLicense.isLicenseDetained(licenseID))
                {
                    MessageBox.Show("The selected license is not detained.", "Not Detained", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnReleaseLicense.Enabled = false;
                    return;
                }

                _DetainedLicense = clsDetainAndReleaseLicense.FindByLicenseID(licenseID);

                if (_DetainedLicense != null)
                {
                    _FillFormWithDetainedLicenseInfo();
                }

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReleaseLicense_Click(object sender, EventArgs e)
        {
            _Application = new clsApplication();
            _FillReleaseApplicationObject();

            if (MessageBox.Show("Are you sure you wanna release this license?", "Confirm Release License", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!_Application.Save())
                {
                    MessageBox.Show("Cannot create a release license application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (_ReleaseLicense(_DetainedLicense.LicenseID))
                {
                    MessageBox.Show($"License has been released successfully!", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblReleaseBy.Text = clsUser.Find(clsGlobalSettings.CurrentUser.UserID).UserName;
                    btnReleaseLicense.Enabled = false;
                    llblShowLicenseInfo.Enabled = true;
                    lblApplicationID.Text = _Application.ApplicationID.ToString();
                    ctrLocalLicenseCardWithSearchBar1.EnableFilterLicenses();
                }
                else
                {
                    clsApplication.DeleteApplication(_Application.ApplicationID);
                    MessageBox.Show("Cannot create a replacement license application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void llblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_DetainedLicense != null)
            {
                clsLicense license = clsLicense.FindByLicenseID(_DetainedLicense.LicenseID);
                clsDriver driver = clsDriver.FindByDriverID(license.DriverID);
                frmLicenseHistory frm = new frmLicenseHistory(driver.PersonID);
                frm.ShowDialog();
            }
        }

        private void llblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_DetainedLicense != null)
            {
                frmShowLicenseCard frm = new frmShowLicenseCard(_DetainedLicense.LicenseID);
                frm.ShowDialog();
            }
        }

    }
}
