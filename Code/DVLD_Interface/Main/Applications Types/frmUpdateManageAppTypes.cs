using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Interface
{
    public partial class frmUpdateManageAppTypes : Form
    {
        private clsManageAppTypes _service;
        public frmUpdateManageAppTypes(int appID)
        {
            _service = clsManageAppTypes.Find(appID);
            InitializeComponent();
        }

        private void _NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a digit or a control key (e.g., Backspace, Delete)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If not a digit or a control key, suppress the key press
                e.Handled = true;
            }
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

        private void _LoadData()
        {
            if (_service != null)
            {
                lblAppID.Text = _service.ApplicationID.ToString();
                txtAppFees.Text = _service.ApplicationFees.ToString();
                txtAppTitle.Text = _service.ApplicationTitle;
            }
        }

        private void _FillServiceObject()
        {
            _service.ApplicationTitle = txtAppTitle.Text;
            _service.ApplicationFees = Convert.ToDecimal(txtAppFees.Text);
        }

        private void frmUpdateManageAppTypes_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtAppFees_KeyUp(object sender, KeyEventArgs e)
        {
            txtAppFees.KeyPress += _NumericTextBox_KeyPress;
        }

        private void _PerformClick(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.PerformClick();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtAppTitle.Text) || string.IsNullOrWhiteSpace(txtAppFees.Text))
            {
                _ValidateEmptyFields(txtAppTitle);
                _ValidateEmptyFields(txtAppFees);

                return;
            }

            if (_service != null)
            {
                _FillServiceObject();

                if (MessageBox.Show($"Are you sure you wanna update this service?", $"Confirm update service", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (_service.Update())
                    {
                        MessageBox.Show("Service has been updated successfully!", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _LoadData();
                    }
                    else
                        MessageBox.Show("Service has not been updated", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


    }
}
