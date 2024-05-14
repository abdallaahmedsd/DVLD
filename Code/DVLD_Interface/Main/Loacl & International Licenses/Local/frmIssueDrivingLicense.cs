using DVLD_Business;
using System;
using System.Windows.Forms;

namespace DVLD_Interface
{
    public partial class frmIssueDrivingLicense : Form
    {
        int _LDL_AppID;
        byte _issueReason = 1; // 1 == Issue for the first time
        private clsLDL_Application _LDL_Application;
        private clsApplication _Application;
        private clsDriver _Driver;
        private clsLicense _License;

        public frmIssueDrivingLicense(int LDL_AppID)
        {
            _LDL_AppID = LDL_AppID;
            InitializeComponent();
        }

        private void _LoadData()
        {
            _LDL_Application = clsLDL_Application.Find(_LDL_AppID);

            if(_LDL_Application != null )
            {
                _Application = clsApplication.Find(_LDL_Application.ApplicationID);
                ctrDrivingLicenseInformation1.Load_LDL_ApplicationInfo(_LDL_Application.LDL_AppID);
                ctrApplicationBasicInfo1.LoadApplicationInfo(_LDL_Application.ApplicationID);
            }
        }

        private void _FillDriverObject()
        {
            //_Driver = new clsDriver();
            _Driver.PersonID = _Application.ApplicantPersonID;
            _Driver.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;
            _Driver.CreationDate = DateTime.Now;
        }

        private void _FillLicenseObject()
        {
            _License = new clsLicense();
            _License.IssueReason = _issueReason;
            _License.ApplicationID = _Application.ApplicationID;
            _License.LicenseClassID = _LDL_Application.LicenseClassID;
            _License.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;
            _License.DriverID = _Driver.DriverID;
            _License.IssueDate = DateTime.Now;
            byte validYears = clsLicenseClass.Find(_LDL_Application.LicenseClassID).DefaultValidityLength;
            _License.ExpiryDate = _License.IssueDate.AddYears(validYears);
            _License.IsActive = true;
            _License.Notes = txtNotes.Text;
            _License.PaidFees = clsLicenseClass.Find(_LDL_Application.LicenseClassID).LicenseClassFees;
        }

        private void _IssueDrivingLicense()
        {
            // First add a new driver if does not already exist
            if (!clsDriver.isPersonAlreadyDriver(_Application.ApplicantPersonID))
            {
                _Driver = new clsDriver();
                _FillDriverObject();

                if(!_Driver.Save())
                {
                    MessageBox.Show($"Cannot add a new driver", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                _Driver = clsDriver.FindByPersonID(_Application.ApplicantPersonID);
            }


            _FillLicenseObject();

            if (_License.Save())
            {
                // Set the application status to be completed, so you can't edit or delete anymore 
                _Application.ApplicationStatusID = 3; // 3 == completed
                _Application.LastStatusDate = DateTime.Now;
                _Application.Save();

                MessageBox.Show($"License has been issued successfully with ID {_License.LicenseID}", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                clsDriver.DeleteDriver(_Driver.DriverID);
                MessageBox.Show($"License has not been issued!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmIssueDrivingLicense_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnIssueLicense_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you wanna issue a new license?", "Confirm Issue", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                _IssueDrivingLicense();
        }
    }
}
