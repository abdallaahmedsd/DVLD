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
    public partial class frmUserInfo : Form
    {
        int _userID;
        public frmUserInfo(int userID)
        {
            _userID = userID;
            InitializeComponent();
        }

        private void frmUserInfo_Load(object sender, EventArgs e)
        {
            ctrUserCard1.LoadUserInfo(_userID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
