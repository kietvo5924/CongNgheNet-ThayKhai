using CarRental_Business;
using CarRental_Business;
using CarRental.GlobalClasses;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace CarRental.Customers
{
    public partial class frmListCustomers : Form
    {
        private DataTable _dtAllCustomers;
        private const string ExportMenuItemName = "miExportCustomersData";

        private static string _LocalizeGender(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return value;

            string normalized = value.Trim().ToLowerInvariant();
            if (normalized == "male") return "Nam";
            if (normalized == "female") return "Nữ";
            return value;
        }

        private static string _EscapeRowFilterValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            return value.Replace("'", "''").Replace("[", "[[]").Replace("%", "[%]").Replace("*", "[*]");
        }

        private void _UpdateRecordsCount()
        {
            lblNumberOfRecords.Text = (_dtAllCustomers == null) ? "0" : _dtAllCustomers.DefaultView.Count.ToString();
            _UpdateEmptyState();
        }

        private void _UpdateEmptyState()
        {
            if (lblEmptyState == null)
                return;

            bool hasData = _dtAllCustomers != null && _dtAllCustomers.DefaultView.Count > 0;
            lblEmptyState.Visible = !hasData;

            if (!hasData)
                lblEmptyState.BringToFront();
        }

        private bool _TryGetSelectedCustomerID(out int customerID)
        {
            customerID = -1;

            if (dgvCustomersList.CurrentRow == null || dgvCustomersList.CurrentRow.Cells["CustomerID"] == null)
                return false;

            object value = dgvCustomersList.CurrentRow.Cells["CustomerID"].Value;
            return value != null && int.TryParse(value.ToString(), out customerID);
        }

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
            _UpdateRecordsCount();

            if (dgvCustomersList.Rows.Count > 0)
            {
                dgvCustomersList.Columns["CustomerID"].HeaderText = "Mã KH";
                dgvCustomersList.Columns["Name"].HeaderText = "Họ và tên";
                dgvCustomersList.Columns["Gender"].HeaderText = "Giới tính";
                dgvCustomersList.Columns["Phone"].HeaderText = "Số điện thoại";
                dgvCustomersList.Columns["Email"].HeaderText = "Email";
                dgvCustomersList.Columns["DriverLicenseNumber"].HeaderText = "Số bằng lái";

                if (dgvCustomersList.Columns.Contains("Country")) 
                    dgvCustomersList.Columns["Country"].HeaderText = "Tỉnh/Thành phố";
                else if (dgvCustomersList.Columns.Contains("CountryName")) 
                    dgvCustomersList.Columns["CountryName"].HeaderText = "Tỉnh/Thành phố";
                else if (dgvCustomersList.Columns.Contains("ProvinceName"))
                    dgvCustomersList.Columns["ProvinceName"].HeaderText = "Tỉnh/Thành phố";

                dgvCustomersList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void frmListCustomers_Load(object sender, EventArgs e)
        {
            cmsEditProfile.Opening += cmsEditProfile_Opening;
            dgvCustomersList.CellMouseDown += dgvCustomersList_CellMouseDown;
            dgvCustomersList.CellFormatting += dgvCustomersList_CellFormatting;
            _EnsureExportMenuItem();

            _RefreshCustomersList();
            cbFilter.SelectedIndex = 0;
        }

        private void dgvCustomersList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || e.Value == null)
                return;

            if (!dgvCustomersList.Columns[e.ColumnIndex].Name.Equals("Gender", StringComparison.OrdinalIgnoreCase))
                return;

            e.Value = _LocalizeGender(e.Value.ToString());
            e.FormattingApplied = true;
        }

        private void _EnsureExportMenuItem()
        {
            if (cmsEditProfile.Items[ExportMenuItemName] != null)
                return;

            cmsEditProfile.Items.Add(new ToolStripSeparator());
            ToolStripMenuItem exportItem = new ToolStripMenuItem("Xuất dữ liệu (CSV/Excel/PDF)")
            {
                Name = ExportMenuItemName
            };
            exportItem.Click += (s, e) => clsUtil.ExportDataGridView(dgvCustomersList, "DanhSachKhachHang", "Danh sách khách hàng");
            cmsEditProfile.Items.Add(exportItem);
        }

        private void cmsEditProfile_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = !_TryGetSelectedCustomerID(out _);
        }

        private void dgvCustomersList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.Button == MouseButtons.Right)
            {
                dgvCustomersList.ClearSelection();
                dgvCustomersList.Rows[e.RowIndex].Selected = true;
                dgvCustomersList.CurrentCell = dgvCustomersList.Rows[e.RowIndex].Cells[0];
            }
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
            _UpdateRecordsCount();
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
                {
                    if (int.TryParse(FilterValue, out int customerID))
                        _dtAllCustomers.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnName, customerID);
                    else
                        _dtAllCustomers.DefaultView.RowFilter = "1 = 0";
                }
                else
                    _dtAllCustomers.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", ColumnName, _EscapeRowFilterValue(FilterValue));
            }
            _UpdateRecordsCount();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Mã khách hàng")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            frmAddEditCustomer frm = new frmAddEditCustomer();
            frm.ShowDialog();
            _RefreshCustomersList();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_TryGetSelectedCustomerID(out int CustomerID))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xem.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmShowCustomerDetails frm = new frmShowCustomerDetails(CustomerID);
            frm.ShowDialog();
        }

        private void editCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_TryGetSelectedCustomerID(out int CustomerID))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmAddEditCustomer frm = new frmAddEditCustomer(CustomerID);
            frm.ShowDialog();
            _RefreshCustomersList();
        }

        private void deleteCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_TryGetSelectedCustomerID(out int CustomerID))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (clsCustomer.DeleteCustomer(CustomerID))
                {
                    MessageBox.Show("Xóa khách hàng thành công!", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshCustomersList();
                }
                else
                    MessageBox.Show("Không thể xóa khách hàng vì đang có lịch đặt xe liên quan!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCustomersList_DoubleClick(object sender, EventArgs e)
        {
            if (dgvCustomersList.Rows.Count > 0)
                showDetailsToolStripMenuItem.PerformClick();
        }
    }
}