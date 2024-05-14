using DVLD_Business;
using System;
using System.Windows.Forms;

namespace DVLD_Interface.Main.Detain_Licenses
{
    public partial class frmDetainLicense : Form
    {
        //clsDetainAndReleaseLicense _DetainLicense;
        int _detainID = -1;
        public frmDetainLicense()
        {
            InitializeComponent();
        }

        private int _DetainLicense(int licenseID)
        {
            decimal fineFees = decimal.Parse(mtxtFineFees.Text);
            int detainID = clsDetainAndReleaseLicense.DetainLicense(licenseID, DateTime.Now, fineFees, clsGlobalSettings.CurrentUser.UserID);
            return detainID;
        }

        private void _FillFormWithDetainedLicenseInfo ()
        {
            lblDetainID.Text = _detainID.ToString();
            lblDetainDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedBy.Text = clsUser.Find(clsGlobalSettings.CurrentUser.UserID).UserName;
            btnDetainLicense.Enabled = false;
            llblShowLicenseInfo.Enabled = true;
            ctrLocalLicenseCardWithSearchBar1.EnableFilterLicenses();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrLocalLicenseCardWithSearchBar1_OnLicenseSelected(int licenseID)
        {
            lblLicenseID.Text = (licenseID != -1 ? licenseID.ToString() : "????");
            btnDetainLicense.Enabled = (licenseID != -1);
            llblShowLicensesHistory.Enabled = (licenseID != -1);

           if(licenseID != -1 )
            {
                if (clsDetainAndReleaseLicense.isLicenseDetained(licenseID))
                {
                    MessageBox.Show("The selected license is already detained.", "Detained", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnDetainLicense.Enabled = false;
                }
            }

        }

        private void mtxtFind_Click(object sender, EventArgs e)
        {
            // To let the Caret be at the start of the MaskedTextBox
            int textLength = mtxtFineFees.Text.Trim().Length;
            mtxtFineFees.SelectionStart = textLength;
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(mtxtFineFees.Text))
            {
                MessageBox.Show("Please enter the fine fees first.", "Enter Fine Fees", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mtxtFineFees.Focus();
                return;
            }

            if (MessageBox.Show("Are you sure you wanna detain this license?", "Confirm Detain License", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _detainID = _DetainLicense(ctrLocalLicenseCardWithSearchBar1.GetCurrentLicenseID);
                if (_detainID != -1)
                {
                    MessageBox.Show($"License has been detained successfully with Detain ID ({_detainID}).", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _FillFormWithDetainedLicenseInfo();
                }
                else
                    MessageBox.Show("License has not been detained.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void llblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ctrLocalLicenseCardWithSearchBar1.GetCurrentLicenseID != -1)
            {
                clsLicense license = clsLicense.FindByLicenseID(ctrLocalLicenseCardWithSearchBar1.GetCurrentLicenseID);
                clsDriver driver = clsDriver.FindByDriverID(license.DriverID);
                frmLicenseHistory frm = new frmLicenseHistory(driver.PersonID);
                frm.ShowDialog();
            }
        }

        private void llblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ctrLocalLicenseCardWithSearchBar1.GetCurrentLicenseID != -1)
            {
                frmShowLicenseCard frm = new frmShowLicenseCard(ctrLocalLicenseCardWithSearchBar1.GetCurrentLicenseID);
                frm.ShowDialog();
            }
        }

    }
}
