using DVLD_Business;
using DVLD_Interface.Properties;
using System;
using System.Windows.Forms;

namespace DVLD_Interface
{
    public partial class frmScheduleTest : Form
    {
        int _testAppointmentID;
        int _LDL_AppID;
        bool _retakeTest;

        clsTestAppointment _TestAppointment;
        clsLDL_Application _LDL_Application;
        clsApplication _Application;
        clsTestType _TestType;
        clsManageAppTypes _service = clsManageAppTypes.Find((int)clsApplication.enApplicationType.RetakeTest);
        clsTestType.enTestType _TestTypeID;

        private enum enMode { update_mode, add_new_mode }
        private enMode _mode;

        public frmScheduleTest(int testAppointmentID ,int LDL_AppID, clsTestType.enTestType testTypeID, bool retakeTest)
        {
            _testAppointmentID = testAppointmentID;
            _LDL_AppID = LDL_AppID;
            _TestTypeID = testTypeID;
            _retakeTest = retakeTest;

            if( testAppointmentID == -1 )
            {
                _mode = enMode.add_new_mode;
            }
            else
            {
                _mode = enMode.update_mode;
            }

            InitializeComponent();
        }

        private void _HandleTestAppointmentDate()
        {
            if (_mode == enMode.update_mode)
            {
                _TestAppointment = clsTestAppointment.Find(_testAppointmentID);
                if (_TestAppointment != null)
                {
                    dtpTestDate.Value = _TestAppointment.AppointmentDate;
                    dtpTestDate.MinDate = _TestAppointment.AppointmentDate;
                    dtpTestDate.MaxDate = _TestAppointment.AppointmentDate.AddMonths(6);
                }
            }
            else
            {
                dtpTestDate.Value = DateTime.Now;
                dtpTestDate.MinDate = DateTime.Now;
                dtpTestDate.MaxDate = DateTime.Now.AddMonths(6);
            }
        }

        private void _FillFormWithTestAppointmentInfo()
        {
            _LDL_Application = clsLDL_Application.Find(_LDL_AppID);

            if (_LDL_Application != null)
            {
                lblDrivingLicenseAppID.Text = _LDL_AppID.ToString();
                lblLicenseClass.Text = clsLicenseClass.Find(_LDL_Application.LicenseClassID).LicenseClassName;

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
            }

            _HandleTestAppointmentDate();

            if(_retakeTest)
            {
                if(_service != null)
                {
                    gbRetakeTestInfo.Enabled = true;
                    lblRetakeTestFees.Text = _service.ApplicationFees.ToString("0.00");
                    lblTotalFees.Text = (_service.ApplicationFees + _TestType.TestFees).ToString("0.00");
                    lblTitle.Text = "Schedule Retake Test";
                    lblTitle.Location = new System.Drawing.Point(95, 102);

                    //if(_mode == enMode.update_mode)
                    //{
                        
                    //}

                }
            }
        }

        private void _FillTestAppointmentObject()
        {
            _TestAppointment.TestTypeID = _TestType.TestID;

            // incase retake test add retake test fees to test type fees
            if(_retakeTest && _service != null)
                _TestAppointment.PaidFees = _TestType.TestFees + _service.ApplicationFees;
            else
                _TestAppointment.PaidFees = _TestType.TestFees;

            _TestAppointment.LDL_ApplicationID = _LDL_AppID;
            _TestAppointment.AppointmentDate = dtpTestDate.Value;
            _TestAppointment.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;
            _TestAppointment.isLocked = false;
        }

        private void _LoadData()
        {
            if (_mode == enMode.add_new_mode)
            {
                _TestAppointment = new clsTestAppointment();
                _FillFormWithTestAppointmentInfo();
                return;
            }
            else
            {
                _TestAppointment = clsTestAppointment.Find(_testAppointmentID);

                if (_TestAppointment == null)
                {
                    MessageBox.Show($"This form will close because test appointment with ID {_testAppointmentID} doesn't exist", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                else
                {
                    if(_TestAppointment.isLocked)
                    {
                        btnSave.Enabled = false;
                        dtpTestDate.Enabled = false;
                        lblShowMessage.Visible = true;
                    }

                    _FillFormWithTestAppointmentInfo();
                }
            }
        }

        private void _CreateRetakeTestApplication()
        {
            clsApplication application = new clsApplication();

            application.ApplicantPersonID = _Application.ApplicantPersonID;
            application.ApplicationDate = DateTime.Now;
            application.LastStatusDate = DateTime.Now;
            application.PaidFees = _service.ApplicationFees;
            application.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;
            application.ApplicationTypeID = _service.ApplicationID;
            application.ApplicationStatusID = 3; // Completed application

            application.Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string modeText = (_mode == enMode.add_new_mode ? "add" : "update");
            if (MessageBox.Show($"Are you sure you wanna {modeText} this appointment?", $"Confirm {modeText} appointment", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                _FillTestAppointmentObject();

                if (_TestAppointment.Save())
                {
                    if (_mode == enMode.add_new_mode)
                    {
                        if(_retakeTest)
                        {
                            _CreateRetakeTestApplication();
                        }

                        MessageBox.Show($"Appointment added successfully with ID {_TestAppointment.TestAppointmentID}", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _mode = enMode.update_mode;
                    }
                    else
                        MessageBox.Show($"Appointment updated successfully!", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                else
                {
                    if (_mode == enMode.add_new_mode)
                        MessageBox.Show("Failed to add a new appointment", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Failed to update a appointment info", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
