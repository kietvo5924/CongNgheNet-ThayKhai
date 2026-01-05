using CarRental.Booking;
using CarRental.Transaction;
using CarRental_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                case "Mã khách hàng":
                    return "CustomerID";

                case "Họ tên":
                    return "Name";

                case "Số bằng lái":
                    return "DriverLicenseNumber";

                case "Giới tính":
                    return "Gender";

                case "Điện thoại":
                    return "Phone";

                case "Email":
                    return "Email";

                case "Quốc gia":
                    return "Country";

                default:
                    return "None";
            }
        }

        private void _RefreshCustomersList()
        {
            _dtAllCustomers = clsCustomer.GetAllCustomers();
            dgvCustomersList.DataSource = _dtAllCustomers;
            lblNumberOfRecords.Text = dgvCustomersList.Rows.Count.ToString();

            if (dgvCustomersList.Rows.Count > 0)
            {
                dgvCustomersList.Columns[0].HeaderText = "Mã khách hàng";
                dgvCustomersList.Columns[0].Width = 125;

                dgvCustomersList.Columns[1].HeaderText = "Họ tên";
                dgvCustomersList.Columns[1].Width = 190;

                dgvCustomersList.Columns[2].HeaderText = "Giới tính";
                dgvCustomersList.Columns[2].Width = 100;

                dgvCustomersList.Columns[3].HeaderText = "Quốc gia";
                dgvCustomersList.Columns[3].Width = 100;

                dgvCustomersList.Columns[4].HeaderText = "Điện thoại";
                dgvCustomersList.Columns[4].Width = 110;

                dgvCustomersList.Columns[5].HeaderText = "Ngày sinh";
                dgvCustomersList.Columns[5].Width = 130;

                dgvCustomersList.Columns[6].HeaderText = "Email";
                dgvCustomersList.Columns[6].Width = 160;

                dgvCustomersList.Columns[7].HeaderText = "Số bằng lái";
                dgvCustomersList.Columns[7].Width = 160;

                dgvCustomersList.Columns[8].HeaderText = "Ngày tạo";
                dgvCustomersList.Columns[8].Width = 180;
            }
        }

        private int _GetCustomerIDFromDGV()
        {
            return (int)dgvCustomersList.CurrentRow.Cells["CustomerID"].Value;
        }

        private void frmListCustomers_Load(object sender, EventArgs e)
        {
            _RefreshCustomersList();
            _FillCountryComboBox();

            cbFilter.SelectedIndex = 0;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Visible = (cbFilter.Text != "Không lọc") && (cbFilter.Text != "Giới tính") && (cbFilter.Text != "Quốc gia");

            cbCountry.Visible = (cbFilter.Text == "Quốc gia");

            cbGender.Visible = (cbFilter.Text == "Giới tính");

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
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_dtAllCustomers.Rows.Count == 0)
            {
                return;
            }

            string ColumnName = _GetRealColumnNameInDB();

            if (string.IsNullOrWhiteSpace(txtSearch.Text.Trim()) || cbFilter.Text == "Không lọc")
            {
                _dtAllCustomers.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvCustomersList.Rows.Count.ToString();

                return;
            }

            if (cbFilter.Text == "Mã khách hàng")
            {
                // search with numbers
                _dtAllCustomers.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnName, txtSearch.Text.Trim());
            }
            else
            {
                // search with string
                _dtAllCustomers.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", ColumnName, txtSearch.Text.Trim());
            }

            lblNumberOfRecords.Text = dgvCustomersList.Rows.Count.ToString();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Mã khách hàng" || cbFilter.Text == "Điện thoại")
            {
                // make sure that the user can only enter the numbers
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllCustomers.Rows.Count == 0)
            {
                return;
            }

            if (cbGender.Text == "Tất cả")
            {
                _dtAllCustomers.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvCustomersList.Rows.Count.ToString();

                return;
            }

            _dtAllCustomers.DefaultView.RowFilter =
                string.Format("[{0}] like '{1}%'", "Gender", cbGender.Text);

            lblNumberOfRecords.Text = dgvCustomersList.Rows.Count.ToString();
        }

        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllCustomers.Rows.Count == 0)
            {
                return;
            }

            if (cbCountry.Text == "Tất cả")
            {
                _dtAllCustomers.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvCustomersList.Rows.Count.ToString();

                return;
            }

            _dtAllCustomers.DefaultView.RowFilter =
                string.Format("[{0}] like '{1}%'", "Country", cbCountry.Text);

            lblNumberOfRecords.Text = dgvCustomersList.Rows.Count.ToString();
        }

        private void ShowCustomerDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowCustomerDetails ShowCustomerDetails =
                new frmShowCustomerDetails(_GetCustomerIDFromDGV());

            ShowCustomerDetails.ShowDialog();

            _RefreshCustomersList();
            txtSearch.Clear();
        }

        private void EditCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditCustomer EditCustomer = new frmAddEditCustomer(_GetCustomerIDFromDGV());
            EditCustomer.ShowDialog();

            _RefreshCustomersList();
        }

        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            frmAddEditCustomer AddCustomer = new frmAddEditCustomer();
            AddCustomer.ShowDialog();

            _RefreshCustomersList();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (clsCustomer.DeleteCustomer(_GetCustomerIDFromDGV()))
                {
                    MessageBox.Show("Xóa dữ liệu thành công", "Đã xóa",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _RefreshCustomersList();
                }
                else
                {
                    MessageBox.Show("Xóa dữ liệu thất bại", "Lỗi",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvCustomersList_DoubleClick(object sender, EventArgs e)
        {
            frmShowCustomerDetails ShowCustomerDetails =
                new frmShowCustomerDetails(_GetCustomerIDFromDGV());

            ShowCustomerDetails.ShowDialog();

            _RefreshCustomersList();
        }

        private void ShowCustomerBookingHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowCustomerBookingHistory ShowCustomerBookingHistory =
                new frmShowCustomerBookingHistory(_GetCustomerIDFromDGV());

            ShowCustomerBookingHistory.ShowDialog();

            _RefreshCustomersList();
        }

        private void ShowCustomerTransactionHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowCustomerTransactionHistory ShowCustomerTransactionHistory =
                new frmShowCustomerTransactionHistory(_GetCustomerIDFromDGV());

            ShowCustomerTransactionHistory.ShowDialog();

            _RefreshCustomersList();
        }
    }
}
