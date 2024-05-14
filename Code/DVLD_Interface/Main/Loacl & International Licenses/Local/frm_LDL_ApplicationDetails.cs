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

namespace DVLD_Interface
{
    public partial class frm_LDL_ApplicationDetails : Form
    {
        int _LDL_AppID;
        public frm_LDL_ApplicationDetails(int LDL_AppID)
        {
            _LDL_AppID = LDL_AppID;
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_LDL_ApplicationDetails_Load(object sender, EventArgs e)
        {
            clsLDL_Application LDL_Application = clsLDL_Application.Find(_LDL_AppID);
            if (LDL_Application != null)
            {
                ctrDrivingLicenseInformation1.Load_LDL_ApplicationInfo(LDL_Application.LDL_AppID);
                ctrApplicationBasicInfo1.LoadApplicationInfo(LDL_Application.ApplicationID);
                
                clsApplication Application = clsApplication.Find(LDL_Application.ApplicationID);
                if (Application != null && Application.ApplicationStatusID == 3) // 3 == Completed
                {
                    ctrDrivingLicenseInformation1.EnableShowLicenseLink();
                }
            }
        }

    }
}
