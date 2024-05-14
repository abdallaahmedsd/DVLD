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
    public partial class frmUpdateTestType : Form
    {
        clsTestType _Test;
        public frmUpdateTestType(int testTypeID)
        {
            _Test = clsTestType.Find(testTypeID);

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
            if (_Test != null)
            {
                lblTestID.Text = _Test.TestID.ToString();
                txtTestFees.Text = _Test.TestFees.ToString();
                txtTestDescription.Text = _Test.TestDescription;
                txtTestTitle.Text = _Test.TestTitle;
            }
        }

        private void _FillServiceObject()
        {
            _Test.TestTitle = txtTestTitle.Text;
            _Test.TestDescription = txtTestDescription.Text;
            _Test.TestFees = Convert.ToDecimal(txtTestFees.Text);
        }

        private void _PerformClick(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.PerformClick();
            }
        }

        private void frmUpdateTestType_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTestTitle.Text) || string.IsNullOrWhiteSpace(txtTestFees.Text)
                || string.IsNullOrWhiteSpace(txtTestDescription.Text))
            {
                _ValidateEmptyFields(txtTestTitle);
                _ValidateEmptyFields(txtTestFees);
                _ValidateEmptyFields(txtTestDescription);

                return;
            }

            if (_Test != null)
            {
                _FillServiceObject();

                if (MessageBox.Show($"Are you sure you wanna update this test info?", $"Confirm update test", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (_Test.Update())
                    {
                        MessageBox.Show("Test info has been updated successfully!", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _LoadData();
                    }
                    else
                        MessageBox.Show("Test has not been updated", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
