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
    public partial class frmPersonDetails : Form
    {
        int _personID;
        public frmPersonDetails(int personID)
        {
            _personID = personID;
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPersonDetails_Load(object sender, EventArgs e)
        {
            ctrPersonCard1.LoadPersonInfo(_personID);
        }
    }
}
