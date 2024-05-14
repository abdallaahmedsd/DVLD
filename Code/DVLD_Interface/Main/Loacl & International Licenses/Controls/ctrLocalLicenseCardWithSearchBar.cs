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
    public partial class ctrLocalLicenseCardWithSearchBar : UserControl
    {
        public ctrLocalLicenseCardWithSearchBar()
        {
            InitializeComponent();
        }

        // Define a custom event handler
        public event Action<int> OnLicenseSelected;

        // A method to raise the event with a parameter
        protected virtual void LicenseSelected(int LicenseID)
        {
            Action<int> handler = OnLicenseSelected;
            if (handler != null)
            {
                handler(LicenseID); // Raise the event with the parameter
            }
        }

        public void FilterFocus()
        {
            mtxtFind.Focus();
        }

        public int GetCurrentLicenseID
        {
            get { return ctrDriverCard1.GetCurrentLicenseID; }
        }

        public void EnableFilterLicenses()
        {
            gbFind.Enabled = false;
        }

        public void LoadLicenseInfo(int licenseID)
        {
            ctrDriverCard1.LoadLicenseInfo(licenseID);
            gbFind.Enabled = false;
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

        private void btnFindLicense_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(mtxtFind.Text))
            {
                ctrDriverCard1.LoadLicenseInfo(int.Parse(mtxtFind.Text));

                if (OnLicenseSelected != null)
                {
                    // Raise the event with a parameter
                    OnLicenseSelected(GetCurrentLicenseID);
                }
            }
        }

        private void mtxtFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnFindLicense.PerformClick();
        }

        private void ctrLocalLicenseCardWithSearchBar_Load(object sender, EventArgs e)
        {
            mtxtFind.Focus();
        }

        private void mtxtFind_Click(object sender, EventArgs e)
        {
            // To let the Caret be at the start of the MaskedTextBox
            int textLength = mtxtFind.Text.Trim().Length;
            mtxtFind.SelectionStart = textLength;
        }

    }
}
