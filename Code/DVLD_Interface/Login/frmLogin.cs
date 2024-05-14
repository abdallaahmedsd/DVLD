using DVLD_Business;
using DVLD_Interface.Global_Classes;
using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace DVLD_Interface
{
    public partial class frmLogin : Form
    {
        // The path to save the login info into Windows Registry
        private string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";

        public frmLogin()
        {
            InitializeComponent();
        }

        private void CheckLogin()
        {
            if (!string.IsNullOrWhiteSpace(txtUsername.Text) && !string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                // Encrypt the password using SHA-256 to compare it with the encrypted password in the database
                string hashPassword = clsUtil.ComputeHash(txtPassword.Text.Trim());

                if (clsUser.isExist(txtUsername.Text.Trim(), hashPassword))
                {
                    clsUser user = clsUser.Find(txtUsername.Text.Trim());
                    
                    if(user != null)
                    {
                        if(user.isActive)
                        {
                            _RememberUsernameAndPassword();

                            clsGlobalSettings.CurrentUser = user;
                            this.Hide();
                            Form form = new frmMain(this);
                            form.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Your account is deactivated, please contact your admin", "Deactivated Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
                else
                {
                    if (clsUser.isExist(txtUsername.Text))
                    {
                        errorProvider1.SetError(txtPassword, "Wrong password");
                    }
                    else
                    {
                        errorProvider1.SetError(txtUsername, "Invalid username");
                        errorProvider1.SetError(txtPassword, "Wrong password");
                    }
                }
            }
            else
            {
                if(string.IsNullOrWhiteSpace(txtUsername.Text))
                    errorProvider1.SetError(txtUsername, "Username cannot be empty");

                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                    errorProvider1.SetError(txtPassword, "Password cannot be empty");
            }
        }

        private void Validate_and_Perform_Click(TextBox textBox, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
            else
            {

                if (!string.IsNullOrWhiteSpace(textBox.Text))
                    errorProvider1.Clear();
                else
                    errorProvider1.SetError(textBox, textBox.Tag + " cannot be empty");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            CheckLogin();
        }

        private void txtUsername_KeyUp(object sender, KeyEventArgs e)
        {
            Validate_and_Perform_Click(txtUsername, e);
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            Validate_and_Perform_Click(txtPassword, e);
        }

        private void _RememberUsernameAndPassword()
        {
            if (chkRememberMe.Checked)
            {
                // Save login info into Windows Registry
                try
                {
                    Registry.SetValue(KeyPath, "Username", txtUsername.Text.Trim());
                    Registry.SetValue(KeyPath, "Password", txtPassword.Text.Trim());
                    Registry.SetValue(KeyPath, "Remember Me", "True");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            else
            {
                // Delete login info from Windows Registry 
                try
                {
                    // Open the registry key in read/write mode with explicit registry view
                    using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                    {
                        using (RegistryKey key = baseKey.OpenSubKey(@"SOFTWARE\DVLD", true))
                        {
                            if (key != null)
                            {
                                // Check if there is no saved user info
                                string rememberMe = key.GetValue("Remember Me") as string;
                                if (rememberMe == "False")
                                    return;

                                // Delete the specified value
                                key.DeleteValue("Username");
                                key.DeleteValue("Password");
                                key.SetValue("Remember Me", "False", RegistryValueKind.String); 
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }

        private void _LoadLoginInfoFromWindowsRegistry()
        {
            try
            {
                string rememberMe = Registry.GetValue(KeyPath, "Remember Me", null) as string;

                if(rememberMe != null && rememberMe == "True")
                {
                    string username = Registry.GetValue(KeyPath, "Username", null) as string;
                    string password = Registry.GetValue(KeyPath, "Password", null) as string;

                    txtUsername.Text = username;
                    txtPassword.Text = password;
                    chkRememberMe.Checked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            _LoadLoginInfoFromWindowsRegistry();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}