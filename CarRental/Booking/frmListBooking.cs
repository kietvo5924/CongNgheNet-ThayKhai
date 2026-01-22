using CarRental.Return;
using CarRental_Business;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace CarRental.Booking
{
    public partial class frmListBooking : Form
    {
        private DataTable _dtAllBooking;

        public frmListBooking()
        {
            InitializeComponent();
        }

        private string _GetRealColumnNameInDB()
        {
            switch (cbFilter.Text)
            {
                case "Mã lịch đặt": return "BookingID";
                case "Mã khách hàng": return "CustomerID";
                case "Tên khách hàng": return "CustomerName";
                case "Mã xe": return "VehicleID";
                case "Ngày nhận xe": return "RentalStartDate";
                case "Ngày trả xe": return "RentalEndDate";
                case "Điểm nhận": return "PickupLocation";
                case "Điểm trả": return "DropoffLocation";
                default: return "None";
            }
        }

        private void _RefreshBookingList()
        {
            _dtAllBooking = clsBooking.GetAllRentalBooking();
            dgvBookingList.DataSource = _dtAllBooking;
            lblNumberOfRecords.Text = dgvBookingList.Rows.Count.ToString();

            if (dgvBookingList.Rows.Count > 0)
            {
                dgvBookingList.Columns[0].HeaderText = "Mã đặt";
                dgvBookingList.Columns[1].HeaderText = "Khách hàng";
                dgvBookingList.Columns[2].HeaderText = "Mã KH";
                dgvBookingList.Columns[3].HeaderText = "Mã xe";
                dgvBookingList.Columns[4].HeaderText = "Ngày thuê";
                dgvBookingList.Columns[5].HeaderText = "Ngày trả";
                dgvBookingList.Columns[6].HeaderText = "Điểm nhận";
                dgvBookingList.Columns[7].HeaderText = "Điểm trả";
                dgvBookingList.Columns[8].HeaderText = "Giá/Ngày";
                dgvBookingList.Columns[9].HeaderText = "Số ngày";
                dgvBookingList.Columns[10].HeaderText = "Tổng tiền";

                var rentalPriceColumn = dgvBookingList.Columns["RentalPricePerDay"];
                if (rentalPriceColumn != null)
                {
                    rentalPriceColumn.DefaultCellStyle.Format = "N0";
                    rentalPriceColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                else if (dgvBookingList.Columns.Count > 8)
                {
                    dgvBookingList.Columns[8].DefaultCellStyle.Format = "N0";
                    dgvBookingList.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                var initialTotalColumn = dgvBookingList.Columns["InitialTotalDueAmount"];
                if (initialTotalColumn != null)
                {
                    initialTotalColumn.DefaultCellStyle.Format = "N0";
                    initialTotalColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                else if (dgvBookingList.Columns.Count > 10)
                {
                    dgvBookingList.Columns[10].DefaultCellStyle.Format = "N0";
                    dgvBookingList.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                // Tự động căn chỉnh độ rộng cột
                dgvBookingList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private int _GetBookingIDFromDGV()
        {
            return (int)dgvBookingList.CurrentRow.Cells["BookingID"].Value;
        }

        private void frmListBooking_Load(object sender, EventArgs e)
        {
            _RefreshBookingList();
            cbFilter.SelectedIndex = 0;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isNoneFilter = cbFilter.Text == "Không lọc";
            bool isDateFilter = cbFilter.Text == "Ngày nhận xe" || cbFilter.Text == "Ngày trả xe";

            txtSearch.Visible = !isNoneFilter && !isDateFilter;
            dtpDate.Visible = isDateFilter;

            if (txtSearch.Visible)
            {
                txtSearch.Clear();
                txtSearch.Focus();
            }

            _dtAllBooking.DefaultView.RowFilter = "";
            lblNumberOfRecords.Text = dgvBookingList.Rows.Count.ToString();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_dtAllBooking == null || _dtAllBooking.Rows.Count == 0) return;

            string ColumnName = _GetRealColumnNameInDB();
            string FilterValue = txtSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(FilterValue) || cbFilter.Text == "Không lọc")
            {
                _dtAllBooking.DefaultView.RowFilter = "";
            }
            else
            {
                bool isNumeric = cbFilter.Text == "Mã lịch đặt" || cbFilter.Text == "Mã khách hàng" || cbFilter.Text == "Mã xe";
                if (isNumeric)
                    _dtAllBooking.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnName, FilterValue);
                else
                    _dtAllBooking.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", ColumnName, FilterValue);
            }
            lblNumberOfRecords.Text = dgvBookingList.Rows.Count.ToString();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool isNumeric = cbFilter.Text == "Mã lịch đặt" || cbFilter.Text == "Mã khách hàng" || cbFilter.Text == "Mã xe";
            if (isNumeric)
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            if (_dtAllBooking == null || _dtAllBooking.Rows.Count == 0) return;

            string ColumnName = (cbFilter.Text == "Ngày nhận xe") ? "RentalStartDate" : "RentalEndDate";
            _dtAllBooking.DefaultView.RowFilter = string.Format("[{0}] = #{1}#", ColumnName, dtpDate.Value.ToString("yyyy-MM-dd"));
            lblNumberOfRecords.Text = dgvBookingList.Rows.Count.ToString();
        }

        private void btnAddNewBooking_Click(object sender, EventArgs e)
        {
            frmAddBooking frm = new frmAddBooking();
            frm.ShowDialog();
            _RefreshBookingList();
        }

        private void ShowBookingDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowBookingDetailsWithCustomerAndVehicle frm = new frmShowBookingDetailsWithCustomerAndVehicle(_GetBookingIDFromDGV());
            frm.ShowDialog();
            _RefreshBookingList();
        }

        private void ReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReturnVehicle frm = new frmReturnVehicle(_GetBookingIDFromDGV());
            frm.ShowDialog();
            _RefreshBookingList();
        }

        private void dgvBookingList_DoubleClick(object sender, EventArgs e)
        {
            if (dgvBookingList.Rows.Count > 0)
                ShowBookingDetailsToolStripMenuItem1.PerformClick();
        }

        private void cmsEditProfile_Opening(object sender, CancelEventArgs e)
        {
            if (dgvBookingList.Rows.Count == 0)
            {
                e.Cancel = true;
                return;
            }
            clsBooking Booking = clsBooking.Find((int)dgvBookingList.CurrentRow.Cells["BookingID"].Value);
            ReturnToolStripMenuItem.Enabled = (Booking != null && !Booking.IsBookingReturned);
        }
    }
}