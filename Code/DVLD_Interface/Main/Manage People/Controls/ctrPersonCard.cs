using DVLD_Business;
using DVLD_Interface.Properties;
using System.IO;
using System.Windows.Forms;

namespace DVLD_Interface
{
    public partial class ctrPersonCard : UserControl
    {
        public ctrPersonCard()
        {
            InitializeComponent();
        }

        clsPerson _Person;

        private void _FillPersonCard()
        {
            lblPersonID.Text = _Person.PersonID.ToString();
            lblNationalNo.Text = _Person.NationalNumber;
            lblEmail.Text = _Person.Email;
            lblPhone.Text = _Person.Phone;
            lblGender.Text = (_Person.Gender == 'F' ? "Female" : "Male");
            lblBirthdate.Text = _Person.DateOfBirth.ToShortDateString();
            lblCountry.Text = clsCountry.Find(_Person.CountryID).CountryName; // ( +1 because the comboBox is zero indexing ) 
            lblAddress.Text = _Person.Address;
            lblFullName.Text = _Person.FullName;

            if (_Person.Gender == 'M')
                pbGenderIcon.Image = Resources.man;
            else
                pbGenderIcon.Image = Resources.women;

            if(string.IsNullOrWhiteSpace(_Person.ImagePath))
            {
                if (_Person.Gender == 'M')
                    pbPersonImage.Image = Resources.male1;
                else
                    pbPersonImage.Image = Resources.female;
            }
            else
            {
                if(File.Exists(_Person.ImagePath)) 
                    pbPersonImage.ImageLocation = _Person.ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + _Person.ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadPersonInfo(int personID)
        {
            //this._PersonID = personID;

            _Person = clsPerson.Find(personID);

            if (_Person == null)
                MessageBox.Show($"Person with ID {personID} doesn't exist", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                _FillPersonCard();
        }

        public int CurrentPersonID
        {
            get
            {
                if ( _Person != null)
                    return _Person.PersonID;
                else
                    return -1;
            }
        }

        private void llblEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_Person == null)
            {
                MessageBox.Show("There's no person to edit", "Empty Card", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmAddEditPerson frm = new frmAddEditPerson(_Person.PersonID);
            frm.ShowDialog();

            // Refresh person data
            LoadPersonInfo(_Person.PersonID);
        }

    }
}
