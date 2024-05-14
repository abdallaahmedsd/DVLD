using DVLD_Business;
using System.Windows.Forms;

namespace DVLD_Interface
{
    public partial class ctrApplicationBasicInfo : UserControl
    {
        clsApplication application;
        public ctrApplicationBasicInfo()
        {
            InitializeComponent();
        }
        
        public void LoadApplicationInfo(int applicationID)
        {
            application = clsApplication.Find(applicationID);
            if (application != null)
            {
                lblAppID.Text = application.ApplicationID.ToString();
                lblStatus.Text = (application.ApplicationStatusID == 1) ? "New" : ((application.ApplicationStatusID == 2) ? "Canceled" : "Completed");
                lblFees.Text = application.PaidFees.ToString("0.00");
                lblApplicationType.Text = clsManageAppTypes.Find(application.ApplicationTypeID).ApplicationTitle.ToString();
                lblApplicantName.Text = clsPerson.Find(application.ApplicantPersonID).FullName;
                lblApplicationDate.Text = application.ApplicationDate.ToShortDateString();
                lblStatusDate.Text = application.LastStatusDate.ToShortDateString();
                lblCreatedBy.Text = clsUser.Find(application.CreatedByUserID).UserName;
            }
        }

        private void llViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(application != null)
            {
                frmPersonDetails frm = new frmPersonDetails(application.ApplicantPersonID);
                frm.ShowDialog();
            }
        }

    }
}