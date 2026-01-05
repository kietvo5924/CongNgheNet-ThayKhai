using CarRental.Return;
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

namespace CarRental.Booking.UserControls
{
    public partial class ucCustomerBookingHistory : UserControl
    {
        private DataTable _dtAllBookingHistory;

        private int? _CustomerID = null;

        public ucCustomerBookingHistory()
        {
            InitializeComponent();
        }

        private void _RefreshBookingHistoryList()
        {
            _dtAllBookingHistory = clsBooking.GetBookingHistoryByCustomerID(_CustomerID);
            dgvBookingHistoryList.DataSource = _dtAllBookingHistory;

            lblNumberOfRecords.Text = dgvBookingHistoryList.Rows.Count.ToString();

            if (dgvBookingHistoryList.Rows.Count > 0)
            {
                dgvBookingHistoryList.Columns[0].HeaderText = "Mã đặt xe";
                dgvBookingHistoryList.Columns[0].Width = 125;

                dgvBookingHistoryList.Columns[1].HeaderText = "Khách hàng";
                dgvBookingHistoryList.Columns[1].Width = 190;

                dgvBookingHistoryList.Columns[2].HeaderText = "Mã khách hàng";
                dgvBookingHistoryList.Columns[2].Width = 125;

                dgvBookingHistoryList.Columns[3].HeaderText = "Mã xe";
                dgvBookingHistoryList.Columns[3].Width = 125;

                dgvBookingHistoryList.Columns[4].HeaderText = "Ngày bắt đầu thuê";
                dgvBookingHistoryList.Columns[4].Width = 160;

                dgvBookingHistoryList.Columns[5].HeaderText = "Ngày kết thúc thuê";
                dgvBookingHistoryList.Columns[5].Width = 160;

                dgvBookingHistoryList.Columns[6].HeaderText = "Điểm nhận xe";
                dgvBookingHistoryList.Columns[6].Width = 160;

                dgvBookingHistoryList.Columns[7].HeaderText = "Điểm trả xe";
                dgvBookingHistoryList.Columns[7].Width = 160;

                dgvBookingHistoryList.Columns[8].HeaderText = "Giá thuê/ngày";
                dgvBookingHistoryList.Columns[8].Width = 180;

                dgvBookingHistoryList.Columns[9].HeaderText = "Số ngày thuê ban đầu";
                dgvBookingHistoryList.Columns[9].Width = 180;

                dgvBookingHistoryList.Columns[10].HeaderText = "Tổng phải trả ban đầu";
                dgvBookingHistoryList.Columns[10].Width = 210;
            }
        }

        private int _GetBookingIDFromDGV()
        {
            return (int)dgvBookingHistoryList.CurrentRow.Cells["BookingID"].Value;
        }

        public void LoadCustomerBookingHistoryInfo(int CustomerID)
        {
            this._CustomerID = CustomerID;
            _RefreshBookingHistoryList();
        }

        public void Clear()
        {
            _dtAllBookingHistory.Clear();
        }

        private void ShowBookingDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowBookingDetailsWithCustomerAndVehicle ShowBookingDetails = new frmShowBookingDetailsWithCustomerAndVehicle(_GetBookingIDFromDGV());
            ShowBookingDetails.ShowDialog();

            _RefreshBookingHistoryList();
        }

        private void cmsEditProfile_Opening(object sender, CancelEventArgs e)
        {
            if (dgvBookingHistoryList.Rows.Count == 0)
            {
                cmsEditProfile.Enabled = false;
                return;
            }

            clsBooking Booking = clsBooking.Find((int)dgvBookingHistoryList.CurrentRow.Cells["BookingID"].Value);

            if (Booking == null)
            {
                return;
            }

            ReturnToolStripMenuItem.Enabled = !Booking.IsBookingReturned;
        }

        private void dgvBookingHistoryList_DoubleClick(object sender, EventArgs e)
        {
            if (dgvBookingHistoryList.Rows.Count == 0)
                return;

            frmShowBookingDetailsWithCustomerAndVehicle ShowBookingDetails = new frmShowBookingDetailsWithCustomerAndVehicle(_GetBookingIDFromDGV());
            ShowBookingDetails.ShowDialog();

            _RefreshBookingHistoryList();
        }

        private void ReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReturnVehicle ReturnVehicle = new frmReturnVehicle((int)dgvBookingHistoryList.CurrentRow.Cells["BookingID"].Value);
            ReturnVehicle.ShowDialog();

            _RefreshBookingHistoryList();
        }
    }
}
