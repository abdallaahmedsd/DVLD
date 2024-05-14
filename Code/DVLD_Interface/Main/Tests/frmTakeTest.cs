using DVLD_Business;
using DVLD_Interface.Properties;
using System;
using System.Windows.Forms;

namespace DVLD_Interface
{
    public partial class frmTakeTest : Form
    {
        int _testAppointmentID;
        int _LDL_AppID;

        clsTestAppointment _TestAppointment;
        clsLDL_Application _LDL_Application;
        clsApplication _Application;
        clsTestType _TestType;
        clsTestType.enTestType _TestTypeID;
        clsTest _Test;

        public frmTakeTest(int testAppointmentID, int LDL_AppID, clsTestType.enTestType testTypeID)
        {
            _testAppointmentID = testAppointmentID;
            _LDL_AppID = LDL_AppID;
            _TestTypeID = testTypeID;

            InitializeComponent();
        }

        private void _FillFormWithTestInfo()
        {
            _LDL_Application = clsLDL_Application.Find(_LDL_AppID);

            if (_LDL_Application != null)
            {
                lblDrivingLicenseAppID.Text = _LDL_AppID.ToString();
                lblLicenseClass.Text = clsLicenseClass.Find(_LDL_Application.LicenseClassID).LicenseClassName;
                lblTrail.Text = clsTest.CountFailedTests((int)_TestTypeID, _LDL_AppID).ToString();

                _Application = clsApplication.Find(_LDL_Application.ApplicationID);
                if (_Application != null)
                    lblName.Text = clsPerson.Find(_Application.ApplicantPersonID).FullName;

                _TestType = clsTestType.Find((int)_TestTypeID);
                if (_TestType != null)
                {
                    lblTestFees.Text = _TestType.TestFees.ToString("0.00");
                    gbTestInfo.Text = _TestType.TestTitle;

                    // Handle test image
                    if (_TestType.TestTitle == "Vision Test")
                        pbTestImage.Image = Resources.eye_bigger;
                    else if (_TestType.TestTitle == "Written (Theory) Test")
                        pbTestImage.Image = Resources.pencil;
                    else if (_TestType.TestTitle == "Practical (Street) Test")
                        pbTestImage.Image = Resources.road;
                    else
                        pbTestImage.Image = Resources.test;
                }

                _TestAppointment = clsTestAppointment.Find(_testAppointmentID);
                lblTestDate.Text = _TestAppointment.AppointmentDate.ToShortDateString();
            }
        }

        private void _FillTestObject()
        {
            _Test = new clsTest();

            _Test.AppointmentID = _testAppointmentID;
            _Test.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;
            _Test.TestResult = (rbPass.Checked ? true : false);
            _Test.Notes = txtNotes.Text;
        }

        private void _LoadData()
        {
            _FillFormWithTestInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you wanna save? After saving you cannot change Pass/Fail results. Are you still wanna save?", "Confirm Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _FillTestObject();

                if(_Test.Save())
                {
                    // Lock up the appointment for this test
                    _TestAppointment = clsTestAppointment.Find(_testAppointmentID);
                    _TestAppointment.isLocked = true;
                    _TestAppointment.Save();

                    MessageBox.Show("Data saved successfully!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cannot save test info", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
