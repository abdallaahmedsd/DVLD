using DVLD_Business;
using DVLD_Interface.Properties;
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
    public partial class ctrInternationalLicenseCard : UserControl
    {
        private clsPerson _Person;
        private clsDriver _Driver;
        private clsInternationalLicense _InternationalLicense;

        public ctrInternationalLicenseCard()
        {
            InitializeComponent();
        }

        public int GetCurrentInternationalLicenseID
        {
            get
            {
                if (_InternationalLicense != null)
                    return _InternationalLicense.InternationalLicenseID;
                else
                    return -1;
            }
        }

        private void _FillInternationalLicenseCard()
        {
            lblFullName.Text = _Person.FullName;
            lblInternationalLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString();
            lblLicenseID.Text = _InternationalLicense.IssuedUsingLocalLicenseID.ToString();
            lblNationalNo.Text = _Person.NationalNumber;
            lblGender.Text = (_Person.Gender == 'F' ? "Female" : "Male");
            lblIssueDate.Text = _InternationalLicense.IssueDate.ToShortDateString();

            lblApplicationID.Text = _InternationalLicense.ApplicationID.ToString();
            lbl_isActive.Text = (_InternationalLicense.IsActive ? "Yes" : "No");
            lblBirthdate.Text = _Person.DateOfBirth.ToShortDateString();
            lblDriverID.Text = _InternationalLicense.DriverID.ToString();
            lblExpiryDate.Text = _InternationalLicense.ExpiryDate.ToShortDateString();

            if (_Person.Gender == 'M')
                pbGenderIcon.Image = Resources.man;
            else
                pbGenderIcon.Image = Resources.women;

            if (string.IsNullOrWhiteSpace(_Person.ImagePath))
            {
                if (_Person.Gender == 'M')
                    pbPersonImage.Image = Resources.male1;
                else
                    pbPersonImage.Image = Resources.female;
            }
            else
            {
                pbPersonImage.Load(_Person.ImagePath);
            }
        }

        public void LoadInternationalLicenseInfo(int internationalLicenseID)
        {
            _InternationalLicense = clsInternationalLicense.FindByInternationalLicenseID(internationalLicenseID);

            if (_InternationalLicense == null)
                MessageBox.Show($"International license with ID ({_InternationalLicense}) doesn't exist", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                _Driver = clsDriver.FindByDriverID(_InternationalLicense.DriverID);
                _Person = clsPerson.Find(_Driver.PersonID);
                _FillInternationalLicenseCard();
            }
        }
    }
}
