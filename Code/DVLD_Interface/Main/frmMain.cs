using DVLD_Interface.Main.Detain_Licenses;
using DVLD_Interface.Main.Licenses;
using DVLD_Interface.Main.Licenses.Replace_License;
using DVLD_Interface.Main.Mange_Detained_Licenses;
using DVLD_Interface.Main.Renew_License;
using System;
using System.Windows.Forms;

namespace DVLD_Interface
{
    public partial class frmMain : Form
    {
        frmLogin _frmLogin;
        public frmMain(frmLogin from)
        {
            _frmLogin = from;
            InitializeComponent();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmManagePeople();
            form.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDrivers frm = new frmManageDrivers();
            frm.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmManageUsers();
            form.ShowDialog();
        }

        private void logUtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobalSettings.CurrentUser = null;
            this.Close();
            _frmLogin.Show();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo(clsGlobalSettings.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(clsGlobalSettings.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageAppTypes frm = new frmManageAppTypes();
            frm.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestTypes frm = new frmManageTestTypes();
            frm.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicense frm = new frmNewInternationalLicense();
            frm.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditLocalLicenseApp frm = new frmAddEditLocalLicenseApp(-1);
            frm.ShowDialog();
        }

        private void internationalLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManage_LDL_Applications frm = new frmManage_LDL_Applications();
            frm.ShowDialog();
        }

        private void internationalLicenseApplicationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmManageInternationalLicenses frm = new frmManageInternationalLicenses();
            frm.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLicense frm = new frmRenewLicense();    
            frm.ShowDialog();
        }

        private void replacementForLostOrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChooseReplacementForDamageOrLost frm = new frmChooseReplacementForDamageOrLost();
            frm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseLicense frm = new frmReleaseLicense(-1);
            frm.ShowDialog();
        }

        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseLicense frm = new frmReleaseLicense(-1);
            frm.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManage_LDL_Applications frm = new frmManage_LDL_Applications();
            frm.ShowDialog();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDetainedLicenses frm = new frmManageDetainedLicenses();    
            frm.ShowDialog();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(clsGlobalSettings.CurrentUser != null)
                Application.Exit();
        }
    }
}
