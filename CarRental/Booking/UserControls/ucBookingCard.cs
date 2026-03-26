using CarRental.GlobalClasses;
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

namespace CarRental.Booking.UserControls
{
    public partial class ucBookingCard : UserControl
    {
        private int? _BookingID = null;
        private clsBooking _Booking;

        public int? BookingID => _BookingID;
        public clsBooking BookingInfo => _Booking;
        
        public ucBookingCard()
        {
            InitializeComponent();
        }

        private void _FillBookingInfo()
        {
            btnTransactionInfo.Enabled = true;

            string customerProvince = _Booking.CustomerInfo?.ProvinceInfo?.ProvinceName;
            string customerAddress = _Booking.CustomerInfo?.Address;
            string customerLocation = string.Empty;

            if (!string.IsNullOrWhiteSpace(customerProvince) && !string.IsNullOrWhiteSpace(customerAddress))
                customerLocation = customerProvince + " - " + customerAddress;
            else if (!string.IsNullOrWhiteSpace(customerProvince))
                customerLocation = customerProvince;
            else if (!string.IsNullOrWhiteSpace(customerAddress))
                customerLocation = customerAddress;

            lblBookingID.Text = _Booking.BookingID?.ToString();
            lblCustomerID.Text = _Booking.CustomerID?.ToString();
            lblVehicleID.Text = _Booking.VehicleID?.ToString();
            lblStartDate.Text = clsFormat.DateToShort(_Booking.RentalStartDate);
            lblEndDate.Text = clsFormat.DateToShort(_Booking.RentalEndDate);
            lblInitialRentalDays.Text = _Booking.InitialRentalDays?.ToString();
            lblInitialTotalDueAmount.Text = _Booking.InitialTotalDueAmount.HasValue
                ? _Booking.InitialTotalDueAmount.Value.ToString("N0") + " VNĐ"
                : "Không có";

            lblPickUpLocation.Text = !string.IsNullOrWhiteSpace(_Booking.PickupLocation)
                ? _Booking.PickupLocation
                : (!string.IsNullOrWhiteSpace(customerLocation) ? customerLocation : "Chưa cập nhật");

            lblDropOffLocation.Text = !string.IsNullOrWhiteSpace(_Booking.DropoffLocation)
                ? _Booking.DropoffLocation
                : (!string.IsNullOrWhiteSpace(customerLocation) ? customerLocation : "Chưa cập nhật");

            lblInitialCheckNotes.Text = string.IsNullOrWhiteSpace(_Booking.InitialCheckNotes) ? "Không có ghi chú" : _Booking.InitialCheckNotes;
        }

        public void Reset()
        {
            _BookingID = null;    
            _Booking = null;

            lblBookingID.Text = "[????]";
            lblCustomerID.Text = "[????]";
            lblVehicleID.Text = "[????]";
            lblStartDate.Text = "[????]";
            lblEndDate.Text = "[????]";
            lblInitialRentalDays.Text = "[????]";
            lblInitialTotalDueAmount.Text = "[????]";
            lblPickUpLocation.Text = "[????]";
            lblDropOffLocation.Text = "[????]";
            lblInitialCheckNotes.Text = "[????]";

            btnTransactionInfo.Enabled = false;
        }

        public void LoadBookingInfo(int? BookingID)
        {
            _BookingID = BookingID;

            if (!_BookingID.HasValue)
            {
                MessageBox.Show("Không có lịch đặt", "Thiếu dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _Booking = clsBooking.Find(_BookingID.Value);

            if (_Booking == null)
            {
                MessageBox.Show($"Không tìm thấy lịch đặt với ID = {BookingID}", "Thiếu dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                _BookingID = null;

                return;
            }

            _FillBookingInfo();
        }

        private void btnTransactionInfo_Click(object sender, EventArgs e)
        {
            frmShowTransactionDetails ShowTransactionDetails = new frmShowTransactionDetails(BookingInfo.TransactionInfo.TransactionID);
            ShowTransactionDetails.ShowDialog();
        }
    }
}
