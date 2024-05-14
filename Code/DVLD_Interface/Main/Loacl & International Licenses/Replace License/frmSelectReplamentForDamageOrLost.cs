using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Interface.Main.Licenses.Replace_License
{
    public partial class frmChooseReplacementForDamageOrLost : Form
    {
        public frmChooseReplacementForDamageOrLost()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(rbLostLicense.Checked)
            {
                frmReplaceLicense frm = new frmReplaceLicense(clsApplication.enApplicationType.ReplaceLostDrivingLicense);
                frm.ShowDialog();
            }
            else
            {
                frmReplaceLicense frm = new frmReplaceLicense(clsApplication.enApplicationType.ReplaceDamagedDrivingLicense);
                frm.ShowDialog();
            }

            this.Close();
        }
    }
}
