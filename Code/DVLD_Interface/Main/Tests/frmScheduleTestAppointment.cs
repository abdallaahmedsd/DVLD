using DVLD_Business;
using DVLD_Interface.Properties;
using System;
using System.Data;
using System.Drawing;
using System.Net.Sockets;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Interface
{
    public partial class frmScheduleTestAppointment : Form
    {
        clsLDL_Application _LDL_Application;
        //int _testTypeID;
        clsTestType.enTestType _TestType = clsTestType.enTestType.VisionTest;

        public frmScheduleTestAppointment(int LDL_AppID, clsTestType.enTestType testType)
        {
            _TestType = testType;
            //_testTypeID = testTypeID;
            _LDL_Application = clsLDL_Application.Find(LDL_AppID);
            InitializeComponent();
        }

        static void _ChangeColumnName(DataTable dataTable, string originalColumnName, string newColumnName)
        {
            // Check if the original column exists
            if (dataTable.Columns.Contains(originalColumnName))
            {
                // Change the column name
                dataTable.Columns[originalColumnName].ColumnName = newColumnName;
            }
        }

        private void _Load_Refresh_Appointments(int LDL_AppID)
        {
            DataTable LoadRecords = clsTestAppointment.GetTestAppointmentsListPerTest(LDL_AppID, (int)_TestType);
            if (LoadRecords != null)
            {
                dgvTestAppointments.DataSource = LoadRecords;
                // Set Fill Mode to all cells
                dgvTestAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Change the column name
                _ChangeColumnName(LoadRecords, "TestAppointmentID", "Appointment ID");
                _ChangeColumnName(LoadRecords, "AppointmentDate", "Appointment Date");
                _ChangeColumnName(LoadRecords, "PaidFees", "Paid Fees");
                _ChangeColumnName(LoadRecords, "IsLocked", "is Locked?");

                // Set AutoSizeMode for the FullName column to AutoSize
                //dgvTestAppointments.Columns["Title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                // Customize the header style for the entire DataGridView
                DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
                headerStyle.Font = new Font("Arial", 10, FontStyle.Bold);
                headerStyle.BackColor = Color.LightBlue;
                headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Center the text
                dgvTestAppointments.ColumnHeadersDefaultCellStyle = headerStyle;

                // Customize the cell style for the entire DataGridView
                DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
                cellStyle.Font = new Font("Arial", 10); // Set the smaller font size
                dgvTestAppointments.DefaultCellStyle = cellStyle;

                lblTotalRecords.Text = LoadRecords.Rows.Count.ToString();
            }
        }

        private void _HandleTestImageAndTitle()
        {
            clsTestType testType = clsTestType.Find((int)_TestType);
            if (testType != null)
            {
                // Handle test image
                if (testType.TestTitle == "Vision Test")
                {
                    pbTestImage.Image = Resources.eye_bigger;
                    lblTitle.Text = "Vision Test Appointment";
                }
                else if (testType.TestTitle == "Written (Theory) Test")
                {
                    pbTestImage.Image = Resources.pencil;
                    lblTitle.Text = "Written Test Appointment";
                }
                else if (testType.TestTitle == "Practical (Street) Test")
                {
                    pbTestImage.Image = Resources.road;
                    lblTitle.Text = "Street Test Appointment";
                }
                else
                {
                    pbTestImage.Image = Resources.test;
                    lblTitle.Text = "Schedule Test Appointment";

                }
            }
        }

        private void _LoadData()
        {
            _HandleTestImageAndTitle();

            if (_LDL_Application != null)
            {
                ctrDrivingLicenseInformation1.Load_LDL_ApplicationInfo(_LDL_Application.LDL_AppID);
                ctrApplicationBasicInfo1.LoadApplicationInfo(_LDL_Application.ApplicationID);
                _Load_Refresh_Appointments(_LDL_Application.LDL_AppID);
            }
        }

        private bool _HasActiveAppointment()
        {
            return clsTestAppointment.HasActiveAppointment(_LDL_Application.LDL_AppID);
        }

        private bool _HasPassedTest(int LDL_AppID, int testTypeID)
        {
            return clsTestAppointment.HasPassedTest(LDL_AppID, testTypeID);
        }

        private bool _HasFailedTest(int LDL_AppID, int testTypeID)
        {
            return clsTestAppointment.HasFailedTest(LDL_AppID, testTypeID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmScheduleTestAppointment_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            if (_HasActiveAppointment())
            {
                MessageBox.Show("This person already has an active appointment for this test. You cannot add a new appointment", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(_HasPassedTest(_LDL_Application.LDL_AppID, (int)_TestType))
            {
                MessageBox.Show("This person already passed this test before, you can only retake failed test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            bool retakeTest = _HasFailedTest(_LDL_Application.LDL_AppID, (int)_TestType);
            frmScheduleTest frm = new frmScheduleTest(-1, _LDL_Application.LDL_AppID, _TestType, retakeTest);
            frm.ShowDialog();
            _Load_Refresh_Appointments(_LDL_Application.LDL_AppID);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool retakeTest = _HasFailedTest(_LDL_Application.LDL_AppID, (int)_TestType);
            frmScheduleTest frm = new frmScheduleTest((int)dgvTestAppointments.CurrentRow.Cells[0].Value, _LDL_Application.LDL_AppID, _TestType, retakeTest);
            frm.ShowDialog();
            _Load_Refresh_Appointments(_LDL_Application.LDL_AppID);
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsTestAppointment appointment = clsTestAppointment.Find((int)dgvTestAppointments.CurrentRow.Cells[0].Value);

            if (appointment != null) {

                if(appointment.isLocked)
                {
                    MessageBox.Show("This person has already took this test. Appointment is locked", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                frmTakeTest frm = new frmTakeTest((int)dgvTestAppointments.CurrentRow.Cells[0].Value, _LDL_Application.LDL_AppID, _TestType);
                frm.ShowDialog();
                _Load_Refresh_Appointments(_LDL_Application.LDL_AppID);
            }
        }

    }
}