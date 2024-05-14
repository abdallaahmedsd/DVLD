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
    public partial class frmManageTestTypes : Form
    {
        public frmManageTestTypes()
        {
            InitializeComponent();
        }

        static void _ChangeColumnName(DataTable dataTable, string originalColumnName, string newColumnName)
        {
            // Check if the original column exists
            if (dataTable.Columns.Contains(originalColumnName))
            {
                // Change the column name
                dataTable.Columns[originalColumnName].ColumnName = newColumnName;
            }
        }

        private void _Load_Refresh_TestTypes()
        {
            DataTable LoadRecords = clsTestType.GetTestTypesList();
            if (LoadRecords != null)
            {
                dgvManageTestTypes.DataSource = LoadRecords;
                // Set Fill Mode to all cells
                dgvManageTestTypes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Change the column name
                _ChangeColumnName(LoadRecords, "TestTypeID", "ID");
                _ChangeColumnName(LoadRecords, "TestTypeTitle", "Title");
                _ChangeColumnName(LoadRecords, "TestTypeDescription", "Description");
                _ChangeColumnName(LoadRecords, "TestTypeFees", "Fees");

                // Set AutoSizeMode for the FullName column to AutoSize
                //dgvManageTestTypes.Columns["Title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                // Customize the header style for the entire DataGridView
                DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
                headerStyle.Font = new Font("Arial", 10, FontStyle.Bold);
                headerStyle.BackColor = Color.LightBlue;
                headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Center the text
                dgvManageTestTypes.ColumnHeadersDefaultCellStyle = headerStyle;

                // Customize the cell style for the entire DataGridView
                DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
                cellStyle.Font = new Font("Arial", 10); // Set the smaller font size
                dgvManageTestTypes.DefaultCellStyle = cellStyle;

                lblTotalRecords.Text = LoadRecords.Rows.Count.ToString();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            _Load_Refresh_TestTypes();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateTestType frm = new frmUpdateTestType((int)dgvManageTestTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _Load_Refresh_TestTypes();
        }
    }
}
