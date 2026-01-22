using CarRental_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace CarRental.Customers
{
    public partial class frmListCustomers : Form
    {
        private DataTable _dtAllCustomers;

        public frmListCustomers()
        {
            InitializeComponent();
        }

        private string _GetRealColumnNameInDB()
        {
            switch (cbFilter.Text)
            {
                case "Mã khách hàng": return "CustomerID";
                case "Họ tên": return "Name";
                case "Số điện thoại": return "Phone";
                case "Số bằng lái": return "DriverLicenseNumber";
                default: return "None";
            }
        }

        private void _RefreshCustomersList()
        {
            _dtAllCustomers = clsCustomer.GetAllCustomers();
            dgvCustomersList.DataSource = _dtAllCustomers;
            lblNumberOfRecords.Text = dgvCustomersList.Rows.Count.ToString();

            if (dgvCustomersList.Rows.Count > 0)
            {
                dgvCustomersList.Columns["CustomerID"].HeaderText = "Mã KH";
                dgvCustomersList.Columns["Name"].HeaderText = "Họ và tên";
                dgvCustomersList.Columns["Gender"].HeaderText = "Giới tính";
                dgvCustomersList.Columns["Phone"].HeaderText = "Số điện thoại";
                dgvCustomersList.Columns["Email"].HeaderText = "Email";
                dgvCustomersList.Columns["DriverLicenseNumber"].HeaderText = "Số bằng lái";

                if (dgvCustomersList.Columns.Contains("Country")) 
                    dgvCustomersList.Columns["Country"].HeaderText = "Province";
                else if (dgvCustomersList.Columns.Contains("CountryName")) 
                    dgvCustomersList.Columns["CountryName"].HeaderText = "Province";
                else if (dgvCustomersList.Columns.Contains("ProvinceName"))
                    dgvCustomersList.Columns["ProvinceName"].HeaderText = "Tỉnh/Thành phố";

                dgvCustomersList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void frmListCustomers_Load(object sender, EventArgs e)
        {
            _RefreshCustomersList();
            cbFilter.SelectedIndex = 0;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Visible = (cbFilter.Text != "Không lọc");
            if (txtSearch.Visible)
            {
                txtSearch.Clear();
                txtSearch.Focus();
            }
            if (_dtAllCustomers != null)
                _dtAllCustomers.DefaultView.RowFilter = "";
            lblNumberOfRecords.Text = dgvCustomersList.Rows.Count.ToString();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_dtAllCustomers == null || _dtAllCustomers.Rows.Count == 0) return;

            string ColumnName = _GetRealColumnNameInDB();
            string FilterValue = txtSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(FilterValue) || cbFilter.Text == "Không lọc")
                _dtAllCustomers.DefaultView.RowFilter = "";
            else
            {
                if (ColumnName == "CustomerID")
                    _dtAllCustomers.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnName, FilterValue);
                else
                    _dtAllCustomers.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", ColumnName, FilterValue);
            }
            lblNumberOfRecords.Text = dgvCustomersList.Rows.Count.ToString();
        }

        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            frmAddEditCustomer frm = new frmAddEditCustomer();
            frm.ShowDialog();
            _RefreshCustomersList();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int CustomerID = (int)dgvCustomersList.CurrentRow.Cells["CustomerID"].Value;
            frmShowCustomerDetails frm = new frmShowCustomerDetails(CustomerID);
            frm.ShowDialog();
        }

        private void editCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int CustomerID = (int)dgvCustomersList.CurrentRow.Cells["CustomerID"].Value;
            frmAddEditCustomer frm = new frmAddEditCustomer(CustomerID);
            frm.ShowDialog();
            _RefreshCustomersList();
        }

        private void deleteCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int CustomerID = (int)dgvCustomersList.CurrentRow.Cells["CustomerID"].Value;
                if (clsCustomer.DeleteCustomer(CustomerID))
                {
                    MessageBox.Show("Xóa khách hàng thành công!", "Thông báo");
                    _RefreshCustomersList();
                }
                else
                    MessageBox.Show("Không thể xóa khách hàng vì đang có lịch đặt xe liên quan!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCustomersList_DoubleClick(object sender, EventArgs e)
        {
            showDetailsToolStripMenuItem.PerformClick();
        }
    }
}