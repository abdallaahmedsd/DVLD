using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Interface.Main.Licenses
{
    public partial class frmShowInternationalLicenseCard : Form
    {
        int _internationalLicenseID;
        public frmShowInternationalLicenseCard(int internationalLicenseID)
        {
            _internationalLicenseID = internationalLicenseID;
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowInternationalLicenseCard_Load(object sender, EventArgs e)
        {
            ctrInternationalLicenseCard1.LoadInternationalLicenseInfo(_internationalLicenseID);
        }
    }
}
