using System;
using System.Windows.Forms;

namespace DVLD_Interface
{
    public partial class frmShowLicenseCard : Form
    {
        int _LicenseID;
        public frmShowLicenseCard(int LicenseID)
        {
            _LicenseID = LicenseID;
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowLicenseCard_Load(object sender, EventArgs e)
        {
            ctrDriverCard1.LoadLicenseInfo(_LicenseID);
        }
    }
}
