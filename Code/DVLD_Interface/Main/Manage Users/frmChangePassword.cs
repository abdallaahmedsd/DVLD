using DVLD_Business;
using DVLD_Interface.Global_Classes;
using System;
using System.Windows.Forms;

namespace DVLD_Interface
{
    public partial class frmChangePassword : Form
    {
        clsUser _user;
        public frmChangePassword(int userID)
        {
             _user = clsUser.Find(userID);

            InitializeComponent();
        }

        private void _UpdatePassword()
        {
            if (_user != null)
            {
                // Encrypt the password using the Secured Hash Algorithm SHA-256
                string hashPassword = clsUtil.ComputeHash(txtNewPassword.Text.Trim());
                _user.Password = hashPassword;

                if (_user.Save())
                    MessageBox.Show($"Password updated successfully!", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Failed to update the password", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _LoadData()
        {
            if (_user != null)
                ctrUserCard1.LoadUserInfo(_user.UserID);
        }

        private bool _ValidateEmptyFields(TextBox textBox)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                errorProvider1.SetError(textBox, "This field cannot be empty");
                return false;
            }
            else
            {
                errorProvider1.SetError(textBox, "");
                return true;
            }
        }

        private bool _confirmPassword()
        {
            if (txtNewPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
            {
                errorProvider1.SetError(txtNewPassword, "Passwords are not match");
                errorProvider1.SetError(txtConfirmPassword, "Passwords are not match");

                return false;
            }
            else
            {
                errorProvider1.SetError(txtNewPassword, "");
                errorProvider1.SetError(txtConfirmPassword, "");

                return true;
            }
        }

        private bool _isCurrentPasswordMatch()
        {
            // Encrypt the password using SHA-256 to compare it with the encrypted password in the database
            string hashPassword = clsUtil.ComputeHash(txtCurrentPassword.Text.Trim());

            if (_user.Password != hashPassword)
            {
                errorProvider1.SetError(txtCurrentPassword, "Current password does not match your password");

                return false;
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, "");

                return true;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtCurrentPassword.Text) || string.IsNullOrWhiteSpace(txtNewPassword.Text) 
                || string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                _ValidateEmptyFields(txtCurrentPassword);
                _ValidateEmptyFields(txtNewPassword);
                _ValidateEmptyFields(txtConfirmPassword);

                return;
            }

            if (!_confirmPassword() || !_isCurrentPasswordMatch())
                return;

            if (MessageBox.Show($"Are you sure you wanna update the password?", $"Confirm updating password", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                _UpdatePassword();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

    }
}
