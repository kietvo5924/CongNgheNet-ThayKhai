using CarRental.GlobalClasses;
using CarRental_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
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
            cbCountry.Items.Add("Tất cả");

            DataTable dtCountries = clsCountry.GetAllCountriesName();

            foreach (DataRow Country in dtCountries.Rows)
            {
                cbCountry.Items.Add(Country["CountryName"].ToString());
            }
        }

        private string _GetRealColumnNameInDB()
        {
            switch (cbFilter.Text)
            {
                case "Mã người dùng":
                    return "UserID";

                case "Họ tên":
                    return "Name";

                case "Tên đăng nhập":
                    return "Username";

                case "Giới tính":
                    return "Gender";

                case "Quốc gia":
                    return "Country";

                case "Trạng thái":
                    return "IsActive";

                default:
                    return "None";
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
                dgvUsersList.Columns[0].Width = 125;

                dgvUsersList.Columns[1].HeaderText = "Họ tên";
                dgvUsersList.Columns[1].Width = 190;

                dgvUsersList.Columns[2].HeaderText = "Giới tính";
                dgvUsersList.Columns[2].Width = 100;

                dgvUsersList.Columns[3].HeaderText = "Ngày sinh";
                dgvUsersList.Columns[3].Width = 130;

                dgvUsersList.Columns[4].HeaderText = "Tên đăng nhập";
                dgvUsersList.Columns[4].Width = 150;

                dgvUsersList.Columns[5].HeaderText = "Quốc gia";
                dgvUsersList.Columns[5].Width = 100;

                dgvUsersList.Columns[6].HeaderText = "Ngày tạo";
                dgvUsersList.Columns[6].Width = 180;

                dgvUsersList.Columns[7].HeaderText = "Trạng thái";
                dgvUsersList.Columns[7].Width = 120;
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
            txtSearch.Visible = (cbFilter.Text != "Không lọc") && (cbFilter.Text != "Giới tính") && (cbFilter.Text != "Quốc gia") && (cbFilter.Text != "Trạng thái");

            cbCountry.Visible = (cbFilter.Text == "Quốc gia");

            cbGender.Visible = (cbFilter.Text == "Giới tính");

            cbIsActive.Visible = (cbFilter.Text == "Trạng thái");

            if (txtSearch.Visible)
            {
                txtSearch.Text = "";
                txtSearch.Focus();
            }

            if (cbCountry.Visible)
            {
                cbCountry.SelectedIndex = 0;
            }

            if (cbGender.Visible)
            {
                cbGender.SelectedIndex = 0;
            }

            if (cbIsActive.Visible)
            {
                cbIsActive.SelectedIndex = 0;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_dtAllUsers.Rows.Count == 0)
            {
                return;
            }

            string ColumnName = _GetRealColumnNameInDB();

            if (string.IsNullOrWhiteSpace(txtSearch.Text.Trim()) || cbFilter.Text == "Không lọc")
            {
                _dtAllUsers.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvUsersList.Rows.Count.ToString();

                return;
            }

            if (cbFilter.Text == "Mã người dùng")
            {
                // search with numbers
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnName, txtSearch.Text.Trim());
            }
            else
            {
                // search with string
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", ColumnName, txtSearch.Text.Trim());
            }

            lblNumberOfRecords.Text = dgvUsersList.Rows.Count.ToString();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Mã người dùng")
            {
                // make sure that the user can only enter the numbers
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllUsers.Rows.Count == 0)
            {
                return;
            }

            if (cbGender.Text == "Tất cả")
            {
                _dtAllUsers.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvUsersList.Rows.Count.ToString();

                return;
            }

            _dtAllUsers.DefaultView.RowFilter =
                string.Format("[{0}] like '{1}%'", "Gender", cbGender.Text);

            lblNumberOfRecords.Text = dgvUsersList.Rows.Count.ToString();
        }

        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllUsers.Rows.Count == 0)
            {
                return;
            }

            if (cbCountry.Text == "Tất cả")
            {
                _dtAllUsers.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvUsersList.Rows.Count.ToString();

                return;
            }

            _dtAllUsers.DefaultView.RowFilter =
                string.Format("[{0}] like '{1}%'", "Country", cbCountry.Text);

            lblNumberOfRecords.Text = dgvUsersList.Rows.Count.ToString();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllUsers.Rows.Count == 0)
            {
                return;
            }

            if (cbIsActive.Text == "Tất cả")
            {
                _dtAllUsers.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvUsersList.Rows.Count.ToString();

                return;
            }

            _dtAllUsers.DefaultView.RowFilter =
                string.Format("[{0}] = {1}", "IsActive", (cbIsActive.Text == "Kích hoạt"));

            lblNumberOfRecords.Text = dgvUsersList.Rows.Count.ToString();
        }

        private void ShowUserDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowUserDetails ShowUserDetails = new frmShowUserDetails(_GetUserIDFromDGV());
            ShowUserDetails.ShowDialog();

            _RefreshUsersList();
            txtSearch.Clear();
        }

        private void EditUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditUser EditUser = new frmAddEditUser(_GetUserIDFromDGV());
            EditUser.ShowDialog();

            _RefreshUsersList();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa người dùng này?", "Xác nhận", MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (clsUser.DeleteUser(_GetUserIDFromDGV()))
                {
                    MessageBox.Show("Xóa dữ liệu thành công", "Đã xóa",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _RefreshUsersList();
                }
                else
                {
                    MessageBox.Show("Xóa dữ liệu thất bại", "Lỗi",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ChangePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword ChangePassword = new frmChangePassword(_GetUserIDFromDGV());
            ChangePassword.ShowDialog();

            _RefreshUsersList();
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmAddEditUser EditUser = new frmAddEditUser();
            EditUser.ShowDialog();

            _RefreshUsersList();
        }

        private void dgvUsersList_DoubleClick(object sender, EventArgs e)
        {
            frmShowUserDetails ShowUserDetails = new frmShowUserDetails(_GetUserIDFromDGV());
            ShowUserDetails.ShowDialog();

            _RefreshUsersList();
        }

        private void cmsEditProfile_Opening(object sender, CancelEventArgs e)
        {
            DeleteToolStripMenuItem.Enabled = ((int)dgvUsersList.CurrentRow.Cells["UserID"].Value != clsGlobal.CurrentUser.UserID);
        }
    }
}
