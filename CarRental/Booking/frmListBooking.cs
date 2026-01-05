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
                case "Booking ID":
                case "Mã lịch đặt":
                    return "BookingID";

                case "Customer ID":
                case "Mã khách hàng":
                    return "CustomerID";

                case "Customer Name":
                case "Tên khách hàng":
                    return "CustomerName";

                case "Vehicle ID":
                case "Mã xe":
                    return "VehicleID";

                case "Start Date":
                case "Ngày nhận xe":
                    return "RentalStartDate";

                case "End Date":
                case "Ngày trả xe":
                    return "RentalEndDate";

                case "Pickup Location":
                case "Điểm nhận":
                    return "PickupLocation";

                case "Drop Off Location":
                case "Drop Off Locatioin":
                case "Điểm trả":
                    return "DropoffLocation";

                default:
                    return "None";
            }
        }

        private void _RefreshBookingList()
        {
            _dtAllBooking = clsBooking.GetAllRentalBooking();
            dgvBookingList.DataSource = _dtAllBooking;
            lblNumberOfRecords.Text = dgvBookingList.Rows.Count.ToString();

            if (dgvBookingList.Rows.Count > 0)
            {
                dgvBookingList.Columns[0].HeaderText = "Mã đặt xe";
                dgvBookingList.Columns[0].Width = 140;

                dgvBookingList.Columns[1].HeaderText = "Tên khách hàng";
                dgvBookingList.Columns[1].Width = 190;

                dgvBookingList.Columns[2].HeaderText = "Mã khách hàng";
                dgvBookingList.Columns[2].Width = 150;

                dgvBookingList.Columns[3].HeaderText = "Mã xe";
                dgvBookingList.Columns[3].Width = 125;

                dgvBookingList.Columns[4].HeaderText = "Ngày nhận xe";
                dgvBookingList.Columns[4].Width = 150;

                dgvBookingList.Columns[5].HeaderText = "Ngày trả xe";
                dgvBookingList.Columns[5].Width = 150;

                dgvBookingList.Columns[6].HeaderText = "Điểm nhận";
                dgvBookingList.Columns[6].Width = 150;

                dgvBookingList.Columns[7].HeaderText = "Điểm trả";
                dgvBookingList.Columns[7].Width = 150;

                dgvBookingList.Columns[8].HeaderText = "Giá thuê/ngày";
                dgvBookingList.Columns[8].Width = 180;

                dgvBookingList.Columns[9].HeaderText = "Số ngày thuê ban đầu";
                dgvBookingList.Columns[9].Width = 180;

                dgvBookingList.Columns[10].HeaderText = "Tổng tiền dự kiến";
                dgvBookingList.Columns[10].Width = 210;
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
            bool isNoneFilter = cbFilter.Text == "None" || cbFilter.Text == "Không lọc";
            bool isStartDate = cbFilter.Text == "Start Date" || cbFilter.Text == "Ngày nhận xe";
            bool isEndDate = cbFilter.Text == "End Date" || cbFilter.Text == "Ngày trả xe";
            bool isDateFilter = isStartDate || isEndDate;

            txtSearch.Visible = !isNoneFilter && !isDateFilter;

            if (isDateFilter)
            {
                // refresh
                _dtAllBooking.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvBookingList.Rows.Count.ToString();

                string columnName = _GetRealColumnNameInDB();
                dtpDate.Visible = true;

                if (dgvBookingList.Rows.Count > 0)
                {
                    dtpDate.Value = (DateTime)dgvBookingList.CurrentRow.Cells[columnName].Value;
                }
                else
                {
                    dtpDate.Value = DateTime.Now;
                }
            }
            else
            {
                dtpDate.Visible = false;
            }

            if (txtSearch.Visible)
            {
                txtSearch.Text = "";
                txtSearch.Focus();
                _dtAllBooking.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvBookingList.Rows.Count.ToString();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_dtAllBooking.Rows.Count == 0)
            {
                return;
            }

            string ColumnName = _GetRealColumnNameInDB();

            if (string.IsNullOrWhiteSpace(txtSearch.Text.Trim()) ||
                cbFilter.Text == "None" || cbFilter.Text == "Không lọc")
            {
                _dtAllBooking.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvBookingList.Rows.Count.ToString();

                return;
            }

            bool isNumericFilter = cbFilter.Text == "Booking ID" || cbFilter.Text == "Customer ID" ||
                                   cbFilter.Text == "Vehicle ID" || cbFilter.Text == "Mã lịch đặt" ||
                                   cbFilter.Text == "Mã khách hàng" || cbFilter.Text == "Mã xe";

            if (isNumericFilter)
            {
                // search with numbers
                _dtAllBooking.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnName, txtSearch.Text.Trim());
            }
            else
            {
                // search with string
                _dtAllBooking.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", ColumnName, txtSearch.Text.Trim());
            }

            lblNumberOfRecords.Text = dgvBookingList.Rows.Count.ToString();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Booking ID" || cbFilter.Text == "Customer ID" || cbFilter.Text == "Vehicle ID" ||
                cbFilter.Text == "Mã lịch đặt" || cbFilter.Text == "Mã khách hàng" || cbFilter.Text == "Mã xe")
            {
                // make sure that the user can only enter the numbers
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            if (_dtAllBooking.Rows.Count == 0)
            {
                return;
            }

            if (cbFilter.Text == "Start Date" || cbFilter.Text == "Ngày nhận xe")
            {
                _dtAllBooking.DefaultView.RowFilter =
                        string.Format("[{0}] = #{1}#", "RentalStartDate", dtpDate.Value.ToString("yyyy-MM-dd")); // Including # around a date value is a way to inform the DataView that the value being compared is a date
            }
            else
            {
                _dtAllBooking.DefaultView.RowFilter =
                        string.Format("[{0}] = #{1}#", "RentalEndDate", dtpDate.Value.ToString("yyyy-MM-dd"));
            }


            lblNumberOfRecords.Text = dgvBookingList.Rows.Count.ToString();
        }

        private void ShowBookingDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowBookingDetailsWithCustomerAndVehicle ShowBookingDetails = new frmShowBookingDetailsWithCustomerAndVehicle(_GetBookingIDFromDGV());
            ShowBookingDetails.ShowDialog();

            _RefreshBookingList();
            txtSearch.Clear();
        }

        private void btnAddNewBooking_Click(object sender, EventArgs e)
        {
            frmAddBooking AddBooking = new frmAddBooking();
            AddBooking.ShowDialog();

            _RefreshBookingList();
        }

        private void cmsEditProfile_Opening(object sender, CancelEventArgs e)
        {
            if (dgvBookingList.Rows.Count == 0)
            {
                ShowBookingDetailsToolStripMenuItem1.Enabled = false;
                return;
            }

            clsBooking Booking = clsBooking.Find((int)dgvBookingList.CurrentRow.Cells["BookingID"].Value);

            if (Booking == null)
            {
                return;
            }

            ReturnToolStripMenuItem.Enabled = !Booking.IsBookingReturned;
        }

        private void dgvBookingList_DoubleClick(object sender, EventArgs e)
        {
            if (dgvBookingList.Rows.Count == 0)
                return;

            frmShowBookingDetailsWithCustomerAndVehicle ShowBookingDetails = new frmShowBookingDetailsWithCustomerAndVehicle(_GetBookingIDFromDGV());
            ShowBookingDetails.ShowDialog();

            _RefreshBookingList();
        }

        private void ReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReturnVehicle ReturnVehicle = new frmReturnVehicle((int)dgvBookingList.CurrentRow.Cells["BookingID"].Value);
            ReturnVehicle.ShowDialog();

            _RefreshBookingList();
        }
    }
}
