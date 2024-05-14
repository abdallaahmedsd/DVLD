using DVLD_Business;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD_Interface
{
    public partial class frmManageAppTypes : Form
    {
        public frmManageAppTypes()
        {
            InitializeComponent();
        }

        static void ChangeColumnName(DataTable dataTable, string originalColumnName, string newColumnName)
        {
            // Check if the original column exists
            if (dataTable.Columns.Contains(originalColumnName))
            {
                // Change the column name
                dataTable.Columns[originalColumnName].ColumnName = newColumnName;
            }
        }

        private void _Load_Refresh_AppTypes()
        {
            DataTable LoadRecords = clsManageAppTypes.GetAppTypesList();
            if (LoadRecords != null)
            {
                dgvManageAppTypes.DataSource = LoadRecords;
                // Set Fill Mode to all cells
                dgvManageAppTypes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Change the column name
                ChangeColumnName(LoadRecords, "ApplicationTypeID", "ID");
                ChangeColumnName(LoadRecords, "ApplicationTypeTitle", "Title");
                ChangeColumnName(LoadRecords, "ApplicationFees", "Fees");

                // Set AutoSizeMode for the FullName column to AutoSize
                dgvManageAppTypes.Columns["Title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                // Customize the header style for the entire DataGridView
                DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
                headerStyle.Font = new Font("Arial", 10, FontStyle.Bold);
                headerStyle.BackColor = Color.LightBlue;
                headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Center the text
                dgvManageAppTypes.ColumnHeadersDefaultCellStyle = headerStyle;

                // Customize the cell style for the entire DataGridView
                DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
                cellStyle.Font = new Font("Arial", 10); // Set the smaller font size
                dgvManageAppTypes.DefaultCellStyle = cellStyle;

                lblTotalRecords.Text = LoadRecords.Rows.Count.ToString();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmManageAppTypes_Load(object sender, EventArgs e)
        {
            _Load_Refresh_AppTypes();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateManageAppTypes frm = new frmUpdateManageAppTypes((int)dgvManageAppTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _Load_Refresh_AppTypes();
        }
    }
}