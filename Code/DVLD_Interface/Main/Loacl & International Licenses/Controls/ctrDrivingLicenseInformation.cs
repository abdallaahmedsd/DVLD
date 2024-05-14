using DVLD_Business;
using System.Windows.Forms;

namespace DVLD_Interface
{
    public partial class ctrDrivingLicenseInformation : UserControl
    {
        clsLDL_Application _LDL_Application;

        public ctrDrivingLicenseInformation()
        {
            InitializeComponent();
        }

        public void Load_LDL_ApplicationInfo(int LDL_AppID)
        {
            _LDL_Application = clsLDL_Application.Find(LDL_AppID);
            if ( _LDL_Application != null )
            {
                lblDrivingLicenseAppID.Text = _LDL_Application.LDL_AppID.ToString();
                lblLicenseClass.Text = clsLicenseClass.Find(_LDL_Application.LicenseClassID).LicenseClassName;


                string passedTests = clsTest.GetTotalPassedTests(_LDL_Application.LDL_AppID).ToString();
                string countTests = clsTestType.GetTestTypesList().Rows.Count.ToString();
                
                lblPassedTests.Text = passedTests + "/" + countTests;
            }
        }

        public void EnableShowLicenseLink()
        {
            llblShowLicenseInfo.Enabled = true;
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clsLicense License = clsLicense.FindByApplicationID(_LDL_Application.ApplicationID);
            frmShowLicenseCard frm = new frmShowLicenseCard(License.LicenseID);
            frm.ShowDialog();
        }

    }
}
