using DVLD_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD_Interface
{
    public partial class frmAddEditLocalLicenseApp : Form
    {
        private int _LDL_AppID;
        //private int _ApplicationID;
        private clsApplication _Application;
        private clsLDL_Application _LDL_Application;
        private clsManageAppTypes _Service = clsManageAppTypes.Find((int)clsApplication.enApplicationType.NewDrivingLicense);
        private enum enMode { update_mode, add_new_mode }
        private enMode _Mode;

        public frmAddEditLocalLicenseApp(int LDL_AppID)
        {
            //_ApplicationID = LDL_ApplicationID;
            _LDL_AppID = LDL_AppID;

            if (LDL_AppID == -1)
                _Mode = enMode.add_new_mode;
            else
                _Mode = enMode.update_mode;

                InitializeComponent();
        }

        private void _LoadLicenseClassesInSelectBox()
        {
            DataTable countries = clsLicenseClass.GetLicenseClassesList();

            if (countries != null)
            {
                foreach (DataRow row in countries.Rows)
                {
                    cbLicenseClasses.Items.Add(row["ClassName"].ToString());
                }

                cbLicenseClasses.SelectedIndex = 2;
            }
        }

        private void _FillFormWithApplicationInfo()
        {
            lblModeTitle.Text = "Update Local Driving License Application";

            lblAppID.Text = _LDL_Application.LDL_AppID.ToString();  
            lblAppDate.Text = _Application.ApplicationDate.ToString();

            //this will select the license class in the comboBox.
            cbLicenseClasses.SelectedIndex = cbLicenseClasses.FindString(clsLicenseClass.Find(_LDL_Application.LicenseClassID).LicenseClassName);
            lblMoney.Text = _Application.PaidFees.ToString();
            lblCreatedBy.Text = clsUser.Find(_Application.CreatedByUserID).UserName;

            ctrPersonCardWithSearchBar1.LoadPersonInfo(_Application.ApplicantPersonID);
            ctrPersonCardWithSearchBar1.EnableSearchBar();
        }

        private void _Fill_LDL_AppObject()
        {
            
            _LDL_Application.ApplicationID = _Application.ApplicationID;
            _LDL_Application.LicenseClassID = clsLicenseClass.Find(cbLicenseClasses.Text).LicenseClassID;   

        }

        private void _FillApplicationObject()
        {
            if(_Mode == enMode.add_new_mode)
            {
                _Application.CreatedByUserID = clsGlobalSettings.CurrentUser.UserID;
                _Application.ApplicantPersonID = ctrPersonCardWithSearchBar1.CurrentPersonID;
                _Application.ApplicationDate = DateTime.Now;
                _Application.LastStatusDate = DateTime.Now;
                _Application.ApplicationStatusID = 1; // 1 = New Application
                _Application.PaidFees = _Service.ApplicationFees;
                _Application.ApplicationTypeID = _Service.ApplicationID; // Local Driving License
            }

        }

        private bool isPersonHasActiveApplicationWithSameClass()
        {
            int licenseClassID = clsLicenseClass.Find(cbLicenseClasses.Text).LicenseClassID;
            int applicantPersonID = ctrPersonCardWithSearchBar1.CurrentPersonID;

            int result = clsLDL_Application.isPersonHasActiveApplicationWithSameClass(applicantPersonID, licenseClassID);

            if (result != -1)
            {
                MessageBox.Show($"Choose another license class, the selected person already has an active application for the selected license class with ID = {result}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool _isPersonHaveLicenseWithSameClass()
        {
            int licenseClassID = clsLicenseClass.Find(cbLicenseClasses.Text).LicenseClassID;
            int applicantPersonID = ctrPersonCardWithSearchBar1.CurrentPersonID;

            clsDriver driver = clsDriver.FindByPersonID(applicantPersonID);

            if (driver != null)
            {
                bool result = clsLicense.isPersonHaveLicenseWithSameClass(licenseClassID, driver.DriverID);

                if (result)
                {
                    MessageBox.Show("The selected person already has a license with the same applied driving class. Please choose a different driving class}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }

            return false;
        }

        private int _CalculateAge(DateTime birthdate)
        {
            DateTime dateNow = DateTime.Now;
            int age = dateNow.Year - birthdate.Year;

            // Check if the birthday has occurred this year
            if (birthdate > dateNow.AddYears(-age))
                age--;

            return age;
        }

        private void _LoadData()
        {
            _LoadLicenseClassesInSelectBox();

            lblAppDate.Text = DateTime.Now.ToShortDateString();

            // Get the current user name
            lblCreatedBy.Text = clsGlobalSettings.CurrentUser.UserName;

            // Get the current application fees
            if (_Service != null)
            {
                decimal feesAmount = _Service.ApplicationFees;
                lblMoney.Text = $"${feesAmount:n2}";
            }

            // Create an object
            if (_Mode == enMode.add_new_mode)
            {
                lblModeTitle.Text = "New Local Driving License Application";
                _LDL_Application = new clsLDL_Application();
                _Application = new clsApplication();
                return;
            }
            else
            {
                //_Application = clsApplication.Find(_ApplicationID);
                _LDL_Application = clsLDL_Application.Find(_LDL_AppID);

                if (_LDL_Application == null)
                {
                    MessageBox.Show($"This form will close because LDL_App with ID {_LDL_AppID} doesn't exist", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                else
                {
                    _Application = clsApplication.Find(_LDL_Application.ApplicationID);

                    if (_Application == null)
                        return;

                    ctrPersonCardWithSearchBar1.LoadPersonInfo(_Application.ApplicantPersonID);
                    _FillFormWithApplicationInfo();
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tcNewLocalLicenseApp.SelectedIndex = 1;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            tcNewLocalLicenseApp.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNewLocalLicenseApp_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // If you didn't choose a person yet
            if(ctrPersonCardWithSearchBar1.CurrentPersonID == -1)
            {
                MessageBox.Show("Please select a person first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if person age is matching the minimum allowed age for this license class
            clsPerson person = clsPerson.Find(ctrPersonCardWithSearchBar1.CurrentPersonID);
            clsLicenseClass licenseClass = clsLicenseClass.Find(cbLicenseClasses.SelectedItem.ToString());
            if(_CalculateAge(person.DateOfBirth) < licenseClass.MinimumAllowedAge)
            {
                MessageBox.Show($"The selected person's age is less than the minimum allowed age for this license class. Minimum age is {licenseClass.MinimumAllowedAge}", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // check if person already have a license with the selected driving license class
            if (_isPersonHaveLicenseWithSameClass())
                return;

            // Check if the current person has an open application with the same LicenseClass and the ApplicationStatus is new 
            if (isPersonHasActiveApplicationWithSameClass())
                return;

            _FillApplicationObject();
            string modeText = (_Mode == enMode.add_new_mode ? "add" : "update");

            if (MessageBox.Show($"Are you sure you wanna {modeText} this application?", $"Confirm {modeText} application", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (_Application.Save())
                {
                    _Fill_LDL_AppObject();
                    if (_LDL_Application.Save())
                    {
                        if (_Mode == enMode.add_new_mode)
                        {
                            MessageBox.Show($"Application added successfully with ID {_LDL_Application.LDL_AppID}", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _Mode = enMode.update_mode;
                            _FillFormWithApplicationInfo();
                        }
                        else
                            MessageBox.Show($"Application updated successfully!", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (_Mode == enMode.add_new_mode)
                            MessageBox.Show("Failed to add new LDL_Application", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            MessageBox.Show("Failed to update LDL_Application info", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (_Mode == enMode.add_new_mode)
                        MessageBox.Show("Failed to add new application", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Failed to update application info", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmAddEditLocalLicenseApp_Activated(object sender, EventArgs e)
        {
            ctrPersonCardWithSearchBar1.FilterFocus();
        }

    }
}