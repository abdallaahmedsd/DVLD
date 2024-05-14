using DVLD_Business;
using DVLD_Interface.Properties;
using System;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using DVLD_Interface.Global_Classes;

namespace DVLD_Interface
{
    public partial class frmAddEditPerson : Form
    {
        public enum enMode { update_mode, add_new_mode }
        enMode _Mode;
        int _PersonID = -1;
        clsPerson _Person;
        public frmAddEditPerson(int personID)
        {
            _PersonID = personID;

            if (personID == -1)
                _Mode = enMode.add_new_mode;
            else
                _Mode = enMode.update_mode;

            InitializeComponent();
        }

        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int personID);

        // Declare an event using the above delegate
        public event DataBackEventHandler DataBack;

        private void _LoadData()
        {
            _SetMaxAndMinDateOfBirth();
            _LoadCountriesInSelectBox();

            // this will set the default country to Sudan.
            cbCountries.SelectedIndex = cbCountries.FindString("Sudan");

            if (_Mode  == enMode.add_new_mode)
            {
                lblModeTitle.Text = "Add New Person";
                _Person = new clsPerson();
                return;
            } 
            else
            {
                _Person = clsPerson.Find(_PersonID);

                if(_Person == null )
                {
                    MessageBox.Show($"This form will close because person with ID {_PersonID} doesn't exist", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                else
                {
                    _FillFormWithPersonInfo();
                }
            }
        }

        private bool _HandlePersonImage()
        {
            /* this procedure will handle the person image,
            it will take care of deleting the old image from the folder
            in case the image changed. and it will rename the new image with guid and 
            place it in the images folder. */


            //_Person.ImagePath contains the old Image, we check if it changed then we copy the new image
            if (_Person.ImagePath != pbPersonImage.ImageLocation)
            {
                if (_Person.ImagePath != string.Empty)
                {
                    //first we delete the old image from the folder in case there is any.
                    try
                    {
                        File.Delete(_Person.ImagePath);

                        // Reset the image path to Empty after deleting the image
                        _Person.ImagePath = string.Empty;
                    }
                    catch (IOException e)
                    {
                        MessageBox.Show($"An IOException occurred: {e.Message}", "Error Deleting Person Image", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                if (pbPersonImage.ImageLocation != null)
                {
                    //then we copy the new image to the image folder after we rename it
                    string SourceImageFile = pbPersonImage.ImageLocation.ToString();

                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbPersonImage.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

            return true;
        }

        private void _LoadCountriesInSelectBox()
        {
            DataTable countries = clsCountry.GetCountriesList();

            foreach (DataRow row in countries.Rows)
            {
                cbCountries.Items.Add(row["CountryName"].ToString());
            }

        }

        private void _SetMaxAndMinDateOfBirth()
        {
            // Set the minimum allowed age to 18 and maximum to 100
            dtpBirthdate.MaxDate = DateTime.Now.AddYears(-18);
            dtpBirthdate.MinDate = DateTime.Now.AddYears(-100);
            dtpBirthdate.Value = dtpBirthdate.MaxDate;
        }

        private void _FillPersonObject()
        {
            _Person.FirstName = txtFirstName.Text.Trim();
            _Person.SecondName = txtSecondName.Text.Trim();
            _Person.ThirdName = txtThirdName.Text.Trim();
            _Person.LastName = txtLastName.Text.Trim();
            _Person.Address = txtAddress.Text.Trim();
            _Person.Phone = txtPhone.Text.Trim();
            _Person.Email = txtEmail.Text.Trim();
            _Person.NationalNumber = txtNationalNo.Text.Trim();
            _Person.DateOfBirth = dtpBirthdate.Value;
            _Person.CountryID = clsCountry.Find(cbCountries.Text.Trim()).CountryID;

            if (radBtnFemale.Checked)
                _Person.Gender = 'F';
            else
                _Person.Gender = 'M';

            if (pbPersonImage.ImageLocation != null)
                _Person.ImagePath = pbPersonImage.ImageLocation;
            else
                _Person.ImagePath = string.Empty;
        }

        private void _FillFormWithPersonInfo()
        {
            lblModeTitle.Text = "Update Person Details";

            lblPersonID.Text = _Person.PersonID.ToString();
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            txtNationalNo.Text = _Person.NationalNumber;
            dtpBirthdate.Value = _Person.DateOfBirth;
            txtPhone.Text = _Person.Phone;
            txtEmail.Text = _Person.Email;
            txtAddress.Text = _Person.Address;

            if (_Person.Gender == 'F')
                radBtnFemale.Checked = true;
            else
                radBtnMale.Checked = true;

            if(_Person.ImagePath != "")
                pbPersonImage.ImageLocation =  _Person.ImagePath;

            llblRemoveImage.Visible = (_Person.ImagePath != "");

            //this will select the country in the comboBox.
            cbCountries.SelectedIndex = cbCountries.FindString(clsCountry.Find(_Person.CountryID).CountryName);
        }

        private bool _ValidateEmptyFields(TextBox textBox)
        {
            if(string.IsNullOrWhiteSpace(textBox.Text))
            {
                errorProvider1.SetError(textBox, $"{textBox.Tag} cannot be empty");
                return false;
            }
            else
            {
                errorProvider1.SetError(textBox, null);
                return true;
            }
        }

        private bool _ValidateEmail()
        {
            string email = txtEmail.Text.Trim();

            // Define a regular expression pattern for a simple email validation
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Check if the email matches the pattern
            if (Regex.IsMatch(email, pattern))
            {
                // Valid email
                errorProvider1.SetError(txtEmail, ""); // Clear any previous error
                return true;
            }
            else 
            {
                // Invalid email
                errorProvider1.SetError(txtEmail, "Invalid email address");
                return false;
            }
        }

        private void frmAddEditPerson_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void llblRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.ImageLocation = null;
            llblRemoveImage.Visible = false;


            if(radBtnFemale.Checked)
                pbPersonImage.Image = Resources.female;
            else
                pbPersonImage.Image = Resources.male1;
        }

        private void radBtnMale_CheckedChanged(object sender, EventArgs e)
        {
            if(pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Resources.male1;
        }

        private void radBtnFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Resources.female;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // Trigger the event to send data back to the invoker form
            int personID = (_Person.PersonID != -1) ? _Person.PersonID : -1;
            DataBack?.Invoke(this, personID);


            this.Close();
        }

        private void llblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ofdSetImage.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            ofdSetImage.FilterIndex = 1;
            ofdSetImage.RestoreDirectory = true;

            if (ofdSetImage.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = ofdSetImage.FileName;
                pbPersonImage.ImageLocation = selectedFilePath;
                llblRemoveImage.Visible = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtSecondName.Text)
                || string.IsNullOrWhiteSpace(txtLastName.Text) || string.IsNullOrWhiteSpace(txtPhone.Text) 
                || string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                _ValidateEmptyFields(txtFirstName);
                _ValidateEmptyFields(txtSecondName);
                _ValidateEmptyFields(txtLastName);
                _ValidateEmptyFields(txtPhone);
                _ValidateEmptyFields(txtAddress);
                _ValidateEmptyFields(txtNationalNo);

                return;
            }

            if(!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                if (!_ValidateEmail())
                    return;
            }


            //Handle person image
            if(!_HandlePersonImage())
            {
                MessageBox.Show($"Cannot handle person image", $"Error", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            _FillPersonObject();

            string modeText = (_Mode == enMode.add_new_mode ? "add" : "update");
            if (MessageBox.Show($"Are you sure you wanna {modeText} this person?", $"Confirm {modeText} person", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (_Person.Save())
                {
                    if (_Mode == enMode.add_new_mode)
                    {
                        MessageBox.Show($"Person added successfully with ID {_Person.PersonID}", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Mode = enMode.update_mode;
                        _FillFormWithPersonInfo();
                    }
                    else
                        MessageBox.Show($"Person updated successfully!", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    if (_Mode == enMode.add_new_mode)
                        MessageBox.Show("Failed to add new person", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Failed to update person info", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void txtFirstName_KeyUp(object sender, KeyEventArgs e)
        {
            _ValidateEmptyFields(txtFirstName);
        }

        private void txtSecondName_KeyUp(object sender, KeyEventArgs e)
        {
            _ValidateEmptyFields(txtSecondName);
        }

        private void txtLastName_KeyUp(object sender, KeyEventArgs e)
        {
            _ValidateEmptyFields(txtLastName);
        }

        private void txtPhone_KeyUp(object sender, KeyEventArgs e)
        {
            _ValidateEmptyFields(txtPhone);
        }

        private void txtAddress_KeyUp(object sender, KeyEventArgs e)
        {
            _ValidateEmptyFields(txtAddress);
        }

        private void txtNationalNo_KeyUp(object sender, KeyEventArgs e)
        {
            _ValidateEmptyFields(txtNationalNo);
        }
        
        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNationalNo.Text.Trim()))
            {
                if (txtNationalNo.Text.Trim() != _Person.NationalNumber && clsPerson.isExist(txtNationalNo.Text.Trim()))
                {
                    e.Cancel = true;
                    txtNationalNo.Focus();
                    errorProvider1.SetError(txtNationalNo, "This national is already exist");
                    btnSave.Enabled = false;
                }
                else
                    btnSave.Enabled = true;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtNationalNo, "");
            }
        }

    }
}