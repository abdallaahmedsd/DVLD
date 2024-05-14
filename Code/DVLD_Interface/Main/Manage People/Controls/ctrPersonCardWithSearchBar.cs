using DVLD_Business;
using System;
using System.Windows.Forms;

namespace DVLD_Interface
{
    public partial class ctrPersonCardWithSearchBar : UserControl
    {
        public ctrPersonCardWithSearchBar()
        {
            InitializeComponent();
        }

        private clsPerson _Person;

        public void FilterFocus()
        {
            txtFindBy.Focus();
        }

        public void LoadPersonInfo(int personId)
        {
            ctrPersonCard1.LoadPersonInfo(personId);
        }

        public int CurrentPersonID
        {
            get
            {
                return ctrPersonCard1.CurrentPersonID;
            }
        }

        public void EnableSearchBar()
        {
            gbFindBy.Enabled = false;
        }

        private void _FindPerson()
        {
            if (!string.IsNullOrWhiteSpace(txtFindBy.Text))
            {
                if (cbFindBy.Text == "Person ID")
                    _Person = clsPerson.Find(int.Parse(txtFindBy.Text.Trim()));
                else if (cbFindBy.Text == "National No")
                    _Person = clsPerson.Find(txtFindBy.Text.Trim());
            }
        }

        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a digit or a control key (e.g., Backspace, Delete)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If not a digit or a control key, suppress the key press
                e.Handled = true;
            }
        }

        private void ctrPersonCardWithSearchBar_Load(object sender, EventArgs e)
        {
            cbFindBy.SelectedIndex = 1;
            txtFindBy.Focus();
        }

        private void txtFindBy_KeyUp(object sender, KeyEventArgs e)
        {
            if((e.KeyCode == Keys.Enter) && !string.IsNullOrWhiteSpace(cbFindBy.Text))
            {
                btnFindPerson.PerformClick();
                txtFindBy.Clear();
            }
        }

        private void cbFindBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFindBy.Focus();
            txtFindBy.Clear();

            if (cbFindBy.Text == "User ID")
                txtFindBy.KeyPress += NumericTextBox_KeyPress;
            else
                txtFindBy.KeyPress -= NumericTextBox_KeyPress;
        }

        private void btnFindPerson_Click(object sender, EventArgs e)
        {
            _FindPerson();

            if(_Person != null)
            {
                ctrPersonCard1.LoadPersonInfo(_Person.PersonID);
                //txtFindBy.Clear();
            }
            else
            {
                if(!string.IsNullOrWhiteSpace(txtFindBy.Text))
                    MessageBox.Show($"There is no person with {cbFindBy.Text} = {txtFindBy.Text}", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson(-1);

            frm.DataBack += _getPersonIdFrom_frmAddNewPerson; // Subscribe to the event

            frm.ShowDialog();
        }

        private void _getPersonIdFrom_frmAddNewPerson(object sender, int personID)
        {
            if(personID != -1)
            {
                _Person = clsPerson.Find(personID);

                if (_Person != null)
                {
                    txtFindBy.Text = personID.ToString();
                    cbFindBy.SelectedIndex = 0;
                    ctrPersonCard1.LoadPersonInfo(_Person.PersonID);
                }
            }
        }

    }
}
