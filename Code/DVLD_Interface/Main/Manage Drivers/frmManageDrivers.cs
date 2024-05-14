using DVLD_Business;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD_Interface
{
    public partial class frmManageDrivers : Form
    {
        DataTable dtDrivers;
        public frmManageDrivers()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void _Filter()
        {
            if (cbFilterBy.Text == "None")
            {
                txtFilterBy.Visible = false;

                // Select all LDL_Apps
                _ShowAllDrivers();
            }
            else
            {
                txtFilterBy.Visible = true;
                txtFilterBy.Focus();
                if (cbFilterBy.Text == "Person ID")
                {
                    txtFilterBy.KeyPress += _NumericTextBox_KeyPress;
                    _FilterBy("personID");
                }
                else if (cbFilterBy.Text == "Driver ID")
                {
                    txtFilterBy.KeyPress += _NumericTextBox_KeyPress;
                    _FilterBy("DriverID");
                }
                else if (cbFilterBy.Text == "National No")
                {
                    txtFilterBy.KeyPress -= _NumericTextBox_KeyPress;
                    _FilterBy("NationalNo");
                }
                else if (cbFilterBy.Text == "Full Name")
                {
                    txtFilterBy.KeyPress -= _NumericTextBox_KeyPress;
                    _FilterBy("FullName");
                }
            }
        }

        private void _FilterBy(string fieldName)
        {
            DataView DriversDataView = dtDrivers.DefaultView;

            if (!string.IsNullOrWhiteSpace(txtFilterBy.Text))
            {
                string searchFor = txtFilterBy.Text;
                string sign = "=";

                if (fieldName == "NationalNo" || fieldName == "FullName")
                {
                    searchFor = $"'%{searchFor}%'";
                    sign = "LIKE";
                }

                DriversDataView.RowFilter = $"{fieldName} {sign} {searchFor}";
                dgvDrivers.DataSource = DriversDataView;
                lblTotalRecords.Text = DriversDataView.Count.ToString();
            }
            else
            {
                _ShowAllDrivers();
            }

        }

        private void _ShowAllDrivers()
        {
            DataView DriversDataView = dtDrivers.DefaultView;
            DriversDataView.RowFilter = "";
            dgvDrivers.DataSource = DriversDataView;
            lblTotalRecords.Text = DriversDataView.Count.ToString();
        }

        private void _LoadData()
        {
            dtDrivers = clsDriver.GetDriversList();
            if (dtDrivers != null)
            {
                dgvDrivers.DataSource = dtDrivers;
                // Set Fill Mode to all cells
                dgvDrivers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Change the columns name
                dgvDrivers.Columns["DriverID"].HeaderText = "Driver ID";
                dgvDrivers.Columns["PersonID"].HeaderText = "Person ID";
                dgvDrivers.Columns["NationalNo"].HeaderText = "National No";
                dgvDrivers.Columns["FullName"].HeaderText = "Full Name";
                dgvDrivers.Columns["CreationDate"].HeaderText = "Creation Date";
                dgvDrivers.Columns["ActiveLicenses"].HeaderText = "Active Licenses";

                //Set AutoSizeMode for the FullName column to AutoSize
                dgvDrivers.Columns["FullName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                // Customize the header style for the entire DataGridView
                DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
                headerStyle.Font = new Font("Arial", 9, FontStyle.Bold);
                headerStyle.BackColor = Color.LightBlue;
                headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Center the text
                dgvDrivers.ColumnHeadersDefaultCellStyle = headerStyle;

                // Customize the cell style for the entire DataGridView
                DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
                cellStyle.Font = new Font("Arial", 9); // Set the smaller font size
                dgvDrivers.DefaultCellStyle = cellStyle;

                lblTotalRecords.Text = dtDrivers.Rows.Count.ToString();
            }
        }

        private void frmManageDrivers_Load(object sender, EventArgs e)
        {
            _LoadData();
            cbFilterBy.SelectedIndex = 0;
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterBy.Clear();
            _Filter();
        }

        private void txtFilterBy_KeyUp(object sender, KeyEventArgs e)
        {
            _Filter();
        }

    }
}
