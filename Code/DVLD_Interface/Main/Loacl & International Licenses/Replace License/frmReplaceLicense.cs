using DVLD_Business;
using System;
using System.Windows.Forms;

namespace DVLD_Interface.Main.Licenses.Replace_License
{
    public partial class frmReplaceLicense : Form
    {
        clsManageAppTypes _Service;
        clsLicense _OldLicense;
        clsLicense _NewLicense;
        clsLicenseClass _LicenseClass;
        clsApplication _Application;
        clsDriver _Driver;

        public frmReplaceLicense(clsApplication.enApplicationType replacementReason)
        {
            InitializeComponent();

            if (replacementReason == clsApplication.enApplicationType.ReplaceLostDrivingLicense)
            {
                lblTitle.Text = "Replacement For  Lost  License";
                _Service = clsManageAppTypes.Find((int)clsApplication.enApplicationType.ReplaceLostDrivingLicense); 
            }
            else if (replacementReason == clsApplication.enApplicationType.ReplaceDamagedDrivingLicense)
            {
                lblTitle.Text = "Replacement For Damaged License";
                _Service = clsManageAppTypes.Find((int)clsApplication.enApplicationType.ReplaceDamagedDrivingLicense);
            }

        }

        private void _LoadData()
        {
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblExpiryDate.Text = DateTime.Now.ToShortDateString();
            lblApplicationFees.Text = _Service.ApplicationFees.ToString("0.00");
            lblCreatedBy.Text = clsUser.Find(clsGlobalSettings.CurrentUser.UserID).UserName;
        }

        private void _FillApplicationObject()
        {
            _Application.ApplicationDate = DateTime.Now;
            _Application.LastStatusDate = DateTime.Now;
            _Application.ApplicationStatusID = 3; // Completed
            _Application.ApplicantPersonID = _Driver.PersonID;
            _Application.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;
            _Application.PaidFees = _Service.ApplicationFees;
            _Application.ApplicationTypeID = _Service.ApplicationID;
        }

        private void _FillLicenseObject()
        {
            _NewLicense.PaidFees = _Service.ApplicationFees;
            _NewLicense.IssueDate = _OldLicense.IssueDate;
            _NewLicense.ExpiryDate = _OldLicense.ExpiryDate;
            _NewLicense.IssueReason = (byte)_Service.ApplicationID;
            _NewLicense.Notes = txtNotes.Text;
            _NewLicense.ApplicationID = _Application.ApplicationID;
            _NewLicense.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;
            _NewLicense.DriverID = _Driver.DriverID;
            _NewLicense.LicenseClassID = _OldLicense.LicenseClassID;
            _NewLicense.IsActive = true;
        }

        private void _FillFormWithNewLicenseInfo()
        {
            lbl_RL_AppID.Text = _Application.ApplicationID.ToString();
            lblApplicationDate.Text = _Application.ApplicationDate.ToShortDateString();
            lblIssueDate.Text = _NewLicense.IssueDate.ToShortDateString();
            lblNewLicenseID.Text = _NewLicense.LicenseID.ToString();
            lblExpiryDate.Text = _NewLicense.ExpiryDate.ToShortDateString();
            lblCreatedBy.Text = clsUser.Find(_NewLicense.CreatedByUserID).UserName;

            llblShowLicenseInfo.Enabled = true;
            btnReplaceLicense.Enabled = false;
            ctrLocalLicenseCardWithSearchBar1.EnableFilterLicenses();
        }

        private void frmReplaceLicense_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void ctrLocalLicenseCardWithSearchBar1_OnLicenseSelected(int obj)
        {
            int licenseID = obj;

            lblOldLicenseID.Text = (licenseID != -1 ? licenseID.ToString() : "????");
            btnReplaceLicense.Enabled = (licenseID != -1);
            llblShowLicensesHistory.Enabled = (licenseID != -1);

            if (licenseID != -1)
            {
                _OldLicense = clsLicense.FindByLicenseID(licenseID);
                _LicenseClass = clsLicenseClass.Find(_OldLicense.LicenseClassID);
                lblLicenseFees.Text = _LicenseClass.LicenseClassFees.ToString("0.00");
                lblTotalFees.Text = (_LicenseClass.LicenseClassFees + _Service.ApplicationFees).ToString("0.00");
                txtNotes.Text = _OldLicense.Notes;

                if (!_OldLicense.IsActive)
                {
                    MessageBox.Show($"Selected license is deactivated. Please choose another one", "Deactivated", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnReplaceLicense.Enabled = false;
                }

                if (_OldLicense.ExpiryDate < DateTime.Now)
                {
                    MessageBox.Show($"Selected license is expired. Please renew it first", "Expired", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnReplaceLicense.Enabled = false;
                }

            }
        }

        private void btnReplaceLicense_Click(object sender, EventArgs e)
        {
            // Check the activation of the license
            if (!_OldLicense.IsActive)
            {
                MessageBox.Show("Cannot replace this license because it is deactivated", "Deactivated License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Driver = clsDriver.FindByDriverID(_OldLicense.DriverID);
            _LicenseClass = clsLicenseClass.Find(_OldLicense.LicenseClassID);
            _Application = new clsApplication();
            _FillApplicationObject();

            if (!_Application.Save())
            {
                MessageBox.Show("Cannot create a replace license application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _NewLicense = new clsLicense();
            _FillLicenseObject();

            if (MessageBox.Show("Are you sure you wanna replace this license?", "Confirm Replacement License", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_NewLicense.Save())
                {
                    MessageBox.Show($"License has been replaced successfully with ID ({_NewLicense.LicenseID})", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _FillFormWithNewLicenseInfo();

                    // Deactivate the old license
                    _OldLicense.IsActive = false;
                    _OldLicense.Save();
                }
                else
                {
                    clsApplication.DeleteApplication(_Application.ApplicationID);
                    MessageBox.Show("Cannot create a replace license application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void llblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_OldLicense != null)
            {
                _Driver = clsDriver.FindByDriverID(_OldLicense.DriverID);
                frmLicenseHistory frm = new frmLicenseHistory(_Driver.PersonID);
                frm.ShowDialog();
            }
        }

        private void llblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_NewLicense != null)
            {
                frmShowLicenseCard frm = new frmShowLicenseCard(_NewLicense.LicenseID);
                frm.ShowDialog();
            }
        }

    }
}
