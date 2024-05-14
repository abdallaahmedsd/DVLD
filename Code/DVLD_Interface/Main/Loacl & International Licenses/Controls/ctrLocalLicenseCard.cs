using DVLD_Business;
using DVLD_Interface.Properties;
using System.Windows.Forms;

namespace DVLD_Interface
{
    public partial class ctrDriverCard : UserControl
    {
        private clsPerson _Person;
        private clsLicense _License;
        private clsDriver _Driver;
        private clsLicenseClass _LicenseClass;

        public ctrDriverCard()
        {
            InitializeComponent();
        }

        public int GetCurrentLicenseID
        {
            get 
            {
                if (_License != null)
                    return _License.LicenseID;
                else
                    return -1;
            }
        }

        private void _FillLicenseCard()
        {
            lblLicenseClass.Text = _LicenseClass.LicenseClassName;
            lblFullName.Text = _Person.FullName;
            lblLicenseID.Text = _License.LicenseID.ToString();
            lblNationalNo.Text = _Person.NationalNumber;
            lblGender.Text = (_Person.Gender == 'F' ? "Female" : "Male");
            lblBirthdate.Text = _Person.DateOfBirth.ToShortDateString();
            lblIssueDate.Text = _License.IssueDate.ToShortDateString();
            lblExpiryDate.Text = _License.ExpiryDate.ToShortDateString();
            lblIssueReason.Text = ((_License.IssueReason == 1) ? "First Time" : (_License.IssueReason == 2) ? "Renew" : (_License.IssueReason == 3) ? "Replacement For Lost" : (_License.IssueReason == 4) ? "Replacement For Damage" : "Not Handled");
            lblNotes.Text = (string.IsNullOrWhiteSpace(_License.Notes) ? "No Notes" : _License.Notes);
            lbl_isActive.Text = (_License.IsActive ? "Yes" : "No");
            lbl_isDetained.Text = (clsDetainAndReleaseLicense.isLicenseDetained(_License.LicenseID) ? "Yes" : "No");
            lblDriverID.Text = _Driver.DriverID.ToString();

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

        public void LoadLicenseInfo(int LicenseID)
        {
            _License = clsLicense.FindByLicenseID(LicenseID);

            if (_License == null)
                MessageBox.Show($"License with ID ({LicenseID}) doesn't exist", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                _Driver = clsDriver.FindByDriverID(_License.DriverID);
                _Person = clsPerson.Find(_Driver.PersonID);
                _LicenseClass = clsLicenseClass.Find(_License.LicenseClassID);
                _FillLicenseCard();
            }
        }

    }
}
