using CarRental.GlobalClasses;
using CarRental_Business;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CarRental.Users
{
    public partial class frmListUsers : Form
    {
        private DataTable _dtAllUsers;

        public frmListUsers()
        {
            InitializeComponent();
        }

        private void _FillCountryComboBox()
        {
            cbCountry.SelectedIndexChanged -= cbCountry_SelectedIndexChanged;

            DataTable dtProvinces = _EnsureProvinceTableSchema(clsProvince.GetAllProvinces());

            DataRow allRow = dtProvinces.NewRow();
            allRow["ProvinceID"] = 0;
            allRow["ProvinceName"] = "Tất cả";
            dtProvinces.Rows.InsertAt(allRow, 0);

            cbCountry.DataSource = dtProvinces;
            cbCountry.DisplayMember = "ProvinceName";
            cbCountry.ValueMember = "ProvinceID";
            cbCountry.SelectedIndex = 0;

            cbCountry.SelectedIndexChanged += cbCountry_SelectedIndexChanged;
        }

        private DataTable _EnsureProvinceTableSchema(DataTable dtProvinces)
        {
            if (dtProvinces == null)
                dtProvinces = new DataTable();

            if (!dtProvinces.Columns.Contains("ProvinceID"))
            {
                dtProvinces.Columns.Add("ProvinceID", typeof(int));

                if (dtProvinces.Columns.Contains("CountryID"))
                {
                    foreach (DataRow row in dtProvinces.Rows)
                    {
                        if (row["CountryID"] != DBNull.Value)
                            row["ProvinceID"] = row["CountryID"];
                    }
                }
            }

            if (!dtProvinces.Columns.Contains("ProvinceName"))
                dtProvinces.Columns.Add("ProvinceName", typeof(string));

            return dtProvinces;
        }

        private string _GetProvinceColumnName()
        {
            if (_dtAllUsers != null)
            {
                if (_dtAllUsers.Columns.Contains("ProvinceName"))
                    return "ProvinceName";
                if (_dtAllUsers.Columns.Contains("Country"))
                    return "Country";
            }

            return "ProvinceName";
        }

        private string _GetRealColumnNameInDB()
        {
            switch (cbFilter.Text)
            {
                case "Mã người dùng": return "UserID";
                case "Họ tên": return "Name";
                case "Tên đăng nhập": return "Username";
                case "Giới tính": return "Gender";
                case "Tỉnh/Thành phố": return _GetProvinceColumnName();
                case "Trạng thái": return "IsActive";
                default: return "None";
            }
        }

        private void _RefreshUsersList()
        {
            _dtAllUsers = clsUser.GetAllUsers();
            dgvUsersList.DataSource = _dtAllUsers;
            lblNumberOfRecords.Text = dgvUsersList.Rows.Count.ToString();

            if (dgvUsersList.Rows.Count > 0)
            {
                dgvUsersList.Columns[0].HeaderText = "Mã người dùng";
                dgvUsersList.Columns[1].HeaderText = "Họ tên";
                dgvUsersList.Columns[2].HeaderText = "Giới tính";
                dgvUsersList.Columns[3].HeaderText = "Ngày sinh";
                dgvUsersList.Columns[4].HeaderText = "Tên đăng nhập";
                dgvUsersList.Columns[5].HeaderText = "Tỉnh/Thành phố";
                dgvUsersList.Columns[6].HeaderText = "Ngày tạo";
                dgvUsersList.Columns[7].HeaderText = "Trạng thái";

                var provinceColumn = dgvUsersList.Columns["ProvinceName"] ?? dgvUsersList.Columns["Country"];
                if (provinceColumn != null)
                    provinceColumn.HeaderText = "Tỉnh/Thành phố";
                dgvUsersList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private int _GetUserIDFromDGV()
        {
            return (int)dgvUsersList.CurrentRow.Cells["UserID"].Value;
        }

        private void frmListUsers_Load(object sender, EventArgs e)
        {
            _RefreshUsersList();
            _FillCountryComboBox();
            cbFilter.SelectedIndex = 0;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Visible = (cbFilter.Text != "Không lọc") && (cbFilter.Text != "Giới tính") && (cbFilter.Text != "Tỉnh/Thành phố") && (cbFilter.Text != "Trạng thái");
            cbCountry.Visible = (cbFilter.Text == "Tỉnh/Thành phố");
            cbGender.Visible = (cbFilter.Text == "Giới tính");
            cbIsActive.Visible = (cbFilter.Text == "Trạng thái");

            if (txtSearch.Visible) { txtSearch.Clear(); txtSearch.Focus(); }
            if (cbCountry.Visible) cbCountry.SelectedIndex = 0;
            if (cbGender.Visible) cbGender.SelectedIndex = 0;
            if (cbIsActive.Visible) cbIsActive.SelectedIndex = 0;

            _dtAllUsers.DefaultView.RowFilter = "";
            lblNumberOfRecords.Text = dgvUsersList.Rows.Count.ToString();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_dtAllUsers == null || _dtAllUsers.Rows.Count == 0) return;
            string ColumnName = _GetRealColumnNameInDB();
            string FilterValue = txtSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(FilterValue) || cbFilter.Text == "Không lọc")
                _dtAllUsers.DefaultView.RowFilter = "";
            else
            {
                if (cbFilter.Text == "Mã người dùng")
                    _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnName, FilterValue);
                else
                    _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", ColumnName, FilterValue);
            }
            lblNumberOfRecords.Text = dgvUsersList.Rows.Count.ToString();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Mã người dùng")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void ShowUserDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // SỬA LỖI: Thêm tham số true để cho phép nút Chỉnh sửa hiện lên trong trang Chi tiết
            frmShowUserDetails frm = new frmShowUserDetails(_GetUserIDFromDGV(), true);
            frm.ShowDialog();
            _RefreshUsersList();
        }

        private void EditUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditUser EditUser = new frmAddEditUser(_GetUserIDFromDGV());
            EditUser.ShowDialog();
            _RefreshUsersList();
        }

        private void ChangePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // SỬA LỖI: Thêm tham số false (Thường đổi mật khẩu không cần hiện nút sửa info Person)
            frmChangePassword ChangePassword = new frmChangePassword(_GetUserIDFromDGV(), false);
            ChangePassword.ShowDialog();
            _RefreshUsersList();
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser();
            frm.ShowDialog();
            _RefreshUsersList();
        }

        private void dgvUsersList_DoubleClick(object sender, EventArgs e)
        {
            ShowUserDetailsToolStripMenuItem1.PerformClick();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (clsUser.DeleteUser(_GetUserIDFromDGV()))
                {
                    MessageBox.Show("Xóa thành công!");
                    _RefreshUsersList();
                }
                else MessageBox.Show("Xóa thất bại!");
            }
        }

        private void cmsEditProfile_Opening(object sender, CancelEventArgs e)
        {
            if (dgvUsersList.Rows.Count == 0) { e.Cancel = true; return; }
            DeleteToolStripMenuItem.Enabled = ((int)dgvUsersList.CurrentRow.Cells["UserID"].Value != clsGlobal.CurrentUser.UserID);
        }

        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllUsers == null || _dtAllUsers.Rows.Count == 0)
                return;

            if (cbFilter.Text != "Tỉnh/Thành phố")
                return;

            if (cbCountry.SelectedValue == null || cbCountry.SelectedIndex == 0 || cbCountry.SelectedValue.ToString() == "0")
            {
                _dtAllUsers.DefaultView.RowFilter = "";
            }
            else
            {
                string columnName = _GetProvinceColumnName();
                string filterValue = cbCountry.Text.Replace("'", "''");
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = '{1}'", columnName, filterValue);
            }

            lblNumberOfRecords.Text = dgvUsersList.Rows.Count.ToString();
        }
    }
}