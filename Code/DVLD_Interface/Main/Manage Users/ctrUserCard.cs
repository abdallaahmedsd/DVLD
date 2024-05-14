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
using System.Xml.Serialization;

namespace DVLD_Interface
{
    public partial class ctrUserCard : UserControl
    {
        public ctrUserCard()
        {
            InitializeComponent();
        }

        private clsUser _User;

        private void _FillUserCard()
        {
            lblUserID.Text = _User.UserID.ToString();
            lblUserName.Text = _User.UserName;
            if (_User.isActive)
                lblIsActive.Text = "Yes";
            else
                lblIsActive.Text = "No";
        }

        public void LoadUserInfo(int userID)
        {

            _User = clsUser.Find(userID);

            if (_User == null)
                MessageBox.Show($"User with ID {userID} doesn't exist", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                ctrPersonCard1.LoadPersonInfo(_User.PersonID);
                _FillUserCard();
            }
        }

    }
}
