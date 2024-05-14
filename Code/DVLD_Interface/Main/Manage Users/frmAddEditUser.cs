using DVLD_Business;
using DVLD_Interface.Global_Classes;
using System;
using System.Windows.Forms;


namespace DVLD_Interface
{
    public partial class frmAddEditUser : Form
    {
        public enum enMode { update_mode, add_new_mode}
        private enMode _Mode;
        int _userID;
        int _personID;
        clsUser _user;
        public frmAddEditUser(int userID)
        {
            _userID = userID;

            if (userID == -1)
                _Mode = enMode.add_new_mode;
            else
            {
                _Mode = enMode.update_mode;
            }

            InitializeComponent();
        }

        private void _FillFormWithUserInfo()
        {
            lblModeTitle.Text = "Update Person Details";

            lblUserID.Text = _user.UserID.ToString();
            txtUsername.Text = _user.UserName;

            txtPassword.Enabled = false;
            txtConfirmPassword.Enabled = false;

            if(_user.isActive)
                chkIsActive.Checked = true;
            else
                chkIsActive.Checked = false;

            ctrPersonCardWithSearchBar1.EnableSearchBar();
        }

        private void _FillUserObject()
        {
            _user.UserName = txtUsername.Text.Trim();
            _user.isActive = chkIsActive.Checked;

            if (_Mode == enMode.add_new_mode)
            {
                _user.PersonID = _personID;

                // Encrypt the password using the Secured Hash Algorithm SHA-256
                string hashPassword = clsUtil.ComputeHash(txtPassword.Text.Trim());
                _user.Password = hashPassword;
            }
        }

        private void _LoadData()
        {
            if (_Mode == enMode.add_new_mode)
            {
                lblModeTitle.Text = "Add New User";
                _user = new clsUser();
                return;
            }
            else
            {
                _user = clsUser.Find(_userID);

                if (_user == null)
                {
                    MessageBox.Show($"This form will close because user with ID {_userID} doesn't exist", "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                else
                {
                    ctrPersonCardWithSearchBar1.LoadPersonInfo(_user.PersonID);
                    _FillFormWithUserInfo();
                }
            }
        }

        private bool _isPersonAlreadyUser()
        {
            _personID = ctrPersonCardWithSearchBar1.CurrentPersonID;

            if (_personID != -1)
            {
                if (clsUser.isPersonAlreadyUser(_personID) && _Mode == enMode.add_new_mode)
                {
                    MessageBox.Show("Selected person is already a user, choose another person!", "Choose another person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
                else { return false; }
            }
            return false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tcAddEditUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isPersonAlreadyUser())
                return;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_isPersonAlreadyUser())
                return;

            tcAddEditUser.SelectedIndex = 1;
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

        private bool _isPasswordMath()
        {
            if (txtPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
            {
                errorProvider1.SetError(txtPassword, "Passwords are not match");
                errorProvider1.SetError(txtConfirmPassword, "Passwords are not match");

                return false;
            }
            else
            {
                errorProvider1.SetError(txtPassword, "");
                errorProvider1.SetError(txtConfirmPassword, "");

                return true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                _ValidateEmptyFields(txtUsername);
                return;
            }

            if (_Mode == enMode.add_new_mode)
            {
                if (string.IsNullOrWhiteSpace(txtPassword.Text) || string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
                {
                    _ValidateEmptyFields(txtPassword);
                    _ValidateEmptyFields(txtConfirmPassword);
                    return;
                }

                if (!_isPasswordMath())
                    return;
            }


            if(clsUser.isExist(txtUsername.Text))
            {
                if (_Mode == enMode.update_mode)
                {
                    if (_user.UserName == txtUsername.Text.Trim())
                        errorProvider1.SetError(txtUsername, "");
                    else
                    {
                        errorProvider1.SetError(txtUsername, "This name has been taken, choose another username");
                        return;
                    }
                }
                else
                {
                    errorProvider1.SetError(txtUsername, "This name has been taken, choose another username");
                    return;
                }
            }
            else
            {
                errorProvider1.SetError(txtUsername, "");
            }

            _FillUserObject();

            string modeText = (_Mode == enMode.add_new_mode ? "add" : "update");

            if(MessageBox.Show($"Are you sure you wanna {modeText} this user?", $"Confirm {modeText} user", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (_user.Save())
                {
                    if (_Mode == enMode.add_new_mode)
                    {
                        MessageBox.Show($"User added successfully with ID {_user.UserID}", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _Mode = enMode.update_mode;
                        _FillFormWithUserInfo();
                    }
                    else
                        MessageBox.Show($"User updated successfully!", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    if (_Mode == enMode.add_new_mode)
                        MessageBox.Show("Failed to add new user", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Failed to update user info", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmAddEditUser_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            tcAddEditUser.SelectedIndex = 0;
        }

        private void frmAddEditUser_Activated(object sender, EventArgs e)
        {
            ctrPersonCardWithSearchBar1.FilterFocus();
        }

    }
}
